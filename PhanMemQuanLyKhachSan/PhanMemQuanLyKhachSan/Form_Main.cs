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
    public partial class Form_Main : Form
    {
        TangBLL tangBLL = new TangBLL();
        PhongBLL phongBLL = new PhongBLL();
        DatPhongBLL datPhongBLL = new DatPhongBLL();
        PhanQuyenBLL phanQuyenBLL = new PhanQuyenBLL();

        private static int idPhong = 0;
        public int userTypeId { get; set; }

        public Form_Main(int userTypeId)
        {
            InitializeComponent();
            showRoom();
            this.userTypeId = userTypeId;
        }


        private Image ResizeImage(Image img, Size size)
        {
            return (Image)(new Bitmap(img, size));
        }

        public void showRoom()
        {
            flowLayoutPanel1.Controls.Clear(); 

            Panel topSpacer = new Panel();
            topSpacer.Size = new Size(flowLayoutPanel1.Width, 10);
            flowLayoutPanel1.Controls.Add(topSpacer);

            var lsTang = tangBLL.getDanhSachTang();

            foreach (var tang in lsTang)
            {
                Label tangLabel = new Label();
                tangLabel.Text = $"{tang.tenTang}";
                tangLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                tangLabel.ForeColor = Color.FromArgb(70, 130, 180);
                tangLabel.AutoSize = true;
                flowLayoutPanel1.Controls.Add(tangLabel);

                var lsPhong = phongBLL.getDSPhongByTang(tang.idTang);

                FlowLayoutPanel roomPanel = new FlowLayoutPanel();
                roomPanel.FlowDirection = FlowDirection.LeftToRight;
                roomPanel.AutoSize = true;
                roomPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                roomPanel.WrapContents = true;

                foreach (var phong in lsPhong)
                {
                    Panel phongContainer = new Panel();
                    phongContainer.Size = new Size(70, 100); 

                    Button phongButton = new Button();
                    phongButton.Text = ""; 
                    phongButton.Size = new Size(70, 70);
                    if(phong.trangThai == true)
                    {
                        phongButton.BackgroundImage = Properties.Resources.locked_home;
                    }   
                    else
                    {
                        phongButton.BackgroundImage = Properties.Resources.non_booking;
                    }    
                    phongButton.BackgroundImageLayout = ImageLayout.Stretch;
                    phongButton.ContextMenuStrip = menuForButton;
                    phongButton.Tag = phong.idPhong;

                    phongButton.Click += (sender, e) =>
                    {
                        MessageBox.Show($"Bạn đã chọn {phong.tenPhong}");
                    };

                    Label phongLabel = new Label();
                    phongLabel.Text = phong.tenPhong;
                    phongLabel.TextAlign = ContentAlignment.MiddleCenter; 
                    phongLabel.Dock = DockStyle.Bottom;
                    phongLabel.Font = new Font("Arial", 9, FontStyle.Bold);

                    phongContainer.Controls.Add(phongButton);
                    phongContainer.Controls.Add(phongLabel);

                    roomPanel.Controls.Add(phongContainer);
                }

                flowLayoutPanel1.Controls.Add(roomPanel);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
                                         "Xác nhận",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form_Login formLogin = new Form_Login();
                formLogin.Show();

                this.Hide();

            }
            else
            {
                return;
            }
        }

        private void LOAIPHONG_Click(object sender, EventArgs e)
        {
            Form_LoaiPhong form = new Form_LoaiPhong();

            if (phanQuyenBLL.CoQuyen(userTypeId, form.Tag))
            {
                form.Show();
            }
            else
            {
                MessageBox.Show($"Bạn không có quyền truy cập vào {form.Tag.ToString()}");
            }
        }

        private void PHONG_Click(object sender, EventArgs e)
        {
            Form_Phong form = new Form_Phong(this);

            if (phanQuyenBLL.CoQuyen(userTypeId, form.Tag))
            {
                form.Show();
            }
            else
            {
                MessageBox.Show($"Bạn không có quyền truy cập vào {form.Tag.ToString()}");
            }
        }

        private void SANPHAM_Click(object sender, EventArgs e)
        {
            Form_SanPham form = new Form_SanPham();

            if (phanQuyenBLL.CoQuyen(userTypeId, form.Tag))
            {
                form.Show();
            }
            else
            {
                MessageBox.Show($"Bạn không có quyền truy cập vào {form.Tag.ToString()}");
            }
        }

        private void THIETBI_Click(object sender, EventArgs e)
        {
            Form_ThietBi form = new Form_ThietBi();

            if (phanQuyenBLL.CoQuyen(userTypeId, form.Tag))
            {
                form.Show();
            }
            else
            {
                MessageBox.Show($"Bạn không có quyền truy cập vào {form.Tag.ToString()}");
            }
        }

        private void PHONG_THIETBI_Click(object sender, EventArgs e)
        {
            Form_ThietBiTrongPhong form = new Form_ThietBiTrongPhong();

            if (phanQuyenBLL.CoQuyen(userTypeId, form.Tag))
            {
                form.Show();
            }
            else
            {
                MessageBox.Show($"Bạn không có quyền truy cập vào {form.Tag.ToString()}");
            }
        }

        private void KHACHHANG_Click(object sender, EventArgs e)
        {
            Form_KhachHang form = new Form_KhachHang();

            if (phanQuyenBLL.CoQuyen(userTypeId, form.Tag))
            {
                form.Show();
            }
            else
            {
                MessageBox.Show($"Bạn không có quyền truy cập vào {form.Tag.ToString()}");
            }
        }

        private void TANG_Click(object sender, EventArgs e)
        {
            Form_Tang form = new Form_Tang(this);

            if (phanQuyenBLL.CoQuyen(userTypeId, form.Tag))
            {
                form.Show();
            }
            else
            {
                MessageBox.Show($"Bạn không có quyền truy cập vào {form.Tag.ToString()}");
            }
        }

        private void DATPHONG_Click(object sender, EventArgs e)
        {
            Form_DatPhongtheoDoan form = new Form_DatPhongtheoDoan(this);

            if (phanQuyenBLL.CoQuyen(userTypeId, form.Tag))
            {
                form.Show();
            }
            else
            {
                MessageBox.Show($"Bạn không có quyền truy cập vào {form.Tag.ToString()}");
            }
        }

        private void quênMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_QuenMatKhau form = new Form_QuenMatKhau();

            if (phanQuyenBLL.CoQuyen(userTypeId, form.Tag))
            {
                form.Show();
            }
            else
            {
                MessageBox.Show($"Bạn không có quyền truy cập vào {form.Tag.ToString()}");
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
                                         "Xác nhận",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form_Login formLogin = new Form_Login();
                formLogin.Show();

                this.Hide(); 

            }
            else
            {
                return;
            }
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            Form_BaoCao form = new Form_BaoCao();

            if (phanQuyenBLL.CoQuyen(userTypeId, form.Tag))
            {
                form.Show();
            }
            else
            {
                MessageBox.Show($"Bạn không có quyền truy cập vào {form.Tag.ToString()}");
            }
        }
    }
}
