using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class DatPhong_SPBLL
    {
        DatPhong_SPDVDAL dal = new DatPhong_SPDVDAL();
        public bool addChiTietPhongSanPham(DatPhong_SPDTO phong)
        {
            if (phong == null)
            {
                MessageBox.Show("Thông tin Chi tiết dịch vụ không được để trống!");
                return false;
            }

            if (phong.idDP <= 0)
            {
                MessageBox.Show("ID Đặt phòng không hợp lệ!");
                return false;
            }

            if (phong.idSP <= 0)
            {
                MessageBox.Show("ID Sản phẩm không hợp lệ!");
                return false;
            }

            if(phong.soLuong <= 0)
            {
                MessageBox.Show("Số lượng tổi thiểu là 1!");
                return false;
            }    
            if(phong.donGia <= 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return false;
            }    
            if(phong.thanhTien <=  0)
            {
                MessageBox.Show("Thành tiền không hợp lệ!");
                return false ;
            }    

            return dal.addChiTietPhongSanPham(phong);
        }

        public bool checkIfProductExists(int idDP, int idSP, int idPhong)
        {
            if (idDP <= 0)
            {
                MessageBox.Show("ID Đặt phòng không hợp lệ!");
                return false;
            }    
            if (idSP <= 0)
            {
                MessageBox.Show("ID Sản phẩm không hợp lệ!");
                return false;
            }    

            return dal.checkIfProductExists(idDP, idSP, idPhong);
        }

        public bool deleteAllSanPhamByRoom(int idDP, int idPhongToRemove)
        {
            if (idDP <= 0)
            {
                MessageBox.Show("ID Đặt phòng không hợp lệ!");
                return false;
            }

            if (idPhongToRemove <= 0)
            {
                MessageBox.Show("ID Phòng không hợp lệ!");
                return false;
            }

            return dal.deleteAllSanPhamByRoom(idDP, idPhongToRemove);
        }

        public bool deleteSanPhamByRoom(int idDP, int idSanPham)
        {
            if (idDP <= 0)
            {
                MessageBox.Show("ID Đặt phòng không hợp lệ!");
                return false;
            }    

            if(idSanPham <= 0)
            {
                MessageBox.Show("ID Sản phẩm không hợp lệ!");
                return false;
            }    

            return dal.deleteSanPhamByRoom(idDP, idSanPham);
        }

        public DataTable getDanhSachSanPhamTheoPhong(int idPhong, int idDP)
        {
            if(idPhong <= 0)
            {
                MessageBox.Show("ID Phòng không hợp lệ!");
                return null;
            }    
            if (idDP <= 0)
            {
                MessageBox.Show("ID Đặt phòng không hợp lệ!");
                return null;
            }    

            return dal.getDanhSachSanPhamTheoPhong(idPhong, idDP);
        }

        public bool updateChiTietPhongSanPham(DatPhong_SPDTO ctspDTO)
        {
            if (ctspDTO == null)
            {
                MessageBox.Show("Thông tin Chi tiết dịch vụ không được để trống!");
                return false;
            }

            if (ctspDTO.idDP <= 0)
            {
                MessageBox.Show("ID Đặt phòng không hợp lệ!");
                return false;
            }

            if (ctspDTO.idSP <= 0)
            {
                MessageBox.Show("ID Sản phẩm không hợp lệ!");
                return false;
            }

            if (ctspDTO.soLuong <= 0)
            {
                MessageBox.Show("Số lượng tổi thiểu là 1!");
                return false;
            }
            if (ctspDTO.donGia <= 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return false;
            }
            if (ctspDTO.thanhTien <= 0)
            {
                MessageBox.Show("Thành tiền không hợp lệ!");
                return false;
            }

            return dal.updateChiTietPhongSanPham(ctspDTO);
        }
    }
}
