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
    public class DatPhong_CTBLL
    {
        DatPhong_CTDAL dal = new DatPhong_CTDAL();

        public bool addDatPhongChiTiet(DatPhong_CTDTO datPhongChiTiet)
        {
            if(datPhongChiTiet == null)
            {
                MessageBox.Show("Thông tin Đặt phòng chi tiết không được để trống!");
                return false;
            }    

            if(datPhongChiTiet.idDP <= 0)
            {
                MessageBox.Show("ID Đặt phòng không hợp lệ!");
                return false;
            }

            if (datPhongChiTiet.idPhong <= 0)
            {
                MessageBox.Show("ID Phòng không hợp lệ!");
                return false ;
            }

            if (datPhongChiTiet.soNgayO <= 0)
            {
                MessageBox.Show("Số ngày ở tối thiểu là 1!");
                return false;
            }

            if (datPhongChiTiet.donGia <= 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return false;
            }

            if(datPhongChiTiet.thanhTien <= 0)
            {
                MessageBox.Show("Thành tiền không hợp lệ!");
                return false;
            }    

            return dal.addDatPhongChiTiet(datPhongChiTiet);
        }

        public bool deleteDatPhongChiTiet(int idDP, int idPhongToRemove)
        {
            if(idDP <= 0)
            {
                MessageBox.Show("ID Đặt phòng không hợp lệ!");
                return false;
            }    
            if(idPhongToRemove <= 0)
            {
                MessageBox.Show("ID Phòng không hợp lệ!");
                return false;
            }    

            return dal.deleteDatPhongChiTiet(idDP, idPhongToRemove);
        }

        public List<int> getExistingRoomIds(int idDP)
        {
            if(idDP <= 0)
            {
                MessageBox.Show("ID Đặt phòng không hợp lệ!");
            }

            return dal.getExistingRoomIds(idDP);
        }

        public DataTable getPhongDetailsByBookingId(int idDP)
        {
            if(idDP <= 0)
            {
                MessageBox.Show("ID Đặt phòng không hợp lệ!");
                return null;
            }    
            return dal.getPhongDetailsByBookingId(idDP);
        }

        public bool updateDatPhongChiTiet(DatPhong_CTDTO dpctDTO)
        {
            if (dpctDTO == null)
            {
                MessageBox.Show("Thông tin Đặt phòng chi tiết không được để trống!");
                return false;
            }

            if (dpctDTO.idDP <= 0)
            {
                MessageBox.Show("ID Đặt phòng không hợp lệ!");
                return false;
            }

            if (dpctDTO.idPhong <= 0)
            {
                MessageBox.Show("ID Phòng không hợp lệ!");
                return false;
            }

            if (dpctDTO.soNgayO <= 0)
            {
                MessageBox.Show("Số ngày ở tối thiểu là 1!");
                return false;
            }

            if (dpctDTO.donGia <= 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return false;
            }

            if (dpctDTO.thanhTien <= 0)
            {
                MessageBox.Show("Thành tiền không hợp lệ!");
                return false;
            }

            return dal.updateDatPhongChiTiet(dpctDTO);
        }
    }
}
