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
    public partial class Form_Phong : Form
    {
        PhongBLL _phongBLL = new PhongBLL();
        TangBLL _tangBLL = new TangBLL();
        LoaiPhongBLL _loaiPhongBLL = new LoaiPhongBLL();
        Form_Main frm_main;

        bool _btnThem = false;

        public Form_Phong(Form_Main frm)
        {
            InitializeComponent();
            showHideControl(true);
            enableControl(false);
            loadData();
            loadComboTang();
            loadTrangThai();
            loadComboLoaiPhong();
            frm_main = frm;
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
            txtTenPhong.Enabled = t;
            cbTrangThai.Enabled = t;
            cbTang.Enabled = t;
            cbLoaiPhong.Enabled = t;
            ckDisable.Enabled = t;
        }
        private void reFresh()
        {
            txtTenPhong.Text = "";
            cbTrangThai.SelectedIndex = 0;
            cbTang.SelectedIndex = 0;
            cbLoaiPhong.SelectedIndex = 0;
            ckDisable.Checked = false;
        }

        private void loadData()
        {
            List<PhongDTO> list = _phongBLL.getDanhSachPhong();
            dgvDSPhong.DataSource = list;

            dgvDSPhong.Columns[0].HeaderText = "Mã Phòng";
            dgvDSPhong.Columns[1].HeaderText = "Tên Phòng";
            dgvDSPhong.Columns[2].HeaderText = "Trạng Thái";
            dgvDSPhong.Columns[3].HeaderText = "Mã Tầng";
            dgvDSPhong.Columns[4].HeaderText = "Mã Loại Phòng";
            dgvDSPhong.Columns[5].HeaderText = "Disable";

            dgvDSPhong.Columns[0].Visible = false;

            dgvDSPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void loadComboTang()
        {
            List<TangDTO> tangList = _tangBLL.getDanhSachTang();

            cbTang.DisplayMember = "tenTang";
            cbTang.ValueMember = "idTang";

            cbTang.DataSource = tangList;
        }

        private void loadTrangThai()
        {
            var trangThaiList = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string> ( 0,"Còn trống" ),
                new KeyValuePair<int, string> ( 1,"Đã được đặt" )
            };

            cbTrangThai.DisplayMember = "Value";
            cbTrangThai.ValueMember = "Key";

            cbTrangThai.DataSource = trangThaiList;
        }

        private void loadComboLoaiPhong()
        {
            List<LoaiPhongDTO> loaiPhong = _loaiPhongBLL.getDanhSachLoaiPhong();

            cbLoaiPhong.DisplayMember = "tenLoaiPhong";
            cbLoaiPhong.ValueMember = "idLoaiPhong";

            cbLoaiPhong.DataSource = loaiPhong;
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

            if (dgvDSPhong.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDSPhong.SelectedRows[0];

                int idPhong = (int)selectedRow.Cells["idPhong"].Value;
                string tenPhong = selectedRow.Cells["tenPhong"].Value.ToString();

                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool kq = _phongBLL.deletePhong(idPhong);

                    if (kq)
                    {
                        tb = $"Bạn đã xóa Phòng {tenPhong} thành công";
                        loadData();
                        reFresh();
                        frm_main.showRoom();
                    }
                    else
                    {
                        tb = "Xóa Phòng thất bại!";
                        reFresh();
                    }
                }
                else
                {
                    tb = "Hủy xóa Phòng.";
                }
            }
            else
            {
                tb = "Vui lòng chọn một Phòng bạn muốn xóa trong danh sách Phòng!";
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
            if(_btnThem)
            {
                PhongDTO phongDTO = new PhongDTO();
                phongDTO.tenPhong = txtTenPhong.Text;
                
                int selectedTrangThai = (int)cbTrangThai.SelectedIndex;
                phongDTO.trangThai = selectedTrangThai == 1;

                int selectedIDTang = (int)cbTang.SelectedValue;
                phongDTO.idTang = selectedIDTang;

                int selectedIDLoaiPhong = (int)cbLoaiPhong.SelectedValue;
                phongDTO.idLoaiPhong = selectedIDLoaiPhong;

                phongDTO.disable = ckDisable.Checked;

                bool kq = _phongBLL.addPhong(phongDTO);

                if(kq)
                {
                    tb = "Bạn đã thêm mới Phòng thành công";
                    loadData();
                    reFresh();
                    frm_main.showRoom();
                }    
                else
                {
                    tb = "Thêm mới Phòng thất bại!";
                }    
            }    
            else
            {
                if (dgvDSPhong.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvDSPhong.SelectedRows[0];

                    PhongDTO phongDTO = new PhongDTO();
                    phongDTO.idPhong = (int)selectedRow.Cells["idPhong"].Value;

                    phongDTO.tenPhong = txtTenPhong.Text;

                    int selectedTrangThai = (int)cbTrangThai.SelectedIndex;
                    phongDTO.trangThai = selectedTrangThai == 1;

                    int selectedIDTang = (int)cbTang.SelectedIndex;
                    phongDTO.idTang = selectedIDTang + 1;

                    int selectedIDLoaiPhong = (int)cbLoaiPhong.SelectedIndex;
                    phongDTO.idLoaiPhong = selectedIDLoaiPhong + 1;

                    phongDTO.disable = ckDisable.Checked;

                    bool kq = _phongBLL.updatePhong(phongDTO);

                    if (kq)
                    {
                        tb = "Bạn đã cập nhật Phòng thành công!";
                        loadData();
                        reFresh();
                        frm_main.showRoom();
                    }
                    else
                    {
                        tb = "Cập nhật Phòng thất bại!";
                        reFresh();
                    }
                }
                else
                {
                    tb = "Vui lòng chọn một Phòng bạn muốn cập nhật trong danh sách Phòng!";
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

        private void dgvDSPhong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSPhong.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDSPhong.SelectedRows[0];
                selectedRow.ReadOnly = true;

                txtTenPhong.Text = selectedRow.Cells["tenPhong"].Value.ToString();

                bool trangThai = (bool)selectedRow.Cells["trangThai"].Value;
                int trangThaiValue = trangThai ? 1 : 0;
                cbTrangThai.SelectedValue = trangThaiValue;

                int idTang = (int)selectedRow.Cells["idTang"].Value;
                cbTang.SelectedValue = idTang;  

                int idLoaiPhong = (int)selectedRow.Cells["idLoaiPhong"].Value;
                cbLoaiPhong.SelectedValue = idLoaiPhong;  

                ckDisable.Checked = (bool)selectedRow.Cells["disable"].Value;
            }
        }

    }
}
