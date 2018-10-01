using Lotus.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lotus.Base.Systems
{
    public partial class FrmNhatKyHeThong : FrmBaseReport
    {
        public FrmNhatKyHeThong()
        {
            InitializeComponent();

            Printable = customGridControl1;
        }

        private void FrmNhatKyHeThong_Load(object sender, EventArgs e)
        {
            OnReload();
        }

        protected override void OnReload()
        {
            if (ReportType == Base.ReportType.All)
                this.nhatKyHeThongTableAdapter.Fill(this.dATA.NhatKyHeThong);
            else
                this.nhatKyHeThongTableAdapter.FillByNgay(this.dATA.NhatKyHeThong, DateFrom, DateTo);
        }

        protected override bool OnSave()
        {
            layoutControl1.Validate();
            customGridView1.CloseEditor();
            customGridView1.UpdateCurrentRow();
            if (customGridView1.HasColumnErrors) return false;
            try
            {
                var dt1 = dATA.NhatKyHeThong.GetChanges() as DATA.NhatKyHeThongDataTable;
                if (dt1 != null)
                {
                    nhatKyHeThongTableAdapter.Update(dt1);
                    dATA.NhatKyHeThong.AcceptChanges();
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
            var x = MsgBox.ShowYesNoDialog("Bạn có chắc muốn xóa (những) dòng đang chọn?");
            if (x == System.Windows.Forms.DialogResult.No) return false;

            customGridView1.DeleteSelectedRows();
            if (!OnSave())
            {
                OnReload();
                return false;
            }

            return true;
        }

        private void customGridView1_DoubleClick(object sender, EventArgs e)
        {
            var n = customGridView1.GetFocusedDataRow() as DATA.NhatKyHeThongRow;
            if (n == null) return;

            if (!n.NoiDung.Contains("{")) return;
            try
            {
                string[] s = n.NoiDung.Split('{');
                string x = s[1].Replace("\"", string.Empty).Replace("}", string.Empty);

                DataTable dt = new DataTable();
                dt.Columns.Add("name");
                dt.Columns.Add("old");
                dt.Columns.Add("new");

                dt.Columns["name"].Caption = "Tên cột";
                dt.Columns["old"].Caption = "Giá trị cũ";
                dt.Columns["new"].Caption = "Giá trị mới";

                var list = x.Split(';');
                foreach (string t in list)
                {
                    string t1 = t.Trim();

                    string colName = t1.Split(':')[0];
                    string oldVal = string.Empty;
                    string newVal = string.Empty;
                    if (t1.Contains("->"))
                    {
                        string[] tmp = t1.Split('>');
                        string t2 = tmp[0];
                        t2 = t2.Replace(colName + ":", string.Empty).TrimEnd('-');
                        oldVal = t2;
                        newVal = tmp[1];
                    }
                    else
                    {
                        newVal = t1.Replace(colName + ":", string.Empty);
                    }
                    DataRow r = dt.NewRow();
                    r["name"] = colName;
                    r["old"] = oldVal;
                    r["new"] = newVal;


                    dt.Rows.Add(r);
                }

                var f = new FrmThongTinNK(dt);
                f.Text = s[0].Replace(" =", string.Empty);
                f.ShowDialog();
            }
            catch { }
        }
    }
}
