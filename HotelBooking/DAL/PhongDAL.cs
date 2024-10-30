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
    public class PhongDAL
    {
        QL_KhachSanDataContext qlks = new QL_KhachSanDataContext();

        public bool checkRoomStatus(int idPhong)
        {
            try
            {
                Phong phong = qlks.Phongs.Where(t => t.maPhong == idPhong).FirstOrDefault();

                if (phong != null && phong.trangThai == 1)
                {
                    return true;
                }    
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return false;
        }

        public PhongDTO getRoomInfoById(int id)
        {
            try
            {
                Phong phong = qlks.Phongs.Where(t => t.maLoaiPhong == id).FirstOrDefault();

                if(phong != null)
                {
                    PhongDTO phongDTO = new PhongDTO
                    {
                        maPhong = phong.maPhong,
                        tenPhong = phong.tenPhong,
                        donGia = (decimal)phong.donGia
                    };

                    return phongDTO;
                }    
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message); 
            }

            return null;
        }

        public DataTable selectedPhong()
        {
            DataTable roomList = new DataTable();
            try
            {
                var tblPhong = from phong in qlks.Phongs
                               select phong;

                roomList.Columns.Add("ID",  typeof(int));
                roomList.Columns.Add("RoomName", typeof(string));
                roomList.Columns.Add("NoP", typeof(int));
                roomList.Columns.Add("Price", typeof(decimal));
                roomList.Columns.Add("Description", typeof(string));
                roomList.Columns.Add("Status", typeof(int));


                foreach(var item in tblPhong)
                {
                    DataRow row = roomList.NewRow();
                    row["ID"] = item.maPhong;
                    row["RoomName"] = item.tenPhong;
                    row["NoP"] = item.soLuongNguoi;
                    row["Price"] = item.donGia;
                    row["Description"] = item.moTa;
                    row["Status"] = item.trangThai;

                    roomList.Rows.Add(row);
                }    


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return roomList;
        }

        public bool updateTrangThaiPhong(int roomId)
        {
            try
            {
                var room = qlks.Phongs.SingleOrDefault(p => p.maPhong == roomId);

                if (room != null)
                {
                    room.trangThai = 0;

                    qlks.SubmitChanges();

                    return true;
                }
                else
                {
                    MessageBox.Show("Room not found.");
                    return false; 
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false; 
            }
        }

    }
}
