using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OlxaWeb.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");





            //
            //routes.MapRoute(
            //    name: null,
            //    url: "Page{page}",
            //    defaults: new { controller = "Blog", action = "Index"});



            routes.MapRoute(
                name: "Develop",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            //новые

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Blog", action = "Index", category = (string)null },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(null,
                "{category}",
                new { controller = "Blog", action = "Index", page = 1 }
            );

            routes.MapRoute(null,
                "{category}/Page{page}",
                new { controller = "Blog", action = "Index" },
                new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");

        }
    }
}
