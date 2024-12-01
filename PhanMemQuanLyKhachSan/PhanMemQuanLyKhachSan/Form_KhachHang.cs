using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyKhachSan
{
    public partial class Form_KhachHang : Form
    {
        KhachHangBLL bll = new KhachHangBLL();

        private bool _btnThem = false;

        Form_DatPhongtheoDoan form;

        Form_DatPhongtheoDoan objDatPhong = (Form_DatPhongtheoDoan)Application.OpenForms["Form_DatPhongtheoDoan"];

        public Form_KhachHang(Form_DatPhongtheoDoan form)
        {
            InitializeComponent();
            loadData();
            showHideControl(true);
            enableControl(false);
            this.form = form;
        }
        public Form_KhachHang()
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
            txtTenKhachHang.Enabled = t;
            txtCCCD.Enabled = t;
            txtDiaChi.Enabled = t;
            txtEmail.Enabled = t;
            txtDienThoai.Enabled = t;
            ckDisable.Enabled = t;
            ckGioiTinh.Enabled = t;
        }
        private void reFresh()
        {
            txtDiaChi.Text = "";
            txtCCCD.Text = "";
            txtEmail.Text = "";
            txtTenKhachHang.Text = "";
            txtDienThoai.Text = "";
            ckDisable.Checked = false;
            ckGioiTinh.Checked = false;
        }
        private void loadData()
        {
            List<KhachHangDTO> list = bll.getDanhSachKhachHang();
            dgvDSKhachHang.DataSource = list;

            dgvDSKhachHang.Columns[0].HeaderText = "ID Khách hàng";
            dgvDSKhachHang.Columns[1].HeaderText = "Họ tên";
            dgvDSKhachHang.Columns[2].HeaderText = "Giới tính";
            dgvDSKhachHang.Columns[3].HeaderText = "CCCD";
            dgvDSKhachHang.Columns[4].HeaderText = "Điện thoại";
            dgvDSKhachHang.Columns[5].HeaderText = "Email";
            dgvDSKhachHang.Columns[6].HeaderText = "Địa chỉ";

            dgvDSKhachHang.Columns[0].Visible = false;

            dgvDSKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

            if(dgvDSKhachHang.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDSKhachHang.SelectedRows[0];

                int idKH = (int)selectedRow.Cells["idKH"].Value;
                string tenKH = selectedRow.Cells["hoTen"].Value.ToString();

                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(result == DialogResult.Yes)
                {
                    bool kq = bll.deleteKhachHang(idKH);

                    if (kq)
                    {
                        tb = $"Bạn đã xóa Khách hàng {tenKH} thành công";
                        loadData();
                        reFresh();
                    }
                    else
                    {
                        tb = $"Xóa Khách hàng {tenKH} thất bại!";
                    }
                }    
                else
                {
                    tb = "Hủy xóa Khách hàng.";
                }    

            }   
            else
            {
                tb = "Vui lòng chọn một Khách hàng bạn muốn cập nhật trong danh sách Khách hàng!";
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
                KhachHangDTO khachHangDTO = new KhachHangDTO();
                khachHangDTO.hoTen = txtTenKhachHang.Text;
                khachHangDTO.cccd = txtCCCD.Text;
                khachHangDTO.email = txtEmail.Text;
                khachHangDTO.diaChi = txtDiaChi.Text;
                khachHangDTO.dienThoai = txtDienThoai.Text;
                khachHangDTO.disable = (bool)ckDisable.Checked;
                khachHangDTO.gioiTinh = (bool)ckGioiTinh.Checked;

                bool kq = bll.addKhachHang(khachHangDTO);

                if(kq)
                {
                    tb = "Bạn đã thêm mới Khách hàng thành công";
                    loadData();
                    reFresh();
                    if (form != null)
                    {
                        form.loadComboboxKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Form hoặc btnThem chưa được khởi tạo.");
                    }
                }    
                else
                {
                    tb = "Thêm mới Khách hàng thất bại!";
                }    
            }   
            else
            {
                if(dgvDSKhachHang.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvDSKhachHang.SelectedRows[0];

                    int idKhachHang = (int)selectedRow.Cells["idKH"].Value;

                    KhachHangDTO khachHangDTO = new KhachHangDTO();
                    khachHangDTO.idKH = idKhachHang;    
                    khachHangDTO.hoTen = txtTenKhachHang.Text;
                    khachHangDTO.cccd = txtCCCD.Text;
                    khachHangDTO.email = txtEmail.Text;
                    khachHangDTO.diaChi = txtDiaChi.Text;
                    khachHangDTO.dienThoai = txtDienThoai.Text;
                    khachHangDTO.disable = (bool)ckDisable.Checked;
                    khachHangDTO.gioiTinh = (bool)ckGioiTinh.Checked;

                    bool kq = bll.updateKhachHang(khachHangDTO);

                    if(kq)
                    {
                        tb = "Bạn đã cập nhật Khách hàng thành công";
                        loadData();
                        reFresh();
                    }   
                    else
                    {
                        tb = "Cập nhật Khách hàng thất bại!";
                    }    
                }  
                else
                {
                    tb = "Vui lòng chọn một Khách hàng bạn muốn cập nhật trong danh sách Khách hàng!";
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

        private void dgvDSKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSKhachHang.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDSKhachHang.SelectedRows[0];
                selectedRow.ReadOnly = true;

                txtTenKhachHang.Text = selectedRow.Cells["hoTen"].Value.ToString();
                txtCCCD.Text = selectedRow.Cells["cccd"].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells["diaChi"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["email"].Value.ToString();
                txtDienThoai.Text = selectedRow.Cells["dienThoai"].Value.ToString();
                ckDisable.Checked = (bool)selectedRow.Cells["disable"].Value;
                ckGioiTinh.Checked = (bool)selectedRow.Cells["gioiTinh"].Value;
            }
        }

        private void dgvDSKhachHang_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDSKhachHang.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDSKhachHang.SelectedRows[0];


                var idKHValue = selectedRow.Cells["idKH"].Value;


                if (idKHValue != null)
                {

                    int idKH;
                    if (int.TryParse(idKHValue.ToString(), out idKH))
                    {
                        objDatPhong.setKhachHang(idKH);
 
                        MessageBox.Show("Khách hàng đã được chọn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Giá trị ID khách hàng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            List<KhachHangExcel> kh = bll.getDanhSachKhachHangExcel();

            DataTable table = ConvertUltil.ConvertListToDataTable(kh.ToList());

            table.PrimaryKey = null;

            DataColumn col = new DataColumn("STT", typeof(int));
            table.Columns.Add(col);
            col.SetOrdinal(0);

            int len = table.Rows.Count;
            for (int i = 0; i < len; i++)
            {
                table.Rows[i]["STT"] = i + 1;
            }

            Dictionary<string, string> dic = new Dictionary<string, string>();
            int soluong = table.Rows.Count;
            dic.Add("soluongkhachhang", soluong.ToString());

            WordExport wd = new WordExport();
            wd.WordUltil(Application.StartupPath + "/Template.dotx", true);

            wd.WriteFields(dic);

            wd.WriteTable(table, 1);

            // Thông báo hoàn thành
            MessageBox.Show("Xuất xong!");
        }
    }
}
