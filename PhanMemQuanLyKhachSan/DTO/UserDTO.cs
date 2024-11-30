using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int uid { get; set; }
        public string fullName { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public DateTime lastPassword { get; set; }
        public bool disable {  get; set; }

        public UserDTO() { }
        public UserDTO(int uid, string fullName, string userName, string passWord, DateTime lastPassword, bool disable)
        {
            this.uid = uid;
            this.fullName = fullName;
            this.userName = userName;
            this.passWord = passWord;
            this.lastPassword = lastPassword;
            this.disable = disable;
        }
    }
}
