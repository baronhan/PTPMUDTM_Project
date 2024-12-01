using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class PhanQuyenDAL
    {
        QLKSDataContext context = new QLKSDataContext();

        public bool CoQuyen(int userTypeId, object tag)
        {
            try
            {
                if (tag == null)
                {
                    return false; 
                }

                string tagUrl = tag.ToString();

                var hasPermission = (from p in context.Permissions
                                   join pg in context.Forms on p.formID equals pg.formID
                                   where p.userType == userTypeId
                                         && pg.url == tagUrl
                                         && p.coQuyen == true
                                   select p).Any();


                return hasPermission;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false; 
            }
        }

    }
}
