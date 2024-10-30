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
    public class TangBLL
    {
        TangDAL dal = new TangDAL();
        public List<TangDTO> getDanhSachTang()
        {
            return dal.getDanhSachTang();
        }

        public bool addTang(TangDTO tangDTO)
        {
            if(tangDTO == null)
            {
                MessageBox.Show("Thông tin Tầng không được để trống!");
                return false;
            }    

            if(string.IsNullOrEmpty(tangDTO.tenTang))
            {
                MessageBox.Show("Tên tầng không được để trống!");
                return false;
            }    

            return dal.addTang(tangDTO);
        }

        public bool updateTang(TangDTO tangDTO)
        {
            if (tangDTO == null)
            {
                MessageBox.Show("Thông tin Tầng không được để trống!");
                return false;
            }

            if (string.IsNullOrEmpty(tangDTO.tenTang))
            {
                MessageBox.Show("Tên tầng không được để trống!");
                return false;
            }

            if(tangDTO.idTang <= 0)
            {
                MessageBox.Show("ID Tầng không hợp lệ!");
                return false;
            }    

            return dal.updateTang(tangDTO);
        }

        public bool deleteTang(int idTang)
        {
            if(idTang <= 0)
            {
                MessageBox.Show("ID Tầng không hợp lệ!");
                return false ;
            }    
            return dal.deleteTang(idTang);
        }
        public bool HasRoomsInTang(int idTang)
        {
            if(idTang <= 0)
            {
                MessageBox.Show("ID Tầng không hợp lệ!");
                return false ;
            }    
            return dal.HasRoomsInTang(idTang);
        }
    }
}
