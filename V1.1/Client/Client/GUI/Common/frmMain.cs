using Client.BLL.Common;
using Client.Module;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Internal;
using DevExpress.XtraEditors;
using EntityModel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUI.Common
{
    public partial class frmMain : XtraForm
    {
        #region Variable
        bool IsLogin = false;
        #endregion

        #region Form
        public frmMain()
        {
            InitializeComponent();

            Load -= FrmMain_Load;
            Load += FrmMain_Load;
        }
        #endregion

        #region Method
        async void LoadDataForm()
        {
            await Task.Factory.StartNew(() =>
            {
                clsGeneral.CallWaitForm(this);

                clsCallForm.InitFormCollection();
                AddItemClick();

                clsGeneral.CloseWaitForm();

                if (CheckConnect())
                    ShowLogin();
            });
        }
        void AddDocument(string bbiName)
        {
            clsGeneral.CallWaitForm(this);
            FormItem fi = clsCallForm.FindForm(bbiName);
            if (fi != null)
            {
                XtraForm _xtraForm = fi.xForm;
                BaseDocument document = tbvMain.Documents.FirstOrDefault(x => x.Control.Name.Equals(_xtraForm.Name));

                if (document != null)
                    tbvMain.Controller.Activate(document);
                else
                {
                    try
                    {
                        _xtraForm.MdiParent = this;
                        _xtraForm.Show();
                    }
                    catch (Exception ex)
                    {
                        clsGeneral.CloseWaitForm();
                        clsGeneral.showErrorException(ex);
                    }
                }
            }
            clsGeneral.CloseWaitForm();
        }
        async void AddItemClick()
        {
            // Duyệt từng page trong ribbon
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    BeginInvoke(new Action(() =>
                    {
                        rcMain.Hide();
                    }));

                    foreach (RibbonPage page in rcMain.Pages)
                    {
                        foreach (RibbonPageGroup group in page.Groups)
                        {
                            foreach (var item in group.ItemLinks)
                            {
                                if (item is BarButtonItemLink)
                                {
                                    BarButtonItemLink bbi = item as BarButtonItemLink;
                                    if (bbi.Item.Name.StartsWith("frm"))
                                    {
                                        bbi.Item.ItemClick -= bbi_ItemClick;
                                        bbi.Item.ItemClick += bbi_ItemClick;
                                    }
                                }
                            }
                        }
                    }
                });
            }
            catch { }
        }
        void ShowLogin()
        {
            frmLogin frm = new frmLogin();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                BeginInvoke(new Action(() =>
                {
                    rcMain.Show();
                    IsLogin = true;
                }));
            }
            else if (!IsLogin)
            {
                Application.Exit();
            }
        }
        bool CheckConnect()
        {
            try
            {
                string dir = @"Config";
                string path = $@"{dir}\UrlSetting.xml";
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string text = sr.ReadToEnd();
                        UrlSetting info = text.DeserializeXMLToObject<UrlSetting>() ?? new UrlSetting();

                        if (clsFunction.CheckConnect(info.Url))
                        {
                            ModuleHelper.Domain = info.Domain;
                            ModuleHelper.Port = info.Port;
                            ModuleHelper.Path = info.Path;
                            ModuleHelper.Url = info.Url;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
                else
                {
                    throw new Exception();
                }

                return true;
            }
            catch
            {
                ModuleHelper.Domain = string.Empty;
                ModuleHelper.Port = string.Empty;
                ModuleHelper.Path = string.Empty;
                ModuleHelper.Url = string.Empty;

                frmServer frm = new frmServer();
                return frm.ShowDialog() == DialogResult.OK;
            }
        }
        #endregion

        #region Event
        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadDataForm();
        }
        void bbi_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddDocument(e.Item.Name);
        }
        #endregion
    }
}
