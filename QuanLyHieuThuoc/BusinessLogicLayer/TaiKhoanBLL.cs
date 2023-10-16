﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.BusinessLogicLayer
{
    internal class TaiKhoanBLL
    {
        DataAccessLayer.TaiKhoanDAL tk = new DataAccessLayer.TaiKhoanDAL();
        public DataTable getTaiKhoan()
        {
            return tk.getTaiKhoan();
        }

        public int check_NV_TK(string maNV)
        {
            return tk.check_NV_TK(maNV);
        }

        public int checkTaiKhoan (string tenDangNhap)
        {
            return tk.checkTaiKhoan(tenDangNhap);
        }

        public int insertTaiKhoan (string tenTaiKhoan, string matKhau, string quyen, string maNV)
        {
            return tk.insertTaiKhoan(tenTaiKhoan, matKhau, quyen, maNV);
        }

        public int updateTaiKhoan(string tenTaiKhoan, string matKhau, string quyen, string maNV)
        {
            return tk.updateTaiKhoan(tenTaiKhoan,matKhau, quyen,maNV);
        }

        public int deleteTaiKhoan (String maNV)
        {
            return tk.deleteTaiKhoan( maNV);
        }

        public string getMaNV (string username)
        {
            return tk.getMaNV(username);
        }
    }
}
