using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PagedList;

using Models.EntityFramework;

namespace Models.DAO
{
    public class LoaiHangDao
    {
        private WebBanQuanAoDbContext db = null;
        
        public LoaiHangDao()
        {
            db = new WebBanQuanAoDbContext();
        }

        public List<LOAIHANG> GetAll()
        {
            return db.LOAIHANGs.ToList();
        }

        public IEnumerable<LOAIHANG> GetByStr (string str, int page=1, int pageSize=8)
        {
            IQueryable<LOAIHANG> ls = db.LOAIHANGs.OrderByDescending(x => x.sapxep);
            if (!string.IsNullOrEmpty(str))
            {
                ls = ls.Where(x => x.link.Contains(str) || x.loai.Contains(str));
            }
            
            return ls.OrderByDescending(x => x.sapxep).ToPagedList(page, pageSize);
        }

        public List<LOAIHANG> GetByCategory (int id)
        {
            return db.LOAIHANGs.Where(x => x.maloaiao == id).OrderBy(x => x.sapxep).ToList();
        }

        public int Insert (LOAIHANG lh)
        {
            db.LOAIHANGs.Add(lh);
            db.SaveChanges();
            return lh.ma;
        }

        public LOAIHANG ViewDetail (int id)
        {
            return db.LOAIHANGs.Find(id);
        }

        public bool Update (LOAIHANG lh)
        {
            var loaihang = db.LOAIHANGs.SingleOrDefault(x => x.ma == lh.ma);
            if (loaihang != null)
            {
                loaihang.sapxep = lh.sapxep;
                loaihang.maloaiao = lh.maloaiao;
                loaihang.link = lh.link;
                loaihang.loai = lh.loai;
                db.SaveChanges();

                return true;
            }
            return false;
        }

        public bool Delete (int id)
        {
            try
            {
                var lh = db.LOAIHANGs.Find(id);
                db.LOAIHANGs.Remove(lh);
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
