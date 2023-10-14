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
    internal class LoaiSanPhamDAL
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HieuThuoc"].ConnectionString);

        public DataTable getLoaiSP ()
        {
            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT sMaLoaiSP , sTenLoaiSP from tblLoaiSanPham", connection);
                cmd1.CommandType = CommandType.Text;
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                DataTable tbl_LoaiThuoc = new DataTable();
                adapter1.Fill(tbl_LoaiThuoc);
                return tbl_LoaiThuoc;
            }
            catch { throw; }
            finally { connection.Close(); }
        }

        public DataTable searchLoaiSP(string search)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * from tblLoaiSanPham " +
                    "where sMaLoaiSP like '%' + @kyTu + '%' or sTenLoaiSP like '%' + @kyTu + '%'", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@kyTu", search);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch { throw; }
            finally { connection.Close(); }
        }

        public DataTable getSanPham (string maLoai)
        {
            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT sMaSP,sTenSP, fGiaBan, sHangSX, sNuocSX, sThongTinSP, sCachDung " +
                    " from tblSanPham " +
                    " where sMaLoaiSP = @maLoaiSP", connection);
                cmd1.CommandType = CommandType.Text;

                cmd1.Parameters.AddWithValue("@maLoaiSP", maLoai);

                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);

                DataTable tbl_Thuoc = new DataTable();
                adapter1.Fill(tbl_Thuoc);
                return tbl_Thuoc;
            }
            catch { throw; }
            finally { connection.Close(); }
        }

        public int insertLoaiSP(string maLoai, string tenLoai)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tblLoaiSanPham (sMaLoaiSP , sTenLoaiSP) VALUES (@maloaiSP, @tenLoaiThuoc)", connection);
                cmd.Parameters.AddWithValue("@tenLoaiThuoc", tenLoai);
                cmd.Parameters.AddWithValue("@maloaiSP", maLoai);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0) return 1; else return 0; 
            }
            catch { throw; }
            finally { connection.Close(); }
        }

        public int updateLoaiSP (string maLoai, string tenLoai)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE tblLoaiSanPham " +
                    "SET sTenLoaiSP = @tenLoaiThuoc " +
                    "WHERE sMaLoaiSP = @maLoaiThuoc", connection);
                cmd.Parameters.AddWithValue("@tenLoaiThuoc", tenLoai);
                cmd.Parameters.AddWithValue("@maLoaiThuoc", maLoai);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0) return 1; else return 0;
            }
            catch { throw; }
            finally { connection.Close(); }
        }

        public int deleteLoaiSP (string maLoai)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM tblLoaiSanPham WHERE sMaLoaiSP = @maLoaiThuoc", connection);
                cmd.Parameters.AddWithValue("@maLoaiThuoc", maLoai);
                
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0) return 1; else return 0;    
            }
            catch { throw; }
            finally { connection.Close(); }
        }

        public DataTable getSanPhamByLoai(string maLoai)
        {
            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT sMaSP,sTenSP, fGiaBan, sHangSX, sNuocSX, sThongTinSP, sCachDung " +
                    " from tblSanPham " +
                    " where sMaLoaiSP = @maLoaiSP", connection);
                cmd1.CommandType = CommandType.Text;

                cmd1.Parameters.AddWithValue("@maLoaiSP", maLoai);

                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                connection.Close();

                DataTable tbl_Thuoc = new DataTable();
                adapter1.Fill(tbl_Thuoc);
                return tbl_Thuoc;
            }
            catch { throw; }
        }
    }
}
