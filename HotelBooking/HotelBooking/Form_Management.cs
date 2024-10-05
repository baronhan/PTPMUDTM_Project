using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBooking
{
    public partial class Form_Management : Form
    {
        private string _username = Form_Login._username;

        public Form_Management()
        {
            InitializeComponent();
        }
        public void AddControls(Control control)
        {
            flowPanel.Controls.Clear();
            flowPanel.Controls.Add(control);
            control.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form_Home form = new Form_Home();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            AddControls(form);

            form.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            Form_UserList form = new Form_UserList();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            AddControls(form);

            form.Show();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {

        }

        private void btnRoom_Click(object sender, EventArgs e)
        {

        }

        private void btnService_Click(object sender, EventArgs e)
        {

        }

        private void Form_Management_Load(object sender, EventArgs e)
        {
            labelWelcome.Text = "Welcome " + _username;

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 30;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);

            this.Region = new Region(path);

            btnHome_Click(sender, e);


        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                         "Bạn có chắc chắn muốn đăng xuất không?",
                         "Xác nhận",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question
                     );
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (sidebar.Width == 267)
            {
                sidebar.Width = 82;
            }
            else
            {
                sidebar.Width = 267;
            }
        }
    }
}
