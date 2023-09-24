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

namespace QuanLyHieuThuoc.NhanVien
{
    public partial class BanHang : Form
    {
        SqlConnection connection = new SqlConnection("data source=DESKTOP-KHO76ED;Initial Catalog=HieuThuoc;Integrated Security=True");

        private string username;
        private User currentUser;
        string maNV;
        public BanHang(User user)
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

                if (reader.Read()) // Đọc dòng đầu tiên
                {
                    maNV = reader["sMaNV"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            connection.Close();
        }

        private void BanHang_Load(object sender, EventArgs e)
        {
            txtNgaySanXuat.Format = DateTimePickerFormat.Custom;
            txtNgaySanXuat.CustomFormat = "dd/MM/yyyy";

            txtHanSuDung.Format = DateTimePickerFormat.Custom;
            txtHanSuDung.CustomFormat = "dd/MM/yyyy";

            connection.Open();
            SqlCommand cmd1 = new SqlCommand("getAllSanPham", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
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
            viewThuoc.ScrollBars = ScrollBars.None;

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

        private void viewThuoc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            viewThuoc.ClearSelection();

            txtTenThuoc.ReadOnly = true;
            txtTenLoaiThuoc.ReadOnly = true;
            txtThongTin.ReadOnly = true;
            txtNuocSanXuat.ReadOnly = true;
            txtHangSanXuat.ReadOnly = true;
            txtGiaBan.ReadOnly = true;
            txtCachDung.ReadOnly = true;

            txtNgaySanXuat.Enabled = false;
            txtHanSuDung.Enabled = false;

            txtSoLuonDat.Enabled = false;
            btnThem.Enabled = false;
            btnHoanThanh.Enabled = false;
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

            txtSoLuonDat.Clear();

            txtSoLuonDat.Enabled = true;
            btnThem.Enabled = true;

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

                string maSP1 = selectedRow.Cells["sMaSP"].Value.ToString();

                cbLo.DropDownStyle = ComboBoxStyle.DropDownList;
                connection.Open();
                SqlCommand cmdLo = new SqlCommand("getMaLoVsSanPham", connection);
                cmdLo.CommandType = CommandType.StoredProcedure;
                cmdLo.Parameters.AddWithValue("@maSP", maSP1);
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

                cbLo.DataSource = loList;
                cbLo.DisplayMember = "Value";
                cbLo.ValueMember = "Key";
            }

        }

        private void cbLo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maLo = cbLo.Text;

            connection.Open();
            SqlCommand cmdLo = new SqlCommand("getNgayTuLo", connection);
            cmdLo.CommandType = CommandType.StoredProcedure;
            cmdLo.Parameters.AddWithValue("@maLo", maLo);
            SqlDataAdapter adapter = new SqlDataAdapter(cmdLo);
            connection.Close();

            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                txtNgaySanXuat.Value = (DateTime)row["dNgaySanXuat"];
                txtHanSuDung.Value = (DateTime)row["dNgayHetHan"];
            }
        }

