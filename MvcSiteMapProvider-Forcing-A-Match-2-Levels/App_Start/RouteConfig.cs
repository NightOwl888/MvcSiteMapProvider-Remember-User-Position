using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcSiteMapProvider_Forcing_A_Match_2_Levels
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //****************************** Custom Routes *********************************************

            // NOTE: These routes will fix the URLs to make them look more like "normal" MVC URLs. However,
            // it is also possible to use the default route, in which case the parameters will be part of the
            // URL query string instead of the path. You can comment out these 2 routes to see what effect it has.

            routes.MapRoute(
                name: "ProductOption",
                url: "{controller}/{action}/{productId}/{productOptionId}",
                defaults: new { controller = "ProductOption", productOptionId = UrlParameter.Optional },
                constraints: new { controller = @"[Pp]roduct[Oo]ption" }
            );

            routes.MapRoute(
                name: "Product",
                url: "{controller}/{action}/{productId}",
                defaults: new { controller = "Product", productId = UrlParameter.Optional },
                constraints: new { controller = @"[Pp]roduct" }
            );

            //****************************** End Custom Routes *****************************************

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}