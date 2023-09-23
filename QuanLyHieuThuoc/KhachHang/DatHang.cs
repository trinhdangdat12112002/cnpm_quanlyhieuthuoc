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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyHieuThuoc.KhachHang
{
    public partial class DatHang : Form
    {
        SqlConnection connection = new SqlConnection("data source=DESKTOP-KHO76ED;Initial Catalog=HieuThuoc;Integrated Security=True");

        private string username;
        private User currentUser;
        int maKH;


        public DatHang(User user)
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

            lbDiaChi.Text = d.Rows[0]["sDiaChiKH"].ToString();
            lbSdt.Text = d.Rows[0]["sSdtKH"].ToString();
        }

        private void DatHang_Load(object sender, EventArgs e)
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

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btnThemDat_Click(object sender, EventArgs e)
        {
            float TongTien = 0;
            if (txtSoLuonDat.Text == "" )
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                if (dem == 0)
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
                }
                else
                {
                    MessageBox.Show("Mã này đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            if (viewChiTietDat.RowCount > 0)
            {

                SqlCommand cmd3 = new SqlCommand("themDonDat", connection);
                cmd3.CommandType = CommandType.StoredProcedure;

                cmd3.Parameters.AddWithValue("@maKH", maKH);

                DateTime currentDate = DateTime.Now;
                SqlParameter paramCurrentDate = new SqlParameter("@ngayDat", SqlDbType.DateTime);
                paramCurrentDate.Value = currentDate;
                cmd3.Parameters.Add(paramCurrentDate);

                cmd3.Parameters.AddWithValue("@ghiChu", "Chưa có ghi chú");
                cmd3.Parameters.AddWithValue("@trangThai", "Chưa xác nhận");

                connection.Open();

                int maHoaDon = Convert.ToInt32(cmd3.ExecuteScalar());
                connection.Close();


                for (int i = 0; i < viewChiTietDat.Rows.Count; i++)
                {
                    DataGridViewRow row = viewChiTietDat.Rows[i];
                    string maSP = row.Cells[0].Value.ToString();
                    string maLo = row.Cells[3].Value.ToString();
                    int soLuong = Convert.ToInt32 (row.Cells[4].Value.ToString());

                    SqlCommand cmd2 = new SqlCommand("themChiTietDat", connection);
                    cmd2.CommandType = CommandType.StoredProcedure;

                    cmd2.Parameters.AddWithValue("@maDonDat", maHoaDon);
                    cmd2.Parameters.AddWithValue("@maSP", maSP);
                    cmd2.Parameters.AddWithValue("@maLo", maLo);
                    cmd2.Parameters.AddWithValue("@soLuong", soLuong);

                    connection.Open();
                    cmd2.ExecuteNonQuery();
                    connection.Close();
                    
                }

                MessageBox.Show("Thêm phiếu nhận thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Hóa đơn đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
