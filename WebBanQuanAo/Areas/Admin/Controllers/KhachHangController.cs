using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Models.EntityFramework;
using Models.DAO;

namespace WebBanQuanAo.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        
        // GET: Admin/KhachHang
        public ActionResult Index(string searchStr, int page = 1, int pageSize = 8)
        {
            var ls = new KhachHangDao().GetByStr(searchStr, page, pageSize);
            ViewBag.searchStr = searchStr;


            return View(ls);
        }

        // GET: Admin/KhachHang/Details/5
        public ActionResult Details(int id)
        {
            return View(new KhachHangDao().ViewDetail(id));
        }

        // GET: Admin/KhachHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new KhachHangDao().ViewDetail(id));
        }

        // POST: Admin/KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (new KhachHangDao().Delete(id) == true)
                return RedirectToAction("Index");
            return View();
        }
    }
}
