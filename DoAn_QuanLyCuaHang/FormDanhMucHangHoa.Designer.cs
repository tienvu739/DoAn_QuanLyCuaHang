namespace DoAn_QuanLyCuaHang
{
    partial class FormDanhMucHangHoa
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btLuu = new System.Windows.Forms.Button();
            this.btDong = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.btBoQua = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMo = new System.Windows.Forms.Button();
            this.pictureAnh = new System.Windows.Forms.PictureBox();
            this.comboBoxMaChatLieu = new System.Windows.Forms.ComboBox();
            this.textDonGiaBan = new System.Windows.Forms.TextBox();
            this.textDonGiaNhap = new System.Windows.Forms.TextBox();
            this.textSoLuong = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textGhiChu = new System.Windows.Forms.TextBox();
            this.textAnh = new System.Windows.Forms.TextBox();
            this.textTenHang = new System.Windows.Forms.TextBox();
            this.textMaHang = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btTimKiem = new System.Windows.Forms.Button();
            this.btHienThi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAnh)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(976, 264);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btHienThi);
            this.panel1.Controls.Add(this.btTimKiem);
            this.panel1.Controls.Add(this.btLuu);
            this.panel1.Controls.Add(this.btDong);
            this.panel1.Controls.Add(this.btThem);
            this.panel1.Controls.Add(this.btBoQua);
            this.panel1.Controls.Add(this.btXoa);
            this.panel1.Controls.Add(this.btSua);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 507);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 58);
            this.panel1.TabIndex = 7;
            // 
            // btLuu
            // 
            this.btLuu.Location = new System.Drawing.Point(409, 18);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(75, 23);
            this.btLuu.TabIndex = 3;
            this.btLuu.Text = "Lưu";
            this.btLuu.UseVisualStyleBackColor = true;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // btDong
            // 
            this.btDong.Location = new System.Drawing.Point(866, 18);
            this.btDong.Name = "btDong";
            this.btDong.Size = new System.Drawing.Size(75, 23);
            this.btDong.TabIndex = 5;
            this.btDong.Text = "Đóng";
            this.btDong.UseVisualStyleBackColor = true;
            this.btDong.Click += new System.EventHandler(this.btDong_Click);
            // 
            // btThem
            // 
            this.btThem.Location = new System.Drawing.Point(41, 18);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(75, 23);
            this.btThem.TabIndex = 0;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // btBoQua
            // 
            this.btBoQua.Location = new System.Drawing.Point(535, 18);
            this.btBoQua.Name = "btBoQua";
            this.btBoQua.Size = new System.Drawing.Size(75, 23);
            this.btBoQua.TabIndex = 4;
            this.btBoQua.Text = "Bỏ qua";
            this.btBoQua.UseVisualStyleBackColor = true;
            this.btBoQua.Click += new System.EventHandler(this.btBoQua_Click);
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(159, 18);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(75, 23);
            this.btXoa.TabIndex = 1;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btSua
            // 
            this.btSua.Location = new System.Drawing.Point(284, 18);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(75, 23);
            this.btSua.TabIndex = 2;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnMo);
            this.panel2.Controls.Add(this.pictureAnh);
            this.panel2.Controls.Add(this.comboBoxMaChatLieu);
            this.panel2.Controls.Add(this.textDonGiaBan);
            this.panel2.Controls.Add(this.textDonGiaNhap);
            this.panel2.Controls.Add(this.textSoLuong);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textGhiChu);
            this.panel2.Controls.Add(this.textAnh);
            this.panel2.Controls.Add(this.textTenHang);
            this.panel2.Controls.Add(this.textMaHang);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(976, 247);
            this.panel2.TabIndex = 8;
            // 
            // btnMo
            // 
            this.btnMo.Location = new System.Drawing.Point(604, 22);
            this.btnMo.Name = "btnMo";
            this.btnMo.Size = new System.Drawing.Size(75, 23);
            this.btnMo.TabIndex = 17;
            this.btnMo.Text = "Mở";
            this.btnMo.UseVisualStyleBackColor = true;
            this.btnMo.Click += new System.EventHandler(this.btnMo_Click);
            // 
            // pictureAnh
            // 
            this.pictureAnh.Location = new System.Drawing.Point(707, 19);
            this.pictureAnh.Name = "pictureAnh";
            this.pictureAnh.Size = new System.Drawing.Size(234, 210);
            this.pictureAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureAnh.TabIndex = 16;
            this.pictureAnh.TabStop = false;
            // 
            // comboBoxMaChatLieu
            // 
            this.comboBoxMaChatLieu.FormattingEnabled = true;
            this.comboBoxMaChatLieu.Location = new System.Drawing.Point(159, 96);
            this.comboBoxMaChatLieu.Name = "comboBoxMaChatLieu";
            this.comboBoxMaChatLieu.Size = new System.Drawing.Size(200, 24);
            this.comboBoxMaChatLieu.TabIndex = 15;
            // 
            // textDonGiaBan
            // 
            this.textDonGiaBan.Location = new System.Drawing.Point(159, 216);
            this.textDonGiaBan.Name = "textDonGiaBan";
            this.textDonGiaBan.Size = new System.Drawing.Size(200, 22);
            this.textDonGiaBan.TabIndex = 14;
            // 
            // textDonGiaNhap
            // 
            this.textDonGiaNhap.Location = new System.Drawing.Point(159, 179);
            this.textDonGiaNhap.Name = "textDonGiaNhap";
            this.textDonGiaNhap.Size = new System.Drawing.Size(200, 22);
            this.textDonGiaNhap.TabIndex = 13;
            // 
            // textSoLuong
            // 
            this.textSoLuong.Location = new System.Drawing.Point(159, 140);
            this.textSoLuong.Name = "textSoLuong";
            this.textSoLuong.Size = new System.Drawing.Size(200, 22);
            this.textSoLuong.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Đơn giá bán";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Đơn giá nhập";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Số lượng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mã chất liệu";
            // 
            // textGhiChu
            // 
            this.textGhiChu.Location = new System.Drawing.Point(409, 115);
            this.textGhiChu.Multiline = true;
            this.textGhiChu.Name = "textGhiChu";
            this.textGhiChu.Size = new System.Drawing.Size(201, 123);
            this.textGhiChu.TabIndex = 4;
            // 
            // textAnh
            // 
            this.textAnh.Location = new System.Drawing.Point(443, 12);
            this.textAnh.Multiline = true;
            this.textAnh.Name = "textAnh";
            this.textAnh.Size = new System.Drawing.Size(155, 37);
            this.textAnh.TabIndex = 3;
            // 
            // textTenHang
            // 
            this.textTenHang.Location = new System.Drawing.Point(159, 58);
            this.textTenHang.Name = "textTenHang";
            this.textTenHang.Size = new System.Drawing.Size(200, 22);
            this.textTenHang.TabIndex = 1;
            // 
            // textMaHang
            // 
            this.textMaHang.Location = new System.Drawing.Point(159, 19);
            this.textMaHang.Name = "textMaHang";
            this.textMaHang.Size = new System.Drawing.Size(200, 22);
            this.textMaHang.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(406, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ghi chú";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(407, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ảnh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hàng";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Location = new System.Drawing.Point(0, 244);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(976, 264);
            this.panel3.TabIndex = 9;
            // 
            // btTimKiem
            // 
            this.btTimKiem.Location = new System.Drawing.Point(642, 18);
            this.btTimKiem.Name = "btTimKiem";
            this.btTimKiem.Size = new System.Drawing.Size(88, 23);
            this.btTimKiem.TabIndex = 6;
            this.btTimKiem.Text = "Tìm kiếm";
            this.btTimKiem.UseVisualStyleBackColor = true;
            this.btTimKiem.Click += new System.EventHandler(this.btTimKiem_Click);
            // 
            // btHienThi
            // 
            this.btHienThi.Location = new System.Drawing.Point(757, 18);
            this.btHienThi.Name = "btHienThi";
            this.btHienThi.Size = new System.Drawing.Size(75, 23);
            this.btHienThi.TabIndex = 7;
            this.btHienThi.Text = "HTDS";
            this.btHienThi.UseVisualStyleBackColor = true;
            this.btHienThi.Click += new System.EventHandler(this.btHienThi_Click);
            // 
            // FormDanhMucHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 565);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormDanhMucHangHoa";
            this.Text = "FormDanhMucHangHoa";
            this.Load += new System.EventHandler(this.FormDanhMucHangHoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAnh)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.Button btDong;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btBoQua;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textGhiChu;
        private System.Windows.Forms.TextBox textAnh;
        private System.Windows.Forms.TextBox textTenHang;
        private System.Windows.Forms.TextBox textMaHang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textDonGiaBan;
        private System.Windows.Forms.TextBox textDonGiaNhap;
        private System.Windows.Forms.TextBox textSoLuong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxMaChatLieu;
        private System.Windows.Forms.Button btnMo;
        private System.Windows.Forms.PictureBox pictureAnh;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btHienThi;
        private System.Windows.Forms.Button btTimKiem;
    }
}