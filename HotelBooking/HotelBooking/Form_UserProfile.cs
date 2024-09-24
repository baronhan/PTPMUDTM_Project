using BUL;
using DTO;
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

namespace HotelBooking
{
    public partial class Form_UserProfile : Form
    {
      
        string _username = Form_Login._username;
        KhachHangBUL bul = new KhachHangBUL();
        KhachHangDTO kh;
        public Form_UserProfile()
        {
            InitializeComponent();
            LoadUserProfile();
    
        }
        private void Form_UserProfile_Load(object sender, EventArgs e)
        {
            pictureBoxUser.Image = Properties.Resources.defaultAvatar;
            pictureBoxUser.SizeMode = PictureBoxSizeMode.Zoom;
            //pictureBoxUser.Region = GetRoundedImagePicturebox(pictureBoxUser);
            lblUser.Text = _username;
            lblUser.Font = new Font(lblUser.Font.FontFamily, 20);
        }
        private void LoadUserProfile()
        {
            kh = bul.GetKhachHangByUsername(_username);

            if (kh != null)
            {
                txtFullname.Text = kh.hoTen;
                txtEmail.Text = kh.email;
                txtAddress.Text = kh.diaChi;
                txtPhone.Text = kh.soDienThoai;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
        private void SetRoundedImageInPictureBox(PictureBox pictureBox, Image image)
        {

            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
               
                float boxRatio = (float)pictureBox.Width / pictureBox.Height;
                float imageRatio = (float)image.Width / image.Height;

                Rectangle srcRect;
                if (imageRatio > boxRatio) 
                {
                    int newWidth = (int)(image.Height * boxRatio);
                    int cropX = (image.Width - newWidth) / 2;
                    srcRect = new Rectangle(cropX, 0, newWidth, image.Height);
                }
                else 
                {
                    int newHeight = (int)(image.Width / boxRatio);
                    int cropY = (image.Height - newHeight) / 2;
                    srcRect = new Rectangle(0, cropY, image.Width, newHeight);
                }

                Rectangle destRect = new Rectangle(0, 0, pictureBox.Width, pictureBox.Height);
                g.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
                    Region region = new Region(path);
                    pictureBox.Region = region;
                }
            }
            pictureBox.Image = bitmap;
        }


        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Hãy chọn 1 bức ảnh đẹp nhất";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image image = Image.FromFile(openFileDialog.FileName);
                    //pictureBoxUser.Image = image;

                    SetRoundedImageInPictureBox(pictureBoxUser, image);

                    pictureBoxUser.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            if (pictureBoxUser.Image != null)
            {
                pictureBoxUser.Image = Properties.Resources.defaultAvatar;
            }
            else
            {
                MessageBox.Show("Không có ảnh để xóa!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "Save")
            {
                LoadUserProfile();
                btnUpdate.Text = "Update";
                EnabledFalseTXT();

            }
        }

        private void EnabledTrueTXT()
        {
            txtAddress.Enabled = true;
            txtEmail.Enabled = true;
            txtFullname.Enabled = true;
            txtPhone.Enabled = true;
        }
        private void EnabledFalseTXT()
        {
            txtAddress.Enabled = false;
            txtEmail.Enabled = false;
            txtFullname.Enabled = false;
            txtPhone.Enabled = false;
        }
        private bool ValidateUserInfo()
        {
            if (string.IsNullOrWhiteSpace(txtFullname.Text))
            {
                MessageBox.Show("Họ và tên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullname.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            //if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^\d{10}$"))
            //{
            //    MessageBox.Show("Số điện thoại phải có 10 ký tự số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtPhone.Focus();
            //    return false;
            //}
            return true;
        }
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập ký số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txtPhone.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Số điện thoại không được vượt quá 10 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (btnUpdate.Text == "Update")
            {
                btnUpdate.Text = "Save";
                EnabledTrueTXT();
                txtFullname.Focus();
            }
            else
            {

                if (kh != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin này không?",
                                                 "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (ValidateUserInfo())
                        {
                            kh.hoTen = txtFullname.Text;
                            kh.email = txtEmail.Text;
                            kh.diaChi = txtAddress.Text;
                            kh.soDienThoai = txtPhone.Text;

                            bool isUpdated = bul.UpdateKhachHang(kh);

                            if (isUpdated)
                            {
                                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật thông tin thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            LoadUserProfile();
                            btnUpdate.Text = "Update";
                            EnabledFalseTXT();
                        }
                    }
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (kh != null)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản không? Bạn sẽ cần đăng nhập lại.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    bool isDeleted = bul.DeleteKhachHang(kh.maKH);
                    if (isDeleted)
                    {
                        MessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        Form_Login form_Login = new Form_Login();
                        form_Login.Show();


                    }
                    else
                    {
                        MessageBox.Show("Xóa người dùng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có người dùng để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnzChangePassword_Click(object sender, EventArgs e)
        {
            if (kh != null) // Kiểm tra nếu kh không null
            {
                Form_ChangePassword form = new Form_ChangePassword(kh.maKH); // Truyền maKH vào form
           
                form.ShowDialog();
                form.BringToFront();
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
