using QuanLyBanHang_API.Utils;
using System.Data.Entity;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace QuanLyBanHang_API
{
    public static class Startup
    {
        public static void Register(HttpConfiguration config)
        {
            ModuleHelper.HttpConfiguration = config;
            ModuleHelper.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["QuanLyBanHangModel"].ConnectionString;

            var container = new UnityContainer();
            container.RegisterType(typeof(aModel), new HierarchicalLifetimeManager());
            container.RegisterType(typeof(IRepositoryCollection), typeof(RepositoryCollection), new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            RegisterRoute();
            RegisterDatabase();
        }
        public static void RegisterRoute()
        {
            ModuleHelper.HttpConfiguration.MapHttpAttributeRoutes();
            ModuleHelper.HttpConfiguration.Routes.MapHttpRoute("Default", "{controller}/{action}", new { controller = "Module", action = "TimeServer" });
        }
        public static void RegisterDatabase()
        {
            aModel db = (aModel)ModuleHelper.HttpConfiguration.DependencyResolver.GetService(typeof(aModel));
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<aModel, MyConfiguration>());
            db.Database.Initialize(false);
        }
    }
}