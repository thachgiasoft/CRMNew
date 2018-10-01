using System;
using DevExpress.XtraSplashScreen;

namespace Lotus.Libraries
{
    public partial class FrmSplash : SplashScreen
    {
        public enum SplashScreenCommand
        {
        }

        public FrmSplash()
        {
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            lblDescription.Text = arg as string;
            base.ProcessCommand(cmd, arg);
        }

        #endregion

      
    
        
    }
}