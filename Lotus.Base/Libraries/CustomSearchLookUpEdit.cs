using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using System.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors;
using System.ComponentModel;
using DevExpress.XtraEditors.Popup;
using System.Reflection;


namespace Lotus.Base.Libraries
{

    [ToolboxItem(true)]
    public class CustomSearchLookUpEdit : SearchLookUpEdit
    {
        static CustomSearchLookUpEdit() { RepositoryItemCustomSearchLookUpEdit.RegisterCustomEdit(); }

        public CustomSearchLookUpEdit() { }

        public override string EditorTypeName
        {
            get
            {
                return RepositoryItemCustomSearchLookUpEdit.CustomEditName;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomSearchLookUpEdit Properties
        {
            get { return base.Properties as RepositoryItemCustomSearchLookUpEdit; }
        }

        protected override DevExpress.XtraEditors.Popup.PopupBaseForm CreatePopupForm()
        {
            return new CustomPopupSearchLookUpEditForm(this);
        }

        public event UpdateDisplayFilterHandler UpdateDisplayFilter
        {
            add { this.Properties.UpdateDisplayFilter += value; }
            remove { this.Properties.UpdateDisplayFilter -= value; }
        }
    }

    public class CustomPopupSearchLookUpEditForm : PopupSearchLookUpEditForm
    {
        public CustomPopupSearchLookUpEditForm(SearchLookUpEdit edit) : base(edit) { }

         

        protected override void UpdateDisplayFilter(string displayFilter)
        {
            DisplayFilterEventArgs args = new DisplayFilterEventArgs(displayFilter);
            Properties.RaiseUpdateDisplayFilter(args);
            base.UpdateDisplayFilter(args.FilterText);
        }

        public new RepositoryItemCustomSearchLookUpEdit Properties
        {
            get { return base.Properties as RepositoryItemCustomSearchLookUpEdit; }
        }
    }

    [UserRepositoryItem("RegisterCustomEdit")]
    public class RepositoryItemCustomSearchLookUpEdit : RepositoryItemSearchLookUpEdit
    {
        static readonly object _updateDisplayFilter = new object();

        static RepositoryItemCustomSearchLookUpEdit() { RegisterCustomEdit(); }

        public RepositoryItemCustomSearchLookUpEdit() { }

        public const string CustomEditName = "CustomSearchLookUpEdit";

        public override string EditorTypeName { get { return CustomEditName; } }

        public static void RegisterCustomEdit()
        {
            Image img = null;
            try
            {
                img = (Bitmap)Bitmap.FromStream(Assembly.GetExecutingAssembly().
                  GetManifestResourceStream("DevExpress.CustomEditors.CustomEdit.bmp"));
            }
            catch
            {
            }
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName,
              typeof(CustomSearchLookUpEdit), typeof(RepositoryItemCustomSearchLookUpEdit),
              typeof(SearchLookUpEditBaseViewInfo), new ButtonEditPainter(), true, img));
        }

        public event UpdateDisplayFilterHandler UpdateDisplayFilter
        {
            add { this.Events.AddHandler(_updateDisplayFilter, value); }
            remove { this.Events.RemoveHandler(_updateDisplayFilter, value); }
        }

        protected internal virtual void RaiseUpdateDisplayFilter(DisplayFilterEventArgs e)
        {
            UpdateDisplayFilterHandler handler = (UpdateDisplayFilterHandler)Events[_updateDisplayFilter];
            if (handler != null) handler(GetEventSender(), e);
        }

        public override void Assign(RepositoryItem item)
        {
            base.Assign(item);
            RepositoryItemCustomSearchLookUpEdit source = item as RepositoryItemCustomSearchLookUpEdit;
            Events.AddHandler(_updateDisplayFilter, source.Events[_updateDisplayFilter]);
        }
    }


    public delegate void UpdateDisplayFilterHandler(object sender, DisplayFilterEventArgs e);
    public class DisplayFilterEventArgs : EventArgs
    {
        string filterText;
        public DisplayFilterEventArgs(string filterText)
        {
            this.filterText = filterText;
        }
        public string FilterText
        {
            get { return filterText; }
            set
            {
                if (filterText != value)
                    filterText = value;
            }
        }
    }
}
