using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models.EntityFramework;
using PagedList;

namespace Models.DAO
{
    public class ChiTietDatHangDao
    {
        private WebBanQuanAoDbContext db = null;

        public ChiTietDatHangDao()
        {
            db = new WebBanQuanAoDbContext();
        }

        public List<CHITIETDATHANG> GetAll ()
        {
            return db.CHITIETDATHANGs.ToList();
        }

        public IEnumerable<CHITIETDATHANG> GetByStr(int? str, int page=1, int pageSize=8)
        {
            IQueryable<CHITIETDATHANG> ls = db.CHITIETDATHANGs;
            if (!string.IsNullOrEmpty(str.ToString()))
            {
                ls = ls.Where(x => x.sohoadon == str || x.mahang == str || x.soluong == str || x.giaban == (double)str);
            }
            
            return ls.OrderBy(x => x.sohoadon).ToPagedList(page, pageSize);
        }

        
        public List<CHITIETDATHANG> GetByCatagory (int sohoadon)
        {
            return db.CHITIETDATHANGs.Where(x => x.sohoadon == sohoadon).ToList();
        }

        public List<CHITIETDATHANG> GetByProduct (int mahang)
        {
            return db.CHITIETDATHANGs.Where(x => x.mahang == mahang).ToList();
        }

        public IEnumerable<History> GetByObj (int makhachhang)
        {
            IQueryable<History> res = from h in db.KHACHHANGs
                                     join c in db.DONDATHANGs
                                     on h.ma equals c.makhachhang
                                     join d in db.CHITIETDATHANGs
                                     on c.sohoadon equals d.sohoadon
                                     join p in db.MATHANGs
                                     on d.mahang equals p.ma
                                     where h.ma == makhachhang
                                     select new History
                                     {
                                         SanPham = p.tenhang,
                                         SoLuong = d.soluong,
                                         NgayDat = c.ngaydathang,
                                         Gia = (double)p.giaban,
                                         TrangThai = c.trangthai
                                     };
            return res.ToList();
                                     
        }

        public bool Delete(int sohoadon)
        {
            try
            {
                var ls = db.CHITIETDATHANGs.Where(x => x.sohoadon == sohoadon).ToList();
                foreach(var item in ls)
                {
                    db.CHITIETDATHANGs.Remove(item);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Insert (CHITIETDATHANG ctdh)
        {
            try
            {
                db.CHITIETDATHANGs.Add(ctdh);
                db.SaveChanges();

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool Update (CHITIETDATHANG ctdh )
        {
            try
            {
                var hdct = db.CHITIETDATHANGs.SingleOrDefault(x => x.sohoadon == ctdh.sohoadon && x.mahang == ctdh.mahang);
                var mh = db.MATHANGs.SingleOrDefault(x => x.ma == hdct.mahang);

                hdct.giaban = (double)mh.giaban;
                hdct.soluong = ctdh.soluong;

                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

    }
}
