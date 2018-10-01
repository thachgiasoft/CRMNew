﻿using Lotus;
using Lotus.Base;
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
    public partial class FrmThongTinTuVan : FrmBase
    {
        string _id = string.Empty;
        string _sophieudat = string.Empty;
        public FrmThongTinTuVan(string Id)
        {
            InitializeComponent();
            _id = Id;
            cboHinhThuc.Properties.Items.AddEnum(typeof(HinhThucLienLac), true);
            repHinhThuc.Items.AddEnum(typeof(HinhThucLienLac), true);
            repTrangThai.Items.AddEnum(typeof(TrangThaiTuVan), true);
        }

        private void FrmThongTinTuVan_Load(object sender, EventArgs e)
        {
          
         
            UseEnableControl = false;
            LockControls(false);

            OnReload();

            Bindings();
        }

        private void Bindings()
        {
            this.tuVanTableAdapter.FillByID(this.data.TuVan, _id);
            if (_id == string.Empty)
            {
                var t = data.TuVan.NewTuVanRow();

                _id = Guid.NewGuid().ToString();
                t.ID = _id;
                t.NgayTao = DateTime.Now;

                int soNgay = Convert.ToInt32(Param.GetValue<string>("Số ngày mặc định", "Tham số ngày hẹn", "20"));

                //t.NgayHen = t.NgayTao.AddDays(soNgay);
                t.NgayHen = Utils.TinhNgay(t.NgayTao, soNgay);
                t.NgayHen = new DateTime(t.NgayHen.Year, t.NgayHen.Month, t.NgayHen.Day, 9, 0, 0);
                t.NhanVien = HeThong.NguoiDungDangNhap.TenDangNhap;
                t.HinhThuc = (int)HinhThucLienLac.GoiDi;
                t.Loai = "TVMH";
                data.TuVan.AddTuVanRow(t);
                tuVanBindingSource.EndEdit();

            }


            var tv = data.TuVan.FirstOrDefault();
            if (tv == null) return;

            if (tv.TrangThai != (int)TrangThaiTuVan.Pending)
            {
                if (HeThong.NguoiDungDangNhap.Loai < 3)
                    LockControls(true);
            }

            btnOK.Enabled = (tv.TrangThai == (int)TrangThaiTuVan.Pending);
            btnXemDonHang.Enabled = !tv.IsSoPhieuDatNull();
            _sophieudat = tv.SoPhieuDat;
        }

        protected override void OnReload()
        {
            this.loaiTuVanTableAdapter.Fill(this.data.LoaiTuVan);
            this.khachHangTableAdapter.FillByUser(this.data.KhachHang, HeThong.NguoiDungDangNhap.TenDangNhap);
            this.nguoiDungTableAdapter.Fill(this.dataHeThong.NguoiDung);
        }

        protected override bool OnSave()
        {
            if (LuuPhieu())
            {
                this.DialogResult = DialogResult.OK;
                return true;
            }

            return false;
        }

        bool LuuPhieu()
        {
            if (Kiemtra() == false) return false;

          

            var dt1 = data.TuVan.GetChanges() as CRMData.TuVanDataTable;
            if (dt1 != null)
            {
                foreach (var t in dt1)
                    t.NgayCapNhat = DateTime.Now;

                tuVanTableAdapter.Update(dt1);
                data.TuVan.AcceptChanges();
            }

            var dt2 = data.PhieuDatHang.GetChanges() as CRMData.PhieuDatHangDataTable;
            if (dt2 != null)
            {
                phieuDatHangTableAdapter1.Update(dt2);
                data.PhieuDatHang.AcceptChanges();
            }
            
            return true;
        }

        private bool Kiemtra()
        {            

            dataLayoutControl1.Validate();
            customGridView1.UpdateCurrentRow();
            customGridView2.UpdateCurrentRow();
            tuVanBindingSource.EndEdit();

            if (customGridView1.HasColumnErrors) return false;
            if (customGridView2.HasColumnErrors) return false;

            // kiem tra gì đó ....

            if(KhachHangSearchLookUpEdit.EditValue == null || KhachHangSearchLookUpEdit.EditValue == DBNull.Value)
            {
                KhachHangSearchLookUpEdit.ErrorText = "Khách hàng không được trống";
                return false;
            }

            if(string.IsNullOrEmpty(NoiDungMemoEdit.Text.Trim()))
            {
                NoiDungMemoEdit.ErrorText = "Nội dung không được trống";
                return false;
            }

            if(NhanVienSearchLookUpEdit.EditValue == null)
            {
                NhanVienSearchLookUpEdit.ErrorText = "Nhân viên không được trống";
                return false;
            }

            if(NgayHenDateEdit.DateTime == DateTime.MinValue)
            {
                NgayHenDateEdit.ErrorText = "Ngày hẹn không được trống";
                return false;
            }

            if (NgayHenDateEdit.DateTime < NgayTaoDateEdit.DateTime)
            {
                NgayHenDateEdit.ErrorText = "Ngày hẹn không hợp lý";
                return false;
            }


            return true;
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
                txtDiaChi.Text = string.Empty;
                customGridControl1.DataSource = null;
            }
            else
            {
                txtTenKH.Text = kh.TenKH;
                txtSoDT.Text = kh.SoDT;
                txtEmail.Text = kh.Email;
                txtDiaChi.Text = kh.DiaChi;
                var dataHistory = new CRMData();

                customGridControl1.DataSource = this.tuVanTableAdapter1.GetDataByKhachHang(kh.MaKH);
                this.lichSuGiaoDichTableAdapter.Fill(dataReport.LichSuGiaoDich, kh.MaKH);
            }
        }

        private void KhachHangSearchLookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                var f = new FrmThongTinKH();
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    khachHangTableAdapter.FillByUser(data.KhachHang, HeThong.NguoiDungDangNhap.TenDangNhap);
                    KhachHangSearchLookUpEdit.EditValue = f.MaKH;
                }
            }
        }

        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //NHấn nút hoàn thì cập nhật Hoàn Thành và Ngày Hoàn thành--> hỏi xem có muốn tạo lịch hẹn khác? 
            //Nếu ok thì vs trường hợp đã là khách hàng thường xuyên thì thêm lịch hẹn vs ngày hẹn là ngày hoàn thành + 30 ngày
            //Khách hàng lần đầu thì lịch hẹn là ngày hoàn thành + 10 ngàycái p

            var t = data.TuVan.FirstOrDefault();
            if (t == null) return;

            if (Kiemtra() == false) return;

            if(MsgBox.ShowYesNoDialog("Bạn muốn hoàn thành lịch hẹn này?")==DialogResult.Yes)
            {                

                t.TrangThai = (int)TrangThaiTuVan.Done;
                t.NgayTrangThai = DateTime.Now;

                if (!t.IsSoPhieuDatNull())
                {
                    phieuDatHangTableAdapter1.FillBySoPhieu(data.PhieuDatHang, t.SoPhieuDat);
                    var p = data.PhieuDatHang.FirstOrDefault();
                    if (p != null)
                    { 
                        if(p.TrangThai==(int)TrangThaiPhieuDat.Pending)
                        {
                            p.TrangThai = (int)TrangThaiPhieuDat.Done;
                            p.NgayTrangThai = DateTime.Now;
                        }
                    }
                }


                if(LuuPhieu())
                {
                    if (MsgBox.ShowYesNoDialog("Lịch hẹn đã hoàn thành! Bạn có muốn tạo lịch hẹn tiếp theo cho khách hàng này?") == DialogResult.Yes)
                    {
                        var t2 = data.TuVan.NewTuVanRow();
                        t2.ID = Guid.NewGuid().ToString();
                        t2.NhanVien = t.NhanVien;
                        t2.NgayTao = DateTime.Now;
                        t2.KhachHang = t.KhachHang;
                        t2.HinhThuc = (int)HinhThucLienLac.GoiDi;
                        t2.GhiChu = t.GhiChu;

                        if (t.IsSoPhieuDatNull())
                        {
                            t2.NoiDung = string.Format("Gọi lại tư vấn cho khách hàng tiềm năng");
                            int soNgay = Convert.ToInt32(Param.GetValue<string>("Số ngày hẹn cho KH tiềm năng", "Tham số ngày hẹn", "10"));
                            var ngayhen = Utils.TinhNgay(DateTime.Today, soNgay);
                            t2.NgayHen = new DateTime(ngayhen.Year, ngayhen.Month, ngayhen.Day, 9, 0, 0);
                            t2.Loai="TVMH";
                        }
                        else
                        {
                            var qUtil = new CRMDataTableAdapters.QueryUtil();
                            object obj = qUtil.KiemTraKHMoi(t.KhachHang);
                            bool isNew = obj == null ? false : Convert.ToBoolean(obj);



                            if (isNew)
                            {
                                t2.NoiDung = string.Format("Gọi lại chăm sóc khách hàng theo đơn hàng số [{0}]", t.SoPhieuDat);
                                int soNgay = Convert.ToInt32(Param.GetValue<string>("Số ngày hẹn tiếp theo cho KH thường xuyên", "Tham số ngày hẹn", "30"));
                                var ngayhen = Utils.TinhNgay(DateTime.Today, soNgay);
                                t2.NgayHen = new DateTime(ngayhen.Year, ngayhen.Month, ngayhen.Day, 9, 0, 0);
                            }
                            else
                            {
                                t2.NoiDung = string.Format("Gọi hỏi cảm nhận của khách hàng theo đơn hàng số [{0}]", t.SoPhieuDat);
                                int soNgay = Convert.ToInt32(Param.GetValue<string>("Số ngày hẹn tiếp theo cho KH lần đầu", "Tham số ngày hẹn", "10"));
                                var ngayhen = Utils.TinhNgay(DateTime.Today, soNgay);
                                t2.NgayHen = new DateTime(ngayhen.Year, ngayhen.Month, ngayhen.Day, 9, 0, 0);
                            }

                            t2.SoPhieuDat = t.SoPhieuDat;
                            t2.Loai="CSKH";
                        }

                        data.TuVan.AddTuVanRow(t2);

                        data.TuVan.RemoveTuVanRow(t);

                        lookUpEdit1.EditValue = t2.Loai;
                        NgayTaoDateEdit.DateTime = t2.NgayTao;
                        NgayHenDateEdit.DateTime = t2.NgayHen;
                        textEdit5.Text = t2.GhiChu;
                        NoiDungMemoEdit.Text = t2.NoiDung;

                        //if (LuuPhieu())
                        //{
                        //    MsgBox.ShowSuccessfulDialog(string.Format("Tạo lịch hẹn thành công! Lịch hẹn tiếp theo vào ngày [{0:dd/MM/yyyy HH:mm}]",t2.NgayHen));
                        //    this.DialogResult = DialogResult.OK;
                        //}
                    }
                    else
                        this.DialogResult = DialogResult.OK;
                }
            }            
        }

        private void btnXemDonHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmThongTinPhieuDH(_sophieudat, true);
            f.ShowDialog();
            
        }

    }
}