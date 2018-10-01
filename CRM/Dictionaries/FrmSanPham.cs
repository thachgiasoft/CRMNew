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
    public partial class FrmSanPham : FrmBase
    {
        public FrmSanPham()
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
            this.loaiSPTableAdapter.Fill(this.data.LoaiSP);            
            this.sanPhamTableAdapter.Fill(this.data.SanPham);
        }
        protected override bool OnSave()
        {
            customGridView1.CloseEditor();
            customGridView1.UpdateCurrentRow();

            if (customGridView1.HasColumnErrors) return false;
            try
            {
                var dt = data.SanPham.GetChanges() as CRMData.SanPhamDataTable;
                if (dt != null)
                {
                    sanPhamTableAdapter.Update(dt);
                    data.BenhLy.AcceptChanges();
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
