namespace DAn_QLCuaHangBanthuoc
{
    partial class frm_add_purchase
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
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lbl_total_price = new System.Windows.Forms.Label();
            this.dgv_data2 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbo_medicine = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_new_perchase = new Guna.UI2.WinForms.Guna2Button();
            this.btn_add = new Guna.UI2.WinForms.Guna2Button();
            this.cbo_staff = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_supplier = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btn_close = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_delete = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data2)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.lbl_total_price);
            this.guna2ShadowPanel1.Controls.Add(this.dgv_data2);
            this.guna2ShadowPanel1.Controls.Add(this.cbo_medicine);
            this.guna2ShadowPanel1.Controls.Add(this.label1);
            this.guna2ShadowPanel1.Controls.Add(this.btn_new_perchase);
            this.guna2ShadowPanel1.Controls.Add(this.btn_add);
            this.guna2ShadowPanel1.Controls.Add(this.cbo_staff);
            this.guna2ShadowPanel1.Controls.Add(this.label5);
            this.guna2ShadowPanel1.Controls.Add(this.cbo_supplier);
            this.guna2ShadowPanel1.Controls.Add(this.label2);
            this.guna2ShadowPanel1.Controls.Add(this.guna2Panel1);
            this.guna2ShadowPanel1.Controls.Add(this.btn_close);
            this.guna2ShadowPanel1.Controls.Add(this.label6);
            this.guna2ShadowPanel1.Controls.Add(this.btn_delete);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(12, 12);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 10;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(835, 752);
            this.guna2ShadowPanel1.TabIndex = 4;
            this.guna2ShadowPanel1.Click += new System.EventHandler(this.guna2ShadowPanel1_Click);
            // 
            // lbl_total_price
            // 
            this.lbl_total_price.AutoSize = true;
            this.lbl_total_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_price.Location = new System.Drawing.Point(598, 666);
            this.lbl_total_price.Name = "lbl_total_price";
            this.lbl_total_price.Size = new System.Drawing.Size(56, 20);
            this.lbl_total_price.TabIndex = 47;
            this.lbl_total_price.Text = "0 VND";
            // 
            // dgv_data2
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_data2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_data2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_data2.ColumnHeadersHeight = 35;
            this.dgv_data2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_data2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgv_data2.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_data2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_data2.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_data2.Location = new System.Drawing.Point(15, 271);
            this.dgv_data2.Name = "dgv_data2";
            this.dgv_data2.RowHeadersVisible = false;
            this.dgv_data2.RowHeadersWidth = 60;
            this.dgv_data2.RowTemplate.Height = 40;
            this.dgv_data2.Size = new System.Drawing.Size(805, 373);
            this.dgv_data2.TabIndex = 46;
            this.dgv_data2.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_data2.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_data2.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_data2.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_data2.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_data2.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_data2.ThemeStyle.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_data2.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_data2.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_data2.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_data2.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_data2.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_data2.ThemeStyle.HeaderStyle.Height = 35;
            this.dgv_data2.ThemeStyle.ReadOnly = false;
            this.dgv_data2.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_data2.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_data2.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_data2.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_data2.ThemeStyle.RowsStyle.Height = 40;
            this.dgv_data2.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_data2.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_data2.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_data2_CellValidating);
            this.dgv_data2.DoubleClick += new System.EventHandler(this.dgv_data2_DoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID Batch";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ID Medicine";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Quantity";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Entry Price";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Manufacture";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Expiry";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Status";
            this.Column7.Name = "Column7";
            // 
            // cbo_medicine
            // 
            this.cbo_medicine.BackColor = System.Drawing.Color.Transparent;
            this.cbo_medicine.BorderColor = System.Drawing.Color.Gray;
            this.cbo_medicine.BorderRadius = 10;
            this.cbo_medicine.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_medicine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_medicine.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_medicine.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_medicine.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_medicine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbo_medicine.ItemHeight = 30;
            this.cbo_medicine.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cbo_medicine.Location = new System.Drawing.Point(40, 205);
            this.cbo_medicine.Name = "cbo_medicine";
            this.cbo_medicine.Size = new System.Drawing.Size(242, 36);
            this.cbo_medicine.TabIndex = 35;
            this.cbo_medicine.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbo_medicine_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(44, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 34;
            this.label1.Text = "Product:";
            // 
            // btn_new_perchase
            // 
            this.btn_new_perchase.Animated = true;
            this.btn_new_perchase.BackColor = System.Drawing.Color.White;
            this.btn_new_perchase.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_new_perchase.BorderRadius = 7;
            this.btn_new_perchase.BorderThickness = 1;
            this.btn_new_perchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new_perchase.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_new_perchase.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_new_perchase.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_new_perchase.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_new_perchase.FillColor = System.Drawing.Color.White;
            this.btn_new_perchase.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_new_perchase.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btn_new_perchase.HoverState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_new_perchase.HoverState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btn_new_perchase.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_new_perchase.Image = global::DAn_QLCuaHangBanthuoc.Properties.Resources.pen;
            this.btn_new_perchase.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_new_perchase.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_new_perchase.IndicateFocus = true;
            this.btn_new_perchase.Location = new System.Drawing.Point(614, 190);
            this.btn_new_perchase.Name = "btn_new_perchase";
            this.btn_new_perchase.Size = new System.Drawing.Size(146, 51);
            this.btn_new_perchase.TabIndex = 32;
            this.btn_new_perchase.Text = "New Purchase";
            this.btn_new_perchase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_new_perchase.Click += new System.EventHandler(this.btn_new_perchase_Click);
            // 
            // btn_add
            // 
            this.btn_add.Animated = true;
            this.btn_add.BackColor = System.Drawing.Color.White;
            this.btn_add.BorderColor = System.Drawing.Color.Green;
            this.btn_add.BorderRadius = 7;
            this.btn_add.BorderThickness = 1;
            this.btn_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_add.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_add.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_add.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_add.FillColor = System.Drawing.Color.White;
            this.btn_add.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_add.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_add.HoverState.BorderColor = System.Drawing.Color.Green;
            this.btn_add.HoverState.FillColor = System.Drawing.Color.Green;
            this.btn_add.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_add.Image = global::DAn_QLCuaHangBanthuoc.Properties.Resources.plus;
            this.btn_add.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_add.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_add.IndicateFocus = true;
            this.btn_add.Location = new System.Drawing.Point(289, 205);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(102, 36);
            this.btn_add.TabIndex = 31;
            this.btn_add.Text = "     Add";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // cbo_staff
            // 
            this.cbo_staff.BackColor = System.Drawing.Color.Transparent;
            this.cbo_staff.BorderColor = System.Drawing.Color.Gray;
            this.cbo_staff.BorderRadius = 10;
            this.cbo_staff.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_staff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_staff.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_staff.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_staff.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_staff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbo_staff.ItemHeight = 30;
            this.cbo_staff.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cbo_staff.Location = new System.Drawing.Point(518, 132);
            this.cbo_staff.Name = "cbo_staff";
            this.cbo_staff.Size = new System.Drawing.Size(242, 36);
            this.cbo_staff.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(523, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 18);
            this.label5.TabIndex = 23;
            this.label5.Text = "Created by:";
            // 
            // cbo_supplier
            // 
            this.cbo_supplier.BackColor = System.Drawing.Color.Transparent;
            this.cbo_supplier.BorderColor = System.Drawing.Color.Gray;
            this.cbo_supplier.BorderRadius = 10;
            this.cbo_supplier.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_supplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_supplier.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_supplier.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_supplier.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_supplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbo_supplier.ItemHeight = 30;
            this.cbo_supplier.Location = new System.Drawing.Point(40, 132);
            this.cbo_supplier.Name = "cbo_supplier";
            this.cbo_supplier.Size = new System.Drawing.Size(242, 36);
            this.cbo_supplier.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(44, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Supplier:";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.guna2Panel1.Location = new System.Drawing.Point(277, 64);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(200, 3);
            this.guna2Panel1.TabIndex = 15;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.BorderRadius = 10;
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.FillColor = System.Drawing.Color.Transparent;
            this.btn_close.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_close.IconColor = System.Drawing.Color.DimGray;
            this.btn_close.Location = new System.Drawing.Point(797, 3);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(35, 25);
            this.btn_close.TabIndex = 1;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(241, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(289, 31);
            this.label6.TabIndex = 7;
            this.label6.Text = "Create Purchase Invoice";
            // 
            // btn_delete
            // 
            this.btn_delete.Animated = true;
            this.btn_delete.BackColor = System.Drawing.Color.White;
            this.btn_delete.BorderColor = System.Drawing.Color.Red;
            this.btn_delete.BorderRadius = 7;
            this.btn_delete.BorderThickness = 1;
            this.btn_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_delete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_delete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_delete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_delete.FillColor = System.Drawing.Color.White;
            this.btn_delete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_delete.ForeColor = System.Drawing.Color.Red;
            this.btn_delete.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_delete.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_delete.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_delete.Image = global::DAn_QLCuaHangBanthuoc.Properties.Resources.remove;
            this.btn_delete.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_delete.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_delete.IndicateFocus = true;
            this.btn_delete.Location = new System.Drawing.Point(288, 205);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(103, 36);
            this.btn_delete.TabIndex = 33;
            this.btn_delete.Text = "        Delete";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // frm_add_purchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(890, 813);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_add_purchase";
            this.Text = "frm_add_purchase";
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2Button btn_delete;
        private Guna.UI2.WinForms.Guna2Button btn_new_perchase;
        private Guna.UI2.WinForms.Guna2Button btn_add;
        private Guna.UI2.WinForms.Guna2ComboBox cbo_staff;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cbo_supplier;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ControlBox btn_close;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cbo_medicine;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_data2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Label lbl_total_price;
    }
}