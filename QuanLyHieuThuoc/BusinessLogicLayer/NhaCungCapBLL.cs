using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.BusinessLogicLayer
{
    public class NhaCungCapBLL
    {
        DataAccessLayer.NhaCungCapDAL ncc = new DataAccessLayer.NhaCungCapDAL();

        public DataTable getNhaCungCap()
        {
            return ncc.getNhaCungCap();
        }

        public int checkNCC (string maNCC)
        {
            return ncc.checkNCC(maNCC);
        } 

        public void insertNCC (string maNCC, string tenNCC, string diaChi, string sdt) {
            ncc.insertNCC(maNCC,tenNCC,diaChi,sdt);
        }

        public void updateNCC(string maNCC, string tenNCC, string diaChi, string sdt)
        {
            ncc.updateNCC(maNCC, tenNCC, diaChi, sdt);
        }

        public void deleteNCC(string maNCC)
        {
            ncc.deleteNCC(maNCC) ;
        }

        public DataTable searchNCC (string search)
        {
            return ncc.searchNCC(search) ;
        }
    }
}
