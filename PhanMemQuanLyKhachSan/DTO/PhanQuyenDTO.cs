using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhanQuyenDTO
    {
        public int formId { get; set; }
        public string formName { get; set; }
        public bool coQuyen {  get; set; }
        public PhanQuyenDTO() { }
        public PhanQuyenDTO(int formId, string formName, bool coQuyen)
        {
            this.formId = formId;
            this.formName = formName;
            this.coQuyen = coQuyen;
        }
    }
}
