﻿using Client.BLL.Common;
using Client.GUI.Common;
using Client.Model;
using Client.Module;
using DevExpress.XtraGrid.Views.Grid;
using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUI.DanhMuc
{
    public partial class frmKhachHang_List : frmBase
    {
        public frmKhachHang_List()
        {
            InitializeComponent();
        }
        protected override void frmBase_Load(object sender, EventArgs e)
        {
            clsGeneral.CallWaitForm(this);
            base.frmBase_Load(sender, e);
            LoadData(0);
            CustomForm();
            clsGeneral.CloseWaitForm();
        }

        public async override void LoadData(object KeyID)
        {
            gctDanhSach.DataSource = await clsFunction.GetItemsAsync<eKhachHang>("KhachHang/GetAll");

            if ((int)KeyID > 0)
                gctDanhSach.BeginInvoke(new Action(async () => { grvDanhSach.FocusedRowHandle = await gctDanhSach.RunMethodAsync(() => { return grvDanhSach.LocateByValue("KeyID", KeyID); }); }));
        }
        public override void CustomForm()
        {
            base.CustomForm();

            DisableEvents();
            EnableEvents();
        }
        public override void EnableEvents()
        {
            gctDanhSach.MouseClick += gctDanhSach_MouseClick;
            grvDanhSach.DoubleClick += GrvDanhSach_DoubleClick;
        }
        public override void DisableEvents()
        {
            gctDanhSach.MouseClick -= gctDanhSach_MouseClick;
            grvDanhSach.DoubleClick -= GrvDanhSach_DoubleClick;
        }
        public override void InsertEntry()
        {
            frmKhachHang frm = new frmKhachHang() { MsgAdd = "Thêm mới khách hàng", MsgEdit = "Cập nhật khách hàng", FormBorderStyle = FormBorderStyle.FixedSingle, MinimizeBox = false, MaximizeBox = false };
            frm.Text = frm.MsgAdd;
            frm._ReloadData = LoadData;
            frm.ShowDialog();
        }
        public override void UpdateEntry()
        {
            frmKhachHang frm = new frmKhachHang() { MsgAdd = "Thêm mới khách hàng", MsgEdit = "Cập nhật khách hàng", FormBorderStyle = FormBorderStyle.FixedSingle, MinimizeBox = false, MaximizeBox = false };
            frm._iEntry = (eKhachHang)grvDanhSach.GetFocusedRow();
            frm.Text = frm.MsgEdit;
            frm._ReloadData = LoadData;
            frm.ShowDialog();
        }
        public override void DeleteEntry()
        {

        }
        public override void RefreshEntry()
        {
            LoadData(0);
        }

        private void GrvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            UpdateEntry();
        }
        private void gctDanhSach_MouseClick(object sender, MouseEventArgs e)
        {
            ShowGridPopup(sender, e, true, false, true, true, true, true);
        }
    }
}
