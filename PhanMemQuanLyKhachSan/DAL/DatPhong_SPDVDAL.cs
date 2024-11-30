using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class DatPhong_SPDVDAL
    {
        QLKSDataContext context = new QLKSDataContext();

        public bool addChiTietPhongSanPham(DatPhong_SPDTO phong)
        {
            try
            {
                var dpsp = new DatPhong_SP
                {
                    idDP = phong.idDP,
                    idSP = phong.idSP,
                    idPhong = phong.idPhong,
                    soLuong = phong.soLuong,
                    donGia = phong.donGia,
                    thanhTien = phong.thanhTien,
                    ngay = DateTime.Now,
                };

                context.DatPhong_SPs.InsertOnSubmit(dpsp);

                context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool checkIfProductExists(int idDP, int idSP, int idPhong)
        {
            try
            {
                var sanpham = context.DatPhong_SPs.Where(sp => sp.idSP == idSP &&  sp.idDP == idDP && sp.idPhong == idPhong).FirstOrDefault();

                if (sanpham != null)
                {
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

        public bool deleteAllSanPhamByRoom(int idDP, int idPhongToRemove)
        {
            try
            {
                var sanPhamList = context.DatPhong_SPs
                    .Where(ctsp => ctsp.idDP == idDP && ctsp.idPhong == idPhongToRemove)
                    .ToList(); 

                if (sanPhamList.Any())
                {
                    context.DatPhong_SPs.DeleteAllOnSubmit(sanPhamList);
                    context.SubmitChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public bool deleteSanPhamByRoom(int idDP, int idSanPham)
        {
            try
            {
                var sanpham = context.DatPhong_SPs.Where(ctsp => ctsp.idDP == idDP && ctsp.idSP == idSanPham).FirstOrDefault();

                context.DatPhong_SPs.DeleteOnSubmit(sanpham);

                context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false ;
            }
        }

        public DataTable getDanhSachSanPhamTheoPhong(int idPhong, int idDP)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã sản phẩm");
            table.Columns.Add("Tên sản phẩm");
            table.Columns.Add("Giá");
            table.Columns.Add("Số lượng");
            table.Columns.Add("Disable");

            try
            {
                var sanpham = from sp in context.SanPhams
                              join ctsp in context.DatPhong_SPs on sp.idSP equals ctsp.idSP
                              where ctsp.idDP == idDP && ctsp.idPhong == idPhong 
                              select new
                              {
                                  idSP = sp.idSP,
                                  tenSP = sp.tenSP,
                                  donGia = sp.donGia,
                                  soLuong = ctsp.soLuong,
                                  disable = (bool)sp.disable
                              };


                foreach (var item in sanpham)
                {
                    table.Rows.Add(item.idSP, item.tenSP, item.donGia, item.soLuong, item.disable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return table;
        }

        public bool IsSanPhamInPhieuDat(int idDP, int idSanPham)
        {
            return context.DatPhong_SPs
                      .Any(ct => ct.idDP == idDP && ct.idSP == idSanPham);
        }

        public bool updateChiTietPhongSanPham(DatPhong_SPDTO ctspDTO)
        {
            try
            {
                var ctsp = context.DatPhong_SPs.Where(sp => sp.idDP == ctspDTO.idDP && sp.idSP == ctspDTO.idSP && sp.idPhong == ctspDTO.idPhong).FirstOrDefault();

                ctsp.soLuong = ctspDTO.soLuong;
                ctsp.donGia = ctspDTO.donGia;
                ctsp.thanhTien = ctspDTO.thanhTien;
                ctsp.ngay = DateTime.Now;

                context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
