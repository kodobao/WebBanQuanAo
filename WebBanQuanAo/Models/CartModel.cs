using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Models.EntityFramework;

namespace WebBanQuanAo.Models
{
    public class CartModel
    {
        public MATHANG SanPham { get; set; }

        public int SoLuong { get; set; }

        public double TongTien ()
        {
            return SoLuong * (double)SanPham.giaban;
        }

        public double ThanhToan (List<CartModel> gio)
        {
            double thanhtien = 0;
            foreach(var item in gio)
            {
                thanhtien += item.TongTien();
            }
            return thanhtien;
        }

        public bool CapNhatSoLuong (int id, int soluong)
        {
            if (this.SanPham.ma == id)
            {
                SoLuong = soluong;
                return true;
            }
            return false;
        }


    }
}