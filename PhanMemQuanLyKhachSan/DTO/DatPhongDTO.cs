using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DatPhongDTO
    {
        public int idDP {  get; set; }
        public int idKH { get; set; }
        public string hoTen { get; set; }
        public DateTime ngayDat { get; set; }
        public DateTime ngayTra {  get; set; }
        public decimal soTien { get; set; }
        public int soNguoiO {  get; set; }
        public int idUser { get; set; }
        public bool status { get; set; }
        public string statusText { get; set; }
        public bool disable {  get; set; }
        public bool theoDoan { get; set; }
        public string ghiChu { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        public int update_by { get; set; }

        public DatPhongDTO() { }
        public DatPhongDTO(int idDP, int idKH, DateTime ngayDat, DateTime ngayTra, decimal soTien, int soNguoiO, int idUser, bool status, bool disable, bool theoDoan, string ghiChu, DateTime create_date, DateTime update_date, int update_by)
        {
            this.idDP = idDP;
            this.idKH = idKH;
            this.ngayDat = ngayDat;
            this.ngayTra = ngayTra;
            this.soTien = soTien;
            this.soNguoiO = soNguoiO;
            this.idUser = idUser;
            this.status = status;
            this.disable = disable;
            this.theoDoan = theoDoan;
            this.ghiChu = ghiChu;
            this.create_date = create_date;
            this.update_date = update_date;
            this.update_by = update_by;
        }
    }
}
