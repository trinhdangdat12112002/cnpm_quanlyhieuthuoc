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

namespace QuanLyHieuThuoc.QuanLy
{
    public partial class DanhSachNhap : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HieuThuoc"].ConnectionString);

        private string username;
        private User currentUser;
        string maNV;
        public DanhSachNhap( User user)
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

        private void DanhSachNhap_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT iMaHoaDonNhap, sTenNV , sTenNCC, sMaLo , dNgayNhap , sGhiChuNhap " +
                " from tblHoaDonNhap inner join tblNhanVien on tblHoaDonNhap.sMaNV = tblNhanVien.sMaNV" +
                " inner join tblNhaCungCap on tblNhaCungCap.sMaNCC = tblHoaDonNhap.sMaNCC " , connection);
            cmd1.CommandType = CommandType.Text;
            cmd1.Parameters.AddWithValue("@maNV", maNV);
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            connection.Close();

            DataTable tbl_LichSu = new DataTable();
            adapter1.Fill(tbl_LichSu);
            viewLichSu.DataSource = tbl_LichSu;

            foreach (DataGridViewColumn col in viewLichSu.Columns)
            {
                switch (col.Name)
                {
                    case "iMaHoaDonNhap":
                        col.HeaderText = "Mã Nhập";
                        col.Width = 100;
                        break;
                    case "sTenNV":
                        col.HeaderText = "Tên Nhân Viên";
                        col.Width = 100;
                        break;
                    case "sTenNCC":
                        col.HeaderText = "Tên Nhà Cung Cấp";
                        col.Width = 100;
                        break;
                    case "sMaLo":
                        col.HeaderText = "Mã Lô";
                        col.Width = 100;
                        break;
                    case "dNgayNhap":
                        col.HeaderText = "Ngày Lập";
                        col.Width = 100;
                        break;
                    case "sGhiChuNhap":
                        col.HeaderText = "Ghi Chú";
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
                int madat = Convert.ToInt32(selectedRow.Cells["iMaHoaDonNhap"].Value.ToString());

                connection.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT sTenSP , iSoLuongNhap, fGiaNhap " +
                    " FROM tblChiTietNhap inner join tblSanPham on  tblChiTietNhap.sMaSP = tblSanPham.sMaSP" +
                    " where iMaHoaDonNhap = @maBanHang", connection);
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
                            col.HeaderText = "Tên Sản Phẩm";
                            col.Width = 100;
                            break;
                        case "iSoLuongNhap":
                            col.HeaderText = "Số Lượng";
                            col.Width = 100;
                            break;
                        case "fGiaNhap":
                            col.HeaderText = "Giá Bán";
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
            SqlCommand cmd1 = new SqlCommand("SELECT iMaHoaDonNhap, sTenNV , sTenNCC, sMaLo , dNgayNhap , sGhiChuNhap " +
                " from tblHoaDonNhap inner join tblNhanVien on tblHoaDonNhap.sMaNV = tblNhanVien.sMaNV" +
                " inner join tblNhaCungCap on tblNhaCungCap.sMaNCC = tblHoaDonNhap.sMaNCC " +
                " and iMaHoaDonNhap like @kyTu" +
                " or sTenNCC like @kyTu", connection);
            cmd1.CommandType = CommandType.Text;
            cmd1.Parameters.AddWithValue("@maNV", maNV);
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
                SqlCommand cmd1 = new SqlCommand("SELECT iMaHoaDonNhap, sTenNV , sTenNCC, sMaLo , dNgayNhap , sGhiChuNhap " +
                    " from tblHoaDonNhap inner join tblNhanVien on tblHoaDonNhap.sMaNV = tblNhanVien.sMaNV" +
                    " inner join tblNhaCungCap on tblNhaCungCap.sMaNCC = tblHoaDonNhap.sMaNCC " +
                    " AND dNgayNhap > @ngayTu -1 and dNgayNhap < @ngayDen + 1 ", connection);
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
