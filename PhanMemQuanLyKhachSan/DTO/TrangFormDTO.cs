using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TrangFormDTO
    {
        public int formId {  get; set; }
        public string url { get; set; }
        public TrangFormDTO() { }
        public TrangFormDTO(int formId, string url)
        {
            this.formId = formId;
            this.url = url;
        }
    }
}
