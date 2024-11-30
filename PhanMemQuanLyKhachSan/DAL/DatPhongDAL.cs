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
                            where dp.disable == false
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

        public string getTienThanhToan(int idDatPhong)
        {
            try
            {
                var datPhong = context.DatPhongs.FirstOrDefault(dp => dp.idDP == idDatPhong);

                if( datPhong != null)
                {
                    return datPhong.soTien.ToString();
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool UpdateThanhToan(int idDatPhong)
        {
            var datPhong = context.DatPhongs.FirstOrDefault(dp => dp.idDP == idDatPhong);

            if (datPhong != null)
            {
                datPhong.status = true;
                context.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<PhongDTO> LayDanhSachPhongByIdDP(int idDatPhong)
        {
            var danhSachPhong = from ct in context.DatPhong_CTs
                                join p in context.Phongs on ct.idPhong equals p.idPhong
                                where ct.idDP == idDatPhong
                                select new PhongDTO
                                {
                                    idPhong = p.idPhong,
                                    tenPhong = p.tenPhong,
                                };

            return danhSachPhong.ToList();
        }

        public bool CapNhatTrangThaiPhong(int idPhong)
        {
            try
            {
                var phong = context.Phongs.FirstOrDefault(p => p.idPhong == idPhong);

                if (phong != null)
                {
                    phong.trangThai = false; 
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

        public XuatExcel excel(int maPD)
        {
            try
            {
                using (var db = new QLKSDataContext())
                {
                    // Truy vấn thông tin cơ bản của phiếu đặt phòng
                    var phieuDat = (from pd in db.DatPhongs
                                    join nv in db.Users on pd.idUser equals nv.uid
                                    join kh in db.KhachHangs on pd.idKH equals kh.idKH
                                    where pd.idDP == maPD
                                    select new XuatExcel
                                    {
                                        TenKhach = kh.hoTen,
                                        SoNguoiO = (int)pd.soNguoiO,
                                        NgayDat = (DateTime)pd.ngayDat,
                                        NgayTra = (DateTime)pd.ngayTra,
                                        GhiChu = pd.ghiChu,
                                        TenNV = nv.fullName
                                    }).FirstOrDefault();

                    if (phieuDat == null)
                        throw new Exception("Không tìm thấy phiếu đặt phòng.");

                    phieuDat.DatPhongCT = (from ctp in db.DatPhong_CTs
                                           join p in db.Phongs on ctp.idPhong equals p.idPhong
                                           join t in db.Tangs on p.idTang equals t.idTang
                                           where ctp.idDP == maPD
                                           group ctp by new { p.idPhong, p.tenPhong, t.tenTang } into g
                                           select new XuatExcel.ChiTietPhieuDatPhongExcel
                                           {
                                               STT = 0,
                                               TENTANG = g.Key.tenTang,
                                               TENPHONG = g.Key.tenPhong,
                                               DONGIA = (double)g.Sum(x => x.donGia),
                                               TONGTIENPHONG = (double)g.Sum(x => x.thanhTien)
                                           }).ToList();


                    // Lấy danh sách chi tiết sản phẩm (dịch vụ) và tính tổng tiền
                    phieuDat.DatPhongCTSP = (from ctdv in db.DatPhong_SPs
                                             join sp in db.SanPhams on ctdv.idSP equals sp.idSP
                                             join dp in db.Phongs on ctdv.idPhong equals dp.idPhong
                                             where ctdv.idDP == maPD
                                             select new
                                             {
                                                 TENPHONG = dp.tenPhong,
                                                 TENSANPHAM = sp.tenSP,
                                                 SOLUONG = ctdv.soLuong,
                                                 DONGIA = ctdv.donGia,
                                                 THANHTIEN = ctdv.thanhTien
                                             }).ToList()
                         .Select(ctdv => new XuatExcel.ChiTietSanPhamExcel
                         {
                             STT = 0,
                             TENPHONG = ctdv.TENPHONG,
                             TENSANPHAM = ctdv.TENSANPHAM,
                             SOLUONG = ctdv.SOLUONG.ToString(),
                             DONGIA = (double)ctdv.DONGIA,
                             THANHTIEN = (double)ctdv.THANHTIEN,
                         }).ToList();


                    phieuDat.TongTien = phieuDat.DatPhongCT.Sum(x => x.TONGTIENPHONG)
                                        + phieuDat.DatPhongCTSP.Sum(x => x.THANHTIEN);

                    foreach (var item in phieuDat.DatPhongCT)
                    {
                        item.TONGTIENPHONG = item.DONGIA;
                    }
                    phieuDat.TongTien = phieuDat.DatPhongCT.Sum(x => x.TONGTIENPHONG);

                    foreach (var item in phieuDat.DatPhongCTSP)
                    {
                        item.TONGTIENSP = item.DONGIA;
                    }

                    phieuDat.TongTien = phieuDat.DatPhongCT.Sum(x => x.TONGTIENPHONG)
                    + phieuDat.DatPhongCTSP.Sum(x => x.THANHTIEN);



                    for (int i = 0; i < phieuDat.DatPhongCT.Count; i++)
                    {
                        phieuDat.DatPhongCT[i].STT = i + 1;
                    }

                    for (int i = 0; i < phieuDat.DatPhongCTSP.Count; i++)
                    {
                        phieuDat.DatPhongCTSP[i].STT = i + 1;
                    }



                    return phieuDat;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool VoHieuHoaPhieuDatPhong(int idDP)
        {
            try
            {
                var datphong = context.DatPhongs.FirstOrDefault(dp => dp.idDP == idDP);
                if (datphong != null)
                {
                    datphong.disable = true;
                    context.SubmitChanges();
                    return true;
                }

                return false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
