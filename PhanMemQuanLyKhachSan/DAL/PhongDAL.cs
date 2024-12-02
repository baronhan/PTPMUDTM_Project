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
    public class PhongDAL
    {
        QLKSDataContext context = new QLKSDataContext();

        public bool addPhong(PhongDTO phongDTO)
        {
            try
            {
                var phong = new Phong
                {
                    tenPhong = phongDTO.tenPhong,
                    idTang = phongDTO.idTang,
                    idLoaiPhong = phongDTO.idLoaiPhong,
                    trangThai = phongDTO.trangThai,
                    disable = phongDTO.disable
                };

                context.Phongs.InsertOnSubmit(phong);

                context.SubmitChanges();

                return true;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool deletePhong(int idPhong)
        {
            try
            {
                var phong = context.Phongs.Where(p => p.idPhong == idPhong).FirstOrDefault();

                context.Phongs.DeleteOnSubmit(phong);

                context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public List<PhongDTO> getDanhSachPhong()
        {
            List<PhongDTO> phongList = context.Phongs
                .Select(phong => new PhongDTO
                {
                   idPhong = phong.idPhong,
                   tenPhong = phong.tenPhong,
                   trangThai = (bool)phong.trangThai,
                   idTang = (int)phong.idTang,
                   idLoaiPhong = (int)phong.idLoaiPhong,
                   disable = (bool)phong.disable
                }).ToList();

            return phongList;
        }

        public List<PhongDTO> getDSPhongByTang(int tang)
        {
            List<PhongDTO> phongList = context.Phongs.Where(p => p.idTang == tang)
                .Select(phong => new PhongDTO
                {
                    idPhong = phong.idPhong,
                    tenPhong = phong.tenPhong,
                    trangThai = (bool)phong.trangThai,
                    idTang = (int)phong.idTang,
                    idLoaiPhong = (int)phong.idLoaiPhong,
                    disable = (bool)phong.disable
                }).ToList();

            return phongList;
        }

        public bool updatePhong(PhongDTO phongDTO)
        {
            try
            {
                var existingPhong = context.Phongs.Where(p => p.idPhong == phongDTO.idPhong).FirstOrDefault();

                existingPhong.tenPhong = phongDTO.tenPhong;
                existingPhong.idLoaiPhong = phongDTO.idLoaiPhong;
                existingPhong.idTang = phongDTO.idTang;
                existingPhong.trangThai = phongDTO.trangThai;
                existingPhong.disable = (bool)phongDTO.disable;

                context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public DataTable getDanhSachPhongConTrong()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Mã tầng", typeof(int));
            table.Columns.Add("Mã phòng", typeof(int));
            table.Columns.Add("Tên tầng", typeof(string));
            table.Columns.Add("Tên phòng", typeof(string));
            table.Columns.Add("Đơn giá", typeof(decimal));

            try
            {
                var availableRoom = from p in context.Phongs
                                    join t in context.Tangs on p.idTang equals t.idTang
                                    join lp in context.LoaiPhongs on p.idLoaiPhong equals lp.idLoaiPhong
                                    where p.trangThai == false
                                    select new
                                    {
                                        idTang = t.idTang,
                                        idPhong = (int)p.idPhong,
                                        tenTang = t.tenTang,
                                        tenPhong = p.tenPhong,
                                        donGia = (decimal)lp.donGia,
                                    };

                foreach (var item in availableRoom)
                {
                    table.Rows.Add(item.idTang, item.idPhong, item.tenTang, item.tenPhong, item.donGia);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return table;
        }

        public bool updateTrangThaiPhong(int idPhong, bool trangThai)
        {
            try
            {
                var phong = context.Phongs.FirstOrDefault(t => t.idPhong == idPhong);
                phong.trangThai = trangThai;

                context.SubmitChanges();

                return true;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public List<PhongGreedyDTO> LayDanhSachPhongConTrong()
        {
            try
            {
                using (QLKSDataContext context = new QLKSDataContext())
                {
                    var danhSachPhongConTrong = context.Phongs
                        .Where(p => p.trangThai == false)
                        .Join(context.LoaiPhongs,
                              phong => phong.idLoaiPhong,
                              loaiPhong => loaiPhong.idLoaiPhong,
                              (phong, loaiPhong) => new PhongGreedyDTO
                              {
                                  Id = phong.idPhong,
                                  TenPhong = phong.tenPhong,
                                  SoKhachToiDa = (int)loaiPhong.soNguoi,
                                  GiaTien = (double)loaiPhong.donGia
                              })
                        .ToList();

                    return danhSachPhongConTrong;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool KiemTraTrangThaiPhong(int idPhong)
        {
            try
            {
                var phong = context.Phongs.FirstOrDefault(p => p.idPhong == idPhong);

                if (phong != null && phong.trangThai == false) 
                {
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

        public List<PhongDTO> getDanhSachPhongByIDDPs(List<int> idDPs)
        {
            var phongList = (from dpct in context.DatPhong_CTs
                             join phong in context.Phongs on dpct.idPhong equals phong.idPhong
                             join tang in context.Tangs on phong.idTang equals tang.idTang
                             join loaiPhong in context.LoaiPhongs on phong.idLoaiPhong equals loaiPhong.idLoaiPhong
                             where idDPs.Contains((int)dpct.idDP)
                             select new PhongDTO
                             {
                                 idPhong = phong.idPhong,
                                 tenPhong = phong.tenPhong,
                                 trangThai = (bool)phong.trangThai,
                                 idTang = (int)phong.idTang,
                                 tenTang = tang.tenTang, // Lấy tên tầng
                                 idLoaiPhong = (int)phong.idLoaiPhong,
                                 tenLoaiPhong = loaiPhong.tenLoaiPhong, // Lấy tên loại phòng
                                 disable = (bool)phong.disable
                             }).Distinct().ToList();

            return phongList;
        }

    }
}
