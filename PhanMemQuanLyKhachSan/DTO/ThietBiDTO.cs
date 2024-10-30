using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThietBiDTO
    {
        public int idTB { get; set; }
        public string tenTB { get; set; }
        public decimal donGia { get; set; }
        public bool disable {  get; set; }
        public ThietBiDTO() { }
        public ThietBiDTO(int idTB, string tenTB, decimal donGia, bool disable)
        {
            this.idTB = idTB;
            this.tenTB = tenTB;
            this.donGia = donGia;
            this.disable = disable;
        }
    }
}
