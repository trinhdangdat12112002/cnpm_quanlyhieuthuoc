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
        int maKH;

        public DanhSachLoaiThuoc()
        {
            InitializeComponent();

           /* connection.Open();
            SqlCommand cmm = new SqlCommand("getMaKH", connection);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.AddWithValue("@tenTaiKhoanKH", username);
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmm);
            DataTable d = new DataTable();
            adapter1.Fill(d);
            connection.Close();
            maKH = Convert.ToInt32(d.Rows[0]["iMaKH"]); */
        }
    }
}
