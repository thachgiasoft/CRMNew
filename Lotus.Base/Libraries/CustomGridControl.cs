using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using DevExpress.Data.Async.Helpers;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using Lotus.Systems;
using Lotus.Base.Systems;
using Lotus.Base;

namespace Lotus.Libraries
{
    [ToolboxItem(true)]
    public class CustomGridControl : GridControl
    {
        private GridView gridView1;
        private IContainer components;
    
        public CustomGridControl()
        {
            Load += CustomGridControl_Load;
        }

        private void CustomGridControl_Load(object sender, EventArgs e)
        {
            var view = MainView as CustomGridView;
            if (view == null) return;

            foreach (GridColumn c in view.Columns)
            {
                c.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                if (c.ColumnType == typeof(DateTime) || c.FieldName == view.KeyColumn)
                {
                    c.AppearanceCell.Options.UseTextOptions = true;
                    c.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                }
            }
        }

        public override bool UseEmbeddedNavigator
        {
            get
            {
                return base.UseEmbeddedNavigator;
            }
            set
            {
                base.UseEmbeddedNavigator = value;
                if(value == true)
                {
                    EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
                    EmbeddedNavigator.Buttons.Edit.Visible = false;
                    EmbeddedNavigator.Buttons.EndEdit.Visible = false;
                    EmbeddedNavigator.Buttons.First.Visible = false;
                    EmbeddedNavigator.Buttons.Last.Visible = false;
                    EmbeddedNavigator.Buttons.Next.Visible = false;
                    EmbeddedNavigator.Buttons.NextPage.Visible = false;
                    EmbeddedNavigator.Buttons.Prev.Visible = false;
                    EmbeddedNavigator.Buttons.PrevPage.Visible = false;
                    EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;

                  
                }
            }
        }

