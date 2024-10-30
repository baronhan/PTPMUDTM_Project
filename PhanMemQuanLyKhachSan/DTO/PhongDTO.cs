using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhongDTO
    {
        public int idPhong {  get; set; }
        public string tenPhong { get; set; }
        public bool trangThai { get; set; }
        public int idTang {  get; set; }
        public int idLoaiPhong { get; set; }
        public string tenTang { get; set; }
        public string tenLoaiPhong { get; set; }
        public bool disable {  get; set; }

        public PhongDTO() { }

        public PhongDTO(int idPhong, string tenPhong, bool trangThai, int idTang, int idLoaiPhong, string tenTang, string tenLoaiPhong, bool disable)
        {
            this.idPhong = idPhong;
            this.tenPhong = tenPhong;
            this.trangThai = trangThai;
            this.idTang = idTang;
            this.idLoaiPhong = idLoaiPhong;
            this.tenTang = tenTang;
            this.tenLoaiPhong = tenLoaiPhong;
            this.disable = disable;
        }
    }
}
