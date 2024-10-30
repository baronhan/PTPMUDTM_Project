using BLL;
using BunifuAnimatorNS;
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
    public partial class Form_ThietBi : Form
    {
        ThietBiBLL bll = new ThietBiBLL();

        private bool _btnThem = false;

        public Form_ThietBi()
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
            txtTenThietBi.Enabled = t;
            nbrDonGia.Enabled = t;
            ckDisable.Enabled = t;
        }
        private void reFresh()
        {
            txtTenThietBi.Text = "";
            nbrDonGia.Value = nbrDonGia.Minimum;
            ckDisable.Checked = false;
        }
        private void loadData()
        {
            List<ThietBiDTO> list = bll.getDanhSachThietBi();
            dgvDSThietBi.DataSource = list;

            dgvDSThietBi.Columns[0].HeaderText = "Mã thiết bị";
            dgvDSThietBi.Columns[1].HeaderText = "Tên thiết bị";
            dgvDSThietBi.Columns[2].HeaderText = "Đơn giá";
            dgvDSThietBi.Columns[3].HeaderText = "Disable";

            dgvDSThietBi.Columns[0].Visible = false;

            dgvDSThietBi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

            if(dgvDSThietBi.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDSThietBi.SelectedRows[0];

                int idThietBi = (int)selectedRow.Cells["idTB"].Value;
                string tenThietBi = selectedRow.Cells["tenTB"].Value.ToString();

                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa loại phòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(result == DialogResult.Yes)
                {
                    bool kq = bll.deleteThietBi(idThietBi);

                    if (kq)
                    {
                        tb = $"Bạn đã xóa Thiết bị {tenThietBi} thành công";
                        loadData();
                        reFresh();
                    }
                    else
                    {
                        tb = "Xóa Thiết bị thất bại!";
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
                tb = "Vui lòng chọn một Thiết bị bạn muốn cập nhật trong danh sách Thiết bị!";
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
                ThietBiDTO thietBiDTO = new ThietBiDTO();
                thietBiDTO.tenTB = txtTenThietBi.Text;
                thietBiDTO.donGia = (decimal)nbrDonGia.Value;
                thietBiDTO.disable = (bool)ckDisable.Checked;

                bool kq = bll.addThietBi(thietBiDTO);

                if(kq)
                {
                    tb = "Bạn đã thêm mới Thiết bị thành công";
                    loadData();
                    reFresh();
                }   
                else
                {
                    tb = "Thêm mới Thiết bị thất bại!";
                }    
            }   
            else
            {
                if(dgvDSThietBi.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvDSThietBi.SelectedRows[0];

                    int idThietBi = (int)selectedRow.Cells["idTB"].Value;

                    ThietBiDTO thietBiDTO = new ThietBiDTO();
                    thietBiDTO.idTB = idThietBi;
                    thietBiDTO.tenTB = txtTenThietBi.Text;
                    thietBiDTO.donGia = (decimal)(nbrDonGia.Value);
                    thietBiDTO.disable = (bool)ckDisable.Checked;

                    bool kq = bll.updateThietBi(thietBiDTO);

                    if(kq)
                    {
                        tb = "Bạn đã cập nhật Thiết bị thành công";
                        loadData();
                        reFresh();
                    }   
                    else
                    {
                        tb = "Cập nhật Thiết bị thất bại!";
                    }    
                }   
                else
                {
                    tb = "Vui lòng chọn một Thiết bị bạn muốn cập nhật trong danh sách Thiết bị!";
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

        private void dgvDSThietBi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSThietBi.SelectedRows.Count > 0)
            {
                var seletedRow = dgvDSThietBi.SelectedRows[0];
                seletedRow.ReadOnly = true;

                txtTenThietBi.Text = seletedRow.Cells["tenTB"].Value.ToString();
                nbrDonGia.Value = (decimal)seletedRow.Cells["donGia"].Value;
                ckDisable.Checked = (bool)seletedRow.Cells["disable"].Value;
            }

        }
    }
}
