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
    public partial class DanhSachLichSu : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HieuThuoc"].ConnectionString);

        private string username;
        private User currentUser;
        string maNV;
        public DanhSachLichSu(User user)
        {
            InitializeComponent();
            currentUser = user;
            username = user.Username;

            try
            {
                BusinessLogicLayer.TaiKhoanBLL manv = new BusinessLogicLayer.TaiKhoanBLL();
                maNV = manv.getMaNV(username);
            }
            catch (SqlException ex)
            {
                foreach (SqlError er in ex.Errors)
                {
                    MessageBox.Show("Lỗi :" + er.Message);
                }
            }

            txtTu.Format = DateTimePickerFormat.Custom;
            txtTu.CustomFormat = "dd/MM/yyyy";

            txtDen.Format = DateTimePickerFormat.Custom;
            txtDen.CustomFormat = "dd/MM/yyyy";
        }

        private void DanhSachLichSu_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT iMaBanHang, dNgayBan , fTongTien,  sTenNV" +
                " FROM tblBanHang inner join tblNhanVien on tblBanHang.sMaNV = tblNhanVien.sMaNV", connection);
            cmd1.CommandType = CommandType.Text;
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            connection.Close();

            DataTable tbl_LichSu = new DataTable();
            adapter1.Fill(tbl_LichSu);
            viewLichSu.DataSource = tbl_LichSu;

            foreach (DataGridViewColumn col in viewLichSu.Columns)
            {
                switch (col.Name)
                {
                    case "iMaBanHang":
                        col.HeaderText = "Mã Hóa Đơn";
                        col.Width = 100;
                        break;
                    case "dNgayBan":
                        col.HeaderText = "Ngày Bán";
                        col.Width = 100;
                        break;
                    case "fTongTien":
                        col.HeaderText = "Tổng Tiền";
                        col.Width = 100;
                        break;
                    case "sTenNV":
                        col.HeaderText = "Tên Nhân Viên";
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
                int madat = Convert.ToInt32(selectedRow.Cells["iMaBanHang"].Value.ToString());

                connection.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT sTenSP , iSoLuongBan, fGiaBan " +
                    " FROM tblChiTietBanHang inner join tblSanPham on  tblChiTietBanHang.sMaSP = tblSanPham.sMaSP" +
                    " where iMaBanHang = @maBanHang", connection);
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.AddWithValue("@maBanHang", madat);

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
                        case "iSoLuongBan":
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT iMaBanHang, dNgayBan , fTongTien FROM tblBanHang " +
                " where iMaBanHang like @kyTu", connection);
            cmd1.CommandType = CommandType.Text;
            cmd1.Parameters.AddWithValue("@kyTu", "%" + txtSearch.Text + "%");
            SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
            connection.Close();

            DataTable table = new DataTable();
            adapter.Fill(table);

            viewLichSu.DataSource = table;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime ngayTu = txtTu.Value;
            DateTime ngayDen = txtDen.Value;

            if (ngayTu > ngayDen)
            {
                MessageBox.Show("Ngày sau phải lớn hơn ngày trước", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT iMaBanHang, dNgayBan, fTongTien FROM tblBanHang WHERE sMaNV = @maNV AND dNgayBan > @ngayTu -1 and dNgayBan < @ngayDen + 1 ", connection);
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.AddWithValue("@maNV", maNV);
                cmd1.Parameters.AddWithValue("@ngayTu", ngayTu);
                cmd1.Parameters.AddWithValue("@ngayDen", ngayDen);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
                connection.Close();

                DataTable table = new DataTable();
                adapter.Fill(table);

                viewLichSu.DataSource = table;
            }
        }
    }
}
