using System.Drawing;
using System.Drawing.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports.UI;
using Lotus.Libraries;
using System.Windows.Forms;
using System.IO;
using System;

namespace Lotus.Base
{
    public partial class LotusReport : XtraReport
    {
        public LotusReport()
        {
            InitializeComponent();
        }

        public void ShowPreview()
        {
            this.ShowPreviewDialog();
        }
      
        public void Print()
        {
            this.PrintDialog();
        }

        public void ShowDesigner()
        {
            MsgBox.ShowWaitForm();
            LoadLayout();
            this.ShowDesignerDialog();
            MsgBox.CloseWaitForm();
        }
        public virtual void LoadLayout()
        {
            try
            {
                string dir = Application.StartupPath + "/Reports";
                string file = string.Format("{0}/{1}.repx", dir, Name);

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                if (!File.Exists(file))
                    this.SaveLayout(file);

                this.LoadLayout(file);
              
            }
            catch (Exception ex)
            {
                MsgBox.ShowErrorDialog(ex.Message);
            }

        }

       
    }
}