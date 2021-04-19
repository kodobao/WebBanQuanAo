using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Models.DAO;

namespace WebBanQuanAo.Areas.Admin.Controllers
{
    public class ChiTietDatHangController : Controller
    {
        // GET: Admin/ChiTietDatHang
        public ActionResult Index(int? searchStr, int page=1, int pageSize=8 )
        {
            var ls = new ChiTietDatHangDao().GetByStr(searchStr, page, pageSize);
            ViewBag.searchStr = searchStr;
            return View(ls);
        }

        //// GET: Admin/ChiTietDatHang/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var ls = new ChiTietDatHangDao().GetByCatagory(id);
            return View(ls);
        }

        // GET: Admin/ChiTietDatHang/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(new ChiTietDatHangDao().Delete(id));
        }

        // POST: Admin/ChiTietDatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
