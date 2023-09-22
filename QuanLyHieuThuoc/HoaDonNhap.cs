using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyHieuThuoc
{
    public partial class HoaDonNhap : Form
    {
        SqlConnection connection = new SqlConnection("data source=DESKTOP-KHO76ED;Initial Catalog=QuanLyHieuThuoc;Integrated Security=True");

        public HoaDonNhap()
        {
            InitializeComponent();
        }

        private void viewThuoc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            viewThuoc.ClearSelection();
        }

        private void HoaDonNhap_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("sp_getThuoc", connection);
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
                    case "maDuocPham":
                        col.HeaderText = "Mã Thuốc";
                        col.Width = 100;
                        break;
                    case "tenDuocPham":
                        col.HeaderText = "Tên Thuốc";
                        col.Width = 200;
                        break;
                    case "tenLoaiThuoc":
                        col.HeaderText = "Tên Loại Thuốc";
                        col.Width = 200;
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
            SqlCommand cmdNhaCungCap = new SqlCommand("SELECT maNhaCungCap, tenNhaCungCap FROM NHA_CUNG_CAP", connection);
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

            DateTime ngayHienTai = DateTime.Now;
            txtNgayNhap.Text = ngayHienTai.ToString("dd-MM-yyyy");
            txtNgayNhap.ReadOnly = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("sp_SearchThuoc", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@kyTu", txtSearch.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            connection.Close();

            DataTable table = new DataTable();
            adapter.Fill(table);

            viewThuoc.DataSource = table;
        }

        private float TongTien = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtGiaNhap.Text == "" || txtSoLuongNhap.Text == "" )
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int dem =0;
                for (int i = 0; i < viewChiTiet.Rows.Count; i++)
                {
                    DataGridViewRow row = viewChiTiet.Rows[i];
                    string ma_from_chitiet = row.Cells[0].Value.ToString();

                    DataGridViewRow selectedRow = viewThuoc.SelectedRows[0];
                    string ma_from_thuoc = selectedRow.Cells["maDuocPham"].Value.ToString();

                    if (ma_from_chitiet == ma_from_thuoc)
                    {
                        dem++;
                    }
                }

                if (dem == 0 )
                {
                    
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(viewChiTiet);
                    DataGridViewRow selectedRow = viewThuoc.SelectedRows[0];
                    row.Cells[0].Value = selectedRow.Cells["maDuocPham"].Value.ToString();
                    row.Cells[1].Value = selectedRow.Cells["tenDuocPham"].Value.ToString();
                    row.Cells[2].Value = txtSoLuongNhap.Text;
                    row.Cells[3].Value = txtGiaNhap.Text;
                    viewChiTiet.Rows.Add(row);

                    TongTien += float.Parse(txtGiaNhap.Text) * int.Parse(txtSoLuongNhap.Text);
                    lbTongTien.Text = TongTien.ToString();

                    viewChiTiet.ClearSelection();

                }
                else
                {
                    MessageBox.Show("Mã này đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void viewThuoc_SelectionChanged(object sender, EventArgs e)
        {
            txtGiaNhap.Enabled = true;
            txtSoLuongNhap.Enabled = true;
            btnThem.Enabled = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

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
    }
}
