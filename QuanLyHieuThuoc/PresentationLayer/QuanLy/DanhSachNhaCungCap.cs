using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuanLyHieuThuoc.DangNhap;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyHieuThuoc.QuanLy
{
    public partial class DanhSachNhaCungCap : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HieuThuoc"].ConnectionString);

        private string username;
        private User currentUser;
        string maNV;

        BusinessLogicLayer.NhaCungCapBLL ncc = new BusinessLogicLayer.NhaCungCapBLL();
        public DanhSachNhaCungCap(User user)
        {
            InitializeComponent();

            currentUser = user;
            username = user.Username;

            try
            {
                BusinessLogicLayer.TaiKhoanBLL manv = new BusinessLogicLayer.TaiKhoanBLL();
                maNV = manv.getMaNV(username);
            }
            catch (SqlException ex)
            {
                foreach (SqlError er in ex.Errors)
                {
                    MessageBox.Show("Lỗi :" + er.Message);
                }
            }
            // Tắt khả năng phóng to form (full screen)
            this.MaximizeBox = false;

            // Tắt khả năng thay đổi kích thước form bằng cách kéo góc hoặc cạnh
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void DanhSachNhaCungCap_Load(object sender, EventArgs e)
        {
            try
            {
                viewNCC.DataSource = ncc.getNhaCungCap();

                foreach (DataGridViewColumn col in viewNCC.Columns)
                {
                    switch (col.Name)
                    {
                        case "sMaNCC":
                            col.HeaderText = "Mã Nhà Cung Cấp";
                            col.Width = 100;
                            break;
                        case "sTenNCC":
                            col.HeaderText = "Tên Nhà Cung Cấp";
                            col.Width = 100;
                            break;
                        case "sDiaChiNCC":
                            col.HeaderText = "Địa Chỉ";
                            col.Width = 100;
                            break;
                        case "sSdtNCC":
                            col.HeaderText = "Số điện thoại";
                            break;
                        default:
                            col.HeaderText = col.Name;
                            break;
                    }
                }
            }
            catch (SqlException ex)
            {
                foreach (SqlError er in ex.Errors)
                {
                    MessageBox.Show("Lỗi :" + er.Message);
                }
            }
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        private void viewNCC_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            viewNCC.ClearSelection();
            
        }

        private void viewNCC_SelectionChanged(object sender, EventArgs e)
        {
            btnThem.Enabled=true;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtDiaChi.Clear();
            txtMaNCC.Clear();
            txtSdt.Clear    ();
            txtTenNCC.Clear();

            txtMaNCC.Enabled = true;
            if (viewNCC.SelectedRows.Count > 0)
            {
                txtMaNCC.Enabled = false;
                DataGridViewRow selectedRow = viewNCC.SelectedRows[0];
                txtMaNCC.Text = selectedRow.Cells["sMaNCC"].Value.ToString();
                txtTenNCC.Text = selectedRow.Cells["sTenNCC"].Value.ToString();
                txtSdt.Text = selectedRow.Cells["sSdtNCC"].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells["sDiaChiNCC"].Value.ToString();

                btnThem.Enabled = false;
                btnSua.Enabled=true;
                btnXoa.Enabled = true;
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            DanhSachNhaCungCap_Load(null, null);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNCC = txtMaNCC.Text;
            string tenNCC = txtTenNCC.Text;
            string diaChi = txtDiaChi.Text;
            string sdt = txtSdt.Text;
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text) || string.IsNullOrWhiteSpace(txtTenNCC.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text) || string.IsNullOrWhiteSpace(txtSdt.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ncc.checkNCC(maNCC) > 0)
            {
                MessageBox.Show("Mã này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            try
            {
                ncc.insertNCC(maNCC, tenNCC, diaChi, sdt);
                MessageBox.Show("Thêm nhà cung cấp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DanhSachNhaCungCap_Load(null, null);
            }
            catch (SqlException ex)
            {
                foreach (SqlError er in ex.Errors)
                {
                    MessageBox.Show("Lỗi :" + er.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (viewNCC.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhà cung cấp để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNCC = txtMaNCC.Text;
            string tenNCC = txtTenNCC.Text;
            string diaChi = txtDiaChi.Text;
            string sdt = txtSdt.Text;

            if (string.IsNullOrWhiteSpace(txtTenNCC.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text) || string.IsNullOrWhiteSpace(txtSdt.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ncc.updateNCC(maNCC, tenNCC, diaChi, sdt);
                MessageBox.Show("Cập nhật thông tin nhà cung cấp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DanhSachNhaCungCap_Load(null, null);
            }
            catch (SqlException ex)
            {
                foreach (SqlError er in ex.Errors)
                {
                    MessageBox.Show("Lỗi :" + er.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (viewNCC.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhà cung cấp để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string maNCC = txtMaNCC.Text;

                try
                {
                    ncc.deleteNCC(maNCC);

                    MessageBox.Show("Xóa nhà cung cấp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DanhSachNhaCungCap_Load(null, null);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError er in ex.Errors)
                    {
                        MessageBox.Show("Lỗi :" + er.Message);
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            try
            {
                if (!string.IsNullOrEmpty(searchText))
                {
                    viewNCC.DataSource = ncc.searchNCC(searchText);
                }
                else
                {
                    DanhSachNhaCungCap_Load(null, null);
                }
            }
            catch (SqlException ex)
            {
                foreach (SqlError er in ex.Errors)
                {
                    MessageBox.Show("Lỗi :" + er.Message);
                }
            }
        }
    }
}
