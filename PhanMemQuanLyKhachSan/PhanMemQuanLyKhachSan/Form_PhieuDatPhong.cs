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
using System.Xml.Linq;

namespace HotelBooking
{
    public partial class Form_PhieuDatPhong : Form
    {
        PhieuDatPhongBUL pdp_bul = new PhieuDatPhongBUL();
        KhachHangBUL user_bul = new KhachHangBUL();
        Hinh_Anh_PhongBUL picture_bul = new Hinh_Anh_PhongBUL();
        PhongBUL room_bul = new PhongBUL();
        List<Dich_VuDTO> list = new List<Dich_VuDTO>();
        Form_Main formMain = new Form_Main();

        private int userId = 0;
        private string username = Form_Login._username;
        private decimal totalPrice = 0;
        private decimal serviceTotal = 0;
        private int roomId;
        private int currentImageIndex = 0;
        private Timer timer;

        public Form_PhieuDatPhong(Form_Main form, List<Dich_VuDTO> list, int idPhong)
        {
            InitializeComponent();
            this.list = list;
            this.roomId = idPhong;
            this.formMain = form;

            panel1.Paint += panel1_Paint;
            loadServiceList();
            loadRoomInfo();
            loadUserName();

            dtpCheckIn.MinDate = DateTime.Now;
            dtpCheckOut.MinDate = DateTime.Now.AddDays(1);

            dtpCheckIn.ValueChanged += dtpCheckin_ValueChanged;
            dtpCheckIn.ValueChanged += dtpCheckout_ValueChanged;
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            currentImageIndex = (currentImageIndex + 1) % imageList1.Images.Count;
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (imageList1.Images.Count > 0)
            {
                e.Graphics.DrawImage(imageList1.Images[currentImageIndex], new Point(32, 450));
            }
            else
            {
                e.Graphics.DrawString("Không có hình ảnh để hiển thị", this.Font, Brushes.Black, new Point(32, 420));
            }
        }


        private void loadServiceList()
        {
            dgvServiceList.Rows.Clear();

            if (dgvServiceList.Columns.Count == 0)
            {
                dgvServiceList.Columns.Add("ID", "ID");
                dgvServiceList.Columns.Add("ServiceName", "ServiceName");
                dgvServiceList.Columns.Add("Acronym", "Acronym");
                dgvServiceList.Columns.Add("Prices", "Prices");

                dgvServiceList.Columns["ID"].Visible = false;
            }

            decimal totalPrice = 0;

            foreach (var service in list)
            {
                dgvServiceList.Rows.Add(service.maDichVu, service.tenDichVu, service.acronym, service.donGia);
                totalPrice += service.donGia;
            }

            serviceTotal = totalPrice;
        }

        private void loadRoomInfo()
        {
            imageList1.Images.Clear();

            PhongDTO phong = room_bul.getRoomInfoById(this.roomId);

            if (phong != null)
            {
                txtRoomName.Text = phong.tenPhong.ToString();
                txtRoomPrice.Text = phong.donGia.ToString();
                totalPrice = (decimal) phong.donGia + serviceTotal;
                txtServiceTotal.Text = serviceTotal.ToString();
                txtTotal.Text = totalPrice.ToString();
            }

            List<Hinh_Anh_PhongDTO> imageListFromDB = picture_bul.getImageListByRoomID(this.roomId);

            bool imagesFound = false;

            foreach (var imageDTO in imageListFromDB)
            {
                string imagePath = imageDTO.url;

                if (File.Exists(imagePath))
                {
                    imageList1.Images.Add(Image.FromFile(imagePath));
                    imagesFound = true;
                }
                else
                {
                    Console.WriteLine($"Hình ảnh không tìm thấy tại đường dẫn: {imagePath}");
                }
            }

            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(256, 185);

            if (imagesFound)
            {
                timer = new Timer();
                timer.Interval = 3000; 
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            else
            {
                MessageBox.Show("Không có hình ảnh hợp lệ để hiển thị.");
            }
        }

        private void loadUserName()
        {
            txtCustomerName.Text = username;

            KhachHangDTO kh = user_bul.GetKhachHangByUsername(username);

            if (kh != null)
            {
                userId = kh.maKH;
            }    
            
        }

        private void dtpCheckin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckIn.Value >= dtpCheckOut.Value)
            {
                MessageBox.Show("Ngày check-in phải nhỏ hơn ngày check-out!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);
            }

            dtpCheckOut.MinDate = dtpCheckIn.Value.AddDays(1);
        }

        private void dtpCheckout_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                MessageBox.Show("Ngày check-out phải lớn hơn ngày check-in!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);
            }
        }

        private void btnReturnServiceList_Click(object sender, EventArgs e)
        {
            Form_Services form = new Form_Services(formMain, list, roomId);

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            formMain.AddControls(form);

            form.Show();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            //if (userId == null || roomId == null || dtpCheckIn.Value == null || dtpCheckOut.Value == null || totalPrice <= 0)
            //{
            //    MessageBox.Show("Thông tin chưa đầy đủ, vui lòng kiểm tra lại thông tin!");
            //    return;
            //}

            //PhieuDatPhongDTO pdp = new PhieuDatPhongDTO(null, userId, roomId, dtpCheckIn.Value, dtpCheckOut.Value, totalPrice);

            //Form_Payment form = new Form_Payment(formMain, list , pdp)
            //{
            //    TopLevel = false,
            //    FormBorderStyle = FormBorderStyle.None,
            //    Dock = DockStyle.Fill
            //};

            //formMain.AddControls(form);

            //form.Show();

            PhieuDatPhongDTO pdp = new PhieuDatPhongDTO(null, userId, roomId, dtpCheckIn.Value, dtpCheckOut.Value, totalPrice);
            
            bool kq = pdp_bul.insertPhieuDatPhong(pdp, list);
            string tb = "";

            if (kq)
            {
                bool updateRoomStatus = room_bul.updateTrangThaiPhong(roomId);
                if (updateRoomStatus)
                {
                    tb = "Bạn đã thanh toán thành công";
                    Form_HistoryBooking form = new Form_HistoryBooking();

                    form.TopLevel = false;
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.Dock = DockStyle.Fill;

                    formMain.AddControls(form);

                    form.Show();

                }    
                else
                {
                    tb = "Thanh toán không thành công!";
                }    
            }    
            else
            {
                tb = "Thêm mới phiếu đặt phòng thất bại!";
            }

            MessageBox.Show(tb);

        }

    }
}
