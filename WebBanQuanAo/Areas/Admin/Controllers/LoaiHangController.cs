using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Models.DAO;
using Models.EntityFramework;

namespace WebBanQuanAo.Areas.Admin.Controllers
{
    public class LoaiHangController : Controller
    {
        // GET: Admin/LoaiHang
        public ActionResult Index(string searchStr, int page=1, int pageSize = 8)
        {
            var ls = new LoaiHangDao().GetByStr(searchStr, page, pageSize);
            ViewBag.searchStr = searchStr;

            return View(ls);
        }

        // GET: Admin/LoaiHang/Details/5
        public ActionResult Details(int id)
        {
            return View(new LoaiHangDao().ViewDetail(id));
        }

        // GET: Admin/LoaiHang/Create
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        // POST: Admin/LoaiHang/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LOAIHANG lh)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiHangDao();
                string tenloaihang = Common.Utility.ChangeChar(lh.loai);
                lh.link = "/" + Common.Utility.ConvertTitle(tenloaihang);

                if (dao.Insert(lh) > 0)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError("", "Thêm thất bại");
            }

            return View();
        }

        // GET: Admin/LoaiHang/Edit/5
        public ActionResult Edit(int id)
        {
            var ls = new LoaiHangDao().ViewDetail(id);
            SetViewBag();
            return View(ls);
        }

        // POST: Admin/LoaiHang/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LOAIHANG lh)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiHangDao();
                string tenloaihang = Common.Utility.ChangeChar(lh.loai);
                lh.link = "/" + Common.Utility.ConvertTitle(tenloaihang);
                if (dao.Update(lh) == true)
                {
                    return RedirectToAction("Index");
                }
                else
                    ModelState.AddModelError("", "Thêm thất bại");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete (int id)
        {
            var lh = new LoaiHangDao().ViewDetail(id);
            if (lh == null)
                return HttpNotFound("Error");
            return View(lh);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)   // route nhận id ---> tên biến phải trùng với tên trong RouteConfig
        {
            if (new LoaiHangDao().Delete(id))
                return RedirectToAction("Index");
            else
                ModelState.AddModelError("", "Xóa thất bại");
            return View("Error");
        }

        public void SetViewBag(int? selectedId = null)
        {
            var dao = new LoaiAoDao();
            ViewBag.MaLoaiAo = new SelectList(dao.GetAll(), "ma", "loaiao1", selectedId);
        }
    }
}
