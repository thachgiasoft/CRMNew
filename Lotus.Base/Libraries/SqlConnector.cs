using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.Configuration;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using System.Diagnostics;
using Lotus.Base;

namespace Lotus.Libraries
{
    public class SqlConnector
    {
        public static string ChuoiKetNoi { get; set; }

        public static string DBName { get; set; }


        public static bool Ketnoi()
        {
            // show wait form

            // lấy chuỗi kết nối trong file app config
          
            string s = AppConfig.GetConnectionString(HeThong.AppConfigConnectionStringName);
            SqlConnection conn = null;
            // thử kết nối CSDL, nếu thành công thì gán ChuoiKetNoi -> sau này dùng
            try
            {
                string chuoiKetnoi = s;
                if (HeThong.MaHoaChuoiKetNoi)
                    chuoiKetnoi = LotusEncoding.Descrypt(s, "nh@ntr@n");

                conn = new SqlConnection(chuoiKetnoi);
                conn.Open();
                ChuoiKetNoi = chuoiKetnoi;
                SQLHelper.Connectionstring = chuoiKetnoi;
                Lotus.Libraries.Settings.Default.ConnectionString = chuoiKetnoi;

                HeThong.ConnectionString = chuoiKetnoi;

                var connStringBuilder = new SqlConnectionStringBuilder(chuoiKetnoi);
                DBName = connStringBuilder.InitialCatalog;
            }
            catch (Exception ex)
            {
                FrmThietLapKetnoi f = new FrmThietLapKetnoi();
                if (HeThong.DaNgonNgu)
                    LanguageHelper.Translate(f);
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    return true;

                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return true;
        }



        public static bool Ketnoi(string maychu, string tendangnhap, string matkhau, string csdl, int cheDo)
        {
            string chuoiKetnoi = string.Empty;
            if (cheDo == 0)
                chuoiKetnoi = string.Format("Server={0};Database={1};Trusted_Connection=True;", maychu, csdl);
            else if (cheDo == 1)
                chuoiKetnoi = string.Format("Server={0};Database={1};User Id={2};Password={3};", maychu, csdl, tendangnhap, matkhau);

            // thử kết nối CSDL, nếu thành công thì gán ChuoiKetNoi -> sau này dùng
            SqlConnection conn = new SqlConnection(chuoiKetnoi);
            try
            {
                conn.Open();
                ChuoiKetNoi = chuoiKetnoi;
                SQLHelper.Connectionstring = chuoiKetnoi;
            }
            catch (Exception ex)
            {
                MsgBox.ShowErrorDialog(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }



        public static void SaoLuu()
        {
            string csdl = SqlConnector.DBName;
            // Kiểm tra chưa chọn đường dẫn.
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Backup file (*.bak)|*.bak|All files (*.*)|*.*";
            var result = dlg.ShowDialog();
            if (result != DialogResult.OK) return;

            if (string.IsNullOrEmpty(dlg.FileName)) return;


            // Ẩn form chính và hiển thị form chờ
             MsgBox.ShowWaitForm();

            try
            {
                string sqlBackup = "BACKUP DATABASE [" + csdl + "] TO DISK = '" + dlg.FileName + "' WITH INIT , NOUNLOAD , name = 'BKdb' , NOSKIP , STATS = 10 , Description = 'BKdb' , NOFORMAT ";

                // Thực thi câu lệnh backup database.
                SQLHelper.ExecuteNonQuery(sqlBackup);

                // Tắt form chờ và hiển thị lại form chính.

                MsgBox.CloseWaitForm();
                MsgBox.ShowSuccessfulDialog("Sao lưu thành công!");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);

                MsgBox.CloseWaitForm();
                MsgBox.ShowWarningDialog("Sao lưu không thành công");
            }
        }

        public static void PhucHoi()
        {
            string csdl = SqlConnector.DBName;

            var questionDlg = XtraMessageBox.Show("Bạn có chắc muốn phục hồi lại dữ liệu cũ không?", "Xác nhận", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (questionDlg != DialogResult.Yes) return;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Backup file (*.bak)|*.bak|All files (*.*)|*.*";

            var dlgResult = dlg.ShowDialog();
            if (dlgResult != DialogResult.OK) return;

            // Kiểm tra chưa chọn đường dẫn
            if (string.IsNullOrEmpty(dlg.FileName)) return;

            try
            {
                string sqlCmd = "USE MASTER ALTER DATABASE [" + csdl + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE ";
                sqlCmd += "RESTORE DATABASE [" + csdl + "] FROM  DISK = N'" + dlg.FileName + "' WITH  FILE = 1,  NOUNLOAD, REPLACE, STATS = 10";
                sqlCmd += " ALTER DATABASE [" + csdl + "] SET MULTI_USER";

                // Thực thi câu sql restore database
                SQLHelper.ExecuteNonQuery(sqlCmd);

                MsgBox.ShowSuccessfulDialog("Phục hồi thành công. Chương trình sẽ khởi động lại.");

                // Thoát chương trình
                Application.ExitThread();

                // Mở lại chương trình
                Process.Start(Application.ExecutablePath);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MsgBox.ShowWarningDialog("Không thể phục hồi");
            }
        }
    }
}
