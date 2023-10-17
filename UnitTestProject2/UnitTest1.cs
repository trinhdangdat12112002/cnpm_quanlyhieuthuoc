using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyHieuThuoc.DataAccessLayer;
using System.Configuration;
using QuanLyHieuThuoc.NhanVien;
using System;
using System.Data;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            LoHangDAL tk = new LoHangDAL();
            int count = tk.deleteLoHang("ML1");
            Assert.AreEqual(1, count);
        }
    }
}
