using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DatPhong_CTDTO
    {
        public int idDPCT {  get; set; }
        public int idDP {  get; set; }
        public int idPhong { get; set; }
        public int soNgayO {  get; set; }
        public decimal donGia { get; set; }
        public decimal thanhTien { get; set; }
        public DateTime ngay {  get; set; }

        public DatPhong_CTDTO() { }

        public DatPhong_CTDTO(int idDPCT, int idDP, int idPhong, int soNgayO, decimal donGia, decimal thanhTien, DateTime ngay)
        {
            this.idDPCT = idDPCT;
            this.idDP = idDP;
            this.idPhong = idPhong;
            this.soNgayO = soNgayO;
            this.donGia = donGia;
            this.thanhTien = thanhTien;
            this.ngay = ngay;
        }
    }
}
