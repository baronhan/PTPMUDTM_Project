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


    }
}
