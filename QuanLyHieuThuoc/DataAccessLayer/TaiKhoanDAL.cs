using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHieuThuoc.DataAccessLayer
{
    public class TaiKhoanDAL
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HieuThuoc"].ConnectionString);

        public DataTable dangNhap (string username, string password)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DangNhapNV", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tenTaiKhoanNV", username);
                cmd.Parameters.AddWithValue("@matKhauNV", password);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                connection.Close();
                DataTable dt = new DataTable();

                da.Fill(dt);
                return dt;
            }
            catch 
            {
                throw ;
            }
        }

        public DataTable getTaiKhoan ()
        {
            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT tblTaiKhoan.sMaNV, sTenNV , sTenTaiKhoanNV, sMatKhauNV , sQuyen " +
                    " FROM tblTaiKhoan inner join tblNhanVien on tblTaiKhoan.sMaNV = tblNhanVien.sMaNV", connection);
                cmd1.CommandType = CommandType.Text;
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                connection.Close();

                DataTable dt = new DataTable();
                adapter1.Fill(dt);
                return dt;
            }
            catch { throw; }
        }

        public int check_NV_TK (string maNV) 
        {
            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM tblTaiKhoan WHERE sMaNV = @maNV", connection);
                cmd1.Parameters.AddWithValue("@maNV", maNV);

                int count = (int)cmd1.ExecuteScalar();
                connection.Close(); return count;
            }
            catch { throw; }
        }

        public int checkTaiKhoan (string tenDangNhap)
        {
            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM tblTaiKhoan WHERE sTenTaiKhoanNV = @tenDN", connection);
                cmd1.Parameters.AddWithValue("@tenDN", tenDangNhap);

                int count = (int)cmd1.ExecuteScalar();
                connection.Close();
                if (count > 0) return 1; else return 0;
            }
            catch { throw; }
        }

        public int insertTaiKhoan (string tenTaiKhoan, string matKhau, string quyen, string maNV)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tblTaiKhoan (sTenTaiKhoanNV, sMatKhauNV, sQuyen, sMaNV) VALUES (@tenTaiKhoan, @matKhau, @quyen, @maNV)", connection);
                cmd.Parameters.AddWithValue("@tenTaiKhoan", tenTaiKhoan);
                cmd.Parameters.AddWithValue("@matKhau", matKhau);
                cmd.Parameters.AddWithValue("@quyen", quyen);
                cmd.Parameters.AddWithValue("@maNV", maNV);

                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();
                if (rowsAffected > 0) return 1; else return 0;
            }
            catch { throw; };
        }

        public int updateTaiKhoan (string tenTaiKhoan, string matKhau, string quyen, string maNV)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE tblTaiKhoan SET sTenTaiKhoanNV = @tenTaiKhoan, sMatKhauNV = @matKhau, sQuyen = @quyen WHERE sMaNV = @maNV", connection);
                cmd.Parameters.AddWithValue("@tenTaiKhoan", tenTaiKhoan);
                cmd.Parameters.AddWithValue("@matKhau", matKhau);
                cmd.Parameters.AddWithValue("@quyen", quyen);
                cmd.Parameters.AddWithValue("@maNV", maNV);

                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();
                if (rowsAffected > 0) { return 1; } else return 0;
            }
            catch { throw; }
        }

        public int deleteTaiKhoan (string maNV)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM tblTaiKhoan WHERE sMaNV = @maNV", connection);
                cmd.Parameters.AddWithValue("@maNV", maNV);

                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();
                if (rowsAffected > 0) { return 1; } else return 0;
            }
            catch { throw; }
        }
    }
}
