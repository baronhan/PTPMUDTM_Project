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
    public partial class Form_Login : Form
    {
        UserBLL userBLL = new UserBLL();
        PhanQuyenBLL phanQuyenBLL = new PhanQuyenBLL();
        public static int uid;
        public static int userTypeId;
        public Form_Login()
        {
            InitializeComponent();
            loginUC1.SubmitClicked += LoginUC_SubmitClicked;
        }

        private void LoginUC_SubmitClicked(object sender, EventArgs e)
        {
            string tenDangNhap = loginUC1.Username;
            string passWord = loginUC1.Password;

            if (userBLL.KiemTraNguoiDung(tenDangNhap, passWord))
            {
                int uid = userBLL.GetUID(tenDangNhap);
                int userTypeId = userBLL.GetUserTypeID(uid);

                Form_Main form = new Form_Main(userTypeId, uid);

                if (phanQuyenBLL.CoQuyen(userTypeId, form.Tag))
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show($"Bạn không có quyền truy cập vào {form.Tag.ToString()}");
                }
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại! Kiểm tra lại tên đăng nhập hoặc mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
