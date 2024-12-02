using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class PhongBLL
    {
        PhongDAL dal = new PhongDAL();

        public bool addPhong(PhongDTO phongDTO)
        {
            if (phongDTO == null)
            {
                MessageBox.Show("Thông tin loại phòng không được để trống!");
                return false;
            }

            if (string.IsNullOrEmpty(phongDTO.tenPhong))
            {
                MessageBox.Show("Tên loại phòng không được để trống!");
                return false;
            }

            if (phongDTO.idTang <= 0)
            {
                MessageBox.Show("ID Tầng phải lớn hơn 0.");
                return false;
            }

            if (phongDTO.idLoaiPhong <= 0)
            {
                MessageBox.Show("ID Loại phòng phải lớn hơn 0.");
                return false;
            }

            return dal.addPhong(phongDTO);
        }

        public bool deletePhong(int idPhong)
        {
            if(idPhong <= 0)
            {
                MessageBox.Show("ID Phòng phải lớn hơn 0!");
                return false;
            }    

            return dal.deletePhong(idPhong);
        }

        public List<PhongDTO> getDanhSachPhong()
        {
            return dal.getDanhSachPhong();
        }

        public List<PhongDTO> getDSPhongByTang(int tang)
        {

            if(tang == null)
            {
                throw new ArgumentNullException("Tầng không được để trống!");
            }    

            if(tang <= 0)
            {
                throw new ArgumentException("Tầng phải lớn hơn 0!");
            }    

            return dal.getDSPhongByTang(tang);
        }

        public bool updatePhong(PhongDTO phongDTO)
        {
            if (phongDTO == null)
            {
                MessageBox.Show("Thông tin loại phòng không được để trống!");
                return false;
            }

            if(phongDTO.idPhong <= 0)
            {
                MessageBox.Show("ID Phòng phải lớn hơn 0!");
                return false;
            }    

            if (string.IsNullOrEmpty(phongDTO.tenPhong))
            {
                MessageBox.Show("Tên loại phòng không được để trống!");
                return false;
            }

            if (phongDTO.idTang <= 0)
            {
                MessageBox.Show("ID Tầng phải lớn hơn 0.");
                return false;
            }

            if (phongDTO.idLoaiPhong <= 0)
            {
                MessageBox.Show("ID Loại phòng phải lớn hơn 0.");
                return false;
            }

            return dal.updatePhong(phongDTO);
        }

        public DataTable getDanhSachPhongConTrong()
        {
            return dal.getDanhSachPhongConTrong();
        }

        public bool updateTrangThaiPhong(int idPhong, bool trangThai)
        {
            if(idPhong <= 0)
            {
                MessageBox.Show("ID Phòng không hợp lệ!");
                return false;
            }    

            return dal.updateTrangThaiPhong(idPhong, trangThai);
        }

        public List<PhongGreedyDTO> LayDanhSachPhongConTrong()
        {
            return dal.LayDanhSachPhongConTrong();
        }

        public bool KiemTraTrangThaiPhong(int idPhong)
        {
            return dal.KiemTraTrangThaiPhong(idPhong);
        }

        public List<PhongDTO> getDanhSachPhongByIDDPs(List<int> idDPs)
        {
            return dal.getDanhSachPhongByIDDPs(idDPs);
        }
    }
}
