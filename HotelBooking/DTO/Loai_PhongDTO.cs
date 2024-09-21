using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Loai_PhongDTO
    {
        public int maLoaiPhong {  get; set; }
        public string tenLoaiPhong { get; set; }
        public string moTa {  get; set; }

        public Loai_PhongDTO() { }  

        public Loai_PhongDTO(int maLoaiPhong, string tenLoaiPhong, string moTa)
        {
            this.maLoaiPhong = maLoaiPhong;
            this.tenLoaiPhong = tenLoaiPhong;
            this.moTa = moTa;
        }
    }
}
