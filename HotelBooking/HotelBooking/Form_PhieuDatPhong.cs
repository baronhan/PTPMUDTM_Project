﻿using DTO;
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
    public partial class Form_PhieuDatPhong : Form
    {
        public Form_PhieuDatPhong(Form form, List<Dich_VuDTO> list, int idPhong)
        {
            InitializeComponent();
        }
    }
}