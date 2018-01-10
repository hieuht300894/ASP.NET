using Client.BLL.Common;
using Client.GUI.Common;
using Client.Module;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUI.NhapHang
{
    public partial class frmNhapHangNhaCungCap_List : frmBase
    {
        public frmNhapHangNhaCungCap_List()
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
            gctDanhSach.DataSource = await clsFunction.GetItemsAsync<eNhapHangNhaCungCap>("NhapHangNhaCungCap/getall");
            if ((int)KeyID > 0)
                gctDanhSach.BeginInvoke(new Action(async () => { grvDanhSach.FocusedRowHandle = await gctDanhSach.RunMethodAsync(() => { return grvDanhSach.LocateByValue("KeyID", KeyID); }); }));
            gctChiTiet.DataSource = await this.RunMethodAsync(() => { return ((eNhapHangNhaCungCap)grvDanhSach.GetFocusedRow() ?? new eNhapHangNhaCungCap()).eNhapHangNhaCungCapChiTiet.ToList(); });
        }
        public override void InsertEntry()
        {
            frmNhapHangNhaCungCap frm = new frmNhapHangNhaCungCap() { MsgAdd = "Thêm mới phiếu nhập kho", MsgEdit = "Cập nhật phiếu nhập kho" };
            frm.Text = frm.MsgAdd;
            frm._ReloadData = LoadData;
            frm.ShowDialog();
        }
        public override void UpdateEntry()
        {
            frmNhapHangNhaCungCap frm = new frmNhapHangNhaCungCap() { MsgAdd = "Thêm mới phiếu nhập kho", MsgEdit = "Cập nhật phiếu nhập kho" };
            frm.Text = frm.MsgEdit;
            frm._iEntry = (eNhapHangNhaCungCap)grvDanhSach.GetFocusedRow();
            frm._ReloadData = LoadData;
            frm.ShowDialog();
        }
        public override void DeleteEntry()
        {

        }
        public override void RefreshEntry()
        {
            clsGeneral.CallWaitForm(this);
            LoadData(0);
            clsGeneral.CloseWaitForm();
        }
        public override void CustomForm()
        {
            RepositoryItemSpinEdit rspn = new RepositoryItemSpinEdit();
            RepositoryItemDateEdit rdte = new RepositoryItemDateEdit();

            rspn.Format();
            rdte.Format();

            grvDanhSach.Columns["SoLuong"].ColumnEdit = rspn;
            grvDanhSach.Columns["ThanhTien"].ColumnEdit = rspn;
            grvDanhSach.Columns["NoCu"].ColumnEdit = rspn;
            grvDanhSach.Columns["TongTien"].ColumnEdit = rspn;
            grvDanhSach.Columns["ThanhToan"].ColumnEdit = rspn;
            grvDanhSach.Columns["ConLai"].ColumnEdit = rspn;

            grvChiTiet.Columns["SoLuongSi"].ColumnEdit = rspn;
            grvChiTiet.Columns["SoLuongLe"].ColumnEdit = rspn;
            grvChiTiet.Columns["SoLuong"].ColumnEdit = rspn;
            grvChiTiet.Columns["DonGia"].ColumnEdit = rspn;
            grvChiTiet.Columns["ThanhTien"].ColumnEdit = rspn;
            grvChiTiet.Columns["VAT"].ColumnEdit = rspn;
            grvChiTiet.Columns["ChietKhau"].ColumnEdit = rspn;
            grvChiTiet.Columns["TongTien"].ColumnEdit = rspn;

            grvDanhSach.Columns["NgayNhap"].ColumnEdit = rdte;
            grvChiTiet.Columns["HanSuDung"].ColumnEdit = rdte;

            base.CustomForm();

            grvDanhSach.ShowFooter(grvDanhSach.VisibleColumns.ToArray());

            grvChiTiet.ShowFooter(
                grvChiTiet.Columns["SoLuongSi"], grvChiTiet.Columns["SoLuongLe"], grvChiTiet.Columns["SoLuong"],
                grvChiTiet.Columns["ThanhTien"], grvChiTiet.Columns["TongTien"]);

            DisableEvents();
            EnableEvents();
        }
        public override void DisableEvents()
        {
            gctDanhSach.MouseClick -= GctDanhSach_MouseClick;
            grvDanhSach.DoubleClick -= GrvDanhSach_DoubleClick;
            grvDanhSach.FocusedRowChanged -= GrvDanhSach_FocusedRowChanged;
        }
        public override void EnableEvents()
        {
            gctDanhSach.MouseClick += GctDanhSach_MouseClick;
            grvDanhSach.DoubleClick += GrvDanhSach_DoubleClick;
            grvDanhSach.FocusedRowChanged += GrvDanhSach_FocusedRowChanged;
        }

        private void GrvDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            eNhapHangNhaCungCap item = (eNhapHangNhaCungCap)grvDanhSach.GetRow(e.FocusedRowHandle) ?? new eNhapHangNhaCungCap();
            gctChiTiet.DataSource = item.eNhapHangNhaCungCapChiTiet.ToList();
        }
        private void GrvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            UpdateEntry();
        }
        private void GctDanhSach_MouseClick(object sender, MouseEventArgs e)
        {
            base.ShowGridPopup(sender, e, true, true, true, true, true, true);
        }
    }
}
