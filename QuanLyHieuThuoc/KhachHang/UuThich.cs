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

namespace QuanLyHieuThuoc.KhachHang
{
    public partial class UuThich : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HieuThuoc"].ConnectionString);

        private string username;
        private User currentUser;
        int maKH;
        public UuThich( User user) 
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

        private void UuThich_Load(object sender, EventArgs e)
        {
            txtTenThuoc.Clear();
            txtTenLoaiThuoc.Clear();
            txtThongTin.Clear();
            txtNuocSanXuat.Clear();
            txtHangSanXuat.Clear();
            txtGiaBan.Clear();
            txtCachDung.Clear();

            connection.Open();
            SqlCommand cmd1 = new SqlCommand("getAllUuThich", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@iMaKH", maKH);
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);     
            connection.Close();

            DataTable tbl_LoaiThuoc = new DataTable();
            adapter1.Fill(tbl_LoaiThuoc);
            viewThuoc.DataSource = tbl_LoaiThuoc;

            foreach (DataGridViewColumn col in viewThuoc.Columns)
            {
                switch (col.Name)
                {
                    case "sMaSP":
                        col.HeaderText = "Mã Thuốc";
                        col.Width = 100;
                        break;
                    case "sTenSP":
                        col.HeaderText = "Tên Thuốc";
                        col.Width = 200;
                        break;
                    case "sTenLoaiSP":
                        col.HeaderText = "Tên Loại Thuốc";
                        col.Width = 200;
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
            txtTenThuoc.ReadOnly = true;
            txtTenLoaiThuoc.ReadOnly = true;
            txtThongTin.ReadOnly = true;
            txtNuocSanXuat.ReadOnly = true;
            txtHangSanXuat.ReadOnly = true;
            txtGiaBan.ReadOnly = true;
            txtCachDung.ReadOnly = true;
        }

        private void viewThuoc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            viewThuoc.ClearSelection();
        }

        private void viewThuoc_SelectionChanged(object sender, EventArgs e)
        {
            txtTenThuoc.Clear();
            txtTenLoaiThuoc.Clear();
            txtThongTin.Clear();
            txtNuocSanXuat.Clear();
            txtHangSanXuat.Clear();
            txtGiaBan.Clear();
            txtCachDung.Clear();
            if (viewThuoc.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = viewThuoc.SelectedRows[0];
                txtThongTin.Text = selectedRow.Cells["sThongTinSP"].Value.ToString();
                txtTenThuoc.Text = selectedRow.Cells["sTenSP"].Value.ToString();
                txtTenLoaiThuoc.Text = selectedRow.Cells["sTenLoaiSP"].Value.ToString();
                txtGiaBan.Text = selectedRow.Cells["fGiaBan"].Value.ToString();
                txtHangSanXuat.Text = selectedRow.Cells["sHangSX"].Value.ToString();
                txtNuocSanXuat.Text = selectedRow.Cells["sNuocSX"].Value.ToString();
                txtCachDung.Text = selectedRow.Cells["sCachDung"].Value.ToString();
            }
        }

        private void txtXoaUuThich_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = viewThuoc.SelectedRows[0];
            string maDP = selectedRow.Cells["sMaSP"].Value.ToString();

            connection.Open();
            SqlCommand command = new SqlCommand("xoaUuThich", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@maKH", maKH);
            command.Parameters.AddWithValue("@maSP", maDP);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            UuThich_Load(sender, e);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SearchUuThich", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@kyTu", txtSearch.Text);
            command.Parameters.AddWithValue("@maKH", maKH);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            connection.Close();

            DataTable table = new DataTable();
            adapter.Fill(table);

            viewThuoc.DataSource = table;
        }
    }
}
