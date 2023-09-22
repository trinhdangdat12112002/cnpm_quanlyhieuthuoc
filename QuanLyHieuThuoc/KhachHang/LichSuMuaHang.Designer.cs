namespace QuanLyHieuThuoc.KhachHang
{
    partial class LichSuMuaHang
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
            this.btnLoc = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.viewLichSu = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.viewChiTietLichSu = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.viewLichSu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewChiTietLichSu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(518, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đến";
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(715, 80);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(75, 23);
            this.btnLoc.TabIndex = 3;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(138, 77);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(210, 22);
            this.txtSearch.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(384, 79);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(128, 22);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(556, 78);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(142, 22);
            this.dateTimePicker2.TabIndex = 6;
            // 
            // viewLichSu
            // 
            this.viewLichSu.AllowUserToAddRows = false;
            this.viewLichSu.AllowUserToDeleteRows = false;
            this.viewLichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewLichSu.Location = new System.Drawing.Point(53, 145);
            this.viewLichSu.Name = "viewLichSu";
            this.viewLichSu.ReadOnly = true;
            this.viewLichSu.RowHeadersWidth = 51;
            this.viewLichSu.RowTemplate.Height = 24;
            this.viewLichSu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.viewLichSu.Size = new System.Drawing.Size(737, 388);
            this.viewLichSu.TabIndex = 7;
            this.viewLichSu.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.viewLichSu_DataBindingComplete);
            this.viewLichSu.SelectionChanged += new System.EventHandler(this.viewLichSu_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1051, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "CHI TIẾT ĐƠN ĐẶT";
            // 
            // viewChiTietLichSu
            // 
            this.viewChiTietLichSu.AllowUserToAddRows = false;
            this.viewChiTietLichSu.AllowUserToDeleteRows = false;
            this.viewChiTietLichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewChiTietLichSu.Location = new System.Drawing.Point(896, 145);
            this.viewChiTietLichSu.Name = "viewChiTietLichSu";
            this.viewChiTietLichSu.ReadOnly = true;
            this.viewChiTietLichSu.RowHeadersWidth = 51;
            this.viewChiTietLichSu.RowTemplate.Height = 24;
            this.viewChiTietLichSu.Size = new System.Drawing.Size(592, 388);
            this.viewChiTietLichSu.TabIndex = 9;
            // 
            // LichSuMuaHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1539, 650);
            this.Controls.Add(this.viewChiTietLichSu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.viewLichSu);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LichSuMuaHang";
            this.Text = "LichSuMuaHang";
            this.Load += new System.EventHandler(this.LichSuMuaHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewLichSu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewChiTietLichSu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridView viewLichSu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView viewChiTietLichSu;
    }
}