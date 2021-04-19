using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Models.EntityFramework;
using Models.DAO;

namespace WebBanQuanAo.Areas.Admin.Controllers
{
    public class LoaiAoController : Controller
    {
        // GET: Admin/LoaiAo
        public ActionResult Index(string searchStr, int page = 1, int pageSize = 8)
        {
            var ls = new LoaiAoDao().GetByStr(searchStr, page, pageSize);
            ViewBag.searchStr = searchStr;
            return View(ls);
        }

        // GET: Admin/LoaiAo/Details/5
        public ActionResult Details(int id)
        {
            return View(new LoaiAoDao().ViewDetail(id));
        }

        // GET: Admin/LoaiAo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiAo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LOAIAO lA)
        {
            var dao = new LoaiAoDao();
            lA.metatitle = Common.Utility.ConvertTitle(lA.loaiao1);
            lA.link = "/" + Common.Utility.ConvertTitle(lA.metatitle);

            int res = dao.Insert(lA);

            if (res > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(" ", "Thêm thất bại");
            }
            return View();
        }

        // GET: Admin/LoaiAo/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new LoaiAoDao().ViewDetail(id));
        }

        // POST: Admin/LoaiAo/Edit/5
        [HttpPost]
        public ActionResult Edit(LOAIAO lA)
        {
            var dao = new LoaiAoDao();
            lA.metatitle = Common.Utility.ConvertTitle(lA.loaiao1);
            lA.link = "/" + lA.metatitle;

            if (dao.Update(lA))
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError(" ", "Sửa thất bại");
            }
            return View();
        }

        // GET: Admin/LoaiAo/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new LoaiAoDao().ViewDetail(id));
        }

        // POST: Admin/LoaiAo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var dao = new LoaiAoDao();
            if (dao.Delete(id) == true)
                return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError("", "Xóa thất bại");
            }
            return View();
        }

        
    }
}
