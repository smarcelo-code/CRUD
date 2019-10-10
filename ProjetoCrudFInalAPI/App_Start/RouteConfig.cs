using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjetoCrudeFInalAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {
                    controller = "Personagens",
                    action = "Index",
                    id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "consulta_cep",
                "consulta-cep",
                new { Controller = "Cep", Action = "Index" }
                );
        }
    }
}
