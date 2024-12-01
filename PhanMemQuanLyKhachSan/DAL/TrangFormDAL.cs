using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class TrangFormDAL
    {
        QLKSDataContext context = new QLKSDataContext();

        public bool addTrangForm(TrangFormDTO form)
        {
            try
            {
                var _form = new Form
                {
                    url = form.url
                };

                context.Forms.InsertOnSubmit(_form);

                context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool deleteTrangForm(int idForm)
        {
            try
            {
                var form = context.Forms.FirstOrDefault(f => f.formID == idForm);

                context.Forms.DeleteOnSubmit(form);

                context.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public List<TrangFormDTO> getDanhSachTrangForm()
        {
            try
            {
                List<TrangFormDTO> form = context.Forms
                .Select(f => new TrangFormDTO
                {
                    formId = f.formID,
                    url = f.url,
                }).ToList();

                return form;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool HasFormInPermission(int idForm)
        {
            return context.Permissions.Any(p => p.formID == idForm);
        }

        public bool updateTrangForm(TrangFormDTO formDTO)
        {
            try
            {
                var existingForm = context.Forms.FirstOrDefault(f => f.formID == formDTO.formId);

                existingForm.url = formDTO.url;

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
