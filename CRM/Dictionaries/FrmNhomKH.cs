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
    public partial class FrmNhomKH : FrmBase
    {
        public FrmNhomKH()
        {
            InitializeComponent();
            Printable = treeList1;

        }

        private void FrmPhapLy_Load(object sender, EventArgs e)
        {
            OnReload();
            LockControls(false);
        }

        protected override void OnNew()
        {
            var x = nhomKHBindingSource.AddNew() as DataRowView;
            var dv = x.Row as CRMData.NhomKHRow;
            dv.ID = data.NhomKH.Rows.Count + 1;

            nhomKHBindingSource.EndEdit();
        }

        protected override void OnReload()
        {
            this.nhomKHTableAdapter.Fill(this.data.NhomKH);
        }
        protected override bool OnSave()
        {
            treeList1.CloseEditor();
            try
            {

                var dt = data.NhomKH.GetChanges() as CRMData.NhomKHDataTable;
                if (dt != null)
                {
                    nhomKHTableAdapter.Update(dt);
                    data.NhomKH.AcceptChanges();
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
            var x = MsgBox.ShowYesNoDialog("Bạn có chắc muốn xóa (những) dòng này?");
            if (x == System.Windows.Forms.DialogResult.No) return false;

            treeList1.DeleteSelectedNodes();
            if (!OnSave())
            {
                OnReload();
            }


            return true;
        }
    }
}
