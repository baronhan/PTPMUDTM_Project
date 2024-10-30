using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class Dich_VuBUL
    {
        Dich_VuDAL dal = new Dich_VuDAL();
        public DataTable SelectDichVu()
        {
            return dal.SelectDichVu();
        }

        public List<Dich_VuDTO> GetServicesByBookingId(int maDatPhong)
        {
            return dal.GetServicesByBookingId(maDatPhong);
        }
    }
}
