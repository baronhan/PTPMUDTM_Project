using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class UserDAL
    {
        QLKSDataContext context = new QLKSDataContext();

        public int GetUID(string tenDangNhap)
        {
            try
            {
                var user = context.Users.FirstOrDefault(u => u.userName == tenDangNhap);
                if (user != null)
                {
                    return user.uid;
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public int GetUserTypeID(int uid)
        {
            try
            {
                var user = context.Users.FirstOrDefault(u => u.uid == uid);
                if (user != null)
                {
                    return user.userType.Value;
                }

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public bool KiemTraMatKhauCu(string passWord)
        {
            try
            {
                var user = context.Users.FirstOrDefault(u => u.passWord == passWord);
                if (user != null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool KiemTraNguoiDung(string tenDangNhap, string passWord)
        {
            try
            {
                var user = context.Users.FirstOrDefault(u => u.userName == tenDangNhap && u.passWord == passWord);
                if (user != null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool ThayDoiMatKhau(string newPassword, int uid)
        {
            try
            {
                var user = context.Users.FirstOrDefault(u => u.uid == uid);

                if (user != null)
                {
                    user.passWord = newPassword;
                    context.SubmitChanges();
                    return true;
                }
                return false ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
