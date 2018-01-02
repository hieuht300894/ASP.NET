using Server.Model;
using Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server
{
    public class DatabaseConfig
    {
        public static void RegisterDatabase()
        {
            ModuleHelper.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["QuanLyBanHangModel"].ConnectionString;
            ModuleHelper.InitDatabase();
        }
    }
}