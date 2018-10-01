using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace CRM.Reports
{
    public partial class CRMBaseReport : Lotus.Base.LotusReport
    {
        CRMData.ThongTinCongTyRow _cty;
        public CRMBaseReport()
        {
            InitializeComponent();

            try
            {
                var ctyAD = new CRMDataTableAdapters.ThongTinCongTyTableAdapter();
                var dt = ctyAD.GetData();

                _cty = dt.FirstOrDefault();
                if (_cty == null) return;
            }
            catch { }
        }

        protected CRMData.ThongTinCongTyRow ThongTinCty 
        {
            get { return _cty; }
        }

        private void CRMBaseReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (_cty == null) return;

            lbTenCty.Text = _cty.TenCongTy;
            lbDiaChi.Text = _cty.DiaChi;
        }

    }
}
