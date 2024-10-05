using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class NhomNguoiDungDAL
    {
        QL_KhachSanDataContext qlks = new QL_KhachSanDataContext();

        public List<NhomNguoiDungDTO> GetAllNhomNguoiDung()
        {
            var nhomList = qlks.Nhom_Nguoi_Dungs
                             .Select(nhom => new NhomNguoiDungDTO
                             {
                                 maNhomNguoiDung = nhom.maNhom,
                                 tenNhomNguoiDung = nhom.tenNhom,
                                 ghiChu = nhom.ghiChu
                             }).ToList();

            return nhomList;
        }
        public DataTable GetUserGroupsDataTable()
        {
            DataTable userGroupsTable = new DataTable();

            try
            {
                var groups = from gr in qlks.Nhom_Nguoi_Dungs
                             select gr;

                userGroupsTable.Columns.Add("GroupID", typeof(int));
                userGroupsTable.Columns.Add("GroupName", typeof(string));
                userGroupsTable.Columns.Add("Note", typeof(string));

                foreach (var group in groups)
                {
                    DataRow row = userGroupsTable.NewRow();
                    row["GroupID"] = group.maNhom;
                    row["GroupName"] = group.tenNhom;
                    row["Note"] = group.ghiChu;

                    userGroupsTable.Rows.Add(row);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return userGroupsTable;
        }

    }
}
