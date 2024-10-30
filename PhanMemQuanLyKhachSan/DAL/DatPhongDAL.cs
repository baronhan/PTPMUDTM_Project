using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class DatPhongDAL
    {
        QLKSDataContext context = new QLKSDataContext();


        public List<DatPhongDTO> getDanhSachDatPhong()
        {
            try
            {
                var list = new List<DatPhongDTO>();

                var query = from dp in context.DatPhongs
                            join kh in context.KhachHangs on dp.idKH equals kh.idKH 
                            select new
                            {
                                dp.idDP,
                                TenKhachHang = kh.hoTen, 
                                dp.idKH,
                                ngayDat = dp.ngayDat,
                                ngayTra = dp.ngayTra,
                                dp.soTien,
                                dp.soNguoiO,
                                dp.idUser,
                                dp.status,
                                dp.disable,
                                dp.theoDoan,
                                dp.ghiChu,
                                create_date = dp.create_date,
                                update_date = dp.update_date,
                                update_by = dp.update_by
                            };

                foreach (var item in query)
                {
                    list.Add(new DatPhongDTO
                    {
                        idDP = item.idDP,
                        idKH = (int)item.idKH, 
                        ngayDat = (DateTime)item.ngayDat,
                        ngayTra = (DateTime)item.ngayTra,
                        soTien = (decimal)item.soTien,
                        soNguoiO = (int)item.soNguoiO,
                        idUser = (int)item.idUser,
                        status = (bool)item.status,
                        disable = (bool)item.disable,
                        theoDoan = (bool)item.theoDoan,
                        ghiChu = item.ghiChu,
                        create_date = item.create_date ?? DateTime.MinValue,
                        update_date = item.update_date ?? DateTime.MinValue,
                        update_by = item.update_by ?? 0,
                        hoTen = item.TenKhachHang,
                        statusText = ((bool)item.status ? "Hoàn tất" : "Chưa hoàn tất")
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public DatPhongDTO addDatPhong(DatPhongDTO _datPhong)
        {
            try
            {
                var datPhong = new DatPhong
                {
                    idKH = _datPhong.idKH,
                    ngayDat = _datPhong.ngayDat,
                    ngayTra = _datPhong.ngayTra,
                    soTien = _datPhong.soTien,
                    soNguoiO = _datPhong.soNguoiO,
                    idUser = _datPhong.idUser,
                    status = _datPhong.status,
                    ghiChu = _datPhong.ghiChu,
                    create_date = DateTime.Now,
                    disable = false,
                    theoDoan = false
                };

                context.DatPhongs.InsertOnSubmit(datPhong);
                context.SubmitChanges();

                _datPhong.idDP = datPhong.idDP; 

                return _datPhong; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool updateDatPhong(DatPhongDTO datPhongDTO)
        {
            try
            {
                var datphong = context.DatPhongs.FirstOrDefault(dp => dp.idDP == datPhongDTO.idDP); 

                datphong.ngayDat = datPhongDTO.ngayDat;
                datphong.idKH = datPhongDTO.idKH;
                datphong.ngayTra = datPhongDTO.ngayTra;
                datphong.soTien = datPhongDTO.soTien;
                datphong.soNguoiO = datPhongDTO.soNguoiO;
                datphong.idUser = datPhongDTO.idUser;
                datphong.status = datPhongDTO.status;
                datphong.theoDoan = datPhongDTO.theoDoan;
                datphong.ghiChu = datPhongDTO.ghiChu;
                datphong.update_date = DateTime.Now;
                datphong.update_by = 1;

                context.SubmitChanges();

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
