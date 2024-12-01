using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class PhanQuyenBLL
    {
        PhanQuyenDAL dal = new PhanQuyenDAL();

        public bool CoQuyen(int userTypeId, object tag)
        {
            if(userTypeId <= 0)
            {
                MessageBox.Show("Mã nhóm người dùng không hợp lệ!");
                return false;
            }
            if (tag == null)
            {
                MessageBox.Show("Tag không hợp lệ!");
                return false;
            }

            return dal.CoQuyen(userTypeId, tag);
        }
    }
}
