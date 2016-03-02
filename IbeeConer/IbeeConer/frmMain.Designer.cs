namespace IbeeConer
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnKH = new DevExpress.XtraBars.BarButtonItem();
            this.btnLSP = new DevExpress.XtraBars.BarButtonItem();
            this.barStatus = new DevExpress.XtraBars.BarHeaderItem();
            this.btnSP = new DevExpress.XtraBars.BarButtonItem();
            this.btnDatHang = new DevExpress.XtraBars.BarButtonItem();
            this.btnThongTinDH = new DevExpress.XtraBars.BarButtonItem();
            this.btnTinhTien = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnKH,
            this.btnLSP,
            this.barStatus,
            this.btnSP,
            this.btnDatHang,
            this.btnThongTinDH,
            this.btnTinhTien,
            this.skinRibbonGalleryBarItem1});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 12;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbon.Size = new System.Drawing.Size(726, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnKH
            // 
            this.btnKH.Caption = "Khách Hàng";
            this.btnKH.Glyph = ((System.Drawing.Image)(resources.GetObject("btnKH.Glyph")));
            this.btnKH.Id = 1;
            this.btnKH.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnKH.LargeGlyph")));
            this.btnKH.Name = "btnKH";
            this.btnKH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKH_ItemClick);
            // 
            // btnLSP
            // 
            this.btnLSP.Caption = "Loại Sản Phẩm";
            this.btnLSP.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLSP.Glyph")));
            this.btnLSP.Id = 4;
            this.btnLSP.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLSP.LargeGlyph")));
            this.btnLSP.Name = "btnLSP";
            this.btnLSP.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLSP_ItemClick);
            // 
            // barStatus
            // 
            this.barStatus.Caption = "barHeaderItem1";
            this.barStatus.Id = 5;
            this.barStatus.Name = "barStatus";
            // 
            // btnSP
            // 
            this.btnSP.Caption = "Sản Phẩm";
            this.btnSP.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSP.Glyph")));
            this.btnSP.Id = 7;
            this.btnSP.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSP.LargeGlyph")));
            this.btnSP.Name = "btnSP";
            this.btnSP.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSP_ItemClick);
            // 
            // btnDatHang
            // 
            this.btnDatHang.Caption = "Đặt Hàng";
            this.btnDatHang.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDatHang.Glyph")));
            this.btnDatHang.Id = 8;
            this.btnDatHang.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDatHang.LargeGlyph")));
            this.btnDatHang.Name = "btnDatHang";
            this.btnDatHang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDatHang_ItemClick);
            // 
            // btnThongTinDH
            // 
            this.btnThongTinDH.Caption = "Thông Tin Đơn Hàng";
            this.btnThongTinDH.Glyph = ((System.Drawing.Image)(resources.GetObject("btnThongTinDH.Glyph")));
            this.btnThongTinDH.Id = 9;
            this.btnThongTinDH.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnThongTinDH.LargeGlyph")));
            this.btnThongTinDH.Name = "btnThongTinDH";
            this.btnThongTinDH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThongTinDH_ItemClick);
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.Caption = "Tính Tiền";
            this.btnTinhTien.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTinhTien.Glyph")));
            this.btnTinhTien.Id = 10;
            this.btnTinhTien.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnTinhTien.LargeGlyph")));
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTinhTien_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.Id = 11;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnKH);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Quản lý khách hàng";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnLSP);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnSP);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Quản lý sản phẩm";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnDatHang);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnThongTinDH);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Đặt Hàng";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnTinhTien);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "$$$";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Setting";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "ribbonPageGroup5";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStatus);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 503);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(726, 31);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 534);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "IBEE CORNER";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnKH;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem btnLSP;
        private DevExpress.XtraBars.BarHeaderItem barStatus;
        private DevExpress.XtraBars.BarButtonItem btnSP;
        private DevExpress.XtraBars.BarButtonItem btnDatHang;
        private DevExpress.XtraBars.BarButtonItem btnThongTinDH;
        private DevExpress.XtraBars.BarButtonItem btnTinhTien;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
    }
}