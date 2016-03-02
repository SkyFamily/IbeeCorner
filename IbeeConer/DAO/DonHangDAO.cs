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
    public class DonHangDAO
    {
        dbConnect db = new dbConnect();

        public DataTable GetData()
        {
            return db.GetData("sp_DonHang_Select_All", null);

        }
        public DataTable GetDataByID(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaDonHang", id)
            };
            return db.GetData("sp_DonHang_Select_ByID", para);
        }
        public DataTable GetDataKhachHang()
        {
            return db.GetData("sp_KhachHang_Select_All", null);

        }
        public int Insert(DonHang obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaDonHang", obj.MaDonHang),
                new SqlParameter("DotHang", obj.DotHang),
                new SqlParameter("Thang", obj.Thang),
                new SqlParameter("Nam", obj.Nam),
                new SqlParameter("NgayLap", obj.NgayLap),
                new SqlParameter("TongGiaTri", obj.TongGiaTri),
                new SqlParameter("TienLai", obj.TienLai)
            };
            return db.ExecuteSQL("sp_DonHang_Insert", para);
        }
        public int Update(DonHang obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaDonHang", obj.MaDonHang),
                new SqlParameter("DotHang", obj.DotHang),
                new SqlParameter("Thang", obj.Thang),
                new SqlParameter("Nam", obj.Nam),
                new SqlParameter("NgayLap", obj.NgayLap),
                new SqlParameter("TongGiaTri", obj.TongGiaTri),
                new SqlParameter("TienLai", obj.TienLai)
            };
            return db.ExecuteSQL("sp_DonHang_Update", para);
        }
        public int Delete(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaDonHang", id)
            };
            return db.ExecuteSQL("sp_DonHang_Delete", para);
        }

        public int DeleteCTDH(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaDonHang", id)
            };
            return db.ExecuteSQL("sp_CTDH_Delete_ByMaDH", para);
        }

        public string LayIdTuDong(string tiento, int chieudai, string tablename)
        {
            return db.LayIdTuDong(tiento, chieudai, tablename);
        }
    }
}
