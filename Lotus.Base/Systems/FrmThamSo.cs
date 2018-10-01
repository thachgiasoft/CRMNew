using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lotus.Base.Systems
{
    public partial class FrmThamSo : FrmBase
    {
        public FrmThamSo()
        {
            InitializeComponent();
            UseEnableControl = false;
        }

        private void FrmThamSo_Load(object sender, EventArgs e)
        {
            this.thamSoTableAdapter.Fill(this.dATA.ThamSo);
            LockControls(false);
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
                var dt = dATA.ThamSo.GetChanges() as DATA.ThamSoDataTable;
                if (dt == null) return false;

                thamSoTableAdapter.Update(dt);
                dATA.ThamSo.AcceptChanges();
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

        private void customGridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (e.Column.FieldName != colGiaTri.FieldName) return;

            var p = customGridView1.GetDataRow(e.RowHandle) as DATA.ThamSoRow;
            if (p == null) return;

            if (p.KieuDuLieu == typeof(bool).ToString())
                e.RepositoryItem = rCheck;
            else if (p.KieuDuLieu == typeof(Int32).ToString()
                || p.KieuDuLieu == typeof(decimal).ToString()
                || p.KieuDuLieu == typeof(double).ToString()
                )
                e.RepositoryItem = rSpin;
            else
                e.RepositoryItem = null;
        }

    }
}
