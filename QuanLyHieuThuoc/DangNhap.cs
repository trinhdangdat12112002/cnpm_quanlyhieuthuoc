using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyHieuThuoc
{
    public partial class DangNhap : Form
    {
        SqlConnection connection = new SqlConnection("data source=DESKTOP-KHO76ED;Initial Catalog=HieuThuoc;Integrated Security=True");

        private User currentUser;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text != "" )
            {
                if (txtMatKhau.Text != "")
                {
                    if( rbNhanVien.Checked)
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("DangNhapNV", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tenTaiKhoanNV", txtTenDangNhap.Text);
                        cmd.Parameters.AddWithValue("@matKhauNV", txtMatKhau.Text);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            currentUser = new User { Username = dt.Rows[0]["sTenTaiKhoanNV"].ToString(), Role = dt.Rows[0]["sQuyen"].ToString() };
                            MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FormNhanVien form = new FormNhanVien(currentUser);
                            this.Hide();
                            form.Show();
                        }
                        else
                        {
                            lbError.Text = "Tài khoản mật khẩu không chính xác";
                        }
                        connection.Close();
                    }
                    else if (rbKhachHang.Checked)
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("DangNhapKH", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tenTaiKhoanKH", txtTenDangNhap.Text);
                        cmd.Parameters.AddWithValue("@matKhauKH", txtMatKhau.Text);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            currentUser = new User { Username = dt.Rows[0]["sTenTaiKhoanKH"].ToString() };
                            MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FormKhachHang form = new FormKhachHang(currentUser);
                            this.Hide();
                            form.Show();
                        }
                        else
                        {
                            lbError.Text = "Tài khoản mật khẩu không chính xác";
                        }
                        connection.Close();
                    }
                    else
                    {
                        lbError.Text = "Lựa chọn quyền truy cập";
                    }
                }
                else
                {
                    lbError.Text = "Vui lòng nhập mật khẩu";
                }
            }
            else
            {
                lbError.Text = "Vui lòng nhập tên tài khoản";
            }
        }
        public class User
        {
            public string Username { get; set; }
            public string Role { get; set; }
        }
    }
}
