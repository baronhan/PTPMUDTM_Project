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
    public partial class Form_PhanQuyen : Form
    {
        NhomNguoiDungBLL bll = new NhomNguoiDungBLL();
        public Form_PhanQuyen()
        {
            InitializeComponent();
            loadData();
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

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvDSNhomNguoiDung.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDSNhomNguoiDung.SelectedRows[0];
                selectedRow.ReadOnly = true;

                int idNND = int.Parse(selectedRow.Cells["userType"].Value.ToString());

                Form_ChiTietQuyen form = new Form_ChiTietQuyen(idNND);
                form.Show();
                this.Hide();    
            }
        }
    }
}
