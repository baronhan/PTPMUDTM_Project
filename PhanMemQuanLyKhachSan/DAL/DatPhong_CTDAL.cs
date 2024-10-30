using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class DatPhong_CTDAL
    {
        QLKSDataContext context = new QLKSDataContext();

        public bool addDatPhongChiTiet(DatPhong_CTDTO datPhongChiTiet)
        {
            try
            {
                var dpct = new DatPhong_CT
                {
                    idDP = datPhongChiTiet.idDP,
                    idPhong = datPhongChiTiet.idPhong,
                    soNgayO = datPhongChiTiet.soNgayO,
                    donGia = datPhongChiTiet.donGia,
                    thanhTien = datPhongChiTiet.thanhTien,
                    ngay = datPhongChiTiet.ngay
                };

                context.DatPhong_CTs.InsertOnSubmit(dpct);

                context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool deleteDatPhongChiTiet(int idDP, int idPhongToRemove)
        {
            try
            {
                var datphong = context.DatPhong_CTs.Where(dp => dp.idDP == idDP && dp.idPhong == idPhongToRemove).FirstOrDefault();

                context.DatPhong_CTs.DeleteOnSubmit(datphong);

                context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public List<int> getExistingRoomIds(int idDP)
        {
            try
            {
                List<int> roomIds = context.DatPhong_CTs.Where(ctdp => ctdp.idDP == idDP && ctdp.idPhong.HasValue).Select(ctdp => ctdp.idPhong.Value).ToList();

                return roomIds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public DataTable getPhongDetailsByBookingId(int idDP)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Mã tầng", typeof(int));
            table.Columns.Add("Mã phòng", typeof(int));
            table.Columns.Add("Tên tầng", typeof(string));
            table.Columns.Add("Tên phòng", typeof(string));
            table.Columns.Add("Đơn giá", typeof(decimal));

            var query = from ctdp in context.DatPhong_CTs
                        join bookingPhong in context.DatPhongs on ctdp.idDP equals bookingPhong.idDP
                        join phong in context.Phongs on ctdp.idPhong equals phong.idPhong
                        join tang in context.Tangs on phong.idTang equals tang.idTang
                        join loaiphong in context.LoaiPhongs on phong.idLoaiPhong equals loaiphong.idLoaiPhong
                        where bookingPhong.idDP == idDP
                        select new
                        {
                            idTang = (int)tang.idTang,
                            idPhong = (int)phong.idPhong,
                            tenPhong = phong.tenPhong,
                            tenTang = tang.tenTang,
                            donGia = loaiphong.donGia
                        };

            foreach (var item in query)
            {
                table.Rows.Add(item.idTang, item.idPhong, item.tenTang, item.tenPhong, item.donGia);
            }

            return table;
        }

        public bool updateDatPhongChiTiet(DatPhong_CTDTO dpctDTO)
        {
            try
            {
                var ctdp = context.DatPhong_CTs.Where(ct => ct.idDP == dpctDTO.idDP && ct.idPhong == dpctDTO.idPhong).FirstOrDefault();

                ctdp.soNgayO = dpctDTO.soNgayO;
                ctdp.donGia = dpctDTO.donGia;
                ctdp.thanhTien = dpctDTO.thanhTien;
                ctdp.ngay =  DateTime.Now;
                
                context.SubmitChanges();
                
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return false;
            }
        }
    }
}
