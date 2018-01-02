using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;

namespace Client.Module
{
    public class ModuleHelper
    {
        public static List<FormItem> ListFormItem { get; set; } = new List<FormItem>();
        public static string Domain { get; set; } = "http://localhost";
        public static string Port { get; set; } = "5000";
        public static string Path { get; set; } = "API";
        public static string Url { get; set; } = $"{Domain}:{Port}/{Path}";
    }

    public class FormItem
    {
        public XtraForm xForm { get { return (XtraForm)Activator.CreateInstance(fType); } }
        public string Name { get; set; }
        public Type fType { get; set; }
    }
}
