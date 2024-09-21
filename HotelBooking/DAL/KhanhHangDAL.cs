using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace DAL
{
    public class KhanhHangDAL
    {
        QL_KhachSanDataContext qlks = new QL_KhachSanDataContext();

        public bool VerifyLogin(string username, string password)
        {
            try
            {
                Khach_Hang kh = qlks.Khach_Hangs.Where(t => t.userName == username && t.password == password).FirstOrDefault();

                if (kh != null)
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public bool Register(string username, string password, string fullName, string email, string address, string phone)
        {
            try
            {
                var existingUser = qlks.Khach_Hangs
                    .FirstOrDefault(kh => kh.userName == username || kh.email == email);

                if (existingUser != null)
                {
                    MessageBox.Show("Tài khoản đã tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                Khach_Hang newKhachHang = new Khach_Hang
                {
                    userName = username,
                    password = hashedPassword,
                    hoTen = fullName,
                    email = email,
                    diaChi = address,
                    soDienThoai = phone
                };

                qlks.Khach_Hangs.InsertOnSubmit(newKhachHang);
                qlks.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}