namespace QuanLyHieuThuoc.NhanVien
{
    partial class DanhSachLoHang
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaLo = new System.Windows.Forms.TextBox();
            this.txtNgaySX = new System.Windows.Forms.DateTimePicker();
            this.txtHanSD = new System.Windows.Forms.DateTimePicker();
            this.viewLoHang = new System.Windows.Forms.DataGridView();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.viewThuoc = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.viewLoHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Lô Hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày Sản Xuất";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hạn Sử Dụng";
            // 
            // txtMaLo
            // 
            this.txtMaLo.Location = new System.Drawing.Point(191, 81);
            this.txtMaLo.Name = "txtMaLo";
            this.txtMaLo.Size = new System.Drawing.Size(200, 22);
            this.txtMaLo.TabIndex = 3;
            // 
            // txtNgaySX
            // 
            this.txtNgaySX.Location = new System.Drawing.Point(191, 129);
            this.txtNgaySX.Name = "txtNgaySX";
            this.txtNgaySX.Size = new System.Drawing.Size(200, 22);
            this.txtNgaySX.TabIndex = 4;
            // 
            // txtHanSD
            // 
            this.txtHanSD.Location = new System.Drawing.Point(191, 173);
            this.txtHanSD.Name = "txtHanSD";
            this.txtHanSD.Size = new System.Drawing.Size(200, 22);
            this.txtHanSD.TabIndex = 5;
            // 
            // viewLoHang
            // 
            this.viewLoHang.AllowUserToAddRows = false;
            this.viewLoHang.AllowUserToDeleteRows = false;
            this.viewLoHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewLoHang.Location = new System.Drawing.Point(55, 284);
            this.viewLoHang.Name = "viewLoHang";
            this.viewLoHang.ReadOnly = true;
            this.viewLoHang.RowHeadersWidth = 51;
            this.viewLoHang.RowTemplate.Height = 24;
            this.viewLoHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.viewLoHang.Size = new System.Drawing.Size(428, 277);
            this.viewLoHang.TabIndex = 6;
            this.viewLoHang.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.viewLoHang_DataBindingComplete);
            this.viewLoHang.SelectionChanged += new System.EventHandler(this.viewLoHang_SelectionChanged);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Location = new System.Drawing.Point(392, 226);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(91, 31);
            this.btnBoQua.TabIndex = 13;
            this.btnBoQua.Text = "Bỏ Qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(280, 226);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(91, 31);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(167, 226);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(91, 31);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(57, 226);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(91, 31);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(794, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "DANH SÁCH THUỐC";
            // 
            // viewThuoc
            // 
            this.viewThuoc.AllowUserToAddRows = false;
            this.viewThuoc.AllowUserToDeleteRows = false;
            this.viewThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewThuoc.Location = new System.Drawing.Point(550, 81);
            this.viewThuoc.Name = "viewThuoc";
            this.viewThuoc.ReadOnly = true;
            this.viewThuoc.RowHeadersWidth = 51;
            this.viewThuoc.RowTemplate.Height = 24;
            this.viewThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.viewThuoc.Size = new System.Drawing.Size(589, 480);
            this.viewThuoc.TabIndex = 14;
            // 
            // DanhSachLoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 613);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.viewThuoc);
            this.Controls.Add(this.btnBoQua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.viewLoHang);
            this.Controls.Add(this.txtHanSD);
            this.Controls.Add(this.txtNgaySX);
            this.Controls.Add(this.txtMaLo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DanhSachLoHang";
            this.Text = "DanhSachLoHang";
            this.Load += new System.EventHandler(this.DanhSachLoHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewLoHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewThuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaLo;
        private System.Windows.Forms.DateTimePicker txtNgaySX;
        private System.Windows.Forms.DateTimePicker txtHanSD;
        private System.Windows.Forms.DataGridView viewLoHang;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView viewThuoc;
    }
}