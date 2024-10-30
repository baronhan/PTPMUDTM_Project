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
    public class Dich_VuDAL
    {
        QL_KhachSanDataContext qlks = new QL_KhachSanDataContext();

        public DataTable SelectDichVu()
        {
            DataTable serviceList = new DataTable();
            try
            {
                var tblService = from dv in qlks.Dich_Vus
                                 select dv;

                serviceList.Columns.Add("ID", typeof(int));
                serviceList.Columns.Add("ServiceName", typeof(string));
                serviceList.Columns.Add("Acronym", typeof(string));
                serviceList.Columns.Add("Prices", typeof (decimal));

                foreach(var item in tblService)
                {
                    DataRow row = serviceList.NewRow();
                    row["ID"] = item.maDichVu;
                    row["ServiceName"] = item.tenDich;
                    row["Acronym"] = item.acronym;
                    row["Prices"] = item.donGia;

                    serviceList.Rows.Add(row);
                }   

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return serviceList;
        }

        public List<Dich_VuDTO> GetServicesByBookingId(int maDatPhong)
        {
            List<Dich_VuDTO> servicesList = new List<Dich_VuDTO>();

            try
            {
                // Query to get the services associated with the given booking ID
                var query = from ct in qlks.CT_PDP_DVs // Assuming CT_PDP_DV is the table holding service details
                            where ct.maDatPhong == maDatPhong
                            join dv in qlks.Dich_Vus on ct.maDichVu equals dv.maDichVu // Join with Dich_Vus to get service details
                            select new
                            {
                                dv.maDichVu,
                                dv.tenDich,
                                dv.acronym,
                                dv.donGia,
                                ct.soLuong,
                            };

                // Populate the services list
                foreach (var item in query)
                {
                    Dich_VuDTO service = new Dich_VuDTO
                    {
                        maDichVu = item.maDichVu,
                        tenDichVu = item.tenDich,
                        acronym = item.acronym,
                        donGia = (decimal)item.donGia
                    };

                    servicesList.Add(service);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return servicesList;
        }

    }
}
