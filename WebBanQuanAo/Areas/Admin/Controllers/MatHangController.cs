using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Models.EntityFramework;
using Models.DAO;

namespace WebBanQuanAo.Areas.Admin.Controllers
{
    public class MatHangController : Controller
    {
        // GET: Admin/MatHang
        public ActionResult Index(string searchStr, int page = 1, int pageSize = 8)
        {
            var ls = new MatHangDao().GetByStr(searchStr, page, pageSize);
            ViewBag.searchStr = searchStr;
            return View(ls);
        }

        // GET: Admin/MatHang/Details/5
        public ActionResult Details(int id)
        {
            return View(new MatHangDao().ViewDetail(id));
        }

        // GET: Admin/MatHang/Create
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        // POST: Admin/MatHang/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MATHANG mh )
        {
            var dao = new MatHangDao();
            mh.ngaynhap = DateTime.Now;
            mh.tenhang = Common.Utility.VietHoa(mh.tenhang);
            string tenhang = mh.tenhang.ToLower();
            //string mausac = mh.mausac.ToLower();
            mh.metatitle = Common.Utility.ConvertTitle(tenhang);


            int rs = dao.Insert(mh);
            if (rs > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Admin/MatHang/Edit/5
        public ActionResult Edit(int id)
        {
            SetViewBag();
            return View(new MatHangDao().ViewDetail(id));
        }

        // POST: Admin/MatHang/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MATHANG mh)
        {
            var dao = new MatHangDao();
            //mh.ngaynhap = DateTime.Now;
            string tenhang = mh.tenhang.ToLower();
            mh.metatitle = Common.Utility.ConvertTitle(tenhang);
           
            if (dao.Update(mh))
                return RedirectToAction("Index");
            else
                ModelState.AddModelError("", "Cập nhật thất bại");
            return View();
        }

        // GET: Admin/MatHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new MatHangDao().ViewDetail(id));
        }

        // POST: Admin/MatHang/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var dao = new MatHangDao();
            if (dao.Delete(id))
            {
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Xóa thất bại");

            return View();
        }

        public void SetViewBag(int? selectedId = null)
        {
            var dao = new LoaiHangDao();
            ViewBag.MaLoaiHang = new SelectList(dao.GetAll(), "ma", "loai", selectedId);
        }
    }
}
