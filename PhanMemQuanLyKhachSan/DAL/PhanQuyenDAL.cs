using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class PhanQuyenDAL
    {
        QLKSDataContext context = new QLKSDataContext();

        public bool CapNhatQuyen(int idNND, int formId)
        {
            try
            {
                var quyen = context.Permissions.FirstOrDefault(p => p.userType == idNND && p.formID == formId);

                if(quyen != null)
                {
                    quyen.coQuyen = true;
                    context.SubmitChanges();
                    return true;
                }   
                else
                {
                    return false;
                }    
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool CoQuyen(int userTypeId, object tag)
        {
            try
            {
                if (tag == null)
                {
                    return false; 
                }

                string tagUrl = tag.ToString();

                var hasPermission = (from p in context.Permissions
                                   join pg in context.Forms on p.formID equals pg.formID
                                   where p.userType == userTypeId
                                         && pg.url == tagUrl
                                         && p.coQuyen == true
                                   select p).Any();


                return hasPermission;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false; 
            }
        }

        public List<PhanQuyenDTO> getDanhSachPhanQuyen(int idNND)
        {
            try
            {
                using (var context = new QLKSDataContext())
                {
                    var danhSachPhanQuyen = context.Forms
                        .Select(form => new PhanQuyenDTO
                        {
                            formId = form.formID,
                            formName = form.url,
                            coQuyen = context.Permissions.Any(p => p.formID == form.formID && p.userType == idNND)
                        })
                        .ToList();

                    return danhSachPhanQuyen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }



        public string GetTenNhomNguoiDung(int idNND)
        {
            try
            {
                var nnd = context.NhomNguoiDungs.FirstOrDefault(n => n.userType == idNND);

                if (nnd != null)
                {
                    return nnd.name;
                }
                return null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool KiemTraCoQuyenChua(int idNND, int formId)
        {
            try
            {
                using (var context = new QLKSDataContext())
                {
                    return context.Permissions.Any(p => p.userType == idNND && p.formID == formId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool KiemTraDuocCapQuyenChua(int idNND, int formId)
        {
            try
            {
                using (var context = new QLKSDataContext())
                {
                    return context.Permissions.Any(p => p.userType == idNND && p.formID == formId && p.coQuyen == true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool ThemMoiQuyen(int idNND, int formId)
        {
            try
            {
                using (var context = new QLKSDataContext())
                {
                    if (!context.Permissions.Any(p => p.userType == idNND && p.formID == formId))
                    {
                        var newPermission = new Permission
                        {
                            userType = idNND,
                            formID = formId,
                            coQuyen = true
                        };

                        context.Permissions.InsertOnSubmit(newPermission);
                        context.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Quyền đã tồn tại, không thể thêm mới!");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        public bool ThuHoiQuyen(int idNND, int formId)
        {
            try
            {
                using (var context = new QLKSDataContext())
                {
                    var permission = context.Permissions.FirstOrDefault(p => p.userType == idNND && p.formID == formId);
                    if (permission != null)
                    {
                        context.Permissions.DeleteOnSubmit(permission);
                        context.SubmitChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
