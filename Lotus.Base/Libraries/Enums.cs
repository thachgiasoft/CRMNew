using System.ComponentModel;
namespace Lotus.Libraries
{
    public enum AlertType
    {
        Done = 0,
        Error = 1,
        Info = 2
    }

    public enum ChucDanh
    {
        [Description("Nhân viên kinh doanh")]
        NVKinhDoanh = 0,
        [Description("Nhân viên vận đơn")]
        NVVanDon = 1,
        [Description("Quản lý")]
        QuanLy = 2,
        [Description("Admin")]
        Admin = 3,
    }
}