using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using DevExpress.Skins;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using Lotus.Libraries;



namespace Lotus.Base.Systems
{
    public partial class FrmPhanQuyen : FrmBase
    {
        public FrmPhanQuyen()
        {
            InitializeComponent();
            repChucDanh.Items.AddEnum(typeof(ChucDanh), true);
            treeList1.ExpandAll();
            Skin skin = GridSkins.GetSkin(treeList1.LookAndFeel);
            skin.Properties[GridSkins.OptShowTreeLine] = true;

            UseEnableControl = false;
        }
        protected override void OnNew()
        {
            gvNguoiDung.AddNewRow();
            ThongTinNguoiDung();
        }
    
        protected override bool OnSave()
        {
            gvNguoiDung.CloseEditor();
            gvNguoiDung.UpdateCurrentRow();

            treeList1.CloseEditor();
            treeList1.EndCurrentEdit();


            try
            {
                var dt = dATA.NguoiDung.GetChanges() as DATA.NguoiDungDataTable;
                if (dt != null)
                {
                    nguoiDungTableAdapter.Update(dt);
                    dATA.NguoiDung.AcceptChanges();
                }

                var dtPhanQuyen = dATA.PhanQuyen.GetChanges() as DATA.PhanQuyenDataTable;
                if (dtPhanQuyen != null)
                {
                    phanQuyenAD.Update(dtPhanQuyen);
                    dATA.PhanQuyen.AcceptChanges();
                }

                if (HeThong.NguoiDungDangNhap != null)
                    HeThong.NguoiDungDangNhap = nguoiDungTableAdapter.GetDataByTenDangNhap(HeThong.NguoiDungDangNhap.TenDangNhap).FirstOrDefault();

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowErrorDialog(ex.Message);
                return false;
            }


        }
        protected override void OnReload()
        {
         
            this.nguoiDungTableAdapter.Fill(this.dATA.NguoiDung);
          
            chucNangAD.Fill(dATA.ChucNang);
            phanQuyenAD.Fill(dATA.PhanQuyen);
            this.phongBanTableAdapter.Fill(dATA.PhongBan);


            NapDuLieuChucNang();

        }
        protected override bool OnDelete()
        {
            var dlg = MsgBox.ShowYesNoDialog("Bạn có chắc muốn xóa (những) dòng này?");
            if (dlg == System.Windows.Forms.DialogResult.No) return false;

            var selectedRows = gvNguoiDung.GetSelectedRows();
            for (int i = 0; i < selectedRows.Length; i++)
            {
                var row = gvNguoiDung.GetDataRow(selectedRows[i]) as DATA.NguoiDungRow;
                if (row == null) return false;
                if (row.QuanTri)
                {
                    MsgBox.ShowWarningDialog("Không thể xóa người dùng quản trị");
                    return false;
                }

                string tendangnhap = gvNguoiDung.GetRowCellValue(selectedRows[i], "TenDangNhap").ToString();
                string sql = string.Format("delete from PhanQuyen where TenDangNhap = N'{0}'", tendangnhap);
                SQLHelper.ExecuteNonQuery(sql);
            }
            gvNguoiDung.DeleteSelectedRows();

            if (OnSave() == false)
            {
                OnReload();
                return false;
            }
            

            NapDuLieuChucNang();
            return true;
        }
        private void NapDuLieuChucNang()
        {

            var nguoidung = gvNguoiDung.GetFocusedDataRow() as DATA.NguoiDungRow;
            if (nguoidung == null) return;

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("TenChucNang");
            dt.Columns.Add("IdCha", typeof(string));
            dt.Columns.Add("TruyCap", typeof(bool));
            dt.Columns.Add("Them", typeof(bool));
            dt.Columns.Add("Sua", typeof(bool));
            dt.Columns.Add("Xoa", typeof(bool));
            dt.Columns.Add("TatCa", typeof(bool));

            DataRow rAll = dt.NewRow();
            rAll["Id"] = string.Empty;
            rAll["TenChucNang"] = "Tất cả";
            rAll["IdCha"] = string.Empty;
            dt.Rows.Add(rAll);

            bool truycap = true;
            bool them = true;
            bool sua = true;
            bool xoa = true;
            bool tatca = true;

            foreach (DATA.ChucNangRow m in dATA.ChucNang.Rows)
            {
                DataRow row = dt.NewRow();
                row["Id"] = m.MaChucNang;
                row["TenChucNang"] = m.TenChucNang;
                row["IdCha"] = m.ChucNangCha;

                var umf = dATA.PhanQuyen.FirstOrDefault(p => p.TenDangNhap.ToLower() == nguoidung.TenDangNhap.ToLower()
                    && p.MaChucNang == m.MaChucNang);

                row["TruyCap"] = umf == null ? false : umf.TruyCap;
                row["Them"] = umf == null ? false : umf.Them;
                row["Sua"] = umf == null ? false : umf.Sua;
                row["Xoa"] = umf == null ? false : umf.Xoa;
                row["TatCa"] = umf == null ? false : (umf.TruyCap & umf.Them & umf.Sua & umf.Xoa);

                dt.Rows.Add(row);

                truycap &= Convert.ToBoolean(row["TruyCap"]);
                them &= Convert.ToBoolean(row["Them"]);
                sua &= Convert.ToBoolean(row["Sua"]);
                xoa &= Convert.ToBoolean(row["Xoa"]);
                tatca &= Convert.ToBoolean(row["TatCa"]);
            }

            rAll["TruyCap"] = truycap;
            rAll["Them"] = them;
            rAll["Sua"] = sua;
            rAll["Xoa"] = xoa;
            rAll["TatCa"] = tatca;


            dt.AcceptChanges();
            treeList1.DataSource = dt;

            DichTreeChucNang();

            treeList1.ExpandAll();
        }
        private void ThongTinNguoiDung()
        {
            var nguoidung = gvNguoiDung.GetFocusedDataRow() as DATA.NguoiDungRow;
            if (nguoidung == null) return;

          
            var f = new FrmNguoiDung(nguoidung);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OnSave();
            }
            else
                this.nguoiDungTableAdapter.Fill(this.dATA.NguoiDung);


        }
        private void SetCheckedChildNodes(TreeListNode node, TreeListColumn col, bool check)
        {
            if (col == colTatCa)
            {
                node[colTruyCap] = check;
                node[colThem] = check;
                node[colSua] = check;
                node[colXoa] = check;
                node[colTatCa] = check;
            }
            else
            {
                bool allowShow = (bool)node.GetValue(colTruyCap);
                bool allowAddNew = (bool)node.GetValue(colThem);
                bool allowEdit = (bool)node.GetValue(colSua);
                bool allowDelete = (bool)node.GetValue(colXoa);

                node[colTatCa] = allowShow & allowAddNew & allowEdit & allowDelete;
            }
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i][col] = check;
                if (col == colTatCa)
                {
                    node.Nodes[i][colTruyCap] = check;
                    node.Nodes[i][colThem] = check;
                    node.Nodes[i][colSua] = check;
                    node.Nodes[i][colXoa] = check;
                }
                SetCheckedChildNodes(node.Nodes[i], col, check);
            }

        }
        private void SetCheckedParentNodes(TreeListNode node, TreeListColumn col, bool check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                bool state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (bool)node.ParentNode.Nodes[i][col];
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                bool bb = b ? false : check;
                node.ParentNode[col] = bb;

                if (col == colTatCa)
                {
                    node.ParentNode[colTruyCap] = bb;
                    node.ParentNode[colThem] = bb;
                    node.ParentNode[colSua] = bb;
                    node.ParentNode[colXoa] = bb;
                }
                else
                {
                    bool allowShow = (bool)node.ParentNode.GetValue(colTruyCap);
                    bool allowAddNew = (bool)node.ParentNode.GetValue(colThem);
                    bool allowEdit = (bool)node.ParentNode.GetValue(colSua);
                    bool allowDelete = (bool)node.ParentNode.GetValue(colXoa);

                    node.ParentNode[colTatCa] = allowShow & allowAddNew & allowEdit & allowDelete;
                }
                SetCheckedParentNodes(node.ParentNode, col, check);
            }
        }
   




        private void treeList1_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            MsgBox.ShowWaitForm("Đang thực hiện ...");
            var nguoidung = gvNguoiDung.GetFocusedDataRow() as DATA.NguoiDungRow;
            if (nguoidung == null) return;

            e.Node.SetValue(e.Column, e.Value);
            DataRowView rowView = treeList1.GetDataRecordByNode(e.Node) as DataRowView;
            if (rowView != null)
            {
                string machucnang = rowView["Id"].ToString();

                if (e.Column.FieldName.Equals("TatCa"))
                {
                    rowView["TruyCap"] = rowView["Them"] = rowView["Sua"] = rowView["Xoa"] = e.Value;
                }
               

                var quyen = dATA.PhanQuyen.FirstOrDefault(p => p.MaChucNang == machucnang 
                    && p.TenDangNhap.ToLower() == nguoidung.TenDangNhap.ToLower());

                if (quyen == null)
                {
                    quyen = dATA.PhanQuyen.NewPhanQuyenRow();
                    quyen.MaChucNang = machucnang;
                    quyen.TenDangNhap = nguoidung.TenDangNhap;
                    dATA.PhanQuyen.AddPhanQuyenRow(quyen);
                }

                quyen.TruyCap = Convert.ToBoolean(rowView["TruyCap"]);
                quyen.Them = Convert.ToBoolean(rowView["Them"]);
                quyen.Sua = Convert.ToBoolean(rowView["Sua"]);
                quyen.Xoa = Convert.ToBoolean(rowView["Xoa"]);
            }


            SetCheckedChildNodes(e.Node, e.Column, (bool)e.Value);
            SetCheckedParentNodes(e.Node, e.Column, (bool)e.Value);

            MsgBox.CloseWaitForm();

            DataTable dt = treeList1.DataSource as DataTable;
            if (dt == null) return;

            DataTable dtChanges = dt.GetChanges();
            if (dtChanges == null) return;

            foreach (DataRow row in dtChanges.Rows)
            {
                string machucnang = row["Id"].ToString();
                if (string.IsNullOrEmpty(machucnang)) continue;

                var quyen = dATA.PhanQuyen.FirstOrDefault(p => p.MaChucNang == machucnang 
                    && p.TenDangNhap.ToLower() == nguoidung.TenDangNhap.ToLower());

                if (quyen == null)
                {
                    quyen = dATA.PhanQuyen.NewPhanQuyenRow();
                    quyen.MaChucNang = machucnang;
                    quyen.TenDangNhap = nguoidung.TenDangNhap;
                    dATA.PhanQuyen.AddPhanQuyenRow(quyen);
                }


                quyen.TruyCap = Convert.ToBoolean(row["TruyCap"]);
                quyen.Them = Convert.ToBoolean(row["Them"]);
                quyen.Sua = Convert.ToBoolean(row["Sua"]);
                quyen.Xoa = Convert.ToBoolean(row["Xoa"]);
             
            }
           
        }
        private void treeList1_CustomDrawNodeImages(object sender, DevExpress.XtraTreeList.CustomDrawNodeImagesEventArgs e)
        {
            e.SelectImageIndex = e.Node.Level;
            if (e.Node.Level > 4)
                e.SelectImageIndex = 4;
        }
        private void treeList1_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if (e.Node.HasChildren)
            {
                e.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                e.Appearance.Options.UseTextOptions = true;
            }
        }
        
       
        private void gvNguoiDung_DoubleClick(object sender, EventArgs e)
        {
            //var nguoidung = gvNguoiDung.GetFocusedDataRow() as DATA.NguoiDungRow;
            //if (nguoidung == null) return;

            //var f = new FrmNguoiDung(nguoidung);
            //if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    OnSave();
            //}
            ThongTinNguoiDung();
        }
        private void gvNguoiDung_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var nguoidung = gvNguoiDung.GetFocusedDataRow() as DATA.NguoiDungRow;
            if (nguoidung == null) return;

            NapDuLieuChucNang();
        }
       
        private void FrmPhanQuyen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dATA.PhongBan' table. You can move, or remove it, as needed.
            this.phongBanTableAdapter.Fill(this.dATA.PhongBan);
            OnReload();
        }


        private void gvNguoiDung_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (!HeThong.NguoiDungDangNhap.QuanTri) return;

            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                var item = new DevExpress.Utils.Menu.DXMenuItem();

                item.Caption = LanguageHelper.TranslateString("Reset mật khẩu", "Reset mật khẩu");
                item.Click += item_Click;

                e.Menu.Items.Add(item);
            }
        }

        void item_Click(object sender, EventArgs e)
        {
            string default_pass = "hoasen";

            var dlg = MsgBox.ShowYesNoDialog(string.Format("Bạn có chắc muốn reset mật khẩu người dùng này thành mặc định ({0})?", default_pass));
            if (dlg == System.Windows.Forms.DialogResult.No) return;

            var nguoidung = gvNguoiDung.GetFocusedDataRow() as DATA.NguoiDungRow;
            if (nguoidung == null) return;

            nguoidung.MatKhau = HeThong.MaHoaMD5(default_pass);
            OnSave();
        }


        public override void Translate()
        {
            base.Translate();
            DichTreeChucNang();
        }

        private void DichTreeChucNang()
        {
            if (HeThong.DaNgonNgu == false) return;

            foreach (TreeListNode node in treeList1.Nodes)
                foreach (TreeListNode n in node.Nodes)
                    DichNode(n);
         
        }

        void DichNode(TreeListNode node)
        {
            var r = treeList1.GetDataRow(node.Id);

            string id = r["Id"].ToString();
            string idCha = r.IsNull("IdCha") ? string.Empty : r["IdCha"].ToString();
            string tenCN = r["TenChucNang"].ToString();

            string node_id = id;
            TreeListNode n = node.ParentNode;
            while (n != null)
            {
                var p = treeList1.GetDataRow(n.Id);
                node_id = p["Id"].ToString() + "." + node_id;
                n = n.ParentNode;
            }

            string key_lang = Application.OpenForms[0].Name + ".ribbon." + node_id;
            key_lang = key_lang.Replace("..", ".");
            string translate = LanguageHelper.TranslateString(key_lang, tenCN);
            r["TenChucNang"] = translate;

            foreach (TreeListNode c in node.Nodes)
                DichNode(c);
        }

        private void btnResetPWD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var nguoidung = gvNguoiDung.GetFocusedDataRow() as DATA.NguoiDungRow;
            if (nguoidung == null) return;

            if(MsgBox.ShowYesNoDialog(string.Format("Bạn muốn reset mật khẩu cho user: [{0}]?",nguoidung.TenDangNhap))==DialogResult.Yes)
            {
                string defaultPWD = "123456";
                nguoidung.MatKhau = HeThong.MaHoaMD5(defaultPWD);
                MsgBox.ShowSuccessfulDialog(string.Format("Mật khẩu mới của user:[{0}] là {1}", nguoidung.TenDangNhap, defaultPWD));
                OnSave();
            }
            
        }

      

       
   
    }
}
