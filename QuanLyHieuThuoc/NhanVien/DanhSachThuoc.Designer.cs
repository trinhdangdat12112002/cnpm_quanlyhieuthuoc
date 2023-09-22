namespace QuanLyHieuThuoc.NhanVien
{
    partial class DanhSachThuoc
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.viewThuoc = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTenThuoc = new System.Windows.Forms.TextBox();
            this.txtNuocSanXuat = new System.Windows.Forms.TextBox();
            this.txtHangSanXuat = new System.Windows.Forms.TextBox();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.txtCachDung = new System.Windows.Forms.RichTextBox();
            this.txtThongTin = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.cbbLoaiThuoc = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.viewThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(131, 369);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(499, 22);
            this.txtSearch.TabIndex = 21;
            // 
            // viewThuoc
            // 
            this.viewThuoc.AllowUserToAddRows = false;
            this.viewThuoc.AllowUserToDeleteRows = false;
            this.viewThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewThuoc.Location = new System.Drawing.Point(44, 406);
            this.viewThuoc.Name = "viewThuoc";
            this.viewThuoc.ReadOnly = true;
            this.viewThuoc.RowHeadersWidth = 51;
            this.viewThuoc.RowTemplate.Height = 24;
            this.viewThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.viewThuoc.Size = new System.Drawing.Size(1043, 193);
            this.viewThuoc.TabIndex = 22;
            this.viewThuoc.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.viewThuoc_DataBindingComplete);
            this.viewThuoc.SelectionChanged += new System.EventHandler(this.viewThuoc_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tên Thuốc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "Loại thuốc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Thông tin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(675, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "Nước sản xuất";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(675, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 27;
            this.label7.Text = "Hãng sản xuất";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(712, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 16);
            this.label8.TabIndex = 28;
            this.label8.Text = "Giá bán";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(695, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 16);
            this.label9.TabIndex = 29;
            this.label9.Text = "Cách dùng";
            // 
            // txtTenThuoc
            // 
            this.txtTenThuoc.Location = new System.Drawing.Point(137, 69);
            this.txtTenThuoc.Name = "txtTenThuoc";
            this.txtTenThuoc.Size = new System.Drawing.Size(238, 22);
            this.txtTenThuoc.TabIndex = 30;
            // 
            // txtNuocSanXuat
            // 
            this.txtNuocSanXuat.Location = new System.Drawing.Point(791, 55);
            this.txtNuocSanXuat.Name = "txtNuocSanXuat";
            this.txtNuocSanXuat.Size = new System.Drawing.Size(238, 22);
            this.txtNuocSanXuat.TabIndex = 32;
            // 
            // txtHangSanXuat
            // 
            this.txtHangSanXuat.Location = new System.Drawing.Point(791, 99);
            this.txtHangSanXuat.Name = "txtHangSanXuat";
            this.txtHangSanXuat.Size = new System.Drawing.Size(238, 22);
            this.txtHangSanXuat.TabIndex = 33;
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(791, 144);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(238, 22);
            this.txtGiaBan.TabIndex = 34;
            // 
            // txtCachDung
            // 
            this.txtCachDung.Location = new System.Drawing.Point(791, 195);
            this.txtCachDung.Name = "txtCachDung";
            this.txtCachDung.Size = new System.Drawing.Size(238, 96);
            this.txtCachDung.TabIndex = 35;
            this.txtCachDung.Text = "";
            // 
            // txtThongTin
            // 
            this.txtThongTin.Location = new System.Drawing.Point(137, 169);
            this.txtThongTin.Name = "txtThongTin";
            this.txtThongTin.Size = new System.Drawing.Size(493, 80);
            this.txtThongTin.TabIndex = 36;
            this.txtThongTin.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(131, 327);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 37;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(265, 326);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 38;
            this.btnSua.Text = "Chỉnh sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(412, 326);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 39;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnBoQua
            // 
            this.btnBoQua.Location = new System.Drawing.Point(564, 326);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(75, 23);
            this.btnBoQua.TabIndex = 40;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // cbbLoaiThuoc
            // 
            this.cbbLoaiThuoc.FormattingEnabled = true;
            this.cbbLoaiThuoc.Location = new System.Drawing.Point(137, 118);
            this.cbbLoaiThuoc.Name = "cbbLoaiThuoc";
            this.cbbLoaiThuoc.Size = new System.Drawing.Size(238, 24);
            this.cbbLoaiThuoc.TabIndex = 41;
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(728, 326);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(75, 23);
            this.btnLoc.TabIndex = 42;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            // 
            // DanhSachThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 671);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.cbbLoaiThuoc);
            this.Controls.Add(this.btnBoQua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtThongTin);
            this.Controls.Add(this.txtCachDung);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.txtHangSanXuat);
            this.Controls.Add(this.txtNuocSanXuat);
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
            this.Name = "DanhSachThuoc";
            this.Text = "DanhSachLoaiThuoc";
            this.Load += new System.EventHandler(this.DanhSachThuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewThuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView viewThuoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTenThuoc;
        private System.Windows.Forms.TextBox txtNuocSanXuat;
        private System.Windows.Forms.TextBox txtHangSanXuat;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.RichTextBox txtCachDung;
        private System.Windows.Forms.RichTextBox txtThongTin;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.ComboBox cbbLoaiThuoc;
        private System.Windows.Forms.Button btnLoc;
    }
}