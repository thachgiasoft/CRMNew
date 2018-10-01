using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

using DevExpress.Xpo;
using Lotus.Base;

namespace Lotus.Systems
{
    public partial class FrmImport2 : FrmBase
    {
        DataTable _dt = new DataTable();
        public FrmImport2()
        {
            InitializeComponent();
            UseEnableControl = false;

            _dt.Columns.Add("Selected", typeof(bool));
            _dt.Columns.Add("FileName");
            _dt.Columns.Add("FullName");
            _dt.Columns.Add("Status");

            customGridControl1.DataSource = _dt;
        }

    

       

        private void RunImportData()
        {
            customGridView1.CloseEditor();
            customGridView1.UpdateCurrentRow();

            foreach (DataRow r in _dt.Rows)
            {
                r["Status"] = DBNull.Value;
            }
            customGridControl1.RefreshDataSource();
            customGridControl1.Refresh();
            int i = 0;
            foreach (DataRow r in _dt.Rows)
            {
                customGridView1.FocusedRowHandle = i;
                if (r["Selected"].Equals(false)) continue;

                r["Status"] = "Runing";
             
                customGridControl1.RefreshDataSource();
                customGridControl1.Refresh();
                var b = ImportData.ImportKhach(r["FullName"].ToString(), "GridViewExporter");

                r["Status"] = b ? "OK" : "ERROR";
                customGridControl1.RefreshDataSource();
                customGridControl1.Refresh();
                i++;
            }

            MsgBox.CloseWaitForm();
        }

        private void txtPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var op = new FolderBrowserDialog();
          
            op.SelectedPath = Application.StartupPath;
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = op.SelectedPath;

                var d = new DirectoryInfo(op.SelectedPath);
                var list = d.GetFiles("*.*", SearchOption.AllDirectories);
                foreach (FileInfo f in list)
                {
                    var r = _dt.NewRow();
                    r["Selected"] = true;
                    r["FileName"] = f.Name;
                    r["FullName"] = f.FullName;
                    _dt.Rows.Add(r);
                }
            }
        }

  
        protected override bool OnSave()
        {
            RunImportData();
            return true;
        }

     
    }
}