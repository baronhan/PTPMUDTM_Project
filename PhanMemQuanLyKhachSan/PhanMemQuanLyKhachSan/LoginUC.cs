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
    public partial class LoginUC : UserControl
    {
        public LoginUC()
        {
            InitializeComponent();
        }
        public string Username
        {
            get { return txtUsername.Text; }
            set { txtUsername.Text = value; }
        }
        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }

        private void ckHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHienThiMatKhau.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text.Length == 0)
            {
                MessageBox.Show("Tên đăng nhập không được để trống!");
                txtUsername.Focus();
                return;
            }    

            if(txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Mật khẩu không được để trống!");
                txtPassword.Focus();
                return ;
            }    

            OnSubmitClicked(sender, e);
        }

        public delegate void SubmitClickedHandler(object sender, EventArgs e);
        public event SubmitClickedHandler SubmitClicked;
        protected virtual void OnSubmitClicked(object sender, EventArgs e)
        {
            if(SubmitClicked != null)
            {
                SubmitClicked(sender, e);
            }    
        }

    }
}
