using DevExpress.Skins;
using DevExpress.Skins.Info;
using DevExpress.XtraBars.Docking2010.Customization;
using Lotus;
using Lotus.Base;
using Lotus.Libraries;
using Lotus.License;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace CRM
{
    static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            HeThong.HostUpdate = CRM.Properties.Settings.Default.RemoteUri;
            HeThong.CapNhatOnline();




            // CHỈ CHẠY 1 LẦN DUY NHẤT
            if (!SingleInstance.Start() && args.Length == 0)
            {
                SingleInstance.ShowFirstInstance();
                return;
            }

            Application.ThreadException += Application_ThreadException;
            MsgBox.ShowSplashForm("Đang nạp giao diện ...");
            DevExpress.UserSkins.BonusSkins.Register();
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();
            HeThong.AddCustomSkin();
            // VIỆT HÓA
      
            //HeThong.DaNgonNgu = true;
            HeThong.MaHoaChuoiKetNoi = true;

         




            HeThong.DaDangKy = BanQuyen.Initalize();
            if (HeThong.DaDangKy == false) return; // khong cho xài hay sao?



            MsgBox.ShowSplashForm();
            // day là cái tên conn string của chuong trình chính (app config)
            HeThong.AppConfigConnectionStringName = "CRM.Properties.Settings.CRMConnString";

            if (HeThong.KetNoi() == false)
            {
                SingleInstance.Stop();
                return;
            }
            // must have after connect, giã mã và chuoi ket nối, gán lại vào bộ nhớ
            CRM.Properties.Settings.Default["CRMConnString"] = SqlConnector.ChuoiKetNoi;
            LanguageHelper.Active();

            MsgBox.ShowSplashForm("Đang khởi tạo hệ thống ...");
            InitData();
            MsgBox.ShowSplashForm("Nạp định dạng ...");
            HeThong.NapDinhDang();
            MsgBox.ShowSplashForm("Quá trình hoàn tất.");


           

           


            MsgBox.CloseWaitForm();


            Application.Run(new FrmCRMMain());
            SingleInstance.Stop();
        }


        private static void InitData()
        {
            Utils.SinhLichHenBaoSinhNhatKH();
        }


        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs ex)
        {
            string err = ex.Exception.Message;
            if (err.Contains("error has occurred when receiving results from the server")
                || ex.Exception.Message.Contains("Could not open a connection"))
                MsgBox.ShowErrorDialog("Không kết nối được cơ sở dữ liệu");

            else
            {
                MsgBox.ShowErrorDialog("Lỗi chưa xử lý.\n" + err, false);
            }


            string msg = string.Format("{0:dd/MM/yyyy HH:mm:ss}\t{1}", DateTime.Now, err);
            File.AppendAllText(Application.StartupPath + "\\log.txt", msg);
        }


    }
}
