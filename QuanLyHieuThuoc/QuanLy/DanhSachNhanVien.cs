using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuanLyHieuThuoc.DangNhap;

namespace QuanLyHieuThuoc.QuanLy
{
    public partial class DanhSachNhanVien : Form
    {
        SqlConnection connection = new SqlConnection("data source=DESKTOP-KHO76ED;Initial Catalog=HieuThuoc;Integrated Security=True");

        private string username;
        private User currentUser;
        string maUserNV;
        public DanhSachNhanVien(User user)
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

                if (reader.Read())
                {
                    maUserNV = reader["sMaNV"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            connection.Close();

            txtNgaySinh.Format = DateTimePickerFormat.Custom;
            txtNgaySinh.CustomFormat = "dd/MM/yyyy";

            txtNgayVaoLam.Format = DateTimePickerFormat.Custom;
            txtNgayVaoLam.CustomFormat = "dd/MM/yyyy";
        }

        private void DanhSachNhanVien_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM tblNhanVien", connection);
            cmd1.CommandType = CommandType.Text;
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            connection.Close();

            DataTable tbl_NhanVien = new DataTable();
            adapter1.Fill(tbl_NhanVien);
            viewNhanVien.DataSource = tbl_NhanVien;

            foreach (DataGridViewColumn col in viewNhanVien.Columns)
            {
                switch (col.Name)
                {
                    case "sMaNV":
                        col.HeaderText = "Mã Nhân Viên";
                        col.Width = 100;
                        break;
                    case "sTenNV":
                        col.HeaderText = "Tên Nhân Viên";
                        col.Width = 100;
                        break;
                    case "dNgaySinh":
                        col.HeaderText = "Ngày Sinh";
                        col.Width = 100;
                        break;
                    case "bGioiTinhNV":
                        col.HeaderText = "Giới Tính";
                        break;
                    case "sSdtNv":
                        col.HeaderText = "Số Điện Thoại";
                        break;
                    case "sDiaChiNV":
                        col.HeaderText = "Địa Chỉ";
                        break;
                    case "dNgayVaoLam":
                        col.HeaderText = "Ngày Vào Làm";
                        break;
                    default:
                        col.HeaderText = col.Name;
                        break;
                }
            }
            txtMaNV.Enabled = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM tblNhanVien WHERE sMaNV LIKE @searchText OR sTenNV LIKE @searchText OR sDiaChiNV LIKE @searchText OR sSdtNV LIKE @searchText";
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tbl_NhanVien = new DataTable();
                adapter.Fill(tbl_NhanVien);

                viewNhanVien.DataSource = tbl_NhanVien;

                connection.Close();
            }
            else
            {
                DanhSachNhanVien_Load(null, null);
            }
        }

