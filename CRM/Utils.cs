using Lotus;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace CRM
{
    public class Utils
    {

        static DateTime LayNgayCNDauTuan(DateTime d)
        {
            DateTime date = d;
            while (date.DayOfWeek != DayOfWeek.Sunday)
            {
                date = d.AddDays(-1);
            }

            return date;
        }

        public static void SinhLichHenBaoSinhNhatKH()
        {
            bool auto = Param.GetValue<bool>("Tự động sinh lịch báo sinh nhật khách", "Hệ thống", false);
            if (auto == false) return;


            var khAD = new CRMDataTableAdapters.KhachHangTableAdapter();

            var lstKhachHang = new CRMData.KhachHangDataTable();
            var d1 = DateTime.Today;
            var d2 = DateTime.Today.AddDays(14);

            var day = d1;
            
            while (day <= d2)
            {
                day = day.AddDays(1);
                // tim khach có day(sinh nhat) = day.Day and month(sinhnhat) = day.Month
                // add vo list
                // code di, ok đó

                var list = khAD.GetKHNgaysinh(day.Day, day.Month);
                lstKhachHang.Merge(list);
            }

            // duyet list khach hàng, tao ra 2 tuvan (truoc ngày và dung ngày sinh nhat)





            var d = DateTime.Today.AddDays(14).Date;
           


          

            var tvAD = new CRMDataTableAdapters.TuVanTableAdapter();
            
            var dtTuVan = new CRMData.TuVanDataTable();
            
            tvAD.Fill(dtTuVan);

          
            //var lishKH = khAD.GetKHNgaysinh (d.Day, d.Month);
            foreach (var k in lstKhachHang)
            {
                var ngayhen = new DateTime(DateTime.Today.Year, k.NgaySinh.Month, k.NgaySinh.Day, 9, 0, 0);
                var tv = dtTuVan.Where(x => x.KhachHang == k.MaKH && x.Loai == "CMSN" && x.NgayHen.Date == ngayhen.Date).FirstOrDefault();
                if (tv == null)
                {
                    var t = dtTuVan.NewTuVanRow();
                    t.ID = Guid.NewGuid().ToString();
                    t.NgayTao = DateTime.Now;
                    t.KhachHang = k.MaKH;
                    t.NgayHen = ngayhen;

                    if (!k.IsNVBHNull())
                        t.NhanVien = k.NVBH;
                    t.Loai = "CMSN";
                    t.NgayCapNhat = DateTime.Now;
                    t.NoiDung = string.Format("Nhắn tin/Gọi điện thoại chúc mừng sinh nhật khách hàng {0} vào ngày {1:dd/MM}", k.TenKH, k.NgaySinh);
                    //...
                    // gán gì giờ
                    dtTuVan.AddTuVanRow(t);
                }

                //-----
                d = k.NgaySinh.AddDays(-14);
                DateTime x1 = new DateTime(DateTime.Today.Year, d.Month, d.Day);
                if (x1.Date < DateTime.Today)
                {
                    d = DateTime.Today;
                }

                ngayhen = new DateTime(DateTime.Today.Year, d.Month, d.Day, 9, 0, 0);
                var tv1 = dtTuVan.Where(x => x.KhachHang == k.MaKH && x.Loai == "LLCMSN" && x.NgayHen.Date == ngayhen.Date).FirstOrDefault();
                if (tv1 == null)
                {
                    var t = dtTuVan.NewTuVanRow();
                    t.ID = Guid.NewGuid().ToString();
                    t.NgayTao = DateTime.Now;
                    t.KhachHang = k.MaKH;
                    t.NgayHen = ngayhen;

                    if (!k.IsNVBHNull())
                        t.NhanVien = k.NVBH;
                    t.Loai = "LLCMSN";
                    t.NgayCapNhat = DateTime.Now;
                    t.NoiDung = string.Format("Liên hệ chúc mừng sinh nhật khách hàng {0} vào ngày {1:dd/MM}", k.TenKH, k.NgaySinh);
                    //...
                    // gán gì giờ
                    dtTuVan.AddTuVanRow(t);
                }
            }

            try
            {
                tvAD.Update(dtTuVan);
            }
            catch (Exception ex)
            {
                Lotus.MsgBox.ShowErrorDialog(ex.Message);
            }
        }

        public static bool SaveResizeImage(Image img, int width, string path)
        {
            try
            {
                // lấy chiều rộng và chiều cao ban đầu của ảnh
                int originalW = img.Width;
                int originalH = img.Height;
                // lấy chiều rộng và chiều cao mới tương ứng với chiều rộng truyền vào của ảnh (nó sẽ giúp ảnh của chúng ta sau khi resize vần giứ được độ cân đối của tấm ảnh
                int resizedW = width;
                int resizedH = (originalH * resizedW) / originalW;
                Bitmap b = new Bitmap(resizedW, resizedH);
                Graphics g = Graphics.FromImage((Image)b);
                g.InterpolationMode = InterpolationMode.Bicubic;    // Specify here
                g.DrawImage(img, 0, 0, resizedW, resizedH);
                g.Dispose();
                b.Save(path);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static DateTime TinhNgay(DateTime TuNgay, int soNgay)
        {
            // trả ra ngày hen hop ly
            // neu ngày hen là chủ nhat
            // next 1 ngày, nếu ngày này có trong lich nghi, next tiep

            DateTime dNgayHen = TuNgay.AddDays(soNgay);
            var lichNghi = new CRMDataTableAdapters.LichNghiTableAdapter().GetData();
            var find = lichNghi.FirstOrDefault(t => t.Ngay.Date == dNgayHen.Date);
            if (find == null) return dNgayHen;

            //DateTime d = ngayHen;          
            while(find!=null)
            {
                dNgayHen = dNgayHen.AddDays(1);
                find = lichNghi.FirstOrDefault(t => t.Ngay.Date == dNgayHen.Date);
            }

            return dNgayHen;
        }
    }
}
