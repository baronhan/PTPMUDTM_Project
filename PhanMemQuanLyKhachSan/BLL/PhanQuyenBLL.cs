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
    public class PhanQuyenBLL
    {
        PhanQuyenDAL dal = new PhanQuyenDAL();

        public bool CapNhatQuyen(int idNND, int formId)
        {
            if (idNND <= 0)
            {
                MessageBox.Show("Mã nhóm người dùng không hợp lệ!");
                return false;
            }
            if (formId <= 0)
            {
                MessageBox.Show("Mã trang không hợp lệ!");
                return false;
            }

            return dal.CapNhatQuyen(idNND, formId);
        }

        public bool CoQuyen(int userTypeId, object tag)
        {
            if(userTypeId <= 0)
            {
                MessageBox.Show("Mã nhóm người dùng không hợp lệ!");
                return false;
            }
            if (tag == null)
            {
                MessageBox.Show("Tag không hợp lệ!");
                return false;
            }

            return dal.CoQuyen(userTypeId, tag);
        }

        public List<PhanQuyenDTO> getDanhSachPhanQuyen(int idNND)
        {
            return dal.getDanhSachPhanQuyen(idNND);
        }

        public string GetTenNhomNguoiDung(int idNND)
        {
            if (idNND <= 0)
            {
                MessageBox.Show("Mã nhóm người dùng không hợp lệ!");
                return null;
            }
            return dal.GetTenNhomNguoiDung(idNND);
        }

        public bool KiemTraCoQuyenChua(int idNND, int formId)
        {
            if (idNND <= 0)
            {
                MessageBox.Show("Mã nhóm người dùng không hợp lệ!");
                return false;
            }
            if(formId <= 0)
            {
                MessageBox.Show("Mã trang không hợp lệ!");
                return false;
            }

            return dal.KiemTraCoQuyenChua(idNND, formId);
        }

        public bool KiemTraDuocCapQuyenChua(int idNND, int formId)
        {
            if (idNND <= 0)
            {
                MessageBox.Show("Mã nhóm người dùng không hợp lệ!");
                return false;
            }
            if (formId <= 0)
            {
                MessageBox.Show("Mã trang không hợp lệ!");
                return false;
            }

            return dal.KiemTraDuocCapQuyenChua(idNND, formId);
        }

        public bool ThemMoiQuyen(int idNND, int formId)
        {
            if (idNND <= 0)
            {
                MessageBox.Show("Mã nhóm người dùng không hợp lệ!");
                return false;
            }
            if (formId <= 0)
            {
                MessageBox.Show("Mã trang không hợp lệ!");
                return false;
            }

            return dal.ThemMoiQuyen(idNND, formId);
        }

        public bool ThuHoiQuyen(int idNND, int formId)
        {
            if (idNND <= 0)
            {
                MessageBox.Show("Mã nhóm người dùng không hợp lệ!");
                return false;
            }
            if (formId <= 0)
            {
                MessageBox.Show("Mã trang không hợp lệ!");
                return false;
            }

            return dal.ThuHoiQuyen(idNND, formId);
        }
    }
}
