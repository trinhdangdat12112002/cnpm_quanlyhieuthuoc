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
        public FormNhanVien(User user)
        {
            InitializeComponent();
            currentUser = user;
            lbNhanVien.Text = user.Username;
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
        private List<Form> openedForms = new List<Form>();

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

        private void đơnĐợiXácNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openedForm in openedForms)
            {
                if (openedForm is NhanVien.DatHangDoiXacNhan)
                {
                    openedForm.BringToFront();
                    MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            NhanVien.DatHangDoiXacNhan form = new NhanVien.DatHangDoiXacNhan();
            form.MdiParent = this;
            form.FormClosed += (s, args) => openedForms.Remove(form);
            openedForms.Add(form);
            form.Show();
        }

        private void đơnĐãXácNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openedForm in openedForms)
            {
                if (openedForm is NhanVien.DatHangDaXacNhan)
                {
                    openedForm.BringToFront();
                    MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            NhanVien.DatHangDaXacNhan form = new NhanVien.DatHangDaXacNhan();
            form.MdiParent = this;
            form.FormClosed += (s, args) => openedForms.Remove(form);
            openedForms.Add(form);
            form.Show();
        }

        private void lịchSửGiaoDịchToolStripMenuItem_Click(object sender, EventArgs e)
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

            NhanVien.LichSuBanHang form = new NhanVien.LichSuBanHang();
            form.MdiParent = this;
            form.FormClosed += (s, args) => openedForms.Remove(form);
            openedForms.Add(form);
            form.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form dangnhap = new DangNhap();
            dangnhap.Show();
        }
    }
}
