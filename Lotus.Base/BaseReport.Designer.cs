namespace Lotus.Base
{
    partial class SaleReport
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BaseDetail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lbDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableHeader = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblCompany = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblAddress = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblTax = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblPhone = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblFax = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblReportName = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTableHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // BaseDetail
            // 
            this.BaseDetail.HeightF = 0F;
            this.BaseDetail.Name = "BaseDetail";
            this.BaseDetail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BaseDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 50F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 50F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbDate,
            this.xrTableHeader,
            this.lblReportName});
            this.ReportHeader.HeightF = 118F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // lbDate
            // 
            this.lbDate.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Italic);
            this.lbDate.LocationFloat = new DevExpress.Utils.PointFloat(0F, 95F);
            this.lbDate.Name = "lbDate";
            this.lbDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbDate.SizeF = new System.Drawing.SizeF(726.9999F, 23.00001F);
            this.lbDate.StylePriority.UseFont = false;
            this.lbDate.StylePriority.UseTextAlignment = false;
            this.lbDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableHeader
            // 
            this.xrTableHeader.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.xrTableHeader.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTableHeader.Name = "xrTableHeader";
            this.xrTableHeader.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow2,
            this.xrTableRow3});
            this.xrTableHeader.SizeF = new System.Drawing.SizeF(727F, 60F);
            this.xrTableHeader.StylePriority.UseFont = false;
            this.xrTableHeader.StylePriority.UseTextAlignment = false;
            this.xrTableHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lblCompany});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // lblCompany
            // 
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Text = "Đơn vị:";
            this.lblCompany.Weight = 2D;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lblAddress,
            this.lblTax});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // lblAddress
            // 
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Text = "Đia chỉ:";
            this.lblAddress.Weight = 1.5186841458369151D;
            // 
            // lblTax
            // 
            this.lblTax.Name = "lblTax";
            this.lblTax.Text = "MST:";
            this.lblTax.Weight = 0.48131585416308459D;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lblPhone,
            this.lblFax});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // lblPhone
            // 
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Text = "Điện thoại:";
            this.lblPhone.Weight = 1.5186841458369151D;
            // 
            // lblFax
            // 
            this.lblFax.Name = "lblFax";
            this.lblFax.Text = "Fax:";
            this.lblFax.Weight = 0.48131585416308448D;
            // 
            // lblReportName
            // 
            this.lblReportName.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblReportName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.lblReportName.LocationFloat = new DevExpress.Utils.PointFloat(0F, 60F);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblReportName.SizeF = new System.Drawing.SizeF(727F, 35F);
            this.lblReportName.StylePriority.UseFont = false;
            this.lblReportName.StylePriority.UseForeColor = false;
            this.lblReportName.StylePriority.UseTextAlignment = false;
            this.lblReportName.Text = "report name";
            this.lblReportName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.HeightF = 100F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // SaleReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.BaseDetail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter});
            this.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "17.1";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.SaleReport_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this.xrTableHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        protected DevExpress.XtraReports.UI.XRLabel lblReportName;
        protected DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        protected DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        protected DevExpress.XtraReports.UI.DetailBand BaseDetail;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        protected DevExpress.XtraReports.UI.XRTable xrTableHeader;
        protected DevExpress.XtraReports.UI.XRTableCell lblCompany;
        protected DevExpress.XtraReports.UI.XRTableCell lblAddress;
        protected DevExpress.XtraReports.UI.XRTableCell lblTax;
        protected DevExpress.XtraReports.UI.XRTableCell lblPhone;
        protected DevExpress.XtraReports.UI.XRTableCell lblFax;
        protected DevExpress.XtraReports.UI.XRLabel lbDate;
    }
}
