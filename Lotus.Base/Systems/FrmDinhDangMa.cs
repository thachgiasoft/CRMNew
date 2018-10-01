using Lotus.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lotus.Main.Systems
{
    public partial class FrmDinhDangMa : FrmBase
    {
        public FrmDinhDangMa()
        {
            InitializeComponent();
            UseEnableControl = false;
        }

        private void FrmThamSo_Load(object sender, EventArgs e)
        {
            this.dinhDangMaTableAdapter.Fill(this.dATA.DinhDangMa);
        }
        protected override bool OnCancelClosing()
        {
            return false;
        }
        protected override bool OnSave()
        {
            layoutControl1.Validate();
            customGridView1.UpdateCurrentRow();

            try
            {
                var dt = dATA.DinhDangMa.GetChanges() as DATA.DinhDangMaDataTable;
                if (dt == null) return false;

                dinhDangMaTableAdapter.Update(dt);
                dATA.DinhDangMa.AcceptChanges();

                HeThong.NapDinhDang();
                DialogResult = System.Windows.Forms.DialogResult.OK;
                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowErrorDialog(ex.Message);
                return false;
            }
        }
      

    }
}
