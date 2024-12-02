using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class SanPhamDAL
    {
        QLKSDataContext context = new QLKSDataContext();

        public bool addSanPham(SanPhamDTO sanPhamDTO)
        {
            try
            {
                var sanPham = new SanPham
                {
                    tenSP = sanPhamDTO.tenSP,
                    donGia = sanPhamDTO.donGia,
                    disable = sanPhamDTO.disable
                };

                context.SanPhams.InsertOnSubmit(sanPham);

                context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            } 
            
        }

        public bool deleteSanPham(int idSP)
        {
            try
            {
                var sanPham = context.SanPhams.Where(sp => sp.idSP == idSP).FirstOrDefault();

                context.SanPhams.DeleteOnSubmit(sanPham);

                context.SubmitChanges();

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public List<SanPhamDTO> getDanhSachSanPham()
        {
            try
            {
                List<SanPhamDTO> list = context.SanPhams
                    .Select(s => new SanPhamDTO
                    {
                        idSP = s.idSP,
                        tenSP = s.tenSP,
                        donGia = (decimal)s.donGia,
                        disable = (bool)s.disable
                    }).ToList();

                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public List<SanPhamDTO> getDanhSachSanPhamByIDDPs(List<int> idDPs)
        {
            var sanPhamList = (from dpctsp in context.DatPhong_SPs
                               join sp in context.SanPhams on dpctsp.idSP equals sp.idSP
                               where idDPs.Contains((int)dpctsp.idDP)
                               select new SanPhamDTO
                               {
                                   idSP = sp.idSP,
                                   tenSP = sp.tenSP,
                                   donGia = (decimal)sp.donGia,
                                   disable = (bool)sp.disable
                               }).Distinct().ToList();
            return sanPhamList;
        }


        public DataTable getDanhSachSanPham_DataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã sản phẩm");
            table.Columns.Add("Tên sản phẩm");
            table.Columns.Add("Giá");
            table.Columns.Add("Disable");

            try
            {
                var sanpham = from sp in context.SanPhams
                              select new
                              {
                                  idSP = sp.idSP,
                                  tenSP = sp.tenSP,
                                  donGia = sp.donGia,
                                  disable = (bool)sp.disable
                              };

                foreach(var item in  sanpham)
                {
                    table.Rows.Add(item.idSP, item.tenSP, item.donGia, item.disable);
                }    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message );
            }

            return table;
        }

        public bool updateSanPham(SanPhamDTO sanPhamDTO)
        {
            try
            {
                var existingSanPham = context.SanPhams.Where(sp => sp.idSP == sanPhamDTO.idSP).FirstOrDefault();
                existingSanPham.tenSP = sanPhamDTO.tenSP;
                existingSanPham.donGia = sanPhamDTO.donGia;
                existingSanPham.disable = sanPhamDTO.disable;

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
