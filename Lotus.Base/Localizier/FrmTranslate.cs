using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraReports.UI;
using Lotus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lotus.Base
{
    public partial class FrmTranslate : XtraForm
    {
        public FrmTranslate()
        {
            InitializeComponent();
            cboLang.Properties.Items.AddEnum(typeof(LanguageEnum));
        }

        private void FrmTranslate_Load(object sender, EventArgs e)
        {
            //LanguageHelper.Language = LanguageEnum.Vietnam;
            //LanguageHelper.Active(LanguageHelper.Language);
            //LanguageHelper.Translate(this);
            cboLang.EditValue = LanguageHelper.Language;
        }
        void InitGrid()
        {
            if (customGridControl1.DataSource == null) return;
            customGridView1.PopulateColumns();
            customGridView1.Columns["name"].VisibleIndex = 0;
            customGridView1.Columns["name"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            customGridView1.Columns["name"].OptionsColumn.AllowEdit =
            customGridView1.Columns["value"].OptionsColumn.AllowEdit = false;

            foreach (GridColumn c in customGridView1.Columns)
            {
                if (c.FieldName == "name")
                    c.Width = 350;
                else
                    c.Width = 200;

                c.ColumnEdit = rMemoEdit;
              
            }
        }
     
        private void txtPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (LanguageHelper.DSLang.GetChanges() != null)
            {
                var msg = MsgBox.ShowYesNoDialog("Bạn có chắc muốn lưu thay đổi");
                if(msg == System.Windows.Forms.DialogResult.Yes)
                    LanguageHelper.SaveXML();
            }

            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = Application.StartupPath + "\\Language";
            op.Filter = "XML files|*.xml";
            if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtPath.Text = op.FileName;
                string tbName = op.SafeFileName.Replace(".xml", string.Empty);
                txtPath.Tag = tbName;
                customGridControl1.DataSource = LanguageHelper.GetTableByName(tbName);
                InitGrid();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LanguageHelper.SaveXML();
            MsgBox.ShowSuccessfulDialog("Đã lưu");
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            if (cboLang.EditValue == null) return;
            LanguageHelper.Active((LanguageEnum)cboLang.EditValue);
            if (txtPath.Tag != null)
            {
                customGridControl1.DataSource = LanguageHelper.GetTableByName(txtPath.Tag.ToString());
                InitGrid();
            }
            LanguageHelper.Translate(this);

            cboLang.EditValue = LanguageHelper.Language;
        }

      
    }
}
