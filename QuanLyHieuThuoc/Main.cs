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

namespace QuanLyHieuThuoc
{
    public partial class Main : Form
    {
        SqlConnection connection = new SqlConnection("data source=DESKTOP-KHO76ED;Initial Catalog=QuanLyHieuThuoc;Integrated Security=True");
        private User currentUser;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            hienLoaiThuoc();
            

            /*label2.Text = currentUser.Username;*/
        }

        void hienLoaiThuoc()
        {
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("sp_getLoaiThuoc", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            connection.Close();

            DataTable tbl_LoaiThuoc = new DataTable();
            adapter1.Fill(tbl_LoaiThuoc);
            viewLoaiThuoc.DataSource = tbl_LoaiThuoc;

            foreach (DataGridViewColumn col in viewLoaiThuoc.Columns)
            {
                switch (col.Name)
                {
                    case "maLoaiThuoc":
                        col.HeaderText = "Mã Loại Thuốc";
                        break;
                    case "tenLoaiThuoc":
                        col.HeaderText = "Tên Loại Thuốc";
                        col.Width = 300;
                        break;
                    default:
                        col.HeaderText = col.Name;
                        break;
                }
            }

        }

        private void viewLoaiThuoc_SelectionChanged(object sender, EventArgs e)
        {
            txtMaLoaiThuoc.Clear();
            txtTenLoaiThuoc.Clear();
            if (viewLoaiThuoc.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = viewLoaiThuoc.SelectedRows[0];
                txtMaLoaiThuoc.Text = selectedRow.Cells["maLoaiThuoc"].Value.ToString();
                txtTenLoaiThuoc.Text = selectedRow.Cells["tenLoaiThuoc"].Value.ToString();
                }
            }

        private void viewLoaiThuoc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            viewLoaiThuoc.ClearSelection();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("sp_SearchLoaiThuoc", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@kyTu", txtSearch.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            connection.Close();

            DataTable table = new DataTable();
            adapter.Fill(table);

            viewLoaiThuoc.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewLoaiThuoc.ClearSelection();
        }

        private void viewLoaiThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
