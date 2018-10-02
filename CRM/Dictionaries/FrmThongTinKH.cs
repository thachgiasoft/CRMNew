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
using Lotus.Base.Systems;
using System.IO;
namespace CRM.Dictionaries
{
    public partial class FrmThongTinKH : FrmBase
    {
        string _maKH = string.Empty;
        BackgroundWorker _worker = new BackgroundWorker();


        public string MaKH { get; set; }

        public FrmThongTinKH()
        {
            InitializeComponent();
            UseEnableControl = false;            
        }

        public FrmThongTinKH(string maKH)
        {
            InitializeComponent();         
            _maKH = maKH;
        }

        bool _isReadOnly;
        public FrmThongTinKH(string maKH, bool isRead)
        {
            InitializeComponent();
            _maKH = maKH;
            _isReadOnly = isRead;
        }

        private void FrmPhapLy_Load(object sender, EventArgs e)
        {
            repHinhThuc.Items.AddEnum(typeof(HinhThucLienLac), true);
            repTrangThai.Items.AddEnum(typeof(TrangThaiTuVan), true);

            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerAsync();
            OnReload();
            LockControls(false);
            Bindings();
        }

        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {

            string path = Param.GetValue<string>("Đường dẫn Hình ảnh", "Hệ thống", @"\\192.168.198.100\Scan Xerox\Test");

            string fileName = MaKHTextEdit.Text + ".jpg";
            _fileDes = string.Format("{0}\\{1}", path, fileName);
            if (File.Exists(_fileDes))
                pictureEdit1.EditValue = Image.FromFile(_fileDes);
        }

        private void Bindings()
        {
            this.khachHangTableAdapter.FillByMaKH(this.data.KhachHang, _maKH);
            if (data.KhachHang.Count == 0)
            {
                var k = data.KhachHang.NewKhachHangRow();
               


                string dd = Param.GetValue<string>("Mã khách hàng", "Định dạng mã", "KH{0:d7}");
                _maKH = DinhDangMa.LayMaTuDong("MaKH", "KhachHang", dd);

                MaKHTextEdit.Text = k.MaKH = _maKH;
                CreatedDateDateEdit.EditValue = k.CreatedDate=DateTime.Now;
                NhomKHTextEdit.EditValue = k.NhomKH= 1;
                SoDTTextEdit.Text = k.SoDT = string.Empty;
                TenKHTextEdit.Text = k.TenKH = string.Empty;
                NVBHTextEdit.EditValue = k.NVBH = HeThong.NguoiDungDangNhap.TenDangNhap;


                data.KhachHang.AddKhachHangRow(k);
            }

            //goi day
            customGridControl1.DataSource = lichSuMuaHangTableAdapter.GetData(_maKH);
            customGridControl4.DataSource = tuVanTableAdapter1.GetDataByKhachHang(_maKH);
            customGridControl2.DataSource = lichSuTraHangTableAdapter.GetData(_maKH);

            var kh = data.KhachHang.FirstOrDefault();
            if (kh == null) return;
            if(!kh.IsAnhNull())
            {
                string path = Param.GetValue<string>("Đường dẫn Hình ảnh", "Hệ thống", @"\\192.168.198.100\Scan Xerox\Test");
                string fileAnh = string.Format("{0}\\{1}", path, kh.Anh);
                if (File.Exists(fileAnh))
                    pictureEdit1.EditValue = Image.FromFile(fileAnh);
            }



           
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (_isReadOnly)
            {
                LockControls(false);
                btnSave.Enabled = btnAdd.Enabled = btnTaoLichKHTN.Enabled = false;
                tabbedControlGroup1.SelectedTabPage = lgGD;

                btnAdd.Visibility = btnSave.Visibility = 
                btnTaoLichKHTN.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;



                lgKH.Enabled = false;
            }
        }

        protected override void OnNew()
        {
            if (LuuKhachHang())
            {
                _maKH = string.Empty;
                Bindings();
            }
        }

        protected override void OnReload()
        {
            this.kenhTTTableAdapter.Fill(this.data.KenhTT);
            this.mucDichSDTableAdapter.Fill(this.data.MucDichSD);
            this.benhLyTableAdapter.Fill(this.data.BenhLy);
            this.tinhThanhTableAdapter.Fill(this.data.TinhThanh);
            this.nhomKHTableAdapter.Fill(this.data.NhomKH);
            this.nguoiDungTableAdapter.Fill(dataHeThong.NguoiDung);
        }

