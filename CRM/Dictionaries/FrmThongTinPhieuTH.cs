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
    public partial class FrmThongTinPhieuTH : FrmBase
    {
        string _soPhieu = string.Empty;
        public FrmThongTinPhieuTH()
        {
            InitializeComponent();
        }

        public FrmThongTinPhieuTH(string sophieu)
        {
            InitializeComponent();
            _soPhieu = sophieu;
        }

        string _makh = string.Empty;
        public FrmThongTinPhieuTH(string sophieu, string makh)
        {
            InitializeComponent();
            _soPhieu = sophieu;
            _makh = makh;
        }

        private void FrmThongTinPhieuDH_Load(object sender, EventArgs e)
        {         
            UseEnableControl = false;
            LockControls(false);

            OnReload();
            Bindings();

            if (_makh != string.Empty)
            {
                var p = data.PhieuTraHang.FirstOrDefault();
                if (p == null) return;

                KhachHangSearchLookUpEdit.EditValue = p.KhachHang = _makh;
            }
        }

        private void Bindings()
        {

            this.phieuTraHangTableAdapter.FillBySoPhieu(this.data.PhieuTraHang, _soPhieu);
            ctPhieuTraHangTableAD.FillBySoPhieu(data.CTPhieuTraHang, _soPhieu);
            customGridControl1.DataSource = data.CTPhieuTraHang;


            if (string.IsNullOrEmpty(_soPhieu))
            {
                phieuTraHangBindingSource.AddNew();

                string dinhdang = Param.GetValue<string>("Phiếu trả hàng", "Định dạng mã", "TH{0:d8}.{1:ddMMyyHHmmss}");
               // _soPhieu = DinhDangMa.LayMaTuDong("SoPhieu", "PhieuTraHang", dinhdang);
                _soPhieu = DinhDangMa.LaySoPhieu("SoPhieu", "PhieuTraHang", "NgayPhieu", dinhdang, DateTime.Now);


                SoPhieuTextEdit.Text = _soPhieu;
                NgayPhieuDateEdit.EditValue = DateTime.Now;

                NVBanHangSearchLookUpEdit.EditValue = HeThong.NguoiDungDangNhap.TenDangNhap;


                phieuTraHangBindingSource.EndEdit();
            }

            // neu phieu cũ thì không cho đổi phieu dat
            var p = data.PhieuTraHang.FirstOrDefault();
            if (!p.IsSoPhieuDHNull())
                lkePhieuDat.Enabled = false;
          
        }

        protected override void OnReload()
        {
            this.nguoiDungTableAdapter.Fill(dataHeThong.NguoiDung);            
            this.nhomKHTableAdapter.Fill(this.data.NhomKH);            
            this.sanPhamTableAdapter.Fill(this.data.SanPham);
            this.khachHangTableAdapter.FillByUser(this.data.KhachHang, HeThong.NguoiDungDangNhap.TenDangNhap);
            this.phieuDatHangTableAdapter.FillByUserTrangThai(this.data.PhieuDatHang, HeThong.NguoiDungDangNhap.TenDangNhap);
        }

        private void customGridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var ct = customGridView1.GetFocusedDataRow() as CRMData.CTPhieuTraHangRow;
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

            var ct = customGridView1.GetFocusedDataRow() as CRMData.CTPhieuTraHangRow;
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
            customGridView1.ClearColumnErrors();

            var ct = customGridView1.GetFocusedDataRow() as CRMData.CTPhieuTraHangRow;
            if (ct == null) return;

            if (e.Column.FieldName == "SoLuong")
            { 
                string sophieudat = (lkePhieuDat.EditValue==null||lkePhieuDat.EditValue==DBNull.Value)?string.Empty:lkePhieuDat.EditValue.ToString();
                var obj = ctPhieuTraHangTableAD.LaySoLuongDatHopLe(ct.STT,sophieudat, ct.SanPham, _soPhieu);
                double slTraHopLe = obj == null ? 0 : Convert.ToDouble(obj);

                if (ct.SoLuong > slTraHopLe)
                {
                    customGridView1.SetColumnError(colSoLuong, "Số lượng không hợp lệ");
                }
            }
         
            if (e.Column.FieldName == "SoLuong" || e.Column.FieldName == "DonGia")
            {

                double tt = ct.SoLuong * ct.DonGia;
                tt = Math.Round(tt, 0, MidpointRounding.AwayFromZero);
               
                ct.ThanhTien = tt;
            }
          

            CapNhatSoTien();
        }

        private void CapNhatSoTien()
        {

            customGridView1.UpdateCurrentRow();
     
            object obj = null;
            obj = data.CTPhieuTraHang.Compute("sum(ThanhTien)", "");
            TienHangCalcEdit.EditValue = (obj == null || obj == DBNull.Value) ? 0 : Convert.ToDouble(obj);

            ConLaiCalcEdit.EditValue = TienHangCalcEdit.Value - ThanhToanCalcEdit.Value;
        }

        private void KhachHangSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            string ma = (KhachHangSearchLookUpEdit.EditValue == DBNull.Value
                        || KhachHangSearchLookUpEdit.EditValue == null) ? string.Empty : KhachHangSearchLookUpEdit.EditValue.ToString();

            phieuDatHangTableAdapter.FillByKhachHang(data.PhieuDatHang, ma);

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
                
            }
            else
            {
                txtTenKH.Text = kh.TenKH;
                txtSoDT.Text = kh.SoDT;
                txtEmail.Text = kh.Email;
                txtDiaChi.Text = kh.DiaChi;
                cbGioiTinh.EditValue = kh.GioiTinh;
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

    

    
    

       


        private void ThanhToanCalcEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (ThanhToanCalcEdit.IsModified)
            {
                ConLaiCalcEdit.EditValue = TienHangCalcEdit.Value - ThanhToanCalcEdit.Value;
            }
        }

      

        private void customGridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            CapNhatSoTien();
        }

     


        bool LuuPhieu()
        {
            if (Kiemtra() == false) return false;

            var dt1 = data.PhieuTraHang.GetChanges() as CRMData.PhieuTraHangDataTable;
            if (dt1 != null)
            {
                phieuTraHangTableAdapter.Update(dt1);
                data.PhieuTraHang.AcceptChanges();
            }

            var dt2 = data.CTPhieuTraHang.GetChanges() as CRMData.CTPhieuTraHangDataTable;
            if (dt2 != null)
            {
                ctPhieuTraHangTableAD.Update(dt2);
                data.CTPhieuTraHang.AcceptChanges();
            }



            return true;
        }

   
        protected override bool OnSave()
        {
            if (LuuPhieu())
                DialogResult = System.Windows.Forms.DialogResult.OK;

            return base.OnSave();
        }

        private bool Kiemtra()
        {
            dataLayoutControl1.Validate();
            customGridView1.UpdateCurrentRow();
            phieuTraHangBindingSource.EndEdit();

            if (customGridView1.DataRowCount == 0)
            {
                MsgBox.ShowWarningDialog("Vui lòng nhập chi tiết");
                return false;
            }
            if (customGridView1.HasColumnErrors)
            {
                MsgBox.ShowWarningDialog("Vui lòng kiểm tra hợp lệ dữ liệu");
                return false;
            }
            if (lkePhieuDat.EditValue == null || lkePhieuDat.EditValue == DBNull.Value)
            {
                lkePhieuDat.ErrorText = "Không được trống";
                return false;
            }
            if (KhachHangSearchLookUpEdit.EditValue == null || KhachHangSearchLookUpEdit.EditValue == DBNull.Value)
            {
                KhachHangSearchLookUpEdit.ErrorText = "Không được trống";
                return false;
            }

            // kiem tra gì đó ....

            return true;
        }

        private void lkePhieuDat_EditValueChanged(object sender, EventArgs e)
        {
            if (lkePhieuDat.EditValue == null || lkePhieuDat.EditValue == DBNull.Value) return;

            TraHangTuPhieuDat(lkePhieuDat.EditValue.ToString());
        }

     
        public void TraHangTuPhieuDat(string soPhieuDat)
        {

            var pDat = phieuDatHangTableAdapter.GetDataBySoPhieu(soPhieuDat).FirstOrDefault();
            if (pDat == null) return;

            KhachHangSearchLookUpEdit.EditValue = pDat.KhachHang;
            var dtCT = ctPhieuDatHangTableAdapter.GetDataBySoPhieu(soPhieuDat);
            var dtCTTra = customGridControl1.DataSource as CRMData.CTPhieuTraHangDataTable;
            if (dtCTTra == null) return;

            dtCTTra.Clear();
            foreach (var ct in dtCT)
            {

                var t = dtCTTra.NewCTPhieuTraHangRow();
                t.STT = dtCTTra.Rows.Count + 1;
                t.SanPham = ct.SanPham;
                t.SoPhieu = _soPhieu;
                t.SoLuong = ct.SoLuong;
                t.DonGia = ct.DonGia;
                t.ThanhTien = ct.ThanhTien;
                t.DVT = ct.DVT;


                var obj = ctPhieuTraHangTableAD.LaySoLuongDatHopLe(t.STT, pDat.SoPhieu, ct.SanPham, _soPhieu);
                double slTraHopLe = obj == null ? 0 : Convert.ToDouble(obj);
                t.SoLuong = slTraHopLe;

                if (slTraHopLe == 0) continue;

                dtCTTra.AddCTPhieuTraHangRow(t);
            }
            CapNhatSoTien();

            if (dtCTTra.Rows.Count == 0)
            {
                MsgBox.ShowWarningDialog("Phiếu này đã trả hết hàng");
                lkePhieuDat.EditValue = null;
            }
        }
    }
}
