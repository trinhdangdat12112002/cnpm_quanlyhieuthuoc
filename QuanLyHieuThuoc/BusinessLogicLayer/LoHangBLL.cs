using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.BusinessLogicLayer
{
    internal class LoHangBLL
    {
        DataAccessLayer.LoHangDAL lh = new DataAccessLayer.LoHangDAL();

        public DataTable getLoHang()
        {
            return lh.getLoHang();
        }

        public DataTable getSanPhamByLoHang(string maLo)
        {
            return lh.getSanPhamByLoHang(maLo);
        }

        public int checkMaLo(string maLo)
        {
            return lh.checkMaLo(maLo);
        }

        public int insertLoHang(string maLo, DateTime ngaySanXuat, DateTime hanSuDung)
        {
            return lh.insertLoHang(maLo, ngaySanXuat, hanSuDung);   
        }

        public int updateLoHang(string maLo, DateTime ngaySanXuat, DateTime hanSuDung)
        {
            return lh.updateLoHang(maLo, ngaySanXuat, hanSuDung);
        }

        public int deleteLoHang(string maLo)
        {
            return lh.deleteLoHang(maLo);
        }
    }
}
