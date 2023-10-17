using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuanLyHieuThuoc.DataAccessLayer.Tests
{
    [TestClass]
    public class TaiKhoanDALTests
    {
        [TestMethod]
        public void getTaiKhoanTest()
        {
            TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();


            Assert.AreEqual(1, 1);
        }
    }
}