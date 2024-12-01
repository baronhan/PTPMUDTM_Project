using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhomNguoiDungDTO
    {
        public int userType {  get; set; }
        public string name { get; set; }
        public NhomNguoiDungDTO() { }
        public NhomNguoiDungDTO(int userType, string name)
        {
            this.userType = userType;
            this.name = name;
        }
    }
}
