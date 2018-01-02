namespace Client.GUI.DanhMuc
{
    partial class frmTinhThanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTinhThanh));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.trlDanhSach = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.lokTen3 = new DevExpress.XtraEditors.LookUpEdit();
            this.lokTen2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lokTen1 = new DevExpress.XtraEditors.LookUpEdit();
            this.lokLoai3 = new DevExpress.XtraEditors.LookUpEdit();
            this.lokLoai2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lokLoai1 = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokTen3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokTen2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokTen1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokLoai3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokLoai2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokLoai1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnTimKiem);
            this.layoutControl1.Controls.Add(this.trlDanhSach);
            this.layoutControl1.Controls.Add(this.lokTen3);
            this.layoutControl1.Controls.Add(this.lokTen2);
            this.layoutControl1.Controls.Add(this.lokTen1);
            this.layoutControl1.Controls.Add(this.lokLoai3);
            this.layoutControl1.Controls.Add(this.lokLoai2);
            this.layoutControl1.Controls.Add(this.lokLoai1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(482, 136, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(884, 360);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // trlDanhSach
            // 
            this.trlDanhSach.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.trlDanhSach.Location = new System.Drawing.Point(24, 90);
            this.trlDanhSach.Name = "trlDanhSach";
            this.trlDanhSach.Size = new System.Drawing.Size(836, 246);
            this.trlDanhSach.TabIndex = 10;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Tên";
            this.treeListColumn1.FieldName = "Ten";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // lokTen3
            // 
            this.lokTen3.Location = new System.Drawing.Point(631, 66);
            this.lokTen3.MenuManager = this.barMenu;
            this.lokTen3.Name = "lokTen3";
            this.lokTen3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokTen3.Properties.NullText = "";
            this.lokTen3.Size = new System.Drawing.Size(119, 20);
            this.lokTen3.StyleController = this.layoutControl1;
            this.lokTen3.TabIndex = 9;
            // 
            // lokTen2
            // 
            this.lokTen2.Location = new System.Drawing.Point(388, 66);
            this.lokTen2.MenuManager = this.barMenu;
            this.lokTen2.Name = "lokTen2";
            this.lokTen2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokTen2.Properties.NullText = "";
            this.lokTen2.Size = new System.Drawing.Size(118, 20);
            this.lokTen2.StyleController = this.layoutControl1;
            this.lokTen2.TabIndex = 8;
            // 
            // lokTen1
            // 
            this.lokTen1.Location = new System.Drawing.Point(145, 66);
            this.lokTen1.MenuManager = this.barMenu;
            this.lokTen1.Name = "lokTen1";
            this.lokTen1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokTen1.Properties.NullText = "";
            this.lokTen1.Size = new System.Drawing.Size(118, 20);
            this.lokTen1.StyleController = this.layoutControl1;
            this.lokTen1.TabIndex = 7;
            // 
            // lokLoai3
            // 
            this.lokLoai3.Location = new System.Drawing.Point(631, 42);
            this.lokLoai3.MenuManager = this.barMenu;
            this.lokLoai3.Name = "lokLoai3";
            this.lokLoai3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokLoai3.Properties.NullText = "";
            this.lokLoai3.Size = new System.Drawing.Size(119, 20);
            this.lokLoai3.StyleController = this.layoutControl1;
            this.lokLoai3.TabIndex = 6;
            // 
            // lokLoai2
            // 
            this.lokLoai2.Location = new System.Drawing.Point(388, 42);
            this.lokLoai2.MenuManager = this.barMenu;
            this.lokLoai2.Name = "lokLoai2";
            this.lokLoai2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokLoai2.Properties.NullText = "";
            this.lokLoai2.Size = new System.Drawing.Size(118, 20);
            this.lokLoai2.StyleController = this.layoutControl1;
            this.lokLoai2.TabIndex = 5;
            // 
            // lokLoai1
            // 
            this.lokLoai1.Location = new System.Drawing.Point(145, 42);
            this.lokLoai1.MenuManager = this.barMenu;
            this.lokLoai1.Name = "lokLoai1";
            this.lokLoai1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokLoai1.Properties.NullText = "";
            this.lokLoai1.Size = new System.Drawing.Size(118, 20);
            this.lokLoai1.StyleController = this.layoutControl1;
            this.lokLoai1.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(884, 360);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem2,
            this.layoutControlItem7,
            this.layoutControlItem3,
            this.layoutControlItem8,
            this.layoutControlItem6});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(864, 340);
            this.layoutControlGroup2.Text = "Thông tin tìm kiếm";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lokLoai1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(243, 24);
            this.layoutControlItem1.Text = "Loại Tỉnh/Thành phố";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(118, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lokTen1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(243, 24);
            this.layoutControlItem4.Text = "Tỉnh/Thành phố";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(118, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lokTen2;
            this.layoutControlItem5.Location = new System.Drawing.Point(243, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(243, 24);
            this.layoutControlItem5.Text = "Quận/Huyện/Thị Xã";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(118, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lokLoai2;
            this.layoutControlItem2.Location = new System.Drawing.Point(243, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(243, 24);
            this.layoutControlItem2.Text = "Loại Quận/Huyện/Thị Xã";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(118, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lokLoai3;
            this.layoutControlItem3.Location = new System.Drawing.Point(486, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(244, 24);
            this.layoutControlItem3.Text = "Loại Xã/Phường/Thị Trấn";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(118, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lokTen3;
            this.layoutControlItem6.Location = new System.Drawing.Point(486, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(244, 24);
            this.layoutControlItem6.Text = "Xã/Phường/Thị Trấn";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(118, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.trlDanhSach;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(840, 250);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Image = global::Client.Properties.Resources.Zoom_32x32;
            this.btnTimKiem.Location = new System.Drawing.Point(754, 42);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(106, 44);
            this.btnTimKiem.StyleController = this.layoutControl1;
            this.btnTimKiem.TabIndex = 11;
            this.btnTimKiem.Text = "Tìm kiếm";
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnTimKiem;
            this.layoutControlItem8.Location = new System.Drawing.Point(730, 0);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(110, 48);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(110, 48);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(110, 48);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // frmTinhThanh_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 411);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmTinhThanh";
            this.Text = "Danh sách tỉnh thành";
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokTen3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokTen2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokTen1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokLoai3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokLoai2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokLoai1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit lokTen3;
        private DevExpress.XtraEditors.LookUpEdit lokTen2;
        private DevExpress.XtraEditors.LookUpEdit lokTen1;
        private DevExpress.XtraEditors.LookUpEdit lokLoai3;
        private DevExpress.XtraEditors.LookUpEdit lokLoai2;
        private DevExpress.XtraEditors.LookUpEdit lokLoai1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraTreeList.TreeList trlDanhSach;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}