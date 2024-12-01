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
    public partial class Form_ChiTietQuyen : Form
    {
        PhanQuyenBLL bll = new PhanQuyenBLL();
        private int idNND {  get; set; }

        public Form_ChiTietQuyen(int idNND)
        {
            InitializeComponent();
            this.idNND = idNND;
            txtName.Text = bll.GetTenNhomNguoiDung(idNND);
            loadData();
        }

        private void loadData()
        {
            List<PhanQuyenDTO> list = bll.getDanhSachPhanQuyen(idNND);
            dgvPhanQuyen.DataSource = list;

            dgvPhanQuyen.Columns[0].HeaderText = "ID Trang";
            dgvPhanQuyen.Columns[1].HeaderText = "Tên Form";
            dgvPhanQuyen.Columns[2].HeaderText = "Có Quyền";

            dgvPhanQuyen.Columns[0].Visible = false;
            dgvPhanQuyen.Columns[1].ReadOnly = true;
            dgvPhanQuyen.Columns[2].ReadOnly = true;

            dgvPhanQuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnCapQuyen_Click(object sender, EventArgs e)
        {
            if (dgvPhanQuyen.SelectedRows.Count > 0)
            {
                var selectedRow = dgvPhanQuyen.SelectedRows[0];
                selectedRow.ReadOnly = true;

                int formId = int.Parse(selectedRow.Cells["formId"].Value.ToString());

                if (bll.KiemTraCoQuyenChua(idNND, formId))
                {
                    MessageBox.Show($"{txtName.Text} đã có quyền truy cập vào trang này!");
                }
                else
                {
                    if (bll.ThemMoiQuyen(idNND, formId))
                    {
                        MessageBox.Show("Bạn đã gán quyền thành công!");
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới quyền thất bại!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để gán quyền!");
            }
        }


        private void btnThuHoi_Click(object sender, EventArgs e)
        {
            if (dgvPhanQuyen.SelectedRows.Count > 0)
            {
                var selectedRow = dgvPhanQuyen.SelectedRows[0];
                selectedRow.ReadOnly = true;

                int formId = int.Parse(selectedRow.Cells["formId"].Value.ToString());

                if (bll.KiemTraCoQuyenChua(idNND, formId))
                {
                    if (bll.ThuHoiQuyen(idNND, formId))
                    {
                        MessageBox.Show("Thu hồi quyền thành công!");
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("Thu hồi quyền thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show($"{txtName.Text} không có quyền truy cập vào trang này để thu hồi!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trong danh sách để thu hồi quyền.");
            }
        }
    }
}
