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
                IEnumerable<xFeature> features = db.xFeature.ToList();
                features = features.Where(x => !string.IsNullOrWhiteSpace(x.Template));

                var q = features.GroupBy(x => x.Template).Select(x => new { Template = x.Key }).ToList();

                int i = 1;
                q.ForEach(x => routes.MapRoute($"Default{i++}", $"{{controller}}/{{action}}/{x.Template}"));
            }
            catch (Exception ex)
            {
            }
        }
        static void MapRouteDefault(RouteCollection routes)
        {
            routes.MapRoute("Default", "{controller}/{action}", new { controller = "Module", action = "TimeServer" });
        }
    }
}
