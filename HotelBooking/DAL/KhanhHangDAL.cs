using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class KhanhHangDAL
    {
        QL_KhachSanDataContext qlks = new QL_KhachSanDataContext();

        public bool VerifyLogin(string username, string password)
        {
            try
            {
                Khach_Hang kh = qlks.Khach_Hangs.Where(t => t.userName == username && t.password == password).FirstOrDefault();

                if (kh != null)
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
    }
}
