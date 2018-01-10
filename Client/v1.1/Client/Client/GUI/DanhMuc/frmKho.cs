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
        public eKho _iEntry;
        eKho _aEntry;

        public frmKho()
        {
            InitializeComponent();
        }
        protected override  void frmBase_Load(object sender, EventArgs e)
        {
            //await RunMethodAsync(() => { clsGeneral.CallWaitForm(this); });
            //await RunMethodAsync(() => { base.frmBase_Load(sender, e); });
            //await RunMethodAsync(() => { LoadDataForm(); });
            //await RunMethodAsync(() => { CustomForm(); });
            //await RunMethodAsync(() => { clsGeneral.CloseWaitForm(); });

            clsGeneral.CallWaitForm(this);
            base.frmBase_Load(sender, e);
            LoadDataForm();
            CustomForm();
            clsGeneral.CloseWaitForm();
        }

        public override void ResetAll()
        {
            _iEntry = _aEntry = null;
        }
        public override void LoadDataForm()
        {
            _iEntry = _iEntry ?? new eKho();
            _aEntry = clsFunction.GetByID<eKho>("Kho/GetByID", _iEntry.KeyID);

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
        public override bool ValidateData()
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
                _aEntry.NguoiCapNhat = clsGeneral.xNhanVien.KeyID;
                _aEntry.MaNguoiCapNhat = clsGeneral.xNhanVien.Ma;
                _aEntry.TenNguoiCapNhat = clsGeneral.xNhanVien.Ten;
                _aEntry.NgayCapNhat = DateTime.Now.ServerNow();
                _aEntry.TrangThai = 2;

            }
            else
            {
                _aEntry.NguoiTao = clsGeneral.xNhanVien.KeyID;
                _aEntry.MaNguoiTao = clsGeneral.xNhanVien.Ma;
                _aEntry.TenNguoiTao = clsGeneral.xNhanVien.Ten;
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
        }
    }
}
