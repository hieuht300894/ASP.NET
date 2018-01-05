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
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUI.DanhMuc
{
    public partial class frmSanPham : frmBase
    {
        public eSanPham _iEntry;
        eSanPham _aEntry;

        public frmSanPham()
        {
            InitializeComponent();
        }
        protected override async void frmBase_Load(object sender, EventArgs e)
        {
            await RunMethodAsync(() => { clsGeneral.CallWaitForm(this); });
            await RunMethodAsync(() => { base.frmBase_Load(sender, e); });
            await RunMethodAsync(() => { LoadDonViTinh(); });
            await RunMethodAsync(() => { LoadDataForm(); });
            await RunMethodAsync(() => { CustomForm(); });
            await RunMethodAsync(() => { clsGeneral.CloseWaitForm(); });
        }

        void LoadDonViTinh()
        {
            slokDVT.Properties.DataSource = clsFunction.GetItems<eDonViTinh>("DonViTinh/GetAll");
        }
        public override void ResetAll()
        {
            _iEntry = _aEntry = null;
        }
        public override void LoadDataForm()
        {
            _iEntry = _iEntry ?? new eSanPham();
            _aEntry = clsFunction.GetByID<eSanPham>("SanPham/GetByID", _iEntry.KeyID);

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
            clrpMauSac.Color = Color.FromArgb(_aEntry.ColorHex);
            txtKichThuoc.EditValue = _aEntry.KichThuoc;
            slokDVT.EditValue = _aEntry.IDDonViTinh;
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
            _aEntry.MauSac = clrpMauSac.Text;
            _aEntry.ColorHex = clrpMauSac.Color.ToArgb();
            _aEntry.KichThuoc = txtKichThuoc.Text.Trim();
            _aEntry.GhiChu = mmeGhiChu.Text.Trim();

            eDonViTinh dvt = (eDonViTinh)slokDVT.Properties.GetRowByKeyValue(slokDVT.EditValue) ?? new eDonViTinh();
            _aEntry.IDDonViTinh = dvt.KeyID;
            _aEntry.MaDonViTinh = dvt.Ma;
            _aEntry.TenDonViTinh = dvt.Ten;

            Tuple<bool, eSanPham> Res = (_aEntry.KeyID > 0 ?
                clsFunction.Put("SanPham/UpdateEntries", _aEntry) :
                clsFunction.Post("SanPham/AddEntries", _aEntry));
            if (Res.Item1)
                KeyID = Res.Item2.KeyID;
            return Res.Item1;
        }
        public override void CustomForm()
        {
            slokDVT.Properties.ValueMember = "KeyID";
            slokDVT.Properties.DisplayMember = "Ten";

            base.CustomForm();
        }
    }
}
