using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuanLyHieuThuoc.DangNhap;

namespace QuanLyHieuThuoc.QuanLy
{
    public partial class DanhSachNhanVien : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HieuThuoc"].ConnectionString);

        private string username;
        private User currentUser;
        string maUserNV;

        BusinessLogicLayer.NhanVienBLL nhanVien = new BusinessLogicLayer.NhanVienBLL();
        public DanhSachNhanVien(User user)
        {
            InitializeComponent();

            currentUser = user;
            username = user.Username;

            try
            {
                BusinessLogicLayer.TaiKhoanBLL manv = new BusinessLogicLayer.TaiKhoanBLL();
                maUserNV = manv.getMaNV(username);
            }
            catch (SqlException ex)
            {
                foreach (SqlError er in ex.Errors)
                {
                    MessageBox.Show("Lỗi :" + er.Message);
                }
            }

            txtNgaySinh.Format = DateTimePickerFormat.Custom;
            txtNgaySinh.CustomFormat = "dd/MM/yyyy";

            txtNgayVaoLam.Format = DateTimePickerFormat.Custom;
            txtNgayVaoLam.CustomFormat = "dd/MM/yyyy";
            // Tắt khả năng phóng to form (full screen)
            this.MaximizeBox = false;

            // Tắt khả năng thay đổi kích thước form bằng cách kéo góc hoặc cạnh
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void DanhSachNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                viewNhanVien.DataSource = nhanVien.getNhanVien();

                foreach (DataGridViewColumn col in viewNhanVien.Columns)
                {
                    switch (col.Name)
                    {
                        case "sMaNV":
                            col.HeaderText = "Mã Nhân Viên";
                            col.Width = 100;
                            break;
                        case "sTenNV":
                            col.HeaderText = "Tên Nhân Viên";
                            col.Width = 100;
                            break;
                        case "dNgaySinh":
                            col.HeaderText = "Ngày Sinh";
                            col.Width = 100;
                            break;
                        case "bGioiTinhNV":
                            col.HeaderText = "Giới Tính";
                            break;
                        case "sSdtNv":
                            col.HeaderText = "Số Điện Thoại";
                            break;
                        case "sDiaChiNV":
                            col.HeaderText = "Địa Chỉ";
                            break;
                        case "dNgayVaoLam":
                            col.HeaderText = "Ngày Vào Làm";
                            break;
                        default:
                            col.HeaderText = col.Name;
                            break;
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
            txtMaNV.Enabled = true;
            viewNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                viewNhanVien.DataSource = nhanVien.searchNhanVien(searchText);

            }
            else
            {
                DanhSachNhanVien_Load(null, null);
            }
        }

        private void viewNhanVien_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            viewNhanVien.ClearSelection();
            txtMaNV.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void viewNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSdt.Clear();
            txtDiaChi.Clear();
            txtMaNV.Enabled = false;

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            if (viewNhanVien.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = viewNhanVien.SelectedRows[0];

                txtMaNV.Text = selectedRow.Cells["sMaNV"].Value.ToString();
                txtTenNV.Text = selectedRow.Cells["sTenNV"].Value.ToString();
                txtNgaySinh.Value = Convert.ToDateTime(selectedRow.Cells["dNgaySinh"].Value);

                if (selectedRow.Cells["bGioiTinhNV"].Value != null)
                {
                    bool gioiTinh = Convert.ToBoolean(selectedRow.Cells["bGioiTinhNV"].Value);
                    if (gioiTinh)
                    {
                        rbNam.Checked = true;
                    }
                    else
                    {
                        rbNu.Checked = true;
                    }
                }

                txtSdt.Text = selectedRow.Cells["sSdtNv"].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells["sDiaChiNV"].Value.ToString();
                txtNgayVaoLam.Value = Convert.ToDateTime(selectedRow.Cells["dNgayVaoLam"].Value);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            DanhSachNhanVien_Load(null, null);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string tenNV = txtTenNV.Text;
            DateTime ngaySinh = txtNgaySinh.Value;
            bool gioiTinh = rbNam.Checked;
            string sdt = txtSdt.Text;
            string diaChi = txtDiaChi.Text;
            DateTime ngayVaoLam = txtNgayVaoLam.Value;

            if (tenNV == "")
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên!");
                txtTenNV.Focus();
                return;
            }
            if (DateTime.Now.Year - ngaySinh.Year < 18)
            {
                MessageBox.Show("Nhân viên chưa đủ 18 tuổi !");
                return;
            }
            if (sdt == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!");
                txtSdt.Focus();
                return;
            }
            if (Regex.IsMatch(sdt, @"^\d{10}$")) { }
            else
            {
                MessageBox.Show("Số điện thoại sai định dạng");
                txtSdt.Focus();
                return;
            }
            if (diaChi == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!");
                txtDiaChi.Focus();
                return;
            }
            if (DateTime.Now < ngayVaoLam)
            {
                MessageBox.Show("Ngày vào làm không được lớn hơn ngày hiện tại !");
                return;
            }
            if (DateTime.Now.Year - ngayVaoLam.Year < 18)
            {
                MessageBox.Show("Nhân viên phải đủ 18 tuổi mới được vào làm !");
                return;
            }
            try
            {
                nhanVien.updateNhanVien(maNV, tenNV, gioiTinh, ngaySinh, sdt, diaChi, ngayVaoLam);
                MessageBox.Show("Sửa thông tin nhân viên thành công!");
                DanhSachNhanVien_Load(null, null);
            }

            catch (SqlException ex)
            {
                foreach (SqlError er in ex.Errors)
                {
                    MessageBox.Show("Lỗi :" + er.Message);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string tenNV = txtTenNV.Text.Trim();
            DateTime ngaySinh = txtNgaySinh.Value;
            bool gioiTinh = rbNam.Checked;
            string sdt = txtSdt.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            DateTime ngayVaoLam = txtNgayVaoLam.Value;

            if (maNV == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!");
                txtMaNV.Focus();
                return;
            }
            if (tenNV == "")
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên!");
                txtTenNV.Focus();
                return;
            }
            if (DateTime.Now.Year - ngaySinh.Year < 18)
            {
                MessageBox.Show("Nhân viên chưa đủ 18 tuổi !");
                return;
            }
            if (sdt == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!");
                txtSdt.Focus();
                return;
            }
            if (Regex.IsMatch(sdt, @"^\d{10}$")) { }
            else
            {
                MessageBox.Show("Số điện thoại sai định dạng");
                txtSdt.Focus();
                return;
            }
            if (diaChi == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!");
                txtDiaChi.Focus();
                return;
            }
            if (DateTime.Now < ngayVaoLam)
            {
                MessageBox.Show("Ngày vào làm không được lớn hơn ngày hiện tại !");
                return;
            }
            if (DateTime.Now.Year - ngayVaoLam.Year < 18)
            {
                MessageBox.Show("Nhân viên phải đủ 18 tuổi mới được vào làm !");
                return;
            }

            try
            {
                bool count = nhanVien.checkMaNV(maNV);
                if (count == true)
                {
                    MessageBox.Show("Mã nhân viên này đã tồn tại!");
                }
                else
                {
                    try
                    {
                        nhanVien.insertNhanVien(maNV, tenNV, gioiTinh, ngaySinh, sdt, diaChi, ngayVaoLam);
                        MessageBox.Show("Thêm nhân viên thành công!");
                        DanhSachNhanVien_Load(null, null);
                    }
                    catch
                    {
                        throw;
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    nhanVien.deleteNhanVien(maNV);
                    MessageBox.Show("Xóa nhân viên thành công!");
                    DanhSachNhanVien_Load(null, null);
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

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string tenNV = txtTenNV.Text.Trim();
            string sdt = txtSdt.Text.Trim();

            try
            {
                viewNhanVien.DataSource = nhanVien.filterNhanVien(maNV, tenNV, sdt);
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
