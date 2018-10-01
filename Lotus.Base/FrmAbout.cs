using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Lotus.Libraries;


namespace Lotus.Base
{
    public partial class FrmAbout : XtraForm
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            lblVersion.Text = string.Format("Phiên bản: v{0}", Application.ProductVersion);
        }

       

        private void lblCopyright_MouseHover(object sender, EventArgs e)
        {
            lblCopyright.ForeColor = Color.Aquamarine;
        }

        private void lblCopyright_MouseLeave(object sender, EventArgs e)
        {
            lblCopyright.ForeColor = Color.White;
        }

        private void lbFace_Click(object sender, EventArgs e)
        {
            Process.Start(lbFace.Text);
        }

       
    }
}