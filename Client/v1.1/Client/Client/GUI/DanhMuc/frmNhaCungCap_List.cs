using Client.BLL.Common;
using Client.GUI.Common;
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
    public partial class frmNhaCungCap_List : frmBase
    {
        public frmNhaCungCap_List()
        {
            InitializeComponent();
        }
        protected override  void frmBase_Load(object sender, EventArgs e)
        {
            clsGeneral.CallWaitForm(this);
            base.frmBase_Load(sender, e);
            LoadData(0);
            CustomForm();
            clsGeneral.CloseWaitForm();
        }

        public async override void LoadData(object KeyID)
        {
            gctDanhSach.DataSource =await clsFunction.GetItemsAsync<eNhaCungCap>("NhaCungCap/GetAll");

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
            frmNhaCungCap frm = new frmNhaCungCap() { MsgAdd = "Thêm mới nhà cung cấp", MsgEdit = "Cập nhật nhà cung cấp", FormBorderStyle = FormBorderStyle.FixedSingle, MinimizeBox = false, MaximizeBox = false };
            frm.Text = frm.MsgAdd;
            frm._ReloadData = LoadData;
            frm.ShowDialog();
        }
        public override void UpdateEntry()
        {
            frmNhaCungCap frm = new frmNhaCungCap() { MsgAdd = "Thêm mới nhà cung cấp", MsgEdit = "Cập nhật nhà cung cấp", FormBorderStyle = FormBorderStyle.FixedSingle, MinimizeBox = false, MaximizeBox = false };
            frm._iEntry = (eNhaCungCap)grvDanhSach.GetFocusedRow();
            frm.Text = frm.MsgEdit;
            frm._ReloadData = LoadData;
            frm.ShowDialog();
        }
        public override void DeleteEntry()
        {

        }
        public override  void RefreshEntry()
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
