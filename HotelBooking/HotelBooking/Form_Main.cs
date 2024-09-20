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
    public partial class Form_Main : Form
    {
        private string _username = Form_Login._username;
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            labelWelcome.Text = "Welcome " + _username;

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 30;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);

            this.Region = new Region(path);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if(sidebar.Width == 267)
            {
                sidebar.Width = 82;
            }    
            else
            {
                sidebar.Width = 267;
            }    
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            Form_RoomList form = new Form_RoomList();

            form.TopLevel = false;

            flowPanel.Controls.Clear();

            foreach (Control control in form.Controls)
            {
                flowPanel.Controls.Add(control);
            }

            form.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form_Home form = new Form_Home();

            form.TopLevel = false;

            flowPanel.Controls.Clear();

            foreach (Control control in form.Controls)
            {
                flowPanel.Controls.Add(control);
            }

            form.Show();
        }

        private void btnHistoryBooking_Click(object sender, EventArgs e)
        {
            Form_HistoryBooking form = new Form_HistoryBooking();

            form.TopLevel = false;

            flowPanel.Controls.Clear();

            foreach (Control control in form.Controls)
            {
                flowPanel.Controls.Add(control);
            }

            form.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            Form_UserProfile form = new Form_UserProfile();

            form.TopLevel = false;

            flowPanel.Controls.Clear();

            foreach (Control control in form.Controls)
            {
                flowPanel.Controls.Add(control);
            }

            form.Show();
        }
    }
}
