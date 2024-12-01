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
    public partial class Form_ThongKeDoanhThu : Form
    {
        DatPhongBLL _datPhongBLL = new DatPhongBLL();
        public Form_ThongKeDoanhThu()
        {
            InitializeComponent();
            loadDanhSachDatPhong();
        }

        private void loadDanhSachDatPhong()
        {
            List<DatPhongDTO> list = _datPhongBLL.getDanhSachDatPhongDaThanhToan();

            dgvDanhSach.DataSource = list;

            dgvDanhSach.Columns[0].HeaderText = "ID Đặt phòng";
            dgvDanhSach.Columns[1].HeaderText = "ID Khách hàng";
            dgvDanhSach.Columns[2].HeaderText = "Tên khách hàng";
            dgvDanhSach.Columns[3].HeaderText = "Ngày đặt";
            dgvDanhSach.Columns[4].HeaderText = "Ngày trả";
            dgvDanhSach.Columns[5].HeaderText = "Số tiền";
            dgvDanhSach.Columns[6].HeaderText = "Số người ở";
            dgvDanhSach.Columns[7].HeaderText = "ID User";
            dgvDanhSach.Columns[8].HeaderText = "Status";
            dgvDanhSach.Columns[9].HeaderText = "Trạng thái";
            dgvDanhSach.Columns[10].HeaderText = "Disable";
            dgvDanhSach.Columns[11].HeaderText = "Theo đoàn";
            dgvDanhSach.Columns[12].HeaderText = "Ghi chú";
            dgvDanhSach.Columns[13].HeaderText = "Ngày tạo";
            dgvDanhSach.Columns[14].HeaderText = "Ngày cập nhật";
            dgvDanhSach.Columns[15].HeaderText = "Cập nhật bởi";


            dgvDanhSach.Columns[0].Visible = false;
            dgvDanhSach.Columns[1].Visible = false;
            dgvDanhSach.Columns[7].Visible = false;
            dgvDanhSach.Columns[8].Visible = false;
            dgvDanhSach.Columns[10].Visible = false;
            dgvDanhSach.Columns[11].Visible = false;
            dgvDanhSach.Columns[12].Visible = false;
            dgvDanhSach.Columns[13].Visible = false;
            dgvDanhSach.Columns[14].Visible = false;
            dgvDanhSach.Columns[15].Visible = false;


            dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime ngayTu = dtpTu.Value.Date;
            DateTime ngayDen = dtpDen.Value.Date;

            if (ngayTu > ngayDen)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<DatPhongDTO> filteredList = _datPhongBLL.getDanhSachDatPhong()
                .Where(dp => dp.ngayTra.Date >= ngayTu && dp.ngayTra.Date <= ngayDen)
                .ToList();

            dgvDanhSach.DataSource = filteredList;

            decimal tongDoanhThu = filteredList.Sum(dp => dp.soTien);

            txtDoanhThu.Text = $"Doanh thu tại khách sạn của bạn từ ngày {ngayTu.ToString("dd/MM/yyyy")} đến ngày {ngayDen.ToString("dd/MM/yyyy")} đạt được: {tongDoanhThu.ToString("N0", new System.Globalization.CultureInfo("vi-VN"))} VND";

            if (filteredList.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả nào trong khoảng thời gian được chọn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuyTimKiem_Click_1(object sender, EventArgs e)
        {
            loadDanhSachDatPhong();
        }
    }
}
