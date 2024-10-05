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
    public partial class UserButtonControl : UserControl
    {
        public event EventHandler BtnAdd_Click;
        public event EventHandler BtnUpdate_Click;
        public event EventHandler BtnDelete_Click;
        public event EventHandler BtnCancel_CLick;
        public UserButtonControl()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BtnAdd_Click?.Invoke(this, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BtnUpdate_Click.Invoke(this, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BtnDelete_Click?.Invoke(this, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BtnCancel_CLick?.Invoke(this, e);
        }
    }
}
