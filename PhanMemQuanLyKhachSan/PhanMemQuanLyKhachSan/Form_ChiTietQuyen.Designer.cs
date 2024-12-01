namespace PhanMemQuanLyKhachSan
{
    partial class Form_ChiTietQuyen
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPhanQuyen = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.Label();
            this.btnCapQuyen = new System.Windows.Forms.Button();
            this.btnThuHoi = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanQuyen)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 242);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(694, 34);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thao tác";
            // 
            // dgvPhanQuyen
            // 
            this.dgvPhanQuyen.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhanQuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhanQuyen.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPhanQuyen.Location = new System.Drawing.Point(0, 34);
            this.dgvPhanQuyen.Name = "dgvPhanQuyen";
            this.dgvPhanQuyen.RowHeadersWidth = 51;
            this.dgvPhanQuyen.RowTemplate.Height = 24;
            this.dgvPhanQuyen.Size = new System.Drawing.Size(694, 208);
            this.dgvPhanQuyen.TabIndex = 0;
            this.dgvPhanQuyen.Tag = "Form_NhomNguoiDung";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnThuHoi);
            this.panel1.Controls.Add(this.btnCapQuyen);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgvPhanQuyen);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 342);
            this.panel1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(694, 34);
            this.panel3.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(3, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(61, 22);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "Name";
            // 
            // btnCapQuyen
            // 
            this.btnCapQuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapQuyen.Location = new System.Drawing.Point(165, 295);
            this.btnCapQuyen.Name = "btnCapQuyen";
            this.btnCapQuyen.Size = new System.Drawing.Size(138, 30);
            this.btnCapQuyen.TabIndex = 5;
            this.btnCapQuyen.Text = "Cấp quyền";
            this.btnCapQuyen.UseVisualStyleBackColor = true;
            this.btnCapQuyen.Click += new System.EventHandler(this.btnCapQuyen_Click);
            // 
            // btnThuHoi
            // 
            this.btnThuHoi.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnThuHoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThuHoi.ForeColor = System.Drawing.Color.White;
            this.btnThuHoi.Location = new System.Drawing.Point(380, 295);
            this.btnThuHoi.Name = "btnThuHoi";
            this.btnThuHoi.Size = new System.Drawing.Size(138, 30);
            this.btnThuHoi.TabIndex = 6;
            this.btnThuHoi.Text = "Thu hồi";
            this.btnThuHoi.UseVisualStyleBackColor = false;
            this.btnThuHoi.Click += new System.EventHandler(this.btnThuHoi_Click);
            // 
            // Form_ChiTietQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 342);
            this.Controls.Add(this.panel1);
            this.Name = "Form_ChiTietQuyen";
            this.Text = "Form_ChiTietQuyen";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanQuyen)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPhanQuyen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Button btnThuHoi;
        private System.Windows.Forms.Button btnCapQuyen;
    }
}