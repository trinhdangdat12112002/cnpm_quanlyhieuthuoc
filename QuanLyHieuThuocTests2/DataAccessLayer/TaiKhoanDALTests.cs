using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyHieuThuoc.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.DataAccessLayer.Tests
{
    [TestClass()]
    public class TaiKhoanDALTests
    {
        TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();
        [TestMethod()]
        public void dangNhapSuccess()
        {
            TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();
            DataTable dt = taiKhoanDAL.dangNhap("test", "test");

            Assert.AreEqual(dt.Rows.Count , 1);
        }
        [TestMethod()]
        public void dangNhapNotSuccess()
        {
            TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();
            DataTable dt = taiKhoanDAL.dangNhap("test13", "test");

            Assert.AreEqual(dt.Rows.Count, 0);
        }

        [TestMethod()]
        public void check_NV_TKExist()
        {
            int expected = 1;
            int actual = taiKhoanDAL.check_NV_TK("NV1");

            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void check_NV_TKNotExist()
        {
            int expected = 1;
            int actual = taiKhoanDAL.check_NV_TK("NV1");

            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void checkTaiKhoanExist()
        {
            int expected = 1;
            int actual = taiKhoanDAL.checkTaiKhoan("test");

            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void checkTaiKhoanNotExist()
        {
            int expected = 0;
            int actual = taiKhoanDAL.checkTaiKhoan("test22");

            Assert.AreEqual(actual, expected);
        }

        [TestMethod()] 
        public void insertTaiKhoanNotSuccess()
        {
            int expected = -1;
            int actual = taiKhoanDAL.insertTaiKhoan("cccc","cccc", "Nhân viên", "NV5" );

            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void insertTaiKhoanSuccess()
        {
            int expected = 1;
            int actual = taiKhoanDAL.insertTaiKhoan("cccc", "cccc", "Nhân viên", "NV4");

            Assert.AreEqual(actual, expected);
        }
        [TestMethod()]
        public void updateTaiKhoanNotSuccess()
        {
            int expected = 0;
            int actual = taiKhoanDAL.updateTaiKhoan("cccc", "cccc", "Nhân viên", "NV7");

            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void updateTaiKhoanSuccess()
        {
            int expected = 1;
            int actual = taiKhoanDAL.updateTaiKhoan("cccc", "cccc", "Nhân viên", "NV4");

            Assert.AreEqual(actual, expected);
        }
        [TestMethod()]
        public void deleteTaiKhoanNotSuccess()
        {
            int expected = 0;
            int actual = taiKhoanDAL.deleteTaiKhoan( "NV7");

            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void deleteTaiKhoanSuccess()
        {
            int expected = 1;
            int actual = taiKhoanDAL.deleteTaiKhoan("NV4");

            Assert.AreEqual(actual, expected);
        }
    }
}