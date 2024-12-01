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
    public class NhomNguoiDungBLL
    {
        NhomNguoiDungDAL dal = new NhomNguoiDungDAL();

        public bool addNhomNguoiDung(NhomNguoiDungDTO nnd)
        {
            if(nnd == null)
            {
                MessageBox.Show("Thông tin nhóm người dùng không được để trống!");
                return false;
            }

            return dal.addNhomNguoiDung(nnd);
        }

        public bool deleteNND(int idNND)
        {
            if (idNND <= 0)
            {
                MessageBox.Show("Mã nhóm người dùng không hợp lệ!");
                return false;
            }
            return dal.deleteNND(idNND);
        }

        public List<NhomNguoiDungDTO> getDanhSachNhomNguoiDung()
        {
            return dal.getDanhSachNhomNguoiDung();
        }

        public bool HasUserInNhomNguoiDung(int idNND)
        {
            if(idNND <= 0)
            {
                MessageBox.Show("Mã nhóm người dùng không hợp lệ!");
                return false;
            }    
            return dal.HasUserInNhomNguoiDung(idNND);
        }

        public bool updateNND(NhomNguoiDungDTO nndDTO)
        {
            if (nndDTO == null)
            {
                MessageBox.Show("Thông tin nhóm người dùng không được để trống!");
                return false;
            }

            return dal.updateNND(nndDTO);
        }
    }
}
