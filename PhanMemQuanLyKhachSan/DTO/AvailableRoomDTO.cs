using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AvailableRoomDTO
    {
        public int idPhong {  get; set; }
        public string tenPhong { get; set; }
        public string tenTang { get; set; }
        public decimal donGia { get; set; }
        public int idTang {  get; set; }
        public AvailableRoomDTO() { }
        public AvailableRoomDTO(int idPhong, string tenPhong, string tenTang, decimal donGia, int idTang)
        {
            this.idPhong = idPhong;
            this.tenPhong = tenPhong;
            this.tenTang = tenTang;
            this.donGia = donGia;
            this.idTang = idTang;
        }
    }
}
