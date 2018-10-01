using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using DevExpress.Xpo;
using Lotus.Base.DATATableAdapters;


namespace Lotus.Base.Systems
{
    public partial class FrmDoiMatKhau : FrmBase
    {
        DATA.NguoiDungRow _nguoidung;
        public FrmDoiMatKhau(DATA.NguoiDungRow nguoidung)
        {
            InitializeComponent();
            UseEnableControl = false;

            _nguoidung = nguoidung;

            txtTenDangNhap.Binding(_nguoidung, "TenDangNhap");

            dxErrorProvider1.DataSource = _nguoidung;
        }


        protected override bool OnSave()
        {
            layoutControl1.Validate();
           
            //if (!txtMatKhauMoi.Text.Equals(txtXacNhan.Text))
            //{
            //    txtXacNhan.ErrorText = "Xác nhận mật mới khẩu không khớp";
            //    return false;
            //}
            //try
            //{
            //    _nguoidung.MatKhau = txtMatKhauMoi.Text;

            //    var ad = new NguoiDungTableAdapter();
            //    ad.Update(_nguoidung);
            //    ShowAlert("Đã thay đổi mật khẩu");
            //    ad.Dispose();
            //    this.Close();
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    MsgBox.ShowErrorDialog(ex.Message);
            //    return false;
            //}

            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                txtMatKhau.ErrorText = "Mật khẩu không hợp lệ";
                return false;
            }
            else if (_nguoidung.MatKhau != HeThong.MaHoaMD5(txtMatKhau.Text))
            {
                txtMatKhau.ErrorText = "Mật khẩu không hợp lệ";
                return false;
            }



            if (!txtMatKhauMoi.Text.Equals(txtXacNhan.Text))
            {
                txtXacNhan.ErrorText = "Xác nhận mật mới khẩu không khớp";
                return false;
            }
            try
            {
                _nguoidung.MatKhau = HeThong.MaHoaMD5(txtMatKhauMoi.Text);

                var ad = new NguoiDungTableAdapter();
                ad.Update(_nguoidung);
                ad.Dispose();
                this.Close();
                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowErrorDialog(ex.Message);
                return false;
            }
        }

        private void txtMatKhau_KeyUp(object sender, KeyEventArgs e)
        {
            txtMatKhauMoi.Enabled =
               txtXacNhan.Enabled = _nguoidung.MatKhau == HeThong.MaHoaMD5(txtMatKhau.Text);
        }

        private void txtXacNhan_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                OnSave();
        }

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {
            LockControls(false);
        }
    }
}
