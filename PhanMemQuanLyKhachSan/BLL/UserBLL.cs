using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class UserBLL
    {
        UserDAL dal = new UserDAL();

        public int GetUID(string tenDangNhap)
        {
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Tên đăng nhập là bắt buộc!");
            }
            return dal.GetUID(tenDangNhap);
        }

        public bool KiemTraMatKhauCu(string passWord)
        {
            if (string.IsNullOrEmpty(passWord))
            {
                MessageBox.Show("Mật khẩu là bắt buộc!");
            }
            return dal.KiemTraMatKhauCu(passWord);
        }

        public bool KiemTraNguoiDung(string tenDangNhap, string passWord)
        {
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Tên đăng nhập là bắt buộc!");
            }

            if (string.IsNullOrEmpty(passWord))
            {
                MessageBox.Show("Mật khẩu là bắt buộc!");
            }

            return dal.KiemTraNguoiDung(tenDangNhap, passWord);
        }

        public bool ThayDoiMatKhau(string newPassword, int uid)
        {
            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Mật khẩu mới là bắt buộc!");
            }

            return dal.ThayDoiMatKhau(newPassword, uid);
        }
    }
}
