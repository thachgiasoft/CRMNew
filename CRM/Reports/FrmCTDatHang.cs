using Lotus;
using Lotus.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using CRM;
namespace CRM.Reports
{
    public partial class FrmCTDatHang : FrmBaseReport
    {
        public FrmCTDatHang()
        {
            InitializeComponent();
            Printable = customGridControl1;
            Landscape = true;

        }

        private void FrmPhapLy_Load(object sender, EventArgs e)
        {                        
            OnReload(); 
        }

     

        protected override void OnEdit()
        {
            //var p = customGridView1.GetFocusedDataRow() as CRMData.PhieuDatHangRow;
            //if (p == null) return;

            //var f = new FrmThongTinPhieuDH(p.SoPhieu);
            //if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    OnReload();

            //ReloadButtons();
        }

        protected override void OnReload()
        {
            base.OnReload();
            if (ReportType == Lotus.Base.ReportType.All)
            {
                // viet code lay het
                //cTPhieuDatTableAdapter.Fill
            }
            else
                cTPhieuDatTableAdapter.Fill(dataReport.CTPhieuDat,DateFrom,DateTo,HeThong.NguoiDungDangNhap.TenDangNhap);
        }
       
       

        private void customGridView1_DoubleClick(object sender, EventArgs e)
        {
            OnEdit();
        }
    }
}
