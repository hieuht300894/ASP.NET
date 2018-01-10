using Client.BLL.Common;
using Client.GUI.Common;
using Client.Module;
using DevExpress.XtraEditors;
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
    public partial class frmNhaCungCap : frmBase
    {
        public eNhaCungCap _iEntry;
        eNhaCungCap _aEntry;

        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        protected override void frmBase_Load(object sender, EventArgs e)
        {
            //await RunMethodAsync(() => { clsGeneral.CallWaitForm(this); });
            //await RunMethodAsync(() => { base.frmBase_Load(sender, e); });
            //await RunMethodAsync(() => { LoadTinhThanh(); });
            //await RunMethodAsync(() => { LoadDataForm(); });
            //await RunMethodAsync(() => { CustomForm(); });
            //await RunMethodAsync(() => { clsGeneral.CloseWaitForm(); });

            clsGeneral.CallWaitForm(this);
            base.frmBase_Load(sender, e);
            LoadDataForm();
            LoadTinhThanh(_aEntry.IDTinhThanh);
            CustomForm();
            clsGeneral.CloseWaitForm();
        }

        async void LoadTinhThanh(object KeyID)
        {
            slokTinhThanh.Properties.DataSource = await clsFunction.GetItemsAsync<eTinhThanh>("TinhThanh/DanhSach63TinhThanh");

            if ((int)KeyID > 0)
                slokTinhThanh.BeginInvoke(new Action(async () => { slokTinhThanh.EditValue = await slokTinhThanh.RunMethodAsync(() => { return KeyID; }); }));
        }
        public override void ResetAll()
        {
            _iEntry = _aEntry = null;
        }
        public override void LoadDataForm()
        {
            _iEntry = _iEntry ?? new eNhaCungCap();
            _aEntry = clsFunction.GetByID<eNhaCungCap>("NhaCungCap/GetByID", _iEntry.KeyID);

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
            txtDiaChi.EditValue = _aEntry.DiaChi;
            txtSDT.EditValue = _aEntry.DienThoai;
            txtNguoiLienHe.EditValue = _aEntry.NguoiLienHe;
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
            _aEntry.DiaChi = txtDiaChi.Text.Trim();
            _aEntry.DienThoai = txtSDT.Text.Trim();
            _aEntry.NguoiLienHe = txtNguoiLienHe.Text.Trim();

            eTinhThanh tinhThanh = (eTinhThanh)slokTinhThanh.Properties.GetRowByKeyValue(slokTinhThanh.EditValue) ?? new eTinhThanh();
            _aEntry.IDTinhThanh = tinhThanh.KeyID;
            _aEntry.TinhThanh = tinhThanh.Ten;

            Tuple<bool, eNhaCungCap> Res = (_aEntry.KeyID > 0 ?
                clsFunction.Put("NhaCungCap/UpdateEntries", _aEntry) :
                clsFunction.Post("NhaCungCap/AddEntries", _aEntry));
            if (Res.Item1)
                KeyID = Res.Item2.KeyID;
            return Res.Item1;
        }
        public override void CustomForm()
        {
            slokTinhThanh.Properties.ValueMember = "KeyID";
            slokTinhThanh.Properties.DisplayMember = "Ten";

            base.CustomForm();
        }
    }
}
