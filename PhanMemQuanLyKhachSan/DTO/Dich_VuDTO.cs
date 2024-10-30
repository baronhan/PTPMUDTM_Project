using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Dich_VuDTO
    {
        public int maDichVu {  get; set; }
        public string tenDichVu { get; set; }
        public string acronym { get; set; }
        public decimal donGia { get; set; }

        public Dich_VuDTO() { }
        public Dich_VuDTO(int maDichVu, string tenDichVu, string acronym, decimal donGia)
        {
            this.maDichVu = maDichVu;
            this.tenDichVu = tenDichVu;
            this.acronym = acronym;
            this.donGia = donGia;
        }
    }
}
