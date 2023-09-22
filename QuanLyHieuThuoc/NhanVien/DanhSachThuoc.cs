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

namespace QuanLyHieuThuoc.NhanVien
{
    public partial class DanhSachThuoc : Form
    {
        SqlConnection connection = new SqlConnection("data source=DESKTOP-KHO76ED;Initial Catalog=HieuThuoc;Integrated Security=True");

        private string username;
        private User currentUser;
        int maNV;
        public DanhSachThuoc()
        {
            InitializeComponent();
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
            //ccb Loại thuốc
            
            txtThongTin.Clear();
            txtNuocSanXuat.Clear();
            txtHangSanXuat.Clear();
            txtGiaBan.Clear();
            txtCachDung.Clear();
            if (viewThuoc.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = viewThuoc.SelectedRows[0];
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
    }
}
