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
    public class KhachHangDAO
    {
        dbConnect db = new dbConnect();

        public DataTable GetData()
        {
            return db.GetData("sp_KhachHang_Select_All", null);

        }
        public DataTable GetDataByID(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaKh", id)
            };
            return db.GetData("sp_KhachHang_Select_ByID", para);
        }

        public int Insert(KhachHang obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaKH", obj.MaKH),
                new SqlParameter("TenKH", obj.TenKH),
                new SqlParameter("DienThoai", obj.DienThoai),
                new SqlParameter("DiaChi", obj.DiaChi),
                new SqlParameter("GhiChu", obj.GhiChu)
            };
            return db.ExecuteSQL("sp_KhachHang_Insert", para);
        }
        public int Update(KhachHang obj)
        {
            SqlParameter[] para =
             {
                new SqlParameter("MaKH", obj.MaKH),
                new SqlParameter("TenKH", obj.TenKH),
                new SqlParameter("DienThoai", obj.DienThoai),
                new SqlParameter("DiaChi", obj.DiaChi),
                new SqlParameter("GhiChu", obj.GhiChu)
            };
            return db.ExecuteSQL("sp_KhachHang_Update", para);
        }
        public int Delete(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaKH", id)
            };
            return db.ExecuteSQL("sp_KhachHang_Delete", para);
        }

        public string LayIdTuDong(string tiento, int chieudai, string tablename)
        {
            return db.LayIdTuDong(tiento, chieudai, tablename);
        }

    }
}

