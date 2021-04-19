using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Models.DAO;
using Models.EntityFramework;
using WebBanQuanAo.Models;
using WebBanQuanAo.Common;
using System.Web.Script.Serialization;

namespace WebBanQuanAo.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart

        /// <summary>
        /// Giỏ hành
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var lsCart = Session[CommonContants.CART_SESSION];
            if (lsCart != null)
            {
                var ls = (List<WebBanQuanAo.Models.CartModel>)lsCart;
                ViewBag.Count = ls.Sum(x => x.SoLuong);
                Session[CommonContants.COUNT_CART_SESSION] = ls.Sum(x => x.SoLuong);

                double Total = 0;
                foreach (var item in ls)
                {
                    Total += item.TongTien();
                }
                ViewBag.Total = Total;
            }


            return View(lsCart);
        }

        /// <summary>
        /// Thêm sản phẩm
        /// </summary>
        /// <returns></returns>
        public ActionResult AddItemCart(int id)
        {
            var model = new MatHangDao().ViewDetail(id);
            var cartSession = Session[CommonContants.CART_SESSION];

            // Trường hợp giỏ hàng đã có sản phẩm
            if (cartSession != null)
            {
                var list = (List<CartModel>)cartSession;

                // Sản phầm đã tồn tại trong giỏ hàng
                if (list.Exists(n => n.SanPham.ma == id))
                {
                    foreach (var item in list)
                    {
                        if (item.SanPham.ma == id)
                        {
                            item.SoLuong = item.SoLuong + 1;
                        }

                    }
                }
                else  // Sản phẩm chưa có trong giỏ hàng
                {
                    var Item = new CartModel();
                    Item.SanPham = model;
                    Item.SoLuong = 1;
                    list.Add(Item);

                }

                Session[CommonContants.CART_SESSION] = list;
                Session[CommonContants.COUNT_CART_SESSION] = list.Sum(x => x.SoLuong);
            }
            else
            {
                //Trường hợp giỏ hàng chưa có gì 
                var Item = new CartModel();
                Item.SanPham = model;
                Item.SoLuong = 1;
                var list = new List<CartModel>();
                list.Add(Item);

                Session[CommonContants.CART_SESSION] = list;
                Session[CommonContants.COUNT_CART_SESSION] = list.Sum(x => x.SoLuong);
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        //public JsonResult UpdateCart(string cartModel)
        //{
        //    var jsonCart = new JavaScriptSerializer().Deserialize<List<CartModel>>(cartModel);
        //    var sessionCart = (List<CartModel>)Session[CommonContants.CART_SESSION];

        //    foreach (var item in sessionCart)
        //    {
        //        var jsonItem = jsonCart.SingleOrDefault(x => x.SanPham.ma == item.SanPham.ma);
        //        if (jsonItem != null)
        //        {
        //            item.SoLuong = jsonItem.SoLuong;
        //        }
        //    }
        //    Session[CommonContants.CART_SESSION] = sessionCart;
        //    return Json(new
        //    {
        //        status = true
        //    });
        //}

        public ActionResult Edit (int id, FormCollection f)
        {
            var cart = Session[CommonContants.CART_SESSION];
            var lsItem = (List<CartModel>)cart;
            var lsRev = new List<CartModel>();

            if (lsItem != null)
            {
                if (lsItem.Exists(x => x.SanPham.ma == id))
                {
                    foreach(var item in lsItem)
                    {
                        if (item.SanPham.ma == id)
                        {
                            int rex = int.Parse(f["SoLuong"].ToString());
                            if (rex < 0 || rex == 0)
                            {
                                lsRev.Add(item);
                            }
                            else
                                item.SoLuong = rex;
                        }
                    }

                    foreach(var item in lsRev)
                    {
                        lsItem.Remove(item);
                    }
                }
            }

            return Redirect("/gio-hang");
        }

        //public ActionResult UpdateCart (int id, int soluong)
        //{


        //    return RedirectToAction("Index", "Cart");
        //}

        public ActionResult DeleteItemCart(int id)
        {
            if (new MatHangDao().CheckId(id) == false)
            {
                Response.StatusCode = 404;
                return View("Error");
            }

            var model = Session[CommonContants.CART_SESSION];
            var ls = (List<WebBanQuanAo.Models.CartModel>)model;
            if (ls != null)
            {
                ls.RemoveAll(x => x.SanPham.ma == id);
                Session[CommonContants.CART_SESSION] = ls;
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteCart()
        {
            Session[CommonContants.CART_SESSION] = null;
            Session[CommonContants.COUNT_CART_SESSION] = null;
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Thanh toán
        /// </summary>
        /// <returns></returns>
        public ActionResult Checkout()
        {
            if (Session[CommonContants.USER_SESSION] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var lsCart = (List<WebBanQuanAo.Models.CartModel>)Session[CommonContants.CART_SESSION];
            if (lsCart == null)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                var us = (UserLogin)Session[CommonContants.USER_SESSION];

                var DDHdao = new DonDatHangDao();
                var dondathang = new DONDATHANG();
                dondathang.makhachhang = us.UserID;
                dondathang.noigiaohang = new KhachHangDao().ViewDetail(us.UserID).diachi;
                dondathang.ngaydathang = DateTime.Now;

                int res = new DonDatHangDao().Insert(dondathang);

                var CTHDdao = new ChiTietDatHangDao();
                foreach (var item in lsCart)
                {
                    var ctdh = new CHITIETDATHANG() { sohoadon = res, mahang = item.SanPham.ma, giaban = (double)item.SanPham.giaban, soluong = item.SoLuong };
                    if (!CTHDdao.Insert(ctdh))
                    {
                        ModelState.AddModelError("", "Lõi hệ thống");
                        //break;
                    }
                }
                Session[CommonContants.CART_SESSION] = null;
                Session[CommonContants.COUNT_CART_SESSION] = 0;

                return Redirect("/hoan-thanh");
            }
            catch (Exception)
            {
                return Redirect("/loi");
            }

        }

        public ActionResult ContinueShopping()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Success()
        {
            ViewBag.Success = "Bạn vừa mua hàng thành công";
            return RedirectToAction("Index", "Cart");
        }
    }
}