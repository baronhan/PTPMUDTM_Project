using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiPhongDTO
    {
        public int idLoaiPhong { get; set; }
        public string tenLoaiPhong { get; set; }
        public decimal donGia { get; set; }
        public int soNguoi { get; set; }
        public int soGiuong { get; set; }
        public bool disable {  get; set; }
        public LoaiPhongDTO() { }
        public LoaiPhongDTO(int idLoaiPhong, string tenLoaiPhong, decimal donGia, int soNguoi, int soGiuong, bool disable)
        {
            this.idLoaiPhong = idLoaiPhong;
            this.tenLoaiPhong = tenLoaiPhong;
            this.donGia = donGia;
            this.soNguoi = soNguoi;
            this.soGiuong = soGiuong;
            this.disable = disable;
        }
    }
}
