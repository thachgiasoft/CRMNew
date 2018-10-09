using CRM.Reports;
using DevExpress.XtraEditors;
using Lotus;
using Lotus.Base;
using Lotus.Base.Systems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRM.Dictionaries
{
    public partial class FrmThongTinPhieuDH : FrmBase
    {
        string _soPhieu = string.Empty;

        public EditMode EditMode { get; set; }
        public FrmThongTinPhieuDH()
        {
            InitializeComponent();
            
        }

        public FrmThongTinPhieuDH(string sophieu)
        {
            InitializeComponent();
            _soPhieu = sophieu;
        }

        bool _isRead;
        public FrmThongTinPhieuDH(string sophieu, bool isReadOnly)
        {
            InitializeComponent();
            _soPhieu = sophieu;
            _isRead = isReadOnly;
        }

        string _makh = string.Empty;
        public FrmThongTinPhieuDH(string sophieu, string makh)
        {
            InitializeComponent();
            _soPhieu = sophieu;
            _makh = makh;
        }


        private void FrmThongTinPhieuDH_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'data.DonViGiaoHang' table. You can move, or remove it, as needed.
           
            HinhThucImageComboBoxEdit.Properties.Items.AddEnum(typeof(HinhThucLienLac), true);
            repHinhThuc.Items.AddEnum(typeof(HinhThucLienLac), true);
            repTrangThai.Items.AddEnum(typeof(TrangThaiTuVan), true);

            UseEnableControl = false;
            LockControls(false);

            OnReload();
            Bindings();

            if (_isRead)
                LockControls(true);

            if (_makh != string.Empty)
            {
                var p = data.PhieuDatHang.FirstOrDefault();
                if (p == null) return;

                KhachHangSearchLookUpEdit.EditValue = p.KhachHang = _makh;
            }
        }
     

        private void Bindings()
        {

            phieuDatHangTableAdapter.FillBySoPhieu(data.PhieuDatHang, _soPhieu);
            ctPhieuDHAD.FillBySoPhieu(data.CTPhieuDatHang, _soPhieu);
            gridChiTietDH.DataSource = data.CTPhieuDatHang;


            if (string.IsNullOrEmpty(_soPhieu))
            {
                phieuDatHangBindingSource.AddNew();

                string dinhdang = Param.GetValue<string>("Phiếu đặt hàng", "Định dạng mã", "DH{0:d8}.{1:ddMMyyHHmmss}");
               // _soPhieu = DinhDangMa.LayMaTuDong("SoPhieu", "PhieuDatHang", dinhdang);

                _soPhieu = DinhDangMa.LaySoPhieu("SoPhieu", "PhieuDatHang", "NgayPhieu", dinhdang, DateTime.Now);


                SoPhieuTextEdit.Text = _soPhieu;
                NgayPhieuDateEdit.EditValue = DateTime.Now;

                NVBanHangSearchLookUpEdit.EditValue = HeThong.NguoiDungDangNhap.TenDangNhap;

                /*sửa sau*/
                // ngay hen mac dinh ....
                var dNgayPhieu = NgayPhieuDateEdit.DateTime;
                int soNgay = Convert.ToInt32(Param.GetValue<string>("Số ngày kiểm tra việc nhận hàng", "Tham số ngày hẹn", "5"));
                var dHen = Utils.TinhNgay(dNgayPhieu, soNgay);
                liNgayHen.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                dateNgayHen.DateTime = new DateTime(dHen.Year, dHen.Month, dHen.Day, 9, 0, 0);

                phieuDatHangBindingSource.EndEdit();
            }

            sdPhieuGiamGIaAD.FillBySoPhieu(data.SDPhieuGiamGIa, _soPhieu); // cho này sleect k ra
            gridPhieuGG.DataSource = data.SDPhieuGiamGIa;

            //tuVanTableAdapter.FillBySoPhieu(data.TuVan, _soPhieu);
            //customGridControl3.DataSource = data.TuVan;

           
        }

     

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (EditMode == CRM.EditMode.Edit)
            {
                int loai = HeThong.NguoiDungDangNhap.Loai;
                int n = Param.GetValue<int>("Số ngày quản lý được phép sửa dữ liệu", "Hệ thống", 7);
                if (loai == (int)Lotus.Libraries.ChucDanh.QuanLy)
                {
                    if (DateTime.Today.AddDays(-n) > NgayPhieuDateEdit.DateTime.Date)
                        LockControls(true);
                }
                else
                {
                    n = Param.GetValue<int>("Số ngày được phép sửa dữ liệu", "Hệ thống", 2);
                    if (DateTime.Today.AddDays(-n) > NgayPhieuDateEdit.DateTime.Date && loai < 3)
                    {
                        LockControls(true);
                        btnHuy.Enabled = false;
                        btnSave.Enabled = false;
                    }
                }

                var p = data.PhieuDatHang.FirstOrDefault();
                if (p == null) return;
                if (p.TrangThai != (int)TrangThaiPhieuDat.Pending)
                {
                    if (loai < 3)
                    {
                        LockControls(true);
                        btnHuy.Enabled = false;
                        btnSave.Enabled = false;
                    }
                }
                btnHuy.Enabled = p.TrangThai == (int)TrangThaiPhieuDat.Pending;
            }

            if (_quyen.Sua == false)
            {
                LockControls(true);
                btnHuy.Enabled = false;
                btnSave.Enabled = false;

            }

            if (EditMode == CRM.EditMode.Add && _quyen.Them)
            {
                LockControls(false);
                btnHuy.Enabled = true;
                btnSave.Enabled = true;
            }

            if (_isRead)
            {
                btnHuy.Enabled = false;
                LockControls(true);
                btnHuy.Enabled = false;
                btnSave.Enabled = false;
            }

            // xu ly cho nay ..
            //...

            CheckOnActive = false;
        }

        protected override void OnReload()
        {
            this.donViGiaoHangTableAdapter.Fill(this.data.DonViGiaoHang);
            this.nVVanDonTableAdapter.Fill(data.NVVanDon);
            this.nguoiDungTableAdapter.Fill(dataHeThong.NguoiDung);            
            this.nhomKHTableAdapter.Fill(this.data.NhomKH);            
            this.mucDichSDTableAdapter.Fill(this.data.MucDichSD);       
            this.sanPhamTableAdapter.Fill(this.data.SanPham);            
            this.khachHangTableAdapter.FillByUser(this.data.KhachHang, HeThong.NguoiDungDangNhap.TenDangNhap);            
           

        }

        private void customGridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var ct = customGridView1.GetFocusedDataRow() as CRMData.CTPhieuDatHangRow;
            if (ct == null) return;

            ct.STT = customGridView1.RowCount;
            ct.SoPhieu = _soPhieu;

        }

        private void repSanPham_EditValueChanged(object sender, EventArgs e)
        {
            var look = sender as SearchLookUpEdit;
            if (look == null) return;

            string ma = look.EditValue == null ? string.Empty : look.EditValue.ToString();

            var sp = data.SanPham.FindByMaSP(ma);
            if (sp == null) return;

            var ct = customGridView1.GetFocusedDataRow() as CRMData.CTPhieuDatHangRow;
            if (ct == null) return;
            ct.DVT = sp.DVT;
            ct.DonGia = sp.DonGia;
            customGridView1.PostEditor();
            customGridView1.UpdateCurrentRow();
            customGridView1.FocusedColumn = colSoLuong;
            customGridView1.ShowEditor();
        }

        private void customGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var ct = customGridView1.GetFocusedDataRow() as CRMData.CTPhieuDatHangRow;
            if (ct == null) return;


         
            if (e.Column.FieldName == "SoLuong"
                         || e.Column.FieldName == "DonGia"
                         || e.Column.FieldName == "CK")
            {

                double tt = ct.SoLuong * ct.DonGia;
                tt = Math.Round(tt, 0, MidpointRounding.AwayFromZero);

                double tienck = tt * ct.CK / 100;
                tienck = Math.Round(tienck, 0, MidpointRounding.AwayFromZero);


                ct.TienCK = tienck;
                ct.ThanhTien = tt - tienck;
            }
            else if (e.Column.FieldName == "ThanhTien")
            {
                double tt = ct.ThanhTien + ct.TienCK;
                tt = Math.Round(tt, 0, MidpointRounding.AwayFromZero);

                if (ct.SoLuong == 0)
                    ct.DonGia = 0;
                else
                    ct.DonGia = tt / ct.SoLuong;

                ct.DonGia = Math.Round(ct.DonGia, 0, MidpointRounding.AwayFromZero);

                if (tt == 0) ct.CK = 0;
                else
                    ct.CK = (ct.TienCK / tt) * 100;
            }
            else if (e.Column.FieldName == "TienCK")
            {
                double tt = ct.SoLuong * ct.DonGia;
                tt = Math.Round(tt, 0, MidpointRounding.AwayFromZero);
                if (tt == 0) ct.CK = 0;
                else
                    ct.CK = (ct.TienCK / tt) * 100;

                ct.ThanhTien = tt - ct.TienCK;
            }

            CapNhatSoTien();
        }

        private void CapNhatSoTien()
        {

            customGridView1.UpdateCurrentRow();
            customGridView2.UpdateCurrentRow();

            object obj = null;
            obj = data.CTPhieuDatHang.Compute("sum(ThanhTien)", "");
            TienHangCalcEdit.EditValue = (obj == null || obj == DBNull.Value) ? 0 : Convert.ToDouble(obj);

            obj = data.SDPhieuGiamGIa.Compute("sum(GiaTri)", "");
            TienPhieuGiamGiaCalcEdit.EditValue = (obj == null || obj == DBNull.Value) ? 0 : Convert.ToDouble(obj);


            //..

            TongThanhToanCalcEdit.EditValue = TienHangCalcEdit.Value - TienCKCalcEdit.Value - TienPhieuGiamGiaCalcEdit.Value;
            // tu dong gan tien thanh toan
            ThanhToanCalcEdit.EditValue = TongThanhToanCalcEdit.EditValue;

            ConLaiCalcEdit.EditValue = TongThanhToanCalcEdit.Value - ThanhToanCalcEdit.Value;
        }

        private void KhachHangSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            string ma = (KhachHangSearchLookUpEdit.EditValue == DBNull.Value
                        || KhachHangSearchLookUpEdit.EditValue == null) ? string.Empty : KhachHangSearchLookUpEdit.EditValue.ToString();

            var kh = data.KhachHang.FindByMaKH(ma);
            if (kh == null)
            {
                txtTenKH.Text =
                txtSoDT.Text =
                txtEmail.Text =
                txtSoCMT.Text =
                txtLinkFB.Text =
                txtNgheNghiep.Text =
                txtKenhTT.Text =
                txtMucDichSD.Text =
                txtBenhLy.Text =
                txtMoTa.Text =
                dtNgaySinh.Text =
                txtDiaChi.Text = string.Empty;
                lkeNhomKH.EditValue = null;
                lookTinhThanh.EditValue = null;

                // cho này là gird khác
                gridLishSuTT.DataSource = null;
                grdLichSuMuaHang.DataSource = grdLichSuTraHang.DataSource = null;
            }
            else
            {
                txtTenKH.Text = kh.TenKH;
                txtSoDT.Text = kh.SoDT;
                txtEmail.Text = kh.Email;
                txtDiaChi.Text = kh.DiaChi;
                cbgioiTinh.EditValue = kh.GioiTinh;
                txtSoCMT.Text = kh.SoCMT;
                txtLinkFB.Text = kh.LinkFB;
                txtNgheNghiep.Text = kh.NgheNghiep;
                txtKenhTT.Text = kh.KenhTT;
                txtMucDichSD.Text = kh.MucDichSuDung;
                txtBenhLy.Text = kh.BenhLy;
                txtMoTa.Text = kh.GhiChu;
                lkeNhomKH.EditValue = kh.NhomKH;
                if (!kh.IsNgaySinhNull()) dtNgaySinh.DateTime = kh.NgaySinh;
                else dtNgaySinh.Text = string.Empty;
                lookTinhThanh.EditValue = kh.TinhThanh;
                var dataHistory = new CRMData();

                gridLishSuTT.DataSource = this.tuVanTableAdapter.GetDataByKhachHang(kh.MaKH);
                grdLichSuMuaHang.DataSource = this.lichSuMuaHangTableAdapter.GetData(kh.MaKH);
                grdLichSuTraHang.DataSource = this.lichSuTraHangTableAdapter.GetData(kh.MaKH);
            }
        }

        private void KhachHangSearchLookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                var f = new FrmThongTinKH();
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    
                    khachHangTableAdapter.Fill(data.KhachHang);
                    KhachHangSearchLookUpEdit.EditValue = f.MaKH;
                }
            }
        }

        private void customGridView2_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var gg = customGridView2.GetFocusedDataRow() as CRMData.SDPhieuGiamGIaRow;
            if (gg == null) return;

            gg.SoPhieuDat = _soPhieu;
        }

        private void repPhieuGiamGia_EditValueChanged(object sender, EventArgs e)
        {
            var look = sender as SearchLookUpEdit;
            if (look == null) return;

            string ma = look.EditValue == null ? string.Empty : look.EditValue.ToString();

            var x = data.PhieuGiamGia.FindBySoPhieu(ma);
            if (x == null) return;

            var gg = customGridView2.GetFocusedDataRow() as CRMData.SDPhieuGiamGIaRow;
            if (gg == null) return;

            gg.GiaTri = x.GiaTri;

            customGridView2.PostEditor();
            customGridView1.UpdateCurrentRow();
            customGridView2.ClearColumnErrors();
        }

        private void customGridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            CapNhatSoTien();
        }

        private void customGridView2_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            CapNhatSoTien();
        }

        private void TienCKCalcEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (TienCKCalcEdit.IsModified)
            {
                CapNhatSoTien();
            }
        }

        private void ThanhToanCalcEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (ThanhToanCalcEdit.IsModified)
            {
                ConLaiCalcEdit.EditValue = TongThanhToanCalcEdit.Value - ThanhToanCalcEdit.Value;
            }
        }

        private void customGridView2_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName != "SoPhieuGiamGia") return;
            var gg = customGridView2.GetDataRow(e.RowHandle) as CRMData.SDPhieuGiamGIaRow;
            if (gg == null) return;

            if (Data.IsNewRow(gg))
            {
                e.RepositoryItem = repPhieuGiamGia;
            }
            else
                e.RepositoryItem = rTextSoPhieuGiamGia;
        }

        private void customGridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            CapNhatSoTien();
        }

        private void NgayPhieuDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            //DateTime d = NgayPhieuDateEdit.DateTime == DateTime.MinValue ? DateTime.Now : NgayPhieuDateEdit.DateTime;
            if(NgayPhieuDateEdit.DateTime>DateTime.MinValue)
            this.phieuGiamGiaTableAdapter.FillByNgay(this.data.PhieuGiamGia, NgayPhieuDateEdit.DateTime);
            int soNgay = Convert.ToInt32(Param.GetValue<string>("Số ngày kiểm tra việc nhận hàng", "Tham số ngày hẹn", "5"));
            dateNgayHen.DateTime = Utils.TinhNgay(NgayPhieuDateEdit.DateTime, soNgay);
        }



        bool LuuPhieu()
        {
            if (Kiemtra() == false) return false;

            var dt1 = data.PhieuDatHang.GetChanges() as CRMData.PhieuDatHangDataTable;
            if (dt1 != null)
            {
                phieuDatHangTableAdapter.Update(dt1);
                data.PhieuDatHang.AcceptChanges();
            }

            var dt2 = data.CTPhieuDatHang.GetChanges() as CRMData.CTPhieuDatHangDataTable;
            if (dt2 != null)
            {
                ctPhieuDHAD.Update(dt2);
                data.CTPhieuDatHang.AcceptChanges();
            }

            var dt3 = data.SDPhieuGiamGIa.GetChanges() as CRMData.SDPhieuGiamGIaDataTable;
            if (dt3 != null)
            {
                sdPhieuGiamGIaAD.Update(dt3);
                data.SDPhieuGiamGIa.AcceptChanges();
            }

            TaoLichTuVan();
           
            
            
            //var dt4 = data.TuVan.GetChanges() as CRMData.TuVanDataTable;
            //if (dt4 != null)
            //{
            //    tuVanTableAdapter.Update(dt4);
            //    data.TuVan.AcceptChanges();
            //}

            return true;
        }

        private void TaoLichTuVan()
        {
            if (data.TuVan.Count > 0) return;

            var t = data.TuVan.NewTuVanRow();

            t.ID = Guid.NewGuid().ToString();
            t.SoPhieuDat = _soPhieu;
            t.NgayTao = NgayPhieuDateEdit.DateTime;
            t.KhachHang = KhachHangSearchLookUpEdit.EditValue.ToString();
            t.NhanVien = NVBanHangSearchLookUpEdit.EditValue.ToString();
            t.NVCS = NVBanHangSearchLookUpEdit.EditValue.ToString();
            // mac dinh 5 ngay
            t.NgayHen = dateNgayHen.DateTime;
            t.NoiDung = string.Format("Kiểm tra xác nhận đơn hàng [{0}]",t.SoPhieuDat);

            t.Loai = "KTDH";
            t.NgayCapNhat = DateTime.Now;

            data.TuVan.AddTuVanRow(t);

            var dt4 = data.TuVan.GetChanges() as CRMData.TuVanDataTable;
            if (dt4 != null)
            {

                tuVanTableAdapter.Update(dt4);
                data.TuVan.AcceptChanges();
                t.AcceptChanges();
               // MsgBox.ShowSuccessfulDialog(string.Format("Lịch hẹn kiểm tra việc nhận hàng của đơn hàng [{0}] đã được thiết lập vào [{1:dd/MM/yyy HH:mm}]", t.SoPhieuDat, t.NgayHen));
            }

        }


        protected override bool OnSave()
        {
            if (LuuPhieu())
                DialogResult = System.Windows.Forms.DialogResult.OK;

            return true;
        }

        private bool Kiemtra()
        {
            dataLayoutControl1.Validate();
            customGridView1.UpdateCurrentRow();
            customGridView2.UpdateCurrentRow();
            phieuDatHangBindingSource.EndEdit();

            if (customGridView1.HasColumnErrors) return false;
            if (customGridView2.HasColumnErrors) return false;
            
            // kiem tra gì đó ....
            
            return true;
        }        


        private void btnInPhieuXuatKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Kiemtra() == false) return;


            var r = new PhieuXuatKho(data, data.PhieuDatHang.FirstOrDefault(), data.CTPhieuDatHang);
            r.ShowPreview();
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var t = data.PhieuDatHang.FirstOrDefault();
            if (t == null) return;
            if (MsgBox.ShowYesNoDialog("Bạn muốn hủy đơn hàng này?") == DialogResult.Yes)
            {

                t.TrangThai = (int)TrangThaiPhieuDat.Deny;
                t.NgayTrangThai = DateTime.Now;
                if (LuuPhieu())
                {
                    MsgBox.ShowSuccessfulDialog(string.Format("Hủy đơn hàng [{0}] thành công", t.SoPhieu));
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnPhieuXuatBH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Kiemtra() == false) return;

            var r = new PhieuXuatKhoBH(data, data.PhieuDatHang.FirstOrDefault(), data.CTPhieuDatHang);
            r.ShowPreview();
        }
    }
}
