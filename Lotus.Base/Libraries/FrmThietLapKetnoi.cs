using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Lotus.Libraries
{
    public partial class FrmThietLapKetnoi : XtraForm
    {
        public FrmThietLapKetnoi()
        {
            InitializeComponent();
            string s = AppConfig.GetConnectionString(HeThong.AppConfigConnectionStringName);

            string chuoiKetnoi = s;

            if(HeThong.MaHoaChuoiKetNoi)
                chuoiKetnoi = LotusEncoding.Descrypt(s, "nh@ntr@n");


            var connStringBuilder = new SqlConnectionStringBuilder(chuoiKetnoi);

            txtMayChu.Text = connStringBuilder.DataSource;
            txtTenDangNhap.Text = connStringBuilder.UserID;
            txtMatKhau.Text = connStringBuilder.Password;
            txtCSDL.Text = connStringBuilder.InitialCatalog;

            cboCheDo.SelectedIndex = 1;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (SqlConnector.Ketnoi(txtMayChu.Text, txtTenDangNhap.Text, txtMatKhau.Text, txtCSDL.Text, cboCheDo.SelectedIndex))
            {

                MsgBox.ShowSuccessfulDialog("Kết nối thành công, chương trình sẽ khởi động lại");
                string sconn = SqlConnector.ChuoiKetNoi;

                if (HeThong.MaHoaChuoiKetNoi)
                    sconn = LotusEncoding.Encrypt(SqlConnector.ChuoiKetNoi, "nh@ntr@n");

                AppConfig.SetConnectionString(sconn, HeThong.AppConfigConnectionStringName);


                var s = Application.ExecutablePath;
                SingleInstance.Stop();
                Application.ExitThread();

                Process.Start(s, "reset");

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
                XtraMessageBox.Show("Không thể lưu kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            bool b = SqlConnector.Ketnoi(txtMayChu.Text, txtTenDangNhap.Text, txtMatKhau.Text, txtCSDL.Text, cboCheDo.SelectedIndex);
            if (b)
            {
                MsgBox.ShowSuccessfulDialog("Kết nối thành công");
            }
        }

        private void cboCheDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCheDo.SelectedIndex == 0)
            {
                txtTenDangNhap.Enabled = false;
                txtMatKhau.Enabled = false;
            }
            else if (cboCheDo.SelectedIndex == 1)
            {
                txtTenDangNhap.Enabled = true;
                txtMatKhau.Enabled = true;
            }
        }
    }
}
