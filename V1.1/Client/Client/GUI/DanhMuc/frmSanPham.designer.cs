namespace Client.GUI.DanhMuc
{
    partial class frmSanPham
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
            this.colMa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDMauSon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpclr = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.colMauSon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKichThuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDDonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlokDVT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rspnKichThuoc = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpclr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlokDVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspnKichThuoc)).BeginInit();
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
            this.rpclr,
            this.rlokDVT,
            this.rspnKichThuoc});
            this.gctDanhSach.Size = new System.Drawing.Size(860, 336);
            this.gctDanhSach.TabIndex = 4;
            this.gctDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDanhSach});
            // 
            // grvDanhSach
            // 
            this.grvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKeyID,
            this.colMa,
            this.colTen,
            this.colIDMauSon,
            this.colMauSon,
            this.colKichThuoc,
            this.colIDDonViTinh,
            this.colDonViTinh,
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
            // colMa
            // 
            this.colMa.Caption = "Mã SP";
            this.colMa.FieldName = "Ma";
            this.colMa.Name = "colMa";
            this.colMa.Visible = true;
            this.colMa.VisibleIndex = 0;
            // 
            // colTen
            // 
            this.colTen.Caption = "Tên SP";
            this.colTen.FieldName = "Ten";
            this.colTen.Name = "colTen";
            this.colTen.Visible = true;
            this.colTen.VisibleIndex = 1;
            // 
            // colIDMauSon
            // 
            this.colIDMauSon.Caption = "Màu sắc";
            this.colIDMauSon.ColumnEdit = this.rpclr;
            this.colIDMauSon.FieldName = "Color";
            this.colIDMauSon.Name = "colIDMauSon";
            // 
            // rpclr
            // 
            this.rpclr.AutoHeight = false;
            this.rpclr.AutomaticColor = System.Drawing.Color.Black;
            this.rpclr.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpclr.Name = "rpclr";
            // 
            // colMauSon
            // 
            this.colMauSon.FieldName = "MauSon";
            this.colMauSon.Name = "colMauSon";
            this.colMauSon.OptionsColumn.AllowEdit = false;
            // 
            // colKichThuoc
            // 
            this.colKichThuoc.Caption = "Kích thước";
            this.colKichThuoc.FieldName = "KichThuoc";
            this.colKichThuoc.Name = "colKichThuoc";
            // 
            // colIDDonViTinh
            // 
            this.colIDDonViTinh.Caption = "ĐVT";
            this.colIDDonViTinh.ColumnEdit = this.rlokDVT;
            this.colIDDonViTinh.FieldName = "IDDonViTinh";
            this.colIDDonViTinh.Name = "colIDDonViTinh";
            this.colIDDonViTinh.Visible = true;
            this.colIDDonViTinh.VisibleIndex = 2;
            // 
            // rlokDVT
            // 
            this.rlokDVT.AutoHeight = false;
            this.rlokDVT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlokDVT.Name = "rlokDVT";
            this.rlokDVT.NullText = "";
            // 
            // colDonViTinh
            // 
            this.colDonViTinh.FieldName = "DonViTinh";
            this.colDonViTinh.Name = "colDonViTinh";
            this.colDonViTinh.OptionsColumn.AllowEdit = false;
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 3;
            // 
            // rspnKichThuoc
            // 
            this.rspnKichThuoc.AutoHeight = false;
            this.rspnKichThuoc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rspnKichThuoc.Name = "rspnKichThuoc";
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
            // frmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 411);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmSanPham";
            this.Text = "Danh sách sản phẩm";
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpclr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlokDVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspnKichThuoc)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colMa;
        private DevExpress.XtraGrid.Columns.GridColumn colTen;
        private DevExpress.XtraGrid.Columns.GridColumn colIDMauSon;
        private DevExpress.XtraGrid.Columns.GridColumn colMauSon;
        private DevExpress.XtraGrid.Columns.GridColumn colKichThuoc;
        private DevExpress.XtraGrid.Columns.GridColumn colIDDonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colDonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlokDVT;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit rpclr;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspnKichThuoc;
    }
}