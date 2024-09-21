using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Hinh_Anh_PhongDTO
    {
        public int maHinhAnh {  get; set; }
        public string url { get; set; }
        public int maPhong { get; set; }

        public Hinh_Anh_PhongDTO() { }

        public Hinh_Anh_PhongDTO(int maHinhAnh, string url, int maPhong)
        {
            this.maHinhAnh = maHinhAnh;
            this.url = url;
            this.maPhong = maPhong;
        }
    }
}
