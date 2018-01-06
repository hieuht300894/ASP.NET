﻿using Client.BLL.Common;
using Client.GUI.Common;
using Client.Module;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUI.DanhMuc
{
    public partial class frmKhachHang : frmBase
    {
        public eKhachHang _iEntry;
        eKhachHang _aEntry;

        public frmKhachHang()
        {
            InitializeComponent();
        }
        protected override  void frmBase_Load(object sender, EventArgs e)
        {
            //await RunMethodAsync(() => { clsGeneral.CallWaitForm(this); });
            //await RunMethodAsync(() => { base.frmBase_Load(sender, e); });
            //await RunMethodAsync(() => { LoadTinhThanh(); });
            //await RunMethodAsync(() => { LoadDataForm(); });
            //await RunMethodAsync(() => { CustomForm(); });
            //await RunMethodAsync(() => { clsGeneral.CloseWaitForm(); });
        }

        void LoadTinhThanh()
        {
            slokTinhThanh.Properties.DataSource = clsFunction.GetItems<eTinhThanh>("TinhThanh/DanhSach63TinhThanh");
        }
        public override void ResetAll()
        {
            _iEntry = _aEntry = null;
        }
        public override void LoadDataForm()
        {
            _iEntry = _iEntry ?? new eKhachHang();
            _aEntry = clsFunction.GetByID<eKhachHang>("KhachHang/GetByID", _iEntry.KeyID);

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
            tgsGioiTinh.IsOn = Convert.ToBoolean(_aEntry.IDGioiTinh);
            dteNgaySinh.DateTime = _aEntry.NgaySinh;
            slokTinhThanh.EditValue = _aEntry.IDTinhThanh;
            txtDiaChi.EditValue = _aEntry.DiaChi;
            txtDienThoai.EditValue = _aEntry.DienThoai;
            txtEmail.EditValue = _aEntry.Email;
            mmeGhiChu.EditValue = _aEntry.GhiChu;

            picLogo.Image = clsGeneral.byteArrayToImage(_aEntry.HinhAnh);
            if (picLogo.Image == null)
                picLogo.Image = Properties.Resources.default_logo;
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
            _aEntry.NgaySinh = dteNgaySinh.DateTime;
            _aEntry.IDGioiTinh = Convert.ToInt32(tgsGioiTinh.IsOn);
            _aEntry.GioiTinh = tgsGioiTinh.IsOn ? tgsGioiTinh.Properties.OnText : tgsGioiTinh.Properties.OffText;
            _aEntry.DiaChi = txtDiaChi.Text.Trim();
            _aEntry.DienThoai = txtDienThoai.Text.Trim();
            _aEntry.Email = txtEmail.Text.Trim();
            _aEntry.GhiChu = mmeGhiChu.Text.Trim();
            _aEntry.HinhAnh = clsGeneral.imageToByteArray(picLogo.Image);

            eTinhThanh tinhThanh = (eTinhThanh)slokTinhThanh.Properties.GetRowByKeyValue(slokTinhThanh.EditValue) ?? new eTinhThanh();
            _aEntry.IDTinhThanh = tinhThanh.KeyID;
            _aEntry.TinhThanh = tinhThanh.Ten;

            Tuple<bool, eKhachHang> Res = (_aEntry.KeyID > 0 ?
                clsFunction.Put("KhachHang/UpdateEntries", _aEntry) :
                clsFunction.Post("KhachHang/AddEntries", _aEntry));
            if (Res.Item1)
                KeyID = Res.Item2.KeyID;
            return Res.Item1;
        }
        public override void CustomForm()
        {
            slokTinhThanh.Properties.ValueMember = "KeyID";
            slokTinhThanh.Properties.DisplayMember = "Ten";

            base.CustomForm();

            DisableEvents();
            EnableEvents();
        }
        public override void EnableEvents()
        {
            picLogo.Click += PicLogo_Click;
        }
        public override void DisableEvents()
        {
            picLogo.Click -= PicLogo_Click;
        }

        private void PicLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.BMP;*.PNG;*.JPG;*.JPEG;*.GIF)|*.BMP;*.PNG;*.JPG;*.JPEG;*.GIF";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(dialog.FileName);
                picLogo.Image = bitmap;
            }
        }

    }
}
