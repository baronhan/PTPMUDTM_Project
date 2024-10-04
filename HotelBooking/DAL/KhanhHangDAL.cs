using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using DTO;

namespace DAL
{
    public class KhanhHangDAL
    {
        QL_KhachSanDataContext qlks = new QL_KhachSanDataContext();

        public bool VerifyLogin(string username, string password)
        {
            try
            {
                Khach_Hang kh = qlks.Khach_Hangs.Where(t => t.userName == username).FirstOrDefault();

                if (kh != null)
                {
                    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, kh.password);

                    if (isPasswordValid)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }
        public bool Register(string username, string password, string fullName, string email, string address, string phone)
        {
            try
            {
                var existingUser = qlks.Khach_Hangs
                    .FirstOrDefault(kh => kh.userName == username || kh.email == email);

                if (existingUser != null)
                {
                    MessageBox.Show("Tài khoản đã tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                Khach_Hang newKhachHang = new Khach_Hang
                {
                    userName = username,
                    password = hashedPassword,
                    hoTen = fullName,
                    email = email,
                    diaChi = address,
                    soDienThoai = phone
                };

                qlks.Khach_Hangs.InsertOnSubmit(newKhachHang);
                qlks.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public KhachHangDTO GetKhachHangByUsername(string username)
        {
            var khachHang = qlks.Khach_Hangs
                            .Where(kh => kh.userName == username)
                            .Select(kh => new KhachHangDTO
                            {
                                maKH = kh.maKH,
                                username = kh.userName,
                                password = kh.password,
                                hoTen = kh.hoTen,
                                email = kh.email,
                                diaChi = kh.diaChi,
                                soDienThoai = kh.soDienThoai,
                                maNhomNguoiDung = (int)kh.maNhomNguoiDung
                            }).FirstOrDefault();
            return khachHang;
        }
        public int GetMaNhom(string username)
        {
            var khachHang = qlks.Khach_Hangs
                            .Where(kh => kh.userName == username)
                            .Select(kh => new KhachHangDTO
                            {
                                maNhomNguoiDung = (int)kh.maNhomNguoiDung
                            }).FirstOrDefault();
            return khachHang.maNhomNguoiDung;
        }

        public List<KhachHangDTO> GetAllKhachHang()
        {
            var khachHangList = qlks.Khach_Hangs
                                         .Select(kh => new KhachHangDTO
                                         {
                                             maKH = kh.maKH,
                                             username = kh.userName,
                                             hoTen = kh.hoTen,
                                             email = kh.email,
                                             diaChi = kh.diaChi,
                                             soDienThoai = kh.soDienThoai,
                                             maNhomNguoiDung = (int)kh.maNhomNguoiDung
                                         })
                                         .ToList();

            return khachHangList;
        }
        public DataTable GetKhachHangDataTable()
        {
            DataTable userList = new DataTable();
            try
            {
                var tblKhachHang = from kh in qlks.Khach_Hangs
                                   where kh.maNhomNguoiDung == 1
                                   select kh;

                userList.Columns.Add("ID", typeof(int));
                userList.Columns.Add("UserName", typeof(string));
                userList.Columns.Add("FullName", typeof(string));
                userList.Columns.Add("Email", typeof(string));
                userList.Columns.Add("Address", typeof(string));
                userList.Columns.Add("Phone", typeof(string));

                foreach (var item in tblKhachHang)
                {
                    DataRow row = userList.NewRow();
                    row["ID"] = item.maKH;
                    row["UserName"] = item.userName;
                    row["FullName"] = item.hoTen;
                    row["Email"] = item.email;
                    row["Address"] = item.diaChi;
                    row["Phone"] = item.soDienThoai;

                    userList.Rows.Add(row);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return userList;
        }
        public bool AddKhachHang(KhachHangDTO khachHang)
        {
            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword("12345678");

                Khach_Hang newKhachHang = new Khach_Hang
                {
                    userName = khachHang.username,
                    password = hashedPassword,
                    hoTen = khachHang.hoTen,
                    email = khachHang.email,
                    diaChi = khachHang.diaChi,
                    soDienThoai = khachHang.soDienThoai,
                    maNhomNguoiDung = khachHang.maNhomNguoiDung
                };

                qlks.Khach_Hangs.InsertOnSubmit(newKhachHang);
                qlks.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the customer: " + ex.Message);
                return false;
            }
        }


        public bool UpdateKhachHang(KhachHangDTO khachHang)
        {
            var khachHangDb = qlks.Khach_Hangs.FirstOrDefault(kh => kh.maKH == khachHang.maKH);
            if (khachHangDb != null)
            {
                khachHangDb.hoTen = khachHang.hoTen;
                khachHangDb.email = khachHang.email;
                khachHangDb.diaChi = khachHang.diaChi;
                khachHangDb.soDienThoai = khachHang.soDienThoai;

                qlks.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool DeleteKhachHang(int maKH)
        {
            var khachHang = qlks.Khach_Hangs.FirstOrDefault(kh => kh.maKH == maKH);
            if (khachHang != null)
            {
                qlks.Khach_Hangs.DeleteOnSubmit(khachHang);
                qlks.SubmitChanges();
                return true;
            }
            return false;

        }
    }
}