using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyHieuThuoc.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.BusinessLogicLayer.Tests
{
    [TestClass()]
    public class DangNhapBLLTests
    {
        [TestMethod()]
        public void dangNhapSuccess()
        {
            DangNhapBLL dangNhapBLL = new DangNhapBLL();

            Assert.AreEqual(dangNhapBLL.dangNhap("test", "test"), 1);   
        }

        [TestMethod()]
        public void dangNhapUsernamePasswordFail()
        {
            DangNhapBLL dangNhapBLL = new DangNhapBLL();

            if (dangNhapBLL.dangNhap("test", "test") != 1)
            {
                Assert.IsTrue(dangNhapBLL.dangNhap("test", "test") == 0);
            }
        }
        [TestMethod()]
        public void dangNhapWithTenDangNhapEmpty()
        {
            DangNhapBLL dangNhapBLL = new DangNhapBLL();

            Assert.AreEqual(dangNhapBLL.dangNhap("", "test"), -1);
        }
        [TestMethod()]
        public void dangNhapWithMatKhauEmpty()
        {
            DangNhapBLL dangNhapBLL = new DangNhapBLL();

            Assert.AreEqual(dangNhapBLL.dangNhap("test", ""), -1);
        }
    }
}