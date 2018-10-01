namespace Lotus.Base
{
    partial class FrmBaseReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBaseReport));
            this.itemDateFrom = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.itemDateTo = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.itemMonth = new DevExpress.XtraBars.BarEditItem();
            this.rcboMonth = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.itemQuarter = new DevExpress.XtraBars.BarEditItem();
            this.rcboQuarter = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.itemYear = new DevExpress.XtraBars.BarEditItem();
            this.rspinYear = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.itemType = new DevExpress.XtraBars.BarEditItem();
            this.rcboType = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imgTreePhongBan = new DevExpress.Utils.ImageCollection(this.components);
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rlkpTaiKhoan = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlookChiNhanh = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgCalc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSpin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcboMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcboQuarter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspinYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcboType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTreePhongBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkpTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlookChiNhanh)).BeginInit();
            this.SuspendLayout();
            // 
            // bm
            // 
            this.bm.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.itemDateFrom,
            this.itemDateTo,
            this.itemMonth,
            this.itemQuarter,
            this.itemYear,
            this.itemType});
            this.bm.MaxItemId = 27;
            this.bm.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2,
            this.rcboMonth,
            this.rcboQuarter,
            this.rspinYear,
            this.rcboType,
            this.repositoryItemTextEdit1,
            this.rlkpTaiKhoan,
            this.rlookChiNhanh});
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            // 
            // btnReload
            // 
            this.btnReload.Caption = "Nạp";
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.itemType, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.itemDateFrom, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.itemDateTo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.itemMonth, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.itemQuarter, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.itemYear, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            // itemDateFrom
            // 
            this.itemDateFrom.Caption = "Từ ngày";
            this.itemDateFrom.Edit = this.repositoryItemDateEdit1;
            this.itemDateFrom.EditWidth = 100;
            this.itemDateFrom.Id = 10;
            this.itemDateFrom.Name = "itemDateFrom";
            this.itemDateFrom.EditValueChanged += new System.EventHandler(this.itemDateFrom_EditValueChanged);
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // itemDateTo
            // 
            this.itemDateTo.Caption = "Đến ngày";
            this.itemDateTo.Edit = this.repositoryItemDateEdit2;
            this.itemDateTo.EditWidth = 100;
            this.itemDateTo.Id = 11;
            this.itemDateTo.Name = "itemDateTo";
            this.itemDateTo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // itemMonth
            // 
            this.itemMonth.Caption = "Tháng";
            this.itemMonth.Edit = this.rcboMonth;
            this.itemMonth.EditWidth = 80;
            this.itemMonth.Id = 12;
            this.itemMonth.Name = "itemMonth";
            this.itemMonth.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.itemMonth.EditValueChanged += new System.EventHandler(this.itemMonth_EditValueChanged);
            // 
            // rcboMonth
            // 
            this.rcboMonth.AutoHeight = false;
            this.rcboMonth.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rcboMonth.DropDownRows = 15;
            this.rcboMonth.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("01", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("02", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("03", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("04", 4, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("05", 5, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("06", 6, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("07", 7, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("08", 8, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("09", 9, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("10", 10, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("11", 11, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("12", 12, -1)});
            this.rcboMonth.Name = "rcboMonth";
            // 
            // itemQuarter
            // 
            this.itemQuarter.Caption = "Quý";
            this.itemQuarter.Edit = this.rcboQuarter;
            this.itemQuarter.EditWidth = 80;
            this.itemQuarter.Id = 14;
            this.itemQuarter.Name = "itemQuarter";
            this.itemQuarter.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.itemQuarter.EditValueChanged += new System.EventHandler(this.itemQuarter_EditValueChanged);
            // 
            // rcboQuarter
            // 
            this.rcboQuarter.AutoHeight = false;
            this.rcboQuarter.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rcboQuarter.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("01", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("02", 4, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("03", 7, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("04", 10, -1)});
            this.rcboQuarter.Name = "rcboQuarter";
            // 
            // itemYear
            // 
            this.itemYear.Caption = "Năm";
            this.itemYear.Edit = this.rspinYear;
            this.itemYear.EditWidth = 80;
            this.itemYear.Id = 16;
            this.itemYear.Name = "itemYear";
            this.itemYear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // rspinYear
            // 
            this.rspinYear.AutoHeight = false;
            this.rspinYear.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rspinYear.IsFloatValue = false;
            this.rspinYear.Mask.EditMask = "N00";
            this.rspinYear.MaxValue = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.rspinYear.MinValue = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.rspinYear.Name = "rspinYear";
            // 
            // itemType
            // 
            this.itemType.Caption = "Loại";
            this.itemType.Edit = this.rcboType;
            this.itemType.EditWidth = 120;
            this.itemType.Id = 19;
            this.itemType.Name = "itemType";
            this.itemType.EditValueChanged += new System.EventHandler(this.itemType_EditValueChanged);
            // 
            // rcboType
            // 
            this.rcboType.AutoHeight = false;
            this.rcboType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rcboType.Name = "rcboType";
            // 
            // imgTreePhongBan
            // 
            this.imgTreePhongBan.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgTreePhongBan.ImageStream")));
            this.imgTreePhongBan.InsertGalleryImage("documentmap_16x16.png", "images/navigation/documentmap_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/navigation/documentmap_16x16.png"), 0);
            this.imgTreePhongBan.Images.SetKeyName(0, "documentmap_16x16.png");
            this.imgTreePhongBan.InsertGalleryImage("home_16x16.png", "images/navigation/home_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/navigation/home_16x16.png"), 1);
            this.imgTreePhongBan.Images.SetKeyName(1, "home_16x16.png");
            this.imgTreePhongBan.InsertGalleryImage("team_16x16.png", "images/people/team_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/people/team_16x16.png"), 2);
            this.imgTreePhongBan.Images.SetKeyName(2, "team_16x16.png");
            this.imgTreePhongBan.Images.SetKeyName(3, "bullet_red.png");
            this.imgTreePhongBan.Images.SetKeyName(4, "bullet_blue.png");
            this.imgTreePhongBan.Images.SetKeyName(5, "bullet_green.png");
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // rlkpTaiKhoan
            // 
            this.rlkpTaiKhoan.AutoHeight = false;
            this.rlkpTaiKhoan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkpTaiKhoan.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SoHieuTaiKhoan", 90, "SoHieuTaiKhoan"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenTaiKhoan", 300, "TenTaiKhoan")});
            this.rlkpTaiKhoan.DropDownRows = 15;
            this.rlkpTaiKhoan.Name = "rlkpTaiKhoan";
            this.rlkpTaiKhoan.ShowHeader = false;
            // 
            // rlookChiNhanh
            // 
            this.rlookChiNhanh.AutoHeight = false;
            this.rlookChiNhanh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlookChiNhanh.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaChiNhanh", 70, "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenChiNhanh", 200, "Tên chi nhánh")});
            this.rlookChiNhanh.DisplayMember = "TenChiNhanh";
            this.rlookChiNhanh.Name = "rlookChiNhanh";
            this.rlookChiNhanh.ValueMember = "MaChiNhanh";
            // 
            // FrmBaseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 461);
            this.Name = "FrmBaseReport";
            this.Text = "FrmBaseReport";
            ((System.ComponentModel.ISupportInitialize)(this.bm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgCalc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSpin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcboMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcboQuarter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspinYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcboType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTreePhongBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkpTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlookChiNhanh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox rcboMonth;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox rcboQuarter;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspinYear;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox rcboType;
        protected DevExpress.XtraBars.BarEditItem itemDateFrom;
        protected DevExpress.XtraBars.BarEditItem itemDateTo;
        protected DevExpress.XtraBars.BarEditItem itemMonth;
        protected DevExpress.XtraBars.BarEditItem itemQuarter;
        protected DevExpress.XtraBars.BarEditItem itemYear;
        protected DevExpress.XtraBars.BarEditItem itemType;
        private DevExpress.Utils.ImageCollection imgTreePhongBan;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkpTaiKhoan;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlookChiNhanh;
    }
}