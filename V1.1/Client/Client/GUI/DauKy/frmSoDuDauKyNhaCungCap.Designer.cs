namespace Client.GUI.DauKy
{
    partial class frmSoDuDauKyNhaCungCap
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
            this.colIDKhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlokNhaCungCap = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMaKhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenKhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rdteNgay = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colSoTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rspnSoTien = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlokNhaCungCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdteNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdteNgay.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspnSoTien)).BeginInit();
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
            this.rdteNgay,
            this.rlokNhaCungCap,
            this.rspnSoTien});
            this.gctDanhSach.Size = new System.Drawing.Size(860, 336);
            this.gctDanhSach.TabIndex = 4;
            this.gctDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDanhSach});
            // 
            // grvDanhSach
            // 
            this.grvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKeyID,
            this.colIDKhachHang,
            this.colMaKhachHang,
            this.colTenKhachHang,
            this.colNgayNhap,
            this.colSoTien,
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
            // colIDKhachHang
            // 
            this.colIDKhachHang.Caption = "Nhà cung cấp";
            this.colIDKhachHang.ColumnEdit = this.rlokNhaCungCap;
            this.colIDKhachHang.FieldName = "IDNhaCungCap";
            this.colIDKhachHang.Name = "colIDKhachHang";
            this.colIDKhachHang.Visible = true;
            this.colIDKhachHang.VisibleIndex = 1;
            // 
            // rlokNhaCungCap
            // 
            this.rlokNhaCungCap.AutoHeight = false;
            this.rlokNhaCungCap.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlokNhaCungCap.Name = "rlokNhaCungCap";
            this.rlokNhaCungCap.NullText = "";
            // 
            // colMaKhachHang
            // 
            this.colMaKhachHang.FieldName = "MaKhachHang";
            this.colMaKhachHang.Name = "colMaKhachHang";
            this.colMaKhachHang.OptionsColumn.AllowEdit = false;
            // 
            // colTenKhachHang
            // 
            this.colTenKhachHang.FieldName = "TenKhachHang";
            this.colTenKhachHang.Name = "colTenKhachHang";
            this.colTenKhachHang.OptionsColumn.AllowEdit = false;
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
            // colSoTien
            // 
            this.colSoTien.Caption = "Số tiền";
            this.colSoTien.ColumnEdit = this.rspnSoTien;
            this.colSoTien.FieldName = "SoTien";
            this.colSoTien.Name = "colSoTien";
            this.colSoTien.Visible = true;
            this.colSoTien.VisibleIndex = 2;
            // 
            // rspnSoTien
            // 
            this.rspnSoTien.AutoHeight = false;
            this.rspnSoTien.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rspnSoTien.Name = "rspnSoTien";
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 3;
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
            // frmSoDuDauKyNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 411);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmSoDuDauKyNhaCungCap";
            this.Text = "Khai báo số dư đầu kỳ nhà cung cấp";
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlokNhaCungCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdteNgay.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdteNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspnSoTien)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colIDKhachHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlokNhaCungCap;
        private DevExpress.XtraGrid.Columns.GridColumn colMaKhachHang;
        private DevExpress.XtraGrid.Columns.GridColumn colTenKhachHang;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayNhap;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rdteNgay;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTien;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspnSoTien;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
    }
}