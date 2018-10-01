
using Lotus.Libraries;
namespace Lotus.Base.Systems
{
    partial class FrmPhanQuyen
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
            DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule treeListFormatRule1 = new DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPhanQuyen));
            this.colTenChucNang = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridNguoiDung = new Lotus.Libraries.CustomGridControl();
            this.nguoiDungBindingSource = new System.Windows.Forms.BindingSource();
            this.dATA = new Lotus.Base.DATA();
            this.gvNguoiDung = new Lotus.Libraries.CustomGridView();
            this.colTenDangNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repChucDanh = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.replkePhong = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.phongBanBindingSource = new System.Windows.Forms.BindingSource();
            this.rsearchNhanVien = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoVaTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colTruyCap = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colThem = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSua = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colXoa = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTatCa = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imgTreeChucNang = new DevExpress.Utils.ImageCollection();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem2 = new DevExpress.XtraLayout.SplitterItem();
            this.chiNhanhBindingSource = new System.Windows.Forms.BindingSource();
            this.phuongBindingSource = new System.Windows.Forms.BindingSource();
            this.nguoiDungTableAdapter = new Lotus.Base.DATATableAdapters.NguoiDungTableAdapter();
            this.chucNangAD = new Lotus.Base.DATATableAdapters.ChucNangTableAdapter();
            this.phanQuyenAD = new Lotus.Base.DATATableAdapters.PhanQuyenTableAdapter();
            this.phongBanTableAdapter = new Lotus.Base.DATATableAdapters.PhongBanTableAdapter();
            this.btnResetPWD = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this._dtNhatKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgCalc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSpin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNguoiDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nguoiDungBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dATA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNguoiDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChucDanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.replkePhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phongBanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsearchNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTreeChucNang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chiNhanhBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phuongBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bm
            // 
            this.bm.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnResetPWD});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAdd, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnResetPWD, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            // colTenChucNang
            // 
            this.colTenChucNang.Caption = "Chức năng";
            this.colTenChucNang.FieldName = "TenChucNang";
            this.colTenChucNang.MinWidth = 34;
            this.colTenChucNang.Name = "colTenChucNang";
            this.colTenChucNang.OptionsColumn.AllowEdit = false;
            this.colTenChucNang.Visible = true;
            this.colTenChucNang.VisibleIndex = 0;
            this.colTenChucNang.Width = 284;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridNguoiDung);
            this.layoutControl1.Controls.Add(this.treeList1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 31);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(315, 294, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1051, 570);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridNguoiDung
            // 
            this.gridNguoiDung.DataSource = this.nguoiDungBindingSource;
            this.gridNguoiDung.Location = new System.Drawing.Point(7, 31);
            this.gridNguoiDung.MainView = this.gvNguoiDung;
            this.gridNguoiDung.MenuManager = this.bm;
            this.gridNguoiDung.Name = "gridNguoiDung";
            this.gridNguoiDung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rsearchNhanVien,
            this.repChucDanh,
            this.replkePhong});
            this.gridNguoiDung.Size = new System.Drawing.Size(359, 532);
            this.gridNguoiDung.TabIndex = 5;
            this.gridNguoiDung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNguoiDung});
            // 
            // nguoiDungBindingSource
            // 
            this.nguoiDungBindingSource.DataMember = "NguoiDung";
            this.nguoiDungBindingSource.DataSource = this.dATA;
            // 
            // dATA
            // 
            this.dATA.DataSetName = "DATA";
            this.dATA.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gvNguoiDung
            // 
            this.gvNguoiDung.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Blue;
            this.gvNguoiDung.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gvNguoiDung.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvNguoiDung.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvNguoiDung.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvNguoiDung.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.gvNguoiDung.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvNguoiDung.AppearancePrint.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvNguoiDung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTenDangNhap,
            this.colHoTen,
            this.colLoai,
            this.colPhong});
            this.gvNguoiDung.FixedLineWidth = 1;
            this.gvNguoiDung.FormatCode = null;
            this.gvNguoiDung.GridControl = this.gridNguoiDung;
            this.gvNguoiDung.GroupFormat = "[#image]{1} {2}";
            this.gvNguoiDung.IndicatorWidth = 31;
            this.gvNguoiDung.KeyColumn = null;
            this.gvNguoiDung.Name = "gvNguoiDung";
            this.gvNguoiDung.NotNullColumns = null;
            this.gvNguoiDung.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvNguoiDung.OptionsDetail.EnableMasterViewMode = false;
            this.gvNguoiDung.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.gvNguoiDung.OptionsView.ShowFooter = true;
            this.gvNguoiDung.ShowIndexIndicator = true;
            this.gvNguoiDung.UseAutoCode = false;
            this.gvNguoiDung.UseAutoLog = true;
            this.gvNguoiDung.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gvNguoiDung_PopupMenuShowing);
            this.gvNguoiDung.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvNguoiDung_FocusedRowChanged);
            this.gvNguoiDung.DoubleClick += new System.EventHandler(this.gvNguoiDung_DoubleClick);
            // 
            // colTenDangNhap
            // 
            this.colTenDangNhap.Caption = "Tên đăng nhập";
            this.colTenDangNhap.FieldName = "TenDangNhap";
            this.colTenDangNhap.Name = "colTenDangNhap";
            this.colTenDangNhap.OptionsColumn.AllowEdit = false;
            this.colTenDangNhap.OptionsColumn.FixedWidth = true;
            this.colTenDangNhap.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenDangNhap.Visible = true;
            this.colTenDangNhap.VisibleIndex = 0;
            this.colTenDangNhap.Width = 109;
            // 
            // colHoTen
            // 
            this.colHoTen.FieldName = "HoTen";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.OptionsColumn.AllowEdit = false;
            this.colHoTen.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colHoTen.Visible = true;
            this.colHoTen.VisibleIndex = 1;
            this.colHoTen.Width = 214;
            // 
            // colLoai
            // 
            this.colLoai.ColumnEdit = this.repChucDanh;
            this.colLoai.FieldName = "Loai";
            this.colLoai.Name = "colLoai";
            this.colLoai.OptionsColumn.AllowEdit = false;
            this.colLoai.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colLoai.Visible = true;
            this.colLoai.VisibleIndex = 2;
            this.colLoai.Width = 137;
            // 
            // repChucDanh
            // 
            this.repChucDanh.AutoHeight = false;
            this.repChucDanh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repChucDanh.Name = "repChucDanh";
            // 
            // colPhong
            // 
            this.colPhong.ColumnEdit = this.replkePhong;
            this.colPhong.FieldName = "Phong";
            this.colPhong.Name = "colPhong";
            this.colPhong.OptionsColumn.AllowEdit = false;
            this.colPhong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPhong.Visible = true;
            this.colPhong.VisibleIndex = 3;
            this.colPhong.Width = 220;
            // 
            // replkePhong
            // 
            this.replkePhong.AutoHeight = false;
            this.replkePhong.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.replkePhong.DataSource = this.phongBanBindingSource;
            this.replkePhong.DisplayMember = "TenPhong";
            this.replkePhong.Name = "replkePhong";
            this.replkePhong.ValueMember = "MaPhong";
            // 
            // phongBanBindingSource
            // 
            this.phongBanBindingSource.DataMember = "PhongBan";
            this.phongBanBindingSource.DataSource = this.dATA;
            // 
            // rsearchNhanVien
            // 
            this.rsearchNhanVien.AutoHeight = false;
            this.rsearchNhanVien.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rsearchNhanVien.DisplayMember = "HoVaTen";
            this.rsearchNhanVien.Name = "rsearchNhanVien";
            this.rsearchNhanVien.ValueMember = "MaNhanVien";
            this.rsearchNhanVien.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaNhanVien,
            this.colHoVaTen});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colMaNhanVien
            // 
            this.colMaNhanVien.FieldName = "MaNhanVien";
            this.colMaNhanVien.Name = "colMaNhanVien";
            this.colMaNhanVien.Visible = true;
            this.colMaNhanVien.VisibleIndex = 0;
            this.colMaNhanVien.Width = 221;
            // 
            // colHoVaTen
            // 
            this.colHoVaTen.FieldName = "HoVaTen";
            this.colHoVaTen.Name = "colHoVaTen";
            this.colHoVaTen.Visible = true;
            this.colHoVaTen.VisibleIndex = 1;
            this.colHoVaTen.Width = 771;
            // 
            // treeList1
            // 
            this.treeList1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.treeList1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colTenChucNang,
            this.colTruyCap,
            this.colThem,
            this.colSua,
            this.colXoa,
            this.colTatCa});
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            treeListFormatRule1.ApplyToRow = true;
            treeListFormatRule1.Column = this.colTenChucNang;
            treeListFormatRule1.ColumnApplyTo = this.colTenChucNang;
            treeListFormatRule1.Name = "tatca";
            formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.LightYellow;
            formatConditionRuleExpression1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Appearance.Options.UseFont = true;
            formatConditionRuleExpression1.Expression = "[TenChucNang]=\'Tất cả\'";
            treeListFormatRule1.Rule = formatConditionRuleExpression1;
            this.treeList1.FormatRules.Add(treeListFormatRule1);
            this.treeList1.KeyFieldName = "Id";
            this.treeList1.Location = new System.Drawing.Point(385, 31);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsView.AutoWidth = false;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.ParentFieldName = "IdCha";
            this.treeList1.RootValue = "";
            this.treeList1.SelectImageList = this.imgTreeChucNang;
            this.treeList1.Size = new System.Drawing.Size(659, 527);
            this.treeList1.TabIndex = 6;
            this.treeList1.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeList1_CustomDrawNodeCell);
            this.treeList1.CustomDrawNodeImages += new DevExpress.XtraTreeList.CustomDrawNodeImagesEventHandler(this.treeList1_CustomDrawNodeImages);
            this.treeList1.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeList1_CellValueChanging);
            // 
            // colTruyCap
            // 
            this.colTruyCap.Caption = "Truy cập";
            this.colTruyCap.FieldName = "TruyCap";
            this.colTruyCap.Name = "colTruyCap";
            this.colTruyCap.OptionsColumn.FixedWidth = true;
            this.colTruyCap.Visible = true;
            this.colTruyCap.VisibleIndex = 1;
            this.colTruyCap.Width = 65;
            // 
            // colThem
            // 
            this.colThem.Caption = "Thêm";
            this.colThem.FieldName = "Them";
            this.colThem.Name = "colThem";
            this.colThem.OptionsColumn.FixedWidth = true;
            this.colThem.Visible = true;
            this.colThem.VisibleIndex = 2;
            this.colThem.Width = 60;
            // 
            // colSua
            // 
            this.colSua.Caption = "Sửa";
            this.colSua.FieldName = "Sua";
            this.colSua.Name = "colSua";
            this.colSua.OptionsColumn.FixedWidth = true;
            this.colSua.Visible = true;
            this.colSua.VisibleIndex = 3;
            this.colSua.Width = 60;
            // 
            // colXoa
            // 
            this.colXoa.Caption = "Xóa";
            this.colXoa.FieldName = "Xoa";
            this.colXoa.Name = "colXoa";
            this.colXoa.OptionsColumn.FixedWidth = true;
            this.colXoa.Visible = true;
            this.colXoa.VisibleIndex = 4;
            this.colXoa.Width = 60;
            // 
            // colTatCa
            // 
            this.colTatCa.AppearanceCell.BackColor = System.Drawing.Color.LightYellow;
            this.colTatCa.AppearanceCell.Options.UseBackColor = true;
            this.colTatCa.Caption = "Tất cả";
            this.colTatCa.FieldName = "TatCa";
            this.colTatCa.Name = "colTatCa";
            this.colTatCa.OptionsColumn.FixedWidth = true;
            this.colTatCa.Visible = true;
            this.colTatCa.VisibleIndex = 5;
            this.colTatCa.Width = 64;
            // 
            // imgTreeChucNang
            // 
            this.imgTreeChucNang.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgTreeChucNang.ImageStream")));
            this.imgTreeChucNang.InsertGalleryImage("properties_16x16.png", "images/setup/properties_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/setup/properties_16x16.png"), 0);
            this.imgTreeChucNang.Images.SetKeyName(0, "properties_16x16.png");
            this.imgTreeChucNang.Images.SetKeyName(1, "bullet_red.png");
            this.imgTreeChucNang.Images.SetKeyName(2, "bullet_blue.png");
            this.imgTreeChucNang.Images.SetKeyName(3, "bullet_green.png");
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup4,
            this.splitterItem1,
            this.layoutControlGroup3,
            this.splitterItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1051, 570);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup4.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup4.CaptionImage = ((System.Drawing.Image)(resources.GetObject("layoutControlGroup4.CaptionImage")));
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup4.Size = new System.Drawing.Size(373, 570);
            this.layoutControlGroup4.Text = "Người dùng";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridNguoiDung;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(104, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(363, 536);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(378, 565);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(673, 5);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup3.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup3.CaptionImage = ((System.Drawing.Image)(resources.GetObject("layoutControlGroup3.CaptionImage")));
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.layoutControlGroup3.Location = new System.Drawing.Point(378, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup3.Size = new System.Drawing.Size(673, 565);
            this.layoutControlGroup3.Text = "Chức năng";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.treeList1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(663, 531);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // splitterItem2
            // 
            this.splitterItem2.AllowHotTrack = true;
            this.splitterItem2.Location = new System.Drawing.Point(373, 0);
            this.splitterItem2.Name = "splitterItem2";
            this.splitterItem2.Size = new System.Drawing.Size(5, 570);
            // 
            // nguoiDungTableAdapter
            // 
            this.nguoiDungTableAdapter.ClearBeforeFill = true;
            // 
            // chucNangAD
            // 
            this.chucNangAD.ClearBeforeFill = true;
            // 
            // phanQuyenAD
            // 
            this.phanQuyenAD.ClearBeforeFill = true;
            // 
            // phongBanTableAdapter
            // 
            this.phongBanTableAdapter.ClearBeforeFill = true;
            // 
            // btnResetPWD
            // 
            this.btnResetPWD.Caption = "Reset mật khẩu";
            this.btnResetPWD.Id = 11;
            this.btnResetPWD.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnResetPWD.ImageOptions.Image")));
            this.btnResetPWD.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnResetPWD.ImageOptions.LargeImage")));
            this.btnResetPWD.Name = "btnResetPWD";
            this.btnResetPWD.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResetPWD_ItemClick);
            // 
            // FrmPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 601);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmPhanQuyen";
            this.Text = "Phân quyền";
            this.Load += new System.EventHandler(this.FrmPhanQuyen_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this._dtNhatKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgCalc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSpin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridNguoiDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nguoiDungBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dATA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNguoiDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChucDanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.replkePhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phongBanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsearchNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTreeChucNang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chiNhanhBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phuongBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private CustomGridControl gridNguoiDung;
        private CustomGridView gvNguoiDung;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDangNhap;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTenChucNang;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTruyCap;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colThem;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSua;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colXoa;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTatCa;
        private DevExpress.Utils.ImageCollection imgTreeChucNang;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rsearchNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DATA dATA;
        private System.Windows.Forms.BindingSource nguoiDungBindingSource;
        private DATATableAdapters.NguoiDungTableAdapter nguoiDungTableAdapter;
        private DATATableAdapters.ChucNangTableAdapter chucNangAD;
        private DATATableAdapters.PhanQuyenTableAdapter phanQuyenAD;
       
        private DevExpress.XtraGrid.Columns.GridColumn colMaNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colHoVaTen;
    
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.SplitterItem splitterItem2;
        private System.Windows.Forms.BindingSource chiNhanhBindingSource;
        private System.Windows.Forms.BindingSource phuongBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colHoTen;
        private DevExpress.XtraGrid.Columns.GridColumn colLoai;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repChucDanh;
        private DevExpress.XtraGrid.Columns.GridColumn colPhong;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit replkePhong;
        private System.Windows.Forms.BindingSource phongBanBindingSource;
        private DATATableAdapters.PhongBanTableAdapter phongBanTableAdapter;
        private DevExpress.XtraBars.BarButtonItem btnResetPWD;
      
    }
}