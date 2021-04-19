using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PagedList;
using Models.EntityFramework;

namespace Models.DAO
{
    public class KhachHangDao
    {
        private WebBanQuanAoDbContext db = null;

        public KhachHangDao()
        {
            db = new WebBanQuanAoDbContext();
        }

        public int Login(string username, string password)
        {
            var user = db.KHACHHANGs.SingleOrDefault(x => x.username == username);
            if (user == null)
            {
                return 0;
            }
            else
            {
                if (user.password == password)
                {
                    if (user.trangthai == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -2;
                }
            }
        }

        public List<KHACHHANG> GetAll()
        {
            return db.KHACHHANGs.ToList();
        }

        public IEnumerable<KHACHHANG> GetByStr(string str, int page = 1, int pageSize = 8)
        {
            IQueryable<KHACHHANG> ls = db.KHACHHANGs;
            if (!string.IsNullOrEmpty(str))
            {
                ls = ls.Where(x => x.tenkhachhang.Contains(str) || x.email.Contains(str) || x.diachi.Contains(str) || x.username.Contains(str) || x.dienthoai.Contains(str));
            }
            return ls.OrderBy(x => x.tenkhachhang).ToPagedList(page, pageSize);
        }

        public int Insert(KHACHHANG kh)
        {

            db.KHACHHANGs.Add(kh);
            db.SaveChanges();
            return kh.ma;

        }

        public KHACHHANG ViewDetail(int id)
        {
            return db.KHACHHANGs.Find(id);
        }

        public bool Update(KHACHHANG kh)
        {
            try
            {
                var khachhang = db.KHACHHANGs.SingleOrDefault(x => x.ma == kh.ma);

                khachhang.tenkhachhang = kh.tenkhachhang;
                khachhang.password = kh.password;
                khachhang.email = kh.email;
                khachhang.dienthoai = kh.dienthoai;
                khachhang.diachi = kh.diachi;

                db.SaveChanges();


                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var khachhang = db.KHACHHANGs.SingleOrDefault(x => x.ma == id);

                db.KHACHHANGs.Remove(khachhang);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public KHACHHANG GetByUser(string str)
        {
            return db.KHACHHANGs.SingleOrDefault(x => x.username == str || x.email == str);
        }

        public bool CheckUser(string username)
        {
            var user = db.KHACHHANGs.SingleOrDefault(x => x.username == username);
            if (user != null)
                return true;
            return false;
        }

        public bool CheckEmail(string email)
        {
            int cout = db.KHACHHANGs.Where(x => x.email == email).Count();
            if (cout > 0)
                return true;
            return false;
        }
    }
}
