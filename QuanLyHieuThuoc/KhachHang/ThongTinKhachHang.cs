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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QuanLyHieuThuoc.KhachHang
{

    public partial class ThongTinKhachHang : Form
    {
        SqlConnection connection = new SqlConnection("data source=DESKTOP-KHO76ED;Initial Catalog=HieuThuoc;Integrated Security=True");

        private User currentUser;
        private string username;
        public ThongTinKhachHang(User user)
        {
            InitializeComponent();
            currentUser = user;
            txtMakhachHang.Text = user.Username;
            username = user.Username;
            connection.Open();
            SqlCommand command = new SqlCommand("SearchKhachHang", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@tenDangNhapKH", user.Username);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            connection.Close();

            DataTable table = new DataTable();
            adapter.Fill(table);

            DataRow row = table.Rows[0];

            txtMakhachHang.Text = row["iMaKH"].ToString();
            txtTenKhachHang.Text = row["sTenKH"].ToString();
            txtSdt.Text = row["sSdtKh"].ToString();

            bool gioiTinh = (bool)row["iGioiTinhKH"];
            if (gioiTinh)
            {
                rbNam.Checked = true;
            }
            else
            {
                rbNu.Checked = true;
            }
            txtDiaChi.Text = row["sDiaChiKH"].ToString();
            DateTime ngaySinh = (DateTime)row["dNgaySinhKH"];
            dateTimePicker1.Value = ngaySinh;

            txtMakhachHang.Enabled= false;
        }

        private void ThongTinKhachHang_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("UpdateKhachHang", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tenDangNhapKH", username);
            cmd.Parameters.AddWithValue("@tenKH", txtTenKhachHang.Text);
            //gioitinh
            bool gioiTinh;
            if (rbNam.Checked)
            {
                gioiTinh = true;
            }
            else
            {
                gioiTinh = false;
            }
            cmd.Parameters.AddWithValue("@gioiTinhKH", gioiTinh);
            //ngáyinh
            DateTime ngaySinh = dateTimePicker1.Value;
            cmd.Parameters.AddWithValue("@ngaySinhKH", ngaySinh.Date);
            cmd.Parameters.AddWithValue("@sdtKH", txtSdt.Text);
            cmd.Parameters.AddWithValue("@diaChiKH", txtDiaChi.Text);

            cmd.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
