using Client.BLL.Common;
using Client.Module;
using DevExpress.XtraEditors;
using EntityModel;
using System;
using System.IO;
using System.Windows.Forms;

namespace Client.GUI.Common
{
    public partial class frmServer : XtraForm
    {
        public frmServer()
        {
            InitializeComponent();
        }
        private void frmServer_Load(object sender, EventArgs e)
        {
            LoadData();
            CustomForm();
        }

        void LoadData()
        {
            try
            {
                string dir = @"Config";
                string path = $@"{dir}\ThongTinMayChu.xml";
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string text = sr.ReadToEnd();
                        ThongTinMayChu info = text.DeserializeXMLToObject<ThongTinMayChu>() ?? new ThongTinMayChu();

                        txtDomain.EditValue = info.Domain;
                        txtPort.EditValue = info.Port;
                        txtPath.EditValue = info.Path;
                        txtUrl.EditValue = info.Url;
                    }
                }
            }
            catch
            {
                txtDomain.ResetText();
                txtPort.ResetText();
                txtPath.ResetText();
                txtUrl.ResetText();
            }
        }
        bool ValidateForm()
        {
            txtDomain.ErrorText = string.Empty;
            txtUrl.ErrorText = string.Empty;

            bool chk = true;
            if (string.IsNullOrWhiteSpace(txtDomain.Text))
            {
                txtDomain.ErrorText = "Vui lòng nhập tên miền(Domain)";
                chk = false;
            }
            if (string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                txtUrl.ErrorText = "Vui lòng nhập địa chỉ kết nối(Url)";
                chk = false;
            }
            return chk;
        }
        bool CheckConnect()
        {
            return clsFunction.CheckConnect(txtUrl.Text.Trim());
        }
        bool SaveData()
        {
            try
            {
                string dir = @"Config";
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                string path = $@"{dir}\ThongTinMayChu.xml";
                if (!File.Exists(path))
                    File.Create(path).Close();

                ThongTinMayChu info = new ThongTinMayChu();
                info.Domain = ModuleHelper.Domain = txtDomain.Text.Trim();
                info.Port = ModuleHelper.Port = txtPort.Text.Trim();
                info.Path = ModuleHelper.Path = txtPath.Text.Trim();
                info.Url = ModuleHelper.Url = txtUrl.Text.Trim();

                StreamWriter sw = new StreamWriter(path);
                sw.Write(info.SerializeObjectToXML());
                sw.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
        void CustomForm()
        {
            btnCheck.Click -= BtnCheck_Click;
            btnCheck.Click += BtnCheck_Click;

            txtDomain.EditValueChanged -= TxtMain_EditValueChanged;
            txtPort.EditValueChanged -= TxtMain_EditValueChanged;
            txtPath.EditValueChanged -= TxtMain_EditValueChanged;
            txtDomain.EditValueChanged += TxtMain_EditValueChanged;
            txtPort.EditValueChanged += TxtMain_EditValueChanged;
            txtPath.EditValueChanged += TxtMain_EditValueChanged;
        }

        private void TxtMain_EditValueChanged(object sender, EventArgs e)
        {
            txtUrl.EditValue = $"{txtDomain.Text.Trim()}:{txtPort.Text.Trim()}/{txtPath.Text.Trim()}";
        }
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (CheckConnect())
                {
                    SaveData();
                    DialogResult = DialogResult.OK;
                }
                else
                    clsGeneral.showMessage("Kết nối không thành công");
            }
        }
    }
}
