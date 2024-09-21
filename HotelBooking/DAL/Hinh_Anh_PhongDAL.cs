using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class Hinh_Anh_PhongDAL
    {
        QL_KhachSanDataContext qlks = new QL_KhachSanDataContext();

        public List<Hinh_Anh_PhongDTO> getImageListByRoomID(int  roomID)
        {
            List<Hinh_Anh_PhongDTO> imageDTOList = new List<Hinh_Anh_PhongDTO>();
            List<Hinh_Anh_Phong> imageList;

            try
            {
                imageList = qlks.Hinh_Anh_Phongs.Where(t => t.maPhong == roomID).ToList();

                foreach (var image in imageList)
                {
                    Hinh_Anh_PhongDTO imageDTO = new Hinh_Anh_PhongDTO
                    {
                        maPhong = (int)image.maPhong,
                        url = image.url,
                    };

                    imageDTOList.Add(imageDTO); 
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return imageDTOList; 
        }

    }
}
