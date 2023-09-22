namespace QuanLyHieuThuoc
{
    partial class HoaDonNhap
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.viewThuoc = new System.Windows.Forms.DataGridView();
            this.txtSoLuongNhap = new System.Windows.Forms.TextBox();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.viewChiTiet = new System.Windows.Forms.DataGridView();
            this.maDuocPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenDuocPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuongNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtThemThuoc = new System.Windows.Forms.Button();
            this.txtNgayNhap = new System.Windows.Forms.TextBox();
            this.btnXoaChiTiet = new System.Windows.Forms.Button();
            this.cbbNhaCungCap = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.viewThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Danh sách hàng hiện có";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(100, 66);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(224, 22);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // viewThuoc
            // 
            this.viewThuoc.AllowUserToAddRows = false;
            this.viewThuoc.AllowUserToDeleteRows = false;
            this.viewThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewThuoc.Location = new System.Drawing.Point(23, 110);
            this.viewThuoc.Name = "viewThuoc";
            this.viewThuoc.ReadOnly = true;
            this.viewThuoc.RowHeadersWidth = 51;
            this.viewThuoc.RowTemplate.Height = 24;
            this.viewThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.viewThuoc.Size = new System.Drawing.Size(681, 407);
            this.viewThuoc.TabIndex = 3;
            this.viewThuoc.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.viewThuoc_DataBindingComplete);
            this.viewThuoc.SelectionChanged += new System.EventHandler(this.viewThuoc_SelectionChanged);
            // 
            // txtSoLuongNhap
            // 
            this.txtSoLuongNhap.Location = new System.Drawing.Point(733, 145);
            this.txtSoLuongNhap.Name = "txtSoLuongNhap";
            this.txtSoLuongNhap.Size = new System.Drawing.Size(100, 22);
            this.txtSoLuongNhap.TabIndex = 4;
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Location = new System.Drawing.Point(733, 221);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(100, 22);
            this.txtGiaNhap.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(733, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Số lượng nhập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(733, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Giá nhập";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(733, 337);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 23);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // viewChiTiet
            // 
            this.viewChiTiet.AllowUserToAddRows = false;
            this.viewChiTiet.AllowUserToDeleteRows = false;
            this.viewChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maDuocPham,
            this.tenDuocPham,
            this.soLuongNhap,
            this.giaNhap});
            this.viewChiTiet.Location = new System.Drawing.Point(857, 110);
            this.viewChiTiet.Name = "viewChiTiet";
            this.viewChiTiet.ReadOnly = true;
            this.viewChiTiet.RowHeadersWidth = 51;
            this.viewChiTiet.RowTemplate.Height = 24;
            this.viewChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.viewChiTiet.Size = new System.Drawing.Size(606, 407);
            this.viewChiTiet.TabIndex = 9;
            // 
            // maDuocPham
            // 
            this.maDuocPham.HeaderText = "Mã";
            this.maDuocPham.MinimumWidth = 6;
            this.maDuocPham.Name = "maDuocPham";
            this.maDuocPham.ReadOnly = true;
            this.maDuocPham.Width = 50;
            // 
            // tenDuocPham
            // 
            this.tenDuocPham.HeaderText = "Tên";
            this.tenDuocPham.MinimumWidth = 6;
            this.tenDuocPham.Name = "tenDuocPham";
            this.tenDuocPham.ReadOnly = true;
            this.tenDuocPham.Width = 125;
            // 
            // soLuongNhap
            // 
            this.soLuongNhap.HeaderText = "Số lượng";
            this.soLuongNhap.MinimumWidth = 6;
            this.soLuongNhap.Name = "soLuongNhap";
            this.soLuongNhap.ReadOnly = true;
            this.soLuongNhap.Width = 125;
            // 
            // giaNhap
            // 
            this.giaNhap.HeaderText = "Giá Nhập";
            this.giaNhap.MinimumWidth = 6;
            this.giaNhap.Name = "giaNhap";
            this.giaNhap.ReadOnly = true;
            this.giaNhap.Width = 125;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 548);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nhà Cung Cấp";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 548);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Ngày Nhập";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 598);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ghi Chú";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(23, 628);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(732, 100);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(540, 734);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(472, 46);
            this.button1.TabIndex = 14;
            this.button1.Text = "Hoàn Thành";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(506, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(193, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Thuốc chưa có trong danh sách";
            // 
            // txtThemThuoc
            // 
            this.txtThemThuoc.Location = new System.Drawing.Point(509, 65);
            this.txtThemThuoc.Name = "txtThemThuoc";
            this.txtThemThuoc.Size = new System.Drawing.Size(190, 23);
            this.txtThemThuoc.TabIndex = 16;
            this.txtThemThuoc.Text = "Thêm thuốc";
            this.txtThemThuoc.UseVisualStyleBackColor = true;
            // 
            // txtNgayNhap
            // 
            this.txtNgayNhap.Location = new System.Drawing.Point(415, 548);
            this.txtNgayNhap.Name = "txtNgayNhap";
            this.txtNgayNhap.Size = new System.Drawing.Size(100, 22);
            this.txtNgayNhap.TabIndex = 18;
            // 
            // btnXoaChiTiet
            // 
            this.btnXoaChiTiet.Location = new System.Drawing.Point(848, 540);
            this.btnXoaChiTiet.Name = "btnXoaChiTiet";
            this.btnXoaChiTiet.Size = new System.Drawing.Size(131, 23);
            this.btnXoaChiTiet.TabIndex = 19;
            this.btnXoaChiTiet.Text = "Xóa khỏi danh sách";
            this.btnXoaChiTiet.UseVisualStyleBackColor = true;
            this.btnXoaChiTiet.Click += new System.EventHandler(this.btnXoaChiTiet_Click);
            // 
            // cbbNhaCungCap
            // 
            this.cbbNhaCungCap.FormattingEnabled = true;
            this.cbbNhaCungCap.Location = new System.Drawing.Point(134, 545);
            this.cbbNhaCungCap.Name = "cbbNhaCungCap";
            this.cbbNhaCungCap.Size = new System.Drawing.Size(141, 24);
            this.cbbNhaCungCap.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1187, 553);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Tổng tiền : ";
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Location = new System.Drawing.Point(1265, 553);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(0, 16);
            this.lbTongTien.TabIndex = 22;
            // 
            // btnBoQua
            // 
            this.btnBoQua.Location = new System.Drawing.Point(733, 384);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(100, 23);
            this.btnBoQua.TabIndex = 23;
            this.btnBoQua.Text = "Hủy thao tác";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(733, 260);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 16);
            this.label10.TabIndex = 24;
            this.label10.Text = "Đơn vị";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Thùng",
            "Vỉ",
            "Lon",
            "Cân"});
            this.comboBox1.Location = new System.Drawing.Point(733, 295);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 24);
            this.comboBox1.TabIndex = 25;
            // 
            // HoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1566, 849);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnBoQua);
            this.Controls.Add(this.lbTongTien);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbbNhaCungCap);
            this.Controls.Add(this.btnXoaChiTiet);
            this.Controls.Add(this.txtNgayNhap);
            this.Controls.Add(this.txtThemThuoc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.viewChiTiet);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGiaNhap);
            this.Controls.Add(this.txtSoLuongNhap);
            this.Controls.Add(this.viewThuoc);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HoaDonNhap";
            this.Text = "Nhập";
            this.Load += new System.EventHandler(this.HoaDonNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewChiTiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView viewThuoc;
        private System.Windows.Forms.TextBox txtSoLuongNhap;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView viewChiTiet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDuocPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenDuocPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuongNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaNhap;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button txtThemThuoc;
        private System.Windows.Forms.TextBox txtNgayNhap;
        private System.Windows.Forms.Button btnXoaChiTiet;
        private System.Windows.Forms.ComboBox cbbNhaCungCap;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}