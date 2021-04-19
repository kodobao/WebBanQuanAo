using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PagedList;
using Models.DAO;

namespace WebBanQuanAo.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult Category()
        {
            var dao = new LoaiHangDao();
            var ls = dao.GetAll();

            return PartialView("_Category", ls);
        }

        public ActionResult ViewDetail(int id)
        {
            var mathang = new MatHangDao().ViewDetail(id);
            ViewBag.lsSanPhamCungLoai = new MatHangDao().GetByCategory(id);

            return View(mathang);
        }

        public ActionResult CategoryType (int id, int page=1)
        {
            int pageSize = 6;
            ViewBag.Id = id;

            var ls = new MatHangDao().GetByType(id);

            return View(ls.ToPagedList(page, pageSize));
        }

        public ActionResult TypeCategory (int id, int page=1)
        {
            int pageSize = 6;
            ViewBag.Id = id;

            var ls = new MatHangDao().GetByCategory(id);

            return View(ls.ToPagedList(page, pageSize));
        }
    }
}