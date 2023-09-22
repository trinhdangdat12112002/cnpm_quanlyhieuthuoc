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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyHieuThuoc.KhachHang
{
    public partial class DoiMatKhauKachHang : Form
    {
        SqlConnection connection = new SqlConnection("data source=DESKTOP-KHO76ED;Initial Catalog=HieuThuoc;Integrated Security=True");

        private string username;
        private User currentUser;
        int maKH;
        public DoiMatKhauKachHang(User user)
        {
            InitializeComponent();
            currentUser = user;
            username = user.Username;

            connection.Open();
            SqlCommand cmm = new SqlCommand("getMaKH", connection);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.AddWithValue("@tenTaiKhoanKH", username);
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmm);
            DataTable d = new DataTable();
            adapter1.Fill(d);
            connection.Close();
            maKH = Convert.ToInt32(d.Rows[0]["iMaKH"]);
        }

        private void DoiMatKhauKachHang_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (txtCurrentPass.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtNewPass.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtConfirmPass.Text == "")
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtNewPass.Text != txtConfirmPass.Text) 
            {
                MessageBox.Show("Xác nhận mật khẩu không giống nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("checkKH", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maKH", maKH);
                cmd.Parameters.AddWithValue("@currentPass", txtCurrentPass.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                connection.Close();

                if (dt.Rows.Count > 0)
                {
                    SqlCommand cmd2 = new SqlCommand("doiMatKhauKH", connection);
                    cmd2.CommandType = CommandType.StoredProcedure;

                    cmd2.Parameters.AddWithValue("@maKH", maKH);
                    cmd2.Parameters.AddWithValue("@newPass", txtNewPass.Text);

                    connection.Open();
                    cmd2.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ sai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
