using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace BLL
{
    public class DatPhongBLL
    {
        DatPhongDAL dal = new DatPhongDAL();
        public DatPhongDTO addDatPhong(DatPhongDTO _datPhong)
        {
            if (_datPhong == null)
            {
                MessageBox.Show("Thông tin Đặt phòng không được để trống!");
                return null;
            }

            if(_datPhong.idKH <= 0)
            {
                MessageBox.Show("ID Khách hàng không hợp lệ!");
                return null;
            }

            if (_datPhong.ngayDat < DateTime.Today)
            {
                MessageBox.Show("Ngày đặt phòng không được nhỏ hơn ngày hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (_datPhong.ngayDat >= _datPhong.ngayTra)
            {
                MessageBox.Show("Ngày trả phải lớn hơn ngày đặt ít nhất 1 ngày!");
                return null;
            }

            if (_datPhong.soTien <= 0)
            {
                MessageBox.Show("Số tiền không hợp lệ!");
                return null;
            }

            if(_datPhong.soNguoiO <= 0 || _datPhong.soNguoiO >= 5)
            {
                MessageBox.Show("Số người ở ít nhất 1 và tối đa 5!");
                return null;
            }    

            return dal.addDatPhong(_datPhong);
        }

        public List<DatPhongDTO> getDanhSachDatPhong()
        {
            return dal.getDanhSachDatPhong();
        }

        public bool updateDatPhong(DatPhongDTO datPhongDTO)
        {
            return dal.updateDatPhong(datPhongDTO);
        }
    }
}
