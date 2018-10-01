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
using Lotus.Libraries;
namespace CRM.Dictionaries
{
    public partial class FrmPhieuTraHang : FrmBaseReport
    {
        public FrmPhieuTraHang()
        {
            InitializeComponent();
            Printable = customGridControl1;
            Landscape = true;

            repTrangThai.Items.AddEnum(typeof(TrangThaiPhieuDat), true);
            repHinhThuc.Items.AddEnum(typeof(HinhThucLienLac), true);
        }

        private void FrmPhapLy_Load(object sender, EventArgs e)
        {                        
            OnReload(); 
        }

        protected override void OnNew()
        {
            var f = new FrmThongTinPhieuTH();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                OnReload();

            ReloadButtons();
        }

        protected override void OnEdit()
        {
            var p = customGridView1.GetFocusedDataRow() as CRMData.PhieuTraHangRow;
            if (p == null) return;

            var f = new FrmThongTinPhieuTH(p.SoPhieu);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                OnReload();

            ReloadButtons();
        }

        protected override void OnReload()
        {
            base.OnReload();
            this.khachHangTableAdapter.FillByUser(this.data.KhachHang,HeThong.NguoiDungDangNhap.TenDangNhap);
            if (ReportType == Lotus.Base.ReportType.All)
                this.phieuTraHangTableAdapter.FillByUser(this.data.PhieuTraHang, HeThong.NguoiDungDangNhap.TenDangNhap);
            else
            {
                // them d1 d2 vào
                this.phieuTraHangTableAdapter.FillByUserDate(this.data.PhieuTraHang, DateFrom, DateTo, HeThong.NguoiDungDangNhap.TenDangNhap);
            }            
        }
        protected override bool OnSave()
        {
            customGridView1.CloseEditor();
            customGridView1.UpdateCurrentRow();

            if (customGridView1.HasColumnErrors) return false;
            try
            {
                var dt = data.PhieuTraHang.GetChanges() as CRMData.PhieuTraHangDataTable;
                if (dt != null)
                {
                    phieuTraHangTableAdapter.Update(dt);
                    data.PhieuTraHang.AcceptChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowErrorDialog(ex.Message);
                return false;
            }
          
        }


        bool XoaDong()
        {
            if (MsgBox.ShowYesNoDialog("Bạn có chắc muốn xóa những dòng này?") == System.Windows.Forms.DialogResult.No) return false;

            customGridView1.DeleteSelectedRows();
            if (OnSave() == false)
            {
                OnReload();
                return false;
            }

            return true;
        }

        protected override bool OnDelete()
        {


            if (HeThong.NguoiDungDangNhap.Loai != 3)
            {
                var p = customGridView1.GetFocusedDataRow() as CRMData.PhieuTraHangRow;
                if (p == null) return false;

                if (HeThong.NguoiDungDangNhap.TenDangNhap == p.NVNhanHang)
                {
                    int n = 1;
                    if (HeThong.NguoiDungDangNhap.Loai < (int)ChucDanh.QuanLy)
                        n = Param.GetValue<int>("Số ngày được phép sửa dữ liệu", "Hệ thống", 2);
                    else if (HeThong.NguoiDungDangNhap.Loai == (int)ChucDanh.QuanLy)
                        n = Param.GetValue<int>("Số ngày quản lý được phép sửa dữ liệu", "Hệ thống", 7);

                    if (DateTime.Today.AddDays(-n) <= p.NgayPhieu.Date)
                    {
                        XoaDong();
                    }
                    else
                    {
                        MsgBox.ShowWarningDialog("Vượt quá số ngày cho phép sửa dữ liệu");
                        return false;
                    }
                }
                else
                {
                    MsgBox.ShowWarningDialog("Không thể xóa phiếu của người khác");
                    return false;
                }

            }


            return XoaDong();

        }

        private void customGridView1_DoubleClick(object sender, EventArgs e)
        {
            OnEdit();
        }
    }
}
