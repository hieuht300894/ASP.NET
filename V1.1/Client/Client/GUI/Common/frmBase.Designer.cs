namespace Client.GUI.Common
{
    partial class frmBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBase));
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barMenu = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAndAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnFitComlum = new DevExpress.XtraBars.BarButtonItem();
            this.betPercent = new DevExpress.XtraBars.BarEditItem();
            this.rpbPercent = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.btnLoading = new DevExpress.XtraBars.BarButtonItem();
            this.barBottom = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbpAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bbpEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbpDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbpRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bbpConfirm = new DevExpress.XtraBars.BarButtonItem();
            this.bbpCancel = new DevExpress.XtraBars.BarButtonItem();
            this.bbpPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bbpSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbpSaveAndAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bbpExportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.popGridMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.alertMsg = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpbPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // barMenu
            // 
            this.barMenu.AllowCustomization = false;
            this.barMenu.AllowQuickCustomization = false;
            this.barMenu.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTop,
            this.barBottom});
            this.barMenu.DockControls.Add(this.barDockControlTop);
            this.barMenu.DockControls.Add(this.barDockControlBottom);
            this.barMenu.DockControls.Add(this.barDockControlLeft);
            this.barMenu.DockControls.Add(this.barDockControlRight);
            this.barMenu.Form = this;
            this.barMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnRefresh,
            this.btnSave,
            this.btnCancel,
            this.btnClose,
            this.btnSaveAndAdd,
            this.bbpAdd,
            this.bbpEdit,
            this.bbpDelete,
            this.bbpRefresh,
            this.btnPrintPreview,
            this.btnExportExcel,
            this.betPercent,
            this.bbpConfirm,
            this.bbpCancel,
            this.bbpPrintPreview,
            this.bbpSave,
            this.bbpSaveAndAdd,
            this.bbpExportExcel,
            this.btnLoading,
            this.btnFitComlum,
            this.btnImportExcel});
            this.barMenu.MainMenu = this.barTop;
            this.barMenu.MaxItemId = 32;
            this.barMenu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpbPercent});
            this.barMenu.StatusBar = this.barBottom;
            // 
            // barTop
            // 
            this.barTop.BarName = "Main menu";
            this.barTop.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.FloatLocation = new System.Drawing.Point(68, 180);
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSaveAndAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCancel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrintPreview, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImportExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFitComlum, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.betPercent, "", false, true, true, 138),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLoading)});
            this.barTop.OptionsBar.DrawDragBorder = false;
            this.barTop.OptionsBar.MultiLine = true;
            this.barTop.OptionsBar.UseWholeRow = true;
            this.barTop.Text = "Main menu";
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Thêm mới";
            this.btnAdd.Id = 0;
            this.btnAdd.ImageOptions.DisabledLargeImage = global::Client.Properties.Resources.Add_32x32;
            this.btnAdd.ImageOptions.Image = global::Client.Properties.Resources.Add_16x16;
            this.btnAdd.ImageOptions.LargeImage = global::Client.Properties.Resources.Add_32x32;
            this.btnAdd.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnAdd.Name = "btnAdd";
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Sửa";
            this.btnEdit.Id = 1;
            this.btnEdit.ImageOptions.Image = global::Client.Properties.Resources.Edit_16x16;
            this.btnEdit.ImageOptions.LargeImage = global::Client.Properties.Resources.Edit_32x32;
            this.btnEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.btnEdit.Name = "btnEdit";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Id = 2;
            this.btnDelete.ImageOptions.Image = global::Client.Properties.Resources.Delete_16x16;
            this.btnDelete.ImageOptions.LargeImage = global::Client.Properties.Resources.Delete_32x32;
            this.btnDelete.Name = "btnDelete";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Lưu";
            this.btnSave.Id = 6;
            this.btnSave.ImageOptions.Image = global::Client.Properties.Resources.Save_16x16;
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnSave.Name = "btnSave";
            // 
            // btnSaveAndAdd
            // 
            this.btnSaveAndAdd.Caption = "Lưu và thêm mới";
            this.btnSaveAndAdd.Id = 9;
            this.btnSaveAndAdd.ImageOptions.Image = global::Client.Properties.Resources.SaveAndNew_16x16;
            this.btnSaveAndAdd.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.S));
            this.btnSaveAndAdd.Name = "btnSaveAndAdd";
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Hủy";
            this.btnCancel.Id = 7;
            this.btnCancel.ImageOptions.Image = global::Client.Properties.Resources.Cancel_16x16;
            this.btnCancel.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Escape));
            this.btnCancel.Name = "btnCancel";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Làm mới";
            this.btnRefresh.Id = 5;
            this.btnRefresh.ImageOptions.Image = global::Client.Properties.Resources.Refresh_16x16;
            this.btnRefresh.ImageOptions.LargeImage = global::Client.Properties.Resources.Refresh_32x32;
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnRefresh.Name = "btnRefresh";
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Caption = "In";
            this.btnPrintPreview.Id = 18;
            this.btnPrintPreview.ImageOptions.Image = global::Client.Properties.Resources.Printer_16x16;
            this.btnPrintPreview.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.btnPrintPreview.Name = "btnPrintPreview";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Caption = "Export Excel";
            this.btnExportExcel.Id = 19;
            this.btnExportExcel.ImageOptions.Image = global::Client.Properties.Resources.ExportToXLSX_16x16;
            this.btnExportExcel.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.E));
            this.btnExportExcel.Name = "btnExportExcel";
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Caption = "Import Excel";
            this.btnImportExcel.Id = 31;
            this.btnImportExcel.ImageOptions.Image = global::Client.Properties.Resources.Grid_16x16;
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnFitComlum
            // 
            this.btnFitComlum.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnFitComlum.Caption = "Fit column";
            this.btnFitComlum.Id = 30;
            this.btnFitComlum.ImageOptions.Image = global::Client.Properties.Resources.FitToContent_16x16;
            this.btnFitComlum.Name = "btnFitComlum";
            this.btnFitComlum.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFitComlum_ItemClick);
            // 
            // betPercent
            // 
            this.betPercent.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.betPercent.Edit = this.rpbPercent;
            this.betPercent.EditValue = 0;
            this.betPercent.EditWidth = 0;
            this.betPercent.Id = 20;
            this.betPercent.Name = "betPercent";
            this.betPercent.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // rpbPercent
            // 
            this.rpbPercent.Name = "rpbPercent";
            this.rpbPercent.ReadOnly = true;
            this.rpbPercent.ShowTitle = true;
            this.rpbPercent.Step = 1;
            // 
            // btnLoading
            // 
            this.btnLoading.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnLoading.Caption = "Stop";
            this.btnLoading.Id = 29;
            this.btnLoading.ImageOptions.Image = global::Client.Properties.Resources.Stop_16x16;
            this.btnLoading.Name = "btnLoading";
            this.btnLoading.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnLoading.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLoading_ItemClick);
            // 
            // barBottom
            // 
            this.barBottom.BarName = "Bottom Menu";
            this.barBottom.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barBottom.DockCol = 0;
            this.barBottom.DockRow = 0;
            this.barBottom.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barBottom.OptionsBar.DrawBorder = false;
            this.barBottom.OptionsBar.DrawDragBorder = false;
            this.barBottom.OptionsBar.MultiLine = true;
            this.barBottom.OptionsBar.UseWholeRow = true;
            this.barBottom.Text = "Bottom Menu";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barMenu;
            this.barDockControlTop.Size = new System.Drawing.Size(884, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 388);
            this.barDockControlBottom.Manager = this.barMenu;
            this.barDockControlBottom.Size = new System.Drawing.Size(884, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barMenu;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 364);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(884, 24);
            this.barDockControlRight.Manager = this.barMenu;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 364);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Thoát";
            this.btnClose.Id = 8;
            this.btnClose.Name = "btnClose";
            // 
            // bbpAdd
            // 
            this.bbpAdd.Caption = "Thêm";
            this.bbpAdd.Enabled = false;
            this.bbpAdd.Id = 13;
            this.bbpAdd.ImageOptions.Image = global::Client.Properties.Resources.Add_16x16;
            this.bbpAdd.Name = "bbpAdd";
            // 
            // bbpEdit
            // 
            this.bbpEdit.Caption = "Cập nhật";
            this.bbpEdit.Enabled = false;
            this.bbpEdit.Id = 14;
            this.bbpEdit.ImageOptions.Image = global::Client.Properties.Resources.Edit_16x16;
            this.bbpEdit.Name = "bbpEdit";
            // 
            // bbpDelete
            // 
            this.bbpDelete.Caption = "Xóa";
            this.bbpDelete.Enabled = false;
            this.bbpDelete.Id = 15;
            this.bbpDelete.ImageOptions.Image = global::Client.Properties.Resources.Delete_16x16;
            this.bbpDelete.Name = "bbpDelete";
            // 
            // bbpRefresh
            // 
            this.bbpRefresh.Caption = "Làm mới";
            this.bbpRefresh.Id = 17;
            this.bbpRefresh.ImageOptions.Image = global::Client.Properties.Resources.Refresh_16x16;
            this.bbpRefresh.Name = "bbpRefresh";
            // 
            // bbpConfirm
            // 
            this.bbpConfirm.Caption = "Xác nhận";
            this.bbpConfirm.Enabled = false;
            this.bbpConfirm.Id = 21;
            this.bbpConfirm.ImageOptions.Image = global::Client.Properties.Resources.Apply_16x16;
            this.bbpConfirm.ImageOptions.LargeImage = global::Client.Properties.Resources.Apply_32x32;
            this.bbpConfirm.Name = "bbpConfirm";
            this.bbpConfirm.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbpCancel
            // 
            this.bbpCancel.Caption = "Hủy bỏ";
            this.bbpCancel.Enabled = false;
            this.bbpCancel.Id = 22;
            this.bbpCancel.ImageOptions.Image = global::Client.Properties.Resources.Cancel_16x16;
            this.bbpCancel.ImageOptions.LargeImage = global::Client.Properties.Resources.Reset_32x32;
            this.bbpCancel.Name = "bbpCancel";
            // 
            // bbpPrintPreview
            // 
            this.bbpPrintPreview.Caption = "In phiếu";
            this.bbpPrintPreview.Enabled = false;
            this.bbpPrintPreview.Id = 23;
            this.bbpPrintPreview.ImageOptions.Image = global::Client.Properties.Resources.Print_16x16;
            this.bbpPrintPreview.Name = "bbpPrintPreview";
            // 
            // bbpSave
            // 
            this.bbpSave.Caption = "Lưu";
            this.bbpSave.Enabled = false;
            this.bbpSave.Id = 24;
            this.bbpSave.ImageOptions.Image = global::Client.Properties.Resources.Save_16x16;
            this.bbpSave.Name = "bbpSave";
            // 
            // bbpSaveAndAdd
            // 
            this.bbpSaveAndAdd.Caption = "Lưu và Thêm mới";
            this.bbpSaveAndAdd.Enabled = false;
            this.bbpSaveAndAdd.Id = 25;
            this.bbpSaveAndAdd.ImageOptions.Image = global::Client.Properties.Resources.SaveAndNew_16x16;
            this.bbpSaveAndAdd.Name = "bbpSaveAndAdd";
            // 
            // bbpExportExcel
            // 
            this.bbpExportExcel.Caption = "Xuất Excel";
            this.bbpExportExcel.Enabled = false;
            this.bbpExportExcel.Id = 26;
            this.bbpExportExcel.ImageOptions.Image = global::Client.Properties.Resources.ExportToXLSX_16x16;
            this.bbpExportExcel.Name = "bbpExportExcel";
            // 
            // popGridMenu
            // 
            this.popGridMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbpSave, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpSaveAndAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpCancel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpPrintPreview, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpExportExcel)});
            this.popGridMenu.Manager = this.barMenu;
            this.popGridMenu.Name = "popGridMenu";
            // 
            // alertMsg
            // 
            this.alertMsg.AutoFormDelay = 5000;
            this.alertMsg.FormShowingEffect = DevExpress.XtraBars.Alerter.AlertFormShowingEffect.SlideHorizontal;
            this.alertMsg.LookAndFeel.SkinName = "Office 2010 Blue";
            this.alertMsg.ShowPinButton = false;
            this.alertMsg.ShowToolTips = false;
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 411);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBase_FormClosing);
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.Enter += new System.EventHandler(this.frmBase_Enter);
            this.Leave += new System.EventHandler(this.frmBase_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpbPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        public DevExpress.XtraBars.BarButtonItem btnEdit;
        public DevExpress.XtraBars.Bar barTop;
        public DevExpress.XtraBars.BarButtonItem btnDelete;
        public DevExpress.XtraBars.BarButtonItem btnRefresh;
        public DevExpress.XtraBars.BarButtonItem btnSave;
        public DevExpress.XtraBars.BarButtonItem btnCancel;
        public DevExpress.XtraBars.BarButtonItem btnSaveAndAdd;
        public DevExpress.XtraBars.PopupMenu popGridMenu;
        public DevExpress.XtraBars.BarButtonItem bbpRefresh;
        public DevExpress.XtraBars.BarButtonItem bbpAdd;
        public DevExpress.XtraBars.BarButtonItem bbpEdit;
        public DevExpress.XtraBars.BarButtonItem bbpDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        public DevExpress.XtraBars.BarButtonItem btnPrintPreview;
        public DevExpress.XtraBars.BarButtonItem btnExportExcel;
        public DevExpress.XtraBars.BarButtonItem btnAdd;
        public DevExpress.XtraBars.Bar barBottom;
        public DevExpress.XtraBars.BarEditItem betPercent;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar rpbPercent;
        private DevExpress.XtraBars.BarButtonItem bbpConfirm;
        public DevExpress.XtraBars.BarManager barMenu;
        public DevExpress.XtraBars.BarButtonItem bbpSave;
        public DevExpress.XtraBars.BarButtonItem bbpSaveAndAdd;
        public DevExpress.XtraBars.BarButtonItem bbpExportExcel;
        public DevExpress.XtraBars.BarButtonItem bbpCancel;
        public DevExpress.XtraBars.BarButtonItem bbpPrintPreview;
        private DevExpress.XtraBars.Alerter.AlertControl alertMsg;
        private DevExpress.XtraBars.BarButtonItem btnLoading;
        private DevExpress.XtraBars.BarButtonItem btnFitComlum;
        public DevExpress.XtraBars.BarButtonItem btnImportExcel;
    }
}