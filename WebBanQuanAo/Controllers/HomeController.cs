using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Models.DAO;
using PagedList;

namespace WebBanQuanAo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int page=1)
        {
            var dao = new MatHangDao();
            var ls = dao.GetAll();
            int pageSize = 12;
            
            return View(ls.ToPagedList(page, pageSize));
        }

        [ChildActionOnly]
        public PartialViewResult Slide ()
        {
            ViewBag.AoDoiTuyen = new MatHangDao().GetByCategory(1);
            ViewBag.AoCauLacBo = new MatHangDao().GetByCategory(2);
            ViewBag.AoTuChon = new MatHangDao().GetAll();
            ViewBag.AoKhuyenMai = new MatHangDao().GetByFree(2);

            return PartialView("_Slide");
        }

        public ActionResult Error ()
        {
            Response.StatusCode = 404;
            return View("Error");
        }


        
    }
}