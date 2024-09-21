using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class KhachHangBUL
    {
        KhanhHangDAL dal = new KhanhHangDAL();

        public bool VerifyLogin(string username, string password)
        {
            return dal.VerifyLogin(username, password);
        }
        public bool RegisterNewUser(string username, string password, string fullName, string email, string address, string phone)
        {
            return dal.Register(username, password, fullName, email, address, phone);
        }
    }
}
