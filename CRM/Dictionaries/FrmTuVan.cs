using Lotus;
using Lotus.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using CRM;
using System.Data.SqlClient;
using Lotus.Libraries;
using DevExpress.XtraBars.Alerter;
namespace CRM.Dictionaries
{
    public partial class FrmTuVan : FrmBaseReport
    {

        SqlConnection _conn;
      


        public delegate void NewHome();
        public event NewHome OnNewHome;

        public FrmTuVan()
        {
            // không dung BeginInvoke thì có thằng này
            //DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;

            InitializeComponent();
            Printable = customGridControl1;
            Landscape = true;

            repHinhThuc.Items.AddEnum(typeof(HinhThucLienLac), true);
            rcboTrangThai.Items.AddEnum(typeof(TrangThaiTuVan), true);
            rcboTrangThaiColumn.Items.AddEnum(typeof(TrangThaiTuVan), true);

         
             _conn = new SqlConnection(HeThong.ConnectionString);
            SqlDependency.Start(HeThong.ConnectionString);

        }

     

     





        private void FrmPhapLy_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'data.NhomKH' table. You can move, or remove it, as needed.
            this.nhomKHTableAdapter.Fill(this.data.NhomKH);
            // TODO: This line of code loads data into the 'data.LoaiTuVan' table. You can move, or remove it, as needed.
            this.loaiTuVanTableAdapter.Fill(this.data.LoaiTuVan);
            UseEnableControl = false;
            LockControls(false);
            OnReload();

            itemTrangThai.Enabled = HeThong.NguoiDungDangNhap.Loai == 3;
            btnChuyen.Enabled = HeThong.NguoiDungDangNhap.Loai >= 2;
            


            OnNewHome += new NewHome(Form1_OnNewHome);
         
            LoadData();
        }





        public void Form1_OnNewHome()
        {
            ISynchronizeInvoke i = (ISynchronizeInvoke)this;
            if (i.InvokeRequired)//tab
            {
                NewHome dd = new NewHome(Form1_OnNewHome);
                i.BeginInvoke(dd, null);
                return;
            }
            LoadData();

        }
        void LoadData()
        {
            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }

