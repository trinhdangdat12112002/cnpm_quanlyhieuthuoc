namespace QuanLyHieuThuoc
{
    partial class FormNhanVien
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.quaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchThuốcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchLoạiThuốcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchLôHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bánHàngTạiQuầyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đơnĐặtOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đơnĐợiXácNhậnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đơnĐãXácNhậnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lịchSửGiaoDịchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lbNhanVien = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quaToolStripMenuItem,
            this.bánHàngTạiQuầyToolStripMenuItem,
            this.đơnĐặtOnlineToolStripMenuItem,
            this.lịchSửGiaoDịchToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1091, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // quaToolStripMenuItem
            // 
            this.quaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhSáchThuốcToolStripMenuItem,
            this.danhSáchLoạiThuốcToolStripMenuItem,
            this.danhSáchLôHàngToolStripMenuItem});
            this.quaToolStripMenuItem.Name = "quaToolStripMenuItem";
            this.quaToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.quaToolStripMenuItem.Text = "Quản Lý Các Danh Mục";
            // 
            // danhSáchThuốcToolStripMenuItem
            // 
            this.danhSáchThuốcToolStripMenuItem.Name = "danhSáchThuốcToolStripMenuItem";
            this.danhSáchThuốcToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.danhSáchThuốcToolStripMenuItem.Text = "Danh Sách Thuốc";
            this.danhSáchThuốcToolStripMenuItem.Click += new System.EventHandler(this.danhSáchThuốcToolStripMenuItem_Click);
            // 
            // danhSáchLoạiThuốcToolStripMenuItem
            // 
            this.danhSáchLoạiThuốcToolStripMenuItem.Name = "danhSáchLoạiThuốcToolStripMenuItem";
            this.danhSáchLoạiThuốcToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.danhSáchLoạiThuốcToolStripMenuItem.Text = "Danh Sách Loại Thuốc";
            this.danhSáchLoạiThuốcToolStripMenuItem.Click += new System.EventHandler(this.danhSáchLoạiThuốcToolStripMenuItem_Click);
            // 
            // danhSáchLôHàngToolStripMenuItem
            // 
            this.danhSáchLôHàngToolStripMenuItem.Name = "danhSáchLôHàngToolStripMenuItem";
            this.danhSáchLôHàngToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.danhSáchLôHàngToolStripMenuItem.Text = "Danh Sách Lô Hàng";
            this.danhSáchLôHàngToolStripMenuItem.Click += new System.EventHandler(this.danhSáchLôHàngToolStripMenuItem_Click);
            // 
            // bánHàngTạiQuầyToolStripMenuItem
            // 
            this.bánHàngTạiQuầyToolStripMenuItem.Name = "bánHàngTạiQuầyToolStripMenuItem";
            this.bánHàngTạiQuầyToolStripMenuItem.Size = new System.Drawing.Size(150, 24);
            this.bánHàngTạiQuầyToolStripMenuItem.Text = "Bán Hàng Tại Quầy";
            this.bánHàngTạiQuầyToolStripMenuItem.Click += new System.EventHandler(this.bánHàngTạiQuầyToolStripMenuItem_Click);
            // 
            // đơnĐặtOnlineToolStripMenuItem
            // 
            this.đơnĐặtOnlineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đơnĐợiXácNhậnToolStripMenuItem,
            this.đơnĐãXácNhậnToolStripMenuItem});
            this.đơnĐặtOnlineToolStripMenuItem.Name = "đơnĐặtOnlineToolStripMenuItem";
            this.đơnĐặtOnlineToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.đơnĐặtOnlineToolStripMenuItem.Text = "Đơn Đặt Online";
            // 
            // đơnĐợiXácNhậnToolStripMenuItem
            // 
            this.đơnĐợiXácNhậnToolStripMenuItem.Name = "đơnĐợiXácNhậnToolStripMenuItem";
            this.đơnĐợiXácNhậnToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.đơnĐợiXácNhậnToolStripMenuItem.Text = "Đơn Đợi Xác Nhận";
            this.đơnĐợiXácNhậnToolStripMenuItem.Click += new System.EventHandler(this.đơnĐợiXácNhậnToolStripMenuItem_Click);
            // 
            // đơnĐãXácNhậnToolStripMenuItem
            // 
            this.đơnĐãXácNhậnToolStripMenuItem.Name = "đơnĐãXácNhậnToolStripMenuItem";
            this.đơnĐãXácNhậnToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.đơnĐãXácNhậnToolStripMenuItem.Text = "Đơn Đã Xác Nhận";
            this.đơnĐãXácNhậnToolStripMenuItem.Click += new System.EventHandler(this.đơnĐãXácNhậnToolStripMenuItem_Click);
            // 
            // lịchSửGiaoDịchToolStripMenuItem
            // 
            this.lịchSửGiaoDịchToolStripMenuItem.Name = "lịchSửGiaoDịchToolStripMenuItem";
            this.lịchSửGiaoDịchToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.lịchSửGiaoDịchToolStripMenuItem.Text = "Lịch Sử Giao Dịch";
            this.lịchSửGiaoDịchToolStripMenuItem.Click += new System.EventHandler(this.lịchSửGiaoDịchToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 599);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1091, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(829, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Xin Chào : ";
            // 
            // lbNhanVien
            // 
            this.lbNhanVien.AutoSize = true;
            this.lbNhanVien.Location = new System.Drawing.Point(893, 11);
            this.lbNhanVien.Name = "lbNhanVien";
            this.lbNhanVien.Size = new System.Drawing.Size(0, 16);
            this.lbNhanVien.TabIndex = 5;
            // 
            // FormNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 625);
            this.Controls.Add(this.lbNhanVien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormNhanVien";
            this.Text = "FormNhanVien";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem quaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bánHàngTạiQuầyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đơnĐặtOnlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đơnĐợiXácNhậnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đơnĐãXácNhậnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lịchSửGiaoDịchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchThuốcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchLoạiThuốcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchLôHàngToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNhanVien;
    }
}



