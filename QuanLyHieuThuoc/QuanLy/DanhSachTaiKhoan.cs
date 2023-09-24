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
    public partial class DanhSachTaiKhoan : Form
    {
        SqlConnection connection = new SqlConnection("data source=DESKTOP-KHO76ED;Initial Catalog=HieuThuoc;Integrated Security=True");

        private string username;
        private User currentUser;
        string maNV;
        public DanhSachTaiKhoan(User user)
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

            List<KeyValuePair<string, string>> maTenNhanVienList = new List<KeyValuePair<string, string>>();

            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT sMaNV, sTenNV FROM tblNhanVien", connection);
                SqlDataReader reader = cmd1.ExecuteReader();

                while (reader.Read())
                {
                    string maNV = reader["sMaNV"].ToString();
                    string tenNV = reader["sTenNV"].ToString();
                    maTenNhanVienList.Add(new KeyValuePair<string, string>(maNV, tenNV));
                }

                cbbTenNV.DataSource = maTenNhanVienList;
                cbbTenNV.DisplayMember = "Value"; 
                cbbTenNV.ValueMember = "Key"; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            connection.Close();

            List<KeyValuePair<string, string>> quyenHan = new List<KeyValuePair<string, string>>();

            quyenHan.Add(new KeyValuePair<string, string>("1", "Nhân viên"));
            quyenHan.Add(new KeyValuePair<string, string>("2", "Quản lý"));
            cbbQuyen.DataSource = quyenHan;
            cbbQuyen.DisplayMember = "Value";
            cbbQuyen.ValueMember = "Key";
        }

        private void DanhSachTaiKhoan_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT sTenNV , sTenTaiKhoanNV, sMatKhauNV , sQuyen " +
                " FROM tblTaiKhoan inner join tblNhanVien on tblTaiKhoan.sMaNV = tblNhanVien.sMaNV", connection);
            cmd1.CommandType = CommandType.Text;
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            connection.Close();

            DataTable tbl_LoaiThuoc = new DataTable();
            adapter1.Fill(tbl_LoaiThuoc);
            viewTaiKhoan.DataSource = tbl_LoaiThuoc;

            foreach (DataGridViewColumn col in viewTaiKhoan.Columns)
            {
                switch (col.Name)
                {
                    case "sTenNV":
                        col.HeaderText = "Tên Nhân Viên";
                        col.Width = 100;
                        break;
                    case "sTenTaiKhoanNV":
                        col.HeaderText = "Tên Tài Khoản";
                        col.Width = 100;
                        break;
                    case "sMatKhauNV":
                        col.HeaderText = "Mật Khẩu";
                        col.Width = 100;
                        break;
                    case "sQuyen":
                        col.HeaderText = "Quyền";
                        break;
                    default:
                        col.HeaderText = col.Name;
                        break;
                }
            }

        }

        private void viewTaiKhoan_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            viewTaiKhoan.ClearSelection();
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

        }

        private void viewTaiKhoan_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            if (viewTaiKhoan.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = viewTaiKhoan.SelectedRows[0];

                string selectedLoaiThuoc = selectedRow.Cells["sTenNV"].Value.ToString();
                foreach (KeyValuePair<string, string> item in cbbTenNV.Items)
                {
                    if (item.Value == selectedLoaiThuoc)
                    {
                        cbbTenNV.SelectedItem = item;
                        break;
                    }
                }

                txtTenTaiKhoan.Text = selectedRow.Cells["sTenTaiKhoanNV"].Value.ToString();
                txtMatKhau.Text = selectedRow.Cells["sMatKhauNV"].Value.ToString();

                string selectQuyen = selectedRow.Cells["sQuyen"].Value.ToString();
                foreach (KeyValuePair<string, string> item in cbbQuyen.Items)
                {
                    if (item.Value == selectQuyen)
                    {
                        cbbQuyen.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenTaiKhoan = txtTenTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            string quyen = cbbQuyen.Text;
            string maNV = cbbTenNV.SelectedValue.ToString();

            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM tblTaiKhoan WHERE sMaNV = @maNV", connection);
                cmd1.Parameters.AddWithValue("@maNV", maNV);

                int count = (int)cmd1.ExecuteScalar();
                connection.Close();

                if (count > 0)
                {
                    MessageBox.Show("Nhân Viên đã này đã có tài khoản");
                }
                else
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO tblTaiKhoan (sTenTaiKhoanNV, sMatKhauNV, sQuyen, sMaNV) VALUES (@tenTaiKhoan, @matKhau, @quyen, @maNV)", connection);
                    cmd.Parameters.AddWithValue("@tenTaiKhoan", tenTaiKhoan);
                    cmd.Parameters.AddWithValue("@matKhau", matKhau);
                    cmd.Parameters.AddWithValue("@quyen", quyen);
                    cmd.Parameters.AddWithValue("@maNV", maNV);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm tài khoản thành công!");
                        DanhSachTaiKhoan_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Thêm tài khoản thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string tenTaiKhoan = txtTenTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            string quyen = cbbQuyen.Text; 
            string maNV = cbbTenNV.SelectedValue.ToString(); 

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE tblTaiKhoan SET sTenTaiKhoanNV = @tenTaiKhoan, sMatKhauNV = @matKhau, sQuyen = @quyen WHERE sMaNV = @maNV", connection);
                cmd.Parameters.AddWithValue("@tenTaiKhoan", tenTaiKhoan);
                cmd.Parameters.AddWithValue("@matKhau", matKhau);
                cmd.Parameters.AddWithValue("@quyen", quyen);
                cmd.Parameters.AddWithValue("@maNV", maNV);

                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật tài khoản thành công!");
                    DanhSachTaiKhoan_Load(null, null); 
                }
                else
                {
                    MessageBox.Show("Cập nhật tài khoản thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (viewTaiKhoan.SelectedRows.Count > 0)
            {
                string maNV = cbbTenNV.SelectedValue.ToString();

                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblTaiKhoan WHERE sMaNV = @maNV", connection);
                    cmd.Parameters.AddWithValue("@maNV", maNV);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa tài khoản thành công!");
                        DanhSachTaiKhoan_Load(null, null); 
                    }
                    else
                    {
                        MessageBox.Show("Xóa tài khoản thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa.");
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            DanhSachTaiKhoan_Load(null, null);
        }
    }
}
