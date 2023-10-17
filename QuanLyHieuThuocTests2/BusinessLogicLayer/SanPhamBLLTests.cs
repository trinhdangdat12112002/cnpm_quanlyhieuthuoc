using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyHieuThuoc.BusinessLogicLayer;
using QuanLyHieuThuoc.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.BusinessLogicLayer.Tests
{
    [TestClass()]
    public class SanPhamBLLTests
    {
        [TestMethod()]
        public void getSanPhamTest()
        {
            Assert.Fail();
        }
        SanPhamBLL sanPhamBLL = new SanPhamBLL();

        [TestMethod()]
        public void checkMaSP_MaSPEmpty()
        {
            int expected = -2;
            int actual = sanPhamBLL.checkMaSP("");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void checkMaSP_MaSPExist()
        {
            int expected = 1;
            int actual = sanPhamBLL.checkMaSP("SP1");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void checkMaSP_MaSPNotExist()
        {
            int expected = 0;
            int actual = sanPhamBLL.checkMaSP("DD");

            Assert.AreEqual(expected, actual);
        }


        //Insert San Pham
        [TestMethod()]
        public void insertSanPham_MaSP_Empty()
        {
            int expected = -2;
            int actual = sanPhamBLL.insertSanPham("", "Sản phẩm 4", "L1", 10000, "VN", "VN", "VN", "Tong tin");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void insertSanPham_TenSP_Empty()
        {
            int expected = -2;
            int actual = sanPhamBLL.insertSanPham("SP4", "", "L1", 10000, "VN", "VN", "VN", "Tong tin");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void insertSanPham_LoaiSP_Empty()
        {
            int expected = -2;
            int actual = sanPhamBLL.insertSanPham("SP4", "Sản phẩm 4", "", 10000, "VN", "VN", "VN", "Tong tin");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void insertSanPham_HangSX_Empty()
        {
            int expected = -2;
            int actual = sanPhamBLL.insertSanPham("SP4", "Sản phẩm 4", "L1", 10000, "", "VN", "VN", "Tong tin");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void insertSanPham_NuocSX_Empty()
        {
            int expected = -2;
            int actual = sanPhamBLL.insertSanPham("SP4", "Sản phẩm 4", "L1", 10000, "VN", "", "VN", "Tong tin");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void insertSanPham_ThongTin_Empty()
        {
            int expected = -2;
            int actual = sanPhamBLL.insertSanPham("SP4", "Sản phẩm 4", "L1", 10000, "VN", "VN", "", "Tong tin");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void insertSanPham_CachDung_Empty()
        {
            int expected = -2;
            int actual = sanPhamBLL.insertSanPham("SP4", "Sản phẩm 4", "L1", 10000, "VN", "VN", "VN", "");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void insertSanPham_Success()
        {
            int expected = 1;
            int actual = sanPhamBLL.insertSanPham("SP6", "Sản phẩm 4", "L1", 10000, "VN", "VN", "VN", "Tong tin");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void insertSanPham_NotSuccess()
        {
            int expected = -1;
            int actual = sanPhamBLL.insertSanPham("SP5", "Sản phẩm 4", "L1", 10000, "VN", "VN", "VN", "Tong tin");

            Assert.AreEqual(expected, actual);
        }

        //update San Pham
        [TestMethod()]
        public void updateSanPham_MaSP_Empty()
        {
            int expected = -2;
            int actual = sanPhamBLL.updateSanPham("", "Sản phẩm 4", "L1", 10000, "VN", "VN", "VN", "Tong tin");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void updateSanPham_TenSP_Empty()
        {
            int expected = -2;
            int actual = sanPhamBLL.updateSanPham("SP4", "", "L1", 10000, "VN", "VN", "VN", "Tong tin");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void updateSanPham_LoaiSP_Empty()
        {
            int expected = -2;
            int actual = sanPhamBLL.updateSanPham("SP4", "Sản phẩm 4", "", 10000, "VN", "VN", "VN", "Tong tin");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void updateSanPham_HangSX_Empty()
        {
            int expected = -2;
            int actual = sanPhamBLL.updateSanPham("SP4", "Sản phẩm 4", "L1", 10000, "", "VN", "VN", "Tong tin");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void updateSanPham_NuocSX_Empty()
        {
            int expected = -2;
            int actual = sanPhamBLL.updateSanPham("SP4", "Sản phẩm 4", "L1", 10000, "VN", "", "VN", "Tong tin");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void updateSanPham_ThongTin_Empty()
        {
            int expected = -2;
            int actual = sanPhamBLL.updateSanPham("SP4", "Sản phẩm 4", "L1", 10000, "VN", "VN", "", "Tong tin");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void updateSanPham_CachDung_Empty()
        {
            int expected = -2;
            int actual = sanPhamBLL.updateSanPham("SP4", "Sản phẩm 4", "L1", 10000, "VN", "VN", "VN", "");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void updateSanPham_Success()
        {
            int expected = 1;
            int actual = sanPhamBLL.updateSanPham("SP4", "Sản phẩm 4", "L1", 10000, "VN", "VN", "VN", "Tong tin");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void updateSanPham_NotSuccess()
        {
            int expected = 0;
            int actual = sanPhamBLL.updateSanPham("SP52", "Sản phẩm 4", "L1", 10000, "VN", "VN", "VN", "Tong tin");

            Assert.AreEqual(expected, actual);
        }

        // DElete San Pham
        [TestMethod()]
        public void deleteSanPham_NotSuccess()
        {
            int expected = 0;
            int actual = sanPhamBLL.deleteSanPham("SP54");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void deleteSanPham_Success()
        {
            int expected = 1;
            int actual = sanPhamBLL.deleteSanPham("SP5");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void deleteSanPham_MaSP_Empty()
        {
            int expected = -2;
            int actual = sanPhamBLL.deleteSanPham("");

            Assert.AreEqual(expected, actual);
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