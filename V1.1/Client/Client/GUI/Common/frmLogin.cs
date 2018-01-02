using Client.BLL.Common;
using Client.Module;
using DevExpress.XtraEditors;
using EntityModel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUI.Common
{
    public partial class frmLogin : XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            LoadData();
            CustomForm();
        }

        void LoadData()
        {
            try
            {
                string dir = @"Config";
                string path = $@"{dir}\LoginSetting.xml";
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string text = sr.ReadToEnd();
                        UserSetting info = text.DeserializeXMLToObject<UserSetting>() ?? new UserSetting();

                        if (info.IsRemember)
                        {
                            txtUsername.EditValue = info.Username;
                            txtPassword.EditValue = info.Password;
                            chkRemember.Checked = info.IsRemember;
                        }
                        else
                        {
                            txtUsername.ResetText();
                            txtPassword.ResetText();
                            chkRemember.CheckState = CheckState.Unchecked;
                        }
                    }
                }
            }
            catch
            {
                txtUsername.ResetText();
                txtPassword.ResetText();
                chkRemember.CheckState = CheckState.Unchecked;
            }
        }
        bool ValidateForm()
        {
            txtUsername.ErrorText = string.Empty;
            txtPassword.ErrorText = string.Empty;

            bool chk = true;
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.ErrorText = "Vui lòng nhập tài khoản";
                chk = false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.ErrorText = "Vui lòng nhập mật khẩu";
                chk = false;
            }
            return chk;
        }
        bool CheckLogin()
        {
            try
            {
                Tuple<bool, UserInfo> tuple = clsFunction.Login<UserInfo>("Module/Login", txtUsername.Text.Trim(), txtPassword.Text.Trim());

                if (!tuple.Item1)
                    throw new Exception();

                clsGeneral.curAccount = tuple.Item2.xAccount;
                clsGeneral.curPersonnel = tuple.Item2.xPersonnel;

                return true;
            }
            catch
            {
                return false;
            }
        }
        bool SaveData()
        {
            try
            {
                string dir = @"Config";
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                string path = $@"{dir}\LoginSetting.xml";
                if (!File.Exists(path))
                    File.Create(path).Close();

                UserSetting info = new UserSetting();
                info.Username = txtUsername.Text.Trim();
                info.Password = txtPassword.Text.Trim();
                info.IsRemember = chkRemember.Checked;
                info.Domain = ModuleHelper.Domain;
                info.Port = ModuleHelper.Port;
                info.Template = ModuleHelper.Template;
                info.Url = ModuleHelper.Url;

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
            btnOK.Click -= BtnOK_Click;
            btnCancel.Click -= BtnCancel_Click;

            btnOK.Click += BtnOK_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (CheckLogin())
                {
                    SaveData();
                    DialogResult = DialogResult.OK;
                }
                else
                    clsGeneral.showMessage("Đăng nhập không thành công");
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
