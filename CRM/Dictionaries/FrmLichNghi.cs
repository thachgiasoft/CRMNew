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
using CRM.Reports;
namespace CRM.Dictionaries
{
    public partial class FrmLichNghi : FrmBaseReport
    {
        public FrmLichNghi()
        {
            InitializeComponent();
            Printable = customGridControl1;

        }

        private void FrmPhapLy_Load(object sender, EventArgs e)
        {            
            OnReload(); 
        }

        protected override void OnNew()
        {
            customGridView1.AddNewRow();
            customGridView1.UpdateCurrentRow();
        }

        protected override void OnReload()
        {
            base.OnReload(); // base reoirt thi goi lai de no xac dinh cái ngày chinh xac
            this.lichNghiTableAdapter.Fill(this.data.LichNghi);
        }
        protected override bool OnSave()
        {
            customGridView1.CloseEditor();
            customGridView1.UpdateCurrentRow();

            if (customGridView1.HasColumnErrors) return false;
            try
            {
                var dt = data.LichNghi.GetChanges() as CRMData.LichNghiDataTable;
                if (dt != null)
                {
                    lichNghiTableAdapter.Update(dt);
                    data.LichNghi.AcceptChanges();
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

        protected override void OnPrintPreview()
        {
            var r = new CRMBaseReport();
            r.ShowPreview();
        }

        private void btnTaoLichNghi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var x = MsgBox.ShowYesNoDialog(string.Format("Bạn có muốn tạo ngày nghỉ mặc định trong năm {0}", Nam));
            if (x == System.Windows.Forms.DialogResult.Cancel) return;



            var utilAD = new CRMDataTableAdapters.QueryUtil();
            utilAD.CRM_SetOffDate(Nam);

            // có ktra trung chua?
            OnReload();

        }
    }
}
