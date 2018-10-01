using DevExpress.XtraEditors;
using Lotus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRM.Dictionaries
{
    public partial class FrmTaoPhieuGiamGiaTuDong : XtraForm
    {
        CRMData.PhieuGiamGiaDataTable _table;
        public FrmTaoPhieuGiamGiaTuDong(CRMData.PhieuGiamGiaDataTable table)
        {
            InitializeComponent();

            _table = table;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string dinhdang = Param.GetValue<string>("Phiếu giảm giá", "Định dạng mã", "V{0:d7}");
            for (int i = 0; i < spinSoLuong.Value; i++)
            {
                var p = _table.NewPhieuGiamGiaRow();
                p.SoPhieu = Lotus.Base.Systems.DinhDangMa.LayMaTuDong(_table.TableName, "SoPhieu", dinhdang, _table);
                p.NoiDung = txtNoiDung.Text;
                p.GiaTri = (double)calcGiaTri.Value;
                p.NgayPhatHanh = dateNgayPhatHanh.DateTime;
                p.NgayHetHan = dateNgayKetThuc.DateTime;

                _table.AddPhieuGiamGiaRow(p);
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
