using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class History
    {
        public string SanPham { get; set; }
        public int? SoLuong { get; set; }
        public DateTime? NgayDat { get; set; }
        public double? Gia { get; set; }
        public int? TrangThai { get; set; }
    }
}
