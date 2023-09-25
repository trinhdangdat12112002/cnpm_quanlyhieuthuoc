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
        public DanhSachNhaCungCap(User user)
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
                    maNV = reader["sMaNV"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            connection.Close();
        }

        private void DanhSachNhaCungCap_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM tblNhaCungCap", connection);
            cmd1.CommandType = CommandType.Text;
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            connection.Close();

            DataTable tbl_LoaiThuoc = new DataTable();
            adapter1.Fill(tbl_LoaiThuoc);
            viewNCC.DataSource = tbl_LoaiThuoc;

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
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text) ||  string.IsNullOrWhiteSpace(txtTenNCC.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text) || string.IsNullOrWhiteSpace(txtSdt.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int check=0;
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblNhaCungCap where sMaNCC = @maNCC", connection);
            cmd.Parameters.AddWithValue("@maNCC", txtMaNCC.Text);
            check = (int) cmd.ExecuteScalar();
            connection.Close();


            if (check > 0)
            {
                MessageBox.Show("Mã này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("INSERT INTO tblNhaCungCap " +
                    " Values (@maNCC , @tenNCC, @diaChi, @sdt)", connection);
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.AddWithValue("@maNCC", txtMaNCC.Text);
                cmd1.Parameters.AddWithValue("@tenNCC", txtTenNCC.Text);
                cmd1.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);
                cmd1.Parameters.AddWithValue("@sdt", txtSdt.Text);
                cmd1.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Thêm nhà cung cấp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DanhSachNhaCungCap_Load(null, null);
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

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE tblNhaCungCap SET sTenNCC = @tenNCC, sDiaChiNCC = @diaChi, sSdtNCC = @sdt WHERE sMaNCC = @maNCC", connection);
                cmd.Parameters.AddWithValue("@tenNCC", tenNCC);
                cmd.Parameters.AddWithValue("@diaChi", diaChi);
                cmd.Parameters.AddWithValue("@sdt", sdt);
                cmd.Parameters.AddWithValue("@maNCC", maNCC);
                cmd.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Cập nhật thông tin nhà cung cấp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DanhSachNhaCungCap_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblNhaCungCap WHERE sMaNCC = @maNCC", connection);
                    cmd.Parameters.AddWithValue("@maNCC", maNCC);
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Xóa nhà cung cấp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DanhSachNhaCungCap_Load(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                connection.Open();
                string sqlQuery = "SELECT * FROM tblNhaCungCap WHERE sMaNCC LIKE @searchText OR sTenNCC LIKE @searchText OR sDiaChiNCC LIKE @searchText OR sSdtNCC LIKE @searchText";
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%"); 

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tbl_LoaiThuoc = new DataTable();
                adapter.Fill(tbl_LoaiThuoc);

                viewNCC.DataSource = tbl_LoaiThuoc;

                connection.Close();
            }
            else
            {
                DanhSachNhaCungCap_Load(null, null);
            }
        }
    }
}
