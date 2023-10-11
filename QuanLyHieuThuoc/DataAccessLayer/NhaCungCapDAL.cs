using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.DataAccessLayer
{
    public class NhaCungCapDAL
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HieuThuoc"].ConnectionString);

        public DataTable getNhaCungCap()
        {
            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM tblNhaCungCap", connection);
                cmd1.CommandType = CommandType.Text;
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                connection.Close();

                DataTable tbl_LoaiThuoc = new DataTable();
                adapter1.Fill(tbl_LoaiThuoc);
                return tbl_LoaiThuoc;
            }
            catch { throw; }
        }

        public int checkNCC (string maNCC)
        {
            int check = 0;
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblNhaCungCap where sMaNCC = @maNCC", connection);
            cmd.Parameters.AddWithValue("@maNCC", maNCC);
            check = (int)cmd.ExecuteScalar();
            connection.Close();
            return check;
        }

        public void insertNCC (string maNCC, string tenNCC, string diaChi, string sdt)
        {
            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("INSERT INTO tblNhaCungCap " +
                    " Values (@maNCC , @tenNCC, @diaChi, @sdt)", connection);
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.AddWithValue("@maNCC", maNCC);
                cmd1.Parameters.AddWithValue("@tenNCC", tenNCC);
                cmd1.Parameters.AddWithValue("@diaChi", diaChi);
                cmd1.Parameters.AddWithValue("@sdt", sdt);
                cmd1.ExecuteNonQuery();
                connection.Close();
            }
            catch { throw; }
        }

        public void updateNCC (string maNCC, string tenNCC, string diaChi, string sdt)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE tblNhaCungCap SET sTenNCC = @tenNCC, sDiaChiNCC = @diaChi, sSdtNCC = @sdt WHERE sMaNCC = @maNCC", connection);
                cmd.Parameters.AddWithValue("@tenNCC", tenNCC);
                cmd.Parameters.AddWithValue("@diaChi", diaChi);
                cmd.Parameters.AddWithValue("@sdt", sdt);
                cmd.Parameters.AddWithValue("@maNCC", maNCC);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch { throw; }
        }

        public void deleteNCC (string maNCC)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM tblNhaCungCap WHERE sMaNCC = @maNCC", connection);
                cmd.Parameters.AddWithValue("@maNCC", maNCC);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch { throw; }
        }

        public DataTable searchNCC (string search)
        {
            try
            {
                connection.Open();
                string sqlQuery = "SELECT * FROM tblNhaCungCap WHERE sMaNCC LIKE @searchText OR sTenNCC LIKE @searchText OR sDiaChiNCC LIKE @searchText OR sSdtNCC LIKE @searchText";
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@searchText", "%" + search + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tbl_LoaiThuoc = new DataTable();
                adapter.Fill(tbl_LoaiThuoc);
                return tbl_LoaiThuoc;
            }
            catch { throw; }
            finally { connection.Close(); }
        }
    }
}
