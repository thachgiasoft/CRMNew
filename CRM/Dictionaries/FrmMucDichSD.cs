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
    public partial class FrmMucDichSD : FrmBase
    {
        public FrmMucDichSD()
        {
            InitializeComponent();
            Printable = customGridControl1;

        }

        private void FrmMucDichSD_Load(object sender, EventArgs e)
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
            this.mucDichSDTableAdapter.Fill(this.data.MucDichSD);
        }
        protected override bool OnSave()
        {
            customGridView1.CloseEditor();
            customGridView1.UpdateCurrentRow();

            if (customGridView1.HasColumnErrors) return false;
            try
            {
                var dt = data.MucDichSD.GetChanges() as CRMData.MucDichSDDataTable;
                if (dt != null)
                {
                    mucDichSDTableAdapter.Update(dt);
                    data.MucDichSD.AcceptChanges();
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
    }
}
