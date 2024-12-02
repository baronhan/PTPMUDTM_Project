namespace PhanMemQuanLyKhachSan
{
    partial class Form_ThongKeDichVu
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
            this.panelTimKiem = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDen = new System.Windows.Forms.DateTimePicker();
            this.dtpTu = new System.Windows.Forms.DateTimePicker();
            this.btnHuyTimKiem = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDoanhThu = new System.Windows.Forms.Label();
            this.dgvDSDichVu = new System.Windows.Forms.DataGridView();
            this.txtSoLuongKhach = new System.Windows.Forms.Label();
            this.panelTimKiem.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDichVu)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTimKiem
            // 
            this.panelTimKiem.BackColor = System.Drawing.Color.White;
            this.panelTimKiem.Controls.Add(this.label2);
            this.panelTimKiem.Controls.Add(this.label1);
            this.panelTimKiem.Controls.Add(this.dtpDen);
            this.panelTimKiem.Controls.Add(this.dtpTu);
            this.panelTimKiem.Controls.Add(this.btnHuyTimKiem);
            this.panelTimKiem.Controls.Add(this.btnLoc);
            this.panelTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTimKiem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTimKiem.Location = new System.Drawing.Point(0, 0);
            this.panelTimKiem.Name = "panelTimKiem";
            this.panelTimKiem.Size = new System.Drawing.Size(1317, 73);
            this.panelTimKiem.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(735, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Đến:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Từ:";
            // 
            // dtpDen
            // 
            this.dtpDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDen.Location = new System.Drawing.Point(795, 23);
            this.dtpDen.Name = "dtpDen";
            this.dtpDen.Size = new System.Drawing.Size(200, 27);
            this.dtpDen.TabIndex = 5;
            // 
            // dtpTu
            // 
            this.dtpTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTu.Location = new System.Drawing.Point(481, 23);
            this.dtpTu.Name = "dtpTu";
            this.dtpTu.Size = new System.Drawing.Size(200, 27);
            this.dtpTu.TabIndex = 4;
            // 
            // btnHuyTimKiem
            // 
            this.btnHuyTimKiem.BackColor = System.Drawing.Color.LightCoral;
            this.btnHuyTimKiem.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnHuyTimKiem.Location = new System.Drawing.Point(1189, 13);
            this.btnHuyTimKiem.Name = "btnHuyTimKiem";
            this.btnHuyTimKiem.Size = new System.Drawing.Size(103, 42);
            this.btnHuyTimKiem.TabIndex = 2;
            this.btnHuyTimKiem.Text = "Hủy";
            this.btnHuyTimKiem.UseVisualStyleBackColor = false;
            this.btnHuyTimKiem.Click += new System.EventHandler(this.btnHuyTimKiem_Click);
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLoc.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(1069, 14);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(103, 42);
            this.btnLoc.TabIndex = 1;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 414);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1317, 55);
            this.panel2.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Thông tin thống kê";
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDanhSach.Location = new System.Drawing.Point(0, 73);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.RowTemplate.Height = 24;
            this.dgvDanhSach.Size = new System.Drawing.Size(1317, 341);
            this.dgvDanhSach.TabIndex = 10;
            this.dgvDanhSach.Tag = "Form_NhomNguoiDung";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtSoLuongKhach);
            this.panel1.Controls.Add(this.txtDoanhThu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 610);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1317, 46);
            this.panel1.TabIndex = 12;
            // 
            // txtDoanhThu
            // 
            this.txtDoanhThu.AutoSize = true;
            this.txtDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoanhThu.ForeColor = System.Drawing.Color.Red;
            this.txtDoanhThu.Location = new System.Drawing.Point(12, 52);
            this.txtDoanhThu.Name = "txtDoanhThu";
            this.txtDoanhThu.Size = new System.Drawing.Size(0, 29);
            this.txtDoanhThu.TabIndex = 0;
            this.txtDoanhThu.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvDSDichVu
            // 
            this.dgvDSDichVu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDSDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSDichVu.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDSDichVu.Location = new System.Drawing.Point(0, 469);
            this.dgvDSDichVu.Name = "dgvDSDichVu";
            this.dgvDSDichVu.RowHeadersWidth = 51;
            this.dgvDSDichVu.RowTemplate.Height = 24;
            this.dgvDSDichVu.Size = new System.Drawing.Size(1317, 141);
            this.dgvDSDichVu.TabIndex = 14;
            // 
            // txtSoLuongKhach
            // 
            this.txtSoLuongKhach.AutoSize = true;
            this.txtSoLuongKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuongKhach.ForeColor = System.Drawing.Color.Red;
            this.txtSoLuongKhach.Location = new System.Drawing.Point(904, 13);
            this.txtSoLuongKhach.Name = "txtSoLuongKhach";
            this.txtSoLuongKhach.Size = new System.Drawing.Size(231, 22);
            this.txtSoLuongKhach.TabIndex = 2;
            this.txtSoLuongKhach.Text = "Số lượng loại sản phẩm: ";
            // 
            // Form_ThongKeDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 663);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDSDichVu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.panelTimKiem);
            this.Name = "Form_ThongKeDichVu";
            this.Tag = "Form_ThongKeDichVu";
            this.Text = "Form_ThongKeDichVu";
            this.panelTimKiem.ResumeLayout(false);
            this.panelTimKiem.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDichVu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDen;
        private System.Windows.Forms.DateTimePicker dtpTu;
        private System.Windows.Forms.Button btnHuyTimKiem;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtDoanhThu;
        private System.Windows.Forms.DataGridView dgvDSDichVu;
        private System.Windows.Forms.Label txtSoLuongKhach;
    }
}