#define DEBUG
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Lotus.AutoUpdate
{
    public class FileHelper
    {
        private static WebClient _wc;

        public static void Download(ProgressBarControl progressBar)
        {
            _wc = new WebClient();
            _wc.DownloadProgressChanged += (sender, args) => { progressBar.Position = args.ProgressPercentage/4*3; };
            _wc.DownloadFileCompleted += (sender, args) =>
            {
                if (args.Cancelled)
                {
                    DeleteFile();
                }
                else
                {
                    if (UnZip())
                    {
                        progressBar.PerformStep();
                        if (DeleteFile())
                        {
                            progressBar.Position = 100;
                        }
                    }
                }
                ReRun();
                Application.Exit();
            };
            _wc.DownloadFileAsync(new Uri(Repository.Instance.DiaChiFile), Repository.Instance.DiaChiLuu);
        }


        static void ReRun()
        {
            string app = String.Format("{0}\\{1}.exe", Application.StartupPath, Repository.Instance.AppCode);
            Process.Start(app);
        }


        /// <summary>
        ///     Hủy tiến trình đang download.
        /// </summary>
        public static void CancelDownload()
        {
            if (Repository.Instance == null) return;

            if (_wc != null) _wc.CancelAsync();
            else
                Application.Exit();
        }

        /// <summary>
        ///     Hàm giải nén file.
        /// </summary>
        /// <returns></returns>
        public static bool UnZip()
        {
            //ZipStorer// Open an existing zip file for reading

            var zip = ZipStorer.Open(Repository.Instance.DiaChiLuu, FileAccess.ReadWrite);

            // Read the central directory collection
            var dir = zip.ReadCentralDir();

            // Look for the desired file
            try
            {
                foreach (var entry in dir)
                {
                    var fileName = string.Format("{0}\\{1}", Application.StartupPath, entry.FilenameInZip);
                    zip.ExtractFile(entry, fileName);
                }
                zip.Close();
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message);
#if (DEBUG)
                XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
#else
                         XtraMessageBox.Show("Không thể cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
#endif
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Hàm xóa file trên local.
        /// </summary>
        /// <returns></returns>
        public static bool DeleteFile()
        {
            if (!File.Exists(Repository.Instance.DiaChiLuu)) return false;
            try
            {
                File.Delete(Repository.Instance.DiaChiLuu);
            }
            catch (Exception ex)
            {
#if (DEBUG)
                XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
#else
                         XtraMessageBox.Show("Không thể cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
#endif
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Hàm lấy kích thước file từ server
        /// </summary>
        public static bool GetFileInfo()
        {
            string d;
            try
            {
                var req = WebRequest.Create(Repository.Instance.DiaChiFile);
                req.Method = "HEAD";

                using (var resp = req.GetResponse())
                {
                    long contentLength = 0;

                    long.TryParse(resp.Headers.Get("Content-Length"), out contentLength);
                    Repository.Instance.KichThuocFile = ConvertFileSize(contentLength);

                    d = resp.Headers.Get("Last-Modified");
                }

                DateTime result;
                DateTime.TryParse(d, out result);

                Repository.Instance.NgayCapNhat = result;

                var url = Repository.Instance.DiaChiFile;
                Repository.Instance.TenFile = url.Substring(url.LastIndexOf("/") + 1,
                    (url.Length - url.LastIndexOf("/") - 1));

                return true;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message);

                //if (ex is WebException)
                //    XtraMessageBox.Show("Tập tin tải về không tồn tại trên server", "Thông báo", MessageBoxButtons.OK,
                //        MessageBoxIcon.Error);
                //else
                //    XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        /// <summary>
        ///     Hàm lấy tên file từ URL.
        /// </summary>
        /// <returns></returns>
        public static string GetFileNameFromUrl()
        {
            return Repository.Instance.DiaChiFile.Substring(Repository.Instance.DiaChiFile.LastIndexOf("/") + 1,
                (Repository.Instance.DiaChiFile.Length - Repository.Instance.DiaChiFile.LastIndexOf("/") - 1));
        }

        /// <summary>
        ///     Hàm tiện ích chuyển kích thước file từ long -> string
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ConvertFileSize(long number)
        {
            string result;

            if (number >= 1073741824)
            {
                result = string.Format("{0} {1}", number/1073741824, "GB");
            }
            else if (number >= 1048576)
            {
                result = string.Format("{0} {1}", number/1048576, "MB");
            }
            else
            {
                result = string.Format("{0} {1}", number/1024, "KB");
            }

            return result;
        }
    }
}