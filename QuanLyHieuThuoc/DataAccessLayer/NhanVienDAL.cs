using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.DataAccessLayer
{
    public class NhanVienDAL
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HieuThuoc"].ConnectionString);

        public DataTable getNhanVien ()
        {   
            DataTable dt = new DataTable();
            try
            {
                connection.Open();

                SqlCommand cmd1 = new SqlCommand("SELECT * FROM tblNhanVien", connection);
                cmd1.CommandType = CommandType.Text;
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                connection.Close();

                DataTable tbl_NhanVien = new DataTable();
                adapter1.Fill(tbl_NhanVien);
                return tbl_NhanVien;
            }
            catch {
                throw;
            }
        }

        public DataTable searchNhanVien (string search)
        {
            try
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM tblNhanVien WHERE sMaNV LIKE @searchText OR sTenNV LIKE @searchText OR sDiaChiNV LIKE @searchText OR sSdtNV LIKE @searchText";
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@searchText", "%" + search + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tbl_NhanVien = new DataTable();
                adapter.Fill(tbl_NhanVien);
                connection.Close();
                return tbl_NhanVien;   
            }
            catch
            {
                throw;
            }
        }

        public bool checkMaNhanVien (string maNV)
        {
            connection.Open();
            string checkQuery = "SELECT COUNT(*) FROM tblNhanVien WHERE sMaNV = @maNV";
            SqlCommand cmd1 = new SqlCommand(checkQuery, connection);
            cmd1.Parameters.AddWithValue("@maNV", maNV);

            int count = (int)cmd1.ExecuteScalar();
            connection.Close();
            if (count > 0) { return true; }
            return false;
        }

        public void insertNhanVien (string maNV, string tenNV, bool gioiTinh, DateTime ngaySinh, string sdt, string diaChi, DateTime ngayVaoLam)
        {
            try
            {
                connection.Open();
                string sqlQuery = "INSERT INTO tblNhanVien (sMaNV, sTenNV, dNgaySinh, bGioiTinhNV, sSdtNV, sDiaChiNV, dNgayVaoLam) " +
                                  "VALUES (@maNV, @tenNV, @ngaySinh, @gioiTinh, @sdt, @diaChi, @ngayVaoLam)";

                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@maNV", maNV);
                cmd.Parameters.AddWithValue("@tenNV", tenNV);
                cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                cmd.Parameters.AddWithValue("@sdt", sdt);
                cmd.Parameters.AddWithValue("@diaChi", diaChi);
                cmd.Parameters.AddWithValue("@ngayVaoLam", ngayVaoLam);

                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch {
                throw;
            }
        }

        public void updateNhanVien (string maNV ,string tenNV, bool gioiTinh, DateTime ngaySinh, string sdt, string diaChi, DateTime ngayVaoLam)
        {
            try
            {
                connection.Open();

                string sqlQuery = "UPDATE tblNhanVien SET sTenNV = @tenNV, dNgaySinh = @ngaySinh, " +
                                  "bGioiTinhNV = @gioiTinh, sSdtNV = @sdt, sDiaChiNV = @diaChi, dNgayVaoLam = @ngayVaoLam " +
                                  "WHERE sMaNV = @maNV";

                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@tenNV", tenNV);
                cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                cmd.Parameters.AddWithValue("@sdt", sdt);
                cmd.Parameters.AddWithValue("@diaChi", diaChi);
                cmd.Parameters.AddWithValue("@ngayVaoLam", ngayVaoLam);
                cmd.Parameters.AddWithValue("@maNV", maNV);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                throw;
            }
        }

        public void deleteNhanVien (string maNV)
        {
            try
            {
                connection.Open();
                string sqlQuery = "DELETE FROM tblNhanVien WHERE sMaNV = @maNV";

                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@maNV", maNV);

                int a = cmd.ExecuteNonQuery();
            }
            catch { throw; }
            finally
            {
                connection.Close();
            }
        }

        public DataTable filterNhanVien (string maNV, string tenNV, string sdt)
        {
            connection.Open();

            string sqlQuery = "SELECT * FROM tblNhanVien WHERE 1 = 1";

            if (!string.IsNullOrEmpty(maNV))
            {
                sqlQuery += " AND sMaNV LIKE @maNV";
            }
            if (!string.IsNullOrEmpty(tenNV))
            {
                sqlQuery += " AND sTenNV LIKE @tenNV";
            }
            if (!string.IsNullOrEmpty(sdt))
            {
                sqlQuery += " AND sSdtNV LIKE @sdt";
            }
            SqlCommand cmd = new SqlCommand(sqlQuery, connection);

            if (!string.IsNullOrEmpty(maNV))
            {
                cmd.Parameters.AddWithValue("@maNV", "%" + maNV + "%");
            }

            if (!string.IsNullOrEmpty(tenNV))
            {
                cmd.Parameters.AddWithValue("@tenNV", "%" + tenNV + "%");
            }

            if (!string.IsNullOrEmpty(sdt))
            {
                cmd.Parameters.AddWithValue("@sdt", "%" + sdt + "%");
            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable tbl_NhanVien = new DataTable();
            adapter.Fill(tbl_NhanVien);
            connection.Close();
            return tbl_NhanVien;
        }
    }
}
