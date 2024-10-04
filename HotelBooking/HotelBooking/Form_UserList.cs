using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Form_UserList()
        {
            InitializeComponent();
            LoadUserList();
        }

        private void LoadUserList()
        {
            try
            {
                DataTable userList = bul.GetKhachHangDataTable();
                dgvUserList.DataSource = userList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
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
                if (string.IsNullOrWhiteSpace(txtUserName.Text) ||
                    string.IsNullOrWhiteSpace(txtFullname.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtAddress.Text) ||
                    string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show("Please fill out all fields.");
                    return;
                }
                KhachHangDTO newUser = new KhachHangDTO
                {
                    username = txtUserName.Text,
                    hoTen = txtFullname.Text,
                    email = txtEmail.Text,
                    diaChi = txtAddress.Text,
                    soDienThoai = txtPhone.Text,
                    maNhomNguoiDung = 1 //
                };

                if (bul.AddKhachHang(newUser))
                {
                    LoadUserList();
                    MessageBox.Show("User added successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to add user.");
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
                if (dgvUserList.SelectedRows.Count > 0)
                {
                    int maKH = (int)dgvUserList.SelectedRows[0].Cells["ID"].Value;

                    KhachHangDTO updatedUser = new KhachHangDTO
                    {
                        maKH = maKH,
                        username = txtUserName.Text,
                        hoTen = txtFullname.Text,
                        email = txtEmail.Text,
                        diaChi = txtAddress.Text,
                        soDienThoai = txtPhone.Text,
                        maNhomNguoiDung = 1 // 
                    };

                    bul.UpdateKhachHang(updatedUser);
                    LoadUserList();
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
                if (dgvUserList.SelectedRows.Count > 0)
                {
                    int maKH = (int)dgvUserList.SelectedRows[0].Cells["ID"].Value;

                    bul.DeleteKhachHang(maKH);
                    LoadUserList();
                    MessageBox.Show("User deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Please select a user to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtFullname.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtFullname.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
        }
    }
}
