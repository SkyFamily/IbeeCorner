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
    public class LoaiSanPhamBLL
    {
        LoaiSanPhamDAO dao = new LoaiSanPhamDAO();

        public DataTable GetData()
        {
            return dao.GetData();
        }
        public DataTable GetDataByID(string id)
        {
            return dao.GetDataByID(id);
        }
        public int Insert(LoaiSanPham obj)
        {
            return dao.Insert(obj);
        }
        public int Update(LoaiSanPham obj)
        {
            return dao.Update(obj);
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
