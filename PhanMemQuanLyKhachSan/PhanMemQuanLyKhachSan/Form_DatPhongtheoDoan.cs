using BLL;
using BunifuAnimatorNS;
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
    public partial class Form_DatPhongtheoDoan : Form
    {
        KhachHangBLL _khachhangBLL = new KhachHangBLL();
        SanPhamBLL _sanphamBLL = new SanPhamBLL();
        PhongBLL _phongBLL = new PhongBLL();
        KhachHangBLL _khachHangBLL = new KhachHangBLL();
        DatPhongBLL _datPhongBLL = new DatPhongBLL();
        DatPhong_CTBLL _datPhongChiTietBLL = new DatPhong_CTBLL();  
        DatPhong_SPBLL _chiTietSanPhamBLL = new DatPhong_SPBLL();

        private bool _btnThem = false;
        private DataTable dtableDatPhong;
        private DataTable dtableSanPham;
        private Form_Main form;
        private List<int> removedProductIds = new List<int>();
        private Dictionary<int, DataTable> danhSachSanPhamTheoPhong = new Dictionary<int, DataTable>();
        private List<AvailableRoomDTO> availableRooms = new List<AvailableRoomDTO>();
        private List<AvailableRoomDTO> bookedRooms = new List<AvailableRoomDTO>();
        private bool isRightClick = false;

        public Form_DatPhongtheoDoan(Form_Main form)
        {
            InitializeComponent();
            this.form = form;
            dgvDanhSach.ContextMenuStrip = menuForButton;
            dgvDanhSach.MouseDown += dgvDanhSach_MouseDown;
            menuForButton.ItemClicked += menuForButton_ItemClicked;
        }

        private void dgvDanhSach_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isRightClick = true;

                var hitTest = dgvDanhSach.HitTest(e.X, e.Y);

                if (hitTest.RowIndex >= 0)
                {
                    dgvDanhSach.ClearSelection();

                    string idDP = dgvDanhSach.Rows[hitTest.RowIndex].Cells["idDP"].Value.ToString();

                    menuForButton.Tag = idDP;

                    menuForButton.Show(dgvDanhSach, e.Location);
                }
            }
        }


        private void menuForButton_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Trả phòng")
            {
                string idDP = menuForButton.Tag.ToString();

                int idDatPhong = int.Parse(idDP);

                MessageBox.Show($"Bạn đã chọn trả phòng với idDP: {idDP}");

                string thanhToan = _datPhongBLL.getTienThanhToan(idDatPhong);

                if (thanhToan != null)
                {
                    double soTien = double.Parse(thanhToan);

                    string soTienVND = soTien.ToString("C0", new System.Globalization.CultureInfo("vi-VN"));

                    DialogResult result = MessageBox.Show(
                        $"Bạn cần thanh toán số tiền {soTienVND}",
                        "Thông báo",
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        bool updateThanhToan = _datPhongBLL.UpdateThanhToan(idDatPhong);
                        if (updateThanhToan)
                        {
                            var danhSachPhong = _datPhongBLL.LayDanhSachPhongByIdDP(idDatPhong);

                            foreach (var phong in danhSachPhong)
                            {
                                bool updateTrangThaiPhong = _datPhongBLL.CapNhatTrangThaiPhong(phong.idPhong); 

                                if (!updateTrangThaiPhong)
                                {
                                    MessageBox.Show($"Cập nhật trạng thái phòng {phong.tenPhong} thất bại.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            MessageBox.Show("Đơn đặt phòng đã được thanh toán và các phòng đã được cập nhật trạng thái!", "Thông báo thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadDanhSachDatPhong();
                            form.showRoom();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật trạng thái thanh toán thất bại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        MessageBox.Show("Bạn chưa thực hiện thanh toán!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }



            }
        }

        private void Form_DatPhongtheoDoan_Load(object sender, EventArgs e)
        {
            showHideControl(true);
            enableControl(false);
            loadComboboxKhachHang();
            loadDanhSachSanPham();
            loadTrangThai();
            loadDanhSachPhongTrong();
            loadDanhSachDatPhong();
            initDGVDSPhongDat();
            initDGVDSSPDV();
        }

        private void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnSua.Visible = t;
            btnXoaDatPhong.Visible = t;
            btnThoat.Visible = t;
            btnLuu.Visible = !t;
            btnBoQua.Visible = !t;
        }
        private void enableControl(bool t)
        {
            cbKhachHang.Enabled = t;
            cbTrangThai.Enabled = t;
            dtpNgayDat.Enabled = t;
            dtpNgayTra.Enabled = t;
            nbrSoNguoiO.Enabled = t;
            txtGhiChu.Enabled = t;
            btnThemMoi.Enabled = t;
            btnThanhTien.Enabled = t;
            txtThanhTien.Enabled= t;
            dgvDanhSachPhongTrong.Enabled = t;
            dgvSanPhamDichVu.Enabled = t;
            btnChuyen.Enabled = t;
            btnHuySanPham.Enabled = t;
            btnThemSanPham.Enabled = t;
            btnTroVe.Enabled = t;
        }
        private void reFresh()
        {
            dtpNgayDat.Value = DateTime.Now;
            dtpNgayTra.Value = DateTime.Now;
            nbrSoNguoiO.Value = nbrSoNguoiO.Minimum;
            cbKhachHang.SelectedIndex = 0;
            cbTrangThai.SelectedValue = false;
            txtGhiChu.Text = "";
            txtThanhTien.Text = "0";
            dgvDanhSachPhongDat.DataSource = null;
            dgvDanhSachSPDV.DataSource = null;
            danhSachSanPhamTheoPhong.Clear();
        }

        public void loadComboboxKhachHang()
        {
            List<KhachHangDTO> list = _khachhangBLL.getDanhSachKhachHang();

            if (list == null || list.Count == 0)
            {
                MessageBox.Show("Không có khách hàng nào trong danh sách!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cbKhachHang.DataSource = list;
            cbKhachHang.DisplayMember = "hoTen";
            cbKhachHang.ValueMember = "idKH";
        }

        private void loadDanhSachPhongTrong()
        {
            DataTable dtable = new DataTable();
            dtable.Columns.Add(new DataColumn("Mã Tầng")); 
            dtable.Columns.Add(new DataColumn("Mã Phòng")); 
            dtable.Columns.Add(new DataColumn("Tên Tầng")); 
            dtable.Columns.Add(new DataColumn("Tên Phòng"));
            dtable.Columns.Add(new DataColumn("Đơn Giá")); 

            DataTable rooms = _phongBLL.getDanhSachPhongConTrong();

            foreach (DataRow room in rooms.Rows) 
            {
                object[] RowValues = { room["Mã Tầng"], room["Mã Phòng"], room["Tên Tầng"], room["Tên Phòng"], room["Đơn Giá"] }; 
                dtable.Rows.Add(RowValues);
            }

            dgvDanhSachPhongTrong.DataSource = dtable;
            dgvDanhSachPhongTrong.Columns[0].Visible = false;
            dgvDanhSachPhongTrong.Columns[1].Visible = false; 

            dgvDanhSachPhongTrong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void loadTrangThai()
        {
            var trangThaiList = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string> ( 0,"Chưa hoàn tất" ),
                new KeyValuePair<int, string> ( 1,"Hoàn tất" )
            };

            cbTrangThai.DisplayMember = "Value";
            cbTrangThai.ValueMember = "Key";

            cbTrangThai.DataSource = trangThaiList;
        }

        private void loadDanhSachSanPham()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã sản phẩm");
            table.Columns.Add("Tên sản phẩm");
            table.Columns.Add("Giá");
            table.Columns.Add("Disable");

            DataTable sanphams = _sanphamBLL.getDanhSachSanPham_DataTable();

            foreach(DataRow sanpham in sanphams.Rows)
            {
                object[] RowValues = { sanpham["Mã sản phẩm"], sanpham["Tên sản phẩm"], sanpham["Giá"], sanpham["Disable"] };
                table.Rows.Add(RowValues);
            }   
            
            dgvSanPhamDichVu.DataSource = table;

            dgvSanPhamDichVu.Columns[0].Visible = false;
            dgvSanPhamDichVu.Columns[3].Visible = false;


            dgvSanPhamDichVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
        private void initDGVDSPhongDat()
        {
            if (dtableDatPhong == null)
            {
                dtableDatPhong = new DataTable();
                dtableDatPhong.Columns.Add(new DataColumn("Mã Tầng", typeof(int)));
                dtableDatPhong.Columns.Add(new DataColumn("Mã Phòng", typeof(int)));
                dtableDatPhong.Columns.Add(new DataColumn("Tên Tầng", typeof(string)));
                dtableDatPhong.Columns.Add(new DataColumn("Tên Phòng", typeof(string)));
                dtableDatPhong.Columns.Add(new DataColumn("Đơn Giá", typeof(decimal)));
            }
        }

        private void initDGVDSSPDV()
        {
            if (dtableSanPham == null)
            {
                dtableSanPham = new DataTable();
                dtableSanPham.Columns.Add(new DataColumn("Mã sản phẩm", typeof(int)));
                dtableSanPham.Columns.Add(new DataColumn("Tên sản phẩm", typeof(string)));
                dtableSanPham.Columns.Add(new DataColumn("Giá", typeof(decimal)));
                dtableSanPham.Columns.Add(new DataColumn("Disable", typeof(bool)));
            }
        }

        private static DateTime getFirstDateInMonth(int year, int month)
        {
            return new DateTime(year, month, 1);
        }

        public void btnThem_Click(object sender, EventArgs e)
        {
            _btnThem = true;
            showHideControl(false);
            enableControl(true);
            reFresh();
            tabControl.SelectedTab = tabChiTiet;
            dtableSanPham.Clear();
            dgvDanhSachSPDV.DataSource = dtableSanPham;
            dtableDatPhong.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _btnThem = false;
            showHideControl(false);
            enableControl(true);
            dtableSanPham.Clear();
            dgvDanhSachSPDV.DataSource = dtableSanPham;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(_btnThem)
            {
                DatPhongDTO datPhongDTO = new DatPhongDTO();
                DatPhong_CTDTO dpctDTO = new DatPhong_CTDTO();
                DatPhong_SPDTO dpsp = new DatPhong_SPDTO();

                datPhongDTO.idKH = (int)cbKhachHang.SelectedValue;
                datPhongDTO.ngayDat = (DateTime)dtpNgayDat.Value;
                datPhongDTO.ngayTra = (DateTime)dtpNgayTra.Value;
                datPhongDTO.soTien = decimal.Parse(txtThanhTien.Text);
                datPhongDTO.soNguoiO = (int)nbrSoNguoiO.Value;
                datPhongDTO.idUser = 1;
                datPhongDTO.status = ((int)cbTrangThai.SelectedValue) == 1;
                datPhongDTO.ghiChu = txtGhiChu.Text;
                var _dp = _datPhongBLL.addDatPhong(datPhongDTO);

                if(_dp == null)
                {
                    MessageBox.Show("Phiếu Đặt Phòng chưa được lưu!");
                }    
                else
                {
                    for (int i = 0; i < dgvDanhSachPhongDat.RowCount; i++)
                    {
                        var selectedRow = dgvDanhSachPhongDat.Rows[i];
                        dpctDTO = new DatPhong_CTDTO();
                        dpctDTO.idDP = _dp.idDP;
                        dpctDTO.idPhong = (int)selectedRow.Cells["Mã Phòng"].Value;
                        dpctDTO.soNgayO = (dtpNgayTra.Value - dtpNgayDat.Value).Days;
                        dpctDTO.donGia = (decimal)selectedRow.Cells["Đơn Giá"].Value;
                        dpctDTO.thanhTien = dpctDTO.soNgayO * dpctDTO.donGia;

                        bool kqDPCT = _datPhongChiTietBLL.addDatPhongChiTiet(dpctDTO);

                        if(kqDPCT == false)
                        {
                            MessageBox.Show("Lưu thông tin Chi tiết phòng thất bại!");
                            break;
                        }    
                        else
                        {
                            bool kqCapNhatTrangThaiPhong = _phongBLL.updateTrangThaiPhong(dpctDTO.idPhong, true);

                            if(kqCapNhatTrangThaiPhong == false)
                            {
                                MessageBox.Show("Cập nhật trạng thái Phòng thất bại!");
                                break;
                            }    
                            else
                            {
                                if (danhSachSanPhamTheoPhong.ContainsKey(dpctDTO.idPhong))
                                {
                                    DataTable sanPhamDataTable = danhSachSanPhamTheoPhong[dpctDTO.idPhong];

                                    var sanPhamGroups = sanPhamDataTable.AsEnumerable()
                                            .GroupBy(row => row["Mã Sản Phẩm"])
                                            .Select(g => new
                                            {
                                                idSanPham = (int)g.Key,
                                                soLuong = g.Count(),
                                                donGia = (decimal)g.First()["Giá"]
                                            });

                                    foreach (var sanPhamRow in sanPhamGroups)
                                    {
                                        DatPhong_SPDTO ctspDTO = new DatPhong_SPDTO();
                                        ctspDTO.idDP = dpctDTO.idDP;
                                        ctspDTO.idSP = sanPhamRow.idSanPham;
                                        ctspDTO.idPhong = dpctDTO.idPhong;
                                        ctspDTO.soLuong = sanPhamRow.soLuong;
                                        ctspDTO.donGia = sanPhamRow.donGia;
                                        ctspDTO.thanhTien = ctspDTO.soLuong * ctspDTO.donGia;

                                        bool kqCTSP = _chiTietSanPhamBLL.addChiTietPhongSanPham(ctspDTO);

                                        if(kqCTSP == false)
                                        {
                                            MessageBox.Show("Thêm mới Chi tiết sản phẩm thất bại!");
                                            loadDanhSachDatPhong();
                                            break;
                                        }    
                                    }
                                }
                            }
                            
                        }    
                        
                    }
                }
                MessageBox.Show("Thêm mới đặt phòng thành công!");
                reFresh();
                form.showRoom();
            }   
            else
            {
                bool flag = false;
                if (dgvDanhSach.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvDanhSach.SelectedRows[0];

                    int idDP = (int)selectedRow.Cells["idDP"].Value;

                    DatPhongDTO datPhongDTO = new DatPhongDTO();
                    datPhongDTO.idDP = idDP;
                    datPhongDTO.idKH = (int)cbKhachHang.SelectedValue;
                    datPhongDTO.ngayDat = (DateTime)dtpNgayDat.Value;
                    datPhongDTO.ngayTra = (DateTime)dtpNgayTra.Value;
                    datPhongDTO.soTien = decimal.Parse(txtThanhTien.Text);
                    datPhongDTO.soNguoiO = (int)nbrSoNguoiO.Value;
                    datPhongDTO.idUser = 1;
                    datPhongDTO.status = ((int)cbTrangThai.SelectedValue) == 1;
                    datPhongDTO.ghiChu = txtGhiChu.Text;

                    var updateDP = _datPhongBLL.updateDatPhong(datPhongDTO);

                    if (updateDP)
                    {
                        List<int> existingRoomIds = _datPhongChiTietBLL.getExistingRoomIds(idDP);

                        for (int i = 0; i < dgvDanhSachPhongDat.RowCount; i++)
                        {
                            var selected = dgvDanhSachPhongDat.Rows[i];

                            int idPhong = (int)selected.Cells["Mã Phòng"].Value;

                            DatPhong_CTDTO dpctDTO = new DatPhong_CTDTO
                            {
                                idDP = idDP,
                                idPhong = idPhong,
                                soNgayO = (dtpNgayTra.Value - dtpNgayDat.Value).Days,
                                donGia = (decimal)selected.Cells["Đơn Giá"].Value,
                            };

                            dpctDTO.thanhTien = dpctDTO.soNgayO * dpctDTO.donGia;

                            if (!existingRoomIds.Contains(idPhong))
                            {
                                bool checkAddCTDP = _datPhongChiTietBLL.addDatPhongChiTiet(dpctDTO);
                                if(checkAddCTDP)
                                {
                                    bool checkUpdateTrangThaiPhong = _phongBLL.updateTrangThaiPhong(idPhong, true);

                                    if(!checkUpdateTrangThaiPhong)
                                    {
                                        MessageBox.Show("Cập nhật Trạng thái phòng thất bại!");
                                        flag = true;
                                        return;
                                    }    
                                    else
                                    {
                                        form.showRoom();
                                    }    

                                }
                                else
                                {
                                    MessageBox.Show("Thêm Chi tiết phòng thất bại!");
                                    flag = true;
                                    return;
                                }    
                            }
                            else
                            {
                                bool checkUpdateChiTiet = _datPhongChiTietBLL.updateDatPhongChiTiet(dpctDTO);

                                if(checkUpdateChiTiet)
                                {
                                    existingRoomIds.Remove(idPhong);
                                }   
                                else
                                {
                                    MessageBox.Show("Cập nhật thông tin Chi tiết đặt phòng thất bại!");
                                    flag = true;
                                    return;
                                }     
                            }

                            if (danhSachSanPhamTheoPhong.ContainsKey(idPhong))
                            {
                                var sanPhamDataTable = danhSachSanPhamTheoPhong[idPhong];
                                var sanPhamGroups = sanPhamDataTable.AsEnumerable()
                                    .GroupBy(row => row["Mã Sản Phẩm"])
                                    .Select(g => new
                                    {
                                        idSanPham = Convert.ToInt32(g.Key),
                                        soLuong = g.Count(),
                                        donGia = Convert.ToDecimal(g.First()["Giá"])
                                    });

                                foreach (var sanPhamRow in sanPhamGroups)
                                {
                                    DatPhong_SPDTO ctspDTO = new DatPhong_SPDTO
                                    {
                                        idDP = dpctDTO.idDP,
                                        idSP = sanPhamRow.idSanPham,
                                        idPhong = idPhong,
                                        soLuong = sanPhamRow.soLuong,
                                        donGia = sanPhamRow.donGia,
                                    };

                                    ctspDTO.thanhTien = ctspDTO.soLuong * ctspDTO.donGia;

                                    bool isExistingProduct = _chiTietSanPhamBLL.checkIfProductExists(ctspDTO.idDP, ctspDTO.idSP, idPhong);

                                    if (isExistingProduct)
                                    {
                                        bool updateChiTietSanPham = _chiTietSanPhamBLL.updateChiTietPhongSanPham(ctspDTO);

                                        if (!updateChiTietSanPham)
                                        {
                                            MessageBox.Show("Cập nhật thông tin chi tiết sản phẩm thất bại!");
                                            flag = true;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        _chiTietSanPhamBLL.addChiTietPhongSanPham(ctspDTO);
                                    }
                                }
                            }

                        }

                        foreach (int idPhongToRemove in existingRoomIds)
                        {
                            bool checkDeleteCTDP = _datPhongChiTietBLL.deleteDatPhongChiTiet(idDP, idPhongToRemove);

                            if(checkDeleteCTDP)
                            {
                                bool updateTrangThaiPhong = _phongBLL.updateTrangThaiPhong(idPhongToRemove, false);

                                if(!updateTrangThaiPhong)
                                {
                                    MessageBox.Show("Cập nhật Trạng thái phòng thất bại!");
                                    flag = true;
                                    return;
                                }    
                                else
                                {
                                    bool checkDeleteCTSP = _chiTietSanPhamBLL.deleteAllSanPhamByRoom(idDP, idPhongToRemove);

                                    if (!checkDeleteCTSP)
                                    {
                                        MessageBox.Show("Xóa thông tin Chi tiết sản phẩm thất bại!");
                                        flag = true;
                                        return;
                                    }
                                    form.showRoom();
                                }    
                            }    
                            else
                            {
                                MessageBox.Show("Xóa thông tin Chi tiết đặt phòng thất bại!");
                                flag = true;
                                return;
                            }    
                        }
                        if(flag == false)
                        {
                            MessageBox.Show("Cập nhật thông tin Phiếu đặt thành công!");
                            reFresh();
                        }    
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin Phiếu đặt phòng thất bại!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một Phiếu đặt phòng để chỉnh sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            showHideControl(true);
            enableControl(false);
            _btnThem = false;
            tabControl.SelectedTab = tabDanhSach;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            Form_KhachHang form = new Form_KhachHang(this);
            form.ShowDialog();
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachPhongTrong.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một phòng để đặt!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRows = new List<DataGridViewRow>();

            foreach (DataGridViewRow selectedRow in dgvDanhSachPhongTrong.SelectedRows)
            {
                DataRow roomRow = ((DataRowView)selectedRow.DataBoundItem).Row;

                dtableDatPhong.ImportRow(roomRow);

                selectedRows.Add(selectedRow);
            }

            foreach (var row in selectedRows)
            {
                dgvDanhSachPhongTrong.Rows.Remove(row);
            }

            if(dgvDanhSachPhongDat.DataSource == null)
            {
                dgvDanhSachPhongDat.DataSource = dtableDatPhong;
                dgvDanhSachPhongDat.Refresh();
            }    
            

            dgvDanhSachPhongDat.Columns[0].Visible = false;
            dgvDanhSachPhongDat.Columns[1].Visible = false;
            dgvDanhSachPhongDat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachPhongDat.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một phòng để trở về!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtDatPhong = (DataTable)dgvDanhSachPhongDat.DataSource;
            DataTable dtPhongTrong = (DataTable)dgvDanhSachPhongTrong.DataSource;

            List<object[]> rowsToReturn = new List<object[]>();

            List<int> selectedPhongIds = new List<int>();

            foreach (DataGridViewRow selectedRow in dgvDanhSachPhongDat.SelectedRows)
            {
                int maPhong = (int)selectedRow.Cells["Mã Phòng"].Value;
                selectedPhongIds.Add(maPhong); 

                object[] rowValues = new object[dtDatPhong.Columns.Count];
                for (int i = 0; i < dtDatPhong.Columns.Count; i++)
                {
                    rowValues[i] = selectedRow.Cells[i].Value;
                }
                rowsToReturn.Add(rowValues);
            }

            foreach (int maPhong in selectedPhongIds)
            {
                if (danhSachSanPhamTheoPhong.ContainsKey(maPhong))
                {
                    danhSachSanPhamTheoPhong.Remove(maPhong); 
                }
            }

            foreach (DataGridViewRow selectedRow in dgvDanhSachPhongDat.SelectedRows)
            {
                dtDatPhong.Rows.RemoveAt(selectedRow.Index);
            }

            foreach (var rowValues in rowsToReturn)
            {
                bool exists = false;
                foreach (DataRow existingRow in dtPhongTrong.Rows)
                {
                    if (existingRow["Mã Phòng"].Equals(rowValues[1]))
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    DataRow newRow = dtPhongTrong.NewRow();
                    newRow["Mã Tầng"] = rowValues[0];
                    newRow["Mã Phòng"] = rowValues[1];
                    newRow["Tên Tầng"] = rowValues[2];
                    newRow["Tên Phòng"] = rowValues[3];
                    newRow["Đơn Giá"] = rowValues[4];
                    dtPhongTrong.Rows.Add(newRow);
                }
            }

            dgvDanhSachPhongDat.DataSource = dtDatPhong;
            dgvDanhSachPhongTrong.DataSource = dtPhongTrong;

            if (selectedPhongIds.Count > 0)
            {
                int firstPhongId = selectedPhongIds[0]; 
                if (danhSachSanPhamTheoPhong.ContainsKey(firstPhongId))
                {
                    dgvDanhSachSPDV.DataSource = danhSachSanPhamTheoPhong[firstPhongId];
                }
                else
                {
                    dgvDanhSachSPDV.DataSource = null; 
                }
            }
            else
            {
                dgvDanhSachSPDV.DataSource = null;
            }

            dgvDanhSachPhongTrong.Columns[0].Visible = false;
            dgvDanhSachPhongTrong.Columns[1].Visible = false;
            dgvDanhSachPhongTrong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachPhongDat.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một phòng để thêm sản phẩm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvSanPhamDichVu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất sản phẩm để thêm vào phòng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPhong = (int)dgvDanhSachPhongDat.SelectedRows[0].Cells["Mã Phòng"].Value;

            if (!danhSachSanPhamTheoPhong.ContainsKey(idPhong))
            {
                DataTable dtSanPham = new DataTable();
                dtSanPham.Columns.Add("Mã Sản Phẩm", typeof(int));
                dtSanPham.Columns.Add("Tên Sản Phẩm", typeof(string));
                dtSanPham.Columns.Add("Giá", typeof(decimal)); // Cột Đơn Giá
                dtSanPham.Columns.Add("Số lượng", typeof(int)); // Cột Số lượng
                dtSanPham.Columns.Add("Disable", typeof(bool)); // Cột Disable thêm vào để tránh lỗi

                danhSachSanPhamTheoPhong[idPhong] = dtSanPham;
            }

            DataTable dtSanPhamPhong = danhSachSanPhamTheoPhong[idPhong];

            foreach (DataGridViewRow selectedRow in dgvSanPhamDichVu.SelectedRows)
            {
                DataRow sanPhamRow = ((DataRowView)selectedRow.DataBoundItem).Row;

                int idSP = Convert.ToInt32(sanPhamRow["Mã sản phẩm"]);
                string tenSanPham = sanPhamRow["Tên sản phẩm"].ToString();
                decimal donGia = Convert.ToDecimal(sanPhamRow["Giá"]);

                int soLuong = 1;  // Giá trị mặc định cho số lượng (có thể thay đổi nếu cần)

                // Thêm Tên Sản Phẩm, Đơn Giá và Số Lượng vào dtSanPhamPhong
                dtSanPhamPhong.Rows.Add(idSP, tenSanPham, donGia, soLuong);
            }

            // Cập nhật DataGridView với dữ liệu mới
            dgvDanhSachSPDV.DataSource = dtSanPhamPhong;

            // Kiểm tra xem cột "Disable" có tồn tại không trước khi thực hiện việc ẩn
            if (dgvDanhSachSPDV.Columns.Contains("Disable"))
            {
                dgvDanhSachSPDV.Columns["Disable"].Visible = false;  // Ẩn cột "Disable"
            }

            // Ẩn các cột không cần thiết
            dgvDanhSachSPDV.Columns["Mã Sản Phẩm"].Visible = false;  // Ẩn cột "Mã Sản Phẩm"

            // Hiển thị cột "Tên Sản Phẩm", "Đơn Giá" và "Số Lượng"
            dgvDanhSachSPDV.Columns["Tên Sản Phẩm"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDanhSachSPDV.Columns["Giá"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDanhSachSPDV.Columns["Số lượng"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvDanhSachSPDV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }






        private void btnHuySanPham_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDanhSach.SelectedRows[0];
                int idDP = (int)selectedRow.Cells["idDP"].Value;

                if (dgvDanhSachSPDV.SelectedRows.Count == 0)    
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm để hủy bỏ lựa chọn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idPhong = (int)dgvDanhSachPhongDat.SelectedRows[0].Cells["Mã Phòng"].Value;

                if (danhSachSanPhamTheoPhong.ContainsKey(idPhong))
                {
                    DataTable dtSanPhamPhong = danhSachSanPhamTheoPhong[idPhong];

                    foreach (DataGridViewRow selectedRowSP in dgvDanhSachSPDV.SelectedRows)
                    {
                        int idSanPham = (int)selectedRowSP.Cells["Mã sản phẩm"].Value;
                        var sanPhamRow = dtSanPhamPhong.AsEnumerable().FirstOrDefault(row => (int)row["Mã sản phẩm"] == idSanPham);

                        if (sanPhamRow != null)
                        {
                            if (sanPhamRow["Số lượng"] != DBNull.Value)
                            {
                                int soLuong;
                                if (int.TryParse(sanPhamRow["Số lượng"].ToString(), out soLuong))
                                {
                                    if (soLuong > 1)
                                    {
                                        sanPhamRow["Số lượng"] = soLuong - 1;
                                    }
                                    else
                                    {
                                        var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                                        if (confirmResult == DialogResult.Yes)
                                        {
                                            removedProductIds.Add(idSanPham);
                                            dtSanPhamPhong.Rows.Remove(sanPhamRow);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Số lượng sản phẩm không hợp lệ.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Số lượng sản phẩm không được để trống.");
                            }
                        }

                    }

                    dgvDanhSachSPDV.DataSource = dtSanPhamPhong;
                }

                foreach (int idSanPham in removedProductIds)
                {
                    bool isSanPhamInPhieuDat = _chiTietSanPhamBLL.IsSanPhamInPhieuDat(idDP, idSanPham);

                    if (!isSanPhamInPhieuDat)
                    {
                        continue;
                    }

                    bool checkDeleteCTSP = _chiTietSanPhamBLL.deleteSanPhamByRoom(idDP, idSanPham);

                    if (!checkDeleteCTSP)
                    {
                        MessageBox.Show("Xóa thông tin Chi tiết sản phẩm thất bại!");
                        return;
                    }
                }

                removedProductIds.Clear();
            }

            if (dgvDanhSach.SelectedRows.Count > 0)
            {
            }
            else
            {
                if (dgvDanhSachSPDV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm để hủy bỏ lựa chọn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int idPhong = (int)dgvDanhSachPhongDat.SelectedRows[0].Cells["Mã Phòng"].Value;

                if (danhSachSanPhamTheoPhong.ContainsKey(idPhong))
                {
                    DataTable dtSanPhamPhong = danhSachSanPhamTheoPhong[idPhong];

                    foreach (DataGridViewRow selectedRowSP in dgvDanhSachSPDV.SelectedRows)
                    {
                        int idSanPham = (int)selectedRowSP.Cells["Mã sản phẩm"].Value;
                        var sanPhamRow = dtSanPhamPhong.AsEnumerable().FirstOrDefault(row => (int)row["Mã sản phẩm"] == idSanPham);

                        if (sanPhamRow != null)
                        {
                            if (sanPhamRow["Số lượng"] != DBNull.Value)
                            {
                                int soLuong;
                                if (int.TryParse(sanPhamRow["Số lượng"].ToString(), out soLuong))
                                {
                                    if (soLuong > 1)
                                    {
                                        sanPhamRow["Số lượng"] = soLuong - 1;
                                    }
                                    else
                                    {
                                        var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                                        if (confirmResult == DialogResult.Yes)
                                        {
                                            removedProductIds.Add(idSanPham);
                                            dtSanPhamPhong.Rows.Remove(sanPhamRow);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Số lượng sản phẩm không hợp lệ.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Số lượng sản phẩm không được để trống.");
                            }
                        }

                    }

                    dgvDanhSachSPDV.DataSource = dtSanPhamPhong;
                }
            }
        }




        private void dgvDanhSachPhongDat_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSachPhongDat.SelectedRows.Count > 0)
            {
                int idPhong = (int)dgvDanhSachPhongDat.SelectedRows[0].Cells["Mã Phòng"].Value;

                if (danhSachSanPhamTheoPhong.ContainsKey(idPhong))
                {
                    dgvDanhSachSPDV.DataSource = danhSachSanPhamTheoPhong[idPhong];
                }
                else
                {
                    dgvDanhSachSPDV.DataSource = null;
                }

                if (dgvDanhSachSPDV.Columns.Count > 0)
                {
                    dgvDanhSachSPDV.Columns[0].Visible = false;
                }
                if (dgvDanhSachSPDV.Columns.Count > 3)
                {
                    dgvDanhSachSPDV.Columns[3].Visible = false;
                }

                dgvDanhSachSPDV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
       
        private void CapNhatTongTien()
        {
            decimal totalAmountPhongDat = 0;
            decimal totalAmountSPDV = 0;

            if (dtpNgayTra.Value <= dtpNgayDat.Value)
            {
                MessageBox.Show("Ngày trả phải lớn hơn ngày đặt ít nhất 1 ngày!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soNgayO = (dtpNgayTra.Value - dtpNgayDat.Value).Days; 

            foreach (DataGridViewRow row in dgvDanhSachPhongDat.Rows)
            {
                if (row.Cells["Đơn Giá"].Value != null)
                {
                    decimal donGia = Convert.ToDecimal(row.Cells["Đơn Giá"].Value); 
                    totalAmountPhongDat += soNgayO * donGia; 
                }
            }

            foreach (var kvp in danhSachSanPhamTheoPhong)
            {
                DataTable dtSanPham = kvp.Value;

                foreach (DataRow dr in dtSanPham.Rows)
                {
                    if (dr["Giá"] != DBNull.Value)
                    {
                        totalAmountSPDV += Convert.ToDecimal(dr["Giá"]);
                    }
                }
            }

            txtThanhTien.Text = (totalAmountPhongDat + totalAmountSPDV).ToString("N2");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        public void setKhachHang(int idKH)
        {
            var _kh = _khachhangBLL.getKhachHangByID(idKH);

            if (_kh != null && cbKhachHang.DataSource != null)
            {
                cbKhachHang.SelectedValue = _kh.idKH;
            }
            else
            {
                MessageBox.Show("Khách hàng không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (isRightClick)
            {
                isRightClick = false;
                return;
            }

            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDanhSach.SelectedRows[0];
                DateTime ngayTra = (DateTime)selectedRow.Cells["NgayTra"].Value; 

                if (ngayTra <= DateTime.Now)
                {
                    MessageBox.Show("Không thể sửa phiếu đặt này vì ngày trả đã qua hạn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dtableSanPham.Clear();
                showHideControl(false);

                dgvDanhSachSPDV.DataSource = dtableSanPham;

                tabControl.SelectedTab = tabChiTiet;

                txtThanhTien.Text = selectedRow.Cells["soTien"].Value.ToString();
                txtGhiChu.Text = selectedRow.Cells["ghiChu"].Value.ToString();
                dtpNgayDat.Value = (DateTime)selectedRow.Cells["ngayDat"].Value;
                dtpNgayTra.Value = (DateTime)selectedRow.Cells["ngayTra"].Value;
                nbrSoNguoiO.Value = (int)selectedRow.Cells["soNguoiO"].Value;

                if (selectedRow.Cells["status"].Value != null && selectedRow.Cells["status"].Value is int status)
                {
                    cbTrangThai.SelectedValue = status;
                }
                else
                {
                    cbTrangThai.SelectedValue = 0;
                }

                cbKhachHang.SelectedValue = (int)selectedRow.Cells["idKH"].Value;

                int idDP = (int)selectedRow.Cells["idDP"].Value;

                loadDanhSachPhongDaDat(idDP);
            }
        }


        private void loadDanhSachPhongDaDat(int idDP)
        {
            dtableDatPhong = _datPhongChiTietBLL.getPhongDetailsByBookingId(idDP);
            dgvDanhSachPhongDat.DataSource = dtableDatPhong;

            dgvDanhSachPhongDat.Columns[0].Visible = false;
            dgvDanhSachPhongDat.Columns[1].Visible = false;
            dgvDanhSachPhongDat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            danhSachSanPhamTheoPhong.Clear();


            foreach (DataRow row in dtableDatPhong.Rows)
            {
                int idPhong = (int)row["Mã Phòng"];
                DataTable dtSanPham = _chiTietSanPhamBLL.getDanhSachSanPhamTheoPhong(idPhong, idDP);

                DataTable dtSanPhamForRoom = new DataTable();
                dtSanPhamForRoom.Columns.Add("Mã sản phẩm", typeof(int));
                dtSanPhamForRoom.Columns.Add("Tên sản phẩm", typeof(string));
                dtSanPhamForRoom.Columns.Add("Giá", typeof(decimal));
                dtSanPhamForRoom.Columns.Add("Số lượng", typeof(int));

                foreach (DataRow productRow in dtSanPham.Rows)
                {
                    int idSP = Convert.ToInt32(productRow["Mã sản phẩm"]);
                    string tenSanPham = productRow["Tên sản phẩm"].ToString();
                    decimal donGia = Convert.ToDecimal(productRow["Giá"]);
                    int soLuong = Convert.ToInt32(productRow["Số lượng"]);

                    for (int i = 0; i < soLuong; i++)
                    {
                        dtSanPhamForRoom.Rows.Add(idSP, tenSanPham, donGia, 1); 
                    }
                }

                danhSachSanPhamTheoPhong[idPhong] = dtSanPhamForRoom;
            }


        }

        private void btnHuyTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            loadDanhSachDatPhong();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenKhachHang = txtTimKiem.Text.Trim();

            List<DatPhongDTO> filteredList = _datPhongBLL.getDanhSachDatPhong()
                .Where(dp => dp.hoTen.ToLower().Contains(tenKhachHang.ToLower()))
                .ToList();

            dgvDanhSach.DataSource = filteredList;

            if (filteredList.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả nào!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Hãy nhập vào tên khách hàng...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form_GoiYPhong form = new Form_GoiYPhong();
            form.Show();
        }

        private void btnXoaDatPhong_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDanhSach.SelectedRows[0];
                int idDP = (int)selectedRow.Cells["idDP"].Value;

                if (_datPhongBLL.VoHieuHoaPhieuDatPhong(idDP))
                {
                    MessageBox.Show("Bạn đã vô hiệu hóa phiếu đặt thành công");
                    loadDanhSachDatPhong();
                }
                else
                {
                    MessageBox.Show("Vô hiệu hóa phiếu đặt phòng thất bại!");
                }    
            }
        }
    }
}
