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
    public partial class Form_LoaiPhong : Form
    {
        LoaiPhongBLL bll = new LoaiPhongBLL();
        bool _btnThem = false;
        public Form_LoaiPhong()
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
            txtTenLoaiPhong.Enabled = t;
            nbrSoNguoi.Enabled = t;
            nbrSoGiuong.Enabled = t;
            nbrDonGia.Enabled = t;
            ckDisable.Enabled = t;
        }
        private void reFresh()
        {
            txtTenLoaiPhong.Text = "";
            nbrDonGia.Value = nbrDonGia.Minimum;
            nbrSoGiuong.Value = nbrSoGiuong.Minimum;
            nbrSoNguoi.Value = nbrSoNguoi.Minimum;
            ckDisable.Checked = false;
        }
        private void loadData()
        {
            List<LoaiPhongDTO> list = bll.getDanhSachLoaiPhong();
            dgvDSLoaiPhong.DataSource = list;

            dgvDSLoaiPhong.Columns[0].HeaderText = "Mã Phòng";
            dgvDSLoaiPhong.Columns[1].HeaderText = "Tên Loại Phòng";
            dgvDSLoaiPhong.Columns[2].HeaderText = "Đơn Giá";
            dgvDSLoaiPhong.Columns[3].HeaderText = "Số Người";
            dgvDSLoaiPhong.Columns[4].HeaderText = "Số Giường";
            dgvDSLoaiPhong.Columns[5].HeaderText = "Disable";

            dgvDSLoaiPhong.Columns[0].Visible = false;

            dgvDSLoaiPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvDSLoaiPhong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSLoaiPhong.SelectedRows.Count > 0)
            { 
                var selectedRow = dgvDSLoaiPhong.SelectedRows[0];
                selectedRow.ReadOnly = true;

                txtTenLoaiPhong.Text = selectedRow.Cells["tenLoaiPhong"].Value.ToString();
                nbrSoNguoi.Value = (int)selectedRow.Cells["soNguoi"].Value;
                nbrDonGia.Value = (decimal)selectedRow.Cells["donGia"].Value;
                nbrSoGiuong.Value = (int)selectedRow.Cells["soGiuong"].Value;
                ckDisable.Checked = (bool)selectedRow.Cells["disable"].Value;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _btnThem = true;
            enableControl(true);
            showHideControl(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _btnThem = false;
            enableControl(true);
            showHideControl(false);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            enableControl(false);

            string tb = "";

            if (dgvDSLoaiPhong.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDSLoaiPhong.SelectedRows[0];

                int idLoaiPhong = (int)selectedRow.Cells["idLoaiPhong"].Value;
                string tenPhong = selectedRow.Cells["tenLoaiPhong"].Value.ToString();

                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa loại phòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool kq = bll.deleteLoaiPhong(idLoaiPhong);

                    if (kq)
                    {
                        tb = $"Bạn đã xóa Loại phòng {tenPhong} thành công";
                        loadData();
                        reFresh();
                    }
                    else
                    {
                        tb = "Xóa Loại phòng thất bại!";
                        reFresh();
                    }
                }
                else
                {
                    tb = "Hủy xóa loại phòng.";
                }    
            }
            else
            {
                tb = "Vui lòng chọn một Loại phòng bạn muốn xóa trong danh sách Loại phòng!";
            }

            MessageBox.Show(tb);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tb = "";

            if (_btnThem)
            {
                LoaiPhongDTO loaiPhongDTO = new LoaiPhongDTO();
                loaiPhongDTO.tenLoaiPhong = txtTenLoaiPhong.Text;
                loaiPhongDTO.soNguoi = (int)nbrSoNguoi.Value;
                loaiPhongDTO.donGia = (decimal)nbrDonGia.Value;
                loaiPhongDTO.soGiuong = (int)nbrSoGiuong.Value;
                loaiPhongDTO.disable = (bool)ckDisable.Checked;

                bool kq = bll.addLoaiPhong(loaiPhongDTO);

                if(kq)
                {
                    tb = "Bạn đã thêm mới Loại phòng thành công";
                    loadData();
                    reFresh();
                }
                else
                {
                    tb = "Thêm mới Loại phòng thất bại!";
                    reFresh();
                }

            }
            else
            {
                if (dgvDSLoaiPhong.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvDSLoaiPhong.SelectedRows[0];

                    LoaiPhongDTO loaiPhongDTO = new LoaiPhongDTO();
                    loaiPhongDTO.idLoaiPhong = (int)selectedRow.Cells["idLoaiPhong"].Value;
                    loaiPhongDTO.tenLoaiPhong = txtTenLoaiPhong.Text;
                    loaiPhongDTO.soNguoi = (int)nbrSoNguoi.Value;
                    loaiPhongDTO.donGia = (decimal)nbrDonGia.Value;
                    loaiPhongDTO.soGiuong = (int)nbrSoGiuong.Value;
                    loaiPhongDTO.disable = (bool)ckDisable.Checked;

                    bool kq = bll.updateLoaiPhong(loaiPhongDTO);

                    if(kq)
                    {
                        tb = "Bạn đã cập nhật Loại phòng thành công!";
                        loadData();
                        reFresh();
                    }    
                    else
                    {
                        tb = "Cập nhật Loại phòng thất bại!";
                        reFresh();
                    }
                }
                else
                {
                    tb = "Vui lòng chọn một Loại phòng bạn muốn cập nhật trong danh sách Loại phòng!";
                }
            }

            MessageBox.Show(tb);
            _btnThem = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            enableControl(false);
            showHideControl(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
