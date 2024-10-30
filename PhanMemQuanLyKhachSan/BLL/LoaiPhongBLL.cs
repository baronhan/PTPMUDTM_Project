using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class LoaiPhongBLL
    {
        LoaiPhongDAL dal = new LoaiPhongDAL();

        public List<LoaiPhongDTO> getDanhSachLoaiPhong()
        {
            return dal.getDanhSachLoaiPhong();
        }

        public bool addLoaiPhong(LoaiPhongDTO loaiPhong)
        {
            if(loaiPhong == null)
            {
                MessageBox.Show("Thông tin loại phòng không được để trống!");
                return false;
            }    

            if(string.IsNullOrEmpty(loaiPhong.tenLoaiPhong))
            {
                MessageBox.Show("Tên loại phòng không được để trống!");
                return false;
            }    

            if(loaiPhong.soNguoi <= 0)
            {
                MessageBox.Show("Số người phải lớn hơn 0!");
                return false;
            }    

            if(loaiPhong.soGiuong <= 0)
            {
                MessageBox.Show("Số giường phải lớn hơn 0");
                return false;
            }    
            
            if(loaiPhong.donGia < 1000000 || loaiPhong.donGia > 10000000)
            {
                MessageBox.Show("Đơn giá phải nằm trong khoảng từ 1,000,000 đến 10,000,000!");
                return false;
            }    

            return dal.addLoaiPhong(loaiPhong);
        }

        public bool updateLoaiPhong(LoaiPhongDTO loaiPhong)
        {
            if (loaiPhong == null)
            {
                MessageBox.Show("Thông tin loại phòng không được để trống!");
                return false;
            }

            if (string.IsNullOrEmpty(loaiPhong.tenLoaiPhong))
            {
                MessageBox.Show("Tên loại phòng không được để trống!");
                return false;
            }

            if (loaiPhong.soNguoi <= 0)
            {
                MessageBox.Show("Số người phải lớn hơn 0!");
                return false;
            }

            if (loaiPhong.soGiuong <= 0)
            {
                MessageBox.Show("Số giường phải lớn hơn 0");
                return false;
            }

            if (loaiPhong.donGia < 1000000 || loaiPhong.donGia > 10000000)
            {
                MessageBox.Show("Đơn giá phải nằm trong khoảng từ 1,000,000 đến 10,000,000!");
                return false;
            }

            return dal.updateLoaiPhong(loaiPhong);
        }

        public bool deleteLoaiPhong(int idLoaiPhong)
        {
            if(idLoaiPhong <= 0)
            {
                MessageBox.Show("Mã loại phòng không được để trống hoặc phải là số dương!");
                return false;
            }    

            return dal.deleteLoaiPhong(idLoaiPhong);
        }
    }
}
