using BCrypt.Net;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class KhachHangBUL
    {
        KhanhHangDAL dal = new KhanhHangDAL();

        public bool VerifyLogin(string username, string password)
        {
            return dal.VerifyLogin(username, password);
        }
        public bool RegisterNewUser(string username, string password, string fullName, string email, string address, string phone)
        {
            return dal.Register(username, password, fullName, email, address, phone);
        }
        public List<KhachHangDTO> GetAllKhachHang()
        {
            return dal.GetAllKhachHang();
        }

        public DataTable GetKhachHangDataTable()
        {
            return dal.GetKhachHangDataTable();
        }
        public DataTable GetKhachHangDataTable(int? userGroupId = null)
        {

            return dal.GetKhachHangDataTable(userGroupId);
        }
        public KhachHangDTO GetKhachHangByUsername(string username)
        {
            return dal.GetKhachHangByUsername(username);
        }
        public int GetMaNhom(string username)
        {
            return dal.GetMaNhom(username);
        }
        public bool AddKhachHang(KhachHangDTO khachHang)
        {
            return dal.AddKhachHang(khachHang);
        }
        public bool UpdateKhachHang(KhachHangDTO khachHang)
        {
            return dal.UpdateKhachHang(khachHang);
        }

        public bool DeleteKhachHang(int maKH)
        {
            return dal.DeleteKhachHang(maKH);
        }

        public bool ChangePassword(string username, string currentPassword, string newPassword)
        {
            var user = dal.GetKhachHangByUsername(username);
            if (user == null)
            {
                throw new Exception("Người dùng không tồn tại.");
            }

       
            bool isPasswordMatch = BCrypt.Net.BCrypt.Verify(currentPassword, user.password);
            if (!isPasswordMatch)
            {
                throw new Exception("Mật khẩu hiện tại không chính xác.");
            }
            string hashedNewPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

            bool isUpdated = dal.UpdatePassword(username, hashedNewPassword);
            return isUpdated;
        }

    }
}
