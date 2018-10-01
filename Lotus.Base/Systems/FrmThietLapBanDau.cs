using DevExpress.Xpo;
using DevExpress.XtraEditors;
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
    public partial class FrmThietLapBanDau : XtraForm
    {
       
        public FrmThietLapBanDau()
        {
            InitializeComponent();
           
        }

        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
         
            TaoNguoiDung();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void TaoNguoiDung()
        {
            var ad = new DATATableAdapters.NguoiDungTableAdapter();
            ad.Insert(txtTenDangNhap.Text, HeThong.MaHoaMD5(txtMatKhau.Text), "", true, 0, null);
        }


       

        private void wizardControl1_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (e.Page == pageNguoiDung)
            {
                if (string.IsNullOrEmpty(txtTenDangNhap.Text))
                {
                    txtTenDangNhap.ErrorText = "Nhập tên đăng nhập";
                    e.Handled = true;
                }
                if (string.IsNullOrEmpty(txtMatKhau.Text))
                {
                    txtMatKhau.ErrorText = "Mật khẩu quản trị không được trống";
                    e.Handled = true;
                }
                else if (!txtMatKhau.Text.Equals(txtXacNhan.Text))
                {
                    txtXacNhan.ErrorText = "Xác nhận mật khẩu không trùng khớp";
                    e.Handled = true;
                }
            }
        }

        private void wizardControl1_CancelClick(object sender, CancelEventArgs e)
        {
            var x = MsgBox.ShowYesNoDialog("Bạn có chắc muốn thoát thiết lập hệ thống?");
            if (x == System.Windows.Forms.DialogResult.Yes)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                Close();
            }
        }


      
    }
}
