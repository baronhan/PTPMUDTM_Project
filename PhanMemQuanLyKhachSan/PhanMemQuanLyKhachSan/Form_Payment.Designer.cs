namespace HotelBooking
{
    partial class Form_Payment
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
            this.pic_qrcode = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReturnServiceList = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnCancelPayment = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.pic_qrcode)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic_qrcode
            // 
            this.pic_qrcode.Location = new System.Drawing.Point(383, 124);
            this.pic_qrcode.Name = "pic_qrcode";
            this.pic_qrcode.Size = new System.Drawing.Size(344, 311);
            this.pic_qrcode.TabIndex = 0;
            this.pic_qrcode.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(998, 78);
            this.panel2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mistral", 34.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Tan;
            this.label3.Location = new System.Drawing.Point(422, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 69);
            this.label3.TabIndex = 0;
            this.label3.Text = "Payment";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Tan;
            this.label5.Location = new System.Drawing.Point(372, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 25);
            this.label5.TabIndex = 27;
            this.label5.Text = "Service List";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnReturnServiceList);
            this.panel1.Controls.Add(this.btnCancelPayment);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pic_qrcode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 613);
            this.panel1.TabIndex = 6;
            // 
            // btnReturnServiceList
            // 
            this.btnReturnServiceList.Activecolor = System.Drawing.Color.BurlyWood;
            this.btnReturnServiceList.AutoSize = true;
            this.btnReturnServiceList.BackColor = System.Drawing.Color.Tan;
            this.btnReturnServiceList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReturnServiceList.BorderRadius = 5;
            this.btnReturnServiceList.ButtonText = "    Return Booking";
            this.btnReturnServiceList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturnServiceList.DisabledColor = System.Drawing.Color.Gray;
            this.btnReturnServiceList.Iconcolor = System.Drawing.Color.Transparent;
            this.btnReturnServiceList.Iconimage = global::HotelBooking.Properties.Resources.return_icon;
            this.btnReturnServiceList.Iconimage_right = null;
            this.btnReturnServiceList.Iconimage_right_Selected = null;
            this.btnReturnServiceList.Iconimage_Selected = null;
            this.btnReturnServiceList.IconMarginLeft = 0;
            this.btnReturnServiceList.IconMarginRight = 0;
            this.btnReturnServiceList.IconRightVisible = true;
            this.btnReturnServiceList.IconRightZoom = 0D;
            this.btnReturnServiceList.IconVisible = true;
            this.btnReturnServiceList.IconZoom = 40D;
            this.btnReturnServiceList.IsTab = false;
            this.btnReturnServiceList.Location = new System.Drawing.Point(186, 444);
            this.btnReturnServiceList.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnReturnServiceList.Name = "btnReturnServiceList";
            this.btnReturnServiceList.Normalcolor = System.Drawing.Color.Tan;
            this.btnReturnServiceList.OnHovercolor = System.Drawing.Color.Silver;
            this.btnReturnServiceList.OnHoverTextColor = System.Drawing.Color.White;
            this.btnReturnServiceList.selected = false;
            this.btnReturnServiceList.Size = new System.Drawing.Size(257, 59);
            this.btnReturnServiceList.TabIndex = 44;
            this.btnReturnServiceList.Text = "    Return Booking";
            this.btnReturnServiceList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturnServiceList.Textcolor = System.Drawing.Color.White;
            this.btnReturnServiceList.TextFont = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnServiceList.Click += new System.EventHandler(this.btnReturnServiceList_Click);
            // 
            // btnCancelPayment
            // 
            this.btnCancelPayment.Activecolor = System.Drawing.Color.BurlyWood;
            this.btnCancelPayment.AutoSize = true;
            this.btnCancelPayment.BackColor = System.Drawing.Color.Tan;
            this.btnCancelPayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelPayment.BorderRadius = 5;
            this.btnCancelPayment.ButtonText = "       Cancel Payment";
            this.btnCancelPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelPayment.DisabledColor = System.Drawing.Color.Gray;
            this.btnCancelPayment.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCancelPayment.Iconimage = global::HotelBooking.Properties.Resources.payment_icon;
            this.btnCancelPayment.Iconimage_right = null;
            this.btnCancelPayment.Iconimage_right_Selected = null;
            this.btnCancelPayment.Iconimage_Selected = null;
            this.btnCancelPayment.IconMarginLeft = 0;
            this.btnCancelPayment.IconMarginRight = 0;
            this.btnCancelPayment.IconRightVisible = true;
            this.btnCancelPayment.IconRightZoom = 0D;
            this.btnCancelPayment.IconVisible = true;
            this.btnCancelPayment.IconZoom = 40D;
            this.btnCancelPayment.IsTab = false;
            this.btnCancelPayment.Location = new System.Drawing.Point(558, 444);
            this.btnCancelPayment.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnCancelPayment.Name = "btnCancelPayment";
            this.btnCancelPayment.Normalcolor = System.Drawing.Color.Tan;
            this.btnCancelPayment.OnHovercolor = System.Drawing.Color.Silver;
            this.btnCancelPayment.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCancelPayment.selected = false;
            this.btnCancelPayment.Size = new System.Drawing.Size(257, 59);
            this.btnCancelPayment.TabIndex = 43;
            this.btnCancelPayment.Text = "       Cancel Payment";
            this.btnCancelPayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelPayment.Textcolor = System.Drawing.Color.White;
            this.btnCancelPayment.TextFont = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelPayment.Click += new System.EventHandler(this.btnCancelPayment_Click);
            // 
            // Form_Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 613);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Payment";
            this.Text = "Form_Payment";
            ((System.ComponentModel.ISupportInitialize)(this.pic_qrcode)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_qrcode;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuFlatButton btnReturnServiceList;
        private Bunifu.Framework.UI.BunifuFlatButton btnCancelPayment;
    }
}