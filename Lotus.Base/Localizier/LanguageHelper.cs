using DevExpress.XtraBars;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout;
using DevExpress.XtraPrinting.Localization;
using DevExpress.XtraReports.UI;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Lotus.Base
{

    public enum LanguageEnum
    {
        [System.ComponentModel.Description("Tiếng Việt")]
        Vietnam = 0,
        [System.ComponentModel.Description("Laos")]
        Laos = 1
        // them nhung ngon ngu khac ...
    }

    public static class LanguageHelper
    {
        const string TBNAME_GridLocalizer = "GridLocalizer";
        const string TBNAME_Localizer = "Localizer";
        const string TBNAME_PreviewLocalizer = "PreviewLocalizer";
        const string TBNAME_BarLocalizer = "BarLocalizer";


        const string TBNAME_LANGUAGE = "Language";

        static string path = Application.StartupPath + "\\Language";
        public static DataSet DSLang = new DataSet();
        public static LanguageEnum Language;

        public static void Active()
        {
            if (HeThong.DaNgonNgu == false)
            {
                HeThong.VietHoa();
                return;
            }

            string langcode = Param.GetValue<int>("Ngôn ngữ", "Hệ thống", 0).ToString();
            var l = (LanguageEnum)Enum.Parse(typeof(LanguageEnum), langcode);
            Active(l);
        }
        public static void Active(string langcode)
        {
            var l = (LanguageEnum)Enum.Parse(typeof(LanguageEnum), langcode);
            Active(l);
        }
        public static void Active(LanguageEnum lang)
        {
            if (HeThong.DaNgonNgu == false)
            {
                HeThong.VietHoa();
                return;
            }

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            Language = lang;
            DSLang.Tables.Clear();

            DataSet ds = new DataSet();
            string fGridLocalizer = string.Format("{0}\\{1}.xml", path, TBNAME_GridLocalizer);
            if (!File.Exists(fGridLocalizer))
                GridLocalizer.Active.WriteToXml(fGridLocalizer);
            ds.ReadXml(fGridLocalizer);
            ds.Tables[0].TableName = TBNAME_GridLocalizer;
            if (!DSLang.Tables.Contains(ds.Tables[0].TableName))
                DSLang.Tables.Add(ds.Tables[0].Copy());
            DSLang.Tables[TBNAME_GridLocalizer].PrimaryKey = new DataColumn[] { DSLang.Tables[TBNAME_GridLocalizer].Columns["name"] };
            if (!DSLang.Tables[TBNAME_GridLocalizer].Columns.Contains(lang.ToString()))
                DSLang.Tables[TBNAME_GridLocalizer].Columns.Add(lang.ToString());


            ds.Tables.Clear();
            string fLocalizer = string.Format("{0}\\{1}.xml", path, TBNAME_Localizer);
            if (!File.Exists(fLocalizer))
                Localizer.Active.WriteToXml(fLocalizer);
            ds.ReadXml(fLocalizer);
            ds.Tables[0].TableName = TBNAME_Localizer;
            if (!DSLang.Tables.Contains(TBNAME_Localizer))
                DSLang.Tables.Add(ds.Tables[0].Copy());
            DSLang.Tables[TBNAME_Localizer].PrimaryKey = new DataColumn[] { DSLang.Tables[TBNAME_Localizer].Columns["name"] };
            if (!DSLang.Tables[TBNAME_Localizer].Columns.Contains(lang.ToString()))
                DSLang.Tables[TBNAME_Localizer].Columns.Add(lang.ToString());

            // copy, doi ten
            ds.Tables.Clear();
            string fPreviewLocalizer = string.Format("{0}\\{1}.xml", path, TBNAME_PreviewLocalizer);
            if (!File.Exists(fPreviewLocalizer))
                PreviewLocalizer.Active.WriteToXml(fPreviewLocalizer);
            ds.ReadXml(fPreviewLocalizer);
            ds.Tables[0].TableName = TBNAME_PreviewLocalizer;
            if (!DSLang.Tables.Contains(TBNAME_PreviewLocalizer))
                DSLang.Tables.Add(ds.Tables[0].Copy());
            DSLang.Tables[TBNAME_PreviewLocalizer].PrimaryKey = new DataColumn[] { DSLang.Tables[TBNAME_PreviewLocalizer].Columns["name"] };
            if (!DSLang.Tables[TBNAME_PreviewLocalizer].Columns.Contains(lang.ToString()))
                DSLang.Tables[TBNAME_PreviewLocalizer].Columns.Add(lang.ToString());
            // end copy

            // copy, doi ten
            ds.Tables.Clear();
            string fBarLocalizer = string.Format("{0}\\{1}.xml", path, TBNAME_BarLocalizer);
            if (!File.Exists(fBarLocalizer))
                BarLocalizer.Active.WriteToXml(fBarLocalizer);
            ds.ReadXml(fBarLocalizer);
            ds.Tables[0].TableName = TBNAME_BarLocalizer;
            if (!DSLang.Tables.Contains(TBNAME_BarLocalizer))
                DSLang.Tables.Add(ds.Tables[0].Copy());
            DSLang.Tables[TBNAME_BarLocalizer].PrimaryKey = new DataColumn[] { DSLang.Tables[TBNAME_BarLocalizer].Columns["name"] };
            if (!DSLang.Tables[TBNAME_BarLocalizer].Columns.Contains(lang.ToString()))
                DSLang.Tables[TBNAME_BarLocalizer].Columns.Add(lang.ToString());
            // end copy

            // them class khac






            // BANG NGON NGU CHUONG TRINH
            ds.Tables.Clear();
            string fLang = string.Format("{0}\\{1}.xml", path, TBNAME_LANGUAGE);
            if (!File.Exists(fLang))
            {
                DataSet dsLang = new DataSet();
                dsLang.Tables.Add(TBNAME_LANGUAGE);
                dsLang.Tables[TBNAME_LANGUAGE].Columns.Add("name");
                dsLang.Tables[TBNAME_LANGUAGE].Columns.Add("value");
                dsLang.WriteXmlSchema(fLang);
            }
            ds.ReadXml(fLang);
            ds.Tables[0].TableName = TBNAME_LANGUAGE;
            if (!DSLang.Tables.Contains(TBNAME_LANGUAGE))
                DSLang.Tables.Add(ds.Tables[0].Copy());
            DSLang.Tables[TBNAME_LANGUAGE].PrimaryKey = new DataColumn[] { DSLang.Tables[TBNAME_LANGUAGE].Columns["name"] };
            if (!DSLang.Tables[TBNAME_LANGUAGE].Columns.Contains(lang.ToString()))
                DSLang.Tables[TBNAME_LANGUAGE].Columns.Add(lang.ToString());
          


            DSLang.AcceptChanges();
            GridLocalizer.Active = new VNGridLocalizer();
            Localizer.Active = new VNLocalizer();
            PreviewLocalizer.Active = new VNPreviewLocalizer();
            BarLocalizer.Active = new VNBarLocalizer();
            // active khac


            var fMain = Application.OpenForms[0] as FrmMain;
            if (fMain != null)
                fMain.ChangeLanguage(lang);

        }

        public static DataTable GetTableByName(string name)
        {
            return DSLang.Tables[name];
        }

        public static DataTable DTGridLocalizer
        {
            get { return DSLang.Tables[TBNAME_GridLocalizer]; }
        }
        public static DataTable DTLocalizer
        {
            get { return DSLang.Tables[TBNAME_Localizer]; }
        }
        public static DataTable DTPreviewLocalizer
        {
            get { return DSLang.Tables[TBNAME_PreviewLocalizer]; }
        }
        public static DataTable DTBarLocalizer
        {
            get { return DSLang.Tables[TBNAME_BarLocalizer]; }
        }


        public static DataTable DTLanguage
        {
            get { return DSLang.Tables[TBNAME_LANGUAGE]; }
        }

        public static void SaveXML()
        {
            DTGridLocalizer.WriteXml(string.Format("{0}\\{1}.xml", path, TBNAME_GridLocalizer));
            DTLocalizer.WriteXml(string.Format("{0}\\{1}.xml", path, TBNAME_Localizer));
            DTPreviewLocalizer.WriteXml(string.Format("{0}\\{1}.xml", path, TBNAME_PreviewLocalizer));
            DTBarLocalizer.WriteXml(string.Format("{0}\\{1}.xml", path, TBNAME_BarLocalizer));

            DTLanguage.WriteXml(string.Format("{0}\\{1}.xml", path, TBNAME_LANGUAGE));

            DSLang.AcceptChanges();
        }


        public static void ShowTranslateTool()
        {
            var f = new FrmTranslate();
            f.ShowDialog();
        }





        public static void Translate(object control)
        {
            if (HeThong.DaNgonNgu == false) return;

            if (control == null) return;

            if (control is Form)
                TranslateForm(control as Form);
            else if (control is LayoutControl)
                TranslateLayoutControl(control as LayoutControl);
            else if (control is GridControl)
                TranslateGridControl(control as GridControl);
            else if (control is TreeList)
                TranslateTreeListControl(control as TreeList);

            else if (control is XtraReport)
                TranslateReport(control as XtraReport);

            else if (control is RibbonControl)
                TranslateRibbonControl(control as RibbonControl);

            else if (control is BarManager)
                TranslateBarManagerControl(control as BarManager);

            else if (control is BaseButton)
            {
                Control c = control as BaseButton;
                string name = GetFullName(c);
                c.Text = TranslateString(name, c.Text);
            }
            else if (control is TextEdit)
            {
                return;
            }
            else if (control is Control)
            {
                Control c = control as Control;
                string name = GetFullName(c);

                c.Text = TranslateString(name, c.Text);
            }

            if (DTLanguage != null)
            {
                DTLanguage.WriteXml(string.Format("{0}\\{1}.xml", path, TBNAME_LANGUAGE));
                DTLanguage.AcceptChanges();
            }


        }


        private static void TranslateReport(XtraReport xtraReport)
        {
            var list = xtraReport.AllControls<XRControl>();
            foreach (var c in list)
            {
                string name = c.Report.GetType().Name + "." + c.Name;
                c.Text = TranslateString(name, c.Text);
            }
        }

        private static void TranslateBarManagerControl(BarManager barManager)
        {
            foreach (BarItem i in barManager.Items)
            {
                if (i.Caption != string.Empty)
                {
                    var f = barManager.Form.GetType().BaseType.Name;
                    string name = f + "." + i.Name;
                    i.Caption = TranslateString(name, i.Caption);
                }
            }
        }


        private static void TranslateRibbonControl(RibbonControl ribbonControl)
        {
            foreach (RibbonPage page in ribbonControl.Pages)
            {
                string name = ribbonControl.FindForm().Name + "." + ribbonControl.Name + "." + page.Name;
                page.Text = TranslateString(name, page.Text);

                foreach (RibbonPageGroup g in page.Groups)
                {
                    string gname = ribbonControl.FindForm().Name + "." + ribbonControl.Name + "." + page.Name + "." + g.Name;
                    g.Text = TranslateString(gname, g.Text);

                    foreach (BarItemLink i in g.ItemLinks)
                    {

                        string iname = ribbonControl.FindForm().Name + "." + ribbonControl.Name + "." + page.Name + "." + g.Name + "." + i.Item.Name;
                        i.Caption = TranslateString(iname, i.Caption);

                        if (i.Item is BarSubItem)
                        {
                            var sub = i.Item as BarSubItem;

                            foreach (BarItemLink y in sub.ItemLinks)
                            {
                                string name2 = ribbonControl.FindForm().Name + "." + ribbonControl.Name + "." + page.Name + "." + g.Name + "." + i.Item.Name + y.Item.Name;
                                y.Caption = TranslateString(name2, y.Caption);
                            }
                        }
                    }
                }
            }
        }


        private static void TranslateGridControl(GridControl gridControl)
        {
            ColumnView view = gridControl.MainView as ColumnView;
            if (view == null) return;
            foreach (GridColumn c in view.Columns)
            {
                string s = c.GetTextCaption();
                if (s == string.Empty) continue;

                string name = gridControl.FindForm().Name + "." + gridControl.Name + "." + c.Name;
                c.Caption = TranslateString(name, s);
            }
        }


        private static void TranslateTreeListControl(TreeList treeList)
        {
            foreach (TreeListColumn c in treeList.Columns)
            {
                string s = c.GetTextCaption();
                if (s == string.Empty) continue;

                string name = treeList.FindForm().Name + "." + treeList.Name + "." + c.Name;
                c.Caption = TranslateString(name, s);
            }
        }


        private static void TranslateLayoutControl(LayoutControl l)
        {
            foreach (BaseLayoutItem item in l.Items)
            {
                if (item is EmptySpaceItem) continue;
                LayoutControlItem li = item as LayoutControlItem;
                if (li != null)
                    Translate(li.Control);

                if (item.Text.Contains("layoutControlItem")) continue;

                string name = l.FindForm().Name + "." + item.Name;
                item.Text = TranslateString(name, item.Text);
            }
        }

        private static string GetFullName(Control c)
        {
            return c.FindForm().Name + "." + c.Name;
        }

        public static string TranslateString(string name, string defaultValue)
        {
            string s = string.Empty;
            if (LanguageHelper.DTLanguage == null) return string.Empty;

            DataRow res = LanguageHelper.DTLanguage.Rows.Find(name);
            if (res == null)
            {
                res = LanguageHelper.DTLanguage.NewRow();
                res["name"] = name;
                res["value"] = defaultValue;
                LanguageHelper.DTLanguage.Rows.Add(res);
            }
            s = res[LanguageHelper.Language.ToString()].ToString() == string.Empty ? res["value"].ToString()
                : res[LanguageHelper.Language.ToString()].ToString();

            return s;
        }

        public static string TranslateMsgString(string name, string defaultValue)
        {
            string s = string.Empty;
            if (LanguageHelper.DTLanguage == null) return defaultValue;


            name = string.Format("MSG_[{0}]", name);

            DataRow res = LanguageHelper.DTLanguage.Rows.Find(name);
            if (res == null)
            {
                res = LanguageHelper.DTLanguage.NewRow();
                res["name"] = name;
                res["value"] = defaultValue;
                LanguageHelper.DTLanguage.Rows.Add(res);
            }
            s = res[LanguageHelper.Language.ToString()].ToString() == string.Empty ? res["value"].ToString()
                : res[LanguageHelper.Language.ToString()].ToString();

            DTLanguage.WriteXml(string.Format("{0}\\{1}.xml", path, TBNAME_LANGUAGE));
            DTLanguage.AcceptChanges();

            return s;
        }


        private static void TranslateForm(Form form)
        {
            form.Text = TranslateString(form.Name, form.Text);
            
            var list = EnumerateComponents(form);
            var l1 = list.Where(t => !(t is BaseEdit)
                              && ((t is Control) || (t is BarManager))
                              );
                                

            for (int i = 0; i < l1.Count(); i++)
            {
                var c = l1.ElementAt(i);
                Translate(c);
            }
        }


        private static IEnumerable<Component> EnumerateComponents(object form)
        {
            return from field in form.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(Component).IsAssignableFrom(field.FieldType)
                   let component = (Component)field.GetValue(form)
                   where component != null
                   select component;
        }

    }




    public class VNGridLocalizer : GridLocalizer
    {
        public override string GetLocalizedString(GridStringId id)
        {
            string key = string.Format("GridStringId.{0}", id);
            DataRow res = LanguageHelper.DTGridLocalizer.Rows.Find(key);
            if (res == null) return base.GetLocalizedString(id);
            string s = res[LanguageHelper.Language.ToString()].ToString() == string.Empty ? 
                base.GetLocalizedString(id) : res[LanguageHelper.Language.ToString()].ToString();
            return s;
        }
    }
    public class VNLocalizer : Localizer
    {
      
        public override string GetLocalizedString(StringId id)
        {
            string key = string.Format("StringId.{0}", id);
            DataRow res = LanguageHelper.DTLocalizer.Rows.Find(key);
            if (res == null) return base.GetLocalizedString(id);
            string s = res[LanguageHelper.Language.ToString()].ToString() == string.Empty ? 
                base.GetLocalizedString(id) : res[LanguageHelper.Language.ToString()].ToString();
            return s;
        }
    }
    public class VNPreviewLocalizer : PreviewLocalizer
    {
      
        public override string GetLocalizedString(PreviewStringId id)
        {
            string key = string.Format("PreviewStringId.{0}", id);
            DataRow res = LanguageHelper.DTPreviewLocalizer.Rows.Find(key);
            if (res == null) return base.GetLocalizedString(id);
            string s = res[LanguageHelper.Language.ToString()].ToString() == string.Empty ? 
                base.GetLocalizedString(id) : res[LanguageHelper.Language.ToString()].ToString();
            return s;
        }
    }
    public class VNBarLocalizer : BarLocalizer
    {
     
        public override string GetLocalizedString(BarString id)
        {
            string key = string.Format("BarString.{0}", id);
            DataRow res = LanguageHelper.DTBarLocalizer.Rows.Find(key);
            if (res == null) return base.GetLocalizedString(id);
            string s = res[LanguageHelper.Language.ToString()].ToString() == string.Empty ? 
                base.GetLocalizedString(id) : res[LanguageHelper.Language.ToString()].ToString();
            return s;
        }
    }



   
}
