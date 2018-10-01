using System;
using System.ComponentModel;
using DevExpress.XtraBars;
using DevExpress.Xpo;

using System.Windows.Forms;
using System.Data;
using DevExpress.XtraTreeList;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;

namespace Lotus.Base
{
    public enum ReportType
    {
        [Description("Ngày")]
        Date = 0,
        [Description("Từ ngày đến ngày")]
        FromDateToDate = 1,
        [Description("Tháng")]
        Month = 2,
        [Description("Quý")]
        Quarter = 3,
        [Description("Năm")]
        Year = 4,
        [Description("(Tất cả)")]
        All = 5,
    }


    public partial class FrmBaseReport : FrmBase
    {
        private ReportType _type;
        public const string STRING_ALL = "ALL";

        public FrmBaseReport()
        {
            InitializeComponent();

            rcboType.Items.AddEnum(typeof(ReportType), true);

            itemDateFrom.EditValue = DateTime.Today;
            itemDateTo.EditValue = DateTime.Today;
            itemMonth.EditValue = DateTime.Today.Month;
            itemYear.EditValue = DateTime.Today.Year;

            var m = DateTime.Today.Month;
            var q = 0;
            q = m % 3 == 0 ? (m / 3 + 1) - 1 : (m / 3 + 1);
            var quarter = 0;
            switch (q)
            {
                case 1:
                    quarter = 1;
                    break;
                case 2:
                    quarter = 4;
                    break;
                case 3:
                    quarter = 7;
                    break;
                case 4:
                    quarter = 10;
                    break;
            }

            itemQuarter.EditValue = quarter;
            itemType.EditValue = 0;
        }

        bool showAll = true;
        public bool ReportTypeShowAll
        {
            get { return showAll; }
            set
            {
                showAll = value;
                if(showAll == false)
                {
                    if (rcboType.Items.Count > 5)
                        rcboType.Items.RemoveAt(5);
                }
            }
        }


        bool allCN = true;
        public bool ShowAllChiNhanh
        {
            get { return allCN; }
            set { allCN = value; }
        }

