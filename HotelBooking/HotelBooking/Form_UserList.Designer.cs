﻿namespace HotelBooking
{
    partial class Form_UserList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvUserList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.pictureBoxUser = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbUserGroup = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUpdate = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnCancel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAdd = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDelete = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1134, 58);
            this.panel2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Mistral", 34.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Tan;
            this.label3.Location = new System.Drawing.Point(358, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(424, 83);
            this.label3.TabIndex = 0;
            this.label3.Text = "User Management";
            // 
            // dgvUserList
            // 
            this.dgvUserList.AllowUserToAddRows = false;
            this.dgvUserList.AllowUserToDeleteRows = false;
            this.dgvUserList.AllowUserToResizeColumns = false;
            this.dgvUserList.AllowUserToResizeRows = false;
            this.dgvUserList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Tan;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.BurlyWood;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Tan;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.BurlyWood;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUserList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUserList.GridColor = System.Drawing.Color.Tan;
            this.dgvUserList.Location = new System.Drawing.Point(242, 318);
            this.dgvUserList.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgvUserList.Name = "dgvUserList";
            this.dgvUserList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Tan;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.BurlyWood;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUserList.RowHeadersVisible = false;
            this.dgvUserList.RowHeadersWidth = 51;
            this.dgvUserList.RowTemplate.Height = 24;
            this.dgvUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserList.Size = new System.Drawing.Size(674, 314);
            this.dgvUserList.TabIndex = 11;
            this.dgvUserList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserList_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Tan;
            this.label1.Location = new System.Drawing.Point(27, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 30);
            this.label1.TabIndex = 12;
            this.label1.Text = "User Name";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(33, 83);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(307, 26);
            this.txtUserName.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Tan;
            this.label2.Location = new System.Drawing.Point(410, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 30);
            this.label2.TabIndex = 14;
            this.label2.Text = "Full name";
            // 
            // txtFullname
            // 
            this.txtFullname.Location = new System.Drawing.Point(412, 82);
            this.txtFullname.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.Size = new System.Drawing.Size(289, 26);
            this.txtFullname.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Tan;
            this.label4.Location = new System.Drawing.Point(772, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 30);
            this.label4.TabIndex = 16;
            this.label4.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(777, 83);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(326, 26);
            this.txtEmail.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Tan;
            this.label5.Location = new System.Drawing.Point(237, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 30);
            this.label5.TabIndex = 25;
            this.label5.Text = "User List";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnDeleteImage);
            this.panel1.Controls.Add(this.btnUploadImage);
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.pictureBoxUser);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cmbUserGroup);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtFullname);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgvUserList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 58);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1134, 745);
            this.panel1.TabIndex = 3;
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.BackColor = System.Drawing.Color.Tan;
            this.btnDeleteImage.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteImage.Location = new System.Drawing.Point(30, 594);
            this.btnDeleteImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(174, 38);
            this.btnDeleteImage.TabIndex = 44;
            this.btnDeleteImage.Text = "Delete Image";
            this.btnDeleteImage.UseVisualStyleBackColor = false;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.BackColor = System.Drawing.Color.Tan;
            this.btnUploadImage.ForeColor = System.Drawing.Color.Black;
            this.btnUploadImage.Location = new System.Drawing.Point(30, 548);
            this.btnUploadImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(174, 42);
            this.btnUploadImage.TabIndex = 43;
            this.btnUploadImage.Text = "Upload Image";
            this.btnUploadImage.UseVisualStyleBackColor = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Tan;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.Black;
            this.lblUser.Location = new System.Drawing.Point(72, 495);
            this.lblUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(91, 32);
            this.lblUser.TabIndex = 42;
            this.lblUser.Text = "Chi Chi";
            // 
            // pictureBoxUser
            // 
            this.pictureBoxUser.Image = global::HotelBooking.Properties.Resources.defaultAvatar;
            this.pictureBoxUser.Location = new System.Drawing.Point(30, 318);
            this.pictureBoxUser.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxUser.Name = "pictureBoxUser";
            this.pictureBoxUser.Size = new System.Drawing.Size(174, 162);
            this.pictureBoxUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxUser.TabIndex = 41;
            this.pictureBoxUser.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Tan;
            this.label9.Location = new System.Drawing.Point(27, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 30);
            this.label9.TabIndex = 40;
            this.label9.Text = "Avatar";
            // 
            // cmbUserGroup
            // 
            this.cmbUserGroup.FormattingEnabled = true;
            this.cmbUserGroup.Location = new System.Drawing.Point(777, 191);
            this.cmbUserGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbUserGroup.Name = "cmbUserGroup";
            this.cmbUserGroup.Size = new System.Drawing.Size(326, 28);
            this.cmbUserGroup.TabIndex = 39;
            this.cmbUserGroup.SelectedIndexChanged += new System.EventHandler(this.cmbUserGroup_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Tan;
            this.label8.Location = new System.Drawing.Point(772, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 30);
            this.label8.TabIndex = 38;
            this.label8.Text = "User group";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(412, 189);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(289, 26);
            this.txtPhone.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Tan;
            this.label7.Location = new System.Drawing.Point(408, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 30);
            this.label7.TabIndex = 35;
            this.label7.Text = "Phone";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(32, 191);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(308, 26);
            this.txtAddress.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Tan;
            this.label6.Location = new System.Drawing.Point(26, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 30);
            this.label6.TabIndex = 33;
            this.label6.Text = "Address";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Activecolor = System.Drawing.Color.BurlyWood;
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.BackColor = System.Drawing.Color.Tan;
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdate.BorderRadius = 5;
            this.btnUpdate.ButtonText = "Update";
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.DisabledColor = System.Drawing.Color.Gray;
            this.btnUpdate.Iconcolor = System.Drawing.Color.Transparent;
            this.btnUpdate.Iconimage = global::HotelBooking.Properties.Resources.remove_icon;
            this.btnUpdate.Iconimage_right = null;
            this.btnUpdate.Iconimage_right_Selected = null;
            this.btnUpdate.Iconimage_Selected = null;
            this.btnUpdate.IconMarginLeft = 0;
            this.btnUpdate.IconMarginRight = 0;
            this.btnUpdate.IconRightVisible = true;
            this.btnUpdate.IconRightZoom = 0D;
            this.btnUpdate.IconVisible = true;
            this.btnUpdate.IconZoom = 40D;
            this.btnUpdate.IsTab = false;
            this.btnUpdate.Location = new System.Drawing.Point(941, 381);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Normalcolor = System.Drawing.Color.Tan;
            this.btnUpdate.OnHovercolor = System.Drawing.Color.Silver;
            this.btnUpdate.OnHoverTextColor = System.Drawing.Color.White;
            this.btnUpdate.selected = false;
            this.btnUpdate.Size = new System.Drawing.Size(162, 73);
            this.btnUpdate.TabIndex = 48;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Textcolor = System.Drawing.Color.White;
            this.btnUpdate.TextFont = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Activecolor = System.Drawing.Color.BurlyWood;
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.Tan;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.ButtonText = "Cancel";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DisabledColor = System.Drawing.Color.Gray;
            this.btnCancel.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCancel.Iconimage = global::HotelBooking.Properties.Resources.return_icon;
            this.btnCancel.Iconimage_right = null;
            this.btnCancel.Iconimage_right_Selected = null;
            this.btnCancel.Iconimage_Selected = null;
            this.btnCancel.IconMarginLeft = 0;
            this.btnCancel.IconMarginRight = 0;
            this.btnCancel.IconRightVisible = true;
            this.btnCancel.IconRightZoom = 0D;
            this.btnCancel.IconVisible = true;
            this.btnCancel.IconZoom = 40D;
            this.btnCancel.IsTab = false;
            this.btnCancel.Location = new System.Drawing.Point(941, 559);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Normalcolor = System.Drawing.Color.Tan;
            this.btnCancel.OnHovercolor = System.Drawing.Color.Silver;
            this.btnCancel.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCancel.selected = false;
            this.btnCancel.Size = new System.Drawing.Size(162, 73);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Textcolor = System.Drawing.Color.White;
            this.btnCancel.TextFont = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Activecolor = System.Drawing.Color.BurlyWood;
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.Color.Tan;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.BorderRadius = 5;
            this.btnAdd.ButtonText = "Add";
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DisabledColor = System.Drawing.Color.Gray;
            this.btnAdd.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAdd.Iconimage = global::HotelBooking.Properties.Resources.add_icon;
            this.btnAdd.Iconimage_right = null;
            this.btnAdd.Iconimage_right_Selected = null;
            this.btnAdd.Iconimage_Selected = null;
            this.btnAdd.IconMarginLeft = 0;
            this.btnAdd.IconMarginRight = 0;
            this.btnAdd.IconRightVisible = true;
            this.btnAdd.IconRightZoom = 0D;
            this.btnAdd.IconVisible = true;
            this.btnAdd.IconZoom = 40D;
            this.btnAdd.IsTab = false;
            this.btnAdd.Location = new System.Drawing.Point(941, 292);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Normalcolor = System.Drawing.Color.Tan;
            this.btnAdd.OnHovercolor = System.Drawing.Color.Silver;
            this.btnAdd.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAdd.selected = false;
            this.btnAdd.Size = new System.Drawing.Size(162, 73);
            this.btnAdd.TabIndex = 46;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Textcolor = System.Drawing.Color.White;
            this.btnAdd.TextFont = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Activecolor = System.Drawing.Color.BurlyWood;
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.Color.Tan;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.BorderRadius = 5;
            this.btnDelete.ButtonText = "Delete";
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.DisabledColor = System.Drawing.Color.Gray;
            this.btnDelete.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDelete.Iconimage = global::HotelBooking.Properties.Resources.remove_icon;
            this.btnDelete.Iconimage_right = null;
            this.btnDelete.Iconimage_right_Selected = null;
            this.btnDelete.Iconimage_Selected = null;
            this.btnDelete.IconMarginLeft = 0;
            this.btnDelete.IconMarginRight = 0;
            this.btnDelete.IconRightVisible = true;
            this.btnDelete.IconRightZoom = 0D;
            this.btnDelete.IconVisible = true;
            this.btnDelete.IconZoom = 40D;
            this.btnDelete.IsTab = false;
            this.btnDelete.Location = new System.Drawing.Point(941, 470);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Normalcolor = System.Drawing.Color.Tan;
            this.btnDelete.OnHovercolor = System.Drawing.Color.Silver;
            this.btnDelete.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDelete.selected = false;
            this.btnDelete.Size = new System.Drawing.Size(162, 73);
            this.btnDelete.TabIndex = 45;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Textcolor = System.Drawing.Color.White;
            this.btnDelete.TextFont = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form_UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 803);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Form_UserList";
            this.Text = "Form_UserList";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvUserList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFullname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbUserGroup;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBoxUser;
        private System.Windows.Forms.Button btnDeleteImage;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Label lblUser;
        private Bunifu.Framework.UI.BunifuFlatButton btnUpdate;
        private Bunifu.Framework.UI.BunifuFlatButton btnCancel;
        private Bunifu.Framework.UI.BunifuFlatButton btnAdd;
        private Bunifu.Framework.UI.BunifuFlatButton btnDelete;
    }
}