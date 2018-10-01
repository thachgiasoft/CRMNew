using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CRM
{
    public enum TrangThaiPhieuDat
    {
        [Description("Đang xử lý")]
        Pending = 0,
        [Description("Hoàn thành")]
        Done = 1,
        [Description("Đã huỷ")]
        Deny = 2,
    }

    public enum TrangThaiTuVan
    {
        [Description("Đang xử lý")]
        Pending = 0,
        [Description("Hoàn thành")]
        Done = 1,
        [Description("Đã huỷ")]
        Deny = 2,
    }

    public enum HinhThucLienLac
    {
        [Description("Gọi đi")]
        GoiDi = 0,
        [Description("Gọi đến")]
        GoiDen = 1,        
    }


    public enum EditMode
    {
        [Description("Thêm")]
        Add = 0,
        [Description("Sửa")]
        Edit = 1,
    }
}
