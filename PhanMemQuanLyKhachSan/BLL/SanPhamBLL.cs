using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class SanPhamBLL
    {
        SanPhamDAL dal = new SanPhamDAL();

        public bool addSanPham(SanPhamDTO sanPhamDTO)
        {
            if(sanPhamDTO == null)
            {
                MessageBox.Show("Thông tin Sản phẩm không được để trống!");
                return false;
            }    

            if(string.IsNullOrEmpty(sanPhamDTO.tenSP))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!");
                return false;
            }    

            if(sanPhamDTO.donGia < 0 || sanPhamDTO.donGia > 100000)
            {
                MessageBox.Show("Đơn giá phải nằm trong khoảng từ 0 đến 100,000!");
                return false;
            }    

            return dal.addSanPham(sanPhamDTO);
        }

        public bool deleteSanPham(int idSP)
        {
            if(idSP <= 0)
            {
                MessageBox.Show("ID Sản phẩm phải lớn hơn 0!");
                return false;
            }    

            return dal.deleteSanPham(idSP);
        }

        public List<SanPhamDTO> getDanhSachSanPham()
        {
            return dal.getDanhSachSanPham();
        }

        public bool updateSanPham(SanPhamDTO sanPhamDTO)
        {
            if (sanPhamDTO == null)
            {
                MessageBox.Show("Thông tin Sản phẩm không được để trống!");
                return false;
            }

            if (string.IsNullOrEmpty(sanPhamDTO.tenSP))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!");
                return false;
            }

            if (sanPhamDTO.donGia < 0 || sanPhamDTO.donGia > 100000)
            {
                MessageBox.Show("Đơn giá phải nằm trong khoảng từ 0 đến 100,000!");
                return false;
            }

            return dal.updateSanPham(sanPhamDTO);
        }

        public DataTable getDanhSachSanPham_DataTable()
        {
            return dal.getDanhSachSanPham_DataTable();
        }

        public List<SanPhamDTO> getDanhSachSanPhamByIDDPs(List<int> idDatPhongs)
        {
            return dal.getDanhSachSanPhamByIDDPs(idDatPhongs);
        }
    }
}
