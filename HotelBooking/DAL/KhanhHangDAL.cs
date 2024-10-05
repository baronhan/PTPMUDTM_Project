using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
                    soDienThoai = phone,
                    maNhomNguoiDung = 1
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
                                             password = kh.password,
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
        public DataTable GetKhachHangDataTable(int? userGroupId = null)
        {
            var query = qlks.Khach_Hangs.AsQueryable();

            if (userGroupId.HasValue)
            {
                query = query.Where(kh => kh.maNhomNguoiDung == userGroupId.Value);
            }

            var khachHangList = query.Select(kh => new
            {
                kh.maKH,
                kh.userName,
                kh.hoTen,
                kh.email,
                kh.diaChi,
                kh.soDienThoai
            }).ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("FullName", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Phone", typeof(string));

            foreach (var kh in khachHangList)
            {
                DataRow row = dt.NewRow();
                row["ID"] = kh.maKH;
                row["UserName"] = kh.userName;
                row["FullName"] = kh.hoTen;
                row["Email"] = kh.email;
                row["Address"] = kh.diaChi;
                row["Phone"] = kh.soDienThoai;
                dt.Rows.Add(row);
            }

            return dt;
        }
        public bool AddKhachHang(KhachHangDTO khachHang)
        {
            try
            {
                Khach_Hang newKhachHang = new Khach_Hang
                {
                    userName = khachHang.username,
                    password = BCrypt.Net.BCrypt.HashPassword(khachHang.password),
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
                khachHangDb.userName = khachHang.username;
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

        public bool UpdatePassword(string username, string hashedPassword)
        {
            var user = qlks.Khach_Hangs.FirstOrDefault(kh => kh.userName == username);
            if (user != null)
            {
                user.password = hashedPassword;
                qlks.SubmitChanges();
                return true;
            }
            return false;
        }




    }
}