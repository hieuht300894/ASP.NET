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
        protected override void frmBase_Load(object sender, EventArgs e)
        {
            clsGeneral.CallWaitForm(this);
            base.frmBase_Load(sender, e);
            LoadDataForm();
            LoadDonViTinh(_aEntry.IDDonViTinh);
            CustomForm();
            clsGeneral.CloseWaitForm();
        }

        async void LoadDonViTinh(object KeyID)
        {
            slokDVT.Properties.DataSource = await clsFunction.GetItemsAsync<eDonViTinh>("DonViTinh/GetAll");

            if ((int)KeyID > 0)
                slokDVT.BeginInvoke(new Action(async () => { slokDVT.EditValue = await slokDVT.RunMethodAsync(() => { return KeyID; }); }));
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
