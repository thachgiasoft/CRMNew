using DevExpress.XtraEditors;
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
    public partial class FrmThongTinNK : XtraForm
    {
        public FrmThongTinNK(object dt)
        {
            InitializeComponent();
            customGridControl1.DataSource = dt;

            if (HeThong.DaNgonNgu)
                LanguageHelper.Translate(this);
        }
    }
}
