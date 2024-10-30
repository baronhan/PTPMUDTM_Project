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
    public class ThietBiBLL
    {
        ThietBiDAL dal = new ThietBiDAL();

        public List<ThietBiDTO> getDanhSachThietBi()
        {
            return dal.getDanhSachThietBi();
        }

        public bool addThietBi(ThietBiDTO thietBiDTO)
        {
            if (thietBiDTO == null)
            {
                MessageBox.Show("Thông tin thiết bị không được để trống!");
                return false;
            }

            if (string.IsNullOrEmpty(thietBiDTO.tenTB))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!");
                return false;
            }

            if (thietBiDTO.donGia < 0 || thietBiDTO.donGia > 20000000)
            {
                MessageBox.Show("Đơn giá phải nằm trong khoảng từ 0 đến 20,000,000!");
            }

            return dal.addThietBi(thietBiDTO);
        }

        public bool updateThietBi(ThietBiDTO thietBiDTO)
        {
            if (thietBiDTO == null)
            {
                MessageBox.Show("Thông tin thiết bị không được để trống!");
                return false;
            }

            if (string.IsNullOrEmpty(thietBiDTO.tenTB))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!");
                return false;
            }

            if (thietBiDTO.donGia < 0 || thietBiDTO.donGia > 20000000)
            {
                MessageBox.Show("Đơn giá phải nằm trong khoảng từ 0 đến 20,000,000!");
            }    

            return dal.updateThietBi(thietBiDTO);
        }

        public bool deleteThietBi(int idTB)
        {
            if(idTB <= 0)
            {
                MessageBox.Show("ID Thiết bị phải lớn hơn 0!");
                return false;
            }    
            return dal.deleteThietBi(idTB);
        }
    }
}
