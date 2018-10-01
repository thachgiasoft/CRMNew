namespace Lotus.Base
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup1 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            this.statusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.lblDatabase = new DevExpress.XtraBars.BarStaticItem();
            this.lblVersion = new DevExpress.XtraBars.BarStaticItem();
            this.lblCopyright = new DevExpress.XtraBars.BarStaticItem();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnPhanQuyen = new DevExpress.XtraBars.BarButtonItem();
            this.btnDoiMatKhau = new DevExpress.XtraBars.BarButtonItem();
            this.btnConnect = new DevExpress.XtraBars.BarButtonItem();
            this.btnRestore = new DevExpress.XtraBars.BarButtonItem();
            this.btnBackup = new DevExpress.XtraBars.BarButtonItem();
            this.btnInfo = new DevExpress.XtraBars.BarButtonItem();
            this.btnDocument = new DevExpress.XtraBars.BarButtonItem();
            this.btnThongTinDonVi = new DevExpress.XtraBars.BarButtonItem();
            this.btnVideo = new DevExpress.XtraBars.BarButtonItem();
            this.lblUser = new DevExpress.XtraBars.BarStaticItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.ribbonGalleryBarItem1 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.btnParamList = new DevExpress.XtraBars.BarButtonItem();
            this.lblSkinName = new DevExpress.XtraBars.BarStaticItem();
            this.btnImport = new DevExpress.XtraBars.BarButtonItem();
            this.btnCapNhat = new DevExpress.XtraBars.BarButtonItem();
            this.btnBanQuyen = new DevExpress.XtraBars.BarButtonItem();
            this.btnHoTro = new DevExpress.XtraBars.BarButtonItem();
            this.btnKhoaChuongTrinh = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnThongTinNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnNhanVienNghiSinh = new DevExpress.XtraBars.BarButtonItem();
            this.btnNghiPhep = new DevExpress.XtraBars.BarButtonItem();
            this.btnNhapXuatNV = new DevExpress.XtraBars.BarButtonItem();
            this.btnNhanVienMangThai = new DevExpress.XtraBars.BarButtonItem();
            this.btnNhatKyHoatDong = new DevExpress.XtraBars.BarButtonItem();
            this.btnNgonNgu = new DevExpress.XtraBars.BarButtonItem();
            this.itemNgonNgu = new DevExpress.XtraBars.BarEditItem();
            this.rItemNgonNgu = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.pageHeThong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupHethong_Nguoidung = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupHethong_DuLieu = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupHethong_ThietLap = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupHethong_GiaoDien = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageTroGiup = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.docManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rItemNgonNgu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.ItemLinks.Add(this.lblDatabase);
            this.statusBar.ItemLinks.Add(this.lblVersion);
            this.statusBar.ItemLinks.Add(this.lblCopyright);
            this.statusBar.Location = new System.Drawing.Point(0, 694);
            this.statusBar.Name = "statusBar";
            this.statusBar.Ribbon = this.ribbon;
            this.statusBar.Size = new System.Drawing.Size(990, 31);
            // 
            // lblDatabase
            // 
            this.lblDatabase.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblDatabase.Caption = "(Chưa kết nối)";
            this.lblDatabase.Id = 28;
            this.lblDatabase.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblDatabase.ImageOptions.Image")));
            this.lblDatabase.Name = "lblDatabase";
            // 
            // lblVersion
            // 
            this.lblVersion.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblVersion.Caption = "v1.0.0.1";
            this.lblVersion.Id = 30;
            this.lblVersion.Name = "lblVersion";
            // 
            // lblCopyright
            // 
            this.lblCopyright.Id = 27;
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.lblCopyright_ItemClick);
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnPhanQuyen,
            this.btnDoiMatKhau,
            this.btnConnect,
            this.btnRestore,
            this.btnBackup,
            this.btnInfo,
            this.btnDocument,
            this.btnThongTinDonVi,
            this.btnVideo,
            this.lblCopyright,
            this.lblDatabase,
            this.lblUser,
            this.lblVersion,
            this.skinRibbonGalleryBarItem1,
            this.ribbonGalleryBarItem1,
            this.btnParamList,
            this.lblSkinName,
            this.btnImport,
            this.btnCapNhat,
            this.btnBanQuyen,
            this.btnHoTro,
            this.btnKhoaChuongTrinh,
            this.btnRefresh,
            this.btnThongTinNhanVien,
            this.btnNhanVienNghiSinh,
            this.btnNghiPhep,
            this.btnNhapXuatNV,
            this.btnNhanVienMangThai,
            this.btnNhatKyHoatDong,
            this.btnNgonNgu,
            this.itemNgonNgu});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 295;
            this.ribbon.Name = "ribbon";
            this.ribbon.PageHeaderItemLinks.Add(this.itemNgonNgu);
            this.ribbon.PageHeaderItemLinks.Add(this.lblUser);
            this.ribbon.PageHeaderItemLinks.Add(this.btnKhoaChuongTrinh);
            this.ribbon.PageHeaderItemLinks.Add(this.btnRefresh);
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pageHeThong,
            this.pageTroGiup});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit1,
            this.repositoryItemMemoEdit1,
            this.repositoryItemTextEdit1,
            this.rItemNgonNgu});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(990, 146);
            this.ribbon.StatusBar = this.statusBar;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnPhanQuyen
            // 
            this.btnPhanQuyen.Caption = "Phân quyền";
            this.btnPhanQuyen.Id = 1;
            this.btnPhanQuyen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPhanQuyen.ImageOptions.Image")));
            this.btnPhanQuyen.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPhanQuyen.ImageOptions.LargeImage")));
            this.btnPhanQuyen.Name = "btnPhanQuyen";
            this.btnPhanQuyen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhanQuyen_ItemClick);
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.Caption = "Đổi mật khẩu";
            this.btnDoiMatKhau.Id = 2;
            this.btnDoiMatKhau.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDoiMatKhau.ImageOptions.Image")));
            this.btnDoiMatKhau.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDoiMatKhau.ImageOptions.LargeImage")));
            this.btnDoiMatKhau.LargeWidth = 65;
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDoiMatKhau_ItemClick);
            // 
            // btnConnect
            // 
            this.btnConnect.Caption = "Kết nối";
            this.btnConnect.Id = 4;
            this.btnConnect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.ImageOptions.Image")));
            this.btnConnect.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnConnect.ImageOptions.LargeImage")));
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConnect_ItemClick);
            // 
            // btnRestore
            // 
            this.btnRestore.Caption = "Phục hồi";
            this.btnRestore.Id = 5;
            this.btnRestore.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRestore.ImageOptions.Image")));
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRestore_ItemClick);
            // 
            // btnBackup
            // 
            this.btnBackup.Caption = "Sao lưu";
            this.btnBackup.Id = 6;
            this.btnBackup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBackup.ImageOptions.Image")));
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBackup_ItemClick);
            // 
            // btnInfo
            // 
            this.btnInfo.Caption = "Thông tin phần mềm";
            this.btnInfo.Id = 21;
            this.btnInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInfo.ImageOptions.Image")));
            this.btnInfo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnInfo.ImageOptions.LargeImage")));
            this.btnInfo.LargeWidth = 75;
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInfo_ItemClick);
            // 
            // btnDocument
            // 
            this.btnDocument.Caption = "Tài liệu hướng dẫn";
            this.btnDocument.Id = 22;
            this.btnDocument.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDocument.ImageOptions.Image")));
            this.btnDocument.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDocument.ImageOptions.LargeImage")));
            this.btnDocument.Name = "btnDocument";
            this.btnDocument.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDocument_ItemClick);
            // 
            // btnThongTinDonVi
            // 
            this.btnThongTinDonVi.Caption = "Thông tin doanh nghiệp";
            this.btnThongTinDonVi.Id = 23;
            this.btnThongTinDonVi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThongTinDonVi.ImageOptions.Image")));
            this.btnThongTinDonVi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThongTinDonVi.ImageOptions.LargeImage")));
            this.btnThongTinDonVi.Name = "btnThongTinDonVi";
            // 
            // btnVideo
            // 
            this.btnVideo.Caption = "Video hướng dẫn";
            this.btnVideo.Id = 24;
            this.btnVideo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnVideo.ImageOptions.Image")));
            this.btnVideo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnVideo.ImageOptions.LargeImage")));
            this.btnVideo.Name = "btnVideo";
            // 
            // lblUser
            // 
            this.lblUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblUser.Caption = "(Chưa đăng nhập)";
            this.lblUser.Id = 29;
            this.lblUser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblUser.ImageOptions.Image")));
            this.lblUser.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblUser.ItemAppearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUser.ItemAppearance.Normal.Options.UseFont = true;
            this.lblUser.ItemAppearance.Normal.Options.UseForeColor = true;
            this.lblUser.Name = "lblUser";
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.Id = 33;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // ribbonGalleryBarItem1
            // 
            this.ribbonGalleryBarItem1.Caption = "InplaceGallery1";
            // 
            // 
            // 
            galleryItemGroup1.Caption = "Group1";
            this.ribbonGalleryBarItem1.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup1});
            this.ribbonGalleryBarItem1.Id = 34;
            this.ribbonGalleryBarItem1.Name = "ribbonGalleryBarItem1";
            // 
            // btnParamList
            // 
            this.btnParamList.Caption = "Tham số";
            this.btnParamList.Id = 35;
            this.btnParamList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnParamList.ImageOptions.Image")));
            this.btnParamList.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnParamList.ImageOptions.LargeImage")));
            this.btnParamList.Name = "btnParamList";
            this.btnParamList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnParamList_ItemClick);
            // 
            // lblSkinName
            // 
            this.lblSkinName.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblSkinName.Id = 38;
            this.lblSkinName.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblSkinName.ImageOptions.Image")));
            this.lblSkinName.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("lblSkinName.ImageOptions.LargeImage")));
            this.lblSkinName.Name = "lblSkinName";
            // 
            // btnImport
            // 
            this.btnImport.Caption = "Import từ Excel";
            this.btnImport.Id = 46;
            this.btnImport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.ImageOptions.Image")));
            this.btnImport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnImport.ImageOptions.LargeImage")));
            this.btnImport.LargeWidth = 75;
            this.btnImport.Name = "btnImport";
            this.btnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImport_ItemClick);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Caption = "Cập nhật online";
            this.btnCapNhat.Id = 2;
            this.btnCapNhat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.ImageOptions.LargeImage")));
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCapNhat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCapNhat_ItemClick);
            // 
            // btnBanQuyen
            // 
            this.btnBanQuyen.Caption = "Thông tin bản quyền";
            this.btnBanQuyen.Id = 3;
            this.btnBanQuyen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBanQuyen.ImageOptions.Image")));
            this.btnBanQuyen.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBanQuyen.ImageOptions.LargeImage")));
            this.btnBanQuyen.Name = "btnBanQuyen";
            this.btnBanQuyen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBanQuyen_ItemClick);
            // 
            // btnHoTro
            // 
            this.btnHoTro.Caption = "Hỗ trợ";
            this.btnHoTro.Id = 60;
            this.btnHoTro.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHoTro.ImageOptions.LargeImage")));
            this.btnHoTro.Name = "btnHoTro";
            this.btnHoTro.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHoTro_ItemClick);
            // 
            // btnKhoaChuongTrinh
            // 
            this.btnKhoaChuongTrinh.Caption = "Khóa chương trình";
            this.btnKhoaChuongTrinh.Id = 91;
            this.btnKhoaChuongTrinh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKhoaChuongTrinh.ImageOptions.Image")));
            this.btnKhoaChuongTrinh.Name = "btnKhoaChuongTrinh";
            this.btnKhoaChuongTrinh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKhoaChuongTrinh_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Giải phóng bộ nhớ";
            this.btnRefresh.Id = 92;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnThongTinNhanVien
            // 
            this.btnThongTinNhanVien.Id = 254;
            this.btnThongTinNhanVien.Name = "btnThongTinNhanVien";
            // 
            // btnNhanVienNghiSinh
            // 
            this.btnNhanVienNghiSinh.Id = 255;
            this.btnNhanVienNghiSinh.Name = "btnNhanVienNghiSinh";
            // 
            // btnNghiPhep
            // 
            this.btnNghiPhep.Id = 256;
            this.btnNghiPhep.Name = "btnNghiPhep";
            // 
            // btnNhapXuatNV
            // 
            this.btnNhapXuatNV.Id = 257;
            this.btnNhapXuatNV.Name = "btnNhapXuatNV";
            // 
            // btnNhanVienMangThai
            // 
            this.btnNhanVienMangThai.Id = 258;
            this.btnNhanVienMangThai.Name = "btnNhanVienMangThai";
            // 
            // btnNhatKyHoatDong
            // 
            this.btnNhatKyHoatDong.Caption = "Nhật ký hoạt động";
            this.btnNhatKyHoatDong.Id = 260;
            this.btnNhatKyHoatDong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNhatKyHoatDong.ImageOptions.Image")));
            this.btnNhatKyHoatDong.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNhatKyHoatDong.ImageOptions.LargeImage")));
            this.btnNhatKyHoatDong.Name = "btnNhatKyHoatDong";
            this.btnNhatKyHoatDong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNhatKyHoatDong_ItemClick);
            // 
            // btnNgonNgu
            // 
            this.btnNgonNgu.Caption = "Dịch ngôn ngữ";
            this.btnNgonNgu.Id = 293;
            this.btnNgonNgu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNgonNgu.ImageOptions.Image")));
            this.btnNgonNgu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNgonNgu.ImageOptions.LargeImage")));
            this.btnNgonNgu.Name = "btnNgonNgu";
            this.btnNgonNgu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNgonNgu_ItemClick);
            // 
            // itemNgonNgu
            // 
            this.itemNgonNgu.Caption = "Ngôn ngữ";
            this.itemNgonNgu.Edit = this.rItemNgonNgu;
            this.itemNgonNgu.EditWidth = 120;
            this.itemNgonNgu.Id = 294;
            this.itemNgonNgu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("itemNgonNgu.ImageOptions.Image")));
            this.itemNgonNgu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("itemNgonNgu.ImageOptions.LargeImage")));
            this.itemNgonNgu.Name = "itemNgonNgu";
            this.itemNgonNgu.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.itemNgonNgu.EditValueChanged += new System.EventHandler(this.itemNgonNgu_EditValueChanged);
            // 
            // rItemNgonNgu
            // 
            this.rItemNgonNgu.AutoHeight = false;
            this.rItemNgonNgu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rItemNgonNgu.Name = "rItemNgonNgu";
       
            // 
            // pageHeThong
            // 
            this.pageHeThong.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.groupHethong_Nguoidung,
            this.groupHethong_DuLieu,
            this.groupHethong_ThietLap,
            this.groupHethong_GiaoDien});
            this.pageHeThong.Image = ((System.Drawing.Image)(resources.GetObject("pageHeThong.Image")));
            this.pageHeThong.Name = "pageHeThong";
            this.pageHeThong.Text = "Hệ thống";
            // 
            // groupHethong_Nguoidung
            // 
            this.groupHethong_Nguoidung.ItemLinks.Add(this.btnPhanQuyen);
            this.groupHethong_Nguoidung.ItemLinks.Add(this.btnDoiMatKhau);
            this.groupHethong_Nguoidung.ItemLinks.Add(this.btnNhatKyHoatDong);
            this.groupHethong_Nguoidung.Name = "groupHethong_Nguoidung";
            this.groupHethong_Nguoidung.ShowCaptionButton = false;
            this.groupHethong_Nguoidung.Text = "Người dùng";
            // 
            // groupHethong_DuLieu
            // 
            this.groupHethong_DuLieu.ItemLinks.Add(this.btnConnect, true);
            this.groupHethong_DuLieu.ItemLinks.Add(this.btnRestore);
            this.groupHethong_DuLieu.ItemLinks.Add(this.btnBackup);
            this.groupHethong_DuLieu.Name = "groupHethong_DuLieu";
            this.groupHethong_DuLieu.ShowCaptionButton = false;
            this.groupHethong_DuLieu.Text = "Dữ liệu";
            // 
            // groupHethong_ThietLap
            // 
            this.groupHethong_ThietLap.ItemLinks.Add(this.btnNgonNgu);
            this.groupHethong_ThietLap.ItemLinks.Add(this.btnParamList);
            this.groupHethong_ThietLap.ItemLinks.Add(this.btnImport);
            this.groupHethong_ThietLap.ItemLinks.Add(this.btnKhoaChuongTrinh);
            this.groupHethong_ThietLap.ItemLinks.Add(this.btnRefresh);
            this.groupHethong_ThietLap.Name = "groupHethong_ThietLap";
            this.groupHethong_ThietLap.ShowCaptionButton = false;
            this.groupHethong_ThietLap.Text = "Thiết lập";
            // 
            // groupHethong_GiaoDien
            // 
            this.groupHethong_GiaoDien.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.groupHethong_GiaoDien.Name = "groupHethong_GiaoDien";
            this.groupHethong_GiaoDien.ShowCaptionButton = false;
            this.groupHethong_GiaoDien.Text = "Giao diện";
            // 
            // pageTroGiup
            // 
            this.pageTroGiup.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup8,
            this.ribbonPageGroup9});
            this.pageTroGiup.Image = ((System.Drawing.Image)(resources.GetObject("pageTroGiup.Image")));
            this.pageTroGiup.Name = "pageTroGiup";
            this.pageTroGiup.Text = "Trợ giúp";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.btnInfo);
            this.ribbonPageGroup8.ItemLinks.Add(this.btnBanQuyen);
            this.ribbonPageGroup8.ItemLinks.Add(this.btnCapNhat);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.ShowCaptionButton = false;
            this.ribbonPageGroup8.Text = "Thông tin";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.ItemLinks.Add(this.btnDocument);
            this.ribbonPageGroup9.ItemLinks.Add(this.btnVideo);
            this.ribbonPageGroup9.ItemLinks.Add(this.btnHoTro);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.ShowCaptionButton = false;
            this.ribbonPageGroup9.Text = "Hướng dẫn";
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // docManager
            // 
            this.docManager.MdiParent = this;
            this.docManager.MenuManager = this.ribbon;
            this.docManager.ShowThumbnailsInTaskBar = DevExpress.Utils.DefaultBoolean.False;
            this.docManager.View = this.tabbedView1;
            this.docManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // tabbedView1
            // 
            this.tabbedView1.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabbedView1.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tabbedView1.BackgroundImageLayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.TopLeft;
            this.tabbedView1.RootContainer.Element = null;
            this.tabbedView1.UseDocumentSelector = DevExpress.Utils.DefaultBoolean.True;
            this.tabbedView1.UseLoadingIndicator = DevExpress.Utils.DefaultBoolean.True;
            this.tabbedView1.UseSnappingEmulation = DevExpress.Utils.DefaultBoolean.False;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Lý luận chính trị";
            this.barButtonItem1.Id = 179;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // FrmMain
            // 
            this.AllowMdiBar = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 725);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1000, 726);
            this.Name = "FrmMain";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.statusBar;
            this.Text = "Phần mềm quản lý nhân sự HRM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rItemNgonNgu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    

        #endregion

        protected DevExpress.XtraBars.Ribbon.RibbonStatusBar statusBar;
        protected DevExpress.XtraBars.Docking2010.DocumentManager docManager;
        protected DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        protected DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        protected DevExpress.XtraBars.BarButtonItem btnPhanQuyen;
        protected DevExpress.XtraBars.BarButtonItem btnDoiMatKhau;
        protected DevExpress.XtraBars.BarButtonItem btnConnect;
        protected DevExpress.XtraBars.BarButtonItem btnRestore;
        protected DevExpress.XtraBars.BarButtonItem btnBackup;
        protected DevExpress.XtraBars.BarButtonItem btnInfo;
        protected DevExpress.XtraBars.BarButtonItem btnDocument;
        protected DevExpress.XtraBars.BarButtonItem btnThongTinDonVi;
        protected DevExpress.XtraBars.BarButtonItem btnVideo;
        protected DevExpress.XtraBars.BarStaticItem lblCopyright;
        protected DevExpress.XtraBars.BarStaticItem lblDatabase;
        protected DevExpress.XtraBars.BarStaticItem lblUser;
        protected DevExpress.XtraBars.BarStaticItem lblVersion;
        protected DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        protected DevExpress.XtraBars.RibbonGalleryBarItem ribbonGalleryBarItem1;
        protected DevExpress.XtraBars.BarButtonItem btnParamList;
        protected DevExpress.XtraBars.BarStaticItem lblSkinName;
        protected DevExpress.XtraBars.BarButtonItem btnImport;
        protected DevExpress.XtraBars.BarButtonItem btnCapNhat;
        protected DevExpress.XtraBars.BarButtonItem btnBanQuyen;
        protected DevExpress.XtraBars.BarButtonItem btnHoTro;
        protected DevExpress.XtraBars.BarButtonItem btnKhoaChuongTrinh;
        protected DevExpress.XtraBars.BarButtonItem btnRefresh;
        protected DevExpress.XtraBars.Ribbon.RibbonPage pageHeThong;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup groupHethong_Nguoidung;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup groupHethong_DuLieu;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup groupHethong_ThietLap;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup groupHethong_GiaoDien;
        protected DevExpress.XtraBars.Ribbon.RibbonPage pageTroGiup;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
        protected DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        protected DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        protected DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        protected DevExpress.XtraBars.BarButtonItem btnThongTinNhanVien;
        protected DevExpress.XtraBars.BarButtonItem btnNhanVienNghiSinh;
        protected DevExpress.XtraBars.BarButtonItem btnNghiPhep;
        protected DevExpress.XtraBars.BarButtonItem btnNhapXuatNV;
        protected DevExpress.XtraBars.BarButtonItem btnNhanVienMangThai;
        protected DevExpress.XtraBars.BarButtonItem btnNhatKyHoatDong;
        protected DevExpress.XtraBars.BarButtonItem btnNgonNgu;
        protected DevExpress.XtraBars.BarEditItem itemNgonNgu;
        protected DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox rItemNgonNgu;
    }
}

