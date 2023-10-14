using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHieuThuoc.BusinessLogicLayer
{
    internal class LoaiSanPhamBLL
    {
        DataAccessLayer.LoaiSanPhamDAL  lsp = new DataAccessLayer.LoaiSanPhamDAL();

        public DataTable getLoaiSP()
        {
            return lsp.getLoaiSP();
        }

        public DataTable searchLoaiSP(string search)
        {
            return lsp.searchLoaiSP(search);
        }

        public DataTable getSanPhamByLoai(string maLoai)
        {
            return lsp.getSanPhamByLoai(maLoai);
        }

        public int insertLoaiSP(string maLoai, string tenLoai)
        {
            return lsp.insertLoaiSP(maLoai, tenLoai);
        }

        public int updateLoaiSP(string maLoai, string tenLoai)
        {
            return lsp.updateLoaiSP(maLoai, tenLoai);
        }

        public int deleteLoaiSP (string maLoai)
        {
             return lsp.deleteLoaiSP(maLoai);
        }
    }
}
