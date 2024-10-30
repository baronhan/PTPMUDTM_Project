using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class TangDAL
    {
        QLKSDataContext context = new QLKSDataContext();

        public List<TangDTO> getDanhSachTang()
        {
            try
            {
                List<TangDTO> tangList = context.Tangs
                .Select(tang => new TangDTO
                {
                    idTang = tang.idTang,
                    tenTang = tang.tenTang,
                    disable = (bool)tang.disable
                }).ToList();

                return tangList;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            } 
            
        }

        public bool addTang(TangDTO tangDTO)
        {
            try
            {
                var tang = new Tang
                {
                    tenTang = tangDTO.tenTang,
                    disable = tangDTO.disable
                };

                context.Tangs.InsertOnSubmit(tang);

                context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool updateTang(TangDTO tangDTO)
        {
            try
            {
                var existingTang = context.Tangs.FirstOrDefault(t => t.idTang == tangDTO.idTang);

                existingTang.tenTang = tangDTO.tenTang;
                existingTang.disable = tangDTO.disable;

                context.SubmitChanges();

                return true;
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool deleteTang(int idTang)
        {
            try
            {
                var tang = context.Tangs.FirstOrDefault(t => t.idTang == idTang);

                context.Tangs.DeleteOnSubmit(tang);

                context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool HasRoomsInTang(int idTang)
        {
            return context.Phongs.Any(p => p.idTang == idTang);
        }
    }
}
