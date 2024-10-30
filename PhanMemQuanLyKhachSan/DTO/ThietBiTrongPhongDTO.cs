using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThietBiTrongPhongDTO
    {
        public string tenPhong {  get; set; }
        public string tenTB { get; set; }
        public int soLuong { get; set; }
        public int idPhong { get; set; }
        public int idTB { get; set; }
        public ThietBiTrongPhongDTO() { }
        public ThietBiTrongPhongDTO(string tenPhong, string tenTB, int soLuong, int idPhong, int idTB)
        {
            this.tenPhong = tenPhong;
            this.tenTB = tenTB;
            this.soLuong = soLuong;
            this.idPhong = idPhong;
            this.idTB = idTB;
        }
    }
}
