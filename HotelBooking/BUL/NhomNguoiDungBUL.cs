using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class NhomNguoiDungBUL
    {
        private NhomNguoiDungDAL nhomNguoiDungDAL;

        public NhomNguoiDungBUL()
        {
            nhomNguoiDungDAL = new NhomNguoiDungDAL();
        }
        public List<NhomNguoiDungDTO> GetAllNhomNguoiDung()
        {
            return nhomNguoiDungDAL.GetAllNhomNguoiDung();
        }
        public DataTable GetUserGroupsDataTable()
        {
            return nhomNguoiDungDAL.GetUserGroupsDataTable();
        }

    }
}
