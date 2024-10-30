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
    public class ThietBiTrongPhongBLL
    {
        ThietBiTrongPhongDAL dal = new ThietBiTrongPhongDAL();

        public List<ThietBiTrongPhongDTO> getDanhSachThietBiPhong()
        {
            return dal.getDanhSachThietBiPhong();
        }

        public bool addThietBiPhong(ThietBiTrongPhongDTO thietBiTrongPhongDTO)
        {
            if(thietBiTrongPhongDTO == null)
            {
                MessageBox.Show("Thông tin thiết bị trong phòng không được để trống!");
                return false;
            }    

            if(thietBiTrongPhongDTO.idTB <= 0)
            {
                MessageBox.Show("ID Thiết bị phải lớn hơn 0!");
                return false;
            }

            if (thietBiTrongPhongDTO.idTB <= 0)
            {
                MessageBox.Show("ID Phòng phải lớn hơn 0!");
                return false;
            }

            if (thietBiTrongPhongDTO.soLuong <= 0)
            {
                MessageBox.Show("Số lượng thiết bị phải lớn hơn 0!");
                return false;
            }

            return dal.addThietBiPhong(thietBiTrongPhongDTO);
        }

        public bool updateThietBiPhong(ThietBiTrongPhongDTO thietBiTrongPhongDTO)
        {
            if (thietBiTrongPhongDTO == null)
            {
                MessageBox.Show("Thông tin thiết bị trong phòng không được để trống!");
                return false;
            }

            if (thietBiTrongPhongDTO.idTB <= 0)
            {
                MessageBox.Show("ID Thiết bị phải lớn hơn 0!");
                return false;
            }

            if (thietBiTrongPhongDTO.idTB <= 0)
            {
                MessageBox.Show("ID Phòng phải lớn hơn 0!");
                return false;
            }

            if (thietBiTrongPhongDTO.soLuong <= 0)
            {
                MessageBox.Show("Số lượng thiết bị phải lớn hơn 0!");
                return false;
            }

            return dal.updateThietBiPhong(thietBiTrongPhongDTO);
        }

        public bool deleteThietBiPhong(ThietBiTrongPhongDTO thietBiTrongPhongDTO)
        {
            if (thietBiTrongPhongDTO == null)
            {
                MessageBox.Show("Thông tin thiết bị trong phòng không được để trống!");
                return false;
            }

            if (thietBiTrongPhongDTO.idTB <= 0)
            {
                MessageBox.Show("ID Thiết bị phải lớn hơn 0!");
                return false;
            }

            if (thietBiTrongPhongDTO.idTB <= 0)
            {
                MessageBox.Show("ID Phòng phải lớn hơn 0!");
                return false;
            }

            return dal.deleteThietBiPhong(thietBiTrongPhongDTO);
        }
    }
}
