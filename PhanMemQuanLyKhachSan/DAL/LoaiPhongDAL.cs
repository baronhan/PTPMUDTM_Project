using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class LoaiPhongDAL
    {
        QLKSDataContext context = new QLKSDataContext();

        public List<LoaiPhongDTO> getDanhSachLoaiPhong()
        {
            try
            {
                List<LoaiPhongDTO> list = context.LoaiPhongs
                .Select(lp => new LoaiPhongDTO
                {
                    idLoaiPhong = lp.idLoaiPhong,
                    tenLoaiPhong = lp.tenLoaiPhong,
                    donGia = (decimal)lp.donGia,
                    soNguoi = (int)lp.soNguoi,
                    soGiuong = (int)lp.soGiuong,
                    disable = (bool)lp.disable
                }).ToList();

                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool addLoaiPhong(LoaiPhongDTO loaiPhong)
        {
            try
            {
                var newLoaiPhong = new LoaiPhong
                {
                    tenLoaiPhong = loaiPhong.tenLoaiPhong,
                    soNguoi = loaiPhong.soNguoi,
                    soGiuong = loaiPhong.soGiuong,
                    donGia = loaiPhong.donGia,
                    disable = loaiPhong.disable
                };

                context.LoaiPhongs.InsertOnSubmit(newLoaiPhong);

                context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm mới loại phòng: " + ex.Message);
                return false;
            }
        }

        public bool updateLoaiPhong(LoaiPhongDTO loaiPhong)
        {
            try
            {
                var existingLoaiPhong = context.LoaiPhongs.Where(t => t.idLoaiPhong == loaiPhong.idLoaiPhong).FirstOrDefault();
                if(existingLoaiPhong != null)
                {
                    existingLoaiPhong.tenLoaiPhong = loaiPhong.tenLoaiPhong;
                    existingLoaiPhong.soNguoi = loaiPhong.soNguoi;
                    existingLoaiPhong.soGiuong = loaiPhong.soGiuong;
                    existingLoaiPhong.donGia = loaiPhong.donGia;
                    existingLoaiPhong.disable = loaiPhong.disable;

                    context.SubmitChanges();

                    return true;
                }    
                else
                {
                    return false;
                }    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool deleteLoaiPhong(int idLoaiPhong)
        {
            try
            {
                var loaiPhong = context.LoaiPhongs.Where(t => t.idLoaiPhong == idLoaiPhong).FirstOrDefault();

                if(loaiPhong != null)
                {
                    context.LoaiPhongs.DeleteOnSubmit(loaiPhong);

                    context.SubmitChanges();

                    return true;
                }    
                else
                {
                    return false;
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
