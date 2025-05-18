namespace DAn_QLCuaHangBanthuoc
{
    partial class frm_show_sale
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_price = new System.Windows.Forms.Label();
            this.dgv_data = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_close = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btn_print = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lbl_customer = new System.Windows.Forms.Label();
            this.lbl_date = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pn_Print = new Guna.UI2.WinForms.Guna2Panel();
            this.cbo_status = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_edit = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_print)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.pn_Print.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_price
            // 
            this.lbl_price.AutoSize = true;
            this.lbl_price.BackColor = System.Drawing.Color.Transparent;
            this.lbl_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_price.Location = new System.Drawing.Point(863, 804);
            this.lbl_price.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_price.Name = "lbl_price";
            this.lbl_price.Size = new System.Drawing.Size(70, 25);
            this.lbl_price.TabIndex = 59;
            this.lbl_price.Text = "0 VND";
            // 
            // dgv_data
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgv_data.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_data.ColumnHeadersHeight = 35;
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column1});
            this.dgv_data.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_data.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_data.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_data.Location = new System.Drawing.Point(17, 416);
            this.dgv_data.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.RowHeadersVisible = false;
            this.dgv_data.RowHeadersWidth = 60;
            this.dgv_data.RowTemplate.Height = 40;
            this.dgv_data.Size = new System.Drawing.Size(1115, 367);
            this.dgv_data.TabIndex = 57;
            this.dgv_data.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_data.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_data.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_data.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_data.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_data.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_data.ThemeStyle.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_data.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_data.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_data.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_data.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_data.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_data.ThemeStyle.HeaderStyle.Height = 35;
            this.dgv_data.ThemeStyle.ReadOnly = false;
            this.dgv_data.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_data.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_data.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_data.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_data.ThemeStyle.RowsStyle.Height = 40;
            this.dgv_data.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_data.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Medicine";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Quantity ";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Price";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Total Amount";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(53, 370);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 24);
            this.label4.TabIndex = 55;
            this.label4.Text = "Customer:";
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
            this.btn_close.Location = new System.Drawing.Point(1085, 4);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(47, 31);
            this.btn_close.TabIndex = 1;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Rockwell Extra Bold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(421, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(236, 55);
            this.label6.TabIndex = 7;
            this.label6.Text = "HIEU LE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(427, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 25);
            this.label1.TabIndex = 60;
            this.label1.Text = "Address: Hung Yen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(427, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 25);
            this.label2.TabIndex = 61;
            this.label2.Text = "Gmail: hieule@gmail.com";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(427, 170);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 25);
            this.label3.TabIndex = 62;
            this.label3.Text = "Phone: 0987766565";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(427, 212);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(300, 25);
            this.label7.TabIndex = 63;
            this.label7.Text = "Website: hieuthuochieule.com.vn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.Location = new System.Drawing.Point(424, 277);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(251, 45);
            this.label8.TabIndex = 64;
            this.label8.Text = "SALE INVOICE";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Black;
            this.guna2Panel1.Location = new System.Drawing.Point(432, 244);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(267, 4);
            this.guna2Panel1.TabIndex = 65;
            // 
            // btn_print
            // 
            this.btn_print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_print.Image = global::DAn_QLCuaHangBanthuoc.Properties.Resources.printer;
            this.btn_print.ImageRotate = 0F;
            this.btn_print.Location = new System.Drawing.Point(1035, 4);
            this.btn_print.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(43, 37);
            this.btn_print.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_print.TabIndex = 66;
            this.btn_print.TabStop = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::DAn_QLCuaHangBanthuoc.Properties.Resources.Logo_Sức_khỏe_Biểu_tượng_Xanh_lam_Xanh_lá;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(-29, -70);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(429, 357);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 39;
            this.guna2PictureBox1.TabStop = false;
            // 
            // lbl_customer
            // 
            this.lbl_customer.AutoSize = true;
            this.lbl_customer.BackColor = System.Drawing.Color.Transparent;
            this.lbl_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_customer.ForeColor = System.Drawing.Color.Black;
            this.lbl_customer.Location = new System.Drawing.Point(165, 370);
            this.lbl_customer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_customer.Name = "lbl_customer";
            this.lbl_customer.Size = new System.Drawing.Size(21, 24);
            this.lbl_customer.TabIndex = 67;
            this.lbl_customer.Text = "a";
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.BackColor = System.Drawing.Color.Transparent;
            this.lbl_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_date.ForeColor = System.Drawing.Color.Black;
            this.lbl_date.Location = new System.Drawing.Point(864, 277);
            this.lbl_date.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(21, 24);
            this.lbl_date.TabIndex = 69;
            this.lbl_date.Text = "a";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(724, 277);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 24);
            this.label9.TabIndex = 68;
            this.label9.Text = "Date Created:";
            // 
            // pn_Print
            // 
            this.pn_Print.Controls.Add(this.cbo_status);
            this.pn_Print.Controls.Add(this.label11);
            this.pn_Print.Controls.Add(this.btn_edit);
            this.pn_Print.Controls.Add(this.lbl_date);
            this.pn_Print.Controls.Add(this.dgv_data);
            this.pn_Print.Controls.Add(this.label9);
            this.pn_Print.Controls.Add(this.lbl_price);
            this.pn_Print.Controls.Add(this.lbl_customer);
            this.pn_Print.Controls.Add(this.btn_print);
            this.pn_Print.Controls.Add(this.label7);
            this.pn_Print.Controls.Add(this.guna2Panel1);
            this.pn_Print.Controls.Add(this.label8);
            this.pn_Print.Controls.Add(this.btn_close);
            this.pn_Print.Controls.Add(this.label4);
            this.pn_Print.Controls.Add(this.label3);
            this.pn_Print.Controls.Add(this.label1);
            this.pn_Print.Controls.Add(this.label2);
            this.pn_Print.Controls.Add(this.label6);
            this.pn_Print.Controls.Add(this.guna2PictureBox1);
            this.pn_Print.FillColor = System.Drawing.Color.White;
            this.pn_Print.Location = new System.Drawing.Point(3, 2);
            this.pn_Print.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pn_Print.Name = "pn_Print";
            this.pn_Print.Size = new System.Drawing.Size(1140, 860);
            this.pn_Print.TabIndex = 38;
            // 
            // cbo_status
            // 
            this.cbo_status.BackColor = System.Drawing.Color.Transparent;
            this.cbo_status.BorderColor = System.Drawing.Color.Gray;
            this.cbo_status.BorderRadius = 10;
            this.cbo_status.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_status.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_status.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_status.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbo_status.ItemHeight = 30;
            this.cbo_status.Items.AddRange(new object[] {
            "Pending",
            "Completed"});
            this.cbo_status.Location = new System.Drawing.Point(715, 348);
            this.cbo_status.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbo_status.Name = "cbo_status";
            this.cbo_status.Size = new System.Drawing.Size(205, 36);
            this.cbo_status.TabIndex = 72;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(724, 322);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 24);
            this.label11.TabIndex = 71;
            this.label11.Text = "Status:";
            // 
            // btn_edit
            // 
            this.btn_edit.Animated = true;
            this.btn_edit.BackColor = System.Drawing.Color.White;
            this.btn_edit.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_edit.BorderRadius = 7;
            this.btn_edit.BorderThickness = 1;
            this.btn_edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_edit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_edit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_edit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_edit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_edit.FillColor = System.Drawing.Color.White;
            this.btn_edit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_edit.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btn_edit.HoverState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_edit.HoverState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btn_edit.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_edit.Image = global::DAn_QLCuaHangBanthuoc.Properties.Resources.pen;
            this.btn_edit.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_edit.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_edit.IndicateFocus = true;
            this.btn_edit.Location = new System.Drawing.Point(929, 347);
            this.btn_edit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(148, 46);
            this.btn_edit.TabIndex = 70;
            this.btn_edit.Text = "Update";
            this.btn_edit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // frm_show_sale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1145, 864);
            this.Controls.Add(this.pn_Print);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_show_sale";
            this.Text = "frm_show_sale";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_print)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.pn_Print.ResumeLayout(false);
            this.pn_Print.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_price;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_data;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ControlBox btn_close;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2PictureBox btn_print;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_customer;
        private Guna.UI2.WinForms.Guna2Panel pn_Print;
        private Guna.UI2.WinForms.Guna2ComboBox cbo_status;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2Button btn_edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}