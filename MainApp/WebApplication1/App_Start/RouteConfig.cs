using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GetAll",
                url: "Product/GetAll"
            );

            routes.MapRoute(
                name: "CreateProduct",
                url: "Product/CreateProduct"
            );

            routes.MapRoute(
                name: "EditProduct",
                url: "Product/EditProduct/{id}"
            );

            routes.MapRoute(
                name: "Contact",
                url: "Contact/ContactForm"
            );

            routes.MapRoute(
                name: "Login",
                url: "Login/LoginForm"
            );
        }
    }
}
