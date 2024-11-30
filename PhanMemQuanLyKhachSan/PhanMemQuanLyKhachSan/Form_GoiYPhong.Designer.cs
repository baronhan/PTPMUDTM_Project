namespace PhanMemQuanLyKhachSan
{
    partial class Form_GoiYPhong
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
            this.dgvDSTang = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGoiY = new System.Windows.Forms.Button();
            this.lblDuDoanKetQua = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nbrSotienchitra = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nbrSoluongkhach = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTenTang = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTang)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrSotienchitra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrSoluongkhach)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDSTang
            // 
            this.dgvDSTang.BackgroundColor = System.Drawing.Color.White;
            this.dgvDSTang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSTang.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDSTang.Location = new System.Drawing.Point(0, 0);
            this.dgvDSTang.Name = "dgvDSTang";
            this.dgvDSTang.RowHeadersWidth = 51;
            this.dgvDSTang.RowTemplate.Height = 24;
            this.dgvDSTang.Size = new System.Drawing.Size(850, 91);
            this.dgvDSTang.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnGoiY);
            this.panel1.Controls.Add(this.lblDuDoanKetQua);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.nbrSotienchitra);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.nbrSoluongkhach);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTenTang);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgvDSTang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 268);
            this.panel1.TabIndex = 7;
            // 
            // btnGoiY
            // 
            this.btnGoiY.Location = new System.Drawing.Point(746, 160);
            this.btnGoiY.Name = "btnGoiY";
            this.btnGoiY.Size = new System.Drawing.Size(73, 29);
            this.btnGoiY.TabIndex = 15;
            this.btnGoiY.Text = "Gợi ý";
            this.btnGoiY.UseVisualStyleBackColor = true;
            this.btnGoiY.Click += new System.EventHandler(this.btnGoiY_Click);
            // 
            // lblDuDoanKetQua
            // 
            this.lblDuDoanKetQua.AutoSize = true;
            this.lblDuDoanKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuDoanKetQua.ForeColor = System.Drawing.Color.IndianRed;
            this.lblDuDoanKetQua.Location = new System.Drawing.Point(182, 222);
            this.lblDuDoanKetQua.Name = "lblDuDoanKetQua";
            this.lblDuDoanKetQua.Size = new System.Drawing.Size(103, 16);
            this.lblDuDoanKetQua.TabIndex = 14;
            this.lblDuDoanKetQua.Text = "Phòng 123, ....";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.IndianRed;
            this.label4.Location = new System.Drawing.Point(52, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Kết quả:";
            // 
            // nbrSotienchitra
            // 
            this.nbrSotienchitra.Location = new System.Drawing.Point(529, 164);
            this.nbrSotienchitra.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nbrSotienchitra.Name = "nbrSotienchitra";
            this.nbrSotienchitra.Size = new System.Drawing.Size(169, 22);
            this.nbrSotienchitra.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(396, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ngân sách :";
            // 
            // nbrSoluongkhach
            // 
            this.nbrSoluongkhach.Location = new System.Drawing.Point(185, 164);
            this.nbrSoluongkhach.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nbrSoluongkhach.Name = "nbrSoluongkhach";
            this.nbrSoluongkhach.Size = new System.Drawing.Size(169, 22);
            this.nbrSoluongkhach.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(198, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(484, 42);
            this.label2.TabIndex = 9;
            this.label2.Text = "Gợi ý đặt phòng theo đoàn";
            // 
            // lblTenTang
            // 
            this.lblTenTang.AutoSize = true;
            this.lblTenTang.Location = new System.Drawing.Point(52, 170);
            this.lblTenTang.Name = "lblTenTang";
            this.lblTenTang.Size = new System.Drawing.Size(102, 16);
            this.lblTenTang.TabIndex = 2;
            this.lblTenTang.Text = "Số lượng khách:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(850, 34);
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
            // Form_GoiYPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 268);
            this.Controls.Add(this.panel1);
            this.Name = "Form_GoiYPhong";
            this.Text = "Form_GoiYPhong";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTang)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrSotienchitra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrSoluongkhach)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSTang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTenTang;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nbrSoluongkhach;
        private System.Windows.Forms.NumericUpDown nbrSotienchitra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDuDoanKetQua;
        private System.Windows.Forms.Button btnGoiY;
    }
}