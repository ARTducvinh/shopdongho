using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace shopdongho
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Trangchu", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Register",
                url: "dang-ky",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "TrangChuDangNhap",
                url: "Index.html",
                defaults: new { controller = "TrangChuDangNhap", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] {"shopdongho.Web.Controller"}
            );
        }
    }
}
