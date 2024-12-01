namespace PhanMemQuanLyKhachSan
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.quênMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.DANHMUC = new System.Windows.Forms.ToolStripDropDownButton();
            this.TANG = new System.Windows.Forms.ToolStripMenuItem();
            this.LOAIPHONG = new System.Windows.Forms.ToolStripMenuItem();
            this.PHONG = new System.Windows.Forms.ToolStripMenuItem();
            this.SANPHAM = new System.Windows.Forms.ToolStripMenuItem();
            this.THIETBI = new System.Windows.Forms.ToolStripMenuItem();
            this.PHONG_THIETBI = new System.Windows.Forms.ToolStripMenuItem();
            this.KHACHHANG = new System.Windows.Forms.ToolStripMenuItem();
            this.DATPHONG = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBaoCao = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanelRooms = new System.Windows.Forms.TableLayoutPanel();
            this.menuForButton = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnTraPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.menuForButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator4,
            this.DANHMUC,
            this.toolStripSeparator1,
            this.btnBaoCao,
            this.toolStripSeparator2,
            this.btnThoat,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1104, 47);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quênMậtKhẩuToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(85, 44);
            this.toolStripDropDownButton1.Text = "Hệ thống";
            this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // quênMậtKhẩuToolStripMenuItem
            // 
            this.quênMậtKhẩuToolStripMenuItem.Image = global::PhanMemQuanLyKhachSan.Properties.Resources.forward_icon;
            this.quênMậtKhẩuToolStripMenuItem.Name = "quênMậtKhẩuToolStripMenuItem";
            this.quênMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.quênMậtKhẩuToolStripMenuItem.Text = "Quên mật khẩu";
            this.quênMậtKhẩuToolStripMenuItem.Click += new System.EventHandler(this.quênMậtKhẩuToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Image = global::PhanMemQuanLyKhachSan.Properties.Resources.forward_icon;
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 47);
            // 
            // DANHMUC
            // 
            this.DANHMUC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TANG,
            this.LOAIPHONG,
            this.PHONG,
            this.SANPHAM,
            this.THIETBI,
            this.PHONG_THIETBI,
            this.KHACHHANG,
            this.DATPHONG});
            this.DANHMUC.Image = ((System.Drawing.Image)(resources.GetObject("DANHMUC.Image")));
            this.DANHMUC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DANHMUC.Name = "DANHMUC";
            this.DANHMUC.Size = new System.Drawing.Size(90, 44);
            this.DANHMUC.Tag = "DANHMUC";
            this.DANHMUC.Text = "Danh mục";
            this.DANHMUC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // TANG
            // 
            this.TANG.Image = ((System.Drawing.Image)(resources.GetObject("TANG.Image")));
            this.TANG.Name = "TANG";
            this.TANG.Size = new System.Drawing.Size(289, 26);
            this.TANG.Tag = "TANG";
            this.TANG.Text = "Quản lý Tầng";
            this.TANG.Click += new System.EventHandler(this.TANG_Click);
            // 
            // LOAIPHONG
            // 
            this.LOAIPHONG.Image = ((System.Drawing.Image)(resources.GetObject("LOAIPHONG.Image")));
            this.LOAIPHONG.Name = "LOAIPHONG";
            this.LOAIPHONG.Size = new System.Drawing.Size(289, 26);
            this.LOAIPHONG.Tag = "LOAIPHONG";
            this.LOAIPHONG.Text = "Quản lý Loại phòng";
            this.LOAIPHONG.Click += new System.EventHandler(this.LOAIPHONG_Click);
            // 
            // PHONG
            // 
            this.PHONG.Image = ((System.Drawing.Image)(resources.GetObject("PHONG.Image")));
            this.PHONG.Name = "PHONG";
            this.PHONG.Size = new System.Drawing.Size(289, 26);
            this.PHONG.Tag = "PHONG";
            this.PHONG.Text = "Quản lý Phòng";
            this.PHONG.Click += new System.EventHandler(this.PHONG_Click);
            // 
            // SANPHAM
            // 
            this.SANPHAM.Image = ((System.Drawing.Image)(resources.GetObject("SANPHAM.Image")));
            this.SANPHAM.Name = "SANPHAM";
            this.SANPHAM.Size = new System.Drawing.Size(289, 26);
            this.SANPHAM.Tag = "SANPHAM";
            this.SANPHAM.Text = "Quản lý Sản phẩm";
            this.SANPHAM.Click += new System.EventHandler(this.SANPHAM_Click);
            // 
            // THIETBI
            // 
            this.THIETBI.Image = ((System.Drawing.Image)(resources.GetObject("THIETBI.Image")));
            this.THIETBI.Name = "THIETBI";
            this.THIETBI.Size = new System.Drawing.Size(289, 26);
            this.THIETBI.Tag = "THIETBI";
            this.THIETBI.Text = "Quản lý Thiết bị";
            this.THIETBI.Click += new System.EventHandler(this.THIETBI_Click);
            // 
            // PHONG_THIETBI
            // 
            this.PHONG_THIETBI.Image = ((System.Drawing.Image)(resources.GetObject("PHONG_THIETBI.Image")));
            this.PHONG_THIETBI.Name = "PHONG_THIETBI";
            this.PHONG_THIETBI.Size = new System.Drawing.Size(289, 26);
            this.PHONG_THIETBI.Tag = "PHONG_THIETBI";
            this.PHONG_THIETBI.Text = "Quản lý Thiết bị trong phòng";
            this.PHONG_THIETBI.Click += new System.EventHandler(this.PHONG_THIETBI_Click);
            // 
            // KHACHHANG
            // 
            this.KHACHHANG.Image = ((System.Drawing.Image)(resources.GetObject("KHACHHANG.Image")));
            this.KHACHHANG.Name = "KHACHHANG";
            this.KHACHHANG.Size = new System.Drawing.Size(289, 26);
            this.KHACHHANG.Tag = "KHACHHANG";
            this.KHACHHANG.Text = "Quản lý Khách hàng";
            this.KHACHHANG.Click += new System.EventHandler(this.KHACHHANG_Click);
            // 
            // DATPHONG
            // 
            this.DATPHONG.Image = ((System.Drawing.Image)(resources.GetObject("DATPHONG.Image")));
            this.DATPHONG.Name = "DATPHONG";
            this.DATPHONG.Size = new System.Drawing.Size(289, 26);
            this.DATPHONG.Tag = "DATPHONG";
            this.DATPHONG.Text = "Quản lý Đặt phòng theo đoàn";
            this.DATPHONG.Click += new System.EventHandler(this.DATPHONG_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Image = ((System.Drawing.Image)(resources.GetObject("btnBaoCao.Image")));
            this.btnBaoCao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(67, 44);
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 47);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::PhanMemQuanLyKhachSan.Properties.Resources.exit;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(51, 44);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 47);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanelRooms);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 47);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1104, 533);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanelRooms
            // 
            this.tableLayoutPanelRooms.AutoSize = true;
            this.tableLayoutPanelRooms.ColumnCount = 2;
            this.tableLayoutPanelRooms.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRooms.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRooms.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelRooms.Name = "tableLayoutPanelRooms";
            this.tableLayoutPanelRooms.RowCount = 2;
            this.tableLayoutPanelRooms.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRooms.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRooms.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutPanelRooms.TabIndex = 0;
            // 
            // menuForButton
            // 
            this.menuForButton.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuForButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTraPhong});
            this.menuForButton.Name = "menuForButton";
            this.menuForButton.Size = new System.Drawing.Size(150, 30);
            // 
            // btnTraPhong
            // 
            this.btnTraPhong.Image = global::PhanMemQuanLyKhachSan.Properties.Resources.forward_icon;
            this.btnTraPhong.Name = "btnTraPhong";
            this.btnTraPhong.Size = new System.Drawing.Size(149, 26);
            this.btnTraPhong.Text = "Trả phòng";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 580);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form_Main";
            this.Tag = "Form_Main";
            this.Text = "Quản lý khách sạn";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.menuForButton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnBaoCao;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton DANHMUC;
        private System.Windows.Forms.ToolStripMenuItem TANG;
        private System.Windows.Forms.ToolStripMenuItem LOAIPHONG;
        private System.Windows.Forms.ToolStripMenuItem PHONG;
        private System.Windows.Forms.ToolStripMenuItem DATPHONG;
        private System.Windows.Forms.ToolStripMenuItem SANPHAM;
        private System.Windows.Forms.ToolStripMenuItem PHONG_THIETBI;
        private System.Windows.Forms.ToolStripMenuItem KHACHHANG;
        private System.Windows.Forms.ToolStripMenuItem THIETBI;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRooms;
        private System.Windows.Forms.ContextMenuStrip menuForButton;
        private System.Windows.Forms.ToolStripMenuItem btnTraPhong;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem quênMậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
    }
}