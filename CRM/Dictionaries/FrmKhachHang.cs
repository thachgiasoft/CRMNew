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
using Lotus.Libraries;
namespace CRM.Dictionaries
{
    public partial class FrmKhachHang : FrmBase
    {
        public FrmKhachHang()
        {
            InitializeComponent();
            Printable = customGridControl1;
            Landscape = true;
            PageKind = System.Drawing.Printing.PaperKind.A3;
        }

        private void FrmPhapLy_Load(object sender, EventArgs e)
        {            
            OnReload();
            btnTransfer.Enabled = HeThong.NguoiDungDangNhap.Loai >= (int)ChucDanh.QuanLy;
        }
        protected override void OnEdit()
        {
            var k = customGridView1.GetFocusedDataRow() as CRMData.KhachHangRow;
            if (k == null) return;

            var f = new FrmThongTinKH(k.MaKH);
            f.ChucNang = ChucNang;
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                OnReload();

            ReloadButtons();
        }

        protected override void OnNew()
        {
            var f = new FrmThongTinKH(string.Empty);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                OnReload();

            ReloadButtons();
        }

        protected override void OnReload()
        {
            this.tinhThanhTableAdapter.Fill(this.data.TinhThanh);
            this.nhomKHTableAdapter.Fill(this.data.NhomKH);
            this.khachHangTableAdapter.FillByUser(this.data.KhachHang, HeThong.NguoiDungDangNhap.TenDangNhap);
        }
        protected override bool OnSave()
        {
            customGridView1.CloseEditor();
            customGridView1.UpdateCurrentRow();

            if (customGridView1.HasColumnErrors) return false;
            try
            {
                var dt = data.KhachHang.GetChanges() as CRMData.KhachHangDataTable;
                if (dt != null)
                {
                    khachHangTableAdapter.Update(dt);
                    data.KhachHang.AcceptChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowErrorDialog(ex.Message);
                return false;
            }
        }
        protected override bool OnDelete()
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

        private void customGridView1_DoubleClick(object sender, EventArgs e)
        {
            OnEdit();
        }

        private void btnTransfer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            customGridView1.CloseEditor();
            var iKH = customGridView1.GetSelectedRows();
            if (iKH.Length == 0) return;
            FrmChonNV f = new FrmChonNV("");
            if(f.ShowDialog()==DialogResult.OK)
            {
                if(MsgBox.ShowYesNoDialog(string.Format("Bạn muốn chuyển những khách hàng này sang cho [{0}]?",f.NVChon))==DialogResult.Yes)
                {
                    foreach (int i in iKH)
                    {
                        var kh = customGridView1.GetDataRow(i) as CRMData.KhachHangRow;
                        kh.NVBH = f.NVChon;
                    }
                    if (OnSave())
                    {
                        OnReload();
                        ShowAlert("Đã chuyển thành công");
                    }
                }
            }
        }

       
    }
}
