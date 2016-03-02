using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class LoaiSanPhamDAO
    {
        dbConnect db = new dbConnect();

        public DataTable GetData()
        {
            return db.GetData("sp_LoaiSanPham_Select_All", null);

        }
        public DataTable GetDataByID(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaLSP", id)
            };
            return db.GetData("sp_LoaiSanPham_Select_ByID", para);
        }

        public int Insert(LoaiSanPham obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaLSP", obj.MaLSP),
                new SqlParameter("TenLSP", obj.TenLSP),
                new SqlParameter("MoTa", obj.MoTa)
            };
            return db.ExecuteSQL("sp_LoaiSanPham_Insert", para);
        }
        public int Update(LoaiSanPham obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaLSP", obj.MaLSP),
                new SqlParameter("TenLSP", obj.TenLSP),
                new SqlParameter("MoTa", obj.MoTa)
            };
            return db.ExecuteSQL("sp_LoaiSanPham_Update", para);
        }
        public int Delete(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaLSP", id)
            };
            return db.ExecuteSQL("sp_LoaiSanPham_Delete", para);
        }

        public string LayIdTuDong(string tiento, int chieudai, string tablename)
        {
            return db.LayIdTuDong(tiento, chieudai, tablename);
        }

    }
}
