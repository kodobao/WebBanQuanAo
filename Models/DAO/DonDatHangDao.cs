using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models.EntityFramework;
using PagedList;

namespace Models.DAO
{
    public class DonDatHangDao
    {
        private WebBanQuanAoDbContext db = null;

        public DonDatHangDao()
        {
            db = new WebBanQuanAoDbContext();
        }

        public List<DONDATHANG> GetAll ()
        {
            return db.DONDATHANGs.ToList();
        }

        public IEnumerable<DONDATHANG> GetByStr (int? str, int page=1, int pageSize=8)
        {
            IQueryable<DONDATHANG> ls = db.DONDATHANGs;
            if (!string.IsNullOrEmpty(str.ToString()))
            {
                ls = ls.Where(x => x.sohoadon == str || x.makhachhang == str || x.trangthai == str);
            }
            
            return ls.OrderByDescending(x => x.ngaydathang).ToPagedList(page, pageSize);
        }

        public DONDATHANG ViewDetail (int sohoadon)
        {
            return db.DONDATHANGs.SingleOrDefault(x => x.sohoadon == sohoadon);
        }

        public bool Delete (int sohoadon)
        {
            try
            {
                var ddh = db.DONDATHANGs.SingleOrDefault(x => x.sohoadon == sohoadon);
                db.DONDATHANGs.Remove(ddh);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Insert (DONDATHANG ddh)
        {
            db.DONDATHANGs.Add(ddh);
            db.SaveChanges();
            return ddh.sohoadon;
        }

        public bool Update (DONDATHANG ddh)
        {
            try
            {
                var res = db.DONDATHANGs.SingleOrDefault(x => x.sohoadon == ddh.sohoadon);
                res.noigiaohang = ddh.noigiaohang;
                res.ngaygiaohang = ddh.ngaygiaohang;
                res.ngaychuyenhang = ddh.ngaychuyenhang;
                res.trangthai = ddh.trangthai;

                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public List<int> SetById (int makhachhang)
        {
            return db.DONDATHANGs.Where(x => x.makhachhang == makhachhang).Select(x => x.sohoadon).ToList();
        }


    }
}
