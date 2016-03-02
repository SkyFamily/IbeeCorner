using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string LinkSP { get; set; }
        public string NhanDanTe { get; set; }
        public string VietNamDong { get; set; }
        public string MaLSP { get; set; }
        public string SoLuong { get; set; }
        public string GhiChu { get; set; }
        public byte[] HinhAnh { get; set; }
    }
}
