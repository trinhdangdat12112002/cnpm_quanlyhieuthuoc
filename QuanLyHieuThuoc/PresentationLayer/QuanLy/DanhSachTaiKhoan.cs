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

namespace QuanLyHieuThuoc.QuanLy
{
    public partial class DanhSachTaiKhoan : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HieuThuoc"].ConnectionString);

        private string username;
        private User currentUser;
        string maNV;

        BusinessLogicLayer.TaiKhoanBLL tk = new BusinessLogicLayer.TaiKhoanBLL();
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
            catch 
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
            try
            {
                viewTaiKhoan.DataSource = tk.getTaiKhoan();

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
            catch (SqlException ex)
            {
                foreach (SqlError er in ex.Errors)
                {
                    MessageBox.Show("Lỗi :" + er.Message);
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

                string selectedLoaiThuoc = selectedRow.Cells["sMaNV"].Value.ToString();
                foreach (KeyValuePair<string, string> item in cbbTenNV.Items)
                {
                    if (item.Key == selectedLoaiThuoc)
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
            string tenTaiKhoan = txtTenTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string quyen = cbbQuyen.Text.Trim();
            string maNV = cbbTenNV.SelectedValue.ToString();

            if (tenTaiKhoan =="")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập");
                txtTenTaiKhoan.Focus();
                return;
            }
            if (matKhau == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                txtMatKhau.Focus();
                return;
            }
            try
            {
                if (tk.check_NV_TK(maNV) > 0)
                {
                    MessageBox.Show("Nhân Viên đã này đã có tài khoản");
                    return;
                }
                if (tk.checkTaiKhoan(tenTaiKhoan) > 0)
                {
                    MessageBox.Show("Tài khoản đã tồn tại");
                    return;
                }
                if (tk.insertTaiKhoan(tenTaiKhoan, matKhau, quyen, maNV) > 0)
                {
                    MessageBox.Show("Thêm tài khoản thành công!");
                    DanhSachTaiKhoan_Load(null, null);
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
            string tenTaiKhoan = txtTenTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            string quyen = cbbQuyen.Text; 
            string maNV = cbbTenNV.SelectedValue.ToString();
            MessageBox.Show(" " + maNV);

            if (tenTaiKhoan == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập");
                txtTenTaiKhoan.Focus();
                return;
            }
            if (matKhau == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                txtMatKhau.Focus();
                return;
            }

            try
            {
                if (tk.updateTaiKhoan(tenTaiKhoan, matKhau, quyen, maNV) > 0)
                {
                    MessageBox.Show("Cập nhật tài khoản thành công!");
                    DanhSachTaiKhoan_Load(null, null); 
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (viewTaiKhoan.SelectedRows.Count > 0)
            {
                string maNV = cbbTenNV.SelectedValue.ToString();

                try
                {
                    if (tk.deleteTaiKhoan(maNV) > 0)
                    {
                        MessageBox.Show("Xóa tài khoản thành công!");
                        DanhSachTaiKhoan_Load(null, null); 
                    }
                    else
                    {
                        MessageBox.Show("Xóa tài khoản thất bại!");
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

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            DanhSachTaiKhoan_Load(null, null);
        }
    }
}
