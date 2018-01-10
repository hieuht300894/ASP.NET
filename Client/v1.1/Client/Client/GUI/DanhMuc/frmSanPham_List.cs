using DevExpress.XtraGrid.Views.Grid;
using EntityModel.DataModel;
using Client.BLL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.GUI.Common;
using Client.Module;

namespace Client.GUI.DanhMuc
{
    public partial class frmSanPham_List : frmBase
    {
        public frmSanPham_List()
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
            gctDanhSach.DataSource = await clsFunction.GetItemsAsync<eSanPham>("SanPham/GetAll");

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
            frmSanPham frm = new frmSanPham() { MsgAdd = "Thêm mới sản phẩm", MsgEdit = "Cập nhật sản phẩm", FormBorderStyle = FormBorderStyle.FixedSingle, MinimizeBox = false, MaximizeBox = false };
            frm.Text = frm.MsgAdd;
            frm._ReloadData = LoadData;
            frm.ShowDialog();
        }
        public override void UpdateEntry()
        {
            frmSanPham frm = new frmSanPham() { MsgAdd = "Thêm mới sản phẩm", MsgEdit = "Cập nhật sản phẩm", FormBorderStyle = FormBorderStyle.FixedSingle, MinimizeBox = false, MaximizeBox = false };
            frm._iEntry = (eSanPham)grvDanhSach.GetFocusedRow();
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
