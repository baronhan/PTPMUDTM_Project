using BLL;
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
    public partial class Form_QuenMatKhau : Form
    {
        UserBLL bll = new UserBLL();
        int uid;
        public Form_QuenMatKhau(int uid)
        {
            InitializeComponent();
            this.uid = uid;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string confirmPassword = txtConfirmPassword.Text;
            string passWord = txtPassword.Text;
            string newPassword = txtNewPassword.Text;

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!bll.KiemTraMatKhauCu(passWord))
            {
                MessageBox.Show("Mật khẩu cũ không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isPasswordChanged = bll.ThayDoiMatKhau(newPassword, uid);

            if (isPasswordChanged)
            {
                MessageBox.Show("Mật khẩu đã được thay đổi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thay đổi mật khẩu. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
