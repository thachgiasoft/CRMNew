using System;
using System.Diagnostics;
using DevExpress.XtraEditors;

namespace Lotus.AutoUpdate
{
    public partial class FrmMain : XtraForm
    {
        public FrmMain()
        {
            InitializeComponent();

            lblCurrentVersion.Text = Repository.AppVersion.ToString();

            if (Repository.Instance != null)
            {
                lblNewVersion.Text = Repository.Instance.XmlVersion.ToString();
                lblDateRelease.Text = Repository.Instance.NgayCapNhat.ToString("dd/MM/yyyy");
                lblSizeRelease.Text = Repository.Instance.KichThuocFile;
                lblTenUngDung.Text = Repository.Instance.AppName;
                txtInfo.Text = Repository.Instance.GhiChu.Replace("\n", Environment.NewLine);
            }
        }

        private void lblViewOnline_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.phanmemhoasen.com/");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FileHelper.CancelDownload();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;

            KillHost();

            // DOWNLOAD FILE.
            FileHelper.Download(progressBarTotal);
        }

        private static void KillHost()
        {
            var ps = Process.GetProcessesByName(Repository.AppCode);
            if (ps.Length == 0) return;
            foreach (var process in ps)
                process.Kill();
        }
    }
}