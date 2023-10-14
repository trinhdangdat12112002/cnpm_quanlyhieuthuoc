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

namespace QuanLyHieuThuoc.NhanVien
{
    public partial class DanhSachLoaiThuoc : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HieuThuoc"].ConnectionString);

        private string username;
        private User currentUser;
        string maNV;

        BusinessLogicLayer.LoaiSanPhamBLL lsp = new BusinessLogicLayer.LoaiSanPhamBLL();

        public DanhSachLoaiThuoc(User user)
        {
            InitializeComponent();

            currentUser = user;
            username = user.Username;

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblTaiKhoan WHERE sTenTaiKhoanNV = @tenTaiKhoan", connection);
                cmd.Parameters.AddWithValue("@tenTaiKhoan", username);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) // Đọc dòng đầu tiên
                {
                    maNV = reader["sMaNV"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            connection.Close();


        }

        private void DanhSachLoaiThuoc_Load(object sender, EventArgs e)
        {
            // Lay danh sach thuoc
            try
            {
                viewLoaiThuoc.DataSource = lsp.getLoaiSP();

                foreach (DataGridViewColumn col in viewLoaiThuoc.Columns)
                {
                    switch (col.Name)
                    {
                        case "sMaLoaiSP":
                            col.HeaderText = "Mã Loại Thuốc";
                            col.Width = 150;
                            break;
                        case "sTenLoaiSP":
                            col.HeaderText = "Tên Loại Thuốc";
                            col.Width = 150;
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
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text;

            try
            {
                viewLoaiThuoc.DataSource = lsp.searchLoaiSP(search);
            }
            catch (SqlException ex)
            {
                foreach (SqlError er in ex.Errors)
                {
                    MessageBox.Show("Lỗi :" + er.Message);
                }
            }
        }

        private void viewLoaiThuoc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            viewLoaiThuoc.ClearSelection();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;

            txtMaLoaiThuoc.Enabled = true;
        }

        private void viewLoaiThuoc_SelectionChanged(object sender, EventArgs e)
        {
            txtMaLoaiThuoc.Clear();
            txtTenLoaiThuoc.Clear();

            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtMaLoaiThuoc.Enabled = false;
            if (viewLoaiThuoc.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = viewLoaiThuoc.SelectedRows[0];
                string maloai = selectedRow.Cells["sMaLoaiSP"].Value.ToString();

                txtMaLoaiThuoc.Text = maloai;
                txtTenLoaiThuoc.Text = selectedRow.Cells["sTenLoaiSP"].Value.ToString();

                
                try
                {
                    viewThuoc.DataSource = lsp.getSanPhamByLoai(maloai);

                    foreach (DataGridViewColumn col in viewThuoc.Columns)
                    {
                        switch (col.Name)
                        {
                            case "sMaSP":
                                col.HeaderText = "Mã Thuốc";
                                col.Width = 50;
                                break;
                            case "sTenSP":
                                col.HeaderText = "Tên Thuốc";
                                col.Width = 100;
                                break;
                            case "fGiaBan":
                                col.HeaderText = "Giá bán";
                                break;
                            case "sHangSX":
                                col.HeaderText = "Hãng sản xuất";
                                break;
                            case "sNuocSX":
                                col.HeaderText = "Nước sản xuất";
                                break;
                            case "sThongTinSP":
                                col.HeaderText = "Thông tin sản phẩm";
                                break;
                            case "sCachDung":
                                col.HeaderText = "Cách dùng";
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
                viewThuoc.ClearSelection();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLoaiThuoc.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại thuốc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenLoaiThuoc.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại thuốc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (lsp.insertLoaiSP(txtMaLoaiThuoc.Text, txtTenLoaiThuoc.Text) > 0)
                {
                    MessageBox.Show("Thêm loại thuốc thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenLoaiThuoc.Clear();
                    txtMaLoaiThuoc.Clear();
                    DanhSachLoaiThuoc_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Không thể thêm loại thuốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (viewLoaiThuoc.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = viewLoaiThuoc.SelectedRows[0];
                string maLoaiThuoc = selectedRow.Cells["sMaLoaiSP"].Value.ToString();
                string tenLoaiThuoc = txtTenLoaiThuoc.Text.Trim();

                try
                {
                    if (lsp.updateLoaiSP(maLoaiThuoc,tenLoaiThuoc) > 0)
                    {
                        MessageBox.Show("Sửa loại thuốc thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DanhSachLoaiThuoc_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Không thể sửa loại thuốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                MessageBox.Show("Vui lòng chọn loại thuốc cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            DanhSachLoaiThuoc_Load(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (viewLoaiThuoc.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = viewLoaiThuoc.SelectedRows[0];
                string maLoaiThuoc = selectedRow.Cells["sMaLoaiSP"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa loại thuốc này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (lsp.deleteLoaiSP(maLoaiThuoc) > 0)
                        {
                            MessageBox.Show("Xóa loại thuốc thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DanhSachLoaiThuoc_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa loại thuốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                MessageBox.Show("Vui lòng chọn loại thuốc cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
