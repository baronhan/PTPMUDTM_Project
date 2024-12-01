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
    public class TrangFormBLL
    {
        TrangFormDAL dal = new TrangFormDAL();

        public bool addTrangForm(TrangFormDTO form)
        {
            if(form == null)
            {
                MessageBox.Show("Thông tin trang form không được để trống!");
                return false;
            }    
            return dal.addTrangForm(form);
        }

        public bool deleteTrangForm(int idForm)
        {
            if (idForm <= 0)
            {
                MessageBox.Show("Mã Trang Form không hợp lệ!");
                return false;
            }
            return dal.deleteTrangForm(idForm);
        }

        public List<TrangFormDTO> getDanhSachTrangForm()
        {
            return dal.getDanhSachTrangForm();
        }

        public bool HasFormInPermission(int idForm)
        {
            if(idForm <= 0)
            {
                MessageBox.Show("Mã Trang Form không hợp lệ!");
                return false;
            }    
            return dal.HasFormInPermission(idForm);
        }

        public bool updateTrangForm(TrangFormDTO formDTO)
        {
            if (formDTO == null)
            {
                MessageBox.Show("Thông tin trang form không được để trống!");
                return false;
            }
            return dal.updateTrangForm(formDTO);
        }
    }
}
