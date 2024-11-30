using BLL;
using DTO;
using Syncfusion.XlsIO;
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

namespace PhanMemQuanLyKhachSan
{
    public partial class Form_BaoCao : Form
    {
        DatPhongBLL _datPhongBLL = new DatPhongBLL();
        public Form_BaoCao()
        {
            InitializeComponent();
            loadDanhSachDatPhong();
        }

        private void loadDanhSachDatPhong()
        {
            List<DatPhongDTO> list = _datPhongBLL.getDanhSachDatPhong();

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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            DateTime ngayTu = dtpTu.Value.Date;
            DateTime ngayDen = dtpDen.Value.Date;

            if (ngayTu > ngayDen)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<DatPhongDTO> filteredList = _datPhongBLL.getDanhSachDatPhong()
                .Where(dp => dp.ngayTra.Date >= ngayTu && dp.ngayTra.Date <= ngayDen)
                .ToList();

            dgvDanhSach.DataSource = filteredList;

            if (filteredList.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả nào trong khoảng thời gian được chọn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuyTimKiem_Click(object sender, EventArgs e)
        {
            loadDanhSachDatPhong();
        }

        private void btnXuatBaoCao_Click_1(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                var selected = dgvDanhSach.SelectedRows[0];
                string maPD = selected.Cells["idDP"].Value.ToString();
                int maDatPhong = int.Parse(maPD);
                MessageBox.Show($"Mã phiếu đặt: {maDatPhong}");

                XuatExcel excelData = _datPhongBLL.excel(maDatPhong);

                if (excelData == null)
                {
                    MessageBox.Show("Không có dữ liệu cho phiếu đặt này.");
                    return;
                }

                try
                {
                    // Tạo thư mục nếu chưa tồn tại
                    string directoryPath = System.IO.Path.Combine(Application.StartupPath, "ExportedFiles");
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    string filePath = System.IO.Path.Combine(directoryPath, "PhieuDatPhong_Exported.xlsx");

                    // Đường dẫn đến file mẫu Excel
                    string templateFilePath = System.IO.Path.Combine(Application.StartupPath, "PhieuDatPhong.xlsx");
                    if (!File.Exists(templateFilePath))
                    {
                        MessageBox.Show("File mẫu không tồn tại.");
                        return;
                    }

                    using (ExcelEngine excelEngine = new ExcelEngine())
                    {
                        IApplication application = excelEngine.Excel;
                        application.DefaultVersion = ExcelVersion.Excel2013;

                        // Mở file mẫu Excel
                        using (FileStream inputStream = new FileStream(templateFilePath, FileMode.Open, FileAccess.Read))
                        {
                            IWorkbook workbook = application.Workbooks.Open(inputStream, ExcelOpenType.Automatic);
                            IWorksheet worksheet = workbook.Worksheets[0];

                            ITemplateMarkersProcessor marker = workbook.CreateTemplateMarkersProcessor();

                            marker.AddVariable("NgayThangNam", DateTime.Now.ToString("dd/MM/yyyy"));
                            marker.AddVariable("TenKhach", excelData.TenKhach);
                            marker.AddVariable("SoNguoiO", excelData.SoNguoiO.ToString());
                            marker.AddVariable("NgayDat", excelData.NgayDat.ToString("dd/MM/yyyy"));
                            marker.AddVariable("NgayTra", excelData.NgayTra.ToString("dd/MM/yyyy"));
                            marker.AddVariable("DatPhongCT", excelData.DatPhongCT);
                            marker.AddVariable("DatPhongCTSP", excelData.DatPhongCTSP);
                            marker.AddVariable("TongTien", excelData.TongTien.ToString("C2", new System.Globalization.CultureInfo("vi-VN")));
                            marker.AddVariable("NgayThangNam_Bottom", "TP.HCM, Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year);
                            marker.AddVariable("TenNV", excelData.TenNV);
                            marker.AddVariable("GhiChu", excelData.GhiChu);
                            marker.AddVariable("TenPhong", excelData.DatPhongCT.Select(x => x.TENPHONG).ToList());
                            marker.ApplyMarkers();

                            using (FileStream outputStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                            {
                                workbook.SaveAs(outputStream);
                            }
                        }
                    }

                    MessageBox.Show("Xuất báo cáo thành công!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi xuất file: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để in!");
            }
        }
    }
}
