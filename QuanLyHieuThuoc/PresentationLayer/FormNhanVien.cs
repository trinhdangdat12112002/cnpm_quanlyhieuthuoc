using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuanLyHieuThuoc.DangNhap;

namespace QuanLyHieuThuoc
{
    public partial class FormNhanVien : Form
    {
        private int childFormNumber = 0;

        private User currentUser;
        string quyen;
        public FormNhanVien(User user)
        {
            InitializeComponent();
            currentUser = user;
            lbNhanVien.Text = user.Name;
            quyen = user.Role;

            if ( quyen == "Nhân viên")
            {
                danhSáchNhàCungCấpToolStripMenuItem.Visible = false;
                danhSaToolStripMenuItem.Visible=false;
                danhSáchTàiKhoảnToolStripMenuItem.Visible =     false;
            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        public List<Form> openedForms = new List<Form>();

        private void danhSáchThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openedForm in openedForms)
            {
                if (openedForm is NhanVien.DanhSachThuoc)
                {
                    openedForm.BringToFront();
                    MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            NhanVien.DanhSachThuoc form = new NhanVien.DanhSachThuoc(currentUser);
            form.MdiParent = this;
            form.FormClosed += (s, args) => openedForms.Remove(form);
            openedForms.Add(form);
            form.Show();
        }

        private void danhSáchLoạiThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openedForm in openedForms)
            {
                if (openedForm is NhanVien.DanhSachLoaiThuoc)
                {
                    openedForm.BringToFront();
                    MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            NhanVien.DanhSachLoaiThuoc form = new NhanVien.DanhSachLoaiThuoc(currentUser);
            form.MdiParent = this;
            form.FormClosed += (s, args) => openedForms.Remove(form);
            openedForms.Add(form);
            form.Show();
        }

        private void danhSáchLôHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openedForm in openedForms)
            {
                if (openedForm is NhanVien.DanhSachLoHang)
                {
                    openedForm.BringToFront();
                    MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            NhanVien.DanhSachLoHang form = new NhanVien.DanhSachLoHang(currentUser);
            form.MdiParent = this;
            form.FormClosed += (s, args) => openedForms.Remove(form);
            openedForms.Add(form);
            form.Show();
        }

        private void bánHàngTạiQuầyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            NhanVien.BanHang form = new NhanVien.BanHang(currentUser);
            form.MdiParent = this;
            form.Show();
        }


        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form dangnhap = new DangNhap();
            dangnhap.Show();
        }

        private void đơnĐặtOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openedForm in openedForms)
            {
                if (openedForm is NhanVien.NhapHang)
                {
                    openedForm.BringToFront();
                    MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            NhanVien.NhapHang form = new NhanVien.NhapHang(currentUser);
            form.MdiParent = this;
            form.FormClosed += (s, args) => openedForms.Remove(form);
            openedForms.Add(form);
            form.Show();
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (quyen == "Nhân viên")
            {
                foreach (Form openedForm in openedForms)
                {
                    if (openedForm is NhanVien.LichSuBanHang)
                    {
                        openedForm.BringToFront();
                        MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                NhanVien.LichSuBanHang form = new NhanVien.LichSuBanHang(currentUser);
                form.MdiParent = this;
                form.FormClosed += (s, args) => openedForms.Remove(form);
                openedForms.Add(form);
                form.Show();
            }
            else
            {
                foreach (Form openedForm in openedForms)
                {
                    if (openedForm is QuanLy.DanhSachLichSu)
                    {
                        openedForm.BringToFront();
                        MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                QuanLy.DanhSachLichSu form = new QuanLy.DanhSachLichSu(currentUser);
                form.MdiParent = this;
                form.FormClosed += (s, args) => openedForms.Remove(form);
                openedForms.Add(form);
                form.Show();
            }
        }

        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (quyen == "Nhân viên")
            {
                foreach (Form openedForm in openedForms)
                {
                    if (openedForm is NhanVien.LichSuNhapHang)
                    {
                        openedForm.BringToFront();
                        MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                NhanVien.LichSuNhapHang form = new NhanVien.LichSuNhapHang(currentUser);
                form.MdiParent = this;
                form.FormClosed += (s, args) => openedForms.Remove(form);
                openedForms.Add(form);
                form.Show();
            }
            else
            {
                foreach (Form openedForm in openedForms)
                {
                    if (openedForm is QuanLy.DanhSachNhap)
                    {
                        openedForm.BringToFront();
                        MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                QuanLy.DanhSachNhap form = new QuanLy.DanhSachNhap(currentUser);
                form.MdiParent = this;
                form.FormClosed += (s, args) => openedForms.Remove(form);
                openedForms.Add(form);
                form.Show();
            }
        }

        private void danhSáchNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openedForm in openedForms)
            {
                if (openedForm is QuanLy.DanhSachNhaCungCap)
                {
                    openedForm.BringToFront();
                    MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            QuanLy.DanhSachNhaCungCap form = new QuanLy.DanhSachNhaCungCap(currentUser);
            form.MdiParent = this;
            form.FormClosed += (s, args) => openedForms.Remove(form);
            openedForms.Add(form);
            form.Show();
        }

        private void danhSaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openedForm in openedForms)
            {
                if (openedForm is QuanLy.DanhSachNhanVien)
                {
                    openedForm.BringToFront();
                    MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            QuanLy.DanhSachNhanVien form = new QuanLy.DanhSachNhanVien(currentUser);
            form.MdiParent = this;
            form.FormClosed += (s, args) => openedForms.Remove(form);
            openedForms.Add(form);
            form.Show();
        }

        private void danhSáchTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openedForm in openedForms)
            {
                if (openedForm is QuanLy.DanhSachTaiKhoan)
                {
                    openedForm.BringToFront();
                    MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            QuanLy.DanhSachTaiKhoan form = new QuanLy.DanhSachTaiKhoan(currentUser);
            form.MdiParent = this;
            form.FormClosed += (s, args) => openedForms.Remove(form);
            openedForms.Add(form);
            form.Show();
        }
    }
}
