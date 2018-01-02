using Server.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Server.Utils
{
    public class ModuleHelper
    {
        //public static String ConnectionString { get; set; } = "Data Source=.;Initial Catalog=QuanLyBanHangModel;Integrated Security=True;MultipleActiveResultSets=True";
        public static String ConnectionString { get; set; } = string.Empty;
        public static void InitDatabase()
        {
            aModel db = new aModel();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<aModel, MyConfiguration>());
            db.Database.Initialize(false);
        }
    }
}
