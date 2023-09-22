namespace QuanLyHieuThuoc.KhachHang
{
    partial class DatHang
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
            this.viewThuoc = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.label5 = new System.Windows.Forms.Label();
            this.cbLo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSoLuonDat = new System.Windows.Forms.TextBox();
            this.btnThemDat = new System.Windows.Forms.Button();
            this.viewChiTietDat = new System.Windows.Forms.DataGridView();
            this.sMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMaLo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSoLuongMua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNgaySanXuat = new System.Windows.Forms.DateTimePicker();
            this.txtHanSuDung = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbDiaChi = new System.Windows.Forms.Label();
            this.lbSdt = new System.Windows.Forms.Label();
            this.btnHoanThanh = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.viewThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewChiTietDat)).BeginInit();
            this.SuspendLayout();
            // 
            // viewThuoc
            // 
            this.viewThuoc.AllowUserToAddRows = false;
            this.viewThuoc.AllowUserToDeleteRows = false;
            this.viewThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewThuoc.Location = new System.Drawing.Point(38, 75);
            this.viewThuoc.Name = "viewThuoc";
            this.viewThuoc.ReadOnly = true;
            this.viewThuoc.RowHeadersWidth = 51;
            this.viewThuoc.RowTemplate.Height = 24;
            this.viewThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.viewThuoc.Size = new System.Drawing.Size(654, 134);
            this.viewThuoc.TabIndex = 5;
            this.viewThuoc.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.viewThuoc_DataBindingComplete);
            this.viewThuoc.SelectionChanged += new System.EventHandler(this.viewThuoc_SelectionChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(121, 28);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(343, 22);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tìm kiếm";
            // 
            // txtThongTin
            // 
            this.txtThongTin.Location = new System.Drawing.Point(138, 317);
            this.txtThongTin.Name = "txtThongTin";
            this.txtThongTin.Size = new System.Drawing.Size(238, 62);
            this.txtThongTin.TabIndex = 32;
            this.txtThongTin.Text = "";
            // 
            // txtCachDung
            // 
            this.txtCachDung.Location = new System.Drawing.Point(138, 551);
            this.txtCachDung.Name = "txtCachDung";
            this.txtCachDung.Size = new System.Drawing.Size(238, 96);
            this.txtCachDung.TabIndex = 31;
            this.txtCachDung.Text = "";
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(138, 500);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(238, 22);
            this.txtGiaBan.TabIndex = 30;
            // 
            // txtHangSanXuat
            // 
            this.txtHangSanXuat.Location = new System.Drawing.Point(138, 455);
            this.txtHangSanXuat.Name = "txtHangSanXuat";
            this.txtHangSanXuat.Size = new System.Drawing.Size(238, 22);
            this.txtHangSanXuat.TabIndex = 29;
            // 
            // txtNuocSanXuat
            // 
            this.txtNuocSanXuat.Location = new System.Drawing.Point(138, 411);
            this.txtNuocSanXuat.Name = "txtNuocSanXuat";
            this.txtNuocSanXuat.Size = new System.Drawing.Size(238, 22);
            this.txtNuocSanXuat.TabIndex = 28;
            // 
            // txtTenLoaiThuoc
            // 
            this.txtTenLoaiThuoc.Location = new System.Drawing.Point(138, 275);
            this.txtTenLoaiThuoc.Name = "txtTenLoaiThuoc";
            this.txtTenLoaiThuoc.Size = new System.Drawing.Size(238, 22);
            this.txtTenLoaiThuoc.TabIndex = 27;
            // 
            // txtTenThuoc
            // 
            this.txtTenThuoc.Location = new System.Drawing.Point(138, 226);
            this.txtTenThuoc.Name = "txtTenThuoc";
            this.txtTenThuoc.Size = new System.Drawing.Size(238, 22);
            this.txtTenThuoc.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 551);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Cách dùng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 500);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 16);
            this.label8.TabIndex = 24;
            this.label8.Text = "Giá bán";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 455);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "Hãng sản xuất";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 411);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "Nước sản xuất";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Thông tin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Loại thuốc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tên Thuốc";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(471, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 16);
            this.label5.TabIndex = 33;
            this.label5.Text = "Chọn hạn sử dụng";
            // 
            // cbLo
            // 
            this.cbLo.FormattingEnabled = true;
            this.cbLo.Location = new System.Drawing.Point(474, 267);
            this.cbLo.Name = "cbLo";
            this.cbLo.Size = new System.Drawing.Size(218, 24);
            this.cbLo.TabIndex = 34;
            this.cbLo.SelectedIndexChanged += new System.EventHandler(this.cbLo_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(474, 316);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 16);
            this.label10.TabIndex = 35;
            this.label10.Text = "Ngày sản xuất";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(477, 381);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 16);
            this.label11.TabIndex = 36;
            this.label11.Text = "Hạn sử dụng";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(474, 453);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 16);
            this.label12.TabIndex = 37;
            this.label12.Text = "Số lượng đặt mua";
            // 
            // txtSoLuonDat
            // 
            this.txtSoLuonDat.Location = new System.Drawing.Point(477, 483);
            this.txtSoLuonDat.Name = "txtSoLuonDat";
            this.txtSoLuonDat.Size = new System.Drawing.Size(215, 22);
            this.txtSoLuonDat.TabIndex = 40;
            // 
            // btnThemDat
            // 
            this.btnThemDat.Location = new System.Drawing.Point(489, 551);
            this.btnThemDat.Name = "btnThemDat";
            this.btnThemDat.Size = new System.Drawing.Size(185, 36);
            this.btnThemDat.TabIndex = 41;
            this.btnThemDat.Text = "Thêm vào giỏ hàng";
            this.btnThemDat.UseVisualStyleBackColor = true;
            this.btnThemDat.Click += new System.EventHandler(this.btnThemDat_Click);
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
            this.viewChiTietDat.Location = new System.Drawing.Point(750, 66);
            this.viewChiTietDat.Name = "viewChiTietDat";
            this.viewChiTietDat.ReadOnly = true;
            this.viewChiTietDat.RowHeadersWidth = 51;
            this.viewChiTietDat.RowTemplate.Height = 24;
            this.viewChiTietDat.Size = new System.Drawing.Size(528, 512);
            this.viewChiTietDat.TabIndex = 42;
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
            // txtNgaySanXuat
            // 
            this.txtNgaySanXuat.Location = new System.Drawing.Point(477, 346);
            this.txtNgaySanXuat.Name = "txtNgaySanXuat";
            this.txtNgaySanXuat.Size = new System.Drawing.Size(215, 22);
            this.txtNgaySanXuat.TabIndex = 43;
            this.txtNgaySanXuat.Value = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            // 
            // txtHanSuDung
            // 
            this.txtHanSuDung.Location = new System.Drawing.Point(477, 410);
            this.txtHanSuDung.Name = "txtHanSuDung";
            this.txtHanSuDung.Size = new System.Drawing.Size(215, 22);
            this.txtHanSuDung.TabIndex = 44;
            this.txtHanSuDung.Value = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(759, 605);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 16);
            this.label13.TabIndex = 45;
            this.label13.Text = "Địa chỉ nhận: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(750, 641);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 16);
            this.label14.TabIndex = 46;
            this.label14.Text = "Số điện thoại : ";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // lbDiaChi
            // 
            this.lbDiaChi.AutoSize = true;
            this.lbDiaChi.Location = new System.Drawing.Point(851, 604);
            this.lbDiaChi.Name = "lbDiaChi";
            this.lbDiaChi.Size = new System.Drawing.Size(0, 16);
            this.lbDiaChi.TabIndex = 47;
            // 
            // lbSdt
            // 
            this.lbSdt.AutoSize = true;
            this.lbSdt.Location = new System.Drawing.Point(854, 641);
            this.lbSdt.Name = "lbSdt";
            this.lbSdt.Size = new System.Drawing.Size(0, 16);
            this.lbSdt.TabIndex = 48;
            // 
            // btnHoanThanh
            // 
            this.btnHoanThanh.Location = new System.Drawing.Point(394, 684);
            this.btnHoanThanh.Name = "btnHoanThanh";
            this.btnHoanThanh.Size = new System.Drawing.Size(614, 34);
            this.btnHoanThanh.TabIndex = 49;
            this.btnHoanThanh.Text = "Hoàn thành";
            this.btnHoanThanh.UseVisualStyleBackColor = true;
            this.btnHoanThanh.Click += new System.EventHandler(this.btnHoanThanh_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1174, 604);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 16);
            this.label15.TabIndex = 50;
            this.label15.Text = "Tổng tiền";
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Location = new System.Drawing.Point(1174, 641);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(0, 16);
            this.lbTongTien.TabIndex = 51;
            // 
            // DatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 744);
            this.Controls.Add(this.lbTongTien);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnHoanThanh);
            this.Controls.Add(this.lbSdt);
            this.Controls.Add(this.lbDiaChi);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtHanSuDung);
            this.Controls.Add(this.txtNgaySanXuat);
            this.Controls.Add(this.viewChiTietDat);
            this.Controls.Add(this.btnThemDat);
            this.Controls.Add(this.txtSoLuonDat);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
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
            this.Name = "DatHang";
            this.Text = "DatHang";
            this.Load += new System.EventHandler(this.DatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewChiTietDat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView viewThuoc;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbLo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSoLuonDat;
        private System.Windows.Forms.Button btnThemDat;
        private System.Windows.Forms.DataGridView viewChiTietDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn fGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMaLo;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSoLuongMua;
        private System.Windows.Forms.DateTimePicker txtNgaySanXuat;
        private System.Windows.Forms.DateTimePicker txtHanSuDung;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbDiaChi;
        private System.Windows.Forms.Label lbSdt;
        private System.Windows.Forms.Button btnHoanThanh;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbTongTien;
    }
}