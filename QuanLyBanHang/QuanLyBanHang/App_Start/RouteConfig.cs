using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuanLyBanHang
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            _ = routes.MapRoute(
                name: "Product",
                url: "san-pham",
                defaults: new { controller = "Product", action = "Products", id = UrlParameter.Optional },
                namespaces: new[] { "QuanLyBanHang.Controllers" }
            );

            _ = routes.MapRoute(
                name: "ProductDetail",
                url: "san-pham/{Title}-{ID}",
                defaults: new { controller = "Product", action = "ProductDetails", id = UrlParameter.Optional },
                namespaces: new[] { "QuanLyBanHang.Controllers" }
            );

            _ = routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "QuanLyBanHang.Controllers" }
            );
        }
    }
}
