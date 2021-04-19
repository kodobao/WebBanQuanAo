using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PagedList;
using Models.EntityFramework;

namespace Models.DAO
{
    public class LoaiAoDao
    {
        private WebBanQuanAoDbContext db = null;

        public LoaiAoDao()
        {
            db = new WebBanQuanAoDbContext();
        }

        public List<LOAIAO> GetAll ()
        {
            return db.LOAIAOs.ToList();
        }

        public IEnumerable<LOAIAO> GetByStr (string search, int page=1, int pageSize=8)
        {
            IQueryable<LOAIAO> ls = db.LOAIAOs;
            if (!string.IsNullOrEmpty(search))
            {
                ls = ls.Where(x => x.loaiao1.Contains(search) || x.link.Contains(search) || x.metatitle.Contains(search));
            }
            return ls.OrderBy(x => x.sapxep).ToPagedList(page, pageSize);
        }

        public LOAIAO ViewDetail (int id)
        {
            return db.LOAIAOs.Find(id);
        }

        public int Insert (LOAIAO loaiAo)
        {
            db.LOAIAOs.Add(loaiAo);
            db.SaveChanges();

            return loaiAo.ma;
        }

        public bool Update (LOAIAO loaiAo)
        {
            try
            {
                var LA = db.LOAIAOs.SingleOrDefault(x => x.ma == loaiAo.ma);

                LA.loaiao1 = loaiAo.loaiao1;
                LA.sapxep = loaiAo.sapxep;
                LA.metatitle = loaiAo.metatitle;
                LA.link = loaiAo.link;

                db.SaveChanges();
                return true;

            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool Delete (int id)
        {
            try
            {
                var la = db.LOAIAOs.SingleOrDefault(x => x.ma == id);
                db.LOAIAOs.Remove(la);
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
