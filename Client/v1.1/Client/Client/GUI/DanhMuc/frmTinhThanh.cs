using Client.BLL.Common;
using Client.GUI.Common;
using Client.Model;
using Client.Module;
using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUI.DanhMuc
{
    public partial class frmTinhThanh : frmBase
    {
        #region Variables
        IList<eTinhThanh> lstDanhSach = new List<eTinhThanh>();
        IList<eTinhThanh> lstDanhSachLoai1 = new List<eTinhThanh>();
        IList<eTinhThanh> lstDanhSachLoai2 = new List<eTinhThanh>();
        IList<eTinhThanh> lstDanhSachLoai3 = new List<eTinhThanh>();
        #endregion

        #region Form Events
        public frmTinhThanh()
        {
            InitializeComponent();
        }
        protected  override void frmBase_Load(object sender, EventArgs e)
        {
            //await RunMethodAsync(() => { clsGeneral.CallWaitForm(this); });
            //await RunMethodAsync(() => { base.frmBase_Load(sender, e); });
            //await RunMethodAsync(() => { LoadData(0); });
            //await RunMethodAsync(() => { CustomForm(); });
            //await RunMethodAsync(() => { clsGeneral.CloseWaitForm(); });

            clsGeneral.CallWaitForm(this);
            base.frmBase_Load(sender, e);
            LoadData(0);
            CustomForm();
            clsGeneral.CloseWaitForm();
        }
        #endregion

        #region Methods
        public async void LoadData(int KeyID)
        {
            lstDanhSach = new List<eTinhThanh>(await clsFunction.GetItemsAsync<eTinhThanh>("tinhthanh/getall"));
            lstDanhSachLoai1 = new List<eTinhThanh>(lstDanhSach.Where(x => x.IDLoai >= 1 && x.IDLoai <= 2));
            lstDanhSachLoai2 = new List<eTinhThanh>(lstDanhSach.Where(x => x.IDLoai >= 3 && x.IDLoai <= 6));
            lstDanhSachLoai3 = new List<eTinhThanh>(lstDanhSach.Where(x => x.IDLoai >= 7 && x.IDLoai <= 9));

            lokLoai1.Properties.DataSource = Loai.LoaiDonViHanhChinh().Where(x => x.KeyID >= 1 && x.KeyID <= 2).ToList();
            lokLoai2.Properties.DataSource = Loai.LoaiDonViHanhChinh().Where(x => x.KeyID >= 3 && x.KeyID <= 6).ToList();
            lokLoai3.Properties.DataSource = Loai.LoaiDonViHanhChinh().Where(x => x.KeyID >= 7 && x.KeyID <= 9).ToList();
            lokTen1.Properties.DataSource = lstDanhSachLoai1;
            lokTen2.Properties.DataSource = lstDanhSachLoai2;
            lokTen3.Properties.DataSource = lstDanhSachLoai3;
            trlDanhSach.DataSource = lstDanhSach;
        }
        public override void InsertEntry()
        {
        }
        public override void UpdateEntry()
        {
        }
        public override void DeleteEntry()
        {
        }
        public override void RefreshEntry()
        {
            LoadData(0);
        }
        public override void CustomForm()
        {
            lokLoai1.Properties.ValueMember = "KeyID";
            lokLoai1.Properties.DisplayMember = "Ten";
            lokLoai2.Properties.ValueMember = "KeyID";
            lokLoai2.Properties.DisplayMember = "Ten";
            lokLoai3.Properties.ValueMember = "KeyID";
            lokLoai3.Properties.DisplayMember = "Ten";
            lokTen1.Properties.ValueMember = "KeyID";
            lokTen1.Properties.DisplayMember = "Ten";
            lokTen2.Properties.ValueMember = "KeyID";
            lokTen2.Properties.DisplayMember = "Ten";
            lokTen3.Properties.ValueMember = "KeyID";
            lokTen3.Properties.DisplayMember = "Ten";
            trlDanhSach.ParentFieldName = "IDTinhThanh";
            trlDanhSach.KeyFieldName = "KeyID";

            base.CustomForm();

            lokLoai1.EditValueChanged += lokLoai_EditValueChanged;
            lokLoai2.EditValueChanged += lokLoai_EditValueChanged;
            lokLoai3.EditValueChanged += lokLoai_EditValueChanged;
            lokTen1.EditValueChanged += lokTen_EditValueChanged;
            lokTen2.EditValueChanged += lokTen_EditValueChanged;
            lokTen3.EditValueChanged += lokTen_EditValueChanged;

            lokLoai1.KeyDown += lokLoai_KeyDown;
            lokLoai2.KeyDown += lokLoai_KeyDown;
            lokLoai3.KeyDown += lokLoai_KeyDown;
            lokTen1.KeyDown += lokTen_KeyDown;
            lokTen2.KeyDown += lokTen_KeyDown;
            lokTen3.KeyDown += lokTen_KeyDown;

            btnTimKiem.Click += btnTimKiem_Click;
        }
        #endregion

        #region Event
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lokTen1.EditValueChanged -= lokTen_EditValueChanged;
            lokTen2.EditValueChanged -= lokTen_EditValueChanged;
            lokTen3.EditValueChanged -= lokTen_EditValueChanged;

            var q1 = new List<eTinhThanh>(lstDanhSachLoai1);
            var q2 = new List<eTinhThanh>(lstDanhSachLoai2);
            var q3 = new List<eTinhThanh>(lstDanhSachLoai3);

            if (lokLoai1.ToInt32() > 0)
                q1 = q1.Where(x => x.IDLoai == lokLoai1.ToInt32()).ToList();
            if (lokLoai2.ToInt32() > 0)
                q2 = q2.Where(x => x.IDLoai == lokLoai2.ToInt32()).ToList();
            if (lokLoai3.ToInt32() > 0)
                q3 = q3.Where(x => x.IDLoai == lokLoai3.ToInt32()).ToList();

            var q12 = q1.Join(q2, x => x.KeyID, y => y.IDTinhThanh, (x, y) => y);
            var q23 = q12.Join(q3, x => x.KeyID, y => y.IDTinhThanh, (x, y) => y);

            List<eTinhThanh> lstResult = new List<eTinhThanh>();
            lstResult.AddRange(q1);
            lstResult.AddRange(q12);
            lstResult.AddRange(q23);


            trlDanhSach.DataSource = lstResult;
            lokTen1.Properties.DataSource = lstResult.Where(x => x.IDLoai >= 1 && x.IDLoai <= 2).ToList();
            lokTen2.Properties.DataSource = lstResult.Where(x => x.IDLoai >= 3 && x.IDLoai <= 6).ToList();
            lokTen3.Properties.DataSource = lstResult.Where(x => x.IDLoai >= 7 && x.IDLoai <= 9).ToList();

            lokTen1.EditValueChanged += lokTen_EditValueChanged;
            lokTen2.EditValueChanged += lokTen_EditValueChanged;
            lokTen3.EditValueChanged += lokTen_EditValueChanged;
        }
        private void lokTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var q1 = new List<eTinhThanh>(lstDanhSachLoai1);
                var q2 = new List<eTinhThanh>(lstDanhSachLoai2);
                var q3 = new List<eTinhThanh>(lstDanhSachLoai3);

                if (lokLoai1.ToInt32() > 0)
                    q1 = q1.Where(x => x.IDLoai == lokLoai1.ToInt32()).ToList();
                if (lokLoai2.ToInt32() > 0)
                    q2 = q2.Where(x => x.IDLoai == lokLoai2.ToInt32()).ToList();
                if (lokLoai3.ToInt32() > 0)
                    q3 = q3.Where(x => x.IDLoai == lokLoai3.ToInt32()).ToList();

                if (lokTen1.ToInt32() > 0)
                    q1 = q1.Where(x => x.KeyID == lokTen1.ToInt32()).ToList();
                if (lokTen2.ToInt32() > 0)
                    q2 = q2.Where(x => x.KeyID == lokTen2.ToInt32()).ToList();
                if (lokTen3.ToInt32() > 0)
                    q3 = q3.Where(x => x.KeyID == lokTen3.ToInt32()).ToList();

                var q12 = q1.Join(q2, x => x.KeyID, y => y.IDTinhThanh, (x, y) => y);
                var q23 = q12.Join(q3, x => x.KeyID, y => y.IDTinhThanh, (x, y) => y);

                List<eTinhThanh> lstResult = new List<eTinhThanh>();
                lstResult.AddRange(q1);
                lstResult.AddRange(q12);
                lstResult.AddRange(q23);

                trlDanhSach.DataSource = lstResult;
            }
        }
        private void lokLoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lokTen1.EditValueChanged -= lokTen_EditValueChanged;
                lokTen2.EditValueChanged -= lokTen_EditValueChanged;
                lokTen3.EditValueChanged -= lokTen_EditValueChanged;

                var q1 = new List<eTinhThanh>(lstDanhSachLoai1);
                var q2 = new List<eTinhThanh>(lstDanhSachLoai2);
                var q3 = new List<eTinhThanh>(lstDanhSachLoai3);

                if (lokLoai1.ToInt32() > 0)
                    q1 = q1.Where(x => x.IDLoai == lokLoai1.ToInt32()).ToList();
                if (lokLoai2.ToInt32() > 0)
                    q2 = q2.Where(x => x.IDLoai == lokLoai2.ToInt32()).ToList();
                if (lokLoai3.ToInt32() > 0)
                    q3 = q3.Where(x => x.IDLoai == lokLoai3.ToInt32()).ToList();

                var q12 = q1.Join(q2, x => x.KeyID, y => y.IDTinhThanh, (x, y) => y);
                var q23 = q12.Join(q3, x => x.KeyID, y => y.IDTinhThanh, (x, y) => y);

                List<eTinhThanh> lstResult = new List<eTinhThanh>();
                lstResult.AddRange(q1);
                lstResult.AddRange(q12);
                lstResult.AddRange(q23);


                trlDanhSach.DataSource = lstResult;
                lokTen1.Properties.DataSource = lstResult.Where(x => x.IDLoai >= 1 && x.IDLoai <= 2).ToList();
                lokTen2.Properties.DataSource = lstResult.Where(x => x.IDLoai >= 3 && x.IDLoai <= 6).ToList();
                lokTen3.Properties.DataSource = lstResult.Where(x => x.IDLoai >= 7 && x.IDLoai <= 9).ToList();

                lokTen1.EditValueChanged += lokTen_EditValueChanged;
                lokTen2.EditValueChanged += lokTen_EditValueChanged;
                lokTen3.EditValueChanged += lokTen_EditValueChanged;
            }
        }
        private void lokLoai_EditValueChanged(object sender, EventArgs e)
        {
            lokTen1.EditValueChanged -= lokTen_EditValueChanged;
            lokTen2.EditValueChanged -= lokTen_EditValueChanged;
            lokTen3.EditValueChanged -= lokTen_EditValueChanged;

            var q1 = new List<eTinhThanh>(lstDanhSachLoai1);
            var q2 = new List<eTinhThanh>(lstDanhSachLoai2);
            var q3 = new List<eTinhThanh>(lstDanhSachLoai3);

            if (lokLoai1.ToInt32() > 0)
                q1 = q1.Where(x => x.IDLoai == lokLoai1.ToInt32()).ToList();
            if (lokLoai2.ToInt32() > 0)
                q2 = q2.Where(x => x.IDLoai == lokLoai2.ToInt32()).ToList();
            if (lokLoai3.ToInt32() > 0)
                q3 = q3.Where(x => x.IDLoai == lokLoai3.ToInt32()).ToList();

            var q12 = q1.Join(q2, x => x.KeyID, y => y.IDTinhThanh, (x, y) => y);
            var q23 = q12.Join(q3, x => x.KeyID, y => y.IDTinhThanh, (x, y) => y);

            List<eTinhThanh> lstResult = new List<eTinhThanh>();
            lstResult.AddRange(q1);
            lstResult.AddRange(q12);
            lstResult.AddRange(q23);


            trlDanhSach.DataSource = lstResult;
            lokTen1.Properties.DataSource = lstResult.Where(x => x.IDLoai >= 1 && x.IDLoai <= 2).ToList();
            lokTen2.Properties.DataSource = lstResult.Where(x => x.IDLoai >= 3 && x.IDLoai <= 6).ToList();
            lokTen3.Properties.DataSource = lstResult.Where(x => x.IDLoai >= 7 && x.IDLoai <= 9).ToList();

            lokTen1.EditValueChanged += lokTen_EditValueChanged;
            lokTen2.EditValueChanged += lokTen_EditValueChanged;
            lokTen3.EditValueChanged += lokTen_EditValueChanged;
        }
        private void lokTen_EditValueChanged(object sender, EventArgs e)
        {
            var q1 = new List<eTinhThanh>(lstDanhSachLoai1);
            var q2 = new List<eTinhThanh>(lstDanhSachLoai2);
            var q3 = new List<eTinhThanh>(lstDanhSachLoai3);

            if (lokLoai1.ToInt32() > 0)
                q1 = q1.Where(x => x.IDLoai == lokLoai1.ToInt32()).ToList();
            if (lokLoai2.ToInt32() > 0)
                q2 = q2.Where(x => x.IDLoai == lokLoai2.ToInt32()).ToList();
            if (lokLoai3.ToInt32() > 0)
                q3 = q3.Where(x => x.IDLoai == lokLoai3.ToInt32()).ToList();

            if (lokTen1.ToInt32() > 0)
                q1 = q1.Where(x => x.KeyID == lokTen1.ToInt32()).ToList();
            if (lokTen2.ToInt32() > 0)
                q2 = q2.Where(x => x.KeyID == lokTen2.ToInt32()).ToList();
            if (lokTen3.ToInt32() > 0)
                q3 = q3.Where(x => x.KeyID == lokTen3.ToInt32()).ToList();

            var q12 = q1.Join(q2, x => x.KeyID, y => y.IDTinhThanh, (x, y) => y);
            var q23 = q12.Join(q3, x => x.KeyID, y => y.IDTinhThanh, (x, y) => y);

            List<eTinhThanh> lstResult = new List<eTinhThanh>();
            lstResult.AddRange(q1);
            lstResult.AddRange(q12);
            lstResult.AddRange(q23);

            trlDanhSach.DataSource = lstResult;
        }
        #endregion
    }
}
