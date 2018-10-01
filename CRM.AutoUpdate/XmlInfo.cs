using System;
using System.Windows.Forms;

namespace Lotus.AutoUpdate
{
    public class XmlInfo
    {
        public string AppCode { get; set; }
        public string AppName { get; set; }
        public Version XmlVersion { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string KichThuocFile { get; set; }
        public string GhiChu { get; set; }
        public string TenFile { get; set; }
        public string DiaChiFile { get; set; }

        public string DiaChiLuu
        {
            get { return string.Format("{0}\\{1}", Application.StartupPath, TenFile); }
        }
    }
}