        protected override BaseView CreateDefaultView()
        {
            return CreateView("CustomGridView");
        }

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new CustomGridViewInfoRegistrator());
        }

        private void InitializeComponent()
        {
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this;
            this.gridView1.Name = "gridView1";
            // 
            // CustomGridControl
            // 
            this.MainView = this.gridView1;
            this.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }

    public class CustomGridView : GridView
    {
        public CustomGridView()
            : this(null)
        {
            UseAutoCode = true;
            UseAutoLog = true;
            ShowIndexIndicator = true;

        }

        public CustomGridView(GridControl grid)
            : base(grid)
        {
            BeginInit();
            OptionsFind.AlwaysVisible = false;
            OptionsFind.FindMode = FindMode.Always;
            OptionsFind.HighlightFindResults = true;

            OptionsBehavior.AllowIncrementalSearch = false;
            //OptionsView.EnableAppearanceEvenRow = true;
            //OptionsDetail.EnableMasterViewMode = false;
            AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            AppearancePrint.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            AppearancePrint.HeaderPanel.TextOptions.VAlignment = VertAlignment.Center;

            Appearance.HeaderPanel.Options.UseTextOptions = true;
            Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            Appearance.HeaderPanel.TextOptions.VAlignment = VertAlignment.Center;


           Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
           Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
           Appearance.FooterPanel.Options.UseFont = true;
           Appearance.FooterPanel.Options.UseForeColor = true;


            GroupFormat = "[#image]{1} {2}";

            FixedLineWidth = 1;

            OptionsBehavior.AutoExpandAllGroups = true;

            CustomDrawRowIndicator += CustomGridView_CustomDrawRowIndicator;
            FocusedRowChanged += CustomGridView_FocusedRowChanged;
            RowCountChanged += CustomGridView_RowCountChanged;
            RowStyle += CustomGridView_RowStyle;


            InvalidRowException += CustomGridView_InvalidRowException;
            ValidateRow += CustomGridView_ValidateRow;
            InitNewRow += CustomGridView_InitNewRow;
            ValidatingEditor += CustomGridView_ValidatingEditor;


            RowDeleting += CustomGridView_RowDeleting;

            EndInit();
        }


        public bool UseAutoLog { get; set; }

        void CustomGridView_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            if (UseAutoLog == false) return;

            var f = GridControl.FindForm() as FrmBase;
            if (f == null) return;

            f.AddDeleleInfoLog(e.Row);
        }

        void CustomGridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (string.IsNullOrEmpty(NotNullColumns)) return;

            if (NotNullColumns.Contains(FocusedColumn.FieldName))
            {
                var x = GetColumnError(FocusedColumn);
                var v = e.Value==null?string.Empty: e.Value.ToString();
                if (!string.IsNullOrEmpty(x) && !string.IsNullOrEmpty(v))
                    SetColumnError(FocusedColumn, string.Empty);
            }
        }


        public bool UseAutoCode { get; set; }
        public bool ShowIndexIndicator { get; set; }

        public string FormatCode { get; set; }

        void CustomGridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var row = GetFocusedDataRow();
            if (row == null) return;
            var keys = row.Table.PrimaryKey;

            string ma = string.Empty;
            if (UseAutoCode)
            {
                string tenBang = row.Table.TableName;
               
                if (keys.Length > 0)
                {
                    string khoa = keys[0].ColumnName;

                    if (FormatCode == string.Empty)
                    {
                        FormatCode = "{0:d4}";
                    }

                    ma = DinhDangMa.LayMaTuDong(tenBang, khoa, FormatCode, row.Table);
                    row[khoa] = ma;
              
                }

                PostEditor();
            }
            if (string.IsNullOrEmpty(ma))
            {
                foreach (DataColumn col in keys)
                    if (row.IsNull(col))
                        SetColumnError(Columns[col.ColumnName], col.Caption + " không được trống", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }

        }



        void CustomGridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            var row = GetFocusedDataRow();
            if (row == null) return;

            var keys = row.Table.PrimaryKey;
            foreach (DataColumn col in keys)
            {
                if (row.IsNull(col))
                {
                    e.ErrorText = col.Caption + " không được trống";
                    SetColumnError(Columns[col.ColumnName], e.ErrorText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                   
                    e.Valid = false;
                }
            }

            if (string.IsNullOrEmpty(NotNullColumns)) return;

            string[] notNullCols = NotNullColumns.Replace(" ", string.Empty).Split(';');
            foreach (string s in notNullCols)
            {
                if (!row.Table.Columns.Contains(s)) continue;

                if (row.IsNull(s) || row[s].Equals(string.Empty) || row[s].Equals(DBNull.Value))
                {
                    e.ErrorText = "Không được trống";
                    SetColumnError(Columns[s], e.ErrorText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);

                    e.Valid = false;
                }
            }
        }

        void CustomGridView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            // Hiển thị icon lỗi trên lưới theo dạng lỗi.

            if (e.ErrorText == "Không được trống") return;

            if (e.ErrorText.Contains("constrained to be unique"))
                e.ErrorText = "Dữ liệu không được trùng";
            else if (e.ErrorText.Contains("MaxLength limit"))
                e.ErrorText = "Dữ liệu không được vướt quá giới hạn";
            else if (e.ErrorText.Contains("does not allow nulls"))
                e.ErrorText = "Không được trống";

          
            SetColumnError(FocusedColumn, e.ErrorText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);

        }


        void CustomGridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle == -999997) // dòng filter
            {
                //e.Appearance.BackColor = Color.Moccasin;
                e.Appearance.BackColor = Color.LightCyan;
                e.Appearance.Options.UseBackColor = true;
                return;
            }
            else if (e.RowHandle == -2147483647) // dong new row
            {
                e.Appearance.BackColor = Color.Honeydew;
                e.Appearance.Options.UseBackColor = true;
            }
        }





        public void CopyNewRow()
        {
            try
            {
                var dt = DataSource as DataView;
                if (dt != null)
                {
                    var row = GetFocusedDataRow();
                    if (row == null) return;
                    var r = dt.AddNew();
                    r.Row.ItemArray = row.ItemArray;

                   // dt.Table.Rows.Add(r);

                }
            }
            catch { }

        }









        [DefaultValue(25)]
        public override int IndicatorWidth
        {
            get { return base.IndicatorWidth; }
            set { base.IndicatorWidth = value; }
        }

        /// <summary>
        ///     FieldName của cột Khóa, có tác dụng không cho sửa dữ liệu đã nhập của cột đó
        /// </summary>
        [Description("FieldName của cột Khóa, có tác dụng không cho sửa dữ liệu đã nhập của cột đó")]
        public string KeyColumn { get; set; }


        [Description("FieldName của các cột Notnull, có tác dụng kiểm tra dữ liệu null. (col1; col2; col3)")]
        public string NotNullColumns { get; set; }

        protected override string ViewName
        {
            get { return "CustomGridView"; }
        }

        protected override ColumnViewOptionsView CreateOptionsView()
        {
            return new MyOptionsView();
            
        }

        protected override ColumnViewOptionsSelection CreateOptionsSelection()
        {
            return new MyOptionsSelection();
        }

        private void CustomGridView_RowCountChanged(object sender, EventArgs e)
        {
            if (ShowIndexIndicator)
            {
                var n = RowCount.ToString().Length;
                IndicatorWidth = 25 + n * 6;
            }
        }

        private void CustomGridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;

            try
            {
                var colKey = view.Columns[KeyColumn];
                if (colKey != null)
                {
                    var row = view.GetFocusedDataRow();
                    if (row == null)
                        colKey.OptionsColumn.AllowEdit = true;
                    else
                        colKey.OptionsColumn.AllowEdit = (row.RowState == System.Data.DataRowState.Added 
                            || row.RowState == DataRowState.Detached);
                }
            }
            catch { }
        }

        private void CustomGridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (ShowIndexIndicator)
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        public bool HasError()
        {
            for (var i = 0; i < RowCount; i++)
                foreach (GridColumn col in Columns)
                    if (GetColumnError(i, col) != string.Empty
                        ||  GetColumnErrorType(i, col) == DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)
                        return true;

            return false;
        }
    }

    public class MyOptionsView : GridOptionsView
    {
        public MyOptionsView()
        {
            base.ShowGroupPanel = false;
            base.NewItemRowPosition = NewItemRowPosition.Bottom;
            base.ShowAutoFilterRow = true;
            //base.ShowFooter = true;
            base.EnableAppearanceEvenRow = true;
        }

        [DefaultValue(NewItemRowPosition.Bottom)]
        public override NewItemRowPosition NewItemRowPosition
        {
            get { return base.NewItemRowPosition; }
            set { base.NewItemRowPosition = value; }
        }

        [DefaultValue(false)]
        public override bool ShowGroupPanel
        {
            get { return base.ShowGroupPanel; }
            set { base.ShowGroupPanel = value; }
        }

        [DefaultValue(true)]
        public override bool ShowAutoFilterRow
        {
            get { return base.ShowAutoFilterRow; }
            set { base.ShowAutoFilterRow = value; }
        }

        [DefaultValue(false)]
        public override bool ColumnAutoWidth { get; set; }

        [DefaultValue(true)]
        public override bool EnableAppearanceEvenRow
        {
            get
            {
                return base.EnableAppearanceEvenRow;
            }
            set
            {
                base.EnableAppearanceEvenRow = value;
            }
        }

      

        //[DefaultValue(true)]
        //public override bool ShowFooter { get; set; }
    }


    public class MyOptionsSelection : GridOptionsSelection
    {
        public MyOptionsSelection()
        {
            base.MultiSelect = true;
        }
        [DefaultValue (true)]
        public override bool MultiSelect
        {
            get
            {
                return base.MultiSelect;
            }
            set
            {
                base.MultiSelect = value;
            }
        }
    }

    public class CustomGridViewInfoRegistrator : GridInfoRegistrator
    {
        public override string ViewName
        {
            get { return "CustomGridView"; }
        }

        public override BaseView CreateView(GridControl grid)
        {
            return new CustomGridView(grid);
        }
    }
}