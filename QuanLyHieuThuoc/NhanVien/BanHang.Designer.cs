namespace QuanLyHieuThuoc.NhanVien
{
    partial class BanHang
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
            this.label15 = new System.Windows.Forms.Label();
            this.viewChiTietDat = new System.Windows.Forms.DataGridView();
            this.sMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMaLo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSoLuongMua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtSoLuonDat = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnHoanThanh = new System.Windows.Forms.Button();
            this.txtHanSuDung = new System.Windows.Forms.DateTimePicker();
            this.txtNgaySanXuat = new System.Windows.Forms.DateTimePicker();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbLo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtThongTin = new System.Windows.Forms.RichTextBox();
            this.txtCachDung = new System.Windows.Forms.RichTextBox();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.txtHangSanXuat = new System.Windows.Forms.TextBox();
            this.txtNuocSanXuat = new System.Windows.Forms.TextBox();
            this.txtTenLoaiThuoc = new System.Windows.Forms.TextBox();
            this.txtTenThuoc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.viewThuoc = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.viewChiTietDat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1173, 604);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 16);
            this.label15.TabIndex = 84;
            this.label15.Text = "Tổng tiền";
            // 
            // viewChiTietDat
            // 
            this.viewChiTietDat.AllowUserToAddRows = false;
            this.viewChiTietDat.AllowUserToDeleteRows = false;
            this.viewChiTietDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewChiTietDat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sMaSP,
            this.sTenSP,
            this.fGiaBan,
            this.sMaLo,
            this.iSoLuongMua});
            this.viewChiTietDat.Location = new System.Drawing.Point(749, 66);
            this.viewChiTietDat.Name = "viewChiTietDat";
            this.viewChiTietDat.ReadOnly = true;
            this.viewChiTietDat.RowHeadersWidth = 51;
            this.viewChiTietDat.RowTemplate.Height = 24;
            this.viewChiTietDat.Size = new System.Drawing.Size(528, 512);
            this.viewChiTietDat.TabIndex = 76;
            // 
            // sMaSP
            // 
            this.sMaSP.HeaderText = "Mã Sản Phẩm";
            this.sMaSP.MinimumWidth = 6;
            this.sMaSP.Name = "sMaSP";
            this.sMaSP.ReadOnly = true;
            this.sMaSP.Width = 125;
            // 
            // sTenSP
            // 
            this.sTenSP.HeaderText = "Tên Sản Phẩm";
            this.sTenSP.MinimumWidth = 6;
            this.sTenSP.Name = "sTenSP";
            this.sTenSP.ReadOnly = true;
            this.sTenSP.Width = 125;
            // 
            // fGiaBan
            // 
            this.fGiaBan.HeaderText = "Giá";
            this.fGiaBan.MinimumWidth = 6;
            this.fGiaBan.Name = "fGiaBan";
            this.fGiaBan.ReadOnly = true;
            this.fGiaBan.Width = 125;
            // 
            // sMaLo
            // 
            this.sMaLo.HeaderText = "Mã Lô";
            this.sMaLo.MinimumWidth = 6;
            this.sMaLo.Name = "sMaLo";
            this.sMaLo.ReadOnly = true;
            this.sMaLo.Width = 125;
            // 
            // iSoLuongMua
            // 
            this.iSoLuongMua.HeaderText = "Số lượng mua";
            this.iSoLuongMua.MinimumWidth = 6;
            this.iSoLuongMua.Name = "iSoLuongMua";
            this.iSoLuongMua.ReadOnly = true;
            this.iSoLuongMua.Width = 125;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(488, 551);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(185, 36);
            this.btnThem.TabIndex = 75;
            this.btnThem.Text = "Thêm vào hóa đơn";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtSoLuonDat
            // 
            this.txtSoLuonDat.Location = new System.Drawing.Point(476, 483);
            this.txtSoLuonDat.Name = "txtSoLuonDat";
            this.txtSoLuonDat.Size = new System.Drawing.Size(215, 22);
            this.txtSoLuonDat.TabIndex = 74;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(473, 453);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 16);
            this.label12.TabIndex = 73;
            this.label12.Text = "Số lượng đặt mua";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(476, 381);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 16);
            this.label11.TabIndex = 72;
            this.label11.Text = "Hạn sử dụng";
            // 
            // btnHoanThanh
            // 
            this.btnHoanThanh.Location = new System.Drawing.Point(393, 684);
            this.btnHoanThanh.Name = "btnHoanThanh";
            this.btnHoanThanh.Size = new System.Drawing.Size(614, 34);
            this.btnHoanThanh.TabIndex = 83;
            this.btnHoanThanh.Text = "Hoàn thành";
            this.btnHoanThanh.UseVisualStyleBackColor = true;
            // 
            // txtHanSuDung
            // 
            this.txtHanSuDung.Location = new System.Drawing.Point(476, 410);
            this.txtHanSuDung.Name = "txtHanSuDung";
            this.txtHanSuDung.Size = new System.Drawing.Size(215, 22);
            this.txtHanSuDung.TabIndex = 78;
            this.txtHanSuDung.Value = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            // 
            // txtNgaySanXuat
            // 
            this.txtNgaySanXuat.Location = new System.Drawing.Point(476, 346);
            this.txtNgaySanXuat.Name = "txtNgaySanXuat";
            this.txtNgaySanXuat.Size = new System.Drawing.Size(215, 22);
            this.txtNgaySanXuat.TabIndex = 77;
            this.txtNgaySanXuat.Value = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Location = new System.Drawing.Point(1173, 641);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(0, 16);
            this.lbTongTien.TabIndex = 85;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(473, 316);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 16);
            this.label10.TabIndex = 71;
            this.label10.Text = "Ngày sản xuất";
            // 
            // cbLo
            // 
            this.cbLo.FormattingEnabled = true;
            this.cbLo.Location = new System.Drawing.Point(473, 267);
            this.cbLo.Name = "cbLo";
            this.cbLo.Size = new System.Drawing.Size(218, 24);
            this.cbLo.TabIndex = 70;
            this.cbLo.SelectedIndexChanged += new System.EventHandler(this.cbLo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(470, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 69;
            this.label5.Text = "Chọn Lô";
            // 
            // txtThongTin
            // 
            this.txtThongTin.Location = new System.Drawing.Point(137, 317);
            this.txtThongTin.Name = "txtThongTin";
            this.txtThongTin.Size = new System.Drawing.Size(238, 62);
            this.txtThongTin.TabIndex = 68;
            this.txtThongTin.Text = "";
            // 
            // txtCachDung
            // 
            this.txtCachDung.Location = new System.Drawing.Point(137, 551);
            this.txtCachDung.Name = "txtCachDung";
            this.txtCachDung.Size = new System.Drawing.Size(238, 96);
            this.txtCachDung.TabIndex = 67;
            this.txtCachDung.Text = "";
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(137, 500);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(238, 22);
            this.txtGiaBan.TabIndex = 66;
            // 
            // txtHangSanXuat
            // 
            this.txtHangSanXuat.Location = new System.Drawing.Point(137, 455);
            this.txtHangSanXuat.Name = "txtHangSanXuat";
            this.txtHangSanXuat.Size = new System.Drawing.Size(238, 22);
            this.txtHangSanXuat.TabIndex = 65;
            // 
            // txtNuocSanXuat
            // 
            this.txtNuocSanXuat.Location = new System.Drawing.Point(137, 411);
            this.txtNuocSanXuat.Name = "txtNuocSanXuat";
            this.txtNuocSanXuat.Size = new System.Drawing.Size(238, 22);
            this.txtNuocSanXuat.TabIndex = 64;
            // 
            // txtTenLoaiThuoc
            // 
            this.txtTenLoaiThuoc.Location = new System.Drawing.Point(137, 275);
            this.txtTenLoaiThuoc.Name = "txtTenLoaiThuoc";
            this.txtTenLoaiThuoc.Size = new System.Drawing.Size(238, 22);
            this.txtTenLoaiThuoc.TabIndex = 63;
            // 
            // txtTenThuoc
            // 
            this.txtTenThuoc.Location = new System.Drawing.Point(137, 226);
            this.txtTenThuoc.Name = "txtTenThuoc";
            this.txtTenThuoc.Size = new System.Drawing.Size(238, 22);
            this.txtTenThuoc.TabIndex = 62;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 551);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 16);
            this.label9.TabIndex = 61;
            this.label9.Text = "Cách dùng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 500);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 16);
            this.label8.TabIndex = 60;
            this.label8.Text = "Giá bán";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 455);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 59;
            this.label7.Text = "Hãng sản xuất";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 411);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 58;
            this.label6.Text = "Nước sản xuất";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 57;
            this.label4.Text = "Thông tin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 56;
            this.label3.Text = "Loại thuốc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 55;
            this.label2.Text = "Tên Thuốc";
            // 
            // viewThuoc
            // 
            this.viewThuoc.AllowUserToAddRows = false;
            this.viewThuoc.AllowUserToDeleteRows = false;
            this.viewThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewThuoc.Location = new System.Drawing.Point(37, 75);
            this.viewThuoc.Name = "viewThuoc";
            this.viewThuoc.ReadOnly = true;
            this.viewThuoc.RowHeadersWidth = 51;
            this.viewThuoc.RowTemplate.Height = 24;
            this.viewThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.viewThuoc.Size = new System.Drawing.Size(654, 134);
            this.viewThuoc.TabIndex = 54;
            this.viewThuoc.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.viewThuoc_DataBindingComplete);
            this.viewThuoc.SelectionChanged += new System.EventHandler(this.viewThuoc_SelectionChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(120, 28);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(343, 22);
            this.txtSearch.TabIndex = 53;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 52;
            this.label1.Text = "Tìm kiếm";
            // 
            // BanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 772);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.viewChiTietDat);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtSoLuonDat);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnHoanThanh);
            this.Controls.Add(this.txtHanSuDung);
            this.Controls.Add(this.txtNgaySanXuat);
            this.Controls.Add(this.lbTongTien);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbLo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtThongTin);
            this.Controls.Add(this.txtCachDung);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.txtHangSanXuat);
            this.Controls.Add(this.txtNuocSanXuat);
            this.Controls.Add(this.txtTenLoaiThuoc);
            this.Controls.Add(this.txtTenThuoc);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.viewThuoc);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Name = "BanHang";
            this.Text = "BanHang";
            this.Load += new System.EventHandler(this.BanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewChiTietDat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewThuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView viewChiTietDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn fGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMaLo;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSoLuongMua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtSoLuonDat;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnHoanThanh;
        private System.Windows.Forms.DateTimePicker txtHanSuDung;
        private System.Windows.Forms.DateTimePicker txtNgaySanXuat;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbLo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtThongTin;
        private System.Windows.Forms.RichTextBox txtCachDung;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.TextBox txtHangSanXuat;
        private System.Windows.Forms.TextBox txtNuocSanXuat;
        private System.Windows.Forms.TextBox txtTenLoaiThuoc;
        private System.Windows.Forms.TextBox txtTenThuoc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView viewThuoc;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
    }
}