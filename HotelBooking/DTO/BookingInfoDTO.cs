using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BookingInfoDTO
    {
        public int maDatPhong {  get; set; }
        public int maPhong {  get; set; }   
        public string username { get; set; }
        public string tenPhong { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public decimal tongTien { get; set; }
        public BookingInfoDTO() { }

        public BookingInfoDTO(string username, string tenPhong, DateTime checkIn, DateTime checkOut, decimal tongTien)
        {
            this.username = username;
            this.tenPhong = tenPhong;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
            this.tongTien = tongTien;
        }
    }
}
