using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Xpo;
using DevExpress.XtraPrinting;

using DevExpress.XtraReports.UI;
using System.Linq;


namespace Lotus.Base
{
    public partial class SaleReport : XtraReport
    {
      

        public SaleReport()
        {
            InitializeComponent();

          
        }

        public string ReportName
        {
            get { return lblReportName.Text; }
            set { lblReportName.Text = value.ToUpper(); }
        }

        public string ReportDate
        {
            get { return lbDate.Text; }
            set { lbDate.Text = value; }
        }

        

        /// <summary>
        ///     Dùng cho in mặc định, nếu chỉnh nằm ngang hay dọc gì thì cũng fill hết chiều ngang trang giấy
        /// </summary>
        public void AutoSizeReportName()
        {
            lblReportName.SizeF = new SizeF(PageWidth - Margins.Left - Margins.Right
                , lblReportName.SizeF.Height);

            xrTableHeader.SizeF = new SizeF(lblReportName.SizeF.Width, xrTableHeader.SizeF.Height);

            lbDate.SizeF = new SizeF(lblReportName.SizeF.Width, lbDate.SizeF.Height);
        }

        public void ShowPrintPreview()
        {
            // ẨN NÚT ĐIỀU CHỈNH WARTERMAK
            var pt = new ReportPrintTool(this);
            var ps = pt.PrintingSystem;
            ps.SetCommandVisibility(PrintingSystemCommand.Watermark, CommandVisibility.None);
            //if ((!Init.Registered))
            //{
            //    ps.SetCommandVisibility(PrintingSystemCommand.ExportCsv, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.ExportFile, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.ExportGraphic, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.ExportHtm, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.ExportMht, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.ExportPdf, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.ExportRtf, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.ExportTxt, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.ExportXls, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.ExportXlsx, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.ExportXps, CommandVisibility.None);

            //    ps.SetCommandVisibility(PrintingSystemCommand.SendCsv, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.SendFile, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.SendGraphic, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.SendMht, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.SendPdf, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.SendRtf, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.SendTxt, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.SendXls, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.SendXlsx, CommandVisibility.None);
            //    ps.SetCommandVisibility(PrintingSystemCommand.SendXps, CommandVisibility.None);
            //}
            //this.CreateDocument();
            //pt.PrintingSystem.Document.AutoFitToPagesWidth = 1;
            pt.ShowPreview();
            
        }
        public void ShowDesigner()
        {
            ReportDesignTool dt = new ReportDesignTool(this);
            dt.ShowDesigner();
        }
        public void Print()
        {
            this.PrintDialog();
        }

        private void SaleReport_BeforePrint(object sender, PrintEventArgs e)
        {
          

            //Watermark.Text = "PHẦN MỀM DÙNG THỬ\nVUI LÒNG ĐĂNG KÝ SỬ DỤNG";
            //Watermark.TextDirection = DirectionMode.ForwardDiagonal;
            //Watermark.Font = new Font(Watermark.Font.FontFamily, 32);
            //Watermark.ForeColor = Color.LightCoral;
            //Watermark.TextTransparency = 100;
            //Watermark.ShowBehind = false;
            //Watermark.PageRange = "1-100";
        }

       
    }
}