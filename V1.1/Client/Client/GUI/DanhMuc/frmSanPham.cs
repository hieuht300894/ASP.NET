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
    public partial class frmSanPham : frmBase
    {
        BindingList<eSanPham> lstEntries = new BindingList<eSanPham>();
        BindingList<eSanPham> lstEdited = new BindingList<eSanPham>();

        public frmSanPham()
        {
            InitializeComponent();
        }
        protected async override void frmBase_Load(object sender, EventArgs e)
        {
            await RunMethodAsync(() => { clsGeneral.CallWaitForm(this); });
            await RunMethodAsync(() => { base.frmBase_Load(sender, e); });
            await RunMethodAsync(() => { LoadRepository(); });
            await RunMethodAsync(() => { LoadDataForm(); });
            await RunMethodAsync(() => { CustomForm(); });
            await RunMethodAsync(() => { clsGeneral.CloseWaitForm(); });

            //base.frmBase_Load(sender, e);
            //LoadRepository();
            //LoadDataForm();
            //CustomForm();
        }

        async void LoadRepository()
        {
            IList<eDonViTinh> lstDVT = await clsFunction.GetItemsAsync<eDonViTinh>("donvitinh");
            await RunMethodAsync(() => { rlokDVT.DataSource = lstDVT; });
        }
        public override void LoadDataForm()
        {
            lstEdited = new BindingList<eSanPham>();
            lstEntries = new BindingList<eSanPham>(clsFunction.GetItems<eSanPham>("sanpham"));
            //     lstEntries.ToList().ForEach(x => { x.Color = Color.FromArgb(x.ColorHex); });

            gctDanhSach.DataSource = lstEntries;
        }
        public override bool ValidationForm()
        {
            grvDanhSach.CloseEditor();
            grvDanhSach.UpdateCurrentRow();
            return base.ValidationForm();
        }
        public override bool SaveData()
        {
            DateTime time = DateTime.Now.ServerNow();

            lstEdited.ToList().ForEach(x =>
            {
                eDonViTinh dvt = (eDonViTinh)rlokDVT.GetDataSourceRowByKeyValue(x.IDDonViTinh) ?? new eDonViTinh();
                x.MaDonViTinh = dvt.Ma;
                x.TenDonViTinh = dvt.Ten;

                x.MauSac = rpclr.ColorText.ToString();
                // x.ColorHex = x.Color.ToArgb();

                if (x.KeyID > 0)
                {
                    x.NguoiCapNhat = clsGeneral.curPersonnel.KeyID;
                    x.MaNguoiCapNhat = clsGeneral.curPersonnel.Ma;
                    x.TenNguoiCapNhat = clsGeneral.curPersonnel.Ten;
                    x.NgayCapNhat = time;
                }
                else
                {
                    x.NguoiTao = clsGeneral.curPersonnel.KeyID;
                    x.MaNguoiTao = clsGeneral.curPersonnel.Ma;
                    x.TenNguoiTao = clsGeneral.curPersonnel.Ten;
                    x.NgayTao = time;
                }
            });

            Tuple<bool, List<eSanPham>> Res = clsFunction.Post("sanpham", lstEdited.ToList());
            return Res.Item1;
        }
        public override void CustomForm()
        {
            rlokDVT.ValueMember = "KeyID";
            rlokDVT.DisplayMember = "Ten";

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
            if (!lstEdited.Any(x => x.KeyID == ((eSanPham)e.Row).KeyID)) lstEdited.Add((eSanPham)e.Row);
        }
    }
}