        private void viewNhanVien_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            viewNhanVien.ClearSelection();
            txtMaNV.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void viewNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSdt.Clear();
            txtDiaChi.Clear();
            txtMaNV.Enabled = false;

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            if (viewNhanVien.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = viewNhanVien.SelectedRows[0];

                txtMaNV.Text = selectedRow.Cells["sMaNV"].Value.ToString();
                txtTenNV.Text = selectedRow.Cells["sTenNV"].Value.ToString();
                txtNgaySinh.Value = Convert.ToDateTime(selectedRow.Cells["dNgaySinh"].Value);

                if (selectedRow.Cells["bGioiTinhNV"].Value != null)
                {
                    bool gioiTinh = Convert.ToBoolean(selectedRow.Cells["bGioiTinhNV"].Value);
                    if (gioiTinh)
                    {
                        rbNam.Checked = true;
                    }
                    else
                    {
                        rbNu.Checked = true;
                    }
                }

                txtSdt.Text = selectedRow.Cells["sSdtNv"].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells["sDiaChiNV"].Value.ToString();
                txtNgayVaoLam.Value = Convert.ToDateTime(selectedRow.Cells["dNgayVaoLam"].Value);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            DanhSachNhanVien_Load(null, null);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string tenNV = txtTenNV.Text;
            DateTime ngaySinh = txtNgaySinh.Value;
            bool gioiTinh = rbNam.Checked; 
            string sdt = txtSdt.Text;
            string diaChi = txtDiaChi.Text;
            DateTime ngayVaoLam = txtNgayVaoLam.Value;

            try
            {
                connection.Open();

                string sqlQuery = "UPDATE tblNhanVien SET sTenNV = @tenNV, dNgaySinh = @ngaySinh, " +
                                  "bGioiTinhNV = @gioiTinh, sSdtNV = @sdt, sDiaChiNV = @diaChi, dNgayVaoLam = @ngayVaoLam " +
                                  "WHERE sMaNV = @maNV";

                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@tenNV", tenNV);
                cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                cmd.Parameters.AddWithValue("@sdt", sdt);
                cmd.Parameters.AddWithValue("@diaChi", diaChi);
                cmd.Parameters.AddWithValue("@ngayVaoLam", ngayVaoLam);
                cmd.Parameters.AddWithValue("@maNV", maNV);

                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Sửa thông tin nhân viên thành công!");
                    DanhSachNhanVien_Load(null, null); 
                }
                else
                {
                    MessageBox.Show("Sửa thông tin nhân viên không thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
           

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string tenNV = txtTenNV.Text;
            DateTime ngaySinh = txtNgaySinh.Value;
            bool gioiTinh = rbNam.Checked;
            string sdt = txtSdt.Text;
            string diaChi = txtDiaChi.Text;
            DateTime ngayVaoLam = txtNgayVaoLam.Value;

            txtMaNV.Enabled = false;

            try
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM tblNhanVien WHERE sMaNV = @maNV";
                SqlCommand cmd1 = new SqlCommand(checkQuery, connection);
                cmd1.Parameters.AddWithValue("@maNV", maNV);

                int count = (int)cmd1.ExecuteScalar();
                connection.Close();
                if (count > 0)
                {
                    MessageBox.Show("Mã nhân viên này đã tồn tại!");
                }
                else
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO tblNhanVien (sMaNV, sTenNV, dNgaySinh, bGioiTinhNV, sSdtNV, sDiaChiNV, dNgayVaoLam) " +
                                      "VALUES (@maNV, @tenNV, @ngaySinh, @gioiTinh, @sdt, @diaChi, @ngayVaoLam)";

                    SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("@maNV", maNV);
                    cmd.Parameters.AddWithValue("@tenNV", tenNV);
                    cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@sdt", sdt);
                    cmd.Parameters.AddWithValue("@diaChi", diaChi);
                    cmd.Parameters.AddWithValue("@ngayVaoLam", ngayVaoLam);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm nhân viên thành công!");
                        DanhSachNhanVien_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân viên không thành công!");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    connection.Open();
                    string sqlQuery = "DELETE FROM tblNhanVien WHERE sMaNV = @maNV";

                    SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("@maNV", maNV);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa nhân viên thành công!");
                        DanhSachNhanVien_Load(null, null); 
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên không thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string tenNV = txtTenNV.Text.Trim();
            string sdt = txtSdt.Text.Trim();

            try
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM tblNhanVien WHERE 1 = 1";

                if (!string.IsNullOrEmpty(maNV))
                {
                    sqlQuery += " AND sMaNV LIKE @maNV";
                }
                if (!string.IsNullOrEmpty(tenNV))
                {
                    sqlQuery += " AND sTenNV LIKE @tenNV";
                }
                if (!string.IsNullOrEmpty(sdt))
                {
                    sqlQuery += " AND sSdtNV LIKE @sdt";
                }
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);

                if (!string.IsNullOrEmpty(maNV))
                {
                    cmd.Parameters.AddWithValue("@maNV", "%" + maNV + "%");
                }

                if (!string.IsNullOrEmpty(tenNV))
                {
                    cmd.Parameters.AddWithValue("@tenNV", "%" + tenNV + "%");
                }

                if (!string.IsNullOrEmpty(sdt))
                {
                    cmd.Parameters.AddWithValue("@sdt", "%" + sdt + "%");
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tbl_NhanVien = new DataTable();
                adapter.Fill(tbl_NhanVien);

                viewNhanVien.DataSource = tbl_NhanVien;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
