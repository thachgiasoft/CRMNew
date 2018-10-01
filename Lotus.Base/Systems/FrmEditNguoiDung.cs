using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using DevExpress.Xpo;
using Lotus.Libraries;

namespace Lotus.Base.Systems
{
    public partial class FrmEditNguoiDung : FrmBase
    {
        DATA.NguoiDungRow _nguoidung;

        public FrmEditNguoiDung(DATA.NguoiDungRow nguoidung)
        {
            InitializeComponent();

            cboChucDanh.Properties.Items.AddEnum(typeof(ChucDanh), true);
            this.phongBanTableAdapter.Fill(this.dATA.PhongBan);

            UseEnableControl = false;

            _nguoidung = nguoidung;
       

            txtTenDangNhap.Binding(_nguoidung, "TenDangNhap");
            txtHoTen.Binding(_nguoidung, "HoTen");
            cboChucDanh.Binding(_nguoidung, "Loai");
            lkePhong.Binding(_nguoidung, "Phong");
          
            dxErrorProvider1.DataSource = _nguoidung;
            txtTenDangNhap.Enabled = _nguoidung.RowState != DataRowState.Unchanged;

            if(string.IsNullOrEmpty(_nguoidung.TenDangNhap))
            {
                txtTenDangNhap.ErrorText = "Tên đăng nhập không được trống";
            }
        }



        protected override bool OnSave()
        {
            layoutControl1.Validate();

            if (dxErrorProvider1.HasErrors) return false;
            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                txtTenDangNhap.ErrorText = "Tên đăng nhập không được trống";
                return false;
            }

            if ((_nguoidung.RowState == DataRowState.Added || _nguoidung.RowState == DataRowState.Detached)
                && HeThong.Exits("NguoiDung", "TenDangNhap", txtTenDangNhap.Text))
            {
                txtTenDangNhap.ErrorText = "Tên đăng nhập đã tồn tại";
                return false;
            }

            try
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowErrorDialog(ex.Message);
                return false;
            }


        }

        private void FrmNguoiDung_Load(object sender, EventArgs e)
        {            
            LockControls(false);
        }
    }
}
