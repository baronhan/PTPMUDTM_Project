using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBooking
{
    public partial class Form_HistoryBooking : Form
    {
        private string username = Form_Login._username;
        PhieuDatPhongBUL bul = new PhieuDatPhongBUL();
        KhachHangBUL user_bul = new KhachHangBUL();
        Dich_VuBUL service_bul = new Dich_VuBUL();
        Hinh_Anh_PhongBUL images_bul = new Hinh_Anh_PhongBUL();

        private int currentImageIndex = 0;
        private Timer timer;
        public Form_HistoryBooking()
        {
            InitializeComponent();
            loadHistoryBooking();

            this.Paint += panel1_Paint;
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(256, 185);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            currentImageIndex = (currentImageIndex + 1) % imageList1.Images.Count;
            this.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (imageList1.Images.Count > 0)
            {
                e.Graphics.DrawImage(imageList1.Images[currentImageIndex], new Point(32, 490));
            }
            else
            {
                e.Graphics.DrawString("Không có hình ảnh để hiển thị", this.Font, Brushes.Black, new Point(32, 490));
            }
        }

        private void loadHistoryBooking()
        {
            KhachHangDTO user = user_bul.GetKhachHangByUsername(username);

            if (user != null)
            {
                List<BookingInfoDTO> bookingList = bul.getBookingListByCustomerID(user.maKH);

                dgvHistoryBooking.DataSource = bookingList;

                dgvHistoryBooking.Columns.Clear();

                dgvHistoryBooking.Columns.Add("MaDatPhong", "Booking ID");
                dgvHistoryBooking.Columns["MaDatPhong"].DataPropertyName = "MaDatPhong";
                dgvHistoryBooking.Columns["MaDatPhong"].Visible = false;

                dgvHistoryBooking.Columns.Add("MaPhong", "Room ID");
                dgvHistoryBooking.Columns["MaPhong"].DataPropertyName = "MaPhong";
                dgvHistoryBooking.Columns["MaPhong"].Visible = false;

                dgvHistoryBooking.Columns.Add("Username", "Customer Name");
                dgvHistoryBooking.Columns["Username"].DataPropertyName = "Username";

                dgvHistoryBooking.Columns.Add("TenPhong", "Room Name");
                dgvHistoryBooking.Columns["TenPhong"].DataPropertyName = "TenPhong";

                dgvHistoryBooking.Columns.Add("CheckIn", "Check-In");
                dgvHistoryBooking.Columns["CheckIn"].DataPropertyName = "CheckIn";

                dgvHistoryBooking.Columns.Add("CheckOut", "Check-Out");
                dgvHistoryBooking.Columns["CheckOut"].DataPropertyName = "CheckOut";

                dgvHistoryBooking.Columns.Add("TongTien", "Total Price");
                dgvHistoryBooking.Columns["TongTien"].DataPropertyName = "TongTien";


            }
        }


        private void LoadServicesForBooking(int maDatPhong)
        {
            List<Dich_VuDTO> serviceList = service_bul.GetServicesByBookingId(maDatPhong);

            dgvServiceList.DataSource = serviceList;

            dgvServiceList.Columns.Clear();

            dgvServiceList.Columns.Add("TenDichVu", "Service Name");
            dgvServiceList.Columns["TenDichVu"].DataPropertyName = "TenDichVu";

            dgvServiceList.Columns.Add("Acronym", "Acronym");
            dgvServiceList.Columns["Acronym"].DataPropertyName = "Acronym";

            dgvServiceList.Columns.Add("DonGia", "Unit Price");
            dgvServiceList.Columns["DonGia"].DataPropertyName = "DonGia";
        }

        private void dgvHistoryBooking_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvHistoryBooking.Rows[e.RowIndex];
                string tenKhachHang = selectedRow.Cells["Username"].Value.ToString();
                string tenPhong = selectedRow.Cells["TenPhong"].Value.ToString();
                DateTime checkIn = Convert.ToDateTime(selectedRow.Cells["CheckIn"].Value);
                DateTime checkOut = Convert.ToDateTime(selectedRow.Cells["CheckOut"].Value);
                decimal tongTien = Convert.ToDecimal(selectedRow.Cells["TongTien"].Value);

                txtCustomerName.Text = tenKhachHang;
                txtRoomName.Text = tenPhong;
                dtpCheckIn.Value = checkIn;
                dtpCheckOut.Value = checkOut;
                txtTotalPrice.Text = tongTien.ToString("F2"); 

                int maDatPhong = Convert.ToInt32(selectedRow.Cells["MaDatPhong"].Value);
                LoadServicesForBooking(maDatPhong);

                int maPhong = Convert.ToInt32(selectedRow.Cells["MaPhong"].Value);

                imageList1.Images.Clear();

                List<Hinh_Anh_PhongDTO> imageListFromDB = images_bul.getImageListByRoomID(maPhong);

                foreach (var imageDTO in imageListFromDB)
                {
                    string imagePath = imageDTO.url;

                    if (File.Exists(imagePath))
                    {
                        imageList1.Images.Add(Image.FromFile(imagePath));
                    }
                    else
                    {
                        MessageBox.Show($"Hình ảnh không tìm thấy tại đường dẫn: {imagePath}");
                    }
                }

                timer = new Timer();
                timer.Interval = 3000;
                timer.Tick += Timer_Tick;
                if (imageList1.Images.Count > 0)
                {
                    timer.Start();
                }
            }
        }
    }
}