        public ReportType ReportType
        {
            get { return _type; }
            set
            {
                _type = value;
                itemType.EditValue = Convert.ToInt32(_type);
                ShowItems(_type);
            }
        }
        public DateTime DateFrom
        {
            get { return Convert.ToDateTime(itemDateFrom.EditValue); }
            set { itemDateFrom.EditValue = value; }
        }
        public DateTime DateTo
        {
            get { return Convert.ToDateTime(itemDateTo.EditValue); }
            set { itemDateTo.EditValue = value; }
        }
        public int Thang
        {
            get { return itemMonth.EditValue == null ? DateFrom.Month : Convert.ToInt32(itemMonth.EditValue); }
        }
        public int Nam
        {
            get { return itemYear.EditValue == null ? DateFrom.Year : Convert.ToInt32(itemYear.EditValue); }
        }

       
        private void SetDateFromDateTo(ReportType type)
        {
            switch (type)
            {
                case ReportType.Date:
                    DateTo = DateFrom.AddDays(1).AddSeconds(-1);
                    break;
                case ReportType.FromDateToDate:
                    break;
                case ReportType.Month:
                    DateFrom = new DateTime(Convert.ToInt32(itemYear.EditValue), Convert.ToInt32(itemMonth.EditValue), 1);
                    DateTo = DateFrom.AddMonths(1).AddSeconds(-1);
                    break;
                case ReportType.Quarter:
                    DateFrom = new DateTime(Convert.ToInt32(itemYear.EditValue), Convert.ToInt32(itemQuarter.EditValue),
                        1);
                    DateTo = DateFrom.AddMonths(3).AddSeconds(-1);
                    break;
                case ReportType.Year:
                    DateFrom = new DateTime(Convert.ToInt32(itemYear.EditValue), 1, 1);
                    DateTo = new DateTime(Convert.ToInt32(itemYear.EditValue), 12, 31, 23, 59, 59);
                    break;
                default:
                    break;
            }
        }
        private void ShowItems(ReportType _reportType)
        {
            switch (_reportType)
            {
                case ReportType.Date:
                    itemDateFrom.Visibility = BarItemVisibility.Always;

                    itemDateTo.Visibility
                        = itemMonth.Visibility
                            = itemQuarter.Visibility
                                = itemYear.Visibility
                                    = BarItemVisibility.Never;
                    break;
                case ReportType.FromDateToDate:
                    itemDateFrom.Visibility = itemDateTo.Visibility = BarItemVisibility.Always;

                    itemMonth.Visibility
                        = itemQuarter.Visibility
                            = itemYear.Visibility
                                = BarItemVisibility.Never;

                    break;
                case ReportType.Month:
                    itemMonth.Visibility = itemYear.Visibility = BarItemVisibility.Always;

                    itemDateFrom.Visibility
                        = itemDateTo.Visibility
                            = itemQuarter.Visibility
                                = BarItemVisibility.Never;
                    break;
                case ReportType.Quarter:
                    itemQuarter.Visibility = itemYear.Visibility = BarItemVisibility.Always;

                    itemDateFrom.Visibility
                        = itemDateTo.Visibility
                            = itemMonth.Visibility
                                = BarItemVisibility.Never;
                    break;
                case ReportType.Year:
                    itemYear.Visibility = BarItemVisibility.Always;

                    itemDateFrom.Visibility
                        = itemDateTo.Visibility
                            = itemMonth.Visibility
                                = itemQuarter.Visibility = BarItemVisibility.Never;
                    break;

                case ReportType.All:
                    itemYear.Visibility = BarItemVisibility.Never;

                    itemDateFrom.Visibility
                        = itemDateTo.Visibility
                            = itemMonth.Visibility
                                = itemQuarter.Visibility = BarItemVisibility.Never;
                    break;
            }
        }

        private void itemDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (ReportType != ReportType.FromDateToDate) return;

            itemDateTo.EditValue = itemDateFrom.EditValue;
            repositoryItemDateEdit2.MinValue = DateFrom;
        }
        private void itemType_EditValueChanged(object sender, EventArgs e)
        {
            ReportType = (ReportType)Convert.ToInt32(itemType.EditValue);
            SetDateFromDateTo(ReportType);
        }
        private void itemMonth_EditValueChanged(object sender, EventArgs e)
        {
            SetDateFromDateTo(ReportType);
        }
        private void itemQuarter_EditValueChanged(object sender, EventArgs e)
        {
            SetDateFromDateTo(ReportType);
        }

        protected override void OnReload()
        {
            base.OnReload();
            EnableControls(true, true, true);
            SetDateFromDateTo(ReportType);
        }


       

      

        protected void OnPrintPreviewAndCreateReport(ColumnView view, object source, string repxFileName)
        {
            string path = Application.StartupPath +"\\Reports";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string repx = path + "\\" + repxFileName;
            XtraReport r = new XtraReport();
            r.DataSource = source;
            if (File.Exists(repx))
            {
                r.LoadLayout(repx);
                r.ShowPreviewDialog();
                //r.ShowDesignerDialog();
                return;
            }
            else
            {
                view.CreateReportTemplate(this.Text, false, false, System.Drawing.Printing.PaperKind.A4, true);
            }
        }



        public override void Translate()
        {
            base.Translate();
            if (HeThong.DaNgonNgu)
            {
                var items = rcboType.Items;
                foreach(ImageComboBoxItem item in items)
                {
                    var x = Enum.Parse(typeof(ReportType), item.Value.ToString());
                    string key = "Enum." + x.GetType().Name + "." + x.ToString();

                    string s = LanguageHelper.TranslateString(key, item.Description);
                    item.Description = s;
                }
            }
        }


        
     
    }



}