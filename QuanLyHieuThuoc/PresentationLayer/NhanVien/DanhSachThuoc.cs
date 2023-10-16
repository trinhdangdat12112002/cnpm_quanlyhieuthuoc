using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections;
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
    public partial class DanhSachThuoc : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HieuThuoc"].ConnectionString);

        private string username;
        private User currentUser;
        string maNV;

        BusinessLogicLayer.SanPhamBLL sp = new BusinessLogicLayer.SanPhamBLL();
        public DanhSachThuoc(User user)
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
            try
            {
                viewThuoc.DataSource = sp.getSanPham();
            }
            catch (SqlException ex)
            {
                foreach (SqlError er in ex.Errors)
                {
                    MessageBox.Show("Lỗi :" + er.Message);
                }
            }

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
            viewThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            else if (!float.TryParse(txtGiaBan.Text, out float giaBan) || giaBan <= 0)
            {
                MessageBox.Show("Giá bán đang sai định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaBan.Focus();
                txtGiaBan.SelectAll();
            }
            else
            {
                try
                {
                    string maSP = txtMaThuoc.Text;
                    string tenSP = txtTenThuoc.Text;
                    string sMaLoai = ((KeyValuePair<string, string>)cbbLoaiThuoc.SelectedItem).Key;

                    string hangSX = txtHangSanXuat.Text;
                    string nuocSX = txtNuocSanXuat.Text;
                    string thongTin = txtThongTin.Text;
                    string cachDung = txtCachDung.Text;

                    if (sp.checkMaSP(txtMaThuoc.Text) > 0)
                    {
                        MessageBox.Show("Mã thuốc đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        if (sp.insertSanPham(maSP, tenSP, sMaLoai, giaBan, hangSX, nuocSX, thongTin, cachDung) > 0)
                        {
                            MessageBox.Show("Thuốc đã được thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DanhSachThuoc_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm thuốc vào cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    foreach (SqlError er in ex.Errors)
                    {
                        MessageBox.Show("Lỗi :" + er.Message);
                    }
                }
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
            else if (!float.TryParse(txtGiaBan.Text, out float giaBan) || giaBan <= 0)
            {
                MessageBox.Show("Giá bán đang sai định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaBan.Focus();
                txtGiaBan.SelectAll();
            }
            else
            {
                try
                {
                    string maSP = txtMaThuoc.Text;
                    string tenSP = txtTenThuoc.Text;
                    string sMaLoai = ((KeyValuePair<string, string>)cbbLoaiThuoc.SelectedItem).Key;

                    string hangSX = txtHangSanXuat.Text;
                    string nuocSX = txtNuocSanXuat.Text;
                    string thongTin = txtThongTin.Text;
                    string cachDung = txtCachDung.Text;

                    if (sp.updateSanPham(maSP, tenSP, sMaLoai, giaBan, hangSX, nuocSX, thongTin, cachDung) > 0)
                    {
                        MessageBox.Show("Thông tin thuốc đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DanhSachThuoc_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin thuốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    foreach (SqlError er in ex.Errors)
                    {
                        MessageBox.Show("Lỗi :" + er.Message);
                    }
                }
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

                        if (sp.deleteSanPham(selectedMaSP) > 0)
                        {
                            MessageBox.Show("Thuốc đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DanhSachThuoc_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa thuốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException ex)
                    {
                        foreach (SqlError er in ex.Errors)
                        {
                            MessageBox.Show("Lỗi :" + er.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thuốc để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string maSP = txtMaThuoc.Text;
            string tenSP = txtTenThuoc.Text;
            string giaBan = txtGiaBan.Text;
            string hangSX = txtHangSanXuat.Text;
            string nuocSX = txtNuocSanXuat.Text;
            string thongTin = txtThongTin.Text;
            string cachDung = txtCachDung.Text;

            try { 
                viewThuoc.DataSource = sp.filterSanPham(maSP, tenSP, giaBan, hangSX, nuocSX, thongTin, cachDung);
                viewThuoc.ClearSelection();
            }
            catch (SqlException ex)
            {
                foreach (SqlError er in ex.Errors)
                {
                    MessageBox.Show("Lỗi :" + er.Message);
                }
            }
            btnThem.Enabled = false;
            btnLoc.Enabled  = true;
            btnBoQua.Enabled = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                viewThuoc.DataSource = sp.searchSanPham(txtSearch.Text);
            }
            catch (SqlException ex)
            {
                foreach (SqlError er in ex.Errors)
                {
                    MessageBox.Show("Lỗi :" + er.Message);
                }
            }
        }
    }
}
