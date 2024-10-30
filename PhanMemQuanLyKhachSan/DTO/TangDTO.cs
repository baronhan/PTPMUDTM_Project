using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TangDTO
    {
        public int idTang { get; set; }
        public string tenTang { get; set; }
        public bool disable {  get; set; }
        public TangDTO() { }
        public TangDTO(int idTang, string tenTang, bool disable)
        {
            this.idTang = idTang;
            this.tenTang = tenTang;
            this.disable = disable;
        }
    }
}
