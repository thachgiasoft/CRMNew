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
using CRM.Dictionaries;
using Lotus.Libraries;
namespace CRM.Reports
{
    public partial class FrmTongDTTheoKH : FrmBaseReport
    {
        public FrmTongDTTheoKH()
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
            var p = customGridView1.GetFocusedDataRow() as DataReport.TongDTTheoKhachHangRow;
            if (p == null) return;

            var f = new FrmThongTinKH(p.MaKH, true);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                OnReload();

            ReloadButtons();
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
            {
                if(HeThong.NguoiDungDangNhap.Loai == (int)ChucDanh.NVKinhDoanh || HeThong.NguoiDungDangNhap.Loai == (int)ChucDanh.NVVanDon)
                {
                    tongDTTheoKhachHangTableAdapter.Fill(dataReport.TongDTTheoKhachHang, DateFrom, DateTo, HeThong.NguoiDungDangNhap.TenDangNhap, HeThong.NguoiDungDangNhap.Phong);
                }
                else if(HeThong.NguoiDungDangNhap.Loai == (int)ChucDanh.QuanLy)
                {
                    tongDTTheoKhachHangTableAdapter.Fill(dataReport.TongDTTheoKhachHang, DateFrom, DateTo, null, HeThong.NguoiDungDangNhap.Phong);
                }
                else if(HeThong.NguoiDungDangNhap.Loai == (int)ChucDanh.Admin)
                {
                    tongDTTheoKhachHangTableAdapter.Fill(dataReport.TongDTTheoKhachHang, DateFrom, DateTo, null, null);
                }
            }                
        }
       
       

        private void customGridView1_DoubleClick(object sender, EventArgs e)
        {
            OnEdit();
        }
    }
}
