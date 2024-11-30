using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class XuatExcel
    {
        public string TenKhach {  get; set; }
        public int SoNguoiO { get; set; }
        public DateTime NgayDat {  get; set; }
        public DateTime NgayTra {  get; set; }
        public string GhiChu { get; set; }
        public string TenNV { get; set; }
        public double TongTien { get; set; }

        public List<ChiTietPhieuDatPhongExcel> DatPhongCT { get; set; }
        public List<ChiTietSanPhamExcel> DatPhongCTSP { get; set; }

        public XuatExcel() { }

        public XuatExcel(string tenKhach, int soNguoiO, DateTime ngayDat, DateTime ngayTra, string ghiChu, string tenNV, double tongTien, List<ChiTietPhieuDatPhongExcel> datPhongCT, List<ChiTietSanPhamExcel> datPhongCTSP)
        {
            TenKhach = tenKhach;
            SoNguoiO = soNguoiO;
            NgayDat = ngayDat;
            NgayTra = ngayTra;
            GhiChu = ghiChu;
            TenNV = tenNV;
            TongTien = tongTien;
            DatPhongCT = datPhongCT;
            DatPhongCTSP = datPhongCTSP;
        }

        public class ChiTietPhieuDatPhongExcel
        {
            public int STT { get; set; }
            public string TENTANG { get; set; }
            public string TENPHONG { get; set; }
            public double DONGIA { get; set; }
            public double TONGTIENPHONG { get; set; }
        }

        public class ChiTietSanPhamExcel
        {
            public int STT { get; set; }
            public string TENPHONG { get; set; }
            public string TENSANPHAM { get; set; }
            public string SOLUONG { get; set; }
            public double DONGIA { get; set; }
            public double THANHTIEN { get; set; }
            public double TONGTIENSP { get; set; }
        }
    }
}
