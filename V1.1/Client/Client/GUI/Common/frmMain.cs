using Client.Module;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Internal;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

                ShowLogin();

            });
        }
        void AddDocument(string bbiName)
        {
            //FormItem fi = clsCallForm.FindForm(bbiName);
            //if (fi != null)
            //{
            //    XtraForm _xtraForm = fi.xForm;
            //    BaseDocument document = tbvMain.Documents.FirstOrDefault(x => x.Control.Name.Equals(_xtraForm.Name));

            //    if (document != null)
            //        tbvMain.Controller.Activate(document);
            //    else
            //    {
            //        Action<XtraForm, XtraForm> act1 = async (f1, f2) =>
            //        {
            //            Action<XtraForm, XtraForm> act2 = (f3, f4) =>
            //            {
            //                try
            //                {
            //                    Action<XtraForm, XtraForm> act3 = (f5, f6) =>
            //                    {
            //                        clsGeneral.CallWaitForm(f5);
            //                        f6.MdiParent = f5;
            //                        f6.Show();
            //                        clsGeneral.CloseWaitForm();
            //                    };
            //                    f3.Invoke(act3, f3, f4);
            //                }
            //                catch (Exception ex)
            //                {
            //                    clsGeneral.CloseWaitForm();
            //                    clsGeneral.showErrorException(ex);
            //                }
            //            };
            //            await Task.Factory.StartNew(() => act2(f1, f2));
            //        };
            //        Invoke(new Action(() => act1(this, _xtraForm)));
            //    }
            //}


            //BaseDocument document = tbvMain.Documents.FirstOrDefault(x => x.Control.Name.Equals(_xtrForm.Name));

            //if (document != null)
            //    tbvMain.Controller.Activate(document);
            //else
            //{
            //    _xtrForm.MdiParent = this;
            //    _xtrForm.Show();
            //}

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
