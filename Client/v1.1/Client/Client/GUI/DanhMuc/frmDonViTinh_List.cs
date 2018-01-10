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
    public partial class frmDonViTinh_List : frmBase
    {
        public frmDonViTinh_List()
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
            gctDanhSach.DataSource = await clsFunction.GetItemsAsync<eDonViTinh>("DonViTinh/GetAll");

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
            frmDonViTinh frm = new frmDonViTinh() { MsgAdd = "Thêm mới đơn vị tính", MsgEdit = "Cập nhật đơn vị tính", FormBorderStyle = FormBorderStyle.FixedSingle, MinimizeBox = false, MaximizeBox = false };
            frm.Text = frm.MsgAdd;
            frm._ReloadData = LoadData;
            frm.ShowDialog();
        }
        public override void UpdateEntry()
        {
            frmDonViTinh frm = new frmDonViTinh() { MsgAdd = "Thêm mới đơn vị tính", MsgEdit = "Cập nhật đơn vị tính", FormBorderStyle = FormBorderStyle.FixedSingle, MinimizeBox = false, MaximizeBox = false };
            frm._iEntry = (eDonViTinh)grvDanhSach.GetFocusedRow();
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
