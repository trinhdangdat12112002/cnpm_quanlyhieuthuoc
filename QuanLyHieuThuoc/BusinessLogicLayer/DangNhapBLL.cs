using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyHieuThuoc.BusinessLogicLayer
{
    public class DangNhapBLL
    {
        DataAccessLayer.TaiKhoanDAL dalDangNhap = new DataAccessLayer.TaiKhoanDAL();
        
        public int dangNhap(string username , string password)
        {
            using (DataTable dt =  dalDangNhap.dangNhap(username, password))
            {
                if (dt.Rows.Count > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public User layUser(string username , string password)
        {
            using (DataTable dt = dalDangNhap.dangNhap(username, password))
            {
                if (dt.Rows.Count > 0)
                {
                    User currentUser = new User { Username = dt.Rows[0]["sTenTaiKhoanNV"].ToString(), Role = dt.Rows[0]["sQuyen"].ToString(), Name = dt.Rows[0]["sTenNV"].ToString() };
                    return currentUser;
                }
                return null;
            }
        }

    }
}
