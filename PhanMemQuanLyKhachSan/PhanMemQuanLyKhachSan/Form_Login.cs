﻿using BLL;
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
    public partial class Form_Login : Form
    {
        UserBLL userBLL = new UserBLL();
        public static int uid;
        public Form_Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtUsername.Text;
            string passWord = txtPassword.Text;

            if (userBLL.KiemTraNguoiDung(tenDangNhap, passWord))
            {
                MessageBox.Show("Đăng nhập thành công!");
                uid = userBLL.GetUID(tenDangNhap);
                Form_Main form = new Form_Main();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại! Kiểm tra lại tên đăng nhập hoặc mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void ckHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHienThiMatKhau.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar= true;
            }    
        }

        private void Form_Login_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}