using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyKhachSan
{
    public partial class Form_Tang : Form
    {
        TangBLL bll = new TangBLL();
        Form_Main form_Main;

        private bool _btnThem = false;

        public Form_Tang(Form_Main form_Main)
        {
            InitializeComponent();
            loadData();
            showHideControl(true);
            enableControl(false);
            this.form_Main = form_Main;
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
            txtTenTang.Enabled = t;
            ckDisable.Enabled = t;
        }
        private void reFresh()
        {
            txtTenTang.Text = "";
            ckDisable.Checked = false;
        }

        private void loadData()
        {
            List<TangDTO> list = bll.getDanhSachTang();
            dgvDSTang.DataSource = list;

            dgvDSTang.Columns[0].HeaderText = "ID Tầng";
            dgvDSTang.Columns[1].HeaderText = "Tên Tầng";
            dgvDSTang.Columns[2].HeaderText = "Disable";

            dgvDSTang.Columns[0].Visible = false;

            dgvDSTang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

            if(dgvDSTang.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDSTang.SelectedRows[0];

                int idTang = (int)selectedRow.Cells["idTang"].Value;
                string tenTang = selectedRow.Cells["tenTang"].Value.ToString();

                bool hasRooms = bll.HasRoomsInTang(idTang);

                if (hasRooms)
                {
                    tb = $"Không thể xóa {tenTang} vì có phòng đang nằm trong tầng này.";
                    MessageBox.Show(tb);
                    return; 
                }

                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(result == DialogResult.Yes)
                {
                    bool kq = bll.deleteTang(idTang);

                    if (kq)
                    {
                        tb = $"Bạn đã xóa {tenTang} thành công";
                        loadData();
                        reFresh();
                        form_Main.showRoom();
                    }
                    else
                    {
                        tb = "Xóa Tầng thất bại!";
                        reFresh();
                    }
                }    
                else
                {
                    tb = "Hủy xóa Tầng.";
                }    
            }   
            else
            {
                tb = "Vui lòng chọn một Tầng bạn muốn xóa trong danh sách Tầng!";
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
                TangDTO tangDTO = new TangDTO();
                tangDTO.tenTang = txtTenTang.Text;
                tangDTO.disable = (bool)ckDisable.Checked;

                bool kq = bll.addTang(tangDTO);

                if(kq)
                {
                    tb = "Bạn đã thêm mới Tầng thành công";
                    loadData();
                    reFresh();
                    form_Main.showRoom();
                }   
                else
                {
                    tb = "Thêm mới Tầng thất bại!";
                }    
            }   
            else
            {
                if(dgvDSTang.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvDSTang.SelectedRows[0];

                    int idTang = (int)selectedRow.Cells["idTang"].Value;

                    TangDTO tangDTO = new TangDTO();
                    tangDTO.idTang = idTang;
                    tangDTO.tenTang = txtTenTang.Text;
                    tangDTO.disable = (bool)ckDisable.Checked;

                    bool kq = bll.updateTang(tangDTO);

                    if(kq)
                    {
                        tb = "Bạn đã cập nhật Tầng thành công!";
                        loadData();
                        reFresh();
                        form_Main.showRoom();
                    }   
                    else
                    {
                        tb = "Cập nhật Tầng thất bại!";
                        reFresh();
                    }    
                }   
                else
                {
                    tb = "Vui lòng chọn một Tầng bạn muốn xóa trong danh sách Tầng!";
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

        private void dgvDSTang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSTang.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDSTang.SelectedRows[0];
                selectedRow.ReadOnly = true;

                txtTenTang.Text = selectedRow.Cells["tenTang"].Value.ToString();
                ckDisable.Checked = (bool)selectedRow.Cells["disable"].Value;
            }
        }
    }
}
