using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class PhieuDatPhongDAL
    {
        QL_KhachSanDataContext qlks = new QL_KhachSanDataContext();

        public bool insertPhieuDatPhong(PhieuDatPhongDTO pdp, List<Dich_VuDTO> dichVuList)
        {
            try
            {
                Phieu_Dat_Phong phieuDatPhong = new Phieu_Dat_Phong
                {
                    maKH = pdp.maKH,
                    maPhong = pdp.maPhong,
                    checkIn = pdp.checkIn,
                    checkOut = pdp.checkOut,
                    tongTien = pdp.tongTien
                };

                qlks.Phieu_Dat_Phongs.InsertOnSubmit(phieuDatPhong);
                qlks.SubmitChanges();

                int maDatPhong = phieuDatPhong.maDatPhong;

                var serviceDict = new Dictionary<int, (int soLuong, decimal donGia)>();

                foreach (var dichVu in dichVuList)
                {
                    if (serviceDict.ContainsKey(dichVu.maDichVu))
                    {
                        serviceDict[dichVu.maDichVu] = (
                            serviceDict[dichVu.maDichVu].soLuong + 1,
                            serviceDict[dichVu.maDichVu].donGia + dichVu.donGia
                        );
                    }
                    else
                    {
                        serviceDict.Add(dichVu.maDichVu, (1, dichVu.donGia));
                    }
                }

                foreach (var service in serviceDict)
                {
                    CT_PDP_DV chiTiet = new CT_PDP_DV
                    {
                        maDatPhong = maDatPhong,
                        maDichVu = service.Key,
                        soLuong = service.Value.soLuong,
                        tongTien = service.Value.donGia
                    };

                    qlks.CT_PDP_DVs.InsertOnSubmit(chiTiet);
                }

                qlks.SubmitChanges();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public List<BookingInfoDTO> getBookingListByCustomerID(int maKH)
        {
            var bookingList = (from pdp in qlks.Phieu_Dat_Phongs
                               join kh in qlks.Khach_Hangs on pdp.maKH equals kh.maKH
                               join p in qlks.Phongs on pdp.maPhong equals p.maPhong
                               where pdp.maKH == maKH
                               select new BookingInfoDTO
                               {
                                   maDatPhong = pdp.maDatPhong,
                                   maPhong = p.maPhong,
                                   username = kh.userName,
                                   tenPhong = p.tenPhong,
                                   checkIn = (DateTime)pdp.checkIn, 
                                   checkOut = (DateTime)pdp.checkOut, 
                                   tongTien = (decimal)pdp.tongTien 
                               }).ToList(); 

            return bookingList;
        }

    }
}
