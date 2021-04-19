using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanQuanAo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Error",
                url: "loi",
                defaults: new { controller = "Error", action = "Home", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanQuanAo.Controllers" }
            );

            routes.MapRoute(
                name: "Success",
                url: "hoan-thanh",
                defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanQuanAo.Controllers" }
            );

            routes.MapRoute(
                name: "UpdateCart",
                url: "cap-nhat",
                defaults: new { controller = "Cart", action = "UpdateCart", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanQuanAo.Controllers" }
            );

            //routes.MapRoute(
            //    name: "UpdateCart",
            //    url: "cap-nhat",
            //    defaults: new { controller = "Cart", action = "UpdateCart", id = UrlParameter.Optional, soluong = UrlParameter.Optional },
            //    namespaces: new[] { "WebBanQuanAo.Controllers" }
            //);

            routes.MapRoute(
                name: "Checkout",
                url: "thanh-toan",
                defaults: new { controller = "Cart", action = "Checkout", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanQuanAo.Controllers" }
            );

            routes.MapRoute(
                name: "ConutineShopping",
                url: "tiep-tuc-mua",
                defaults: new { controller = "Cart", action = "ContinueShopping", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanQuanAo.Controllers" }
            );

            routes.MapRoute(
                name: "DeleteItemCart",
                url: "xoa-san-pham/{id}",
                defaults: new { controller = "Cart", action = "DeleteItemCart", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanQuanAo.Controllers" }
            );

            routes.MapRoute(
                name: "DeleteCart",
                url: "huy-gio-hang",
                defaults: new { controller = "Cart", action = "DeleteCart", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanQuanAo.Controllers" }
            );

            routes.MapRoute(
                name: "AddItemCart",
                url: "them-gio-hang",
                defaults: new { controller = "Cart", action = "AddItemCart", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanQuanAo.Controllers" }
            );

            routes.MapRoute(
                name: "Cart",
                url: "gio-hang",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanQuanAo.Controllers" }
            );

            routes.MapRoute(
                name: "Detail",
                url: "xem-chi-tiet/{title}/{id}",
                defaults: new { controller = "Product", action = "ViewDetail", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanQuanAo.Controllers" }
            );

            routes.MapRoute(
                name: "CategoryTpye",
                url: "loai-hang",
                defaults: new { controller = "Product", action = "CategoryType", id = UrlParameter.Optional, page = UrlParameter.Optional },
                namespaces: new[] { "WebBanQuanAo.Controllers" }
            );

            routes.MapRoute(
                name: "TypeCategory",
                url: "loai-ao",
                defaults: new { controller = "Product", action = "TypeCategory", id = UrlParameter.Optional, page = UrlParameter.Optional },
                namespaces: new[] { "WebBanQuanAo.Controllers" }
            );

            routes.MapRoute(
                name: "History",
                url: "lich-su-giao-dich",
                defaults: new { controller = "Account", action = "History", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanQuanAo.Controllers" }
            );

            routes.MapRoute(
                name: "Register",
                url: "dang-ky",
                defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanQuanAo.Controllers" }
            );

            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanQuanAo.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebBanQuanAo.Controllers"}
            );
        }
    }
}
