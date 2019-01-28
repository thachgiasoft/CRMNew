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
using System.Data.SqlClient;
using Lotus.Libraries;
using DevExpress.XtraBars.Alerter;
namespace CRM.Dictionaries
{
    public partial class FrmKetXuatTuVan : FrmBaseReport
    {
        public FrmKetXuatTuVan()
        {
            // không dung BeginInvoke thì có thằng này
            //DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;

            InitializeComponent();
            Printable = customGridControl1;
            Landscape = true;

            repHinhThuc.Items.AddEnum(typeof(HinhThucLienLac), true);
            rcboTrangThai.Items.AddEnum(typeof(TrangThaiTuVan), true);
            rcboTrangThaiColumn.Items.AddEnum(typeof(TrangThaiTuVan), true);

        }

     

     





        private void FrmPhapLy_Load(object sender, EventArgs e)
        {
            UseEnableControl = false;
            LockControls(false);
            OnReload();

            itemTrangThai.Enabled = HeThong.NguoiDungDangNhap.Loai == 3;
            btnChuyen.Enabled = HeThong.NguoiDungDangNhap.Loai >= 2;

            OnReload();
        }

        protected override void OnNew()
        {
            var f = new FrmThongTinTuVan(string.Empty);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                OnReload();

            ReloadButtons();
        }

        protected override void OnEdit()
        {
            var p = customGridView1.GetFocusedDataRow() as CRMData.TuVanRow;
            if (p == null) return;

            var f = new FrmThongTinTuVan(p.ID);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                OnReload();

            ReloadButtons();
        }

        protected override void OnReload()
        {
            base.OnReload();

            exportTuVanTableAdapter.Fill(dataReport.ExportTuVan, DateFrom, DateTo);
        }
        

      

        private void customGridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
        }

        private void customGridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
           
          
        }

        private void customGridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;

            var t = customGridView1.GetDataRow(e.RowHandle) as CRMData.TuVanRow;
            if (t == null) return;



            if (t.TrangThai != (int)TrangThaiTuVan.Pending) return;
            if (e.Column.FieldName == "NoiDung")
            {
                if (t.NgayHen.Date == DateTime.Today)
                    e.Appearance.BackColor = Color.LightGreen;
                else if (t.NgayHen.Date < DateTime.Today)
                {
                    e.Appearance.BackColor = Color.Pink;
                }
                else
                    e.Appearance.BackColor = Color.Transparent;
            }

        }
    }
}
