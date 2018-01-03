using Client.BLL.Common;
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
    public partial class frmKhachHang : frmBase
    {
        BindingList<eKhachHang> lstEntries = new BindingList<eKhachHang>();
        BindingList<eKhachHang> lstEdited = new BindingList<eKhachHang>();

        public frmKhachHang()
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

         void LoadRepository()
        {
            rlokGioiTinh.DataSource = Loai.LoaiGioiTinh();

            IList<eTinhThanh> lstTinhThanh = new List<eTinhThanh>( clsFunction.GetItems<eTinhThanh>("tinhthanh/getall"));
           rlokTinhThanh.DataSource = lstTinhThanh; 
        }
        public  override void LoadDataForm()
        {
            lstEdited = new BindingList<eKhachHang>();
            lstEntries = new BindingList<eKhachHang>( clsFunction.GetItems<eKhachHang>("khachhang/getall"));
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
                Loai gioiTinh = (Loai)rlokGioiTinh.GetDataSourceRowByKeyValue(x.IDGioiTinh) ?? new Loai();
                eTinhThanh tinhThanh = (eTinhThanh)rlokTinhThanh.GetDataSourceRowByKeyValue(x.IDTinhThanh) ?? new eTinhThanh();

                x.GioiTinh = gioiTinh.Ten;
                x.TinhThanh = tinhThanh.Ten;

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

            Tuple<bool, List<eKhachHang>> Res =  clsFunction.Post("khachhang", lstEdited.ToList());
            return Res.Item1;
        }
        public override void CustomForm()
        {
            rlokGioiTinh.ValueMember = "KeyID";
            rlokGioiTinh.DisplayMember = "Ten";
            rlokTinhThanh.ValueMember = "KeyID";
            rlokTinhThanh.DisplayMember = "Ten";

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
            if (!lstEdited.Any(x => x.KeyID == ((eKhachHang)e.Row).KeyID)) lstEdited.Add((eKhachHang)e.Row);
        }
    }
}
