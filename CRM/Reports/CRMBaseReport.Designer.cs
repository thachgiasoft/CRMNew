namespace CRM.Reports
{
    partial class CRMBaseReport
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
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lbTenCty = new DevExpress.XtraReports.UI.XRLabel();
            this.lbDiaChi = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbTenCty,
            this.lbDiaChi});
            this.ReportHeader.HeightF = 76.04166F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // lbTenCty
            // 
            this.lbTenCty.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.lbTenCty.LocationFloat = new DevExpress.Utils.PointFloat(0F, 5.999994F);
            this.lbTenCty.Name = "lbTenCty";
            this.lbTenCty.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.lbTenCty.SizeF = new System.Drawing.SizeF(727F, 23F);
            this.lbTenCty.StylePriority.UseFont = false;
            this.lbTenCty.StylePriority.UseTextAlignment = false;
            this.lbTenCty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbDiaChi
            // 
            this.lbDiaChi.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lbDiaChi.LocationFloat = new DevExpress.Utils.PointFloat(0F, 29F);
            this.lbDiaChi.Name = "lbDiaChi";
            this.lbDiaChi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.lbDiaChi.SizeF = new System.Drawing.SizeF(727F, 23F);
            this.lbDiaChi.StylePriority.UseFont = false;
            this.lbDiaChi.StylePriority.UseTextAlignment = false;
            this.lbDiaChi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // CRMBaseReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.BaseDetail,
            this.ReportHeader});
            this.Version = "17.1";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.CRMBaseReport_BeforePrint);
            this.Controls.SetChildIndex(this.ReportHeader, 0);
            this.Controls.SetChildIndex(this.BaseDetail, 0);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        protected DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        protected DevExpress.XtraReports.UI.XRLabel lbTenCty;
        protected DevExpress.XtraReports.UI.XRLabel lbDiaChi;


    }
}
