using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Lotus.Libraries
{
    public partial class CustomBox : XtraMessageBoxForm
    {
        public CustomBox()
        {
            InitializeComponent();
        }

        MsgBox.DialogButton[] _buttons;
        public CustomBox(MsgBox.DialogButton[] buttons)
        {
            InitializeComponent();
            _buttons = buttons;
        }

        protected override string GetButtonText(DialogResult target)
        {
            var button = _buttons.FirstOrDefault(b => b.Button == target);
            if (string.IsNullOrEmpty(button.ButtonText)) return base.GetButtonText(target);
            else return button.ButtonText;
        }

      
    }
}
