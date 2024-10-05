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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HotelBooking
{
    public partial class Form_ChangePassword : Form
    {
        string _username = Form_Login._username;
        KhachHangBUL bul = new KhachHangBUL();
        public Form_ChangePassword(int maKH)
        {
            InitializeComponent();
            txtOldPass.PasswordChar = '*';  
            txtNewPass.PasswordChar = '*';
            txtConfirmPass.PasswordChar = '*';

            txtOldPass.Font = new Font(txtOldPass.Font.FontFamily, 20);
            txtNewPass.Font = new Font(txtNewPass.Font.FontFamily, 20);
            txtConfirmPass.Font = new Font(txtConfirmPass.Font.FontFamily, 20);


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string oldPass = txtOldPass.Text;
            string newPass = txtNewPass.Text;
            string confirmPass = txtConfirmPass.Text;

            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp ");
                return;
            }
            if (txtOldPass.Text == String.Empty)
            {
                MessageBox.Show("Hãy nhập mật khẩu hiện tại ");

                return;
            }
            if (txtNewPass.Text == String.Empty)
            {
                MessageBox.Show("Hãy nhập mật khẩu mới");

                return;
            }
            if (txtConfirmPass.Text == String.Empty)
            {
                MessageBox.Show("Hãy nhập xác nhận mật khẩu mới");

                return;
            }
            try
            {
                bool isChanged = bul.ChangePassword(_username, oldPass, newPass);
                if (isChanged)
                {
                    MessageBox.Show("Bạn đã thay đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    Form_Login form_Login = new Form_Login();
                    form_Login.Show();

                }
                else
                {
                    MessageBox.Show("Thay đổi mật khẩu không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
