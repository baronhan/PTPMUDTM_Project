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
    public partial class Form_SanPham : Form
    {
        SanPhamBLL bll = new SanPhamBLL();

        private bool _btnThem = false; 
        public Form_SanPham()
        {
            InitializeComponent();
            showHideControl(true);
            enableControl(false);
            loadData();
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
            txtTenSanPham.Enabled = t;
            nbrDonGia.Enabled = t;
            ckDisable.Enabled = t;
        }
        private void reFresh()
        {
            txtTenSanPham.Text = "";
            nbrDonGia.Value = nbrDonGia.Minimum;
            ckDisable.Checked = false;
        }

        private void loadData()
        {
            List<SanPhamDTO> list = bll.getDanhSachSanPham();
            dgvDSSanPham.DataSource = list;

            dgvDSSanPham.Columns[0].HeaderText = "ID Sản phẩm";
            dgvDSSanPham.Columns[1].HeaderText = "Tên sản phẩm";
            dgvDSSanPham.Columns[2].HeaderText = "Đơn giá";
            dgvDSSanPham.Columns[3].HeaderText = "Disable";

            dgvDSSanPham.Columns[0].Visible = false;

            dgvDSSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            showHideControl(false);
            enableControl(true);

            _btnThem = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            enableControl(false);

            string tb = "";

            if (dgvDSSanPham.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDSSanPham.SelectedRows[0];

                int idSP = (int)selectedRow.Cells["idSP"].Value;
                string tenSanPham = selectedRow.Cells["tenSP"].Value.ToString();

                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa loại phòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool kq = bll.deleteSanPham(idSP);

                    if (kq)
                    {
                        tb = $"Bạn đã xóa Sản phẩm {tenSanPham} thành công";
                        loadData();
                        reFresh();
                    }
                    else
                    {
                        tb = "Xóa Sản phẩm thất bại!";
                        reFresh();
                    }
                }
                else
                {
                    tb = "Hủy xóa Sản phẩm.";
                }
            }
            else
            {
                tb = "Vui lòng chọn một Sản phẩm bạn muốn xóa trong danh sách Sản phẩm!";
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
                SanPhamDTO sanPhamDTO = new SanPhamDTO();
                sanPhamDTO.tenSP = txtTenSanPham.Text;
                sanPhamDTO.donGia = (decimal)nbrDonGia.Value;
                sanPhamDTO.disable = (bool)ckDisable.Checked;

                bool kq = bll.addSanPham(sanPhamDTO);

                if(kq)
                {
                    tb = "Bạn đã thêm mới Sản phẩm thành công";
                    loadData();
                    reFresh();
                }   
                else
                {
                    tb = "Thêm mới Sản phẩm thất bại!";
                }    
            }
            else
            {
                if(dgvDSSanPham.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvDSSanPham.SelectedRows[0];

                    int idSanPham = (int)selectedRow.Cells["idSP"].Value;

                    SanPhamDTO sanPhamDTO = new SanPhamDTO();
                    sanPhamDTO.idSP = idSanPham;
                    sanPhamDTO.tenSP = txtTenSanPham.Text;
                    sanPhamDTO.donGia = (decimal)nbrDonGia.Value;
                    sanPhamDTO.disable = (bool)ckDisable.Checked;

                    bool kq = bll.updateSanPham(sanPhamDTO);

                    if(kq)
                    {
                        tb = "Bạn đã cập nhật Sản phẩm thành công";
                        loadData();
                        reFresh();
                    }   
                    else
                    {
                        tb = "Cập nhật Sản phẩm thất bại!";
                    }    
                }   
                else
                {
                    tb = "Vui lòng chọn một Sản phẩm bạn muốn cập nhật trong danh sách Sản phẩm!";
                }    
            }

            MessageBox.Show(tb);
            _btnThem = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            showHideControl(true);
            enableControl(false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDSSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvDSSanPham.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDSSanPham.SelectedRows[0];
                selectedRow.ReadOnly = true;

                txtTenSanPham.Text = selectedRow.Cells["tenSP"].Value.ToString();
                nbrDonGia.Value = (decimal)selectedRow.Cells["donGia"].Value;
                ckDisable.Checked = (bool)selectedRow.Cells["disable"].Value;
            }    
        }
    }
}
