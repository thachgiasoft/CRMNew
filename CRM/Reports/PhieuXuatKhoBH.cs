using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Lotus;
using System.Linq;
namespace CRM.Reports
{
    public partial class PhieuXuatKhoBH : CRM.Reports.CRMBaseReport
    {
        public PhieuXuatKhoBH()
        {
            InitializeComponent();
        }

        CRMData _data;
        CRMData.PhieuDatHangRow _p;
        CRMData.CTPhieuDatHangDataTable _dtCT;
        public PhieuXuatKhoBH(CRMData data, CRMData.PhieuDatHangRow p, CRMData.CTPhieuDatHangDataTable dtCT)
        {
            InitializeComponent();

            _data = data;
            _p = p;
            _dtCT = dtCT;
        }

        private void PhieuDatReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                InitData();
            }
            catch { }
        }

        private void InitData()
        {
            if (_data == null) return;
            if (_p == null) return;
            if (_dtCT == null) return;


            lblNgayDH.Text = string.Format("Ngày {0:dd/MM/yyyy}", _p.NgayPhieu);
            lblMaDH.Text = _p.SoPhieu;
            lblGhiChu.Text = _p.GhiChu;
            xrTienHang.Text = string.Format("{0:#,#0}",_p.TienHang);
            xrTongThanhToan.Text = string.Format("{0:#,#0}", _p.TongThanhToan);
            lblSoTienBangChu.Text = string.Format("Bằng chữ: {0}", NumToString.SoThanhChu(Convert.ToDecimal(_p.TongThanhToan)));
            var kh = _data.KhachHang.FindByMaKH(_p.KhachHang);
            if (kh != null)
            {
                lblTenKH.Text = kh.TenKH;
                lblDiaChi.Text = kh.DiaChi;
                lblSoDT.Text = kh.SoDT;
                xrKhachHang.Text = kh.TenKH;
            }

            var dt = _dtCT.Copy() as CRMData.CTPhieuDatHangDataTable;
            dt.Columns.Add("TenSanPham");
            foreach (var ct in dt)
            {
                var sp = _data.SanPham.FindByMaSP(ct.SanPham);
                if (sp != null)
                    ct["TenSanPham"] = sp.TenSP;
            }

            DataSource = dt;

            var ndAD = new Lotus.Base.DATATableAdapters.NguoiDungTableAdapter();
            var nv = ndAD.GetDataByTenDangNhap(_p.NVBanHang).FirstOrDefault();

            xrNhanVienBH.Text = nv == null ? _p.NVBanHang : nv.HoTen;
            xrThuKho.Text = ThongTinCty.ThuKho;
        }

    }
}
