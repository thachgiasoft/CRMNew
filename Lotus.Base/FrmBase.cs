using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Base;
using System.Linq;
using DevExpress.XtraLayout;
using System.Collections.Generic;

using System.Data;
using System.Data.OleDb;
using DevExpress.Xpo;

using Lotus.Libraries;
using System.ComponentModel;
using System.Reflection;
using DevExpress.XtraGrid.Views.BandedGrid;
using Lotus.Base.Systems;
using DevExpress.XtraTreeList;
namespace Lotus.Base
{
    public partial class FrmBase : XtraForm
    {
        //string chucnang = string.Empty;

        public bool AllowClose = true;
        public bool UseEnableControl = true;

        DATATableAdapters.NhatKyHeThongTableAdapter _nkAD = new DATATableAdapters.NhatKyHeThongTableAdapter();
        public DATA.NhatKyHeThongDataTable _dtNhatKy;

        bool _checkEditOnAdd = false;

        public FrmBase()
        {
            InitializeComponent();

            ChucNang = HeThong.ChucNangDangChon;
            AllowLog = true;
            var dstmp = new DATA();
            _dtNhatKy = dstmp.NhatKyHeThong;
        }
        public string ChucNang { get; set; }
        

        protected virtual void OnReload()
        {
           
        }

        protected virtual void OnNew() { }

        protected virtual void OnEdit()
        {

        }

        protected virtual bool OnSave()
        {
            return false;
        }

        protected virtual void OnClose()
        {
            Close();
        }

        protected virtual void OnPrint()
        {
        }

        protected virtual bool OnDelete()
        {
            return false;
        }


        public bool IsDataChange()
        {
            var x = EnumerateComponents();
            var b = x.FirstOrDefault(c => c is BindingSource);
            if (b == null) return false;

            var ds = (b as BindingSource).DataSource as DataSet;
            if (ds == null) return false;


            return ds.HasChanges();
        }


        BindingSource FindBindingSource()
        {
            var x = EnumerateComponents();
            var b = x.FirstOrDefault(c => c is BindingSource);
            return b == null ? null : b as BindingSource;
        }

        protected virtual bool OnCancelClosing()
        {
            var bs = FindBindingSource();
            if (bs != null)
            {
                try
                {
                    bs.EndEdit();
                }
                catch
                {
                    bs.CancelEdit();
                }
            }

            if (AllowClose)
            {
                if (IsDataChange())
                {
                    var s = MsgBox.ShowYesNoCancelDialog(Text, "Bạn có muốn lưu những thay đổi?");
                    if (s == DialogResult.Cancel)
                    {
                        return true;
                    }
                    if (s == DialogResult.No)
                    {
                        return false;
                    }
                    OnSave();
                    return false;
                }
                return false;
            }
            return true;
        }

        private void FrmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = OnCancelClosing();
        }

        #region In mặc định

        private IPrintable _print;