        bool LuuKhachHang()
        {
           
            if (ValidateKH() == false) return false;



            khachHangBindingSource.EndEdit();


            var k = data.KhachHang.FirstOrDefault();
            if (k == null) return false;

            if (Data.IsNewRow(k))
            {
                CreatedDateDateEdit.EditValue = DateTime.Now;
                // kiem tra mã trùng 1 lần nữa .. chua cần
                // ...
            }


            try
            {
                var dt = data.KhachHang.GetChanges() as CRMData.KhachHangDataTable;
                if (dt != null)
                {
                    khachHangTableAdapter.Update(dt);
                    data.KhachHang.AcceptChanges();
                }

                var d2 = data.TuVan.GetChanges() as CRMData.TuVanDataTable;
                if (d2 != null)
                {
                    tuVanTableAdapter1.Update(d2);
                    data.TuVan.AcceptChanges();
                }

                MaKH = MaKHTextEdit.Text;
                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowErrorDialog(ex.Message);
                return false;
            }

        
        }

        bool ValidateKH()
        {
            dataLayoutControl1.Validate();

            if (TenKHTextEdit.Text == string.Empty)
            {
                TenKHTextEdit.ErrorText = "Không được trống";
                return false;
            }
            //if (SoDTTextEdit.Text == string.Empty)
            //{
            //    SoDTTextEdit.ErrorText = "Không được trống";
            //    return false;
            //}
            //...

            //Nếu số điện thoại # null thì check xem có trùng không?
            if (!string.IsNullOrEmpty(SoDTTextEdit.Text))
            {
                var list = khachHangTableAdapter.GetDataBySoDT(string.Format("%{0}%", SoDTTextEdit.Text), MaKHTextEdit.Text);
                if (list.Count > 0)
                {
                    string listMaKH = string.Empty;
                    foreach (var k in list)
                    {
                        listMaKH = string.Format("{0}-{1}\n", k.MaKH, k.TenKH);
                    }

                    SoDTTextEdit.ErrorText = "Số điện thoại này đã đăng ký bởi khách hàng khác\n" + listMaKH;
                    return false;
                }
            }


            if (UploadAnh() == false) return false;

            return true;
        }


        protected override bool OnSave()
        {
            if (LuuKhachHang())
                DialogResult = System.Windows.Forms.DialogResult.OK;

            return false;
        }
        protected override bool OnDelete()
        {
            if (MsgBox.ShowYesNoDialog("Bạn có chắc muốn xóa những dòng này?") == System.Windows.Forms.DialogResult.No) return false;

            khachHangBindingSource.RemoveCurrent();
            if (OnSave() == false)
            {
                OnReload();
                return false;
            }

          

            DialogResult = System.Windows.Forms.DialogResult.OK;
            return true;
        }

        private void SoDTTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            SoDTTextEdit.ErrorText = string.Empty;
        }


        bool UploadAnh()
        {
            if (string.IsNullOrEmpty(_fileSource))
                return true;

            try
            {
                //File.Copy(_fileSource, _fileDes, true);
                Utils.SaveResizeImage(Image.FromFile(_fileSource), 200, _fileDes);
                return true; ;

            }
            catch (Exception ex)
            {
                MsgBox.ShowErrorDialog(ex.Message);
                return false;
            }
        }

        string _fileDes = string.Empty;
        string _fileSource = string.Empty;
        private void AnhTextEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            //op.Filter = "jpg";
            if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _fileSource = op.FileName;
                string path = Param.GetValue<string>("Đường dẫn Hình ảnh", "Hệ thống", @"\\192.168.198.100\Scan Xerox\Test");

                string fileName = MaKHTextEdit.Text + "_" + DateTime.Now.ToString("yyyyMMddmmssffff") + ".jpg";
                _fileDes = string.Format("{0}\\{1}", path, fileName);

