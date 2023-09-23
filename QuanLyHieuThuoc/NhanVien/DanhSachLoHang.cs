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
    public partial class DanhSachLoHang : Form
    {
        SqlConnection connection = new SqlConnection("data source=DESKTOP-KHO76ED;Initial Catalog=HieuThuoc;Integrated Security=True");

        private string username;
        private User currentUser;
        string maNV;
        public DanhSachLoHang(User user)
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


            txtNgaySX.Format = DateTimePickerFormat.Custom;
            txtNgaySX.CustomFormat = "dd/MM/yyyy";

            txtHanSD.Format = DateTimePickerFormat.Custom;
            txtHanSD.CustomFormat = "dd/MM/yyyy";
        }

        private void DanhSachLoHang_Load(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("SELECT * from tblLoHang", connection);
            cmd1.CommandType = CommandType.Text;
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            connection.Close();
            DataTable tbl_LoHang = new DataTable();
            adapter1.Fill(tbl_LoHang);
            viewLoHang.DataSource = tbl_LoHang;

            foreach (DataGridViewColumn col in viewLoHang.Columns)
            {
                switch (col.Name)
                {
                    case "sMaLo":
                        col.HeaderText = "Mã Lô Hàng";
                        col.Width = 70;
                        break;
                    case "dNgaySanXuat":
                        col.HeaderText = "Ngày Sản xuất";
                        col.Width = 100;
                        break;
                    case "dNgayHetHan":
                        col.HeaderText = "Hạn Sử Dụng";
                        col.Width = 100;
                        break;
                    default:
                        col.HeaderText = col.Name;
                        break;
                }
            }
        }

        private void viewLoHang_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            viewLoHang.ClearSelection();
            btnSua.Enabled= false;
            btnXoa.Enabled= false;  
            btnThem.Enabled= true;
            txtMaLo.Enabled= true;
        }

        private void viewLoHang_SelectionChanged(object sender, EventArgs e)
        {
            txtMaLo.Clear();

            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtMaLo.Enabled = false;
            if (viewLoHang.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = viewLoHang.SelectedRows[0];
                txtMaLo.Text = selectedRow.Cells["sMaLo"].Value.ToString();

                txtNgaySX.Value = (DateTime)selectedRow.Cells["dNgaySanXuat"].Value;
                txtHanSD.Value = (DateTime)selectedRow.Cells["dNgayHetHan"].Value;

                connection.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT tblSanPham.sMaSP,sTenSP, fGiaBan, sHangSX, sNuocSX, sThongTinSP, sCachDung " +
                    " from tblSanPham inner join tblLoSanPham on tblSanPham.sMaSP = tblLoSanPham.sMaSP" +
                    " where sMaLo = @maLo", connection);
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.AddWithValue("@maLo", txtMaLo.Text);

                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                connection.Close();

                DataTable tbl_Thuoc = new DataTable();
                adapter1.Fill(tbl_Thuoc);
                viewThuoc.DataSource = tbl_Thuoc;

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
                viewThuoc.ClearSelection();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            DanhSachLoHang_Load(null, null);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maLo = txtMaLo.Text;
            DateTime ngaySanXuat = txtNgaySX.Value;
            DateTime hanSuDung = txtHanSD.Value;

            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblLoHang WHERE sMaLo = @maLo", connection);
            cmd.Parameters.AddWithValue("@maLo", maLo);
            int count = (int)cmd.ExecuteScalar();
            connection.Close();

            if (count > 0)
            {
                MessageBox.Show("Mã này đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (hanSuDung <= ngaySanXuat)
            {
                MessageBox.Show("Ngày hết hạn phải sau ngày sản xuất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("INSERT INTO tblLoHang (sMaLo, dNgaySanXuat, dNgayHetHan) VALUES (@maLo, @ngaySanXuat, @hanSuDung)", connection);
                cmd1.Parameters.AddWithValue("@maLo", maLo);
                cmd1.Parameters.AddWithValue("@ngaySanXuat", ngaySanXuat);
                cmd1.Parameters.AddWithValue("@hanSuDung", hanSuDung);
                int rowsAffected = cmd1.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thêm lô hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể thêm lô hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();

            txtMaLo.Clear();
            txtNgaySX.Value = DateTime.Now; 
            txtHanSD.Value = DateTime.Now;  

            DanhSachLoHang_Load(null, null);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maLo = txtMaLo.Text;
            DateTime ngaySanXuatMoi = txtNgaySX.Value;
            DateTime hanSuDungMoi = txtHanSD.Value;

            if (hanSuDungMoi <= ngaySanXuatMoi)
            {
                MessageBox.Show("Ngày hết hạn phải sau ngày sản xuất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE tblLoHang SET dNgaySanXuat = @ngaySanXuatMoi, dNgayHetHan = @hanSuDungMoi WHERE sMaLo = @maLo", connection);
                cmd.Parameters.AddWithValue("@maLo", maLo);
                cmd.Parameters.AddWithValue("@ngaySanXuatMoi", ngaySanXuatMoi);
                cmd.Parameters.AddWithValue("@hanSuDungMoi", hanSuDungMoi);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật thông tin lô hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật thông tin lô hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            DanhSachLoHang_Load(null, null);
            txtNgaySX.Value = DateTime.Now;
            txtHanSD.Value = DateTime.Now;
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (viewLoHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lô hàng cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa lô hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = viewLoHang.SelectedRows[0];
                string maLo = selectedRow.Cells["sMaLo"].Value.ToString();

                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblLoHang WHERE sMaLo = @maLo", connection);
                    cmd.Parameters.AddWithValue("@maLo", maLo);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa lô hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa lô hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mã Lô Này Đang Còn Thuốc", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }

                DanhSachLoHang_Load(null, null);
                txtNgaySX.Value = DateTime.Now;
                txtHanSD.Value = DateTime.Now;
                
            }
        }
    }
}