        float TongTien = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoLuonDat.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!int.TryParse(txtSoLuonDat.Text, out int soLuongDat) || soLuongDat <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập một số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int dem = 0;
                for (int i = 0; i < viewChiTietDat.Rows.Count; i++)
                {
                    DataGridViewRow row = viewChiTietDat.Rows[i];
                    string ma_from_chitiet = row.Cells[0].Value.ToString();

                    DataGridViewRow selectedRow = viewThuoc.SelectedRows[0];
                    string ma_from_thuoc = selectedRow.Cells["sMaSP"].Value.ToString();

                    if (ma_from_chitiet == ma_from_thuoc)
                    {
                        dem++;
                    }
                }
                int soLuong = 0;
                if (dem == 0)
                {
                    if (viewThuoc.Rows.Count > 0)
                    {
                        connection.Open();
                        DataGridViewRow row1 = viewThuoc.SelectedRows[0];

                        SqlCommand cmdLo = new SqlCommand("SELECT iSoLuongTrongLo from tblLoSanPham where sMaSP = @maSP and sMaLo = @maLo", connection);
                        cmdLo.CommandType = CommandType.Text;
                        cmdLo.Parameters.AddWithValue("@maSP", row1.Cells["sMaSP"].Value.ToString());
                        cmdLo.Parameters.AddWithValue("@maLo", cbLo.Text);

                        object result = cmdLo.ExecuteScalar();
                        connection.Close();
                        if (result != null && result != DBNull.Value)
                        {
                            soLuong = Convert.ToInt32(result);
                        }

                        if (soLuong > Convert.ToInt32(txtSoLuonDat.Text))
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(viewChiTietDat);
                            DataGridViewRow selectedRow = viewThuoc.SelectedRows[0];
                            row.Cells[0].Value = selectedRow.Cells["sMaSP"].Value.ToString();
                            row.Cells[1].Value = selectedRow.Cells["sTenSP"].Value.ToString();
                            row.Cells[2].Value = selectedRow.Cells["fGiaBan"].Value.ToString();
                            row.Cells[3].Value = cbLo.Text;
                            row.Cells[4].Value = txtSoLuonDat.Text;
                            viewChiTietDat.Rows.Add(row);

                            TongTien += float.Parse(selectedRow.Cells["fGiaBan"].Value.ToString()) * int.Parse(txtSoLuonDat.Text);
                            lbTongTien.Text = TongTien.ToString();

                            btnHoanThanh.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Số lượng không đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mã này đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (viewChiTietDat.SelectedRows.Count > 0)
            {
                int rowIndex = viewChiTietDat.SelectedRows[0].Index;
                if (viewChiTietDat.SelectedRows[0].Cells["fGiaBan"].Value != null)
                {
                    float giaBan = float.Parse(viewChiTietDat.SelectedRows[0].Cells["fGiaBan"].Value.ToString());
                    int soLuong = int.Parse(viewChiTietDat.SelectedRows[0].Cells[4].Value.ToString());
                    TongTien -= giaBan * soLuong;
                    lbTongTien.Text = TongTien.ToString();
                }
                viewChiTietDat.Rows.RemoveAt(rowIndex);
            }
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            SqlCommand cmdInsertHoaDon = new SqlCommand("INSERT INTO tblBanHang (sMaNV, dNgayBan) VALUES (@maNV, @ngayLap); SELECT SCOPE_IDENTITY();", connection);
            cmdInsertHoaDon.Parameters.AddWithValue("@maNV", maNV);
            cmdInsertHoaDon.Parameters.AddWithValue("@ngayLap", DateTime.Now);

            connection.Open();
            int maHoaDon = Convert.ToInt32(cmdInsertHoaDon.ExecuteScalar()); 
            connection.Close();

            try
            {
                foreach (DataGridViewRow row in viewChiTietDat.Rows)
                {
                    string maSP = row.Cells[0].Value.ToString();
                    string maLo = row.Cells[3].Value.ToString();
                    int soLuongDat = int.Parse(row.Cells[4].Value.ToString());

                    // Tạo một đối tượng SqlCommand để thêm chi tiết hóa đơn vào cơ sở dữ liệu
                    SqlCommand cmdInsertChiTietHoaDon = new SqlCommand("INSERT INTO tblChiTietBanHang (iMaBanHang, sMaSP, sMaLo, iSoLuongBan) VALUES (@maHD, @maSP, @maLo, @soLuong);", connection);
                    cmdInsertChiTietHoaDon.Parameters.AddWithValue("@maHD", maHoaDon);
                    cmdInsertChiTietHoaDon.Parameters.AddWithValue("@maSP", maSP);
                    cmdInsertChiTietHoaDon.Parameters.AddWithValue("@maLo", maLo);
                    cmdInsertChiTietHoaDon.Parameters.AddWithValue("@soLuong", soLuongDat);
                    connection.Open ();
                    cmdInsertChiTietHoaDon.ExecuteNonQuery();
                    connection.Close();

                    SqlCommand cmd5 = new SqlCommand("UPDATE tblBanHang " +
                        " SET fTongTien = @tongTien " +
                        " where iMaBanHang = @maHD", connection);
                    cmd5.Parameters.AddWithValue("@maHD", maHoaDon);
                    cmd5.Parameters.AddWithValue("@tongTien", TongTien);
                    connection.Open();
                    cmd5.ExecuteNonQuery();
                    connection.Close();

                    SqlCommand cmd3 = new SqlCommand("Update tblLoSanPham " +
                        " set iSoLuongTrongLo = iSoLuongTrongLo - @soluong" +
                        " where sMaSP = @maSP and sMaLo = @maLo", connection);
                    cmd3.Parameters.AddWithValue("@maSP", maSP);
                    cmd3.Parameters.AddWithValue("@maLo", maLo);
                    cmd3.Parameters.AddWithValue("@soLuong", soLuongDat);
                    connection.Open();
                    cmd3.ExecuteNonQuery();
                    connection.Close();
                }

                MessageBox.Show("Thêm hóa đơn thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            BanHang_Load(null, null);

        }
    }
}
