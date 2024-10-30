using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class KhachHangBLL
    {
        KhachHangDAL dal = new KhachHangDAL();

        public List<KhachHangDTO> getDanhSachKhachHang()
        {
            return dal.getDanhSachKhachHang();
        }
        public bool addKhachHang(KhachHangDTO khachHangDTO)
        {
            if (khachHangDTO == null)
            {
                MessageBox.Show("Thông tin khách hàng không được để trống!");
                return false;
            }

            if (string.IsNullOrEmpty(khachHangDTO.hoTen))
            {
                MessageBox.Show("Họ tên khách hàng không được để trống!");
                return false;
            }

            if (string.IsNullOrEmpty(khachHangDTO.dienThoai))
            {
                MessageBox.Show("Số điện thoại khách hàng không được để trống!");
                return false;
            }

            string phonePattern = @"^(090|091|094|088|098|097|096|086|083|084|0120|0121|0122|0126|0128)\d{7}$";

            if (!Regex.IsMatch(khachHangDTO.dienThoai, phonePattern))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Nó phải bắt đầu bằng đầu số của Vinaphone, Viettel hoặc Mobifone và có đúng 10 chữ số.");
                return false;
            }

            if (string.IsNullOrEmpty(khachHangDTO.diaChi))
            {
                MessageBox.Show("Địa chỉ khách hàng không được để trống!");
                return false;
            }    

            if(string.IsNullOrEmpty(khachHangDTO.cccd))
            {
                MessageBox.Show("Số căn cước công dân của khách hàng không được để trống!");
                return false;
            }    

            if(string.IsNullOrEmpty(khachHangDTO.email))
            {
                MessageBox.Show("Email khách hàng không được để trống!");
                return false;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(khachHangDTO.email, emailPattern))
            {
                MessageBox.Show("Email không hợp lệ!");
                return false;
            }

            return dal.addKhachHang(khachHangDTO);
        }
        public bool updateKhachHang(KhachHangDTO khachHangDTO)
        {
            if (khachHangDTO == null)
            {
                MessageBox.Show("Thông tin khách hàng không được để trống!");
                return false;
            }

            if (string.IsNullOrEmpty(khachHangDTO.hoTen))
            {
                MessageBox.Show("Họ tên khách hàng không được để trống!");
                return false;
            }

            if (string.IsNullOrEmpty(khachHangDTO.dienThoai))
            {
                MessageBox.Show("Số điện thoại khách hàng không được để trống!");
                return false;
            }

            string phonePattern = @"^(090|091|094|088|098|097|096|086|083|084|0120|0121|0122|0126|0128)\d{7}$";

            if (!Regex.IsMatch(khachHangDTO.dienThoai, phonePattern))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Nó phải bắt đầu bằng đầu số của Vinaphone, Viettel hoặc Mobifone và có đúng 10 chữ số.");
                return false;
            }

            if (string.IsNullOrEmpty(khachHangDTO.diaChi))
            {
                MessageBox.Show("Địa chỉ khách hàng không được để trống!");
                return false;
            }

            if (string.IsNullOrEmpty(khachHangDTO.cccd))
            {
                MessageBox.Show("Số căn cước công dân của khách hàng không được để trống!");
                return false;
            }

            if (string.IsNullOrEmpty(khachHangDTO.email))
            {
                MessageBox.Show("Email khách hàng không được để trống!");
                return false;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(khachHangDTO.email, emailPattern))
            {
                MessageBox.Show("Email không hợp lệ!");
                return false;
            }

            return dal.updateKhachHang(khachHangDTO);
        }
        public bool deleteKhachHang(int idKH)
        {
            if(idKH <= 0)
            {
                MessageBox.Show("ID Khách hàng không hợp lệ!");
                return false;
            }   
            
            return dal.deleteKhachHang(idKH);
        }

        public KhachHangDTO getKhachHangByID(int idKH)
        {
            if (idKH <= 0)
            {
                MessageBox.Show("ID Khách hàng không hợp lệ");
                return null;
            }

            return dal.getKhachHangByID((int)idKH);
        }
    }
}
