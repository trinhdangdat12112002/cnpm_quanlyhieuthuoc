using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyHieuThuoc.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.DataAccessLayer.Tests
{
    [TestClass()]
    public class SanPhamDALTests
    {
        SanPhamDAL sanPhamDAL= new SanPhamDAL();
        [TestMethod()]
        public void checkMaSPWithMaSPEmpty()
        {
            int expected = 0;
            int actual = sanPhamDAL.checkMaSP("");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void insertSanPhamTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void updateSanPhamTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void deleteSanPhamTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void filterSanPhamTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void searchSanPhamTest()
        {
            Assert.Fail();
        }
    }
}