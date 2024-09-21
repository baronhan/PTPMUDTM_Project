using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhongDTO
    {
        public int maPhong {  get; set; }
        public string tenPhong { get; set; }

        public int soLuongNguoi { get; set; }
        public decimal donGia { get; set; }
        public string moTa {  get; set; }
        public int maLoaiPhong { get; set; }
        public int trangThai {  get; set; }

        public PhongDTO() { }

        public PhongDTO(int maPhong, string tenPhong, int soLuongNguoi, decimal donGia, string moTa, int maLoaiPhong, int trangThai)
        {
            this.maPhong = maPhong;
            this.tenPhong = tenPhong;
            this.soLuongNguoi = soLuongNguoi;
            this.donGia = donGia;
            this.moTa = moTa;
            this.maLoaiPhong = maLoaiPhong;
            this.trangThai = trangThai;
        }
    }
}
