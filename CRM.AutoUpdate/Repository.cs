using System;
using System.Data;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraEditors;

namespace Lotus.AutoUpdate
{
    public class Repository
    {
        /// <summary>
        ///     Instance chứa thông tin từ file xml
        /// </summary>
        public static XmlInfo Instance;

        /// <summary>
        ///     Tên của app trên máy.
        /// </summary>
        public static string AppCode;

        /// <summary>
        ///     Version của app trên máy.
        /// </summary>
        public static Version AppVersion;

        /// <summary>
        ///     Hàm thực thi toàn bộ ứng dụng Update Online.
        /// </summary>
        /// <param name="args"></param>
        public static bool Initalize(string[] args)
        {
            if (args.Length != 3)
            {
                Log.Write("args không chính xác.");
                return false;
            }

            AppCode = args[0];

            if (!Version.TryParse(args[1], out AppVersion)) return false;

            // LẤY THÔNG TIN XML TỪ XML FILE
            if (!GetInfo()) return false;

            //KIỂM TRA VERSION
            Log.Write("2");
            if (HasNewVersion())
            {
                // HIỆN FORM UPDATE
                return ShowFrmUpdate();
            }
            return false;
        }

        /// <summary>
        ///     Hàm lấy thông tin từ xml về.
        /// </summary>
        private static bool GetInfo()
        {
            Instance = new XmlInfo();
            var result = false;
            var ds = new DataSet("Root");


            //var settings = new XmlReaderSettings()
            //{
                
            //    Indent = true,
            //    NewLineChars = "\r\n",
            //    NewLineHandling = NewLineHandling.Replace
            //};

            Log.Write("0");

            try
            {
                using (var reader = XmlReader.Create(Program.XmlLocation))
                {
                    ds.ReadXml(reader, XmlReadMode.Auto);
                    if (ds.Tables.Count > 0)
                    {
                        var dt = ds.Tables[0];
                        foreach (DataRow dr in dt.Rows)
                        {
                            var code = dr["AppCode"];
                            if (code != null && code.ToString() == AppCode)
                            {
                                Instance.AppCode = AppCode;
                                Instance.AppName = dr["AppName"].ToString();
                                Instance.DiaChiFile = dr["Link"].ToString();
                                Instance.XmlVersion = new Version(dr["Version"].ToString());
                                Instance.GhiChu = dr["Description"].ToString();
                                result = true;
                            }
                        }
                    }
                } // end using

                Log.Write("1");
            }

            catch (Exception ex)
            {
                //if (ex is WebException)
                //    XtraMessageBox.Show("File định dạng (XML) không có trên server.", "Thông báo", MessageBoxButtons.OK,
                //        MessageBoxIcon.Error);
                //else
                //    XtraMessageBox.Show(ex.Message);

                return false;
            }


            if (result)
            {
                result = FileHelper.GetFileInfo();
            }
            return result;
        }

        /// <summary>
        ///     Hàm kiểm tra appVersion vs xmlVersion.
        /// </summary>
        /// <returns></returns>
        private static bool HasNewVersion()
        {
            return Instance.XmlVersion > AppVersion;
        }

        /// <summary>
        ///     Hiện form update
        /// </summary>
        public static bool ShowFrmUpdate()
        {
            var f = new FrmMain();
            f.ShowDialog();

            return f.DialogResult == DialogResult.OK;
        }

        /// <summary>
        ///     Hàm tiện ích lấy thông tin của app.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assembly"></param>
        public static T GetAssemblyAttribute<T>(Assembly assembly) where T : Attribute
        {
            if (assembly == null) return null;

            var attributes = assembly.GetCustomAttributes(typeof (T), true);

            if (attributes.Length == 0) return null;

            return (T) attributes[0];
        }
    }
}