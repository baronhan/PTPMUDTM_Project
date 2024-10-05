using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuDatPhongDTO
    {
        public int? maDatPhong { get; set; }
        public int maKH {get; set; }
        public int maPhong { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public decimal tongTien { get; set; }

        public PhieuDatPhongDTO() { }

        public PhieuDatPhongDTO(int? maDatPhong, int maKH, int maPhong, DateTime checkIn, DateTime checkOut, decimal tongTien)
        {
            this.maDatPhong = maDatPhong;
            this.maKH = maKH;
            this.maPhong = maPhong;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
            this.tongTien = tongTien;
        }
    }
}
