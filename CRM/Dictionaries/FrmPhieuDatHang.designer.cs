namespace CRM.Dictionaries
{
    partial class FrmPhieuDatHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPhieuDatHang));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.customGridControl1 = new Lotus.Libraries.CustomGridControl();
            this.phieuDatHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.data = new CRM.CRMData();
            this.customGridView1 = new Lotus.Libraries.CustomGridView();
            this.colSoPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repKhachHang = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.khachHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colHinhThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repHinhThuc = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.colTienHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTienCK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTienPhieuGiamGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTongThanhToan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMucDichSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNVBanHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayTrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repTrangThai = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.colThanhToan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConLai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rsearchNhanVien = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChi1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCMND1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienThoai1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.phieuDatHangTableAdapter = new CRM.CRMDataTableAdapters.PhieuDatHangTableAdapter();
            this.khachHangTableAdapter = new CRM.CRMDataTableAdapters.KhachHangTableAdapter();
            this.btnInPhieuXuat = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnInPhieuXuatBH = new DevExpress.XtraBars.BarButtonItem();
            this.colNVVanDon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShipper = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dtNhatKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgCalc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSpin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phieuDatHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repHinhThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsearchNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // itemDateFrom
            // 
            this.itemDateFrom.EditValue = new System.DateTime(2018, 9, 1, 0, 0, 0, 0);
            this.itemDateFrom.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // itemDateTo
            // 
            this.itemDateTo.EditValue = new System.DateTime(2018, 9, 30, 23, 59, 59, 0);
            // 
            // itemMonth
            // 
            this.itemMonth.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            // 
            // itemYear
            // 
            this.itemYear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            // 
            // itemType
            // 
            this.itemType.EditValue = 2;
            // 
            // bm
            // 
            this.bm.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnInPhieuXuat,
            this.barSubItem1,
            this.btnInPhieuXuatBH});
            this.bm.MaxItemId = 12;
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            // 
            // btnReload
            // 
            this.btnReload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.ImageOptions.Image")));
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            // 
            // btnEdit
            // 
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            // 
            // btnPrint
            // 
            this.btnPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.ImageOptions.Image")));
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Caption = "In danh sách";
            this.btnPrintPreview.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintPreview.ImageOptions.Image")));
            // 
            // rgCollection
            // 
            this.rgCollection.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rgCalc,
            this.rgDate,
            this.rgSpin});
            // 
            // rgCalc
            // 
            this.rgCalc.DisplayFormat.FormatString = "#,#0.##;(#,#0.##);-";
            this.rgCalc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.rgCalc.EditFormat.FormatString = "#,#0.##;(#,#0.##);-";
            this.rgCalc.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            // 
            // rgDate
            // 
            // 
            // bar1
            // 
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnReload, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            // 
            // rgSpin
            // 
            this.rgSpin.DisplayFormat.FormatString = "#,#0.##;(#,#0.##);-";
            this.rgSpin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rgSpin.EditFormat.FormatString = "#,#0.##;(#,#0.##);-";
            this.rgSpin.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.customGridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 60);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1220, 527);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // customGridControl1
            // 
            this.customGridControl1.DataSource = this.phieuDatHangBindingSource;
            this.customGridControl1.ExternalRepository = this.rgCollection;
            this.customGridControl1.Location = new System.Drawing.Point(2, 2);
            this.customGridControl1.MainView = this.customGridView1;
            this.customGridControl1.MenuManager = this.bm;
            this.customGridControl1.Name = "customGridControl1";
            this.customGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rsearchNhanVien,
            this.repTrangThai,
            this.repHinhThuc,
            this.repKhachHang});
            this.customGridControl1.Size = new System.Drawing.Size(1216, 523);
            this.customGridControl1.TabIndex = 4;
            this.customGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.customGridView1});
            // 
            // phieuDatHangBindingSource
            // 
            this.phieuDatHangBindingSource.DataMember = "PhieuDatHang";
            this.phieuDatHangBindingSource.DataSource = this.data;
            // 
            // data
            // 
            this.data.DataSetName = "Data";
            this.data.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customGridView1
            // 
            this.customGridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.customGridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.customGridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.customGridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.customGridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.customGridView1.Appearance.GroupFooter.Options.UseFont = true;
            this.customGridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.customGridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.customGridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.customGridView1.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.customGridView1.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.customGridView1.AppearancePrint.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.customGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSoPhieu,
            this.colNgayPhieu,
            this.colKhachHang,
            this.colHinhThuc,
            this.colTienHang,
            this.colTienCK,
            this.colTienPhieuGiamGia,
            this.colTongThanhToan,
            this.colGhiChu,
            this.colMucDichSD,
            this.colNVBanHang,
            this.colNgayTrangThai,
            this.colTrangThai,
            this.colThanhToan,
            this.colConLai,
            this.colNVVanDon,
            this.colShipper});
            this.customGridView1.FixedLineWidth = 1;
            this.customGridView1.FormatCode = null;
            this.customGridView1.GridControl = this.customGridControl1;
            this.customGridView1.GroupCount = 1;
            this.customGridView1.GroupFormat = "[#image]{1} {2}";
            this.customGridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TongThanhToan", this.colTongThanhToan, "{0:#,#0;(#,#0);-}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienHang", this.colTienHang, "{0:#,#0;(#,#0);-}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienCK", this.colTienCK, "{0:#,#0;(#,#0);-}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienPhieuGiamGia", this.colTienPhieuGiamGia, "{0:#,#0;(#,#0);-}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThanhToan", this.colThanhToan, "{0:#,#0;(#,#0);-}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ConLai", this.colConLai, "{0:#,#0;(#,#0);-}")});
            this.customGridView1.IndicatorWidth = 31;
            this.customGridView1.KeyColumn = "TenBL";
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.NotNullColumns = "TenPhapLy";
            this.customGridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.customGridView1.OptionsDetail.EnableMasterViewMode = false;
            this.customGridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.customGridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.customGridView1.OptionsView.ShowFooter = true;
            this.customGridView1.ShowIndexIndicator = true;
            this.customGridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNVBanHang, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.customGridView1.UseAutoCode = false;
            this.customGridView1.UseAutoLog = true;
            this.customGridView1.DoubleClick += new System.EventHandler(this.customGridView1_DoubleClick);
            // 
            // colSoPhieu
            // 
            this.colSoPhieu.AppearanceCell.Options.UseTextOptions = true;
            this.colSoPhieu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoPhieu.FieldName = "SoPhieu";
            this.colSoPhieu.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colSoPhieu.Name = "colSoPhieu";
            this.colSoPhieu.OptionsColumn.AllowEdit = false;
            this.colSoPhieu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoPhieu.Visible = true;
            this.colSoPhieu.VisibleIndex = 0;
            this.colSoPhieu.Width = 180;
            // 
            // colNgayPhieu
            // 
            this.colNgayPhieu.AppearanceCell.Options.UseTextOptions = true;
            this.colNgayPhieu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayPhieu.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.colNgayPhieu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayPhieu.FieldName = "NgayPhieu";
            this.colNgayPhieu.Name = "colNgayPhieu";
            this.colNgayPhieu.OptionsColumn.AllowEdit = false;
            this.colNgayPhieu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgayPhieu.Visible = true;
            this.colNgayPhieu.VisibleIndex = 1;
            this.colNgayPhieu.Width = 120;
            // 
            // colKhachHang
            // 
            this.colKhachHang.ColumnEdit = this.repKhachHang;
            this.colKhachHang.FieldName = "KhachHang";
            this.colKhachHang.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colKhachHang.Name = "colKhachHang";
            this.colKhachHang.OptionsColumn.AllowEdit = false;
            this.colKhachHang.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colKhachHang.Visible = true;
            this.colKhachHang.VisibleIndex = 3;
            this.colKhachHang.Width = 160;
            // 
            // repKhachHang
            // 
            this.repKhachHang.AutoHeight = false;
            this.repKhachHang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repKhachHang.DataSource = this.khachHangBindingSource;
            this.repKhachHang.DisplayMember = "TenKH";
            this.repKhachHang.Name = "repKhachHang";
            this.repKhachHang.ValueMember = "MaKH";
            // 
            // khachHangBindingSource
            // 
            this.khachHangBindingSource.DataMember = "KhachHang";
            this.khachHangBindingSource.DataSource = this.data;
            // 
            // colHinhThuc
            // 
            this.colHinhThuc.ColumnEdit = this.repHinhThuc;
            this.colHinhThuc.FieldName = "HinhThuc";
            this.colHinhThuc.Name = "colHinhThuc";
            this.colHinhThuc.OptionsColumn.AllowEdit = false;
            this.colHinhThuc.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colHinhThuc.Visible = true;
            this.colHinhThuc.VisibleIndex = 2;
            // 
            // repHinhThuc
            // 
            this.repHinhThuc.AutoHeight = false;
            this.repHinhThuc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repHinhThuc.Name = "repHinhThuc";
            this.repHinhThuc.SmallImages = this.imageCollection1;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "if_Phone_2744956.png");
            this.imageCollection1.InsertGalleryImage("bocontact_16x16.png", "images/business%20objects/bocontact_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bocontact_16x16.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "bocontact_16x16.png");
            // 
            // colTienHang
            // 
            this.colTienHang.ColumnEdit = this.rgCalc;
            this.colTienHang.FieldName = "TienHang";
            this.colTienHang.Name = "colTienHang";
            this.colTienHang.OptionsColumn.AllowEdit = false;
            this.colTienHang.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTienHang.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienHang", "{0:#,#0}")});
            this.colTienHang.Visible = true;
            this.colTienHang.VisibleIndex = 5;
            this.colTienHang.Width = 120;
            // 
            // colTienCK
            // 
            this.colTienCK.Caption = "Tiền giảm khác";
            this.colTienCK.ColumnEdit = this.rgCalc;
            this.colTienCK.FieldName = "TienCK";
            this.colTienCK.Name = "colTienCK";
            this.colTienCK.OptionsColumn.AllowEdit = false;
            this.colTienCK.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTienCK.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienCK", "{0:#,#0}")});
            this.colTienCK.Visible = true;
            this.colTienCK.VisibleIndex = 6;
            this.colTienCK.Width = 100;
            // 
            // colTienPhieuGiamGia
            // 
            this.colTienPhieuGiamGia.ColumnEdit = this.rgCalc;
            this.colTienPhieuGiamGia.FieldName = "TienPhieuGiamGia";
            this.colTienPhieuGiamGia.Name = "colTienPhieuGiamGia";
            this.colTienPhieuGiamGia.OptionsColumn.AllowEdit = false;
            this.colTienPhieuGiamGia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTienPhieuGiamGia.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienPhieuGiamGia", "{0:#,#0}")});
            this.colTienPhieuGiamGia.Visible = true;
            this.colTienPhieuGiamGia.VisibleIndex = 7;
            this.colTienPhieuGiamGia.Width = 100;
            // 
            // colTongThanhToan
            // 
            this.colTongThanhToan.ColumnEdit = this.rgCalc;
            this.colTongThanhToan.FieldName = "TongThanhToan";
            this.colTongThanhToan.Name = "colTongThanhToan";
            this.colTongThanhToan.OptionsColumn.AllowEdit = false;
            this.colTongThanhToan.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTongThanhToan.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TongThanhToan", "{0:#,#0}")});
            this.colTongThanhToan.Visible = true;
            this.colTongThanhToan.VisibleIndex = 8;
            this.colTongThanhToan.Width = 120;
            // 
            // colGhiChu
            // 
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.OptionsColumn.AllowEdit = false;
            this.colGhiChu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 11;
            this.colGhiChu.Width = 116;
            // 
            // colMucDichSD
            // 
            this.colMucDichSD.FieldName = "MucDichSD";
            this.colMucDichSD.Name = "colMucDichSD";
            this.colMucDichSD.OptionsColumn.AllowEdit = false;
            this.colMucDichSD.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMucDichSD.Visible = true;
            this.colMucDichSD.VisibleIndex = 4;
            this.colMucDichSD.Width = 200;
            // 
            // colNVBanHang
            // 
            this.colNVBanHang.FieldName = "NVBanHang";
            this.colNVBanHang.Name = "colNVBanHang";
            this.colNVBanHang.OptionsColumn.AllowEdit = false;
            this.colNVBanHang.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNVBanHang.Visible = true;
            this.colNVBanHang.VisibleIndex = 12;
            // 
            // colNgayTrangThai
            // 
            this.colNgayTrangThai.AppearanceCell.Options.UseTextOptions = true;
            this.colNgayTrangThai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayTrangThai.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.colNgayTrangThai.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayTrangThai.FieldName = "NgayTrangThai";
            this.colNgayTrangThai.Name = "colNgayTrangThai";
            this.colNgayTrangThai.OptionsColumn.AllowEdit = false;
            this.colNgayTrangThai.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgayTrangThai.Visible = true;
            this.colNgayTrangThai.VisibleIndex = 13;
            this.colNgayTrangThai.Width = 106;
            // 
            // colTrangThai
            // 
            this.colTrangThai.ColumnEdit = this.repTrangThai;
            this.colTrangThai.FieldName = "TrangThai";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.OptionsColumn.AllowEdit = false;
            this.colTrangThai.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTrangThai.Visible = true;
            this.colTrangThai.VisibleIndex = 12;
            this.colTrangThai.Width = 89;
            // 
            // repTrangThai
            // 
            this.repTrangThai.AutoHeight = false;
            this.repTrangThai.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repTrangThai.Name = "repTrangThai";
            this.repTrangThai.SmallImages = this.imageCollection2;
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            this.imageCollection2.Images.SetKeyName(0, "Key-icon.png");
            this.imageCollection2.Images.SetKeyName(1, "Accept-icon.png");
            this.imageCollection2.Images.SetKeyName(2, "deletered.png");
            // 
            // colThanhToan
            // 
            this.colThanhToan.ColumnEdit = this.rgCalc;
            this.colThanhToan.FieldName = "ThanhToan";
            this.colThanhToan.Name = "colThanhToan";
            this.colThanhToan.OptionsColumn.AllowEdit = false;
            this.colThanhToan.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colThanhToan.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThanhToan", "{0:#,#0}")});
            this.colThanhToan.Visible = true;
            this.colThanhToan.VisibleIndex = 9;
            this.colThanhToan.Width = 100;
            // 
            // colConLai
            // 
            this.colConLai.ColumnEdit = this.rgCalc;
            this.colConLai.FieldName = "ConLai";
            this.colConLai.Name = "colConLai";
            this.colConLai.OptionsColumn.AllowEdit = false;
            this.colConLai.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colConLai.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ConLai", "{0:#,#0}")});
            this.colConLai.Visible = true;
            this.colConLai.VisibleIndex = 10;
            this.colConLai.Width = 100;
            // 
            // rsearchNhanVien
            // 
            this.rsearchNhanVien.AutoHeight = false;
            this.rsearchNhanVien.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rsearchNhanVien.DisplayMember = "HoTen";
            this.rsearchNhanVien.Name = "rsearchNhanVien";
            this.rsearchNhanVien.ValueMember = "MaNV";
            this.rsearchNhanVien.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaNV,
            this.colHoTen,
            this.colDiaChi1,
            this.colCMND1,
            this.colDienThoai1});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colMaNV
            // 
            this.colMaNV.FieldName = "MaNV";
            this.colMaNV.Name = "colMaNV";
            this.colMaNV.Visible = true;
            this.colMaNV.VisibleIndex = 0;
            this.colMaNV.Width = 185;
            // 
            // colHoTen
            // 
            this.colHoTen.FieldName = "HoTen";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.Visible = true;
            this.colHoTen.VisibleIndex = 1;
            this.colHoTen.Width = 288;
            // 
            // colDiaChi1
            // 
            this.colDiaChi1.FieldName = "DiaChi";
            this.colDiaChi1.Name = "colDiaChi1";
            this.colDiaChi1.Visible = true;
            this.colDiaChi1.VisibleIndex = 4;
            this.colDiaChi1.Width = 708;
            // 
            // colCMND1
            // 
            this.colCMND1.FieldName = "CMND";
            this.colCMND1.Name = "colCMND1";
            this.colCMND1.Visible = true;
            this.colCMND1.VisibleIndex = 2;
            this.colCMND1.Width = 194;
            // 
            // colDienThoai1
            // 
            this.colDienThoai1.FieldName = "DienThoai";
            this.colDienThoai1.Name = "colDienThoai1";
            this.colDienThoai1.Visible = true;
            this.colDienThoai1.VisibleIndex = 3;
            this.colDienThoai1.Width = 247;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1220, 527);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.customGridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1220, 527);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // phieuDatHangTableAdapter
            // 
            this.phieuDatHangTableAdapter.ClearBeforeFill = true;
            // 
            // khachHangTableAdapter
            // 
            this.khachHangTableAdapter.ClearBeforeFill = true;
            // 
            // btnInPhieuXuat
            // 
            this.btnInPhieuXuat.Caption = "In phiếu xuất";
            this.btnInPhieuXuat.Id = 9;
            this.btnInPhieuXuat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInPhieuXuat.ImageOptions.Image")));
            this.btnInPhieuXuat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnInPhieuXuat.ImageOptions.LargeImage")));
            this.btnInPhieuXuat.Name = "btnInPhieuXuat";
            this.btnInPhieuXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInPhieuXuat_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barSubItem1.Caption = "In";
            this.barSubItem1.Id = 10;
            this.barSubItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem1.ImageOptions.Image")));
            this.barSubItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barSubItem1.ImageOptions.LargeImage")));
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnInPhieuXuat),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnInPhieuXuatBH),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrintPreview, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnInPhieuXuatBH
            // 
            this.btnInPhieuXuatBH.Caption = "In phiếu xuất kho bán hàng";
            this.btnInPhieuXuatBH.Id = 11;
            this.btnInPhieuXuatBH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInPhieuXuatBH.ImageOptions.Image")));
            this.btnInPhieuXuatBH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnInPhieuXuatBH.ImageOptions.LargeImage")));
            this.btnInPhieuXuatBH.Name = "btnInPhieuXuatBH";
            this.btnInPhieuXuatBH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInPhieuXuatBH_ItemClick);
            // 
            // colNVVanDon
            // 
            this.colNVVanDon.FieldName = "NVVanDon";
            this.colNVVanDon.Name = "colNVVanDon";
            this.colNVVanDon.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNVVanDon.Visible = true;
            this.colNVVanDon.VisibleIndex = 14;
            this.colNVVanDon.Width = 100;
            // 
            // colShipper
            // 
            this.colShipper.FieldName = "Shipper";
            this.colShipper.Name = "colShipper";
            this.colShipper.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colShipper.Visible = true;
            this.colShipper.VisibleIndex = 15;
            this.colShipper.Width = 200;
            // 
            // FrmPhieuDatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 587);
            this.Controls.Add(this.layoutControl1);
            this.DateFrom = new System.DateTime(2018, 9, 1, 0, 0, 0, 0);
            this.DateTo = new System.DateTime(2018, 9, 30, 23, 59, 59, 0);
            this.Name = "FrmPhieuDatHang";
            this.ReportType = Lotus.Base.ReportType.Month;
            this.Text = "Phiếu đặt hàng";
            this.Load += new System.EventHandler(this.FrmPhapLy_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this._dtNhatKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgCalc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSpin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phieuDatHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repHinhThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsearchNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private Lotus.Libraries.CustomGridControl customGridControl1;
        private Lotus.Libraries.CustomGridView customGridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private CRMData data;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rsearchNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNV;
        private DevExpress.XtraGrid.Columns.GridColumn colHoTen;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChi1;
        private DevExpress.XtraGrid.Columns.GridColumn colCMND1;
        private DevExpress.XtraGrid.Columns.GridColumn colDienThoai1;
        private System.Windows.Forms.BindingSource phieuDatHangBindingSource;
        private CRMDataTableAdapters.PhieuDatHangTableAdapter phieuDatHangTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colSoPhieu;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayPhieu;
        private DevExpress.XtraGrid.Columns.GridColumn colKhachHang;
        private DevExpress.XtraGrid.Columns.GridColumn colHinhThuc;
        private DevExpress.XtraGrid.Columns.GridColumn colTienHang;
        private DevExpress.XtraGrid.Columns.GridColumn colTienCK;
        private DevExpress.XtraGrid.Columns.GridColumn colTienPhieuGiamGia;
        private DevExpress.XtraGrid.Columns.GridColumn colTongThanhToan;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn colMucDichSD;
        private DevExpress.XtraGrid.Columns.GridColumn colNVBanHang;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayTrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn colThanhToan;
        private DevExpress.XtraGrid.Columns.GridColumn colConLai;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repTrangThai;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repHinhThuc;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.Utils.ImageCollection imageCollection2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repKhachHang;
        private System.Windows.Forms.BindingSource khachHangBindingSource;
        private CRMDataTableAdapters.KhachHangTableAdapter khachHangTableAdapter;
        private DevExpress.XtraBars.BarButtonItem btnInPhieuXuat;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnInPhieuXuatBH;
        private DevExpress.XtraGrid.Columns.GridColumn colNVVanDon;
        private DevExpress.XtraGrid.Columns.GridColumn colShipper;
    }
}