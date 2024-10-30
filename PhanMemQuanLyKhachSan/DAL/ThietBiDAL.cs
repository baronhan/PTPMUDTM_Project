using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class ThietBiDAL
    {
        QLKSDataContext context = new QLKSDataContext();

        public List<ThietBiDTO> getDanhSachThietBi()
        {
            try
            {
                List<ThietBiDTO> list = context.ThietBis
                    .Select(tb => new ThietBiDTO
                    {
                        idTB = tb.idTB,
                        tenTB = tb.tenTB,
                        donGia = (decimal)tb.donGia,
                        disable = (bool)tb.disable
                    }).ToList();
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool addThietBi(ThietBiDTO thietBiDTO)
        {
            try
            {
                var thietBi = new ThietBi
                {
                    tenTB = thietBiDTO.tenTB,
                    donGia = thietBiDTO.donGia,
                    disable = thietBiDTO.disable
                };

                context.ThietBis.InsertOnSubmit(thietBi);

                context.SubmitChanges();

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool updateThietBi(ThietBiDTO thietBiDTO)
        {
            try
            {
                var existingThietBi = context.ThietBis.Where(tb => tb.idTB == thietBiDTO.idTB).FirstOrDefault();

                existingThietBi.tenTB = thietBiDTO.tenTB;
                existingThietBi.donGia = thietBiDTO.donGia;
                existingThietBi.disable = thietBiDTO.disable;

                context.SubmitChanges();

                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false ;
            }
        }

        public bool deleteThietBi(int idTB)
        {
            try
            {
                var thietBi = context.ThietBis.Where(tb => tb.idTB == idTB).FirstOrDefault();

                context.ThietBis.DeleteOnSubmit(thietBi);

                context.SubmitChanges();

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
            
    }
}
