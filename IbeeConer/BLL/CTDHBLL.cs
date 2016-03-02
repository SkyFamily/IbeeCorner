using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BLL
{
    public class CTDHBLL
    {
        CTDHDAO dao = new CTDHDAO();

        public DataTable GetData()
        {
            return dao.GetData();
        }
        public DataTable GetDataByID(string id)
        {
            return dao.GetDataByID(id);
        }
        public DataTable GetDataByMaDH(string id)
        {
            return dao.GetDataByMaDH(id);
        }
        public DataTable GetDataByMaDH_MaKH(string id,string idkh)
        {
            return dao.GetDataByMaDH_MaKH(id,idkh);
        }
        public DataTable TinhTien(string id, string idkh)
        {
            return dao.TinhTien(id,idkh);
        }
        public DataTable GetDataKhachHang()
        {
            return dao.GetDataKhachHang();
        }
        public DataTable GetDataDonHang()
        {
            return dao.GetDataDonHang();
        }
        public DataTable GetDataSanPham()
        {
            return dao.GetDataSanPham();
        }
        public DataTable GetDataSanPhamByID(string id)
        {
            return dao.GetDataSanPhamByID(id);
        }
        public DataTable GetDataSanPhamBySoLuong()
        {
            return dao.GetDataSanPham_SoLuong();
        }
        public int Insert(CTDH obj)
        {
            return dao.Insert(obj);
        }
        public int Update(CTDH obj)
        {
            return dao.Update(obj);
        }
        public int UpdateSoLuongSP(SanPham obj)
        {
            return dao.UpdateSoLuongSanPham(obj);
        }
        public int Delete(string id)
        {
            return dao.Delete(id);
        }
        public string LayIdTuDong(string tiento, int chieudai, string tablename)
        {
            return dao.LayIdTuDong(tiento, chieudai, tablename);
        }
    }
}
