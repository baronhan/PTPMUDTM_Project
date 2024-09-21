using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class Hinh_Anh_PhongBUL
    {
        Hinh_Anh_PhongDAL dal = new Hinh_Anh_PhongDAL();

        public List<Hinh_Anh_PhongDTO> getImageListByRoomID(int roomID)
        {
            return dal.getImageListByRoomID(roomID);
        }
    }
}
