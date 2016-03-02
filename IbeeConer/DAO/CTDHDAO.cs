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
    public class CTDHDAO
    {
        dbConnect db = new dbConnect();

        public DataTable GetData()
        {
            return db.GetData("sp_CTDH_Select_All", null);

        }
        public DataTable GetDataByID(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaCTDH", id)
            };
            return db.GetData("sp_CTDH_Select_ByID", para);
        }
        public DataTable GetDataByMaDH(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaDonHang", id)
            };
            return db.GetData("sp_CTDH_Select_ByMaDH", para);
        }
        public DataTable GetDataByMaDH_MaKH(string id,string idkh)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaDonHang", id),
                new SqlParameter("MaKH", idkh)
            };
            return db.GetData("sp_CTDH_Select_ByMaDonHang", para);
        }
        public DataTable TinhTien(string id, string idkh)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaDonHang", id),
                new SqlParameter("MaKH", idkh)
            };
            return db.GetData("sp_CTDH_TinhTien", para);
        }
        public DataTable GetDataDonHang()
        {
            return db.GetData("sp_DonHang_Select_All", null);

        }
        public DataTable GetDataSanPham()
        {
            return db.GetData("sp_SanPham_Select_All", null);

        }
        public DataTable GetDataSanPhamByID(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaSP", id)
            };
            return db.GetData("sp_SanPham_Select_ByID", para);
        }
        public DataTable GetDataSanPham_SoLuong()
        {
            return db.GetData("sp_SanPham_Select_BySoLuong", null);

        }
        public DataTable GetDataKhachHang()
        {
            return db.GetData("sp_KhachHang_Select_All", null);

        }
        public int Insert(CTDH obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaCTDH", obj.MaCTDH),
                new SqlParameter("MaDonHang", obj.MaDonHang),
                new SqlParameter("MaKH", obj.MaKH),
                new SqlParameter("MaSP", obj.MaSP),
                new SqlParameter("SoLuongMua", obj.SoLuongMua),
                new SqlParameter("DonGiaNhap", obj.DonGiaNhap),
                new SqlParameter("TienLoi", obj.TienLoi),
                new SqlParameter("DonGiaBan", obj.DonGiaBan)
            };
            return db.ExecuteSQL("sp_CTDH_Insert", para);
        }
        public int Update(CTDH obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaCTDH", obj.MaCTDH),
                new SqlParameter("MaDonHang", obj.MaDonHang),
                new SqlParameter("MaKH", obj.MaKH),
                new SqlParameter("MaSP", obj.MaSP),
                new SqlParameter("SoLuongMua", obj.SoLuongMua),
                new SqlParameter("DonGiaNhap", obj.DonGiaNhap),
                new SqlParameter("TienLoi", obj.TienLoi),
                new SqlParameter("DonGiaBan", obj.DonGiaBan)
            };
            return db.ExecuteSQL("sp_CTDH_Update", para);
        }
        public int UpdateSoLuongSanPham(SanPham obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaSP", obj.MaSP),
                new SqlParameter("SoLuong", obj.SoLuong)
            };
            return db.ExecuteSQL("sp_SanPham_Update_BySoLuong", para);
        }
        public int Delete(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaCTDH", id)
            };
            return db.ExecuteSQL("sp_CTDH_Delete", para);
        }

        public string LayIdTuDong(string tiento, int chieudai, string tablename)
        {
            return db.LayIdTuDong(tiento, chieudai, tablename);
        }
    }
}
