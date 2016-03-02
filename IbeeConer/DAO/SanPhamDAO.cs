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
    public class SanPhamDAO
    {
        dbConnect db = new dbConnect();

        public DataTable GetData()
        {
            return db.GetData("sp_SanPham_Select_All", null);

        }
        public DataTable GetDataByID(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaSP", id)
            };
            return db.GetData("sp_SanPham_Select_ByID", para);
        }
        public DataTable GetDataLoaiSP()
        {
            return db.GetData("sp_LoaiSanPham_Select_All", null);

        }
        public int Insert(SanPham obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaSP", obj.MaSP),
                new SqlParameter("TenSP", obj.TenSP),
                new SqlParameter("LinkSP", obj.LinkSP),
                new SqlParameter("NhanDanTe", obj.NhanDanTe),
                new SqlParameter("VietNamDong", obj.VietNamDong),
                new SqlParameter("MaLSP", obj.MaLSP),
                new SqlParameter("SoLuong", obj.SoLuong),
                new SqlParameter("GhiChu", obj.GhiChu),
                new SqlParameter("HinhAnh", obj.HinhAnh)
            };
            return db.ExecuteSQL("sp_SanPham_Insert", para);
        }
        public int Update(SanPham obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaSP", obj.MaSP),
                new SqlParameter("TenSP", obj.TenSP),
                new SqlParameter("LinkSP", obj.LinkSP),
                new SqlParameter("NhanDanTe", obj.NhanDanTe),
                new SqlParameter("VietNamDong", obj.VietNamDong),
                new SqlParameter("MaLSP", obj.MaLSP),
                new SqlParameter("SoLuong", obj.SoLuong),
                new SqlParameter("GhiChu", obj.GhiChu),
                new SqlParameter("HinhAnh", obj.HinhAnh)
            };
            return db.ExecuteSQL("sp_SanPham_Update", para);
        }
        public int Delete(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaSP", id)
            };
            return db.ExecuteSQL("sp_SanPham_Delete", para);
        }

        public string LayIdTuDong(string tiento, int chieudai, string tablename)
        {
            return db.LayIdTuDong(tiento, chieudai, tablename);
        }
    }
}