            string sql = string.Format(@"SELECT [ID]
                                        ,[SoPhieuDat]
                                        ,[KhachHang]
                                        ,[NhanVien]
                                        ,[NVCS]
                                        ,[NgayTao]
                                        ,[NoiDung]
                                        ,[NgayHen]
                                        ,[TrangThai]
                                        ,[NgayTrangThai]
                                        ,[HinhThuc]
                                        ,[GhiChu]
                                        ,[Loai]
                                        ,[NgayCapNhat]
                                    FROM [dbo].[TuVan]");
           
            // muốn treo máy thì cứ where
            //                          WHERE ([NhanVien] ='{0}') OR ((SELECT [Loai] FROM [dbo].[NguoiDung] WHERE ([TenDangNhap] = '{0}')) > 1)"
                                        //, HeThong.NguoiDungDangNhap.TenDangNhap);


            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                SqlDependency dependency = new SqlDependency(command);

                dependency.OnChange += new OnChangeEventHandler(de_OnChange);

                // Execute the command.  
                using (SqlDataReader reader = command.ExecuteReader())
                {

                }
            }
        }
        public void de_OnChange(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency de = sender as SqlDependency;
            de.OnChange -= de_OnChange;
            if (OnNewHome != null)
            {
                OnNewHome();
            }

            try
            {
                // cái quỷ BeginInvoke gì day?? --> né thread
                BeginInvoke(new MethodInvoker(delegate()
                {
                    OnReload();

                    if (e.Info == SqlNotificationInfo.Insert || e.Info == SqlNotificationInfo.Update)
                    {

                        var last = tuVanTableAdapter.GetLastestByUser(HeThong.NguoiDungDangNhap.TenDangNhap).FirstOrDefault();
                        if (last == null) return;

                        // cho này van ktra de máy khác có tạo gì cho nhanvien này thì ben máy này nó tu hien ra
                        // voi lai admin xem nhiều nguoi cung luc
                        if (last.NhanVien == HeThong.NguoiDungDangNhap.TenDangNhap)
                        {

                            ShowAlert(string.Format("{0} - Ngày hẹn {1:dd/MM/yyyy}", last.NoiDung, last.NgayHen));


                        }


                    }
                }));
            }
            catch
            {

            }
        }




        protected override void OnNew()
        {
            var f = new FrmThongTinTuVan(string.Empty);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                OnReload();

            ReloadButtons();
        }

        protected override void OnEdit()
        {
            var p = customGridView1.GetFocusedDataRow() as CRMData.TuVanRow;
            if (p == null) return;

            var f = new FrmThongTinTuVan(p.ID);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                OnReload();

            ReloadButtons();
        }

        protected override void OnReload()
        {
            base.OnReload();
            
            this.khachHangTableAdapter.FillByUser(this.data.KhachHang, HeThong.NguoiDungDangNhap.TenDangNhap);

            if (ReportType == Lotus.Base.ReportType.All)
            {
                itemLookTrangThai.EditValue = -1;
                this.tuVanTableAdapter.FillByUser(this.data.TuVan, HeThong.NguoiDungDangNhap.TenDangNhap);
            }
            else
            {
                tuVanTableAdapter.FillByUserDateTrangThai(this.data.TuVan, (int)itemLookTrangThai.EditValue, DateFrom, DateTo, HeThong.NguoiDungDangNhap.TenDangNhap);
            }
        }
        protected override bool OnSave()
        {
            customGridView1.CloseEditor();
            customGridView1.UpdateCurrentRow();

            if (customGridView1.HasColumnErrors) return false;
            try
            {
                var dt = data.TuVan.GetChanges() as CRMData.TuVanDataTable;
                if (dt != null)
                {

                    foreach (var t in dt)
                    {
                        if (t.RowState != DataRowState.Deleted)
                            t.NgayCapNhat = DateTime.Now;
                    }
                    tuVanTableAdapter.Update(dt);
                    data.TuVan.AcceptChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowErrorDialog(ex.Message);
                return false;
            }
          
        }


        bool XoaDong()
        {
            if (MsgBox.ShowYesNoDialog("Bạn có chắc muốn xóa những dòng này?") == System.Windows.Forms.DialogResult.No) return false;

            customGridView1.DeleteSelectedRows();
            if (OnSave() == false)
            {
                OnReload();
                return false;
            }

            return true;
        }

        protected override bool OnDelete()
        {
            if (HeThong.NguoiDungDangNhap.Loai != 3)
            {
                var p = customGridView1.GetFocusedDataRow() as CRMData.TuVanRow;
                if (p == null) return false;

                if (HeThong.NguoiDungDangNhap.TenDangNhap == p.NhanVien)
                {
                    int n = 1;
                    if (HeThong.NguoiDungDangNhap.Loai < (int)ChucDanh.QuanLy)
                        n = Param.GetValue<int>("Số ngày được phép sửa dữ liệu", "Hệ thống", 2);
                    else if (HeThong.NguoiDungDangNhap.Loai == (int)ChucDanh.QuanLy)
                        n = Param.GetValue<int>("Số ngày quản lý được phép sửa dữ liệu", "Hệ thống", 7);

                    if (DateTime.Today.AddDays(-n) <= p.NgayTao.Date)
                    {
                        XoaDong();
                    }
                    else
                    {
                        MsgBox.ShowWarningDialog("Vượt quá số ngày cho phép sửa dữ liệu");
                        return false;
                    }
                }
                else
                {
                    MsgBox.ShowWarningDialog("Không thể xóa dữ liệu của người khác");
                    return false;
                }

            }


            return XoaDong();

        }

        private void customGridView1_DoubleClick(object sender, EventArgs e)
        {
            OnEdit();
        }

      

        private void customGridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                itemTrangThai.EditValue = null;
                pMenu.ShowPopup(MousePosition);
            }
        }

        private void itemTrangThai_EditValueChanged(object sender, EventArgs e)
        {
            int tt = (itemTrangThai.EditValue == null || itemTrangThai.EditValue == DBNull.Value) ? 0 : Convert.ToInt32(itemTrangThai.EditValue);

            int[] rows = customGridView1.GetSelectedRows();


            for (int i = 0; i < rows.Length; i++)
            {
                var t = customGridView1.GetDataRow(rows[i]) as CRMData.TuVanRow;
                if (t == null) continue;
                if (HeThong.NguoiDungDangNhap.Loai == 3)
                {
                    t.TrangThai = tt;
                    t.NgayTrangThai = DateTime.Now;

                    if (tt == (int)TrangThaiTuVan.Pending)
                        t.SetNgayTrangThaiNull();
                }
                else
                {
                    if (t.TrangThai != (int)TrangThaiTuVan.Pending) return;

                    t.TrangThai = tt;
                    t.NgayTrangThai = DateTime.Now;

                   
                }

            }
        }

        private void btnChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var t = customGridView1.GetFocusedDataRow() as CRMData.TuVanRow;
            if (t == null) return;

            var f = new FrmChonNV(t.NhanVien);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { 
                // chuyen cho nv khac là tạo 1 dong mới và huy dong cũ

                t.TrangThai = (int)TrangThaiTuVan.Deny;
                t.NgayTrangThai = DateTime.Now;

                var t2 = data.TuVan.NewTuVanRow();
                t2.ID = Guid.NewGuid().ToString();
                t2.NhanVien = t.NhanVien;
                t2.NVCS = f.NVChon;
                t2.NoiDung = string.Format("{0} chuyển từ {1} sang {2}: {3}", HeThong.NguoiDungDangNhap.TenDangNhap, t.NhanVien, f.NVChon, t.NoiDung);
                t2.NgayTao = t.NgayTao;
                t2.NgayHen = t.NgayHen;
                t2.KhachHang = t.KhachHang;
                t2.SoPhieuDat = t.SoPhieuDat;
                t2.HinhThuc = t.HinhThuc;
                t2.GhiChu = t.GhiChu;
                t2.Loai = t.Loai;
                t2.NgayCapNhat = DateTime.Now;  
                data.TuVan.AddTuVanRow(t2);
            }
        }

        private void btnXemDonHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var t = customGridView1.GetFocusedDataRow() as CRMData.TuVanRow;
            if (t == null) return;

            if (t.IsSoPhieuDatNull()) return;

            var f = new FrmThongTinPhieuDH(t.SoPhieuDat, true);
            f.ShowDialog();
        }

        private void customGridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
           
          
        }

        private void customGridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;

            var t = customGridView1.GetDataRow(e.RowHandle) as CRMData.TuVanRow;
            if (t == null) return;



            if (t.TrangThai != (int)TrangThaiTuVan.Pending) return;
            if (e.Column.FieldName == "NoiDung")
            {
                if (t.NgayHen.Date == DateTime.Today)
                    e.Appearance.BackColor = Color.LightGreen;
                else if (t.NgayHen.Date < DateTime.Today)
                {
                    e.Appearance.BackColor = Color.Pink;
                }
                else
                    e.Appearance.BackColor = Color.Transparent;
            }

        }

        private void FrmTuVan_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlDependency.Stop(HeThong.ConnectionString);
        }
    }
}
