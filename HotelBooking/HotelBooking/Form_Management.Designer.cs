
namespace HotelBooking
{
    partial class Form_Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Management));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtMenu = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.sidebar = new System.Windows.Forms.Panel();
            this.btnService = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnRoom = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnBooking = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnUser = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnHome = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.flowPanel = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.txtMenu);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnMenu);
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
            this.label1.Size = new System.Drawing.Size(146, 30);
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
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.Linen;
            this.sidebar.Controls.Add(this.btnService);
            this.sidebar.Controls.Add(this.btnRoom);
            this.sidebar.Controls.Add(this.btnBooking);
            this.sidebar.Controls.Add(this.btnUser);
            this.sidebar.Controls.Add(this.btnHome);
            this.sidebar.Controls.Add(this.label2);
            this.sidebar.Controls.Add(this.lblWelcome);
            this.sidebar.Controls.Add(this.panel4);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 62);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(267, 690);
            this.sidebar.TabIndex = 2;
            // 
            // btnService
            // 
            this.btnService.Activecolor = System.Drawing.Color.BurlyWood;
            this.btnService.AutoSize = true;
            this.btnService.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.btnService.BackColor = System.Drawing.Color.Tan;
            this.btnService.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnService.BorderRadius = 0;
            this.btnService.ButtonText = "    Service";
            this.btnService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnService.DisabledColor = System.Drawing.Color.Gray;
            this.btnService.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnService.Iconcolor = System.Drawing.Color.Transparent;
            this.btnService.Iconimage = global::HotelBooking.Properties.Resources.collection_icon;
            this.btnService.Iconimage_right = null;
            this.btnService.Iconimage_right_Selected = null;
            this.btnService.Iconimage_Selected = null;
            this.btnService.IconMarginLeft = 30;
            this.btnService.IconMarginRight = 0;
            this.btnService.IconRightVisible = true;
            this.btnService.IconRightZoom = 0D;
            this.btnService.IconVisible = true;
            this.btnService.IconZoom = 45D;
            this.btnService.IsTab = false;
            this.btnService.Location = new System.Drawing.Point(0, 563);
            this.btnService.Margin = new System.Windows.Forms.Padding(13, 33, 13, 33);
            this.btnService.Name = "btnService";
            this.btnService.Normalcolor = System.Drawing.Color.Tan;
            this.btnService.OnHovercolor = System.Drawing.Color.Silver;
            this.btnService.OnHoverTextColor = System.Drawing.Color.White;
            this.btnService.selected = false;
            this.btnService.Size = new System.Drawing.Size(267, 112);
            this.btnService.TabIndex = 8;
            this.btnService.Text = "    Service";
            this.btnService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnService.Textcolor = System.Drawing.Color.Transparent;
            this.btnService.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnService.Click += new System.EventHandler(this.btnService_Click);
            // 
            // btnRoom
            // 
            this.btnRoom.Activecolor = System.Drawing.Color.BurlyWood;
            this.btnRoom.AutoSize = true;
            this.btnRoom.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.btnRoom.BackColor = System.Drawing.Color.Tan;
            this.btnRoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRoom.BorderRadius = 0;
            this.btnRoom.ButtonText = "    Room";
            this.btnRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoom.DisabledColor = System.Drawing.Color.Gray;
            this.btnRoom.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRoom.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRoom.Iconimage = global::HotelBooking.Properties.Resources.collection_icon;
            this.btnRoom.Iconimage_right = null;
            this.btnRoom.Iconimage_right_Selected = null;
            this.btnRoom.Iconimage_Selected = null;
            this.btnRoom.IconMarginLeft = 30;
            this.btnRoom.IconMarginRight = 0;
            this.btnRoom.IconRightVisible = true;
            this.btnRoom.IconRightZoom = 0D;
            this.btnRoom.IconVisible = true;
            this.btnRoom.IconZoom = 45D;
            this.btnRoom.IsTab = false;
            this.btnRoom.Location = new System.Drawing.Point(0, 451);
            this.btnRoom.Margin = new System.Windows.Forms.Padding(10, 22, 10, 22);
            this.btnRoom.Name = "btnRoom";
            this.btnRoom.Normalcolor = System.Drawing.Color.Tan;
            this.btnRoom.OnHovercolor = System.Drawing.Color.Silver;
            this.btnRoom.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRoom.selected = false;
            this.btnRoom.Size = new System.Drawing.Size(267, 112);
            this.btnRoom.TabIndex = 7;
            this.btnRoom.Text = "    Room";
            this.btnRoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoom.Textcolor = System.Drawing.Color.Transparent;
            this.btnRoom.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoom.Click += new System.EventHandler(this.btnRoom_Click);
            // 
            // btnBooking
            // 
            this.btnBooking.Activecolor = System.Drawing.Color.BurlyWood;
            this.btnBooking.AutoSize = true;
            this.btnBooking.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.btnBooking.BackColor = System.Drawing.Color.Tan;
            this.btnBooking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBooking.BorderRadius = 0;
            this.btnBooking.ButtonText = "    Booking";
            this.btnBooking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBooking.DisabledColor = System.Drawing.Color.Gray;
            this.btnBooking.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBooking.Iconcolor = System.Drawing.Color.Transparent;
            this.btnBooking.Iconimage = global::HotelBooking.Properties.Resources.history_booking_icon;
            this.btnBooking.Iconimage_right = null;
            this.btnBooking.Iconimage_right_Selected = null;
            this.btnBooking.Iconimage_Selected = null;
            this.btnBooking.IconMarginLeft = 30;
            this.btnBooking.IconMarginRight = 0;
            this.btnBooking.IconRightVisible = true;
            this.btnBooking.IconRightZoom = 0D;
            this.btnBooking.IconVisible = true;
            this.btnBooking.IconZoom = 45D;
            this.btnBooking.IsTab = false;
            this.btnBooking.Location = new System.Drawing.Point(0, 339);
            this.btnBooking.Margin = new System.Windows.Forms.Padding(8, 14, 8, 14);
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.Normalcolor = System.Drawing.Color.Tan;
            this.btnBooking.OnHovercolor = System.Drawing.Color.Silver;
            this.btnBooking.OnHoverTextColor = System.Drawing.Color.White;
            this.btnBooking.selected = false;
            this.btnBooking.Size = new System.Drawing.Size(267, 112);
            this.btnBooking.TabIndex = 6;
            this.btnBooking.Text = "    Booking";
            this.btnBooking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBooking.Textcolor = System.Drawing.Color.Transparent;
            this.btnBooking.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click);
            // 
            // btnUser
            // 
            this.btnUser.Activecolor = System.Drawing.Color.BurlyWood;
            this.btnUser.AutoSize = true;
            this.btnUser.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.btnUser.BackColor = System.Drawing.Color.Tan;
            this.btnUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUser.BorderRadius = 0;
            this.btnUser.ButtonText = "    User";
            this.btnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUser.DisabledColor = System.Drawing.Color.Gray;
            this.btnUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUser.Iconcolor = System.Drawing.Color.Transparent;
            this.btnUser.Iconimage = global::HotelBooking.Properties.Resources.user;
            this.btnUser.Iconimage_right = null;
            this.btnUser.Iconimage_right_Selected = null;
            this.btnUser.Iconimage_Selected = null;
            this.btnUser.IconMarginLeft = 30;
            this.btnUser.IconMarginRight = 0;
            this.btnUser.IconRightVisible = true;
            this.btnUser.IconRightZoom = 0D;
            this.btnUser.IconVisible = true;
            this.btnUser.IconZoom = 50D;
            this.btnUser.IsTab = false;
            this.btnUser.Location = new System.Drawing.Point(0, 227);
            this.btnUser.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnUser.Name = "btnUser";
            this.btnUser.Normalcolor = System.Drawing.Color.Tan;
            this.btnUser.OnHovercolor = System.Drawing.Color.Silver;
            this.btnUser.OnHoverTextColor = System.Drawing.Color.White;
            this.btnUser.selected = false;
            this.btnUser.Size = new System.Drawing.Size(267, 112);
            this.btnUser.TabIndex = 5;
            this.btnUser.Text = "    User";
            this.btnUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.Textcolor = System.Drawing.Color.Transparent;
            this.btnUser.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
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
            this.btnHome.Size = new System.Drawing.Size(267, 112);
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
            this.label2.Size = new System.Drawing.Size(0, 30);
            this.label2.TabIndex = 3;
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(65, 18);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(0, 30);
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
            this.labelWelcome.Size = new System.Drawing.Size(114, 30);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome ";
            this.labelWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowPanel
            // 
            this.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanel.Location = new System.Drawing.Point(267, 62);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(1008, 690);
            this.flowPanel.TabIndex = 3;
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
            this.btnClose.TabIndex = 8;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // Form_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1275, 752);
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form_Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Management";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form_Management_Load);
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
        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnMenu;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuFlatButton btnHome;
        private System.Windows.Forms.Panel panel4;
        private Bunifu.Framework.UI.BunifuFlatButton btnUser;
        private Bunifu.Framework.UI.BunifuFlatButton btnBooking;
        private Bunifu.Framework.UI.BunifuFlatButton btnRoom;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtMenu;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Panel flowPanel;
        private Bunifu.Framework.UI.BunifuFlatButton btnService;
        private System.Windows.Forms.Button btnClose;
    }
}