using Client.BLL.Common;
using Client.GUI.Common;
using Client.Module;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using EntityModel.DataModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUI.DanhMuc
{
    public partial class frmKho : frmBase
    {
        eKho _iEntry;
        eKho _aEntry;

        public frmKho()
        {
            InitializeComponent();
        }
        protected override async void frmBase_Load(object sender, EventArgs e)
        {
            await RunMethodAsync(() => { clsGeneral.CallWaitForm(this); });
            await RunMethodAsync(() => { base.frmBase_Load(sender, e); });
            await RunMethodAsync(() => { LoadData(0); });
            await RunMethodAsync(() => { CustomForm(); });
            await RunMethodAsync(() => { clsGeneral.CloseWaitForm(); });
        }

        public override void LoadData(object KeyID)
        {
            gctDanhSach.DataSource = clsFunction.GetItems<eKho>("Kho/GetAll");

            if ((int)KeyID > 0)
                grvDanhSach.FocusedRowHandle = grvDanhSach.LocateByValue("KeyID", KeyID);
        }
        public override void LoadDataForm()
        {
            _iEntry = _iEntry ?? new eKho();
            _aEntry = clsFunction.GetItem<eKho>("Kho/GetByID", _iEntry.KeyID);

            SetControlValue();
        }
        public override void SetControlValue()
        {
            if (_aEntry.KeyID > 0)
            {
                txtTen.Select();
            }
            else
            {
                txtMa.Select();
            }

            txtMa.EditValue = _aEntry.Ma;
            txtTen.EditValue = _aEntry.Ten;
            mmeGhiChu.EditValue = _aEntry.GhiChu;
        }
        public override bool ValidationForm()
        {
            bool chk = true;

            txtMa.ErrorText = string.Empty;
            txtTen.ErrorText = string.Empty;

            if (string.IsNullOrWhiteSpace(txtMa.Text))
            {
                txtMa.ErrorText = "Mã không để trống";
                chk = false;
            }

            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                txtTen.ErrorText = "Tên không để trống";
                chk = false;
            }

            return chk;
        }
        public override bool SaveData()
        {
            if (_aEntry.KeyID > 0)
            {
                _aEntry.NguoiCapNhat = clsGeneral.curPersonnel.KeyID;
                _aEntry.MaNguoiCapNhat = clsGeneral.curPersonnel.Ma;
                _aEntry.TenNguoiCapNhat = clsGeneral.curPersonnel.Ten;
                _aEntry.NgayCapNhat = DateTime.Now.ServerNow();
                _aEntry.TrangThai = 2;

            }
            else
            {
                _aEntry.NguoiTao = clsGeneral.curPersonnel.KeyID;
                _aEntry.MaNguoiTao = clsGeneral.curPersonnel.Ma;
                _aEntry.TenNguoiTao = clsGeneral.curPersonnel.Ten;
                _aEntry.NgayTao = DateTime.Now.ServerNow();
                _aEntry.TrangThai = 1;
            }

            _aEntry.Ma = txtMa.Text.Trim();
            _aEntry.Ten = txtTen.Text.Trim();
            _aEntry.GhiChu = mmeGhiChu.Text.Trim();

            Tuple<bool, eKho> Res = (_aEntry.KeyID > 0 ?
                clsFunction.Put("Kho/UpdateEntries", _aEntry) :
                clsFunction.Post("Kho/AddEntries", _aEntry));
            if (Res.Item1)
                KeyID = Res.Item2.KeyID;
            return Res.Item1;
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
            _iEntry = null;
            LoadDataForm();
        }
        public override void UpdateEntry()
        {
            _iEntry = (eKho)grvDanhSach.GetFocusedRow();
            LoadDataForm();
        }
        public override void DeleteEntry()
        {

        }
        public override async void RefreshEntry()
        {
            await RunMethodAsync(() => { clsGeneral.CallWaitForm(this); });
            await RunMethodAsync(() => { LoadData(0); });
            await RunMethodAsync(() => { clsGeneral.CloseWaitForm(); });
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
