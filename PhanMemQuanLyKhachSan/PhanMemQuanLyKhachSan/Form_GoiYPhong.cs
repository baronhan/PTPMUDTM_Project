using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyKhachSan
{
    public partial class Form_GoiYPhong : Form
    {
        PhongBLL bll = new PhongBLL();
        public Form_GoiYPhong()
        {
            InitializeComponent();
        }

        private void btnGoiY_Click(object sender, EventArgs e)
        {
            try
            {
                double nganSach = (double)nbrSotienchitra.Value;
                int tongSoKhach = (int)nbrSoluongkhach.Value;

                List<PhongGreedyDTO> danhSachPhong = bll.LayDanhSachPhongConTrong();
                List<string> tenPhongToiUu = TimPhongToiUu(danhSachPhong, tongSoKhach, nganSach);

                string ketQua = string.Join(", ", tenPhongToiUu);
                lblDuDoanKetQua.Text = $"Phòng tối ưu: {ketQua}";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<string> TimPhongToiUu(List<PhongGreedyDTO> danhSachPhong, int tongSoKhach, double nganSach)
        {
            if (danhSachPhong == null || danhSachPhong.Count == 0)
                throw new ArgumentException("Danh sách phòng không được rỗng");

            const double TRONG_SO_GIA_TIEN = 0.6;
            const double TRONG_SO_SO_KHACH = 0.4;

            double giaTienToiDa = danhSachPhong.Max(p => p.GiaTien);
            double soKhachToiDa = danhSachPhong.Max(p => p.SoKhachToiDa);

            foreach (var phong in danhSachPhong)
            {
                double pGiaTien = 1 - Math.Abs(phong.GiaTien - nganSach) / giaTienToiDa;
                double pSoKhach = 1 - Math.Abs(phong.SoKhachToiDa - tongSoKhach) / soKhachToiDa;

                phong.DiemPhuHop = (TRONG_SO_GIA_TIEN * pGiaTien) + (TRONG_SO_SO_KHACH * pSoKhach);
            }

            // Sắp xếp danh sách phòng theo điểm phù hợp giảm dần
            var phongSapXep = danhSachPhong
                .OrderByDescending(p => p.DiemPhuHop)
                .ToList();

            // Sử dụng thuật toán tìm tổ hợp tối ưu
            var tapPhongToiUu = new List<PhongGreedyDTO>();
            var ketQuaToiUu = new List<PhongGreedyDTO>();
            double diemToiUu = double.MinValue;

            void TryCombination(int index, List<PhongGreedyDTO> currentCombination, int currentKhach, double currentDiem)
            {
                if (currentKhach >= tongSoKhach)
                {
                    if (currentDiem > diemToiUu)
                    {
                        diemToiUu = currentDiem;
                        ketQuaToiUu = new List<PhongGreedyDTO>(currentCombination);
                    }
                    return;
                }

                if (index >= phongSapXep.Count)
                    return;

                // Thử thêm phòng hiện tại
                currentCombination.Add(phongSapXep[index]);
                TryCombination(index + 1, currentCombination, currentKhach + phongSapXep[index].SoKhachToiDa, currentDiem + phongSapXep[index].DiemPhuHop);

                // Bỏ qua phòng hiện tại
                currentCombination.RemoveAt(currentCombination.Count - 1);
                TryCombination(index + 1, currentCombination, currentKhach, currentDiem);
            }

            TryCombination(0, tapPhongToiUu, 0, 0);

            if (ketQuaToiUu.Count == 0)
                throw new InvalidOperationException("Không tìm được phòng đủ để đáp ứng số khách yêu cầu.");

            return ketQuaToiUu.Select(p => p.TenPhong).ToList();
        }



    }
}
