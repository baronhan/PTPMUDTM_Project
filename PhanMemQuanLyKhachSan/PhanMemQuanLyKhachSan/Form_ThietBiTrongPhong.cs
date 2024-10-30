using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyKhachSan
{
    public partial class Form_ThietBiTrongPhong : Form
    {
        ThietBiTrongPhongBLL _ptbBLL = new ThietBiTrongPhongBLL();
        PhongBLL _phongBLL = new PhongBLL();
        ThietBiBLL _thietBiBLL = new ThietBiBLL();  

        private bool _btnThem = false;

        public Form_ThietBiTrongPhong()
        {
            InitializeComponent();
            showHideControl(true);
            enableControl(false);
            loadData();
            loadComboPhong();
            loadComboThietBi();
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
            cbTenThietBi.Enabled = t;
            cbTenPhong.Enabled = t;
            nbrSoLuong.Enabled = t;
        }
        private void reFresh()
        {
            cbTenThietBi.SelectedIndex = 0;
            cbTenPhong.SelectedIndex = 0;
            nbrSoLuong.Value = nbrSoLuong.Minimum;
        }

        private void loadData()
        {
            List<ThietBiTrongPhongDTO> thietBiTrongPhongs = _ptbBLL.getDanhSachThietBiPhong();

            dgvDSThietBiTrongPhong.DataSource = thietBiTrongPhongs;

            dgvDSThietBiTrongPhong.Columns[0].HeaderText = "Tên phòng";
            dgvDSThietBiTrongPhong.Columns[1].HeaderText = "Tên thiết bị";
            dgvDSThietBiTrongPhong.Columns[2].HeaderText = "Số lượng";
            dgvDSThietBiTrongPhong.Columns[3].HeaderText = "Mã thiết bị";
            dgvDSThietBiTrongPhong.Columns[4].HeaderText = "Mã phòng";

            dgvDSThietBiTrongPhong.Columns[3].Visible = false;
            dgvDSThietBiTrongPhong.Columns[4].Visible = false;

            dgvDSThietBiTrongPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void loadComboPhong()
        {
            List<PhongDTO> phong = _phongBLL.getDanhSachPhong();

            cbTenPhong.DisplayMember = "tenPhong";
            cbTenPhong.ValueMember = "idPhong";

            cbTenPhong.DataSource = phong;
        }

        private void loadComboThietBi()
        {
            List<ThietBiDTO> thietbi = _thietBiBLL.getDanhSachThietBi();

            cbTenThietBi.DisplayMember = "tenTB";
            cbTenThietBi.ValueMember = "idTB";

            cbTenThietBi.DataSource = thietbi;
        }


        private void dgvDSThietBiTrongPhong_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvDSThietBiTrongPhong.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDSThietBiTrongPhong.SelectedRows[0];
                selectedRow.ReadOnly = true;

                int idPhong = (int)selectedRow.Cells["idPhong"].Value;
                cbTenPhong.SelectedValue = idPhong;

                int idThietBi = (int)selectedRow.Cells["idTB"].Value;
                cbTenThietBi.SelectedValue = idThietBi;

                int soLuong = (int)selectedRow.Cells["soLuong"].Value;
                nbrSoLuong.Value = soLuong;
            }
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

            if (dgvDSThietBiTrongPhong.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDSThietBiTrongPhong.SelectedRows[0];

                ThietBiTrongPhongDTO ptb = new ThietBiTrongPhongDTO();

                ptb.idPhong = (int)selectedRow.Cells["idPhong"].Value;
                ptb.idTB = (int)selectedRow.Cells["idTB"].Value;
                ptb.tenPhong = selectedRow.Cells["tenPhong"].Value.ToString();
                ptb.tenTB = selectedRow.Cells["tenTB"].Value.ToString();
                ptb.soLuong = (int)selectedRow.Cells["soLuong"].Value;


                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool kq = _ptbBLL.deleteThietBiPhong(ptb);

                    if (kq)
                    {
                        tb = $"Bạn đã xóa Thiết bị {ptb.tenTB} ở phòng {ptb.tenPhong} thành công";
                        loadData();
                        reFresh();
                    }
                    else
                    {
                        tb = $"Xóa Thiết bị {ptb.tenTB} ở phòng {ptb.tenPhong} thất bại!";
                        reFresh();
                    }
                }
                else
                {
                    tb = "Hủy xóa Thiết bị trong phòng.";
                }
            }
            else
            {
                tb = "Vui lòng chọn một Thiết bị trong phòng bạn muốn cập nhật trong danh sách Thiết bị trong phòng!";
            }

            MessageBox.Show(tb);

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            showHideControl(false);
            enableControl(true);
            cbTenPhong.Enabled = false;
            cbTenThietBi.Enabled = false;
            _btnThem = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tb = "";

            if(_btnThem)
            {
                ThietBiTrongPhongDTO ptb = new ThietBiTrongPhongDTO();

                string tenPhong = ((PhongDTO)cbTenPhong.SelectedItem).tenPhong;
                ptb.tenPhong = tenPhong;

                int selectedIDPhong = (int)((PhongDTO)cbTenPhong.SelectedItem).idPhong;
                ptb.idPhong = selectedIDPhong;

                string tenTB = ((ThietBiDTO)cbTenThietBi.SelectedItem).tenTB;
                ptb.tenTB = tenTB;

                int selectedIDThietBi = (int)((ThietBiDTO)cbTenThietBi.SelectedItem).idTB;
                ptb.idTB = selectedIDThietBi;

                ptb.soLuong = (int)nbrSoLuong.Value;

                bool kq = _ptbBLL.addThietBiPhong(ptb);

                if(kq)
                {
                    tb = "Bạn đã thêm mới Thiết bị vào phòng thành công";
                    loadData();
                    reFresh();
                }   
                else
                {
                    tb = "Thêm Thiết bị vào phòng thất bại!";
                    return;
                }    
            }   
            else
            {
                if(dgvDSThietBiTrongPhong.SelectedRows.Count > 0)
                { 
                    var selectedRow = dgvDSThietBiTrongPhong.SelectedRows[0];

                    ThietBiTrongPhongDTO ptb = new ThietBiTrongPhongDTO();

                    string tenPhong = ((PhongDTO)cbTenPhong.SelectedItem).tenPhong;
                    ptb.tenPhong = tenPhong;

                    int selectedIDPhong = (int)((PhongDTO)cbTenPhong.SelectedItem).idPhong;
                    ptb.idPhong = selectedIDPhong;

                    string tenTB = ((ThietBiDTO)cbTenThietBi.SelectedItem).tenTB;
                    ptb.tenTB = tenTB;

                    int selectedIDThietBi = (int)((ThietBiDTO)cbTenThietBi.SelectedItem).idTB;
                    ptb.idTB = selectedIDThietBi;

                    ptb.soLuong = (int)nbrSoLuong.Value;

                    bool kq = _ptbBLL.updateThietBiPhong(ptb);

                    if(kq)
                    {
                        tb = "Bạn đã cập nhật Thiết bị trong phòng thành công";
                        loadData();
                        reFresh();
                    }   
                    else
                    {
                        tb = "Cập nhật Thiết bị trong phòng thất bại!";
                    }    
                }   
                else
                {
                    tb = "Vui lòng chọn một Thiết bị trong phòng bạn muốn cập nhật trong danh sách Thiết bị trong phòng!";
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
    }
}
