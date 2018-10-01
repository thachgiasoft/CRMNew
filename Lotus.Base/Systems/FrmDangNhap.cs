using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;




namespace Lotus.Base.Systems
{
    public partial class FrmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public FrmDangNhap()
        {
            InitializeComponent();

            LanguageHelper.Translate(this);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (KiemTraDangNhap())
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

       

        private bool KiemTraDangNhap()
        {
            txtMatKhau.ErrorText = string.Empty;
            txtTenDangNhap.ErrorText = string.Empty;

            var obj = HeThong.LayNguoiDungDangNhap(txtTenDangNhap.Text);

            if (obj == null)
            {
                txtTenDangNhap.ErrorText = "Tên đăng nhập không hợp lệ";
                return false;
            }
            else
            {
                if (obj.MatKhau != HeThong.MaHoaMD5(txtMatKhau.Text))
                {
                    txtMatKhau.ErrorText = "Mật khẩu không hợp lệ";
                    return false;
                }

                HeThong.TenDangNhap = txtTenDangNhap.Text;
                HeThong.NguoiDungDangNhap = HeThong.LayNguoiDungDangNhap(HeThong.TenDangNhap);
            
                return true;
            }

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTenDangNhap_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnDangNhap.PerformClick();
        }

        private void txtMatKhau_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnDangNhap.PerformClick();
        }

       

      

      

    }
}