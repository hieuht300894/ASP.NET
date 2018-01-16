using QuanLyBanHang_API.Utils;
using System.Data.Entity;
using System.Net.Http.Formatting;
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
            container.RegisterType(typeof(IRepositoryCollection), typeof(RepositoryCollection));
            config.DependencyResolver = new UnityResolver(container);

            RegisterRoute();
            RegisterDatabase();
            RegisterFormat();
            RegisterAuthentication();
        }
        public static void RegisterRoute()
        {
            //ModuleHelper.HttpConfiguration.MapHttpAttributeRoutes();
            ModuleHelper.HttpConfiguration.Routes.MapHttpRoute("Default", "{controller}/{action}", new { controller = "Module", action = "TimeServer" });
        }
        public static void RegisterDatabase()
        {
            //aModel db = (aModel)ModuleHelper.HttpConfiguration.DependencyResolver.GetService(typeof(aModel));
            aModel db = new aModel();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<aModel, MyConfiguration>());
            db.Database.Initialize(false);
        }
        public static void RegisterFormat()
        {
            ModuleHelper.HttpConfiguration.Formatters.Remove(ModuleHelper.HttpConfiguration.Formatters.XmlFormatter);
            ModuleHelper.HttpConfiguration.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;
            ModuleHelper.HttpConfiguration.Formatters.JsonFormatter.MaxDepth = int.MaxValue;
        }
        public static void RegisterAuthentication()
        {
            ModuleHelper.HttpConfiguration.Filters.Add(new CustomAuthorizeAttribute());  
        }
    }
}