﻿using DevExpress.XtraGrid.Views.Grid;
using EntityModel.DataModel;
using Client.BLL.Common;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.GUI.Common;
using Client.Module;
using System.Collections.Generic;

namespace Client.GUI.DanhMuc
{
    public partial class frmNhomKhachHang : frmBase
    {
        BindingList<eNhomKhachHang> lstEntries = new BindingList<eNhomKhachHang>();
        BindingList<eNhomKhachHang> lstEdited = new BindingList<eNhomKhachHang>();

        public frmNhomKhachHang()
        {
            InitializeComponent();
        }
        protected  override void frmBase_Load(object sender, EventArgs e)
        {
            //await RunMethodAsync(() => { clsGeneral.CallWaitForm(this); });
            //await RunMethodAsync(() => { base.frmBase_Load(sender, e); });
            //await RunMethodAsync(() => { LoadDataForm(); });
            //await RunMethodAsync(() => { CustomForm(); });
            //await RunMethodAsync(() => { clsGeneral.CloseWaitForm(); });

            //base.frmBase_Load(sender, e);
            //LoadDataForm();
            //CustomForm();
        }

        public override void LoadDataForm()
        {
            lstEdited = new BindingList<eNhomKhachHang>();
            lstEntries = new BindingList<eNhomKhachHang>(clsFunction.GetItems<eNhomKhachHang>("nhomkhachhang/getall"));
            gctDanhSach.DataSource = lstEntries;
        }
        public override bool ValidateData()
        {
            grvDanhSach.CloseEditor();
            grvDanhSach.UpdateCurrentRow();
            return base.ValidateData();
        }
        public override bool SaveData()
        {
            DateTime time = DateTime.Now.ServerNow();

            lstEdited.ToList().ForEach(x =>
            {
                if (x.KeyID > 0)
                {
                    x.NguoiCapNhat = clsGeneral.xNhanVien.KeyID;
                    x.MaNguoiCapNhat = clsGeneral.xNhanVien.Ma;
                    x.TenNguoiCapNhat = clsGeneral.xNhanVien.Ten;
                    x.NgayCapNhat = time;
                }
                else
                {
                    x.NguoiTao = clsGeneral.xNhanVien.KeyID;
                    x.MaNguoiTao = clsGeneral.xNhanVien.Ma;
                    x.TenNguoiTao = clsGeneral.xNhanVien.Ten;
                    x.NgayTao = time;
                }
            });

            Tuple<bool, List<eNhomKhachHang>> Res = clsFunction.Post("nhomkhachhang", lstEdited.ToList());
            return Res.Item1;
        }
        public override void CustomForm()
        {
            base.CustomForm();

            gctDanhSach.MouseClick += gctDanhSach_MouseClick;
            grvDanhSach.RowUpdated += grvDanhSach_RowUpdated;
        }

        private void gctDanhSach_MouseClick(object sender, MouseEventArgs e)
        {
            ShowGridPopup(sender, e, true, false, true, true, true, true);
        }
        private void grvDanhSach_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (!lstEdited.Any(x => x.KeyID == ((eNhomKhachHang)e.Row).KeyID)) lstEdited.Add((eNhomKhachHang)e.Row);
        }
    }
}
