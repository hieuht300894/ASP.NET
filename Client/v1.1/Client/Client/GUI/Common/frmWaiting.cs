using DevExpress.XtraEditors;
using DevExpress.XtraWaitForm;
using System;

namespace Client.GUI.Common
{
    public partial class frmWaiting : WaitForm
    {
        public frmWaiting()
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string DienGiai)
        {
            base.SetDescription(DienGiai);
            this.progressPanel1.Description = DienGiai;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }
    }
}
