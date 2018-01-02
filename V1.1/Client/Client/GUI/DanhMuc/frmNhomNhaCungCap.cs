using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmNhomNhaCungCap : frmBase
    {
        BindingList<eNhomNhaCungCap> lstEntries = new BindingList<eNhomNhaCungCap>();
        BindingList<eNhomNhaCungCap> lstEdited = new BindingList<eNhomNhaCungCap>();

        public frmNhomNhaCungCap()
        {
            InitializeComponent();
        }
        protected async override void frmBase_Load(object sender, EventArgs e)
        {
            await RunMethodAsync(() => { clsGeneral.CallWaitForm(this); });
            await RunMethodAsync(() => { base.frmBase_Load(sender, e); });
            await RunMethodAsync(() => { LoadDataForm(); });
            await RunMethodAsync(() => { CustomForm(); });
            await RunMethodAsync(() => { clsGeneral.CloseWaitForm(); });

            //base.frmBase_Load(sender, e);
            //LoadDataForm();
            //CustomForm();
        }

        public override void LoadDataForm()
        {
            lstEdited = new BindingList<eNhomNhaCungCap>();
            lstEntries = new BindingList<eNhomNhaCungCap>(clsFunction.GetItems<eNhomNhaCungCap>("nhomnhacungcap/getall"));
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

            Tuple<bool, List<eNhomNhaCungCap>> Res = clsFunction.Post("nhomnhacungcap", lstEdited.ToList());
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
            if (!lstEdited.Any(x => x.KeyID == ((eNhomNhaCungCap)e.Row).KeyID)) lstEdited.Add((eNhomNhaCungCap)e.Row);
        }
    }
}
