namespace dentistry6boy
{
    partial class fAdmin
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tc = new System.Windows.Forms.TabControl();
            this.tpBill = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tpEmploy = new System.Windows.Forms.TabPage();
            this.btnRs = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDiachi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateNS = new System.Windows.Forms.DateTimePicker();
            this.rbtnNu = new System.Windows.Forms.RadioButton();
            this.rbtnNam = new System.Windows.Forms.RadioButton();
            this.txtHovaten = new System.Windows.Forms.TextBox();
            this.txtMaphong = new System.Windows.Forms.TextBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maNv = new System.Windows.Forms.Label();
            this.tpWarehouse = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnResetBN = new System.Windows.Forms.Button();
            this.btnXoaDV = new System.Windows.Forms.Button();
            this.btnSuaDV = new System.Windows.Forms.Button();
            this.btnRefDV = new System.Windows.Forms.Button();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.DGV_dv = new System.Windows.Forms.DataGridView();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tc.SuspendLayout();
            this.tpBill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tpEmploy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_dv)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tc
            // 
            this.tc.Controls.Add(this.tpBill);
            this.tc.Controls.Add(this.tpEmploy);
            this.tc.Controls.Add(this.tpWarehouse);
            this.tc.Controls.Add(this.tabPage1);
            this.tc.Location = new System.Drawing.Point(-3, 4);
            this.tc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(950, 444);
            this.tc.TabIndex = 1;
            // 
            // tpBill
            // 
            this.tpBill.Controls.Add(this.dataGridView1);
            this.tpBill.Location = new System.Drawing.Point(4, 29);
            this.tpBill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpBill.Name = "tpBill";
            this.tpBill.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpBill.Size = new System.Drawing.Size(942, 411);
            this.tpBill.TabIndex = 0;
            this.tpBill.Text = "Doanh thu";
            this.tpBill.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-4, -38);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(924, 368);
            this.dataGridView1.TabIndex = 0;
            // 
            // tpEmploy
            // 
            this.tpEmploy.Controls.Add(this.btnRs);
            this.tpEmploy.Controls.Add(this.btnAdd);
            this.tpEmploy.Controls.Add(this.dataGridView2);
            this.tpEmploy.Controls.Add(this.txtEmail);
            this.tpEmploy.Controls.Add(this.txtDiachi);
            this.tpEmploy.Controls.Add(this.label6);
            this.tpEmploy.Controls.Add(this.label1);
            this.tpEmploy.Controls.Add(this.dateNS);
            this.tpEmploy.Controls.Add(this.rbtnNu);
            this.tpEmploy.Controls.Add(this.rbtnNam);
            this.tpEmploy.Controls.Add(this.txtHovaten);
            this.tpEmploy.Controls.Add(this.txtMaphong);
            this.tpEmploy.Controls.Add(this.txtMaNV);
            this.tpEmploy.Controls.Add(this.label5);
            this.tpEmploy.Controls.Add(this.label4);
            this.tpEmploy.Controls.Add(this.label3);
            this.tpEmploy.Controls.Add(this.label2);
            this.tpEmploy.Controls.Add(this.maNv);
            this.tpEmploy.Location = new System.Drawing.Point(4, 29);
            this.tpEmploy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpEmploy.Name = "tpEmploy";
            this.tpEmploy.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpEmploy.Size = new System.Drawing.Size(942, 411);
            this.tpEmploy.TabIndex = 1;
            this.tpEmploy.Text = "Nhân viên";
            this.tpEmploy.UseVisualStyleBackColor = true;
            // 
            // btnRs
            // 
            this.btnRs.Location = new System.Drawing.Point(514, 168);
            this.btnRs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRs.Name = "btnRs";
            this.btnRs.Size = new System.Drawing.Size(84, 29);
            this.btnRs.TabIndex = 17;
            this.btnRs.Text = "Reset";
            this.btnRs.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(514, 99);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 29);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(641, 4);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(270, 330);
            this.dataGridView2.TabIndex = 15;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(133, 269);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(112, 26);
            this.txtEmail.TabIndex = 14;
            // 
            // txtDiachi
            // 
            this.txtDiachi.Location = new System.Drawing.Point(133, 221);
            this.txtDiachi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.Size = new System.Drawing.Size(112, 26);
            this.txtDiachi.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Địa chỉ";
            // 
            // dateNS
            // 
            this.dateNS.Location = new System.Drawing.Point(133, 171);
            this.dateNS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateNS.Name = "dateNS";
            this.dateNS.Size = new System.Drawing.Size(176, 26);
            this.dateNS.TabIndex = 10;
            // 
            // rbtnNu
            // 
            this.rbtnNu.AutoSize = true;
            this.rbtnNu.Location = new System.Drawing.Point(204, 119);
            this.rbtnNu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtnNu.Name = "rbtnNu";
            this.rbtnNu.Size = new System.Drawing.Size(54, 24);
            this.rbtnNu.TabIndex = 9;
            this.rbtnNu.TabStop = true;
            this.rbtnNu.Text = "Nữ";
            this.rbtnNu.UseVisualStyleBackColor = true;
            // 
            // rbtnNam
            // 
            this.rbtnNam.AutoSize = true;
            this.rbtnNam.Location = new System.Drawing.Point(133, 119);
            this.rbtnNam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtnNam.Name = "rbtnNam";
            this.rbtnNam.Size = new System.Drawing.Size(67, 24);
            this.rbtnNam.TabIndex = 8;
            this.rbtnNam.TabStop = true;
            this.rbtnNam.Text = "Nam";
            this.rbtnNam.UseVisualStyleBackColor = true;
            // 
            // txtHovaten
            // 
            this.txtHovaten.Location = new System.Drawing.Point(133, 66);
            this.txtHovaten.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHovaten.Name = "txtHovaten";
            this.txtHovaten.Size = new System.Drawing.Size(112, 26);
            this.txtHovaten.TabIndex = 7;
            // 
            // txtMaphong
            // 
            this.txtMaphong.Location = new System.Drawing.Point(397, 16);
            this.txtMaphong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaphong.Name = "txtMaphong";
            this.txtMaphong.Size = new System.Drawing.Size(112, 26);
            this.txtMaphong.TabIndex = 6;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(133, 20);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(112, 26);
            this.txtMaNV.TabIndex = 5;
            this.txtMaNV.TextChanged += new System.EventHandler(this.txtMaNV_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày sinh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giới tính";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Họ và tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã phòng";
            // 
            // maNv
            // 
            this.maNv.AutoSize = true;
            this.maNv.Location = new System.Drawing.Point(40, 24);
            this.maNv.Name = "maNv";
            this.maNv.Size = new System.Drawing.Size(57, 20);
            this.maNv.TabIndex = 0;
            this.maNv.Text = "Mã NV";
            this.maNv.Click += new System.EventHandler(this.label1_Click);
            // 
            // tpWarehouse
            // 
            this.tpWarehouse.Location = new System.Drawing.Point(4, 29);
            this.tpWarehouse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpWarehouse.Name = "tpWarehouse";
            this.tpWarehouse.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpWarehouse.Size = new System.Drawing.Size(942, 411);
            this.tpWarehouse.TabIndex = 2;
            this.tpWarehouse.Text = "Kho";
            this.tpWarehouse.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnResetBN);
            this.tabPage1.Controls.Add(this.btnXoaDV);
            this.tabPage1.Controls.Add(this.btnSuaDV);
            this.tabPage1.Controls.Add(this.btnRefDV);
            this.tabPage1.Controls.Add(this.btnThemDV);
            this.tabPage1.Controls.Add(this.DGV_dv);
            this.tabPage1.Controls.Add(this.txtPrice);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.txtServiceName);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(942, 411);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Dịch vụ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnResetBN
            // 
            this.btnResetBN.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnResetBN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnResetBN.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnResetBN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResetBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetBN.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnResetBN.Location = new System.Drawing.Point(532, 99);
            this.btnResetBN.Name = "btnResetBN";
            this.btnResetBN.Size = new System.Drawing.Size(75, 34);
            this.btnResetBN.TabIndex = 75;
            this.btnResetBN.Text = "Reset";
            this.btnResetBN.UseVisualStyleBackColor = false;
            // 
            // btnXoaDV
            // 
            this.btnXoaDV.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnXoaDV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnXoaDV.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXoaDV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXoaDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDV.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnXoaDV.Location = new System.Drawing.Point(428, 99);
            this.btnXoaDV.Name = "btnXoaDV";
            this.btnXoaDV.Size = new System.Drawing.Size(75, 34);
            this.btnXoaDV.TabIndex = 74;
            this.btnXoaDV.Text = "Xóa";
            this.btnXoaDV.UseVisualStyleBackColor = false;
            // 
            // btnSuaDV
            // 
            this.btnSuaDV.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSuaDV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSuaDV.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSuaDV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSuaDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaDV.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSuaDV.Location = new System.Drawing.Point(323, 99);
            this.btnSuaDV.Name = "btnSuaDV";
            this.btnSuaDV.Size = new System.Drawing.Size(75, 34);
            this.btnSuaDV.TabIndex = 73;
            this.btnSuaDV.Text = "Sửa ";
            this.btnSuaDV.UseVisualStyleBackColor = false;
            // 
            // btnRefDV
            // 
            this.btnRefDV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRefDV.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRefDV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefDV.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRefDV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefDV.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefDV.Location = new System.Drawing.Point(636, 99);
            this.btnRefDV.Name = "btnRefDV";
            this.btnRefDV.Size = new System.Drawing.Size(79, 34);
            this.btnRefDV.TabIndex = 72;
            this.btnRefDV.Text = "Refresh";
            this.btnRefDV.UseVisualStyleBackColor = false;
            // 
            // btnThemDV
            // 
            this.btnThemDV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThemDV.BackColor = System.Drawing.Color.Red;
            this.btnThemDV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnThemDV.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnThemDV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThemDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemDV.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnThemDV.Location = new System.Drawing.Point(211, 99);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(84, 34);
            this.btnThemDV.TabIndex = 71;
            this.btnThemDV.Text = "Thêm";
            this.btnThemDV.UseVisualStyleBackColor = false;
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
            // 
            // DGV_dv
            // 
            this.DGV_dv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_dv.Location = new System.Drawing.Point(59, 157);
            this.DGV_dv.Name = "DGV_dv";
            this.DGV_dv.RowHeadersWidth = 62;
            this.DGV_dv.RowTemplate.Height = 28;
            this.DGV_dv.Size = new System.Drawing.Size(812, 226);
            this.DGV_dv.TabIndex = 58;
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Location = new System.Drawing.Point(583, 46);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(268, 26);
            this.txtPrice.TabIndex = 57;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(468, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 22);
            this.label13.TabIndex = 56;
            this.label13.Text = "Giá cả";
            // 
            // txtServiceName
            // 
            this.txtServiceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServiceName.Location = new System.Drawing.Point(176, 46);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(271, 26);
            this.txtServiceName.TabIndex = 55;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(55, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(115, 22);
            this.label16.TabIndex = 54;
            this.label16.Text = "Tên dịch vụ";
            // 
            // fAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 450);
            this.Controls.Add(this.tc);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fAdmin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.fAdmin_Load);
            this.tc.ResumeLayout(false);
            this.tpBill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tpEmploy.ResumeLayout(false);
            this.tpEmploy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_dv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage tpBill;
        private System.Windows.Forms.TabPage tpEmploy;
        private System.Windows.Forms.TabPage tpWarehouse;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtHovaten;
        private System.Windows.Forms.TextBox txtMaphong;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label maNv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateNS;
        private System.Windows.Forms.RadioButton rbtnNu;
        private System.Windows.Forms.RadioButton rbtnNam;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDiachi;
        private System.Windows.Forms.Button btnRs;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView DGV_dv;
        private System.Windows.Forms.Button btnResetBN;
        private System.Windows.Forms.Button btnXoaDV;
        private System.Windows.Forms.Button btnSuaDV;
        private System.Windows.Forms.Button btnRefDV;
        private System.Windows.Forms.Button btnThemDV;
    }
}