namespace PhanMemQuanLyKhachSan
{
    partial class Form_LoaiPhong
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnBoQua = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSoGiuong = new System.Windows.Forms.Label();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblSoNguoi = new System.Windows.Forms.Label();
            this.ckDisable = new System.Windows.Forms.CheckBox();
            this.nbrSoGiuong = new System.Windows.Forms.NumericUpDown();
            this.nbrDonGia = new System.Windows.Forms.NumericUpDown();
            this.nbrSoNguoi = new System.Windows.Forms.NumericUpDown();
            this.txtTenLoaiPhong = new System.Windows.Forms.TextBox();
            this.lblTenLoaiPhong = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDSLoaiPhong = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrSoGiuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrDonGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrSoNguoi)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSLoaiPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThem,
            this.btnXoa,
            this.btnSua,
            this.btnLuu,
            this.btnBoQua,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(855, 47);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnThem
            // 
            this.btnThem.Image = global::PhanMemQuanLyKhachSan.Properties.Resources.add_icon;
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(50, 44);
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = global::PhanMemQuanLyKhachSan.Properties.Resources.update_icon;
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(38, 44);
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = global::PhanMemQuanLyKhachSan.Properties.Resources.delete_icon;
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(39, 44);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::PhanMemQuanLyKhachSan.Properties.Resources.save_icon;
            this.btnLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(37, 44);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Image = global::PhanMemQuanLyKhachSan.Properties.Resources.skip_icon;
            this.btnBoQua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(60, 44);
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblSoGiuong);
            this.panel1.Controls.Add(this.lblDonGia);
            this.panel1.Controls.Add(this.lblSoNguoi);
            this.panel1.Controls.Add(this.ckDisable);
            this.panel1.Controls.Add(this.nbrSoGiuong);
            this.panel1.Controls.Add(this.nbrDonGia);
            this.panel1.Controls.Add(this.nbrSoNguoi);
            this.panel1.Controls.Add(this.txtTenLoaiPhong);
            this.panel1.Controls.Add(this.lblTenLoaiPhong);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgvDSLoaiPhong);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(855, 421);
            this.panel1.TabIndex = 1;
            // 
            // lblSoGiuong
            // 
            this.lblSoGiuong.AutoSize = true;
            this.lblSoGiuong.Location = new System.Drawing.Point(381, 353);
            this.lblSoGiuong.Name = "lblSoGiuong";
            this.lblSoGiuong.Size = new System.Drawing.Size(68, 16);
            this.lblSoGiuong.TabIndex = 10;
            this.lblSoGiuong.Text = "Số giường";
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(381, 293);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(53, 16);
            this.lblDonGia.TabIndex = 9;
            this.lblDonGia.Text = "Đơn giá";
            // 
            // lblSoNguoi
            // 
            this.lblSoNguoi.AutoSize = true;
            this.lblSoNguoi.Location = new System.Drawing.Point(52, 353);
            this.lblSoNguoi.Name = "lblSoNguoi";
            this.lblSoNguoi.Size = new System.Drawing.Size(60, 16);
            this.lblSoNguoi.TabIndex = 8;
            this.lblSoNguoi.Text = "Số người";
            // 
            // ckDisable
            // 
            this.ckDisable.AutoSize = true;
            this.ckDisable.Location = new System.Drawing.Point(718, 296);
            this.ckDisable.Name = "ckDisable";
            this.ckDisable.Size = new System.Drawing.Size(76, 20);
            this.ckDisable.TabIndex = 7;
            this.ckDisable.Text = "Disable";
            this.ckDisable.UseVisualStyleBackColor = true;
            // 
            // nbrSoGiuong
            // 
            this.nbrSoGiuong.Location = new System.Drawing.Point(495, 347);
            this.nbrSoGiuong.Name = "nbrSoGiuong";
            this.nbrSoGiuong.Size = new System.Drawing.Size(156, 22);
            this.nbrSoGiuong.TabIndex = 6;
            // 
            // nbrDonGia
            // 
            this.nbrDonGia.Location = new System.Drawing.Point(495, 294);
            this.nbrDonGia.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nbrDonGia.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nbrDonGia.Name = "nbrDonGia";
            this.nbrDonGia.Size = new System.Drawing.Size(156, 22);
            this.nbrDonGia.TabIndex = 5;
            this.nbrDonGia.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            // 
            // nbrSoNguoi
            // 
            this.nbrSoNguoi.Location = new System.Drawing.Point(165, 347);
            this.nbrSoNguoi.Name = "nbrSoNguoi";
            this.nbrSoNguoi.Size = new System.Drawing.Size(169, 22);
            this.nbrSoNguoi.TabIndex = 4;
            // 
            // txtTenLoaiPhong
            // 
            this.txtTenLoaiPhong.Location = new System.Drawing.Point(165, 290);
            this.txtTenLoaiPhong.Name = "txtTenLoaiPhong";
            this.txtTenLoaiPhong.Size = new System.Drawing.Size(169, 22);
            this.txtTenLoaiPhong.TabIndex = 3;
            // 
            // lblTenLoaiPhong
            // 
            this.lblTenLoaiPhong.AutoSize = true;
            this.lblTenLoaiPhong.Location = new System.Drawing.Point(52, 293);
            this.lblTenLoaiPhong.Name = "lblTenLoaiPhong";
            this.lblTenLoaiPhong.Size = new System.Drawing.Size(98, 16);
            this.lblTenLoaiPhong.TabIndex = 2;
            this.lblTenLoaiPhong.Text = "Tên loại Phòng";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 208);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(855, 34);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin";
            // 
            // dgvDSLoaiPhong
            // 
            this.dgvDSLoaiPhong.BackgroundColor = System.Drawing.Color.White;
            this.dgvDSLoaiPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSLoaiPhong.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDSLoaiPhong.Location = new System.Drawing.Point(0, 0);
            this.dgvDSLoaiPhong.Name = "dgvDSLoaiPhong";
            this.dgvDSLoaiPhong.RowHeadersWidth = 51;
            this.dgvDSLoaiPhong.RowTemplate.Height = 24;
            this.dgvDSLoaiPhong.Size = new System.Drawing.Size(855, 208);
            this.dgvDSLoaiPhong.TabIndex = 0;
            this.dgvDSLoaiPhong.SelectionChanged += new System.EventHandler(this.dgvDSLoaiPhong_SelectionChanged);
            // 
            // Form_LoaiPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 468);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form_LoaiPhong";
            this.Text = "Form_LoaiPhong";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrSoGiuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrDonGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrSoNguoi)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSLoaiPhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.ToolStripButton btnBoQua;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvDSLoaiPhong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSoGiuong;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Label lblSoNguoi;
        private System.Windows.Forms.CheckBox ckDisable;
        private System.Windows.Forms.NumericUpDown nbrSoGiuong;
        private System.Windows.Forms.NumericUpDown nbrDonGia;
        private System.Windows.Forms.NumericUpDown nbrSoNguoi;
        private System.Windows.Forms.TextBox txtTenLoaiPhong;
        private System.Windows.Forms.Label lblTenLoaiPhong;
    }
}