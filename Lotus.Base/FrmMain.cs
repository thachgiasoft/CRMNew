using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Lotus.Libraries;

using DevExpress.Xpo;
using Lotus.Base.Systems;
using Lotus.Base.DATATableAdapters;
using DevExpress.XtraEditors;



namespace Lotus.Base
{
    public partial class FrmMain : RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
            try
            {
                string defaultSkin = Param.GetValue<string>("Giao diện", "Hệ thống", "Office 2010 Blue");
                lblSkinName.Caption = "Giao diện " + defaultSkin;
                UserLookAndFeel.Default.SkinName = defaultSkin;
                UserLookAndFeel.Default.StyleChanged += Default_StyleChanged;

                lblDatabase.Caption = SqlConnector.DBName;
                lblVersion.Caption = String.Format("v{0}", Application.ProductVersion);
            }
            catch { }
        }

      

        private void Default_StyleChanged(object sender, EventArgs e)
        {
            lblSkinName.Caption = "Giao diện " + UserLookAndFeel.Default.SkinName;
            docManager.View.Appearance.BackColor = this.BackColor;
            Param.SetValue("Giao diện", UserLookAndFeel.Default.SkinName);
        }

        public void OpenForm<T>(string chucnang)
        {
         
            MsgBox.ShowWaitForm();
            var f = MdiChildren.FirstOrDefault(i => i is T);
            if (f == null)
            {
                f = Activator.CreateInstance<T>() as Form;
                f.MdiParent = this;

                if (f is FrmBase)
                {
                    (f as FrmBase).ChucNang = chucnang;
                }

                f.Show();
            }
            else f.Activate();
            MsgBox.CloseWaitForm();
        }

        public void OpenForm<T>(object arg) where T : Form
        {
            MsgBox.ShowWaitForm();
            var f = MdiChildren.FirstOrDefault(i => i is T);
            if (f == null)
            {
                f = Activator.CreateInstance(typeof(T), arg) as T;
                f.MdiParent = this;
                f.Show();
            }
            else f.Activate();
            MsgBox.CloseWaitForm();
        }


     
        private void btnParamList_ItemClick(object sender, ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            MsgBox.OpenDialog<FrmThamSo>();
        }
        
     
        private void lblCopyright_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }
        private void btnComment_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }
        private void btnHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }
        private void btnDocument_ItemClick(object sender, ItemClickEventArgs e)
        {
            var s = Application.StartupPath + "\\Help.docx";
            if (!File.Exists(s))
                MsgBox.ShowWarningDialog("Tài liệu chưa sẵn sàng");
            else
                Process.Start(s);
        }
        private void btnImport_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }
        private void btnBackup_ItemClick(object sender, ItemClickEventArgs e)
        {
            SqlConnector.SaoLuu();
        }
        private void btnRestore_ItemClick(object sender, ItemClickEventArgs e)
        {
            SqlConnector.PhucHoi();
        }
        private void btnConnect_ItemClick(object sender, ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            MsgBox.OpenDialog<FrmThietLapKetnoi>();
        }
        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gabageMem = GC.GetTotalMemory(false);
            GC.RemoveMemoryPressure(gabageMem);
            GC.Collect();
            Refresh();
            var msg = string.Empty;

            string s = "Đã giải phóng {0} {1} bộ nhớ";
            if (HeThong.DaNgonNgu)
                s = LanguageHelper.TranslateMsgString(s, s);

            var gabageMem2 = GC.GetTotalMemory(false);
            var mem = gabageMem - gabageMem2;
            if (mem.ToString().Length <= 3) //Byte
                msg = string.Format(s, mem, "Bytes");
            else if (mem.ToString().Length <= 6) //KB
                msg = string.Format(s, mem / 1024, "KB");
            else if (mem.ToString().Length <= 9) //MB
                msg = string.Format(s, mem / (1024 * 1024), "MB");
            else
                msg = string.Format(s, gabageMem / (1024 * 1024 * 1024), "GB");


            MsgBox.ShowSuccessfulDialog(msg, false);
        }
        private void btnInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowAbout();
        }


        protected virtual void ShowAbout()
        {
            MsgBox.OpenDialog<FrmAbout>();
        }


        private void btnCapNhat_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }
        private void btnBanQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            rItemNgonNgu.Items.Clear();
            rItemNgonNgu.Items.AddEnum(typeof(LanguageEnum), true);

            itemNgonNgu.EditValue = (int)LanguageHelper.Language;
            itemNgonNgu.Visibility = btnNgonNgu.Visibility = HeThong.DaNgonNgu ? BarItemVisibility.Always : BarItemVisibility.Never;
        }



        public bool DangNhap()
        {
            foreach (Form f in MdiChildren)
                f.Close();

            if (MdiChildren.Length > 0) return true;

            if (!string.IsNullOrEmpty(HeThong.TenDangNhap))
                NhatKy.Add("Đăng xuất");

            HeThong.TenDangNhap = string.Empty;
            HeThong.ChiNhanhDangNhap = string.Empty;
            lblUser.Caption = "(Chưa đăng nhập)";

            var a = new ChucNangTableAdapter();

            var fDangNhap = new FrmDangNhap();
            if (fDangNhap.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bool isFirsRun = Param.GetValue<bool>("Lần chạy đầu tiên", "Hệ thống", true, false);

                NhatKy.Add("Đăng nhập");

                MsgBox.ShowWaitForm();
                var adChucNang = new ChucNangTableAdapter();
                foreach (RibbonPage page in ribbon.Pages)
                {
                    if (page.Visible == false) continue;
                    if (page.Equals(pageTroGiup)) continue;

                    var chucnangPage = HeThong.LayChucNang(page.Name, page.Text, string.Empty);

                    foreach (RibbonPageGroup group in page.Groups)
                    {
                        if (group.Visible == false) continue;
                        if (group.Equals(groupHethong_GiaoDien)) continue;

                        var chucnangGroup = HeThong.LayChucNang(group.Name, group.Text, page.Name);
                        if (!chucnangGroup["TenChucNang"].Equals(group.Text) && HeThong.NguoiDungDangNhap.QuanTri)
                        {
                            chucnangGroup["TenChucNang"] = group.Text;
                            a.Update(chucnangGroup);
                        }

                        foreach (BarItemLink itemlink in group.ItemLinks)
                        {
                            if (itemlink.Item.Visibility == BarItemVisibility.Never) continue;

                            if (itemlink.Item.Equals(btnDoiMatKhau)) continue;
                            if (itemlink.Item.Equals(btnRefresh)) continue;
                            if (itemlink.Item.Equals(btnKhoaChuongTrinh)) continue;

                            var chucnangItem = HeThong.LayChucNang(itemlink.Item.Name, itemlink.Item.Caption, group.Name);

                            if (!chucnangItem["ChucNangCha"].Equals(group.Name) && HeThong.NguoiDungDangNhap.QuanTri)
                            {
                                chucnangItem["ChucNangCha"] = group.Name;
                                a.Update(chucnangItem);
                            }

                            itemlink.Item.Tag = itemlink.Item.Name;

                            if (HeThong.NguoiDungDangNhap != null)
                            {
                                var quyenItem = HeThong.LayPhanQuyen(itemlink.Item.Name, HeThong.TenDangNhap, HeThong.NguoiDungDangNhap.QuanTri);
                                itemlink.Item.Enabled = quyenItem.TruyCap;
                            }
                        }
                        HeThong.LayPhanQuyen(group.Name, HeThong.TenDangNhap, HeThong.NguoiDungDangNhap.QuanTri);
                    }
                    HeThong.LayPhanQuyen(page.Name, HeThong.TenDangNhap, HeThong.NguoiDungDangNhap.QuanTri);
                }

                a.Dispose();

                // HIỆN TÊN NGƯỜI DÙNG
                string n = HeThong.TenDangNhap == null ? "[hoasensystem]" : HeThong.TenDangNhap.ToUpper();
                lblUser.Caption = string.Format("Xin chào: {0}", n);

                if (isFirsRun)
                    Param.SetValue("Lần chạy đầu tiên", false);

                MsgBox.CloseWaitForm();

                return true;
            }
            else
                //Application.ExitThread();
                return false;
        }

   

      

        private void btnKhoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (DangNhap() == false) this.Close();
        }
        private void btnPhanQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmPhanQuyen>(HeThong.ChucNangDangChon);
        }
        private void btnDoiMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            MsgBox.OpenDialog<FrmDoiMatKhau>(HeThong.NguoiDungDangNhap);
        }
        private void btnKhoaChuongTrinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (DangNhap() == false) this.Close();
        }
     

       
        private void btnHoTro_ItemClick(object sender, ItemClickEventArgs e)
        {
            var s = Application.StartupPath + "\\TeamViewer.exe";
            if (File.Exists(s))
                Process.Start(s);
        }

        private void btnNhatKyHoatDong_ItemClick(object sender, ItemClickEventArgs e)
        {
            HeThong.ChucNangDangChon = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            OpenForm<FrmNhatKyHeThong>(HeThong.ChucNangDangChon);
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            NhatKy.Add("Thoát chương trình");
        }

        private void btnNgonNgu_ItemClick(object sender, ItemClickEventArgs e)
        {
            LanguageHelper.ShowTranslateTool();
        }


        protected virtual void TranslateChildForms()
        {
            if (HeThong.DaNgonNgu == false) return;
            
            LanguageHelper.Translate(this);
            foreach (Form f in MdiChildren)
            {
                if (f is FrmBase)
                    (f as FrmBase).Translate();
                else
                    LanguageHelper.Translate(f);
            }
        }
        public void ChangeLanguage(LanguageEnum lang)
        {
            itemNgonNgu.EditValue = (int)lang;
        }
        private void itemNgonNgu_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lang = (LanguageEnum)Enum.Parse(typeof(LanguageEnum), itemNgonNgu.EditValue.ToString());
                LanguageHelper.Active(lang);
                TranslateChildForms();

                Param.SetValue("Ngôn ngữ", itemNgonNgu.EditValue.ToString());
            }
            catch { }
        }

        
    }
}