        protected IPrintable Printable
        {
            get { return _print; }
            set
            {
                _print = value;

                #region Thiết kế trước khi in

                if (_print != null)
                {
                    var g = Printable as GridControl;
                    if (g != null)
                    {
                        foreach (BaseView v in g.ViewCollection)
                        {
                            var view = v as GridView;
                            if (view != null)
                            {
                                view.AppearancePrint.EvenRow.BackColor = Color.FromArgb(239, 243, 250);
                                view.AppearancePrint.EvenRow.BorderColor = Color.FromArgb(175, 190, 216);
                                view.AppearancePrint.EvenRow.Options.UseBackColor = true;
                                view.AppearancePrint.EvenRow.Options.UseBorderColor = true;

                                view.AppearancePrint.FooterPanel.BackColor = Color.LightYellow;
                                view.AppearancePrint.FooterPanel.Options.UseBackColor = true;
                                view.AppearancePrint.FooterPanel.Font = new Font("Times New Roman", 11F);
                                view.AppearancePrint.FooterPanel.Options.UseBorderColor = true;
                                view.AppearancePrint.FooterPanel.Options.UseFont = true;
                                view.AppearancePrint.FooterPanel.Options.UseForeColor = true;
                                view.AppearancePrint.FooterPanel.ForeColor = Color.DarkRed;
                                view.AppearancePrint.FooterPanel.BorderColor = Color.FromArgb(175, 190, 216);


                                view.AppearancePrint.GroupFooter.BackColor = Color.FromArgb(255, 253, 234);
                                view.AppearancePrint.GroupFooter.Options.UseBackColor = true;
                                view.AppearancePrint.GroupRow.BackColor = Color.FromArgb(249, 255, 242);
                                view.AppearancePrint.GroupRow.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
                                view.AppearancePrint.GroupRow.Options.UseBackColor = true;
                                view.AppearancePrint.GroupRow.Options.UseFont = true;
                                view.AppearancePrint.HeaderPanel.BackColor = Color.FromArgb(201, 214, 237);
                                view.AppearancePrint.HeaderPanel.BorderColor = Color.FromArgb(175, 190, 216);
                                view.AppearancePrint.HeaderPanel.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
                                view.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
                                view.AppearancePrint.HeaderPanel.Options.UseBorderColor = true;
                                view.AppearancePrint.HeaderPanel.Options.UseFont = true;
                                view.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
                                view.AppearancePrint.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
                                view.AppearancePrint.HeaderPanel.TextOptions.VAlignment = VertAlignment.Center;
                                view.AppearancePrint.HeaderPanel.TextOptions.WordWrap = WordWrap.Wrap;
                                view.AppearancePrint.Lines.BackColor = Color.FromArgb(175, 190, 216);
                                view.AppearancePrint.Lines.BorderColor = Color.FromArgb(175, 190, 216);
                                view.AppearancePrint.Lines.Options.UseBackColor = true;
                                view.AppearancePrint.Lines.Options.UseBorderColor = true;
                                view.AppearancePrint.Row.BorderColor = Color.FromArgb(175, 190, 216);
                                view.AppearancePrint.Row.Options.UseBorderColor = true;
                                view.AppearancePrint.Row.Font = new Font("Times New Roman", 11F);
                                view.AppearancePrint.Row.Options.UseBorderColor = true;
                                view.AppearancePrint.Row.Options.UseFont = true;

                                view.AppearancePrint.GroupFooter.BackColor = Color.FromArgb(240, 212, 194);
                                view.AppearancePrint.GroupFooter.Options.UseBackColor = true;
                                view.AppearancePrint.GroupFooter.Font = new Font("Times New Roman", 11F);
                                view.AppearancePrint.GroupFooter.Options.UseBorderColor = true;
                                view.AppearancePrint.GroupFooter.Options.UseFont = true;


                                view.OptionsPrint.EnableAppearanceEvenRow = true;
                            }
                            var adview = v as AdvBandedGridView;
                            if (adview != null)
                            {
                                adview.AppearancePrint.BandPanel.BackColor = Color.FromArgb(201, 214, 237);
                                adview.AppearancePrint.BandPanel.BackColor = Color.FromArgb(201, 214, 237);
                                adview.AppearancePrint.BandPanel.BorderColor = Color.FromArgb(175, 190, 216);
                                adview.AppearancePrint.BandPanel.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
                                adview.AppearancePrint.BandPanel.Options.UseBackColor = true;
                                adview.AppearancePrint.BandPanel.Options.UseBorderColor = true;
                                adview.AppearancePrint.BandPanel.Options.UseFont = true;
                                adview.AppearancePrint.BandPanel.Options.UseTextOptions = true;
                                adview.AppearancePrint.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
                                adview.AppearancePrint.BandPanel.TextOptions.VAlignment = VertAlignment.Center;
                                adview.AppearancePrint.BandPanel.TextOptions.WordWrap = WordWrap.Wrap;
                            }

                        }
                    }
                }

                #endregion
            }
        }

