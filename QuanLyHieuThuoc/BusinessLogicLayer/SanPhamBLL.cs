using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.BusinessLogicLayer
{
    public class SanPhamBLL
    {
        DataAccessLayer.SanPhamDAL sp = new DataAccessLayer.SanPhamDAL();

        public DataTable getSanPham()
        {
            return sp.getSanPham();
        }

        public int checkMaSP(string maSP)
        {
            if (string.IsNullOrEmpty(maSP))
            {
                return -2;
            } 
            else
            {
                return sp.checkMaSP(maSP);
            }
        }

        public int insertSanPham (string maSP, string tenSP, string sMaLoai, float giaBan, string hangSX, string nuocSX, string thongTin, string cachDung)
        {
            if (string.IsNullOrEmpty(maSP) || string.IsNullOrEmpty(tenSP) || string.IsNullOrEmpty(sMaLoai) || string.IsNullOrEmpty(hangSX) || string.IsNullOrEmpty(nuocSX) || string.IsNullOrEmpty(thongTin) || string.IsNullOrEmpty(cachDung))
            {
                return -2;
            }
            else
            {
                return sp.insertSanPham(maSP, tenSP, sMaLoai, giaBan, hangSX, nuocSX, thongTin, cachDung);
            }
        }

        public int updateSanPham(string maSP, string tenSP, string sMaLoai, float giaBan, string hangSX, string nuocSX, string thongTin, string cachDung)
        {
            if (string.IsNullOrEmpty(maSP) || string.IsNullOrEmpty(tenSP) || string.IsNullOrEmpty(sMaLoai) || string.IsNullOrEmpty(hangSX) || string.IsNullOrEmpty(nuocSX) || string.IsNullOrEmpty(thongTin) || string.IsNullOrEmpty(cachDung))
            {
                return -2;
            }
            else
            {
                return sp.updateSanPham(maSP, tenSP, sMaLoai, giaBan, hangSX, nuocSX, thongTin, cachDung);
            } 
        }

        public int deleteSanPham (string maSP)
        {
            if (string.IsNullOrEmpty(maSP))
            {
                return -2;
            }
            else
            {
                return sp.deleteSanPham(maSP);
            }
        }

        public DataTable filterSanPham(string maSP, string tenSP, string giaBan, string hangSX, string nuocSX, string thongTin, string cachDung)
        {
            return sp.filterSanPham(maSP, tenSP , giaBan , hangSX , nuocSX , thongTin , cachDung);
        }

        public DataTable searchSanPham (string search)
        {
            return sp.searchSanPham(search);
        }
    }
}
