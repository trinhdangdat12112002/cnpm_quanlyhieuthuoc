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

namespace QuanLyHieuThuoc.NhanVien
{
    public partial class NhapHang : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HieuThuoc"].ConnectionString);

        private string username;
        private User currentUser;
        string maNV;

        public NhapHang(User user)
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
            // Tắt khả năng phóng to form (full screen)
            this.MaximizeBox = false;

            // Tắt khả năng thay đổi kích thước form bằng cách kéo góc hoặc cạnh
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void txtThemThuoc_Click(object sender, EventArgs e)
        {
            if (MdiParent is FormNhanVien mdiParent)
            {
                DanhSachThuoc form = new DanhSachThuoc(currentUser);
                form.MdiParent = mdiParent;
                form.Show();
            }

        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("getAllSanPham", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            connection.Close();
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);

            DataTable tbl_LoaiThuoc = new DataTable();
            adapter1.Fill(tbl_LoaiThuoc);
            viewThuoc.DataSource = tbl_LoaiThuoc;

            foreach (DataGridViewColumn col in viewThuoc.Columns)
            {
                switch (col.Name)
                {
                    case "sMaSP":
                        col.HeaderText = "Mã Thuốc";
                        col.Width = 50;
                        break;
                    case "sTenSP":
                        col.HeaderText = "Tên Thuốc";
                        col.Width = 100;
                        break;
                    case "sTenLoaiSP":
                        col.HeaderText = "Tên Loại Thuốc";
                        col.Width = 100;
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
            txtGiaNhap.Enabled = false;
            txtSoLuongNhap.Enabled = false;
            btnThem.Enabled = false;

            cbbNhaCungCap.DropDownStyle = ComboBoxStyle.DropDownList;
            connection.Open();
            SqlCommand cmdNhaCungCap = new SqlCommand("SELECT sMaNCC, sTenNCC FROM tblNhaCungCap", connection);
            SqlDataReader readerNhaCungCap = cmdNhaCungCap.ExecuteReader();
            List<KeyValuePair<string, string>> nhaCungCapList = new List<KeyValuePair<string, string>>();
            while (readerNhaCungCap.Read())
            {
                string maNhaCungCap = readerNhaCungCap.GetString(0);
                string tenNhaCungCap = readerNhaCungCap.GetString(1);
                nhaCungCapList.Add(new KeyValuePair<string, string>(maNhaCungCap, tenNhaCungCap));
            }
            connection.Close();

            cbbNhaCungCap.DataSource = nhaCungCapList;
            cbbNhaCungCap.DisplayMember = "Value";
            cbbNhaCungCap.ValueMember = "Key";

            cbLoHang.DropDownStyle = ComboBoxStyle.DropDownList;
            connection.Open();
            SqlCommand cmdLo = new SqlCommand("SElect sMaLo from tblLoHang ", connection);
            cmdLo.CommandType = CommandType.Text;
            SqlDataReader readerLo = cmdLo.ExecuteReader();
            List<KeyValuePair<int, string>> loList = new List<KeyValuePair<int, string>>();
            int i = 0;
            while (readerLo.Read())
            {
                i = i + 1;
                string maLo = readerLo["sMaLo"].ToString();
                loList.Add(new KeyValuePair<int, string>(i, maLo));
            }
            connection.Close();

            cbLoHang.DataSource = loList;
            cbLoHang.DisplayMember = "Value";
            cbLoHang.ValueMember = "Key";

            DateTime ngayHienTai = DateTime.Now;
            txtNgayNhap.Text = ngayHienTai.ToString("dd-MM-yyyy");
            txtNgayNhap.ReadOnly = true;

            btnHoanThanh.Enabled = false;
            btnThem.Enabled = false;   
            btnXoaChiTiet.Enabled = false;
        }

        private void viewThuoc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            viewThuoc.ClearSelection();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SearchSanPham", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@kyTu", txtSearch.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            connection.Close();

            DataTable table = new DataTable();
            adapter.Fill(table);

            viewThuoc.DataSource = table;
        }

        private void viewThuoc_SelectionChanged(object sender, EventArgs e)
        {
            txtSoLuongNhap.Enabled = true;
            txtGiaNhap.Enabled      =true;
            btnThem.Enabled = true;
        }
        float TongTien = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            
            if (txtGiaNhap.Text == "" || txtSoLuongNhap.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int dem = 0;
                for (int i = 0; i < viewChiTiet.Rows.Count; i++)
                {
                    DataGridViewRow row = viewChiTiet.Rows[i];
                    string ma_from_chitiet = row.Cells[0].Value.ToString();

                    DataGridViewRow selectedRow = viewThuoc.SelectedRows[0];
                    string ma_from_thuoc = selectedRow.Cells["sMaSP"].Value.ToString();

                    if (ma_from_chitiet == ma_from_thuoc)
                    {
                        dem++;
                    }
                }

                if (dem == 0)
                {

                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(viewChiTiet);
                    DataGridViewRow selectedRow = viewThuoc.SelectedRows[0];
                    row.Cells[0].Value = selectedRow.Cells["sMaSP"].Value.ToString();
                    row.Cells[1].Value = selectedRow.Cells["sTenSP"].Value.ToString();
                    row.Cells[2].Value = txtSoLuongNhap.Text;
                    row.Cells[3].Value = txtGiaNhap.Text;
                    viewChiTiet.Rows.Add(row);

                    TongTien += float.Parse(txtGiaNhap.Text) * int.Parse(txtSoLuongNhap.Text);
                    lbTongTien.Text = TongTien.ToString();

                    viewChiTiet.ClearSelection();

                    btnHoanThanh.Enabled = true;
                    btnXoaChiTiet.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Mã này đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            if (viewChiTiet.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = viewChiTiet.SelectedRows[0];
                viewChiTiet.Rows.Remove(selectedRow);

                TongTien = 0;
                foreach (DataGridViewRow row in viewChiTiet.Rows)
                {
                    float giaNhap = float.Parse(row.Cells[3].Value.ToString());
                    int soLuongNhap = int.Parse(row.Cells[2].Value.ToString());
                    TongTien += giaNhap * soLuongNhap;
                }

                lbTongTien.Text = TongTien.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            viewThuoc.ClearSelection();
            viewChiTiet.ClearSelection();
            txtGiaNhap.Text = string.Empty;
            txtSoLuongNhap.Text = string.Empty;
            txtGiaNhap.Enabled = false;
            txtSoLuongNhap.Enabled = false;
            btnThem.Enabled = false;
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            if (viewChiTiet.Rows.Count > 0)
            {
                SqlCommand cmdInsertHoaDon = new SqlCommand("INSERT INTO tblHoaDonNhap (sMaNV, sMaNCC, sMaLo, dNgayNhap, sGhiChuNhap) VALUES (@maNV, @maNCC, @maLo, @ngayNhap, @ghiChu); SELECT SCOPE_IDENTITY();", connection);
                cmdInsertHoaDon.Parameters.AddWithValue("@maNV", maNV);
                cmdInsertHoaDon.Parameters.AddWithValue("@maNCC", ((KeyValuePair<string, string>)cbbNhaCungCap.SelectedItem).Key);
                cmdInsertHoaDon.Parameters.AddWithValue("@maLo", cbLoHang.Text);
                cmdInsertHoaDon.Parameters.AddWithValue("@ngayNhap", DateTime.Now);
                cmdInsertHoaDon.Parameters.AddWithValue("@ghiChu", txtGhiChu.Text);

                connection.Open();
                int maHoaDon = Convert.ToInt32(cmdInsertHoaDon.ExecuteScalar());
                connection.Close();

                try
                {
                    foreach (DataGridViewRow row in viewChiTiet.Rows)
                    {
                        string maSP = row.Cells[0].Value.ToString();
                        string maLo = cbLoHang.Text;
                        int soLuongNhap = int.Parse(row.Cells[2].Value.ToString());
                        float giaNhap = int.Parse(row.Cells[3].Value.ToString());

                        // Tạo một đối tượng SqlCommand để thêm chi tiết hóa đơn vào cơ sở dữ liệu
                        SqlCommand cmdInsertChiTietHoaDon = new SqlCommand("INSERT INTO tblChiTietNhap (iMaHoaDonNhap, sMaSP, iSoLuongNhap, fGiaNhap) VALUES (@maHD, @maSP, @soLuong, @giaNhap);", connection);
                        cmdInsertChiTietHoaDon.Parameters.AddWithValue("@maHD", maHoaDon);
                        cmdInsertChiTietHoaDon.Parameters.AddWithValue("@maSP", maSP);
                        cmdInsertChiTietHoaDon.Parameters.AddWithValue("@soLuong", soLuongNhap);
                        cmdInsertChiTietHoaDon.Parameters.AddWithValue("@giaNhap", giaNhap);
                        connection.Open();
                        cmdInsertChiTietHoaDon.ExecuteNonQuery();
                        connection.Close();


                        SqlCommand cmd3 = new SqlCommand("SELECT Count(*) from tblLoSanPham where sMaSP = @maSP and sMaLo = @maLo", connection);
                        cmd3.Parameters.AddWithValue("@maSP", maSP);
                        cmd3.Parameters.AddWithValue("@maLo", maLo);
                        connection.Open();
                        int count = (int)cmd3.ExecuteScalar();
                        connection.Close();

                        if (count > 0)
                        {
                            SqlCommand cmd4 = new SqlCommand("UPDATE tblLoSanPham SET iSoLuongTrongLo += @soLuongNhap WHERE sMaSP = @maSP AND sMaLo = @maLo", connection);
                            cmd4.Parameters.AddWithValue("@maSP", maSP);
                            cmd4.Parameters.AddWithValue("@maLo", maLo);
                            cmd4.Parameters.AddWithValue("@soLuongNhap", soLuongNhap);
                            connection.Open();
                            cmd4.ExecuteNonQuery();
                            connection.Close();
                        }
                        else
                        {
                            SqlCommand cmd4 = new SqlCommand("INSERT INTO tblLoSanPham(sMaSP, sMaLo, iSoLuongTrongLo) VALUES (@maSP, @maLo, @soLuongNhap)", connection);
                            cmd4.Parameters.AddWithValue("@maSP", maSP);
                            cmd4.Parameters.AddWithValue("@maLo", maLo);
                            cmd4.Parameters.AddWithValue("@soLuongNhap", soLuongNhap);
                            connection.Open();
                            cmd4.ExecuteNonQuery();
                            connection.Close();
                        }

                    }

                    MessageBox.Show("Thêm hóa đơn thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                NhapHang_Load(null, null);
            }
            else
            {
                MessageBox.Show("Chưa có sản phẩm trong giỏ hàng ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
