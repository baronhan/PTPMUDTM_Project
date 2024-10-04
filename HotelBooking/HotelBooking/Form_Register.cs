using BUL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBooking
{
    public partial class Form_Register : Form
    {
        KhachHangBUL bul = new KhachHangBUL();
        public Form_Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập vào " + lblUsername.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtUserName.Text.Trim(), @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Username không được chứa ký tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }

            if (txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập vào " + lblPassword.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text.Trim().Length < 8)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập vào " + lblEmail.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            if (txtFullName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập vào " + lblFullName.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }
            if (txtAddress.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập vào " + lblAddress.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }
            if (txtPhone.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập vào " + lblPhone.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text.Trim(), @"^\d+$") || txtPhone.Text.Trim().Length != 10 || !txtPhone.Text.Trim().StartsWith("0"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string hoten = txtFullName.Text.Trim();
            string diachi = txtAddress.Text.Trim();
            string email = txtEmail.Text.Trim();
            string sdt = txtPhone.Text.Trim();

            bool isSuccess = bul.RegisterNewUser(username, password, hoten, email, diachi, sdt);

            if (isSuccess)
            {
                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form_Login form = new Form_Login();
                form.Show();
            }
            else
            {
                MessageBox.Show("Đăng ký không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
        }

        private void llLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form_Login form = new Form_Login();
            form.Show();
        }

<<<<<<< HEAD
=======
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
>>>>>>> ed61d68dc2a6cabd7b6f68ceb6a13aff424753c7
    }
}
