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
using CRM.Reports;
using Lotus.Libraries;
namespace CRM.Dictionaries
{
    public partial class FrmPhieuDatHang : FrmBaseReport
    {
        public FrmPhieuDatHang()
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
            var f = new FrmThongTinPhieuDH();
            f.ChucNang = ChucNang;
            f.EditMode = EditMode.Add;
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                OnReload();

            ReloadButtons();
        }

        protected override void OnEdit()
        {
            var p = customGridView1.GetFocusedDataRow() as CRMData.PhieuDatHangRow;
            if (p == null) return;

            var f = new FrmThongTinPhieuDH(p.SoPhieu);
            f.ChucNang = ChucNang;
            f.EditMode = EditMode.Edit;
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                OnReload();

            ReloadButtons();
        }

        protected override void OnReload()
        {
            base.OnReload(); // cai basereport phải goi lai cho này de nó xac dinh d1 d2

            this.khachHangTableAdapter.FillByUser(this.data.KhachHang, HeThong.NguoiDungDangNhap.TenDangNhap);

            if (ReportType == Lotus.Base.ReportType.All)
                this.phieuDatHangTableAdapter.FillByUser(this.data.PhieuDatHang, HeThong.NguoiDungDangNhap.TenDangNhap);
            else
            {
                // them d1 d2 vào
                this.phieuDatHangTableAdapter.FillByUserDate(this.data.PhieuDatHang,DateFrom, DateTo, HeThong.NguoiDungDangNhap.TenDangNhap);
            }
        }
        protected override bool OnSave()
        {
            customGridView1.CloseEditor();
            customGridView1.UpdateCurrentRow();

            if (customGridView1.HasColumnErrors) return false;
            try
            {
                var dt = data.PhieuDatHang.GetChanges() as CRMData.PhieuDatHangDataTable;
                if (dt != null)
                {
                    phieuDatHangTableAdapter.Update(dt);
                    data.PhieuDatHang.AcceptChanges();
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

            // chỉ cho phep xóa phieu của mình
            // chi duoc xóa sua trong x ngày cho phep
            // chi duoc xoa pending

            // ??ok


            if (HeThong.NguoiDungDangNhap.Loai != 3)
            {
                var p = customGridView1.GetFocusedDataRow() as CRMData.PhieuDatHangRow;
                if (p == null) return false;

                if (HeThong.NguoiDungDangNhap.TenDangNhap == p.NVBanHang)
                {
                    int n = 1;
                    if (HeThong.NguoiDungDangNhap.Loai < (int)ChucDanh.QuanLy)
                        n = Param.GetValue<int>("Số ngày được phép sửa dữ liệu", "Hệ thống", 2);
                    else if (HeThong.NguoiDungDangNhap.Loai == (int)ChucDanh.QuanLy)
                        n = Param.GetValue<int>("Số ngày quản lý được phép sửa dữ liệu", "Hệ thống", 7);


                    if (DateTime.Today.AddDays(-n) <= p.NgayPhieu.Date && p.TrangThai == (int)TrangThaiPhieuDat.Pending)
                    {
                        XoaDong();
                    }
                    else
                    {
                        MsgBox.ShowWarningDialog("Vượt quá số ngày cho phép sửa dữ liệu hoặc chỉ được xóa phiếu đang xử lý");
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

        private void btnInPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var p = customGridView1.GetFocusedDataRow() as CRMData.PhieuDatHangRow;
            if (p == null) return;

            var ctAD = new CRMDataTableAdapters.CTPhieuDatHangTableAdapter();
        
            var spAD = new CRMDataTableAdapters.SanPhamTableAdapter();

            spAD.Fill(data.SanPham);

            var dtCT = ctAD.GetDataBySoPhieu(p.SoPhieu);
            var r = new PhieuXuatKho(data, p, dtCT);
           
            r.ShowPreview();
        }

        private void btnInPhieuXuatBH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var p = customGridView1.GetFocusedDataRow() as CRMData.PhieuDatHangRow;
            if (p == null) return;

            var ctAD = new CRMDataTableAdapters.CTPhieuDatHangTableAdapter();
        
            var spAD = new CRMDataTableAdapters.SanPhamTableAdapter();

            spAD.Fill(data.SanPham);

            var dtCT = ctAD.GetDataBySoPhieu(p.SoPhieu);
            var r = new PhieuXuatKhoBH(data, p, dtCT);
         
            r.ShowPreview();
        }
    }
}
