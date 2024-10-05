using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUL;
using DTO;

namespace HotelBooking
{
    public partial class Form_UserList : Form
    {
        KhachHangBUL bul = new KhachHangBUL();
        NhomNguoiDungBUL nhombul=new NhomNguoiDungBUL();
        //UserButtonControl buttonControl;
        string _username = Form_Login._username;
        KhachHangDTO kh;
        public Form_UserList()
        {
            InitializeComponent();
            LoadUserList();
            LoadNhomNguoiDung();

            //buttonControl = new UserButtonControl();
            //buttonControl.Location = new Point(10, 10);
            //this.Controls.Add(buttonControl);

            //buttonControl.BtnAdd_Click += btnAdd_Click;
            //buttonControl.BtnUpdate_Click += btnUpdate_Click;
            //buttonControl.BtnDelete_Click += btnDelete_Click;
            //buttonControl.BtnCancel_CLick += btnCancel_Click;
        }
    
        
        //private void btnDeleteImage_Click(object sender, EventArgs e)
        //{
        //    if (pictureBoxUser.Image != null)
        //    {
        //        pictureBoxUser.Image = Properties.Resources.defaultAvatar;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Không có ảnh để xóa!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        private void LoadUserList()
        {
            try
            {
                DataTable userList = bul.GetKhachHangDataTable();
                dgvUserList.DataSource = userList;
                dgvUserList.ClearSelection();
                dgvUserList.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }
        private void LoadUserList(int? userGroupId = null)
        {
            try
            {
                DataTable userList = bul.GetKhachHangDataTable(userGroupId);
                dgvUserList.DataSource = userList;
                dgvUserList.ClearSelection();
                dgvUserList.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void LoadNhomNguoiDung()
        {
            try
            {
                List<NhomNguoiDungDTO> nhomNguoiDungList = nhombul.GetAllNhomNguoiDung();
                cmbUserGroup.DataSource = nhomNguoiDungList;
                cmbUserGroup.DisplayMember = "tenNhomNguoiDung";
                cmbUserGroup.ValueMember = "maNhomNguoiDung";
                cmbUserGroup.SelectedIndexChanged += cmbUserGroup_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        //private void cmbUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbUserGroup.SelectedValue != null)
        //    {
        //        if (int.TryParse(cmbUserGroup.SelectedValue.ToString(), out int selectedGroupId))
        //        {
        //            LoadUserList(selectedGroupId);
        //        }
        //        else
        //        {
        //            LoadUserList();
        //        }
        //    }
        //}
        private void cmbUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUserGroup.SelectedValue != null)
            {
                if (int.TryParse(cmbUserGroup.SelectedValue.ToString(), out int selectedGroupId))
                {
                    LoadUserList(selectedGroupId);
                }
                else
                {
                    LoadUserList();
                }
            }
        }

        private void dgvUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selected = dgvUserList.Rows[e.RowIndex];
                

                if (selected != null)
                {
                    int maKH = (int)selected.Cells["ID"].Value;
                    string userName = selected.Cells["UserName"].Value.ToString();
                    string hoTen = selected.Cells["FullName"].Value.ToString();
                    string email = selected.Cells["Email"].Value.ToString();
                    string diaChi = selected.Cells["Address"].Value.ToString();
                    string soDienThoai = selected.Cells["Phone"].Value.ToString();

                    txtUserName.Text = userName;
                    txtFullname.Text = hoTen;
                    txtEmail.Text = email;
                    txtAddress.Text = diaChi;
                    txtPhone.Text = soDienThoai;

                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn cần nhập vào username!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserName.Focus();
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtUserName.Text.Trim(), @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Username không được chứa ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserName.Focus();
                    return;
                }

                if (txtEmail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn cần nhập vào email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (txtFullname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn cần nhập vào fullname!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFullname.Focus();
                    return;
                }

                if (txtAddress.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn cần nhập vào address!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAddress.Focus();
                    return;
                }

                if (txtPhone.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn cần nhập vào phone!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text.Trim(), @"^\d+$") || txtPhone.Text.Trim().Length != 10 || !txtPhone.Text.Trim().StartsWith("0"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }

                string username = txtUserName.Text.Trim();
                string password = "12345678";
                string hoten = txtFullname.Text.Trim();
                string diachi = txtAddress.Text.Trim();
                string email = txtEmail.Text.Trim();
                string sdt = txtPhone.Text.Trim();

                int maNhomNguoiDung = (int)cmbUserGroup.SelectedValue;
                bool _isSuccess = bul.RegisterNewUser(username, password, hoten, email, diachi, sdt);

                if (_isSuccess)
                {
                    KhachHangDTO newUser = new KhachHangDTO
                    {
                        username = username,
                        hoTen = hoten,
                        password = password,
                        email = email,
                        diaChi = diachi,
                        soDienThoai = sdt,
                        maNhomNguoiDung = maNhomNguoiDung
                    };

                    bool isSuccess = bul.AddKhachHang(newUser);
                    if (isSuccess)
                    {
                        LoadUserList(maNhomNguoiDung);
                        MessageBox.Show("User added successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add user.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn cần nhập vào username!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserName.Focus();
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtUserName.Text.Trim(), @"^[a-zA-Z0-9]+$"))
                {
                    MessageBox.Show("Username không được chứa ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserName.Focus();
                    return;
                }

                if (txtEmail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn cần nhập vào email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (txtFullname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn cần nhập vào fullname!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFullname.Focus();
                    return;
                }

                if (txtAddress.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn cần nhập vào address!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAddress.Focus();
                    return;
                }

                if (txtPhone.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn cần nhập vào phone!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text.Trim(), @"^\d+$") || txtPhone.Text.Trim().Length != 10 || !txtPhone.Text.Trim().StartsWith("0"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }
                if (dgvUserList.SelectedRows.Count > 0)
                {
                    int maKH = (int)dgvUserList.SelectedRows[0].Cells["ID"].Value;

                    int maNhomNguoiDung = (int)cmbUserGroup.SelectedValue;

                    KhachHangDTO updatedUser = new KhachHangDTO
                    {
                        maKH = maKH,
                        username = txtUserName.Text,
                        hoTen = txtFullname.Text,
                        email = txtEmail.Text,
                        diaChi = txtAddress.Text,
                        soDienThoai = txtPhone.Text,
                        maNhomNguoiDung = maNhomNguoiDung 
                    };

                    bul.UpdateKhachHang(updatedUser);
                    LoadUserList(maNhomNguoiDung);
                    MessageBox.Show("User updated successfully!");
                }
                else
                {
                    MessageBox.Show("Please select a user to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    if (dgvUserList.SelectedRows.Count > 0)
                    {
                        int maKH = (int)dgvUserList.SelectedRows[0].Cells["ID"].Value;

                        bul.DeleteKhachHang(maKH);
                        int maNhomNguoiDung = (int)cmbUserGroup.SelectedValue;
                        LoadUserList(maNhomNguoiDung); 
                        MessageBox.Show("User deleted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Please select a user to delete.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                         "Bạn có chắc chắn muốn hủy không?",
                         "Xác nhận",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question
                     );
            if (result == DialogResult.Yes)
            {
                txtUserName.Clear();
                txtFullname.Clear();
                txtEmail.Clear();
                txtPhone.Clear();
                txtAddress.Clear();
            }
        }
    }
}