        public WinControlContainer CopyGridControl(IPrintable grid)
        {
            var winContainer = new WinControlContainer();

            winContainer.Location = new Point(0, 0);
            winContainer.Size = new Size(200, 100);

            winContainer.WinControl = (grid as Control);
            return winContainer;
        }

        protected PaperKind PageKind { get; set; }
        protected bool Landscape { get; set; }

        protected string ReportDate { get; set; }
        protected string ReportName { get; set; }
        protected virtual void OnPrintPreview()
        {
           
            var r = new SaleReport();
            if (string.IsNullOrEmpty(ReportName))
                ReportName = Text.ToUpper();

            r.ReportName = ReportName;
            r.PaperKind = PageKind;
            r.Landscape = Landscape;
            r.ReportDate = ReportDate;
            r.AutoSizeReportName();

            r.Bands[BandKind.Detail].Controls.Add(CopyGridControl(Printable));
            r.ShowPrintPreview();
        }

        #endregion

        #region AlertControl

        protected void ShowAlert(string caption, string text, AlertType type)
        {
            Image img = null;
            if (type == AlertType.Done)
                img = img32.Images["apply_32x32.png"];
            else if (type == AlertType.Error)
                img = img32.Images["cancel_32x32.png"];
            else if (type == AlertType.Info)
                img = img32.Images["info_32x32.png"];

            if (HeThong.DaNgonNgu)
            {
                caption = LanguageHelper.TranslateMsgString(caption, caption);
                text = LanguageHelper.TranslateMsgString(text, text);
            }
            alert.Show(this, caption, text, img);
        }

        protected void ShowAlert(string caption, string text)
        {
            ShowAlert(caption, text, AlertType.Done);
        }

        public void ShowAlert(string text)
        {
            ShowAlert("Thông báo", text, AlertType.Done);
        }




        #endregion

        #region Button Click

