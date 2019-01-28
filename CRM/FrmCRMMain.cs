

using CRM.Dictionaries;
using CRM.Reports;
using Lotus;
using Lotus.Base;
using Lotus.License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRM
{
    public partial class FrmCRMMain : FrmMain
    {
        public FrmCRMMain()
        {
            InitializeComponent();

            ribbon.Pages.Clear();
            ribbon.Pages.Add(pageChucNang);
            ribbon.Pages.Add(pageHeThong);
            ribbon.Pages.Add(pageTroGiup);

        }

        private void FrmBDSMain_Load(object sender, EventArgs e)
        {
            if (DangNhap() == false) 
                this.Close();
            else
                btnTuVan.PerformClick();
        }

        private void btnBenhLy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmBenhLy>(HeThong.ChucNangDangChon);
        }

        private void btnKenhTT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmKenhTT>(HeThong.ChucNangDangChon);
        }

        private void btnMucDichSD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmMucDichSD>(HeThong.ChucNangDangChon);
        }

        private void btnNhomKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmNhomKH>(HeThong.ChucNangDangChon);
        }

        private void btnKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmKhachHang>(HeThong.ChucNangDangChon);
        }

        private void btnPhieuGiamGia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmPhieuGiamGia>(HeThong.ChucNangDangChon);
        }

        private void btnLoaiSP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmLoaiSP>(HeThong.ChucNangDangChon);
        }

        private void btnSanPham_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmSanPham>(HeThong.ChucNangDangChon);
        }

        private void btnPhieuDatHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmPhieuDatHang>(HeThong.ChucNangDangChon);
        }

        private void btnTuVan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmTuVan>(HeThong.ChucNangDangChon);
        }

        private void btnPhieuTraHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmPhieuTraHang>(HeThong.ChucNangDangChon);
        }

        private void btnCTDatHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmCTDatHang>(HeThong.ChucNangDangChon);
        }

        private void btnThongTinCty_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MsgBox.OpenDialog<FrmThongTinCty>();
        }

        private void btnBCSoLuotCSKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmSoLuotCSKH>(HeThong.ChucNangDangChon);
        }

        private void btnTinhThanh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmTinhThanh>(HeThong.ChucNangDangChon);
        }

        private void btnDTBQTheoNhomKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmDTBQTheoNhomKH>(HeThong.ChucNangDangChon);
        }

        private void btnDTTheoKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmTongDTTheoKH>(HeThong.ChucNangDangChon);
        }

        private void btnSoLanMuaTheoSoKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmSoLanMuaTheoNhomKH>(HeThong.ChucNangDangChon);
        }

        private void btnLichNghi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmLichNghi>(HeThong.ChucNangDangChon);
        }

        private void btnTiLeChuyenDoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmTiLeChuyenDoiKH>(HeThong.ChucNangDangChon);
        }

        private void btnBanQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BanQuyen.ShowFrmDangKy();
            HeThong.DaDangKy = BanQuyen.KiemTraLicense();
        }

        private void btnLoaiTuVan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmLoaiTuVan>(HeThong.ChucNangDangChon);
        }

        private void btnDonViGiaoHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmDonViGiaoHang>(HeThong.ChucNangDangChon);
        }

        private void btnSoKHdcChamSoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmSoKHDuocCS>(HeThong.ChucNangDangChon);
        }

        private void btnExportTuvan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmKetXuatTuVan>(HeThong.ChucNangDangChon);
        }

       
    }
}
