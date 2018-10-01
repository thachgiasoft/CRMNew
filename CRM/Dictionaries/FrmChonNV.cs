using DevExpress.XtraEditors;
using Lotus;
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
    public partial class FrmChonNV : XtraForm
    {
        public string NVChon
        {
            get
            {
                return lookUpEdit1.EditValue == null ? string.Empty : lookUpEdit1.EditValue.ToString();
            }
        
        }
        public FrmChonNV(string nvgiao)
        {
            InitializeComponent();

            nguoiDungTableAdapter1.Fill(data1.NguoiDung);
            var n = data1.NguoiDung.FindByTenDangNhap(nvgiao);
            if (n != null)
                data1.NguoiDung.RemoveNguoiDungRow(n);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
          
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
