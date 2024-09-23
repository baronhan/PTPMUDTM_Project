using BUL;
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

namespace HotelBooking
{
    public partial class Form_Services : Form
    {
        private Form_Main formMain;
        private List<Dich_VuDTO> serviceList = new List<Dich_VuDTO>();
        private int idPhong = 0;

        Dich_VuBUL bul = new Dich_VuBUL();
        public Form_Services(Form_Main formMain, int idPhong)
        {
            InitializeComponent();
            this.formMain = formMain;
            this.idPhong = idPhong;
        }

        private void Form_Services_Load(object sender, EventArgs e)
        {
            DataTable tbService = bul.SelectDichVu();
            dgvServiceList.DataSource = tbService;
            dgvServiceList.Columns["ID"].Visible = false;

            dgvSelectedServices.Columns.Add("ID", "ID");
            dgvSelectedServices.Columns.Add("ServiceName", "ServiceName");
            dgvSelectedServices.Columns.Add("Acronym", "Acronym");
            dgvSelectedServices.Columns.Add("Prices", "Prices");
            dgvSelectedServices.Columns["ID"].Visible = false;

        }

        private void dgvServiceList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow selected = dgvServiceList.Rows[e.RowIndex];

                string tenDich = selected.Cells["ServiceName"].Value.ToString();
                string acronym = selected.Cells["Acronym"].Value.ToString();
                decimal donGia = (decimal)selected.Cells["Prices"].Value;

                txtAcronym.Text = acronym;
                txtPrices.Text = donGia.ToString();
                txtServiceName.Text = tenDich;

            }    
        }

        private void btnRemoveService_Click(object sender, EventArgs e)
        {
            if (dgvSelectedServices.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvSelectedServices.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dgvSelectedServices.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 dịch vụ.");
            }
        }

        private void btnAddNewService_Click(object sender, EventArgs e)
        {
            if (dgvServiceList.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow selectedRow in dgvServiceList.SelectedRows)
                {
                    int id = (int)selectedRow.Cells["ID"].Value;
                    string serviceName = selectedRow.Cells["ServiceName"].Value.ToString();
                    string acronym = selectedRow.Cells["Acronym"].Value.ToString();
                    decimal price = Convert.ToDecimal(selectedRow.Cells["Prices"].Value);

                    Dich_VuDTO service = new Dich_VuDTO(id, serviceName, acronym, price);
                    serviceList.Add(service);

                    dgvSelectedServices.Rows.Add(id, serviceName, acronym, price);
                }

                MessageBox.Show("Dịch vụ đã được thêm!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dịch vụ để thêm.");
            }
        }

        private void btnReturnRoomList_Click(object sender, EventArgs e)
        {
            Form_RoomList form = new Form_RoomList(formMain);

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            formMain.AddControls(form);

            form.Show();
        }

        private void btnContinueBooking_Click(object sender, EventArgs e)
        {
            if (idPhong != 0 && serviceList.Count == 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn đặt phòng không có sử dụng thêm dịch vụ không?",
                                                      "Xác nhận",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Form_PhieuDatPhong form = new Form_PhieuDatPhong(formMain, serviceList, idPhong);

                    form.TopLevel = false;
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.Dock = DockStyle.Fill;

                    formMain.AddControls(form);

                    form.Show();
                }
            }
            else if (idPhong != 0 && serviceList.Count > 0)
            {
                Form_PhieuDatPhong form = new Form_PhieuDatPhong(formMain, serviceList, idPhong);

                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;

                formMain.AddControls(form);

                form.Show();
            }
            else
            {
                MessageBox.Show("Không tìm thấy phòng tương ứng");
            }
        }
    }
}