                AnhTextEdit.Text = fileName;
                pictureEdit1.EditValue = Image.FromFile(op.FileName);
                
            }
        }

        private void NhomKHTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!NhomKHTextEdit.IsModified) return;

            NhomKHTextEdit.ErrorText = string.Empty;
            if (treeListLookUpEdit1TreeList.FocusedNode == null) return;
            if (treeListLookUpEdit1TreeList.FocusedNode.HasChildren)
            {

                NhomKHTextEdit.EditValue = null;
                NhomKHTextEdit.ErrorText = "Chọn nhóm con";
                return;
            }


            var lstNhomKH = (nhomKHBindingSource.DataSource) as CRMData;
            var nhomKH = lstNhomKH.NhomKH.FindByID((int)NhomKHTextEdit.EditValue);
       
            btnTaoLichKHTN.Enabled = nhomKH.ParentID == 16; //cheat
        }

        private void treeListLookUpEdit1TreeList_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if (e.Node.HasChildren)
            {
                e.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                e.Appearance.Options.UseTextOptions = true;
            }
        }

        private void btnTaoLichKHTN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MaKHTextEdit.EditValue == null || MaKHTextEdit.EditValue == DBNull.Value) return;
            if (ValidateKH() == false) return;
            
            
            data.TuVan.Clear();
        
            var t2 = data.TuVan.NewTuVanRow();
            t2.ID = Guid.NewGuid().ToString();
            t2.NhanVien = HeThong.NguoiDungDangNhap.TenDangNhap;
            t2.NoiDung = string.Format("Gọi tư vấn khách hàng tiềm năng");
            int soNgay = Convert.ToInt32(Param.GetValue<string>("Số ngày hẹn cho KH tiềm năng", "Tham số ngày hẹn", "10"));
            var ngayhen = Utils.TinhNgay(DateTime.Today, soNgay);
            t2.NgayHen = new DateTime(ngayhen.Year, ngayhen.Month, ngayhen.Day, 9, 0, 0);
            t2.NgayTao = DateTime.Now;
            t2.KhachHang = MaKHTextEdit.EditValue.ToString();
           
            t2.HinhThuc = (int)HinhThucLienLac.GoiDi;

            t2.Loai = "TVMH";
            t2.NgayCapNhat = DateTime.Now;

            data.TuVan.AddTuVanRow(t2);

            MsgBox.ShowSuccessfulDialog(string.Format("Lịch hẹn tư vấn cho KH tiềm năng {0} vào [{1:dd/MM/yyyy HH:mm}] được tạo thành công", TenKHTextEdit.Text, t2.NgayHen));

        }

        //double click lên tư vấn treo
        private void customGridView4_DoubleClick(object sender, EventArgs e)
        {
            var tv = customGridView4.GetFocusedDataRow() as CRMData.TuVanRow;
            if (tv == null) return;
            if (tv.TrangThai != (int)TrangThaiTuVan.Pending) return;
            FrmThongTinTuVan f = new FrmThongTinTuVan(tv.ID);
            f.ShowDialog();
        }

        private void btnAddTV_Click(object sender, EventArgs e)
        {
            var k = data.KhachHang.FirstOrDefault();
            if (k == null) return;

            if (Data.IsNewRow(k))
            {
                MsgBox.ShowWarningDialog("Khách hàng chưa được tạo, không thể thực hiện thao tác này");
                return;
            }

            FrmThongTinTuVan f = new FrmThongTinTuVan(string.Empty);
         
            f.SetKhachHang(k.MaKH);
            if(f.ShowDialog()==DialogResult.OK)
                customGridControl4.DataSource = tuVanTableAdapter1.GetDataByKhachHang(_maKH);
        }

        private void btnMuaHang_Click(object sender, EventArgs e)
        {
           
            var k = data.KhachHang.FirstOrDefault();
            if (k == null) return;
            if (Data.IsNewRow(k))
            {
                MsgBox.ShowWarningDialog("Khách hàng chưa được tạo, không thể thực hiện thao tác này");
                return;
            }

            FrmThongTinPhieuDH f = new FrmThongTinPhieuDH(string.Empty, k.MaKH);
        
            f.ChucNang = "btnPhieuDatHang";
            if(f.ShowDialog()==DialogResult.OK)
                customGridControl1.DataSource = lichSuMuaHangTableAdapter.GetData(_maKH);            
        }

        private void btnTraHang_Click(object sender, EventArgs e)
        {
            var k = data.KhachHang.FirstOrDefault();
            if (k == null) return;
            if (Data.IsNewRow(k))
            {
                MsgBox.ShowWarningDialog("Khách hàng chưa được tạo, không thể thực hiện thao tác này");
                return;
            }

            FrmThongTinPhieuTH f = new FrmThongTinPhieuTH(string.Empty, k.MaKH);

            f.ChucNang = "btnPhieuTraHang";
            if(f.ShowDialog()==DialogResult.OK)
                customGridControl2.DataSource = lichSuTraHangTableAdapter.GetData(_maKH);
        }
    }
}
