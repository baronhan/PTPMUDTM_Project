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
    public partial class Form_NhomNguoiDung : Form
    {
        NhomNguoiDungBLL bll = new NhomNguoiDungBLL();
        private bool _btnThem = false;
        public Form_NhomNguoiDung()
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
            txtTenNhom.Enabled = t;
        }
        private void reFresh()
        {
            txtTenNhom.Text = "";
        }

        private void loadData()
        {
            List<NhomNguoiDungDTO> list = bll.getDanhSachNhomNguoiDung();
            dgvDSNhomNguoiDung.DataSource = list;

            dgvDSNhomNguoiDung.Columns[0].HeaderText = "ID Nhóm Người Dùng";
            dgvDSNhomNguoiDung.Columns[1].HeaderText = "Tên Nhóm Người Dùng";

            dgvDSNhomNguoiDung.Columns[0].Visible = false;

            dgvDSNhomNguoiDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

            if (dgvDSNhomNguoiDung.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDSNhomNguoiDung.SelectedRows[0];

                int idNND = (int)selectedRow.Cells["userType"].Value;
                string tenNND = selectedRow.Cells["name"].Value.ToString();

                bool hasRooms = bll.HasUserInNhomNguoiDung(idNND);

                if (hasRooms)
                {
                    tb = $"Không thể xóa {tenNND} vì có người dùng đang nằm trong nhóm người dùng này.";
                    MessageBox.Show(tb);
                    return;
                }

                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhóm người dùng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool kq = bll.deleteNND(idNND);

                    if (kq)
                    {
                        tb = $"Bạn đã xóa {tenNND} thành công";
                        loadData();
                        reFresh();
                    }
                    else
                    {
                        tb = "Xóa Nhóm người dùng thất bại!";
                        reFresh();
                    }
                }
                else
                {
                    tb = "Hủy xóa Nhóm người dùng.";
                }
            }
            else
            {
                tb = "Vui lòng chọn một Nhóm người dùng bạn muốn xóa trong danh sách Nhóm người dùng!";
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
                NhomNguoiDungDTO nnd = new NhomNguoiDungDTO();
                if(string.IsNullOrEmpty(txtTenNhom.Text))
                {
                    MessageBox.Show("Tên nhóm người dùng không được bỏ trống!");
                    return;

                }
                else
                {
                    nnd.name = txtTenNhom.Text;
                }    

                bool kq = bll.addNhomNguoiDung(nnd);

                if (kq)
                {
                    tb = "Bạn đã thêm mới Nhóm người dùng thành công";
                    loadData();
                    reFresh();
                }
                else
                {
                    tb = "Thêm mới Nhóm người dùng thất bại!";
                }
            }
            else
            {
                if (dgvDSNhomNguoiDung.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvDSNhomNguoiDung.SelectedRows[0];

                    int idNND = (int)selectedRow.Cells["userType"].Value;

                    NhomNguoiDungDTO nndDTO = new NhomNguoiDungDTO();
                    nndDTO.userType = idNND;

                    if (string.IsNullOrEmpty(txtTenNhom.Text))
                    {
                        MessageBox.Show("Tên nhóm người dùng không được bỏ trống!");
                        return;

                    }
                    else
                    {
                        nndDTO.name = txtTenNhom.Text;
                    }         

                    bool kq = bll.updateNND(nndDTO);

                    if (kq)
                    {
                        tb = "Bạn đã cập nhật Nhóm người dùng thành công!";
                        loadData();
                        reFresh();
                    }
                    else
                    {
                        tb = "Cập nhật Nhóm người dùng thất bại!";
                        reFresh();
                    }
                }
                else
                {
                    tb = "Vui lòng chọn một Nhóm người dùng bạn muốn chỉnh sửa trong danh sách Nhóm người dùng!";
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

        private void dgvDSNhomNguoiDung_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSNhomNguoiDung.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDSNhomNguoiDung.SelectedRows[0];
                selectedRow.ReadOnly = true;

                txtTenNhom.Text = selectedRow.Cells["name"].Value.ToString();
            }
        }
    }
}
