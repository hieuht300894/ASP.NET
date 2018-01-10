namespace Client.GUI.Common
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.rcMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bhiNhanVien = new DevExpress.XtraBars.BarHeaderItem();
            this.frmTinhThanh = new DevExpress.XtraBars.BarButtonItem();
            this.frmKho_List = new DevExpress.XtraBars.BarButtonItem();
            this.frmSoDuDauKyKhachHang_List = new DevExpress.XtraBars.BarButtonItem();
            this.frmSoDuDauKyNhaCungCap_List = new DevExpress.XtraBars.BarButtonItem();
            this.frmTonKhoDauKy_List = new DevExpress.XtraBars.BarButtonItem();
            this.frmNhapHangNhaCungCap_List = new DevExpress.XtraBars.BarButtonItem();
            this.frmDonViTinh_List = new DevExpress.XtraBars.BarButtonItem();
            this.frmKhachHang_List = new DevExpress.XtraBars.BarButtonItem();
            this.frmNhaCungCap_List = new DevExpress.XtraBars.BarButtonItem();
            this.frmSanPham_List = new DevExpress.XtraBars.BarButtonItem();
            this.bsiServer = new DevExpress.XtraBars.BarStaticItem();
            this.rpTaiKhoan = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpThietLap = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpDanhMuc = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpChucNang = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemHyperLinkEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemHyperLinkEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.rsbBottom = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.docManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tbvMain = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.rhleServer = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.bhiServer = new DevExpress.XtraBars.BarHeaderItem();
            ((System.ComponentModel.ISupportInitialize)(this.rcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhleServer)).BeginInit();
            this.SuspendLayout();
            // 
            // rcMain
            // 
            this.rcMain.ExpandCollapseItem.Id = 0;
            this.rcMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rcMain.ExpandCollapseItem,
            this.bhiNhanVien,
            this.frmTinhThanh,
            this.frmKho_List,
            this.frmSoDuDauKyKhachHang_List,
            this.frmSoDuDauKyNhaCungCap_List,
            this.frmTonKhoDauKy_List,
            this.frmNhapHangNhaCungCap_List,
            this.frmDonViTinh_List,
            this.frmKhachHang_List,
            this.frmNhaCungCap_List,
            this.frmSanPham_List,
            this.bsiServer,
            this.bhiServer});
            this.rcMain.Location = new System.Drawing.Point(0, 0);
            this.rcMain.MaxItemId = 27;
            this.rcMain.Name = "rcMain";
            this.rcMain.PageHeaderItemLinks.Add(this.bhiNhanVien);
            this.rcMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpTaiKhoan,
            this.rpThietLap,
            this.rpDanhMuc,
            this.rpChucNang});
            this.rcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemHyperLinkEdit2,
            this.repositoryItemHyperLinkEdit3,
            this.rhleServer});
            this.rcMain.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.rcMain.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.rcMain.ShowToolbarCustomizeItem = false;
            this.rcMain.Size = new System.Drawing.Size(884, 116);
            this.rcMain.StatusBar = this.rsbBottom;
            this.rcMain.Toolbar.ShowCustomizeItem = false;
            this.rcMain.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bhiNhanVien
            // 
            this.bhiNhanVien.Caption = "Nhân viên";
            this.bhiNhanVien.Id = 5;
            this.bhiNhanVien.Name = "bhiNhanVien";
            // 
            // frmTinhThanh
            // 
            this.frmTinhThanh.Caption = "Tỉnh thành";
            this.frmTinhThanh.Id = 11;
            this.frmTinhThanh.Name = "frmTinhThanh";
            // 
            // frmKho_List
            // 
            this.frmKho_List.Caption = "Kho";
            this.frmKho_List.Id = 12;
            this.frmKho_List.Name = "frmKho_List";
            // 
            // frmSoDuDauKyKhachHang_List
            // 
            this.frmSoDuDauKyKhachHang_List.Caption = "Khách hàng";
            this.frmSoDuDauKyKhachHang_List.Id = 13;
            this.frmSoDuDauKyKhachHang_List.Name = "frmSoDuDauKyKhachHang_List";
            // 
            // frmSoDuDauKyNhaCungCap_List
            // 
            this.frmSoDuDauKyNhaCungCap_List.Caption = "Nhà cung cấp";
            this.frmSoDuDauKyNhaCungCap_List.Id = 14;
            this.frmSoDuDauKyNhaCungCap_List.Name = "frmSoDuDauKyNhaCungCap_List";
            // 
            // frmTonKhoDauKy_List
            // 
            this.frmTonKhoDauKy_List.Caption = "Tồn kho";
            this.frmTonKhoDauKy_List.Id = 15;
            this.frmTonKhoDauKy_List.Name = "frmTonKhoDauKy_List";
            // 
            // frmNhapHangNhaCungCap_List
            // 
            this.frmNhapHangNhaCungCap_List.Caption = "Nhà cung cấp";
            this.frmNhapHangNhaCungCap_List.Id = 16;
            this.frmNhapHangNhaCungCap_List.Name = "frmNhapHangNhaCungCap_List";
            // 
            // frmDonViTinh_List
            // 
            this.frmDonViTinh_List.Caption = "ĐVT";
            this.frmDonViTinh_List.Id = 17;
            this.frmDonViTinh_List.Name = "frmDonViTinh_List";
            // 
            // frmKhachHang_List
            // 
            this.frmKhachHang_List.Caption = "Khách hàng";
            this.frmKhachHang_List.Id = 18;
            this.frmKhachHang_List.Name = "frmKhachHang_List";
            // 
            // frmNhaCungCap_List
            // 
            this.frmNhaCungCap_List.Caption = "Nhà cung cấp";
            this.frmNhaCungCap_List.Id = 19;
            this.frmNhaCungCap_List.Name = "frmNhaCungCap_List";
            // 
            // frmSanPham_List
            // 
            this.frmSanPham_List.Caption = "Sản phẩm";
            this.frmSanPham_List.Id = 20;
            this.frmSanPham_List.Name = "frmSanPham_List";
            // 
            // bsiServer
            // 
            this.bsiServer.Id = 23;
            this.bsiServer.Name = "bsiServer";
            this.bsiServer.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // rpTaiKhoan
            // 
            this.rpTaiKhoan.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.rpTaiKhoan.Name = "rpTaiKhoan";
            this.rpTaiKhoan.Text = "Tài khoản";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Nhân viên";
            // 
            // rpThietLap
            // 
            this.rpThietLap.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.rpThietLap.Name = "rpThietLap";
            this.rpThietLap.Text = "Thiết lập";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // rpDanhMuc
            // 
            this.rpDanhMuc.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.rpDanhMuc.Name = "rpDanhMuc";
            this.rpDanhMuc.Text = "Danh mục";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.frmTinhThanh);
            this.ribbonPageGroup3.ItemLinks.Add(this.frmKho_List);
            this.ribbonPageGroup3.ItemLinks.Add(this.frmDonViTinh_List);
            this.ribbonPageGroup3.ItemLinks.Add(this.frmKhachHang_List);
            this.ribbonPageGroup3.ItemLinks.Add(this.frmNhaCungCap_List);
            this.ribbonPageGroup3.ItemLinks.Add(this.frmSanPham_List);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // rpChucNang
            // 
            this.rpChucNang.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
            this.rpChucNang.Name = "rpChucNang";
            this.rpChucNang.Text = "Chức năng";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.frmSoDuDauKyKhachHang_List);
            this.ribbonPageGroup4.ItemLinks.Add(this.frmSoDuDauKyNhaCungCap_List);
            this.ribbonPageGroup4.ItemLinks.Add(this.frmTonKhoDauKy_List);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Đầu kỳ";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.frmNhapHangNhaCungCap_List);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Nhập hàng";
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            // 
            // repositoryItemHyperLinkEdit2
            // 
            this.repositoryItemHyperLinkEdit2.AutoHeight = false;
            this.repositoryItemHyperLinkEdit2.Name = "repositoryItemHyperLinkEdit2";
            // 
            // repositoryItemHyperLinkEdit3
            // 
            this.repositoryItemHyperLinkEdit3.AutoHeight = false;
            this.repositoryItemHyperLinkEdit3.Name = "repositoryItemHyperLinkEdit3";
            // 
            // rsbBottom
            // 
            this.rsbBottom.ItemLinks.Add(this.bsiServer);
            this.rsbBottom.ItemLinks.Add(this.bhiServer);
            this.rsbBottom.Location = new System.Drawing.Point(0, 384);
            this.rsbBottom.Name = "rsbBottom";
            this.rsbBottom.Ribbon = this.rcMain;
            this.rsbBottom.Size = new System.Drawing.Size(884, 27);
            // 
            // docManager
            // 
            this.docManager.MdiParent = this;
            this.docManager.MenuManager = this.rcMain;
            this.docManager.View = this.tbvMain;
            this.docManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tbvMain});
            // 
            // tbvMain
            // 
            this.tbvMain.RootContainer.Element = null;
            // 
            // rhleServer
            // 
            this.rhleServer.AutoHeight = false;
            this.rhleServer.Name = "rhleServer";
            // 
            // bhiServer
            // 
            this.bhiServer.Id = 26;
            this.bhiServer.Name = "bhiServer";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 411);
            this.Controls.Add(this.rsbBottom);
            this.Controls.Add(this.rcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm demo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.rcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhleServer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rcMain;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpTaiKhoan;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarHeaderItem bhiNhanVien;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpThietLap;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpDanhMuc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpChucNang;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Docking2010.DocumentManager docManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tbvMain;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar rsbBottom;
        private DevExpress.XtraBars.BarButtonItem frmTinhThanh;
        private DevExpress.XtraBars.BarButtonItem frmKho_List;
        private DevExpress.XtraBars.BarButtonItem frmSoDuDauKyKhachHang_List;
        private DevExpress.XtraBars.BarButtonItem frmSoDuDauKyNhaCungCap_List;
        private DevExpress.XtraBars.BarButtonItem frmTonKhoDauKy_List;
        private DevExpress.XtraBars.BarButtonItem frmNhapHangNhaCungCap_List;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem frmDonViTinh_List;
        private DevExpress.XtraBars.BarButtonItem frmKhachHang_List;
        private DevExpress.XtraBars.BarButtonItem frmNhaCungCap_List;
        private DevExpress.XtraBars.BarButtonItem frmSanPham_List;
        private DevExpress.XtraBars.BarStaticItem bsiServer;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rhleServer;
        private DevExpress.XtraBars.BarHeaderItem bhiServer;
    }
}