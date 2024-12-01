using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class NhomNguoiDungDAL
    {
        QLKSDataContext context = new QLKSDataContext();

        public bool addNhomNguoiDung(NhomNguoiDungDTO nnd)
        {
            try
            {
                var nhom = new NhomNguoiDung
                {
                    name = nnd.name
                };

                context.NhomNguoiDungs.InsertOnSubmit(nhom);

                context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool deleteNND(int idNND)
        {
            try
            {
                var nnd = context.NhomNguoiDungs.FirstOrDefault(n => n.userType == idNND);

                context.NhomNguoiDungs.DeleteOnSubmit(nnd);

                context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public List<NhomNguoiDungDTO> getDanhSachNhomNguoiDung()
        {
            try
            {
                List<NhomNguoiDungDTO> nhomnguoidung = context.NhomNguoiDungs
                .Select(nnd => new NhomNguoiDungDTO
                {
                    userType = nnd.userType,
                    name = nnd.name,
                }).ToList();

                return nhomnguoidung;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool HasUserInNhomNguoiDung(int idNND)
        {
            return context.Users.Any(u => u.userType == idNND);
        }

        public bool updateNND(NhomNguoiDungDTO nndDTO)
        {
            try
            {
                var existingNND = context.NhomNguoiDungs.FirstOrDefault(n => n.userType == nndDTO.userType);

                existingNND.name = nndDTO.name;

                context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
