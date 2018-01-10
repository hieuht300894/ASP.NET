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

namespace Client.GUI.DauKy
{
    public partial class frmTonKhoDauKy : frmBase
    {
        BindingList<eTonKhoDauKy> lstEntries = new BindingList<eTonKhoDauKy>();
        BindingList<eTonKhoDauKy> lstEdited = new BindingList<eTonKhoDauKy>();

        public frmTonKhoDauKy()
        {
            InitializeComponent();
        }
        protected  override void frmBase_Load(object sender, EventArgs e)
        {
            //await RunMethodAsync(() => { clsGeneral.CallWaitForm(this); });
            //await RunMethodAsync(() => { base.frmBase_Load(sender, e); });
            //await RunMethodAsync(() => { LoadRepository(); });
            //await RunMethodAsync(() => { LoadDataForm(); });
            //await RunMethodAsync(() => { CustomForm(); });
            //await RunMethodAsync(() => { clsGeneral.CloseWaitForm(); });

            //base.frmBase_Load(sender, e);
            //LoadRepository();
            //LoadDataForm();
            //CustomForm();
        }

        public void LoadRepository()
        {
            IList<eSanPham> lstSanPham = clsFunction.GetItems<eSanPham>("SanPham/getall");
            rlokSanPham.DataSource = lstSanPham;

            IList<eKho> lstKho = clsFunction.GetItems<eKho>("Kho/getall");
            rlokKho.DataSource = lstKho;
        }
        public  override void LoadDataForm()
        {
            lstEdited = new BindingList<eTonKhoDauKy>();
            lstEntries = new BindingList<eTonKhoDauKy>( clsFunction.GetItems<eTonKhoDauKy>("tonkhodauky/getall"));
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
            lstEdited.ToList().ForEach(x =>
            {
                eSanPham sanPham = (eSanPham)rlokSanPham.GetDataSourceRowByKeyValue(x.IDSanPham) ?? new eSanPham();
                x.MaSanPham = sanPham.Ma;
                x.TenSanPham = sanPham.Ten;

                x.IDDonViTinh = sanPham.IDDonViTinh;
                x.MaDonViTinh = sanPham.MaDonViTinh;
                x.TenDonViTinh = sanPham.TenDonViTinh;

                eKho kho = (eKho)rlokKho.GetDataSourceRowByKeyValue(x.IDKho) ?? new eKho();
                x.MaKho = kho.Ma;
                x.TenKho = kho.Ten;
            });

            Tuple<bool, List<eTonKhoDauKy>> Res = clsFunction.Post("tonkhodauky", lstEdited.ToList());
            return Res.Item1;
        }
        public override void CustomForm()
        {
            rlokKho.ValueMember = "KeyID";
            rlokKho.DisplayMember = "Ten";

            rlokSanPham.ValueMember = "KeyID";
            rlokSanPham.DisplayMember = "Ten";

            base.CustomForm();
            gctDanhSach.MouseClick += gctDanhSach_MouseClick;
            grvDanhSach.RowUpdated += grvDanhSach_RowUpdated;
            grvDanhSach.InitNewRow += grvDanhSach_InitNewRow;
        }

        private void grvDanhSach_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GridView view = (GridView)sender;
            view.SetRowCellValue(e.RowHandle, colKeyID, -lstEdited.Count);
        }
        private void gctDanhSach_MouseClick(object sender, MouseEventArgs e)
        {
            ShowGridPopup(sender, e, true, false, true, true, true, true);
        }
        private void grvDanhSach_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (!lstEdited.Any(x => x.KeyID == ((eTonKhoDauKy)e.Row).KeyID)) lstEdited.Add((eTonKhoDauKy)e.Row);
        }
    }
}
