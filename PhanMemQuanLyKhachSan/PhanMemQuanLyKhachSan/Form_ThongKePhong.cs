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
    public partial class Form_ThongKePhong : Form
    {
        DatPhongBLL _datPhongBLL = new DatPhongBLL();
        PhongBLL _phongBLL = new PhongBLL();
        public Form_ThongKePhong()
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

            // Lọc danh sách đặt phòng
            List<DatPhongDTO> filteredList = _datPhongBLL.getDanhSachDatPhong()
                .Where(dp => dp.ngayTra.Date >= ngayTu && dp.ngayTra.Date <= ngayDen)
                .ToList();

            dgvDanhSach.DataSource = filteredList;

            if (filteredList.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả nào trong khoảng thời gian được chọn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDSPhong.DataSource = null;
                return;
            }

            List<int> idDPs = filteredList.Select(dp => dp.idDP).Distinct().ToList();

            txtSoLuongKhach.Text = "Số lượng phòng: " + idDPs.Count.ToString();

            List<PhongDTO> phongList = _phongBLL.getDanhSachPhongByIDDPs(idDPs);

            dgvDSPhong.DataSource = phongList;

            dgvDSPhong.Columns[0].HeaderText = "Mã Phòng";
            dgvDSPhong.Columns[1].HeaderText = "Tên Phòng";
            dgvDSPhong.Columns[2].HeaderText = "Trạng Thái";
            dgvDSPhong.Columns[3].HeaderText = "Mã Tầng";
            dgvDSPhong.Columns[4].HeaderText = "Mã Loại Phòng";
            dgvDSPhong.Columns[5].HeaderText = "Tên tầng";
            dgvDSPhong.Columns[6].HeaderText = "Tên Loại phòng";
            dgvDSPhong.Columns[7].HeaderText = "Disable";

            dgvDSPhong.Columns[0].Visible = false;
            dgvDSPhong.Columns[2].Visible = false;
            dgvDSPhong.Columns[3].Visible = false;
            dgvDSPhong.Columns[4].Visible = false;
            dgvDSPhong.Columns[7].Visible = false;




            dgvDSPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnHuyTimKiem_Click(object sender, EventArgs e)
        {
            loadDanhSachDatPhong();
            dgvDSPhong.DataSource = null;
        }
    }
}
