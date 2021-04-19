using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Models.DAO;
using Models.EntityFramework;
using WebBanQuanAo.Common;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDao();
                int res = dao.Login(user.UserName, user.Password.ToMD5());

                if (res == 1)
                {
                    var Acc = dao.GetByUser(user.UserName);
                    var USER = new UserLogin() { UserID = Acc.ma, UserName = Acc.username };
                    Session.Add(Common.CommonContants.USER_SESSION, USER);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (res == 0)
                    {
                        ModelState.AddModelError("", "Tài khoản không tồn tại");
                    }
                    else if (res == -1)
                    {
                        ModelState.AddModelError(" ", "Tài khoản bị khóa");
                    }
                    else if (res == -2)
                    {
                        ModelState.AddModelError(" ", "Sai mật khẩu");
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel user)
        {
            if (ModelState.IsValid)
            {
                var res = new KhachHangDao();
                if (res.CheckUser(user.username))
                {
                    ModelState.AddModelError(" ", "Tài khoản đã tồn tại");
                }
                else if (res.CheckEmail(user.email))
                {
                    ModelState.AddModelError(" ", "Email đã tồn tại");
                }
                else
                {
                    var User = new KHACHHANG();
                    User.tenkhachhang = Utility.VietHoa(user.tenkhachhang);
                    User.password = user.password.ToMD5();
                    User.trangthai = 1;
                    User.username = user.username;
                    User.email = user.email;
                    User.dienthoai = user.dienthoai;
                    User.diachi = Utility.VietHoa(user.diachi);

                    if (res.Insert(User) > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(" ", "Đăng ký thất bại");
                    }
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session[Common.CommonContants.USER_SESSION] = null;
            return Redirect("/");
        }

        public ActionResult History()
        {
            var user = (UserLogin)Session[CommonContants.USER_SESSION];

            if (user != null)
            {
                List<HistoryModel> lsDS = new List<HistoryModel>();
                foreach(var item in new ChiTietDatHangDao().GetByObj(user.UserID))
                {
                    HistoryModel hs = new HistoryModel();
                    hs.SanPham = item.SanPham;
                    hs.SoLuong = item.SoLuong;
                    hs.NgayDat = item.NgayDat;
                    hs.TrangThai = item.TrangThai;
                    hs.Gia = item.Gia;

                    lsDS.Add(hs);
                }

                return View(lsDS.OrderByDescending(x => x.NgayDat).ToList());
            }

            return Redirect("/dang-nhap");
        }

        
    }
}