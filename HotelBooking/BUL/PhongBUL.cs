﻿using DAL;
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
    }
}
