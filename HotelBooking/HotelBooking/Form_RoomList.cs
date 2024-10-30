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
    public partial class Form_RoomList : Form
    {
        public static int idPhong = 0;
        private Form_Main mainForm;
        PhongBUL PhongBul = new PhongBUL();
        Hinh_Anh_PhongBUL HinhAnhBul = new Hinh_Anh_PhongBUL();
        
        private int currentImageIndex = 0;
        private Timer timer;

        public Form_RoomList(Form_Main formMain)
        {
            InitializeComponent();
            panel1.Paint += panel1_Paint;
            this.mainForm = formMain;
        }

        private void Form_RoomList_Load(object sender, EventArgs e)
        {
            DataTable tblPhong = PhongBul.selectedPhong();
            dgvRoomList.DataSource = tblPhong;
            dgvRoomList.Columns["ID"].Visible = false;

            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(256, 185);

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
                e.Graphics.DrawImage(imageList1.Images[currentImageIndex], new Point(32, 420));
            }
            else
            {
                e.Graphics.DrawString("Không có hình ảnh để hiển thị", this.Font, Brushes.Black, new Point(32, 420));
            }
        }

        private void dgvRoomList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                imageList1.Images.Clear();
                DataGridViewRow selected = dgvRoomList.Rows[e.RowIndex];

                if (selected != null)
                {
                    int maPhong = (int)selected.Cells["ID"].Value;
                    string tenPhong = selected.Cells["RoomName"].Value.ToString();
                    int soLuong = (int)selected.Cells["NoP"].Value;
                    decimal donGia = (decimal)selected.Cells["Price"].Value;
                    string moTa = selected.Cells["Description"].Value.ToString();
                    int trangThai = (int)selected.Cells["Status"].Value;

                    idPhong = maPhong;
                    txtTenPhong.Text = tenPhong;
                    txtSoLuongNguoi.Text = soLuong.ToString();
                    txtMoTa.Text = moTa;
                    txtDonGia.Text = donGia.ToString();
                    txtTrangThai.Text = (trangThai == 0) ? "Not Available" : "Available";

                    imageList1.Images.Clear();

                    List<Hinh_Anh_PhongDTO> imageListFromDB = HinhAnhBul.getImageListByRoomID(maPhong);

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

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            Form_Services form = new Form_Services(mainForm, idPhong);

            bool kq = PhongBul.checkRoomStatus(idPhong);
            if (kq)
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;

                mainForm.AddControls(form);

                form.Show();
                idPhong = 0;
            }
            else
            {
                MessageBox.Show("Phòng không có sẵn! Vui lòng chọn phòng khác!");
            }    
            
        }
    }
}
