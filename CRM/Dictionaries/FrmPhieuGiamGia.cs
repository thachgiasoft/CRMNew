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
namespace CRM.Dictionaries
{
    public partial class FrmPhieuGiamGia : FrmBase
    {
        public FrmPhieuGiamGia()
        {
            InitializeComponent();
            Printable = customGridControl1;

            customGridView1.FormatCode = Param.GetValue<string>("Phiếu giảm giá", "Định dạng mã", "V{0:d7}");
        }

        private void FrmPhapLy_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'data.KhachHang' table. You can move, or remove it, as needed.
            this.khachHangTableAdapter.Fill(this.data.KhachHang);
          
            OnReload(); 
        }

        protected override void OnNew()
        {
            customGridView1.AddNewRow();
            customGridView1.UpdateCurrentRow();
        }

        protected override void OnReload()
        {
            this.phieuGiamGiaTableAdapter.Fill(this.data.PhieuGiamGia);
        }
        protected override bool OnSave()
        {
            customGridView1.CloseEditor();
            customGridView1.UpdateCurrentRow();

            if (customGridView1.HasColumnErrors) return false;
            try
            {
                var dt = data.PhieuGiamGia.GetChanges() as CRMData.PhieuGiamGiaDataTable;
                if (dt != null)
                {
                    phieuGiamGiaTableAdapter.Update(dt);
                    data.PhieuGiamGia.AcceptChanges();
                }

                return true;
            }
            catch(Exception ex)
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

        private void btnTaoTuDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var f = new FrmTaoPhieuGiamGiaTuDong(data.PhieuGiamGia);
            f.ShowDialog();
        }
    }
}
