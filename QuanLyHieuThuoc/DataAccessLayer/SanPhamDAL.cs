using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.DataAccessLayer
{
    public class SanPhamDAL
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HieuThuoc"].ConnectionString);
            
        public DataTable getSanPham()
        {
            try
            {
                connection.Open();
                SqlCommand cmd1 = new SqlCommand("getAllSanPham", connection);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                DataTable tbl_LoaiThuoc = new DataTable();
                adapter1.Fill(tbl_LoaiThuoc);
                return tbl_LoaiThuoc;
            }
            catch { throw; }
            finally { connection.Close(); }
        }

        public int checkMaSP(string maSP)
        {
            try
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM tblSanPham WHERE sMaSP = @sMaSP";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@sMaSP", maSP);

                int existingCount = (int)checkCommand.ExecuteScalar();
                return existingCount;
            }
            catch { return -1; throw; }
            finally { connection.Close(); }
        }

        public int insertSanPham (string maSP, string tenSP, string sMaLoai, float giaBan, string hangSX, string nuocSX, string thongTin, string cachDung)
        {
            try
            {
                connection.Open();
                string insertQuery = "INSERT INTO tblSanPham (sMaSP, sTenSP, sMaLoaiSP, fGiaBan, iSoLuong, sHangSX, sNuocSX, sThongTinSP, sCachDung) " +
                                             "VALUES (@sMaSP, @sTenSP, @sMaLoaiSP, @fGiaBan, 0, @sHangSX, @sNuocSX, @sThongTinSP, @sCachDung)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

                insertCommand.Parameters.AddWithValue("@sMaSP", maSP);
                insertCommand.Parameters.AddWithValue("@sTenSP", tenSP);
                insertCommand.Parameters.AddWithValue("@sMaLoaiSP", sMaLoai);
                insertCommand.Parameters.AddWithValue("@fGiaBan", giaBan);
                insertCommand.Parameters.AddWithValue("@sHangSX", hangSX);
                insertCommand.Parameters.AddWithValue("@sNuocSX", nuocSX);
                insertCommand.Parameters.AddWithValue("@sThongTinSP", thongTin);
                insertCommand.Parameters.AddWithValue("@sCachDung", cachDung);

                int rowsAffected = insertCommand.ExecuteNonQuery();
                return rowsAffected;
            }
            catch { return -1;  throw; }
            finally { connection.Close(); }
        }

        public int updateSanPham(string maSP, string tenSP, string sMaLoai, float giaBan, string hangSX, string nuocSX, string thongTin, string cachDung)
        {
            try
            {
                connection.Open();
                string updateQuery = "UPDATE tblSanPham " +
                                    "SET sTenSP = @sTenSP, sMaLoaiSP = @sMaLoaiSP, fGiaBan = @fGiaBan, " +
                                    "sHangSX = @sHangSX, sNuocSX = @sNuocSX, sThongTinSP = @sThongTinSP, sCachDung = @sCachDung " +
                                    "WHERE sMaSP = @sMaSP";
                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);

                updateCommand.Parameters.AddWithValue("@sMaSP", maSP);
                updateCommand.Parameters.AddWithValue("@sTenSP", tenSP);
                updateCommand.Parameters.AddWithValue("@sMaLoaiSP", sMaLoai);
                updateCommand.Parameters.AddWithValue("@fGiaBan", giaBan);
                updateCommand.Parameters.AddWithValue("@sHangSX", hangSX);
                updateCommand.Parameters.AddWithValue("@sNuocSX", nuocSX);
                updateCommand.Parameters.AddWithValue("@sThongTinSP", thongTin);
                updateCommand.Parameters.AddWithValue("@sCachDung", cachDung);

                int rowsAffected = updateCommand.ExecuteNonQuery();
                return rowsAffected;
            }
            catch { throw; }
            finally { connection.Close(); }
        }

        public int deleteSanPham (string selectedMaSP)
        {
            try
            {
                connection.Open();
                string deleteQuery = "DELETE FROM tblSanPham WHERE sMaSP = @sMaSP";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@sMaSP", selectedMaSP);

                int rowsAffected = deleteCommand.ExecuteNonQuery();
                return rowsAffected;
            }
            catch { throw; }
            finally { connection.Close(); }
        }

        public DataTable filterSanPham (string maSP, string tenSP, string giaBan, string hangSX, string nuocSX, string thongTin, string cachDung)
        {
            try
            {
                connection.Open();

                string filterQuery = "SELECT sMaSP , sTenSP, sTenLoaiSP, fGiaBan, sHangSX, sNuocSX, sThongTinSP, sCachDung " +
                                     "FROM tblSanPham inner join tblLoaiSanPham on tblSanPham.sMaLoaiSP = tblLoaiSanPham.sMaLoaiSP " +
                                     "WHERE 1 = 1 ";
                if (!string.IsNullOrEmpty(tenSP))
                    filterQuery += " AND sTenSP LIKE @filterTenThuoc";
                if (!string.IsNullOrEmpty(maSP))
                    filterQuery += " AND sMaSP LIKE @filterMaThuoc";
                if (!string.IsNullOrEmpty(thongTin))
                    filterQuery += " AND sThongTinSP LIKE @filterThongTin";
                if (!string.IsNullOrEmpty(nuocSX))
                    filterQuery += " AND sNuocSX LIKE @filterNuocSanXuat";
                if (!string.IsNullOrEmpty(hangSX))
                    filterQuery += " AND sHangSX LIKE @filterHangSanXuat";
                if (!string.IsNullOrEmpty(giaBan))
                    filterQuery += " AND fGiaBan = @filterGiaBan";
                if (!string.IsNullOrEmpty(cachDung))
                    filterQuery += " AND sCachDung LIKE @filterCachDung";

                SqlCommand filterCommand = new SqlCommand(filterQuery, connection);

                if (!string.IsNullOrEmpty(tenSP))
                    filterCommand.Parameters.AddWithValue("@filterTenThuoc", "%" + tenSP + "%");
                if (!string.IsNullOrEmpty(maSP))
                    filterCommand.Parameters.AddWithValue("@filterMaThuoc", "%" + maSP + "%");
                if (!string.IsNullOrEmpty(thongTin))
                    filterCommand.Parameters.AddWithValue("@filterThongTin", "%" + thongTin + "%");
                if (!string.IsNullOrEmpty(nuocSX))
                    filterCommand.Parameters.AddWithValue("@filterNuocSanXuat", "%" + nuocSX + "%");
                if (!string.IsNullOrEmpty(hangSX))
                    filterCommand.Parameters.AddWithValue("@filterHangSanXuat", "%" + hangSX + "%");
                if (!string.IsNullOrEmpty(giaBan))
                    filterCommand.Parameters.AddWithValue("@filterGiaBan", decimal.Parse(giaBan));
                if (!string.IsNullOrEmpty(cachDung))
                    filterCommand.Parameters.AddWithValue("@filterCachDung", "%" + cachDung + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(filterCommand);
                DataTable filteredTable = new DataTable();
                adapter.Fill(filteredTable);
                return filteredTable;
            }
            catch { throw; }
            finally { connection.Close(); }
        }

        public DataTable searchSanPham(string search)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SearchSanPham", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@kyTu", search);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Close();

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch { throw; }
            finally { connection.Close(); }
        }
    }
}
