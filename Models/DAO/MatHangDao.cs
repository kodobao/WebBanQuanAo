using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PagedList;
using Models.EntityFramework;

namespace Models.DAO
{
    public class MatHangDao
    {
        private WebBanQuanAoDbContext db = null;

        public MatHangDao()
        {
            db = new WebBanQuanAoDbContext();
        }

        public List<MATHANG> GetAll()
        {
            var ls = db.MATHANGs.ToList();
            return ls;
        }

        public MATHANG ViewDetail(int id)
        {
            return db.MATHANGs.Find(id);
        }

        public IEnumerable<MATHANG> GetByStr(string str, int page = 1, int pageSize = 8)
        {
            IQueryable<MATHANG> ls = db.MATHANGs;
            if (!string.IsNullOrEmpty(str))
            {
                ls = db.MATHANGs.Where(x => x.tenhang.Contains(str) || x.mota.Contains(str) || x.mausac.Contains(str) || x.kichthuoc.Contains(str) || x.metatitle.Contains(str));
            }

            return ls.OrderBy(x => x.ngaynhap).ToPagedList(page, pageSize);
        }

        public int Insert(MATHANG mathang)
        {
            db.MATHANGs.Add(mathang);
            db.SaveChanges();
            return mathang.ma;
        }

        public bool Update(MATHANG mathang)
        {
            var mh = db.MATHANGs.Find(mathang.ma);
            if (mh != null)
            {
                mh.giaban = mathang.giaban;
                mh.hinhanh = mathang.hinhanh;
                mh.kichthuoc = mathang.kichthuoc;
                mh.mausac = mathang.mausac;
                mh.ngaynhap = DateTime.Now;
                mh.soluong = mathang.soluong;
                mh.tenhang = mathang.tenhang;
                mh.metatitle = mathang.metatitle;

                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            try
            {
                var mh = db.MATHANGs.Find(id);
                db.MATHANGs.Remove(mh);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<MATHANG> GetByType(int ma)
        {
            return db.MATHANGs.Where(x => x.maloaihang == ma).ToList();
        }

        public List<MATHANG> GetByCategory (int ma)
        {
            var lsMH = db.MATHANGs.ToList();
            var lsLH = db.LOAIHANGs.ToList();
            IEnumerable<MATHANG> ls = from c in lsMH
                     join d in lsLH
                     on c.maloaihang equals d.ma
                     where d.maloaiao == ma
                     select c;

            return ls.ToList();
        }

        public List<MATHANG> GetByFree (int ma)
        {
            return db.MATHANGs.Where(x => x.luotxem > 100).Take(ma).ToList();
        }

        public bool CheckId (int id)
        {
            var mh = db.MATHANGs.SingleOrDefault(x => x.ma == id);
            if (mh == null)
                return false;
            return true;
        }
    }
}
