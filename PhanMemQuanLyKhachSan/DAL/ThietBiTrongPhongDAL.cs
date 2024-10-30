using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class ThietBiTrongPhongDAL
    {
        QLKSDataContext context = new QLKSDataContext();

        public List<ThietBiTrongPhongDTO> getDanhSachThietBiPhong()
        {
            try
            {
                List<ThietBiTrongPhongDTO> list = (from ptb in context.Phong_TBs
                                                   join tb in context.ThietBis on ptb.idTB equals tb.idTB
                                                   join p in context.Phongs on ptb.idPhong equals p.idPhong
                                                   select new ThietBiTrongPhongDTO
                                                   {
                                                       tenPhong = p.tenPhong,
                                                       tenTB = tb.tenTB,
                                                       soLuong = (int)ptb.soLuong,
                                                       idTB = (int)ptb.idTB,
                                                       idPhong = (int)ptb.idPhong
                                                   }).ToList();
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        
        public bool addThietBiPhong(ThietBiTrongPhongDTO thietBiTrongPhongDTO)
        {
            try
            {
                var phong = context.Phongs.FirstOrDefault(p => p.tenPhong == thietBiTrongPhongDTO.tenPhong);
                var thietBi = context.ThietBis.FirstOrDefault(tb => tb.tenTB == thietBiTrongPhongDTO.tenTB);

                if(phong == null || thietBi == null)
                {
                    MessageBox.Show("Tên phòng hoặc thiết bị không hợp lệ!");
                    return false;
                }

                var existingPhongTB = context.Phong_TBs.FirstOrDefault(pt => pt.idPhong == phong.idPhong && pt.idTB == thietBi.idTB);
                if (existingPhongTB != null)
                {
                    MessageBox.Show("Thiết bị đã tồn tại trong phòng này!");
                    return false;
                }

                var phongTB = new Phong_TB
                {
                    idPhong = phong.idPhong,
                    idTB = thietBi.idTB,
                    soLuong = thietBiTrongPhongDTO.soLuong
                };

                context.Phong_TBs.InsertOnSubmit(phongTB);

                context.SubmitChanges();

                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool updateThietBiPhong(ThietBiTrongPhongDTO thietBiTrongPhongDTO)
        {
            try
            {
                var phongTB = context.Phong_TBs.FirstOrDefault(pt => pt.idPhong == thietBiTrongPhongDTO.idPhong && pt.idTB == thietBiTrongPhongDTO.idTB);

                if (phongTB == null)
                {
                    MessageBox.Show("Không tìm thấy thiết bị trong phòng với thông tin đã cho!");
                    return false;
                }

                phongTB.soLuong = thietBiTrongPhongDTO.soLuong;

                context.SubmitChanges();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool deleteThietBiPhong(ThietBiTrongPhongDTO thietBiTrongPhongDTO)
        {
            try
            {
                var phongTB = context.Phong_TBs.FirstOrDefault(pt => pt.idPhong == thietBiTrongPhongDTO.idPhong && pt.idTB == thietBiTrongPhongDTO.idTB);

                if (phongTB == null)
                {
                    MessageBox.Show("Không tìm thấy thiết bị trong phòng với thông tin đã cho!");
                    return false;
                }

                context.Phong_TBs.DeleteOnSubmit(phongTB);

                context.SubmitChanges();

                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
    }
}
