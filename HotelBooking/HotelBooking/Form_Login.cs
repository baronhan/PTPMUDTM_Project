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
    public partial class Form_Login : Form
    {
        public static string _username = "";
        KhachHangBUL bul = new KhachHangBUL();
        public Form_Login()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 30;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);

            this.Region = new Region(path);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập vào " + lblUsername.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }


            if (!System.Text.RegularExpressions.Regex.IsMatch(txtUserName.Text.Trim(), @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Username không được chứa ký tự đặc biệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }



            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();


            bool kq = bul.VerifyLogin(username, password);

            string tb = "";

            if (kq)
            {
                tb = "Bạn đã đăng nhập thành công!";
                _username = username;
                this.Hide();

                if (bul.GetMaNhom(username) == 2) //
                {
                    Form_Management form = new Form_Management();
                    form.Show();
                }
                else
                {
                    Form_Main form = new Form_Main();
                    form.Show();
                }
            }
            else
            {
                tb = "Bạn đăng nhập không thành công!";
            }

            MessageBox.Show(tb);
        }

        private void llCreateNewAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form_Register form = new Form_Register();
            form.Show();
        }
    }
}
