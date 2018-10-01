
using DevExpress.Skins;
using DevExpress.Skins.Info;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraLayout.Localization;
using DevExpress.XtraPivotGrid.Localization;
using DevExpress.XtraTreeList.Localization;
using Lotus.Base;
using Lotus.Base.DATATableAdapters;
using Lotus.Base.Systems;
using Lotus.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lotus
{
    public class HeThong
    {
        public static void VietHoa()
        {
            GridLocalizer.Active = new VietNamGridLocalizer();
            Localizer.Active = new VietNamEditorsLocalizer();
            PivotGridLocalizer.Active = new VietNamPivotGridLocalizer();
            DocumentManagerLocalizer.Active = new VietNamDocumentManagerLocalizer();
            TreeListLocalizer.Active = new VietNamTreeListLocalizer();
            LayoutLocalizer.Active = new VietNamLayoutLocalizer();

        }
        public static bool KetNoi()
        { 
            bool bKetnoi = SqlConnector.Ketnoi();
            while (bKetnoi == false)
            {
                MsgBox.CloseSplashForm();
                if (MsgBox.ShowYesNoDialog("Không thể kết nối cơ sở dữ liệu!\nBạn có muốn thiết lập lại kết nối?") == DialogResult.Yes)
                    bKetnoi = SqlConnector.Ketnoi();
                else
                    return false;
            }

            if (bKetnoi)
            {
                bool isFirsRun = Param.GetValue<bool>("Lần chạy đầu tiên", "Hệ thống", true, false);
                if (isFirsRun)
                {
                    MsgBox.CloseSplashForm();
                    var fthietlap = new FrmThietLapBanDau();
                    var x = fthietlap.ShowDialog();
                    if (x == DialogResult.Cancel)
                    {
                        SingleInstance.Stop();
                        return false;
                    }
                }
            }

            return bKetnoi;
        }

        public static string HostUpdate { get; set; }
        public static void CapNhatOnline()
        {
            var app = String.Format("{0}\\{1}", Application.StartupPath, "AutoUpdate.exe");
            if (!File.Exists(app)) return;

        
            var info = new ProcessStartInfo();
            info.FileName = app;
            info.Arguments = string.Format("{0} {1} {2}",
                Application.ProductName,
                Application.ProductVersion,
                HostUpdate);

            var process = Process.Start(info);
            if (process != null) process.WaitForExit();
        }

        public static void AddCustomSkin()
        {
            ((DevExpress.LookAndFeel.Design.UserLookAndFeelDefault)DevExpress.LookAndFeel.Design.UserLookAndFeelDefault.Default).LoadSettings(() =>
            {
                var skinCreator = new SkinBlobXmlCreator("HybridApp",
                    "Lotus.Base.SkinData.", typeof(FrmBase).Assembly, null);
                SkinManager.Default.RegisterSkin(skinCreator);
            });
            //AsyncAdornerBootStrapper.RegisterLookAndFeel(
            //    "MetroBlack", "DevExpress.RealtorWorld.Win.SkinData.", typeof(Program).Assembly);
        }

        public static void DangNhap()
        {
            (Application.OpenForms[0] as FrmMain).DangNhap();
        }

        public static bool MaHoaChuoiKetNoi { get; set; }
        public static bool DaNgonNgu { get; set; }


        public static bool DaDangKy { get; set; }

        public static string AppConfigConnectionStringName;
        public static string MaHoaMD5(string data)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bdrr = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] barr = md5.ComputeHash(bdrr);
            return Convert.ToBase64String(barr);
        }

        public static string TenDangNhap 
        {
            get;
            set;
        }

        public static string ChiNhanhDangNhap
        {
            get;
            set;
        }

        public static string ConnectionString { get; set; }

        public static DATA.NguoiDungRow LayNguoiDungDangNhap(string tendangnhap)
        {
            NguoiDungTableAdapter ad = new NguoiDungTableAdapter();
            var dt = ad.GetDataByTenDangNhap(tendangnhap);
            ad.Dispose();
            if (dt == null) return null;
            if (dt.Rows.Count == 0) return null;

            return dt.Rows[0] as DATA.NguoiDungRow;
        }


        public static string ChucNangDangChon { get; set; }
   
     

        public static DATA.NguoiDungRow NguoiDungDangNhap
        {
            get;
            set;
        }






       


        public static DataRow LayChucNang(string machucnang, string tenChucNang, string chucnangcha)
        {
            DataRow chucnang = null;
            var ad = new ChucNangTableAdapter();
            string sql = string.Format("select * from ChucNang where MaChucNang = N'{0}'", machucnang);
            var dt = SQLHelper.ExecuteDataTable(sql);

            if (dt == null || dt.Rows.Count == 0)
            {
                ad.Insert(machucnang, tenChucNang, chucnangcha);
                dt = SQLHelper.ExecuteDataTable(sql);
            }


            chucnang = dt.Rows[0];
            if (!chucnang["TenChucNang"].Equals(tenChucNang))
            {
                chucnang["TenChucNang"] = tenChucNang;
                chucnang["ChucNangCha"] = chucnangcha;
                ad.Update(chucnang);
                chucnang.AcceptChanges();
            }


            return chucnang;
        }
        public static DATA.PhanQuyenRow LayPhanQuyen(string machucnang, string tendangNhap, bool all)
        {
            DATA.PhanQuyenRow chucnang = null;
            var ad = new PhanQuyenTableAdapter();
            string sql = string.Format("select * from PhanQuyen where MaChucNang = N'{0}' and TenDangNhap = N'{1}'"
                                                , machucnang, tendangNhap);
            var dt = SQLHelper.ExecuteDataTable(sql);

            if (dt == null || dt.Rows.Count == 0)
            {

                ad.Insert(tendangNhap.ToLower(), machucnang, all, all, all, all);
                dt = SQLHelper.ExecuteDataTable(sql);
            }

            var dtPQ = new DATA.PhanQuyenDataTable();
            chucnang = dtPQ.NewPhanQuyenRow();
            chucnang.ItemArray = dt.Rows[0].ItemArray;
            dtPQ.Dispose();


            return chucnang;
        }
        public static bool Exits(string tenBang, string cotMa, string ma)
        {
            string sql = string.Format("select * from {0} where {1} = N'{2}'", tenBang, cotMa, ma);
            object obj = SQLHelper.ExecuteScalar(sql);
            return obj == null ? false : true;
        }


        public static void NapDinhDang()
        {
            CultureInfo cul = new CultureInfo("vi-VN");

            cul.DateTimeFormat.ShortDatePattern
                = Param.GetValue<string>("Định dạng ngày", "Đinh dạng dữ liệu", cul.DateTimeFormat.ShortDatePattern);

            cul.NumberFormat.CurrencyDecimalDigits
                = Param.GetValue<int>("Số lẻ thập phân", "Đinh dạng dữ liệu", cul.NumberFormat.CurrencyDecimalDigits);
            cul.NumberFormat.CurrencyDecimalSeparator
                = Param.GetValue<string>("Dấu cách thập phân", "Đinh dạng dữ liệu", cul.NumberFormat.CurrencyDecimalSeparator);
            cul.NumberFormat.CurrencyGroupSeparator
               = Param.GetValue<string>("Dấu cách hàng nghìn", "Đinh dạng dữ liệu", cul.NumberFormat.CurrencyGroupSeparator);

           

            cul.NumberFormat.CurrencySymbol
                = Param.GetValue<string>("Ký hiệu tiền", "Đinh dạng dữ liệu", string.Empty);


            // 8    - -n $
            // 15   - (n $)
            cul.NumberFormat.CurrencyNegativePattern
                = Param.GetValue<int>("Định dạng tiền âm", "Đinh dạng dữ liệu", 15);

            Thread.CurrentThread.CurrentCulture = cul;
        }
    }





   
    public class Param
    {
        public static void SetValue(string paramCode, object value)
        {
            string s = string.Empty;
            if (value.GetType() == typeof(DateTime))
            {
                var cul = new CultureInfo("en-US");
                s = Convert.ToDateTime(value, cul.DateTimeFormat).ToString(cul.DateTimeFormat);
            }
            else if (value.GetType() == typeof(decimal))
            {
                var cul = new CultureInfo("en-US");
                s = Convert.ToDecimal(value, cul.NumberFormat).ToString();
            }
            else
                s = value.ToString();

            string sql = string.Format("update ThamSo set GiaTri = N'{0}' where TenThamSo = N'{1}'", s, paramCode);
            SQLHelper.ExecuteNonQuery(sql);
        }

        public static T GetValue<T>(string paramCode, string category, object defaultValue)
        {
            return GetValue<T>(paramCode, category, defaultValue, true);
        }

        public static T GetValue<T>(string paramCode, string category, object defaultValue, bool allowEdit)
        {
            string sql = string.Empty;
            if (!HeThong.Exits("ThamSo", "TenThamSo", paramCode))
            {
                string value = string.Empty;
                if (typeof(T) == typeof(DateTime))
                {
                    var cul = new CultureInfo("en-US");
                    value = Convert.ToDateTime(defaultValue, cul.DateTimeFormat).ToString(cul.DateTimeFormat);
                }
                else if (typeof(T) == typeof(decimal))
                {
                    var cul = new CultureInfo("en-US");
                    value = Convert.ToDecimal(defaultValue, cul.NumberFormat).ToString();
                }
                else
                    value = defaultValue.ToString();

                sql = string.Format(@"INSERT INTO [ThamSo]
                                    ([TenThamSo]
                                    ,[GiaTri]
                                    ,[ChoPhepThayDoi]
                                    ,[Nhom]
                                    ,[KieuDuLieu])
                                VALUES (N'{0}', N'{1}', {2}, N'{3}', N'{4}')",
                                     paramCode, value, Convert.ToInt32(allowEdit), category, typeof(T).ToString());
                
                SQLHelper.ExecuteNonQuery(sql);
            }

            sql = string.Format("select * from ThamSo where TenThamSo = N'{0}'", paramCode);
            var dt = SQLHelper.ExecuteDataTable(sql);
            if (dt == null || dt.Rows.Count == 0)
                return default(T);

            var row = dt.Rows[0];

            if (typeof(T) == typeof(DateTime))
            {
                var cul = new CultureInfo("en-US");
                return (T)Convert.ChangeType(row["GiaTri"], typeof(T), cul);
            }
            else if (typeof(T) == typeof(decimal))
            {
                var cul = new CultureInfo("en-US");
                return (T)Convert.ChangeType(row["GiaTri"], typeof(T), cul);
            }
            else
                return (T)Convert.ChangeType(row["GiaTri"], typeof(T));
        }

    }

    public class NhatKy
    {
        static NhatKyHeThongTableAdapter ad = new NhatKyHeThongTableAdapter();

        public static void Add(string noidung)
        {
            if (string.IsNullOrEmpty(noidung)) return;


            bool b = Param.GetValue<bool>("Ghi nhật ký hệ thống", "Hệ thống", true);
            if (!b) return;

            ad.Insert(DateTime.Now, HeThong.TenDangNhap, noidung);
        }

    }
}
