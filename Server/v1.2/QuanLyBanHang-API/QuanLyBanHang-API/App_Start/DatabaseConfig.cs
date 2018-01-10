using Server.Utils;
using System.Web.Http;

namespace Server
{
    public class DatabaseConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ModuleHelper.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["QuanLyBanHangModel"].ConnectionString;
            ModuleHelper.InitDatabase();
        }
    }
}