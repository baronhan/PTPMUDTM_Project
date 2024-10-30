namespace HotelBooking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtMenu = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.sidebar = new System.Windows.Forms.Panel();
            this.btnCollection = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnHistoryBooking = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnProfile = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnHome = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.flowPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            this.sidebar.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.txtMenu);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1275, 62);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HotelBooking.Properties.Resources.search_icon;
            this.pictureBox2.Location = new System.Drawing.Point(711, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // txtMenu
            // 
            this.txtMenu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMenu.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtMenu.ForeColor = System.Drawing.Color.White;
            this.txtMenu.HintForeColor = System.Drawing.Color.Empty;
            this.txtMenu.HintText = "";
            this.txtMenu.isPassword = false;
            this.txtMenu.LineFocusedColor = System.Drawing.Color.Silver;
            this.txtMenu.LineIdleColor = System.Drawing.Color.White;
            this.txtMenu.LineMouseHoverColor = System.Drawing.Color.Silver;
            this.txtMenu.LineThickness = 2;
            this.txtMenu.Location = new System.Drawing.Point(769, 2);
            this.txtMenu.Margin = new System.Windows.Forms.Padding(4);
            this.txtMenu.Name = "txtMenu";
            this.txtMenu.Size = new System.Drawing.Size(370, 44);
            this.txtMenu.TabIndex = 5;
            this.txtMenu.Text = "Search here ...";
            this.txtMenu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(65, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "HotelBooking";
            // 
            // btnMenu
            // 
            this.btnMenu.Image = global::HotelBooking.Properties.Resources.menu_icon;
            this.btnMenu.Location = new System.Drawing.Point(19, 15);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(40, 34);
            this.btnMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMenu.TabIndex = 3;
            this.btnMenu.TabStop = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1231, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(44, 62);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.Linen;
            this.sidebar.Controls.Add(this.btnCollection);
            this.sidebar.Controls.Add(this.btnHistoryBooking);
            this.sidebar.Controls.Add(this.btnProfile);
            this.sidebar.Controls.Add(this.btnHome);
            this.sidebar.Controls.Add(this.label2);
            this.sidebar.Controls.Add(this.lblWelcome);
            this.sidebar.Controls.Add(this.panel4);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 62);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(267, 708);
            this.sidebar.TabIndex = 2;
            // 
            // btnCollection
            // 
            this.btnCollection.Activecolor = System.Drawing.Color.BurlyWood;
            this.btnCollection.AutoSize = true;
            this.btnCollection.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.btnCollection.BackColor = System.Drawing.Color.Tan;
            this.btnCollection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCollection.BorderRadius = 0;
            this.btnCollection.ButtonText = "    Collection";
            this.btnCollection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCollection.DisabledColor = System.Drawing.Color.Gray;
            this.btnCollection.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCollection.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCollection.Iconimage = global::HotelBooking.Properties.Resources.collection_icon;
            this.btnCollection.Iconimage_right = null;
            this.btnCollection.Iconimage_right_Selected = null;
            this.btnCollection.Iconimage_Selected = null;
            this.btnCollection.IconMarginLeft = 30;
            this.btnCollection.IconMarginRight = 0;
            this.btnCollection.IconRightVisible = true;
            this.btnCollection.IconRightZoom = 0D;
            this.btnCollection.IconVisible = true;
            this.btnCollection.IconZoom = 45D;
            this.btnCollection.IsTab = false;
            this.btnCollection.Location = new System.Drawing.Point(0, 391);
            this.btnCollection.Margin = new System.Windows.Forms.Padding(10, 22, 10, 22);
            this.btnCollection.Name = "btnCollection";
            this.btnCollection.Normalcolor = System.Drawing.Color.Tan;
            this.btnCollection.OnHovercolor = System.Drawing.Color.Silver;
            this.btnCollection.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCollection.selected = false;
            this.btnCollection.Size = new System.Drawing.Size(267, 92);
            this.btnCollection.TabIndex = 7;
            this.btnCollection.Text = "    Collection";
            this.btnCollection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCollection.Textcolor = System.Drawing.Color.Transparent;
            this.btnCollection.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCollection.Click += new System.EventHandler(this.btnCollection_Click);
            // 
            // btnHistoryBooking
            // 
            this.btnHistoryBooking.Activecolor = System.Drawing.Color.BurlyWood;
            this.btnHistoryBooking.AutoSize = true;
            this.btnHistoryBooking.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.btnHistoryBooking.BackColor = System.Drawing.Color.Tan;
            this.btnHistoryBooking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHistoryBooking.BorderRadius = 0;
            this.btnHistoryBooking.ButtonText = "    History Booking";
            this.btnHistoryBooking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistoryBooking.DisabledColor = System.Drawing.Color.Gray;
            this.btnHistoryBooking.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHistoryBooking.Iconcolor = System.Drawing.Color.Transparent;
            this.btnHistoryBooking.Iconimage = global::HotelBooking.Properties.Resources.history_booking_icon;
            this.btnHistoryBooking.Iconimage_right = null;
            this.btnHistoryBooking.Iconimage_right_Selected = null;
            this.btnHistoryBooking.Iconimage_Selected = null;
            this.btnHistoryBooking.IconMarginLeft = 30;
            this.btnHistoryBooking.IconMarginRight = 0;
            this.btnHistoryBooking.IconRightVisible = true;
            this.btnHistoryBooking.IconRightZoom = 0D;
            this.btnHistoryBooking.IconVisible = true;
            this.btnHistoryBooking.IconZoom = 45D;
            this.btnHistoryBooking.IsTab = false;
            this.btnHistoryBooking.Location = new System.Drawing.Point(0, 299);
            this.btnHistoryBooking.Margin = new System.Windows.Forms.Padding(8, 14, 8, 14);
            this.btnHistoryBooking.Name = "btnHistoryBooking";
            this.btnHistoryBooking.Normalcolor = System.Drawing.Color.Tan;
            this.btnHistoryBooking.OnHovercolor = System.Drawing.Color.Silver;
            this.btnHistoryBooking.OnHoverTextColor = System.Drawing.Color.White;
            this.btnHistoryBooking.selected = false;
            this.btnHistoryBooking.Size = new System.Drawing.Size(267, 92);
            this.btnHistoryBooking.TabIndex = 6;
            this.btnHistoryBooking.Text = "    History Booking";
            this.btnHistoryBooking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistoryBooking.Textcolor = System.Drawing.Color.Transparent;
            this.btnHistoryBooking.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistoryBooking.Click += new System.EventHandler(this.btnHistoryBooking_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Activecolor = System.Drawing.Color.BurlyWood;
            this.btnProfile.AutoSize = true;
            this.btnProfile.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.btnProfile.BackColor = System.Drawing.Color.Tan;
            this.btnProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProfile.BorderRadius = 0;
            this.btnProfile.ButtonText = "    Profile";
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.DisabledColor = System.Drawing.Color.Gray;
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfile.Iconcolor = System.Drawing.Color.Transparent;
            this.btnProfile.Iconimage = global::HotelBooking.Properties.Resources.user;
            this.btnProfile.Iconimage_right = null;
            this.btnProfile.Iconimage_right_Selected = null;
            this.btnProfile.Iconimage_Selected = null;
            this.btnProfile.IconMarginLeft = 30;
            this.btnProfile.IconMarginRight = 0;
            this.btnProfile.IconRightVisible = true;
            this.btnProfile.IconRightZoom = 0D;
            this.btnProfile.IconVisible = true;
            this.btnProfile.IconZoom = 50D;
            this.btnProfile.IsTab = false;
            this.btnProfile.Location = new System.Drawing.Point(0, 207);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Normalcolor = System.Drawing.Color.Tan;
            this.btnProfile.OnHovercolor = System.Drawing.Color.Silver;
            this.btnProfile.OnHoverTextColor = System.Drawing.Color.White;
            this.btnProfile.selected = false;
            this.btnProfile.Size = new System.Drawing.Size(267, 92);
            this.btnProfile.TabIndex = 5;
            this.btnProfile.Text = "    Profile";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.Textcolor = System.Drawing.Color.Transparent;
            this.btnProfile.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnHome
            // 
            this.btnHome.Activecolor = System.Drawing.Color.BurlyWood;
            this.btnHome.AutoSize = true;
            this.btnHome.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.btnHome.BackColor = System.Drawing.Color.Tan;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.BorderRadius = 0;
            this.btnHome.ButtonText = "     Home";
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.DisabledColor = System.Drawing.Color.Gray;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.Iconcolor = System.Drawing.Color.Transparent;
            this.btnHome.Iconimage = global::HotelBooking.Properties.Resources.home_icon;
            this.btnHome.Iconimage_right = null;
            this.btnHome.Iconimage_right_Selected = null;
            this.btnHome.Iconimage_Selected = null;
            this.btnHome.IconMarginLeft = 30;
            this.btnHome.IconMarginRight = 0;
            this.btnHome.IconRightVisible = true;
            this.btnHome.IconRightZoom = 0D;
            this.btnHome.IconVisible = true;
            this.btnHome.IconZoom = 35D;
            this.btnHome.IsTab = false;
            this.btnHome.Location = new System.Drawing.Point(0, 115);
            this.btnHome.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnHome.Name = "btnHome";
            this.btnHome.Normalcolor = System.Drawing.Color.Tan;
            this.btnHome.OnHovercolor = System.Drawing.Color.Silver;
            this.btnHome.OnHoverTextColor = System.Drawing.Color.White;
            this.btnHome.selected = false;
            this.btnHome.Size = new System.Drawing.Size(267, 92);
            this.btnHome.TabIndex = 3;
            this.btnHome.Text = "     Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Textcolor = System.Drawing.Color.Transparent;
            this.btnHome.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 3;
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(65, 18);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(0, 25);
            this.lblWelcome.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelWelcome);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(267, 115);
            this.panel4.TabIndex = 3;
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.ForeColor = System.Drawing.Color.Tan;
            this.labelWelcome.Location = new System.Drawing.Point(8, 48);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(96, 25);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome ";
            this.labelWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowPanel
            // 
            this.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanel.Location = new System.Drawing.Point(267, 62);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(1008, 708);
            this.flowPanel.TabIndex = 3;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1275, 770);
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            this.sidebar.ResumeLayout(false);
            this.sidebar.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnMenu;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuFlatButton btnHome;
        private System.Windows.Forms.Panel panel4;
        private Bunifu.Framework.UI.BunifuFlatButton btnProfile;
        private Bunifu.Framework.UI.BunifuFlatButton btnHistoryBooking;
        private Bunifu.Framework.UI.BunifuFlatButton btnCollection;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtMenu;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Panel flowPanel;
    }
}