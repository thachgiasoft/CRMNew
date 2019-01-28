namespace CRM.Dictionaries
{
    partial class FrmKetXuatTuVan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKetXuatTuVan));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.customGridControl1 = new Lotus.Libraries.CustomGridControl();
            this.exportTuVanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataReport = new CRM.DataReport();
            this.customGridView1 = new Lotus.Libraries.CustomGridView();
            this.repKhachHang = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colHinhThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repHinhThuc = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoanThanh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rcboTrangThaiColumn = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection3 = new DevExpress.Utils.ImageCollection(this.components);
            this.colNgayHen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayHoanThanh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayTao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoPhieuDat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colNVCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.data = new CRM.CRMData();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.itemTrangThai = new DevExpress.XtraBars.BarEditItem();
            this.rcboTrangThai = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.btnChuyen = new DevExpress.XtraBars.BarButtonItem();
            this.btnXemDonHang = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.rcboLookTrangThai = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.exportTuVanTableAdapter = new CRM.DataReportTableAdapters.ExportTuVanTableAdapter();
            this.colTenKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenLoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNhom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKenhTT = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dtNhatKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgCalc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSpin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportTuVanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repHinhThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcboTrangThaiColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcboTrangThai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcboLookTrangThai)).BeginInit();
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
            this.itemTrangThai,
            this.btnChuyen,
            this.btnXemDonHang});
            this.bm.MaxItemId = 15;
            this.bm.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.rcboTrangThai,
            this.rcboLookTrangThai});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrintPreview, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            this.layoutControl1.Location = new System.Drawing.Point(0, 31);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1220, 556);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // customGridControl1
            // 
            this.customGridControl1.DataSource = this.exportTuVanBindingSource;
            this.customGridControl1.ExternalRepository = this.rgCollection;
            this.customGridControl1.Location = new System.Drawing.Point(2, 2);
            this.customGridControl1.MainView = this.customGridView1;
            this.customGridControl1.MenuManager = this.bm;
            this.customGridControl1.Name = "customGridControl1";
            this.customGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repHinhThuc,
            this.repKhachHang,
            this.rcboTrangThaiColumn,
            this.repositoryItemLookUpEdit1});
            this.customGridControl1.Size = new System.Drawing.Size(1216, 552);
            this.customGridControl1.TabIndex = 4;
            this.customGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.customGridView1});
            // 
            // exportTuVanBindingSource
            // 
            this.exportTuVanBindingSource.DataMember = "ExportTuVan";
            this.exportTuVanBindingSource.DataSource = this.dataReport;
            // 
            // dataReport
            // 
            this.dataReport.DataSetName = "DataReport";
            this.dataReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customGridView1
            // 
            this.customGridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.customGridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.customGridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.customGridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.customGridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.customGridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.customGridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.customGridView1.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.customGridView1.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.customGridView1.AppearancePrint.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.customGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHinhThuc,
            this.colGhiChu,
            this.colHoanThanh,
            this.colNgayHen,
            this.colNgayHoanThanh,
            this.colNgayTao,
            this.colNhanVien,
            this.colNoiDung,
            this.colSoPhieuDat,
            this.colNVCS,
            this.colTenKH,
            this.colTenLoai,
            this.colTenNhom,
            this.colSoDT,
            this.colKenhTT});
            this.customGridView1.FixedLineWidth = 1;
            this.customGridView1.FormatCode = null;
            this.customGridView1.GridControl = this.customGridControl1;
            this.customGridView1.GroupFormat = "[#image]{1} {2}";
            this.customGridView1.IndicatorWidth = 31;
            this.customGridView1.KeyColumn = "ID";
            this.customGridView1.Name = "customGridView1";
            this.customGridView1.NotNullColumns = "";
            this.customGridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.customGridView1.OptionsDetail.EnableMasterViewMode = false;
            this.customGridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.customGridView1.OptionsView.EnableAppearanceEvenRow = false;
            this.customGridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.customGridView1.OptionsView.ShowFooter = true;
            this.customGridView1.ShowIndexIndicator = true;
            this.customGridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colHoanThanh, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNgayHen, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.customGridView1.UseAutoCode = false;
            this.customGridView1.UseAutoLog = true;
            this.customGridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.customGridView1_RowCellClick);
            this.customGridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.customGridView1_RowCellStyle);
            // 
            // repKhachHang
            // 
            this.repKhachHang.AutoHeight = false;
            this.repKhachHang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repKhachHang.DisplayMember = "TenKH";
            this.repKhachHang.Name = "repKhachHang";
            this.repKhachHang.ValueMember = "MaKH";
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
            this.colHinhThuc.Width = 83;
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
            // colGhiChu
            // 
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.OptionsColumn.AllowEdit = false;
            this.colGhiChu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 8;
            this.colGhiChu.Width = 116;
            // 
            // colHoanThanh
            // 
            this.colHoanThanh.Caption = "Trạng thái";
            this.colHoanThanh.ColumnEdit = this.rcboTrangThaiColumn;
            this.colHoanThanh.FieldName = "TrangThai";
            this.colHoanThanh.Name = "colHoanThanh";
            this.colHoanThanh.OptionsColumn.AllowEdit = false;
            this.colHoanThanh.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colHoanThanh.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.colHoanThanh.Visible = true;
            this.colHoanThanh.VisibleIndex = 9;
            this.colHoanThanh.Width = 100;
            // 
            // rcboTrangThaiColumn
            // 
            this.rcboTrangThaiColumn.AutoHeight = false;
            this.rcboTrangThaiColumn.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rcboTrangThaiColumn.Name = "rcboTrangThaiColumn";
            this.rcboTrangThaiColumn.SmallImages = this.imageCollection3;
            // 
            // imageCollection3
            // 
            this.imageCollection3.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection3.ImageStream")));
            this.imageCollection3.Images.SetKeyName(0, "Key-icon.png");
            this.imageCollection3.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 1);
            this.imageCollection3.Images.SetKeyName(1, "apply_16x16.png");
            this.imageCollection3.Images.SetKeyName(2, "deletered.png");
            // 
            // colNgayHen
            // 
            this.colNgayHen.AppearanceCell.Options.UseTextOptions = true;
            this.colNgayHen.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayHen.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.colNgayHen.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayHen.FieldName = "NgayHen";
            this.colNgayHen.Name = "colNgayHen";
            this.colNgayHen.OptionsColumn.AllowEdit = false;
            this.colNgayHen.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgayHen.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.colNgayHen.Visible = true;
            this.colNgayHen.VisibleIndex = 5;
            this.colNgayHen.Width = 133;
            // 
            // colNgayHoanThanh
            // 
            this.colNgayHoanThanh.AppearanceCell.Options.UseTextOptions = true;
            this.colNgayHoanThanh.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayHoanThanh.Caption = "Ngày trạng thái";
            this.colNgayHoanThanh.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.colNgayHoanThanh.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayHoanThanh.FieldName = "NgayTrangThai";
            this.colNgayHoanThanh.Name = "colNgayHoanThanh";
            this.colNgayHoanThanh.OptionsColumn.AllowEdit = false;
            this.colNgayHoanThanh.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgayHoanThanh.Visible = true;
            this.colNgayHoanThanh.VisibleIndex = 10;
            this.colNgayHoanThanh.Width = 101;
            // 
            // colNgayTao
            // 
            this.colNgayTao.AppearanceCell.Options.UseTextOptions = true;
            this.colNgayTao.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayTao.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.colNgayTao.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayTao.FieldName = "NgayTao";
            this.colNgayTao.Name = "colNgayTao";
            this.colNgayTao.OptionsColumn.AllowEdit = false;
            this.colNgayTao.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgayTao.Visible = true;
            this.colNgayTao.VisibleIndex = 0;
            this.colNgayTao.Width = 110;
            // 
            // colNhanVien
            // 
            this.colNhanVien.FieldName = "NhanVien";
            this.colNhanVien.Name = "colNhanVien";
            this.colNhanVien.OptionsColumn.AllowEdit = false;
            this.colNhanVien.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNhanVien.Visible = true;
            this.colNhanVien.VisibleIndex = 6;
            this.colNhanVien.Width = 119;
            // 
            // colNoiDung
            // 
            this.colNoiDung.FieldName = "NoiDung";
            this.colNoiDung.Name = "colNoiDung";
            this.colNoiDung.OptionsColumn.AllowEdit = false;
            this.colNoiDung.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNoiDung.Visible = true;
            this.colNoiDung.VisibleIndex = 4;
            this.colNoiDung.Width = 333;
            // 
            // colSoPhieuDat
            // 
            this.colSoPhieuDat.FieldName = "SoPhieuDat";
            this.colSoPhieuDat.Name = "colSoPhieuDat";
            this.colSoPhieuDat.OptionsColumn.AllowEdit = false;
            this.colSoPhieuDat.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoPhieuDat.Visible = true;
            this.colSoPhieuDat.VisibleIndex = 11;
            this.colSoPhieuDat.Width = 160;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.DisplayMember = "TenLoai";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.ValueMember = "MaLoai";
            // 
            // colNVCS
            // 
            this.colNVCS.FieldName = "NVCS";
            this.colNVCS.Name = "colNVCS";
            this.colNVCS.OptionsColumn.AllowEdit = false;
            this.colNVCS.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNVCS.Visible = true;
            this.colNVCS.VisibleIndex = 7;
            this.colNVCS.Width = 118;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(1220, 556);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.customGridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1220, 556);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // data
            // 
            this.data.DataSetName = "Data";
            this.data.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            this.imageCollection2.Images.SetKeyName(0, "Key-icon.png");
            this.imageCollection2.Images.SetKeyName(1, "Accept-icon.png");
            this.imageCollection2.Images.SetKeyName(2, "deletered.png");
            // 
            // itemTrangThai
            // 
            this.itemTrangThai.Caption = "Trạng thái";
            this.itemTrangThai.Edit = this.rcboTrangThai;
            this.itemTrangThai.Id = 11;
            this.itemTrangThai.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("itemTrangThai.ImageOptions.Image")));
            this.itemTrangThai.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("itemTrangThai.ImageOptions.LargeImage")));
            this.itemTrangThai.Name = "itemTrangThai";
            // 
            // rcboTrangThai
            // 
            this.rcboTrangThai.AutoHeight = false;
            this.rcboTrangThai.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rcboTrangThai.Name = "rcboTrangThai";
            this.rcboTrangThai.SmallImages = this.imageCollection3;
            // 
            // btnChuyen
            // 
            this.btnChuyen.Caption = "Chuyển việc";
            this.btnChuyen.Id = 12;
            this.btnChuyen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChuyen.ImageOptions.Image")));
            this.btnChuyen.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnChuyen.ImageOptions.LargeImage")));
            this.btnChuyen.Name = "btnChuyen";
            // 
            // btnXemDonHang
            // 
            this.btnXemDonHang.Caption = "Xem đơn hàng";
            this.btnXemDonHang.Id = 13;
            this.btnXemDonHang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXemDonHang.ImageOptions.Image")));
            this.btnXemDonHang.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXemDonHang.ImageOptions.LargeImage")));
            this.btnXemDonHang.Name = "btnXemDonHang";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // rcboLookTrangThai
            // 
            this.rcboLookTrangThai.AutoHeight = false;
            this.rcboLookTrangThai.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rcboLookTrangThai.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Đang xử lý", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Hoàn thành", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Đã hủy", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tất cả", -1, -1)});
            this.rcboLookTrangThai.Name = "rcboLookTrangThai";
            // 
            // exportTuVanTableAdapter
            // 
            this.exportTuVanTableAdapter.ClearBeforeFill = true;
            // 
            // colTenKH
            // 
            this.colTenKH.FieldName = "TenKH";
            this.colTenKH.Name = "colTenKH";
            this.colTenKH.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenKH.Visible = true;
            this.colTenKH.VisibleIndex = 1;
            this.colTenKH.Width = 183;
            // 
            // colTenLoai
            // 
            this.colTenLoai.FieldName = "TenLoai";
            this.colTenLoai.Name = "colTenLoai";
            this.colTenLoai.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenLoai.Visible = true;
            this.colTenLoai.VisibleIndex = 3;
            this.colTenLoai.Width = 155;
            // 
            // colTenNhom
            // 
            this.colTenNhom.FieldName = "TenNhom";
            this.colTenNhom.Name = "colTenNhom";
            this.colTenNhom.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenNhom.Visible = true;
            this.colTenNhom.VisibleIndex = 12;
            this.colTenNhom.Width = 143;
            // 
            // colSoDT
            // 
            this.colSoDT.FieldName = "SoDT";
            this.colSoDT.Name = "colSoDT";
            this.colSoDT.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoDT.Visible = true;
            this.colSoDT.VisibleIndex = 13;
            this.colSoDT.Width = 113;
            // 
            // colKenhTT
            // 
            this.colKenhTT.FieldName = "KenhTT";
            this.colKenhTT.Name = "colKenhTT";
            this.colKenhTT.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colKenhTT.Visible = true;
            this.colKenhTT.VisibleIndex = 14;
            this.colKenhTT.Width = 188;
            // 
            // FrmKetXuatTuVan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 587);
            this.Controls.Add(this.layoutControl1);
            this.DateFrom = new System.DateTime(2018, 9, 1, 0, 0, 0, 0);
            this.DateTo = new System.DateTime(2018, 9, 30, 23, 59, 59, 0);
            this.Name = "FrmKetXuatTuVan";
            this.ReportType = Lotus.Base.ReportType.Month;
            this.Text = "Tư vấn";
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
            ((System.ComponentModel.ISupportInitialize)(this.exportTuVanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repHinhThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcboTrangThaiColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcboTrangThai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcboLookTrangThai)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colHinhThuc;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repHinhThuc;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.Utils.ImageCollection imageCollection2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repKhachHang;
        private DevExpress.XtraGrid.Columns.GridColumn colHoanThanh;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayHen;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayHoanThanh;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayTao;
        private DevExpress.XtraGrid.Columns.GridColumn colNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colNoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn colSoPhieuDat;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraBars.BarEditItem itemTrangThai;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox rcboTrangThai;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox rcboTrangThaiColumn;
        private DevExpress.XtraBars.BarButtonItem btnChuyen;
        private DevExpress.Utils.ImageCollection imageCollection3;
        private DevExpress.XtraBars.BarButtonItem btnXemDonHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox rcboLookTrangThai;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colNVCS;
        private System.Windows.Forms.BindingSource exportTuVanBindingSource;
        private DataReport dataReport;
        private DataReportTableAdapters.ExportTuVanTableAdapter exportTuVanTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colTenKH;
        private DevExpress.XtraGrid.Columns.GridColumn colTenLoai;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNhom;
        private DevExpress.XtraGrid.Columns.GridColumn colSoDT;
        private DevExpress.XtraGrid.Columns.GridColumn colKenhTT;
    }
}