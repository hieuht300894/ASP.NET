using System.Web.Http;

namespace QuanLyBanHang_API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(Startup.Register);
        }
    }
}
