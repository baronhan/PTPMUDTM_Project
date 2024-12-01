using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyKhachSan
{
    public partial class Form_TrangForm : Form
    {
        TrangFormBLL bll = new TrangFormBLL();
        private bool _btnThem = false;
        public Form_TrangForm()
        {
            InitializeComponent();
            loadData();
            showHideControl(true);
            enableControl(false);
        }

        private void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnSua.Visible = t;
            btnXoa.Visible = t;
            btnThoat.Visible = t;
            btnLuu.Visible = !t;
            btnBoQua.Visible = !t;
        }
        private void enableControl(bool t)
        {
            txtUrl.Enabled = t;
        }
        private void reFresh()
        {
            txtUrl.Text = "";
        }

        private void loadData()
        {
            List<TrangFormDTO> list = bll.getDanhSachTrangForm();
            dgvDSTrangForm.DataSource = list;

            dgvDSTrangForm.Columns[0].HeaderText = "ID Trang Form";
            dgvDSTrangForm.Columns[1].HeaderText = "Tên URL";

            dgvDSTrangForm.Columns[0].Visible = false;

            dgvDSTrangForm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            showHideControl(false);
            enableControl(true);
            _btnThem = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tb = "";
            enableControl(false);

            if (dgvDSTrangForm.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDSTrangForm.SelectedRows[0];

                int idForm = (int)selectedRow.Cells["formId"].Value;
                string url = selectedRow.Cells["url"].Value.ToString();

                bool hasForm = bll.HasFormInPermission(idForm);

                if (hasForm)
                {
                    tb = $"Không thể xóa {url} vì có người dùng đang có quyền truy cập vào Form này.";
                    MessageBox.Show(tb);
                    return;
                }

                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa trang form này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool kq = bll.deleteTrangForm(idForm);

                    if (kq)
                    {
                        tb = $"Bạn đã xóa {url} thành công";
                        loadData();
                        reFresh();
                    }
                    else
                    {
                        tb = "Xóa Trang Form thất bại!";
                        reFresh();
                    }
                }
                else
                {
                    tb = "Hủy xóa Trang Form.";
                }
            }
            else
            {
                tb = "Vui lòng chọn một Trang Form bạn muốn xóa trong danh sách Trang Form!";
            }

            MessageBox.Show(tb);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            showHideControl(false);
            enableControl(true);
            _btnThem = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tb = "";

            if (_btnThem)
            {
                TrangFormDTO form = new TrangFormDTO();
                if (string.IsNullOrEmpty(txtUrl.Text))
                {
                    MessageBox.Show("Đường dẫn URL không được bỏ trống!");
                    return;

                }
                else
                {
                    form.url = txtUrl.Text;
                }

                bool kq = bll.addTrangForm(form);

                if (kq)
                {
                    tb = "Bạn đã thêm mới Trang form thành công";
                    loadData();
                    reFresh();
                }
                else
                {
                    tb = "Thêm mới Trang form thất bại!";
                }
            }
            else
            {
                if (dgvDSTrangForm.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvDSTrangForm.SelectedRows[0];

                    int idForm = (int)selectedRow.Cells["formId"].Value;

                    TrangFormDTO formDTO = new TrangFormDTO();
                    formDTO.formId = idForm;
                    if (string.IsNullOrEmpty(txtUrl.Text))
                    {
                        MessageBox.Show("Đường dẫn URL không được bỏ trống!");
                        return;
                    }
                    else
                    {
                        formDTO.url = txtUrl.Text;
                    }
                    

                    bool kq = bll.updateTrangForm(formDTO);

                    if (kq)
                    {
                        tb = "Bạn đã cập nhật Trang form thành công!";
                        loadData();
                        reFresh();
                    }
                    else
                    {
                        tb = "Cập nhật Trang form thất bại!";
                        reFresh();
                    }
                }
                else
                {
                    tb = "Vui lòng chọn một Trang form bạn muốn chỉnh sửa trong danh sách Trang form!";
                }
            }

            MessageBox.Show(tb);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            showHideControl(true);
            enableControl(false);
            _btnThem = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDSTrangForm_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSTrangForm.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDSTrangForm.SelectedRows[0];
                selectedRow.ReadOnly = true;

                txtUrl.Text = selectedRow.Cells["url"].Value.ToString();
            }
        }
    }
}
