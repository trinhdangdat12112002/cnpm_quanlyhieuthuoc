using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyHieuThuoc.DataAccessLayer;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace UnitTestProject1
{

    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();
            taiKhoanDAL.cac(1);

            Assert.AreEqual(1, 1);

        }
    }
}
