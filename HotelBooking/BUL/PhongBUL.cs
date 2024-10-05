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
    public class PhongBUL
    {
        PhongDAL dal = new PhongDAL();

        public bool checkRoomStatus(int idPhong)
        {
            return dal.checkRoomStatus(idPhong);
        }

        public DataTable selectedPhong()
        {
            return dal.selectedPhong();
        }

        public PhongDTO getRoomInfoById(int id)
        {
            return dal.getRoomInfoById(id);
        }

        public bool updateTrangThaiPhong(int roomId)
        {
            return dal.updateTrangThaiPhong(roomId);
        }
    }
}
