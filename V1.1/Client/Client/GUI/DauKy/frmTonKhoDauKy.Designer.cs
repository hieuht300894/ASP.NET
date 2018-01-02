namespace Client.GUI.DauKy
{
    partial class frmTonKhoDauKy
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gctDanhSach = new DevExpress.XtraGrid.GridControl();
            this.grvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKeyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlokSanPham = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMaSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlokKho = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMaKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rdteNgay = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rspnSoLuong = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlokSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlokKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdteNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdteNgay.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspnSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gctDanhSach);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(884, 360);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gctDanhSach
            // 
            this.gctDanhSach.Location = new System.Drawing.Point(12, 12);
            this.gctDanhSach.MainView = this.grvDanhSach;
            this.gctDanhSach.MenuManager = this.barMenu;
            this.gctDanhSach.Name = "gctDanhSach";
            this.gctDanhSach.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlokSanPham,
            this.rlokKho,
            this.rdteNgay,
            this.rspnSoLuong});
            this.gctDanhSach.Size = new System.Drawing.Size(860, 336);
            this.gctDanhSach.TabIndex = 4;
            this.gctDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDanhSach});
            // 
            // grvDanhSach
            // 
            this.grvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKeyID,
            this.colIDSanPham,
            this.colMaSanPham,
            this.colTenSanPham,
            this.colIDKho,
            this.colMaKho,
            this.colTenKho,
            this.colNgayNhap,
            this.colSoLuong,
            this.colGhiChu});
            this.grvDanhSach.GridControl = this.gctDanhSach;
            this.grvDanhSach.Name = "grvDanhSach";
            // 
            // colKeyID
            // 
            this.colKeyID.FieldName = "KeyID";
            this.colKeyID.Name = "colKeyID";
            this.colKeyID.OptionsColumn.AllowEdit = false;
            // 
            // colIDSanPham
            // 
            this.colIDSanPham.Caption = "Sản phẩm";
            this.colIDSanPham.ColumnEdit = this.rlokSanPham;
            this.colIDSanPham.FieldName = "IDSanPham";
            this.colIDSanPham.Name = "colIDSanPham";
            this.colIDSanPham.Visible = true;
            this.colIDSanPham.VisibleIndex = 1;
            // 
            // rlokSanPham
            // 
            this.rlokSanPham.AutoHeight = false;
            this.rlokSanPham.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlokSanPham.Name = "rlokSanPham";
            this.rlokSanPham.NullText = "";
            // 
            // colMaSanPham
            // 
            this.colMaSanPham.FieldName = "MaSanPham";
            this.colMaSanPham.Name = "colMaSanPham";
            this.colMaSanPham.OptionsColumn.AllowEdit = false;
            // 
            // colTenSanPham
            // 
            this.colTenSanPham.FieldName = "TenSanPham";
            this.colTenSanPham.Name = "colTenSanPham";
            this.colTenSanPham.OptionsColumn.AllowEdit = false;
            // 
            // colIDKho
            // 
            this.colIDKho.Caption = "Kho";
            this.colIDKho.ColumnEdit = this.rlokKho;
            this.colIDKho.FieldName = "IDKho";
            this.colIDKho.Name = "colIDKho";
            this.colIDKho.Visible = true;
            this.colIDKho.VisibleIndex = 2;
            // 
            // rlokKho
            // 
            this.rlokKho.AutoHeight = false;
            this.rlokKho.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlokKho.Name = "rlokKho";
            this.rlokKho.NullText = "";
            // 
            // colMaKho
            // 
            this.colMaKho.FieldName = "MaKho";
            this.colMaKho.Name = "colMaKho";
            this.colMaKho.OptionsColumn.AllowEdit = false;
            // 
            // colTenKho
            // 
            this.colTenKho.FieldName = "TenKho";
            this.colTenKho.Name = "colTenKho";
            this.colTenKho.OptionsColumn.AllowEdit = false;
            // 
            // colNgayNhap
            // 
            this.colNgayNhap.Caption = "Ngày nhập";
            this.colNgayNhap.ColumnEdit = this.rdteNgay;
            this.colNgayNhap.FieldName = "NgayNhap";
            this.colNgayNhap.Name = "colNgayNhap";
            this.colNgayNhap.Visible = true;
            this.colNgayNhap.VisibleIndex = 0;
            // 
            // rdteNgay
            // 
            this.rdteNgay.AutoHeight = false;
            this.rdteNgay.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rdteNgay.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rdteNgay.Name = "rdteNgay";
            // 
            // colSoLuong
            // 
            this.colSoLuong.Caption = "Số lượng";
            this.colSoLuong.ColumnEdit = this.rspnSoLuong;
            this.colSoLuong.FieldName = "SoLuong";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.Visible = true;
            this.colSoLuong.VisibleIndex = 3;
            // 
            // rspnSoLuong
            // 
            this.rspnSoLuong.AutoHeight = false;
            this.rspnSoLuong.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rspnSoLuong.Name = "rspnSoLuong";
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(884, 360);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gctDanhSach;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(864, 340);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmTonKhoDauKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 411);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmTonKhoDauKy";
            this.Text = "Khai báo tồn kho đầu kỳ";
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlokSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlokKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdteNgay.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdteNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspnSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gctDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDanhSach;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colKeyID;
        private DevExpress.XtraGrid.Columns.GridColumn colIDSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn colTenSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn colIDKho;
        private DevExpress.XtraGrid.Columns.GridColumn colMaKho;
        private DevExpress.XtraGrid.Columns.GridColumn colTenKho;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayNhap;
        private DevExpress.XtraGrid.Columns.GridColumn colSoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlokSanPham;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlokKho;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rdteNgay;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspnSoLuong;
    }
}