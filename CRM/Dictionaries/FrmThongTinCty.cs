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
    public partial class FrmThongTinCty : FrmBase
    {
        public FrmThongTinCty()
        {
            InitializeComponent();
        }

        private void FrmThongTinCty_Load(object sender, EventArgs e)
        {            
            UseEnableControl = false;
            LockControls(false);

        
            Bindings();
        }

        private void Bindings()
        {
            this.thongTinCongTyTableAdapter.Fill(this.data.ThongTinCongTy);
            if (data.ThongTinCongTy.Count == 0)
            {
                var tt = data.ThongTinCongTy.NewThongTinCongTyRow();
                data.ThongTinCongTy.AddThongTinCongTyRow(tt);
                thongTinCongTyBindingSource.EndEdit();
            }
        }
        protected override bool OnSave()
        {
            dataLayoutControl1.Validate();
            thongTinCongTyBindingSource.EndEdit();
            var dt = data.ThongTinCongTy.GetChanges() as CRMData.ThongTinCongTyDataTable;
            if(dt!= null)
            {
                thongTinCongTyTableAdapter.Update(dt);
                data.ThongTinCongTy.AcceptChanges();
                this.DialogResult = DialogResult.OK;
                return true;
            }
            return false;
        }

     
    }
}
