using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.BusinessLogicLayer
{
    public class NhanVienBLL
    {
        DataAccessLayer.NhanVienDAL nhanVien = new DataAccessLayer.NhanVienDAL();

        public DataTable getNhanVien ()
        {
            return nhanVien.getNhanVien();
        }

        public DataTable searchNhanVien (string search)
        {
            return nhanVien.searchNhanVien(search);
        }

        public bool checkMaNV (string maNV)
        {
            return nhanVien.checkMaNhanVien(maNV);
        }

        public void insertNhanVien (string maNV, string tenNV, bool gioiTinh, DateTime ngaySinh, string sdt, string diaChi, DateTime ngayVaoLam)
        {
            nhanVien.insertNhanVien(maNV, tenNV, gioiTinh, ngaySinh, sdt, diaChi, ngayVaoLam);  
        }

        public void updateNhanVien (string maNV, string tenNV, bool gioiTinh, DateTime ngaySinh, string sdt, string diaChi, DateTime ngayVaoLam)
        {
            nhanVien.updateNhanVien(maNV, tenNV, gioiTinh, ngaySinh, sdt, diaChi, ngayVaoLam);
        }

        public void deleteNhanVien (string maNV)
        {
            nhanVien.deleteNhanVien(maNV) ;
        }

        public DataTable filterNhanVien (string maNV, string tenNV, string sdt)
        {
            return nhanVien.filterNhanVien(maNV , tenNV, sdt) ; 
        }
    }
}
