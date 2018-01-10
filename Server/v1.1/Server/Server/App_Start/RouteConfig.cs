using EntityModel.DataModel;
using Server.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Server
{
    public class RouteConfig
    {
        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    routes.MapRoute(
        //        name: "Default",
        //        url: "{controller}/{action}",
        //        defaults: new { controller = "Module", action = "TimeServer" }
        //    );
        //}

        public static void RegisterRoutes(RouteCollection routes)
        {
            IgnoreRoute(routes);
            MapRoute(routes);
            MapRouteDefault(routes);
        }

        static void IgnoreRoute(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        }
        static void MapRoute(RouteCollection routes)
        {
            try
            {
                aModel db = new aModel();
                IEnumerable<xQuyen> lstQuyens = db.xQuyen.Where(x => !x.MacDinh);
                lstQuyens = lstQuyens.Where(x => !string.IsNullOrWhiteSpace(x.Template));

                int i = 0;
                lstQuyens.ToList().ForEach(x =>
                {
                    //string name = $"Route{i++}";
                    //string url = $"{{controller}}/{{action}}/{x.Template}";
                    //routes.MapRoute(name, url);

                    string name = $"Route{i++}";
                    string url = $"{x.Path}";
                    routes.MapRoute(name, url, new { controller = x.Controller, action = x.Action }, new string[] { "Server.Controllers" });
                });
            }
            catch { }
        }
        static void MapRouteDefault(RouteCollection routes)
        {
            routes.MapRoute("Default", "{controller}/{action}", new { controller = "Module", action = "TimeServer" });
        }
    }
}
