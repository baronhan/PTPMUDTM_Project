using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class KhachHangDAL
    {
        QLKSDataContext context = new QLKSDataContext();

        public List<KhachHangDTO> getDanhSachKhachHang()
        {
            try
            {
                List <KhachHangDTO> list = context.KhachHangs
                    .Select(kh => new KhachHangDTO
                    {
                        idKH = kh.idKH,
                        hoTen = kh.hoTen,
                        gioiTinh = (bool)kh.gioiTinh,
                        cccd = kh.cccd,
                        dienThoai = kh.dienThoai,
                        email = kh.email,
                        diaChi = kh.diaChi,
                        disable = (bool)kh.disable
                    }).ToList();

                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public bool addKhachHang(KhachHangDTO khachHangDTO)
        {
            try
            {
                var khachHang = new KhachHang
                {
                    hoTen = khachHangDTO.hoTen,
                    gioiTinh = khachHangDTO.gioiTinh,
                    cccd = khachHangDTO.cccd,
                    dienThoai = khachHangDTO.dienThoai,
                    email = khachHangDTO.email,
                    diaChi = khachHangDTO.diaChi,
                    disable = khachHangDTO.disable
                };

                context.KhachHangs.InsertOnSubmit(khachHang);

                context.SubmitChanges();

                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        public bool updateKhachHang(KhachHangDTO khachHangDTO)
        {
            try
            {
                var existingKhachHang = context.KhachHangs.FirstOrDefault(kh => kh.idKH == khachHangDTO.idKH);

                existingKhachHang.hoTen = khachHangDTO.hoTen;
                existingKhachHang.cccd  = khachHangDTO.cccd;
                existingKhachHang.gioiTinh = khachHangDTO.gioiTinh;
                existingKhachHang.dienThoai = khachHangDTO.dienThoai;
                existingKhachHang.email = khachHangDTO.email;
                existingKhachHang.diaChi = khachHangDTO.diaChi;
                existingKhachHang.disable = khachHangDTO.disable;

                context.SubmitChanges();

                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        public bool deleteKhachHang(int idKH)
        {
            try
            {
                var khachHang = context.KhachHangs.FirstOrDefault(kh => kh.idKH == idKH);

                context.KhachHangs.DeleteOnSubmit(khachHang);

                context.SubmitChanges(); 
                
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public KhachHangDTO getKhachHangByID(int idKH)
        {
            try
            {
                var khachhang = context.KhachHangs.FirstOrDefault(kh => kh.idKH == idKH);

                KhachHangDTO _kh = new KhachHangDTO
                {
                    idKH = khachhang.idKH,
                    hoTen = khachhang.hoTen
                };

                return _kh;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
