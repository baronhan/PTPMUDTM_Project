using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class PhieuDatPhongBUL
    {
        PhieuDatPhongDAL dal = new PhieuDatPhongDAL();
        public bool insertPhieuDatPhong(PhieuDatPhongDTO pdp, List<Dich_VuDTO> list)
        {
            return dal.insertPhieuDatPhong(pdp, list);
        }

        public List<BookingInfoDTO> getBookingListByCustomerID(int maKH)
        {
            return dal.getBookingListByCustomerID((int) maKH);
        }
    }
}
