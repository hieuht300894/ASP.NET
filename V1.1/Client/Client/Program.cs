using Client.GUI.Common;
using Client.Module;
using EntityModel.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoadSetting();
            LoadApplication();
        }
        static void LoadSetting()
        {
            try
            {
                string dir = @"Config";
                string path = $@"{dir}\LoginSetting.xml";
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string text = sr.ReadToEnd();
                        UserSetting info = text.DeserializeXMLToObject<UserSetting>() ?? new UserSetting();

                        ModuleHelper.Domain = info.Domain;
                        ModuleHelper.Port = info.Port;
                        ModuleHelper.Template = info.Template;
                        ModuleHelper.Url = info.Url;
                    }
                }
            }
            catch
            {
                ModuleHelper.Domain = string.Empty;
                ModuleHelper.Port = string.Empty;
                ModuleHelper.Template = string.Empty;
                ModuleHelper.Url = string.Empty;
            }
        }
        static void LoadApplication()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.SkinName);
            //DevExpress.Utils.AppearanceObject.DefaultFont = Properties.Settings.Default.FontFormat;
            Application.Run(new frmMain());
        }
    }
}
