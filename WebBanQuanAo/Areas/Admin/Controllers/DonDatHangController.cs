using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Models.DAO;
using Models.EntityFramework;

namespace WebBanQuanAo.Areas.Admin.Controllers
{
    public class DonDatHangController : Controller
    {
        // GET: Admin/DonDatHang
        public ActionResult Index(int? searchStr, int page = 1, int pageSize = 8)
        {
            var ls = new DonDatHangDao().GetByStr(searchStr, page, pageSize);
            ViewBag.searchStr = searchStr;
            return View(ls);
        }

        // GET: Admin/DonDatHang/Details/5
        public ActionResult Details(int id)
        {
            return View(new DonDatHangDao().ViewDetail(id));
        }

        
        // GET: Admin/DonDatHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new DonDatHangDao().ViewDetail(id));
        }

        // POST: Admin/DonDatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (new DonDatHangDao().Delete(id))
                return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public ActionResult Update (int id)
        {
            return View(new DonDatHangDao().ViewDetail(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update (DONDATHANG ddh)
        {
            if (new DonDatHangDao().Update(ddh))
                return RedirectToAction("Index");
            return View();

        }
    }
}
