using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebBanQuanAo.Areas.Admin.Models;
using Models.DAO;
using Models.EntityFramework;
using WebBanQuanAo.Common;

namespace WebBanQuanAo.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountModel acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                int res = dao.Login(acc.UserName, acc.Password.ToMD5());

                if (res == 1)
                {
                    Session[CommonContants.ADMIN_SESSION] = acc.UserName;
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
                        ModelState.AddModelError("", "Không được phép truy cập");
                    }
                    else if (res == -2)
                    {
                        ModelState.AddModelError("", "Sai mật khẩu");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng nhập thất bại");
                    }
                }

            }
            return View();
        }

        public ActionResult Logout()
        {
            Session[Common.CommonContants.ADMIN_SESSION] = null;
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAccount(QUANLY user)
        {
            return View();
        }
    }
}