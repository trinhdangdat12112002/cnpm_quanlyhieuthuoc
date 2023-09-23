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

namespace QuanLyHieuThuoc.NhanVien
{
    public partial class DanhSachLoaiThuoc : Form
    {
        SqlConnection connection = new SqlConnection("data source=DESKTOP-KHO76ED;Initial Catalog=HieuThuoc;Integrated Security=True");

        private string username;
        private User currentUser;
        string maNV;

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
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT sMaLoaiSP , sTenLoaiSP from tblLoaiSanPham", connection);
            cmd1.CommandType = CommandType.Text;
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            connection.Close();
            DataTable tbl_LoaiThuoc = new DataTable();
            adapter1.Fill(tbl_LoaiThuoc);
            viewLoaiThuoc.DataSource = tbl_LoaiThuoc;

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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * from tblLoaiSanPham " +
                "where sMaLoaiSP like '%' + @kyTu + '%' or sTenLoaiSP like '%' + @kyTu + '%'", connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@kyTu", txtSearch.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            connection.Close();

            DataTable table = new DataTable();
            adapter.Fill(table);

            viewLoaiThuoc.DataSource = table;
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

                connection.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT sMaSP,sTenSP, fGiaBan, sHangSX, sNuocSX, sThongTinSP, sCachDung " +
                    " from tblSanPham " +
                    " where sMaLoaiSP = @maLoaiSP", connection);
                cmd1.CommandType = CommandType.Text;

                cmd1.Parameters.AddWithValue("@maLoaiSP", maloai);

                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                connection.Close();

                DataTable tbl_Thuoc = new DataTable();
                adapter1.Fill(tbl_Thuoc);
                viewThuoc.DataSource = tbl_Thuoc;

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
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tblLoaiSanPham (sMaLoaiSP , sTenLoaiSP) VALUES (@maloaiSP, @tenLoaiThuoc)", connection);
                cmd.Parameters.AddWithValue("@tenLoaiThuoc", txtTenLoaiThuoc.Text);
                cmd.Parameters.AddWithValue("@maloaiSP", txtMaLoaiThuoc.Text);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thêm loại thuốc thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenLoaiThuoc.Clear();
                    txtMaLoaiThuoc.Clear();
                }
                else
                {
                    MessageBox.Show("Không thể thêm loại thuốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
            DanhSachLoaiThuoc_Load(null, null);

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
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE tblLoaiSanPham " +
                        "SET sTenLoaiSP = @tenLoaiThuoc " +
                        "WHERE sMaLoaiSP = @maLoaiThuoc", connection);
                    cmd.Parameters.AddWithValue("@tenLoaiThuoc", tenLoaiThuoc);
                    cmd.Parameters.AddWithValue("@maLoaiThuoc", maLoaiThuoc);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa loại thuốc thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể sửa loại thuốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
                DanhSachLoaiThuoc_Load(null, null);

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
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM tblLoaiSanPham WHERE sMaLoaiSP = @maLoaiThuoc", connection);
                        cmd.Parameters.AddWithValue("@maLoaiThuoc", maLoaiThuoc);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa loại thuốc thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa loại thuốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                    DanhSachLoaiThuoc_Load(null, null);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại thuốc cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
