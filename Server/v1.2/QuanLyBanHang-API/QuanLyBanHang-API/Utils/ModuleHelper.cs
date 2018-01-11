using System;
using System.Data.Entity;
using System.Web.Http;

namespace QuanLyBanHang_API.Utils
{
    public class ModuleHelper
    {
        //public static String ConnectionString { get; set; } = "Data Source=.;Initial Catalog=QuanLyBanHangModel;Integrated Security=True;MultipleActiveResultSets=True";
        public static String ConnectionString { get; set; } = string.Empty;
        public static HttpConfiguration HttpConfiguration { get; set; }
    }
}
