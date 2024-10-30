using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTO
    {
        public int idSP {  get; set; }
        public string tenSP { get; set; }
        public decimal donGia { get; set; }
        public bool disable {  get; set; }
        public SanPhamDTO() { }
        public SanPhamDTO(int idSP, string tenSP, decimal donGia, bool disable)
        {
            this.idSP = idSP;
            this.tenSP = tenSP;
            this.donGia = donGia;
            this.disable = disable;
        }
    }
}
