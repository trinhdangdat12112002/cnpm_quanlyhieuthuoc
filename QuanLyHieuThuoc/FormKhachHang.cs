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
    public partial class FormKhachHang : Form
    {
        private int childFormNumber = 0;

        private User currentUser;

        public FormKhachHang(User user)
        {
            InitializeComponent();
            currentUser = user;
            lbKhachHang.Text = user.Username;
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

        private void traCứuThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openedForm in openedForms)
            {
                if (openedForm is KhachHang.TraCuuThuoc)
                {
                    openedForm.BringToFront(); 
                    MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; 
                }
            }

            KhachHang.TraCuuThuoc tracuuForm = new KhachHang.TraCuuThuoc(currentUser);
            tracuuForm.MdiParent = this; 
            tracuuForm.FormClosed += (s, args) => openedForms.Remove(tracuuForm); 
            openedForms.Add(tracuuForm); 
            tracuuForm.Show();
        }

        private void đặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openedForm in openedForms)
            {
                if (openedForm is KhachHang.DatHang)
                {
                    openedForm.BringToFront();
                    MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            KhachHang.DatHang tracuuForm = new KhachHang.DatHang(currentUser);
            tracuuForm.MdiParent = this;
            tracuuForm.FormClosed += (s, args) => openedForms.Remove(tracuuForm);
            openedForms.Add(tracuuForm);
            tracuuForm.Show();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openedForm in openedForms)
            {
                if (openedForm is KhachHang.ThongTinKhachHang )
                {
                    openedForm.BringToFront();
                    MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            KhachHang.ThongTinKhachHang tracuuForm = new KhachHang.ThongTinKhachHang(currentUser);
            tracuuForm.MdiParent = this;
            tracuuForm.FormClosed += (s, args) => openedForms.Remove(tracuuForm);
            openedForms.Add(tracuuForm);
            tracuuForm.Show();
        }

        private void mụcYêuThíchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openedForm in openedForms)
            {
                if (openedForm is KhachHang.UuThich)
                {
                    openedForm.BringToFront();
                    MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            KhachHang.UuThich tracuuForm = new KhachHang.UuThich(currentUser);
            tracuuForm.MdiParent = this;
            tracuuForm.FormClosed += (s, args) => openedForms.Remove(tracuuForm);
            openedForms.Add(tracuuForm);
            tracuuForm.Show();
        }

        private void lịchSửToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openedForm in openedForms)
            {
                if (openedForm is KhachHang.LichSuMuaHang)
                {
                    openedForm.BringToFront();
                    MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            KhachHang.LichSuMuaHang tracuuForm = new KhachHang.LichSuMuaHang(currentUser);
            tracuuForm.MdiParent = this;
            tracuuForm.FormClosed += (s, args) => openedForms.Remove(tracuuForm);
            openedForms.Add(tracuuForm);
            tracuuForm.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openedForm in openedForms)
            {
                if (openedForm is KhachHang.DoiMatKhauKachHang)
                {
                    openedForm.BringToFront();
                    MessageBox.Show("Form này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            KhachHang.DoiMatKhauKachHang tracuuForm = new KhachHang.DoiMatKhauKachHang(currentUser);
            tracuuForm.MdiParent = this;
            tracuuForm.FormClosed += (s, args) => openedForms.Remove(tracuuForm);
            openedForms.Add(tracuuForm);
            tracuuForm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form dangnhap = new DangNhap();
            dangnhap.Show();
        }
    }
}
