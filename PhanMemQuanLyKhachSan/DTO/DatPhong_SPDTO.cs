using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DatPhong_SPDTO
    {
        public int idDPSP {  get; set; }
        public int idDP {  get; set; }
        public int idSP { get; set; }
        public int idPhong { get; set; }
        public int soLuong { get; set; }
        public decimal donGia { get; set; }
        public decimal thanhTien { get; set; }
        public DateTime ngay {  get; set; }

        public DatPhong_SPDTO() { }

        public DatPhong_SPDTO(int idDPSP, int idDP, int idSP, int idPhong, int soLuong, decimal donGia, decimal thanhTien, DateTime ngay)
        {
            this.idDPSP = idDPSP;
            this.idDP = idDP;
            this.idSP = idSP;
            this.idPhong = idPhong;
            this.soLuong = soLuong;
            this.donGia = donGia;
            this.thanhTien = thanhTien;
            this.ngay = ngay;
        }
    }
}