        private void btnReload_ItemClick(object sender, ItemClickEventArgs e)
        {
            _dtNhatKy.Clear();
            _checkEditOnAdd = false;
            MsgBox.ShowWaitForm();
            EnableControls(true, true, true);
            OnReload();
            if (UseEnableControl)
                LockControls(true);

            MsgBox.CloseWaitForm();
        }

        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            EnableControls(false, true, false);
            OnEdit();
        }

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            _checkEditOnAdd = true;
            EnableControls(true, false, false);
            OnNew();
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (OnDelete())
                SaveNhatKy();
            
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            var l = FindLayoutControl();
            if (l != null)
                l.Validate();

            //TODO:
            AddLog();

            if (OnSave())
            {
                ShowAlert("Đã xử lý thành công");
                EnableControls(true, true, true);
                LockControls(true);
                _checkEditOnAdd = false;
                //TODO:
                SaveNhatKy();
            }
        }

      


        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            OnClose();
        }

        private void btnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            OnPrint();
        }

        private void btnPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            MsgBox.ShowWaitForm();
            OnPrintPreview();
            MsgBox.CloseWaitForm();
        }

        #endregion



        #region Ghi nhật ký
        public bool AllowLog { get; set; }
        public void AddDeleleInfoLog(object o)
        {
            if (AllowLog == false) return;

            bool bLog = Param.GetValue<bool>("Ghi nhật ký hệ thống", "Hệ thống", true);
            if (!bLog) return;

            DataRow r = null;

            if (o is DataRow)
                r = o as DataRow;
            else if (o is DataRowView)
            {
                var v = o as DataRowView;
                r = v.Row;
            }
            if (r == null) return;


            string text = string.Empty;
            var keys = r.Table.PrimaryKey;
            foreach (var col in keys)
                text += string.Format("{0}:{1}; ", col.ColumnName, r[col]);
            if (text.Length > 2)
            {
                text = text.Remove(text.Length - 2, 2);
                text = string.Format("{0}[{1}]", r.Table.TableName, text);
            }



            var nk = _dtNhatKy.NewNhatKyHeThongRow();
            nk.NgayGio = DateTime.Now;
            nk.NguoiDung = HeThong.TenDangNhap;

            nk.NoiDung = string.Format("Xóa {0}", text);

            _dtNhatKy.AddNhatKyHeThongRow(nk);
        }
        private void SaveNhatKy()
        {
            if (AllowLog == false) return;
            try
            {
                var xx = _dtNhatKy.GetChanges() as DATA.NhatKyHeThongDataTable;
                if (xx != null)
                {
                    _nkAD.Update(xx);
                    _dtNhatKy.Clear();
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowErrorDialog(ex.Message);
            }

        }
        private void AddLog()
        {
            if (AllowLog == false) return;

            bool bLog = Param.GetValue<bool>("Ghi nhật ký hệ thống", "Hệ thống", true);
            if (!bLog) return;

            var x = EnumerateComponents();

            var listBS = x.OfType<BindingSource>();
            foreach (var g in listBS)
                g.EndEdit();

            var b = x.FirstOrDefault(c => c is BindingSource);
            if (b != null) (b as BindingSource).EndEdit();

            //var ds = (b as BindingSource).DataSource as DataSet;
            //if (ds == null) return;

            DataSet ds = null;
            
            // TODO: form gì goi vay form doi mat khau, tạm thoi khoi ghi log, ktra sau
            if (b == null) return;


            var source = (b as BindingSource).DataSource;
            if (source is DataSet)
                ds = source as DataSet;
            else if (source is DataRow)
            {
                var row = source as DataRow;
                ds = row.Table.DataSet;
            }

            if (ds == null) return;





            _dtNhatKy.Clear();
           
            var dsChange = ds.GetChanges();
            if (dsChange == null) return;

            foreach (DataTable t in dsChange.Tables)
            {
                foreach (DataRow r in t.Rows)
                {
                    string nd = GetLogString(r);
                    if (nd == string.Empty) continue;

                    var nk = _dtNhatKy.NewNhatKyHeThongRow();
                    nk.NgayGio = DateTime.Now;
                    nk.NguoiDung = HeThong.TenDangNhap;
                    nk.NoiDung = nd;
                    _dtNhatKy.AddNhatKyHeThongRow(nk);
                }
            }

        }
        public string GetLogString(DataRow r)
        {
            string s = string.Empty;
            string text = string.Empty;
            var keys = r.Table.PrimaryKey;

            if (r.RowState == DataRowState.Added)
            {
                foreach (var col in keys)
                    text += string.Format("{0}:{1}; ", col.ColumnName, r[col]);
                if (text.Length > 2)
                {
                    text = text.Remove(text.Length - 2, 2);
                    text = string.Format("{0}[{1}]", r.Table.TableName, text);
                }

                for (int i = 0; i < r.Table.Columns.Count; i++)
                {
                    if (!r[i].Equals(DBNull.Value) && !r[i].Equals(string.Empty))
                        s += string.Format("{0}:{1}; ", r.Table.Columns[i].ColumnName, r[i]);
                }
                if (s.Length > 2)
                {
                    s = s.Remove(s.Length - 2, 2);
                    s = "Thêm " + text + " = " + "{" + s + "}";
                }
            }
            else if (r.RowState == DataRowState.Modified)
            {
                foreach (var col in keys)
                    text += string.Format("{0}:{1}; ", col.ColumnName, r[col, DataRowVersion.Original]);
                if (text.Length > 2)
                {
                    text = text.Remove(text.Length - 2, 2);
                    text = string.Format("{0}[{1}]", r.Table.TableName, text);
                }

                for (int i = 0; i < r.Table.Columns.Count; i++)
                {
                    var r2 = r[i, DataRowVersion.Original];
                    if (!r[i].Equals(r2))
                        s += string.Format("{0}:{1}->{2}; ", r.Table.Columns[i].ColumnName, r2, r[i]);
                }
                if (s.Length > 2)
                {
                    s = s.Remove(s.Length - 2, 2);
                    s = "Sửa " + text + " = " + "{" + s + "}";
                }
            }



            return s;
        }
        
        #endregion


        private IEnumerable<Component> EnumerateComponents()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(Component).IsAssignableFrom(field.FieldType)
                   let component = (Component)field.GetValue(this)
                   where component != null
                   select component;
        }

        public LayoutControl FindLayoutControl()
        {
            return Controls.OfType<LayoutControl>().Select(c => c).FirstOrDefault();
        }
        public List<GridControl> FindGridControls()
        {
            var l = FindLayoutControl();
            if (l == null)
            {
                return Controls.OfType<GridControl>().Select(c => c).ToList();
            }
            return l.Controls.OfType<GridControl>().Select(c => c).ToList();
        }
        public List<TreeList> FindTreeLists()
        {
            var l = FindLayoutControl();
            if (l == null)
            {
                return Controls.OfType<TreeList>().Select(c => c).ToList();
            }
            return l.Controls.OfType<TreeList>().Select(c => c).ToList();
        }

        private void FrmBase_Load(object sender, EventArgs e)
        {
            EnableControls(true, true, true);
            LockControls(true);
        }

        DATA.PhanQuyenRow _quyen;

        private void FrmBase_Activated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(HeThong.TenDangNhap)) return;
            if (string.IsNullOrEmpty(ChucNang)) return;

            //if (this.MdiParent == null) return; // tam thoi cheat

            var p = HeThong.LayPhanQuyen(ChucNang, HeThong.TenDangNhap, false);
            if (p == null) return;

            _quyen = p;

            if (!p.TruyCap && !IsInitializing)
            {
                MsgBox.ShowWarningDialog("Bạn không có quyền truy cập chức năng này");
                this.Close();
            }

            btnAdd.Enabled = p.Them;
            btnDelete.Enabled = p.Xoa;
            btnEdit.Enabled = p.Sua;
            btnSave.Enabled = p.Sua | p.Them;

            btnPrintPreview.Enabled = HeThong.NguoiDungDangNhap.Loai == 3;

            var l = FindGridControls();
            foreach (GridControl g in l)
            {
                var v = g.MainView as CustomGridView;
                if (v == null) continue;
                if (v.OptionsView.NewItemRowPosition == NewItemRowPosition.None) return;

                v.OptionsView.NewItemRowPosition = p.Them ? NewItemRowPosition.Bottom : NewItemRowPosition.None;
            }


        }



        protected void ReloadButtons()
        {
            _checkEditOnAdd = false;
            EnableControls(true,true,true);
        }

        protected void LockControls(bool isLocked)
        {
            var l = FindLayoutControl();
            if (l == null) return;

            var collectionBaseEdit = l.Controls.OfType<BaseEdit>().Select(c => c);
            foreach (var t in collectionBaseEdit)
            {
                t.Properties.ReadOnly = isLocked;

                if (t.DataBindings.Count > 1)
                    t.Properties.ReadOnly = true;
            }
            var gg = FindGridControls();
            foreach (GridControl g in gg)
            {
                var v = g.MainView as ColumnView;
                if (v == null) continue;
                v.OptionsBehavior.Editable = !isLocked;
            }
        }
        protected void EnableControls(bool allowNew, bool allowEdit, bool allowDelete)
        {
            if (!UseEnableControl) return;
            if (string.IsNullOrEmpty(HeThong.TenDangNhap)) return;
            if (ChucNang != null)
            {
                var p = HeThong.LayPhanQuyen(ChucNang, HeThong.TenDangNhap, false);
                if (p == null) return;

                allowNew = allowNew & p.Them;
                allowEdit = allowEdit & p.Sua;
                allowDelete = allowDelete & p.Xoa;

                btnAdd.Enabled = allowNew;
                btnEdit.Enabled = allowEdit;
                btnDelete.Enabled = allowDelete;
            }

            var l = FindLayoutControl();
            if (l == null) return;

            bool r = true;
            if (allowNew & allowEdit) r = true;
            else r = false;

            var collectionBaseEdit = l.Controls.OfType<BaseEdit>().Select(c => c);
            foreach (var t in collectionBaseEdit)
            {
                t.Properties.ReadOnly = r;

                if (t.DataBindings.Count > 1)
                    t.Properties.ReadOnly = true;
            }
            var gg = FindGridControls();
            foreach (GridControl g in gg)
            {
                var v = g.MainView as ColumnView;
                if (v == null) continue;
                v.OptionsBehavior.Editable = !r;

                v.FocusedRowChanged -= v_FocusedRowChanged;
                v.FocusedRowChanged += v_FocusedRowChanged;
            }
        }

        void v_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (!_checkEditOnAdd) return;

            var v = sender as ColumnView;
            if (v == null) return;

            var r = v.GetFocusedDataRow();
            if (r == null) return;

            if (Data.IsNewRow(r))
            {
                v.OptionsBehavior.Editable = _quyen.Them;
            }
            else
                v.OptionsBehavior.Editable = _quyen.Sua;
        }


        protected DataTable GetExcelTable(string fileName, string sheetName)
        {
            return GetExcelTable(fileName, sheetName, string.Empty);
        }

        protected DataTable GetExcelTable(string fileName, string sheetName, string sql)
        {
            sheetName = sheetName.Replace(".", "#");
            if (sql == string.Empty)
                sql = string.Format("select * from [{0}$]", sheetName);

            var strConn = string.Empty;
            if (fileName.Contains(".xlsx"))
            {
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                          + fileName + ";Extended Properties=\"Excel 12.0;HDR=YES\";";
            }
            else if (fileName.Contains(".xls"))
            {
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                          "Data Source=" + fileName + ";Extended Properties=Excel 8.0;";
            }
            var dt = new DataTable();
            try
            {
                var oleConn = new OleDbConnection(strConn);
                var oleCmd = new OleDbDataAdapter(sql, strConn);
                oleCmd.Fill(dt);
            }
            catch (Exception ex)
            {
                MsgBox.ShowWarningDialog("Không import được file");
                Console.WriteLine(ex.Message);

                return null;
            }
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns[0].DataType == typeof(string))
                        dr[0] = Convert.ToString(dr[0]).Replace("&", "");

                }

            return dt;
        }


        protected OleDbDataReader GetExcelReader(string fileName, string sheetName)
        {
            return GetExcelReader(fileName, sheetName, string.Empty);
        }
        protected OleDbDataReader GetExcelReader(string fileName, string sheetName, string sql)
        {
            OleDbDataReader reader;
            sheetName = sheetName.Replace(".", "#");
            if (sql == string.Empty)
                sql = string.Format("select * from [{0}$]", sheetName);

            var strConn = string.Empty;
            if (fileName.Contains(".xlsx"))
            {
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                          + fileName + ";Extended Properties=\"Excel 12.0;HDR=YES\";";
            }
            else if (fileName.Contains(".xls"))
            {
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                          "Data Source=" + fileName + ";Extended Properties=Excel 8.0;";
            }

            try
            {
                var oleConn = new OleDbConnection(strConn);
                oleConn.Open();
                var oleCmd = new OleDbCommand(sql, oleConn);
                reader = oleCmd.ExecuteReader();
                oleConn.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowWarningDialog("Không import được file");
                Console.WriteLine(ex.Message);

                return null;
            }


            return reader;
        }

    

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Translate();

            var treeList = FindTreeLists();
            foreach (var t in treeList)
            {
                var source = t.DataSource as BindingSource;
                if (source == null) continue;

                var ds = source.DataSource as DataSet;
                if (ds == null) continue;

                ds.Tables[source.DataMember].RowDeleting += FrmBase_RowDeleting;
            }
        }

        void FrmBase_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            AddDeleleInfoLog(e.Row);
        }

      
        public virtual void Translate()
        {
            if (HeThong.DaNgonNgu == false) return;
            LanguageHelper.Translate(this);
        }
      
    }
}