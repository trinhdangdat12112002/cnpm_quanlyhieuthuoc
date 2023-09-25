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

namespace QuanLyHieuThuoc.KhachHang
{
    public partial class LichSuMuaHang : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HieuThuoc"].ConnectionString);

        private string username;
        private User currentUser;
        int maKH;
        public LichSuMuaHang(User user)
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

        private void btnLoc_Click(object sender, EventArgs e)
        {

        }

        private void LichSuMuaHang_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("getLischSuDat", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@maKH", maKH);
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            connection.Close();

            DataTable tbl_LichSu = new DataTable();
            adapter1.Fill(tbl_LichSu);
            viewLichSu.DataSource = tbl_LichSu;

            foreach (DataGridViewColumn col in viewLichSu.Columns)
            {
                switch (col.Name)
                {
                    case "iMaDonDatHang":
                        col.HeaderText = "Mã đơn";
                        col.Width = 100;
                        break;
                    case "dNgayDat":
                        col.HeaderText = "Ngày đặt";
                        col.Width = 100;
                        break;
                    case "sGhiChuDat":
                        col.HeaderText = "Ghi chú";
                        col.Width = 100;
                        break;
                    case "sTrangThai":
                        col.HeaderText = "Trạng Thái";
                        col.Width = 100;
                        break;
                    default:
                        col.HeaderText = col.Name;
                        break;
                }
            }
        }

        private void viewLichSu_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            viewLichSu.ClearSelection();
        }

        private void viewLichSu_SelectionChanged(object sender, EventArgs e)
        {
            if (viewLichSu.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = viewLichSu.SelectedRows[0];
                int madat = Convert.ToInt32(selectedRow.Cells["iMaDatHang"].Value.ToString());

                connection.Open();
                SqlCommand cmd1 = new SqlCommand("getChiTietLichSu", connection);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@maKH", maKH);

                cmd1.Parameters.AddWithValue("@maDonDat", madat);

                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                connection.Close();

                DataTable tbl_CTLichSu = new DataTable();
                adapter1.Fill(tbl_CTLichSu);
                viewChiTietLichSu.DataSource = tbl_CTLichSu;

                foreach (DataGridViewColumn col in viewChiTietLichSu.Columns)
                {
                    switch (col.Name)
                    {
                        case "sTenSP":
                            col.HeaderText = "Ten San Pham";
                            col.Width = 100;
                            break;
                        case "iSoLuongDat":
                            col.HeaderText = "So Luong";
                            col.Width = 100;
                            break;
                        case "fGiaBan":
                            col.HeaderText = "Gia ban";
                            col.Width = 100;
                            break;
                        default:
                            col.HeaderText = col.Name;
                            break;
                    }
                }
            }
        }
    }
}
