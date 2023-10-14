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
    internal class LoHangDAL
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HieuThuoc"].ConnectionString);

        public DataTable getLoHang()
        {
            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT * from tblLoHang", connection);
                cmd1.CommandType = CommandType.Text;
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                DataTable tbl_LoHang = new DataTable();
                adapter1.Fill(tbl_LoHang);
                return tbl_LoHang;
            }
            catch { throw; }
            finally {connection.Close(); } 
        }

        public DataTable getSanPhamByLoHang(string maLo)
        {
            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT tblSanPham.sMaSP,sTenSP, fGiaBan, sHangSX, sNuocSX, sThongTinSP, sCachDung " +
                    " from tblSanPham inner join tblLoSanPham on tblSanPham.sMaSP = tblLoSanPham.sMaSP" +
                    " where sMaLo = @maLo", connection);
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.AddWithValue("@maLo", maLo);

                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                connection.Close();

                DataTable tbl_Thuoc = new DataTable();
                adapter1.Fill(tbl_Thuoc);
                return tbl_Thuoc;
            }
            catch { throw; }
            finally { connection.Close(); }
        }

        public int checkMaLo(string maLo)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblLoHang WHERE sMaLo = @maLo", connection);
                cmd.Parameters.AddWithValue("@maLo", maLo);
                int count = (int)cmd.ExecuteScalar();
                connection.Close(); return count;
            }
            catch { throw; }    
        }

        public int insertLoHang (string maLo, DateTime ngaySanXuat ,DateTime hanSuDung)
        {
            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("INSERT INTO tblLoHang (sMaLo, dNgaySanXuat, dNgayHetHan) VALUES (@maLo, @ngaySanXuat, @hanSuDung)", connection);
                cmd1.Parameters.AddWithValue("@maLo", maLo);
                cmd1.Parameters.AddWithValue("@ngaySanXuat", ngaySanXuat);
                cmd1.Parameters.AddWithValue("@hanSuDung", hanSuDung);
                int rowsAffected = cmd1.ExecuteNonQuery();
                return rowsAffected;
            }
            catch { throw; }
            finally { connection.Close(); }
        }

        public int updateLoHang(string maLo, DateTime ngaySanXuat, DateTime hanSuDung)
        {
            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("UPDATE tblLoHang SET dNgaySanXuat = @ngaySanXuatMoi, dNgayHetHan = @hanSuDungMoi WHERE sMaLo = @maLo", connection);
                cmd1.Parameters.AddWithValue("@maLo", maLo);
                cmd1.Parameters.AddWithValue("@ngaySanXuat", ngaySanXuat);
                cmd1.Parameters.AddWithValue("@hanSuDung", hanSuDung);
                int rowsAffected = cmd1.ExecuteNonQuery();
                return rowsAffected;
            }
            catch { throw; }
            finally { connection.Close(); }
        }

        public int deleteLoHang (string maLo)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM tblLoHang WHERE sMaLo = @maLo", connection);
                cmd.Parameters.AddWithValue("@maLo", maLo);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
            catch { throw; }
            finally { connection.Close(); }
        }
    }
}
