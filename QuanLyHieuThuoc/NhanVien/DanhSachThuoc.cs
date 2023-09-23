using System;
using System.Collections;
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
    public partial class DanhSachThuoc : Form
    {
        SqlConnection connection = new SqlConnection("data source=DESKTOP-KHO76ED;Initial Catalog=HieuThuoc;Integrated Security=True");

        private string username;
        private User currentUser;
        string maNV;
        public DanhSachThuoc(User user)
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
                    txtTest.Text = maNV.ToString();
                }
            }
            catch (Exception ex)
            {

            }
            connection.Close();

        }

        private void DanhSachThuoc_Load(object sender, EventArgs e)
        {

            // Lay danh sach loai thuoc
            cbbLoaiThuoc.DropDownStyle = ComboBoxStyle.DropDownList;
            connection.Open();
            SqlCommand cmdLoaiThuoc = new SqlCommand("SELECT sMaLoaiSP , sTenLoaiSP from tblLoaiSanPham", connection);
            SqlDataReader readerLoaiThuoc = cmdLoaiThuoc.ExecuteReader();
            List<KeyValuePair<string, string>> loaiThuocList = new List<KeyValuePair<string, string>>();
            while (readerLoaiThuoc.Read())
            {
                string maLoaiThuoc = readerLoaiThuoc.GetString(0);
                string tenLoaiThuoc = readerLoaiThuoc.GetString(1);
                loaiThuocList.Add(new KeyValuePair<string, string>(maLoaiThuoc, tenLoaiThuoc));
            }
            connection.Close();

            cbbLoaiThuoc.DataSource = loaiThuocList;
            cbbLoaiThuoc.DisplayMember = "Value";
            cbbLoaiThuoc.ValueMember = "Key";

            // Lay danh sach thuoc
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
        }

        private void viewThuoc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            viewThuoc.ClearSelection();
            btnBoQua.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnLoc.Enabled = true;
        }

        private void viewThuoc_SelectionChanged(object sender, EventArgs e)
        {
            txtTenThuoc.Clear();
            txtMaThuoc.Clear();
            
            txtThongTin.Clear();
            txtNuocSanXuat.Clear();
            txtHangSanXuat.Clear();
            txtGiaBan.Clear();
            txtCachDung.Clear();
            if (viewThuoc.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = viewThuoc.SelectedRows[0];
                txtMaThuoc.Text = selectedRow.Cells["sMaSP"].Value.ToString();
                txtThongTin.Text = selectedRow.Cells["sThongTinSP"].Value.ToString();
                txtTenThuoc.Text = selectedRow.Cells["sTenSP"].Value.ToString();

                string selectedLoaiThuoc = selectedRow.Cells["sTenLoaiSP"].Value.ToString();

                foreach (KeyValuePair<string, string> item in cbbLoaiThuoc.Items)
                {
                    if (item.Value == selectedLoaiThuoc)
                    {
                        cbbLoaiThuoc.SelectedItem = item;
                        break;
                    }
                }

                txtGiaBan.Text = selectedRow.Cells["fGiaBan"].Value.ToString();
                txtHangSanXuat.Text = selectedRow.Cells["sHangSX"].Value.ToString();
                txtNuocSanXuat.Text = selectedRow.Cells["sNuocSX"].Value.ToString();
                txtCachDung.Text = selectedRow.Cells["sCachDung"].Value.ToString();
            }
            btnBoQua.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            btnLoc.Enabled  = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            DanhSachThuoc_Load(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenThuoc.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenThuoc.Focus();
            }
            else if (txtMaThuoc.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã thuốc thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaThuoc.Focus();
            }
            else if (txtThongTin.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtThongTin.Focus();
            }
            else if (txtNuocSanXuat.Text == "")
            {
                MessageBox.Show("Vui lòng nhập nước sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNuocSanXuat.Focus();
            }
            else if (txtHangSanXuat.Text == "")
            {
                MessageBox.Show("Vui lòng nhập hãng sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHangSanXuat.Focus();
            }
            else if (txtGiaBan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaBan.Focus();
            }
            else if (txtCachDung.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Cách dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCachDung.Focus();
            }
            else if (!decimal.TryParse(txtGiaBan.Text, out decimal giaBan) || giaBan <= 0)
            {
                MessageBox.Show("Giá bán đang sai định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaBan.Focus();
                txtGiaBan.SelectAll();
            }
            else
            {
                try
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM tblSanPham WHERE sMaSP = @sMaSP";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@sMaSP", txtMaThuoc.Text);

                    int existingCount = (int)checkCommand.ExecuteScalar();

                    if (existingCount > 0)
                    {
                        MessageBox.Show("Mã thuốc đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO tblSanPham (sMaSP, sTenSP, sMaLoaiSP, fGiaBan, iSoLuong, sHangSX, sNuocSX, sThongTinSP, sCachDung) " +
                                             "VALUES (@sMaSP, @sTenSP, @sMaLoaiSP, @fGiaBan, 0, @sHangSX, @sNuocSX, @sThongTinSP, @sCachDung)" ;
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

                        insertCommand.Parameters.AddWithValue("@sMaSP", txtMaThuoc.Text);
                        insertCommand.Parameters.AddWithValue("@sTenSP", txtTenThuoc.Text);
                        insertCommand.Parameters.AddWithValue("@sMaLoaiSP", ((KeyValuePair<string, string>)cbbLoaiThuoc.SelectedItem).Key);
                        insertCommand.Parameters.AddWithValue("@fGiaBan", decimal.Parse(txtGiaBan.Text));
                        insertCommand.Parameters.AddWithValue("@sHangSX", txtHangSanXuat.Text);
                        insertCommand.Parameters.AddWithValue("@sNuocSX", txtNuocSanXuat.Text);
                        insertCommand.Parameters.AddWithValue("@sThongTinSP", txtThongTin.Text);
                        insertCommand.Parameters.AddWithValue("@sCachDung", txtCachDung.Text);

                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thuốc đã được thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm thuốc vào cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
                DanhSachThuoc_Load(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenThuoc.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenThuoc.Focus();
            }
            else if (txtThongTin.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtThongTin.Focus();
            }
            else if (txtNuocSanXuat.Text == "")
            {
                MessageBox.Show("Vui lòng nhập nước sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNuocSanXuat.Focus();
            }
            else if (txtHangSanXuat.Text == "")
            {
                MessageBox.Show("Vui lòng nhập hãng sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHangSanXuat.Focus();
            }
            else if (txtGiaBan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaBan.Focus();
            }
            else if (txtCachDung.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Cách dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCachDung.Focus();
            }
            else if (!decimal.TryParse(txtGiaBan.Text, out decimal giaBan) || giaBan <= 0)
            {
                MessageBox.Show("Giá bán đang sai định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaBan.Focus();
                txtGiaBan.SelectAll();
            }
            else
            {
                try
                {
                    connection.Open();
                    string updateQuery = "UPDATE tblSanPham " +
                                        "SET sTenSP = @sTenSP, sMaLoaiSP = @sMaLoaiSP, fGiaBan = @fGiaBan, " +
                                        "sHangSX = @sHangSX, sNuocSX = @sNuocSX, sThongTinSP = @sThongTinSP, sCachDung = @sCachDung " +
                                        "WHERE sMaSP = @sMaSP";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);

                    updateCommand.Parameters.AddWithValue("@sMaSP", txtMaThuoc.Text);
                    updateCommand.Parameters.AddWithValue("@sTenSP", txtTenThuoc.Text);
                    updateCommand.Parameters.AddWithValue("@sMaLoaiSP", ((KeyValuePair<string, string>)cbbLoaiThuoc.SelectedItem).Key);
                    updateCommand.Parameters.AddWithValue("@fGiaBan", decimal.Parse(txtGiaBan.Text));
                    updateCommand.Parameters.AddWithValue("@sHangSX", txtHangSanXuat.Text);
                    updateCommand.Parameters.AddWithValue("@sNuocSX", txtNuocSanXuat.Text);
                    updateCommand.Parameters.AddWithValue("@sThongTinSP", txtThongTin.Text);
                    updateCommand.Parameters.AddWithValue("@sCachDung", txtCachDung.Text);

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thông tin thuốc đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin thuốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
                DanhSachThuoc_Load(sender, e); 
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (viewThuoc.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = viewThuoc.SelectedRows[0];
                string selectedMaSP = selectedRow.Cells["sMaSP"].Value.ToString();
                string selectedTenSP = selectedRow.Cells["sTenSP"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa thuốc '{selectedTenSP}' (Mã SP: {selectedMaSP}) không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        string deleteQuery = "DELETE FROM tblSanPham WHERE sMaSP = @sMaSP";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@sMaSP", selectedMaSP);

                        int rowsAffected = deleteCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thuốc đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa thuốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                    DanhSachThuoc_Load(null, null);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thuốc để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try { 
                connection.Open();

                string filterQuery = "SELECT sMaSP , sTenSP, sTenLoaiSP, fGiaBan, sHangSX, sNuocSX, sThongTinSP, sCachDung " +
                                     "FROM tblSanPham inner join tblLoaiSanPham on tblSanPham.sMaLoaiSP = tblLoaiSanPham.sMaLoaiSP " +
                                     "WHERE 1 = 1 ";
                if (!string.IsNullOrEmpty(txtTenThuoc.Text))
                    filterQuery += " AND sTenSP LIKE @filterTenThuoc";
                if (!string.IsNullOrEmpty(txtMaThuoc.Text))
                    filterQuery += " AND sMaSP LIKE @filterMaThuoc";
                if (!string.IsNullOrEmpty(txtThongTin.Text))
                    filterQuery += " AND sThongTinSP LIKE @filterThongTin";
                if (!string.IsNullOrEmpty(txtNuocSanXuat.Text))
                    filterQuery += " AND sNuocSX LIKE @filterNuocSanXuat";
                if (!string.IsNullOrEmpty(txtHangSanXuat.Text))
                    filterQuery += " AND sHangSX LIKE @filterHangSanXuat";
                if (!string.IsNullOrEmpty(txtGiaBan.Text))
                    filterQuery += " AND fGiaBan = @filterGiaBan";
                if (!string.IsNullOrEmpty(txtCachDung.Text))
                    filterQuery += " AND sCachDung LIKE @filterCachDung";

                SqlCommand filterCommand = new SqlCommand(filterQuery, connection);

                if (!string.IsNullOrEmpty(txtTenThuoc.Text))
                    filterCommand.Parameters.AddWithValue("@filterTenThuoc", "%" + txtTenThuoc.Text + "%");
                if (!string.IsNullOrEmpty(txtMaThuoc.Text))
                    filterCommand.Parameters.AddWithValue("@filterMaThuoc", "%" + txtMaThuoc.Text + "%");
                if (!string.IsNullOrEmpty(txtThongTin.Text))
                    filterCommand.Parameters.AddWithValue("@filterThongTin", "%" + txtThongTin.Text + "%");
                if (!string.IsNullOrEmpty(txtNuocSanXuat.Text))
                    filterCommand.Parameters.AddWithValue("@filterNuocSanXuat", "%" + txtNuocSanXuat.Text + "%");
                if (!string.IsNullOrEmpty(txtHangSanXuat.Text))
                    filterCommand.Parameters.AddWithValue("@filterHangSanXuat", "%" + txtHangSanXuat.Text + "%");
                if (!string.IsNullOrEmpty(txtGiaBan.Text))
                    filterCommand.Parameters.AddWithValue("@filterGiaBan", decimal.Parse(txtGiaBan.Text));
                if (!string.IsNullOrEmpty(txtCachDung.Text))
                    filterCommand.Parameters.AddWithValue("@filterCachDung", "%" + txtCachDung.Text + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(filterCommand);
                DataTable filteredTable = new DataTable();
                adapter.Fill(filteredTable);

                viewThuoc.DataSource = filteredTable;
                viewThuoc.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
            btnThem.Enabled = false;
            btnLoc.Enabled  = true;
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
    }
}
