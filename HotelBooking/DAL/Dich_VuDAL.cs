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
    }
}
