﻿namespace QuanLyHieuThuoc.NhanVien
{
    partial class LichSuBanHang
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
            this.viewChiTietLichSu = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.viewLichSu = new System.Windows.Forms.DataGridView();
            this.txtDen = new System.Windows.Forms.DateTimePicker();
            this.txtTu = new System.Windows.Forms.DateTimePicker();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.viewChiTietLichSu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewLichSu)).BeginInit();
            this.SuspendLayout();
            // 
            // viewChiTietLichSu
            // 
            this.viewChiTietLichSu.AllowUserToAddRows = false;
            this.viewChiTietLichSu.AllowUserToDeleteRows = false;
            this.viewChiTietLichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewChiTietLichSu.Location = new System.Drawing.Point(864, 131);
            this.viewChiTietLichSu.Name = "viewChiTietLichSu";
            this.viewChiTietLichSu.ReadOnly = true;
            this.viewChiTietLichSu.RowHeadersWidth = 51;
            this.viewChiTietLichSu.RowTemplate.Height = 24;
            this.viewChiTietLichSu.Size = new System.Drawing.Size(592, 388);
            this.viewChiTietLichSu.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1019, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "CHI TIẾT ĐƠN ĐẶT";
            // 
            // viewLichSu
            // 
            this.viewLichSu.AllowUserToAddRows = false;
            this.viewLichSu.AllowUserToDeleteRows = false;
            this.viewLichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewLichSu.Location = new System.Drawing.Point(21, 131);
            this.viewLichSu.Name = "viewLichSu";
            this.viewLichSu.ReadOnly = true;
            this.viewLichSu.RowHeadersWidth = 51;
            this.viewLichSu.RowTemplate.Height = 24;
            this.viewLichSu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.viewLichSu.Size = new System.Drawing.Size(737, 388);
            this.viewLichSu.TabIndex = 17;
            this.viewLichSu.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.viewLichSu_DataBindingComplete);
            this.viewLichSu.SelectionChanged += new System.EventHandler(this.viewLichSu_SelectionChanged);
            // 
            // txtDen
            // 
            this.txtDen.Location = new System.Drawing.Point(505, 63);
            this.txtDen.Name = "txtDen";
            this.txtDen.Size = new System.Drawing.Size(142, 22);
            this.txtDen.TabIndex = 16;
            // 
            // txtTu
            // 
            this.txtTu.Location = new System.Drawing.Point(333, 64);
            this.txtTu.Name = "txtTu";
            this.txtTu.Size = new System.Drawing.Size(128, 22);
            this.txtTu.TabIndex = 15;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(106, 63);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(177, 22);
            this.txtSearch.TabIndex = 14;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(664, 63);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(94, 25);
            this.btnLoc.TabIndex = 13;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Đến";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Từ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tìm kiếm";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(423, 579);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LichSuBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 894);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.viewChiTietLichSu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.viewLichSu);
            this.Controls.Add(this.txtDen);
            this.Controls.Add(this.txtTu);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LichSuBanHang";
            this.Text = "Lịch Sử Bán Hàng";
            this.Load += new System.EventHandler(this.LichSuBanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewChiTietLichSu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewLichSu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView viewChiTietLichSu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView viewLichSu;
        private System.Windows.Forms.DateTimePicker txtDen;
        private System.Windows.Forms.DateTimePicker txtTu;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}