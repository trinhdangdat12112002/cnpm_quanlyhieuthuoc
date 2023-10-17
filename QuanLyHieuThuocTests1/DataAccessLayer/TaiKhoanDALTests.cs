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
    public class TaiKhoanDALTests
    {
        [TestMethod()]
        public void dangNhapTest()
        {
            try
            {
                TaiKhoanDAL t
                = new TaiKhoanDAL();
                int count = t.check_NV_TK("NV1");

                Assert.AreEqual(count, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}