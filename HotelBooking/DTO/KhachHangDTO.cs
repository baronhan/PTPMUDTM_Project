using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        public int maKH { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string hoTen { get; set; }
        public string email { get; set; }
        public string diaChi { get; set; }
        public string soDienThoai { get; set; }
        public int maNhomNguoiDung { get; set; }

        public KhachHangDTO() { }
        public KhachHangDTO(int maKH, string username, string password, string hoTen, string email, string diaChi, string soDienThoai, int maNhomNguoiDung)
        {
            this.maKH = maKH;
            this.username = username;
            this.password = password;
            this.hoTen = hoTen;
            this.email = email;
            this.diaChi = diaChi;
            this.soDienThoai = soDienThoai;
            this.maNhomNguoiDung = maNhomNguoiDung;
        }


    }
}
