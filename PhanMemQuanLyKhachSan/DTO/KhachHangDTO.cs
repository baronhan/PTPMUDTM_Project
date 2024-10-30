using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        public int idKH {  get; set; }
        public string hoTen {  get; set; }
        public bool gioiTinh { get; set; }
        public string cccd { get; set; }
        public string dienThoai { get; set; }
        public string email { get; set; }
        public string diaChi { get; set; }
        public bool disable { get; set; }
        public KhachHangDTO() { }
        public KhachHangDTO(int idKH, string hoTen, bool gioiTinh, string cccd, string dienThoai, string email, string diaChi, bool disable)
        {
            this.idKH = idKH;
            this.hoTen = hoTen;
            this.gioiTinh = gioiTinh;
            this.cccd = cccd;
            this.dienThoai = dienThoai;
            this.email = email;
            this.diaChi = diaChi;
            this.disable = disable;
        }
    }
}
