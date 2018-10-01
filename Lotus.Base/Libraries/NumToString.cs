using System;
using System.Globalization;

namespace Lotus
{
    //
    // code internet, chưa đọc được số lẻ và số âm
    //

    public class NumToString
    {
        //Đọc số hàng chục
        private static readonly string[] mangso =
        {
            "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám",
            "chín"
        };

        private static string dochangchuc(decimal so, bool daydu)
        {
            var chuoi = "";
            var chuc = (int)Math.Floor(so / 10);
            var donvi = (int)so % 10;
            if (chuc > 1)
            {
                chuoi = " " + mangso[chuc] + " mươi";
                if (donvi == 1)
                    chuoi += " mốt";
            }
            else if (chuc == 1)
            {
                chuoi = " mười";
                if (donvi == 1)
                    chuoi += " một";
            }
            else if (daydu && donvi > 0)
                chuoi = " lẻ";
            if (donvi == 5 && chuc >= 1)
                chuoi += " lăm";
            else if (donvi > 1 || (donvi == 1 && chuc == 0))
                chuoi += " " + mangso[donvi];

            return chuoi;
        }

        //Đọc block 3 số
        private static string docblock(decimal so, bool daydu)
        {
            var chuoi = "";
            var tram = (int)Math.Floor(so / 100);
            so = so % 100;
            if (daydu || tram > 0)
            {
                chuoi = " " + mangso[tram] + " trăm";
                chuoi += dochangchuc(so, true);
            }
            else
                chuoi = dochangchuc(so, false);

            return chuoi;
        }

        //Đọc số hàng triệu
        private static string dochangtrieu(decimal so, bool daydu)
        {
            var chuoi = "";
            var trieu = (int)Math.Floor(so / 1000000);
            so = so % 1000000;
            if (trieu > 0)
            {
                chuoi = docblock(trieu, daydu) + " triệu";
                daydu = true;
            }
            var nghin = Math.Floor(so / 1000);
            so = so % 1000;
            if (nghin > 0)
            {
                chuoi += docblock(nghin, daydu) + " nghìn";
                daydu = true;
            }
            if (so > 0)
                chuoi += docblock(so, daydu);
            return chuoi;
        }

        //Đọc số
        public static string ReadNumber(decimal so)
        {
            if (so == 0) return mangso[0];
            string chuoi = "", hauto = "";
            do
            {
                var ty = so % 1000000000;
                so = Math.Floor(so / 1000000000);
                if (so > 0)
                    chuoi = dochangtrieu(ty, true) + hauto + chuoi;
                else
                    chuoi = dochangtrieu(ty, false) + hauto + chuoi;
                hauto = " tỷ";
            } while (so > 0);
            try
            {
                if (chuoi.Trim().Substring(chuoi.Trim().Length - 1, 1) == ",")
                    chuoi = chuoi.Trim().Substring(0, chuoi.Trim().Length - 1);
            }
            catch
            {
            }
            chuoi = chuoi.Trim();
            //return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(chuoi + " đồng");

            //return (chuoi + " đồng").ToUpper();

            char c0 = chuoi[0];
            c0 = c0.ToString().ToUpper()[0];
            char[] arr = chuoi.ToCharArray();
            arr[0] = c0;
            string s = new string(arr);

            return s + " đồng";


        }


        public static string SoThanhChu(decimal number)
        {
            var s = number.ToString("#");
            var so = new[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            var hang = new[] { "", "nghìn", "triệu", "tỷ" };
            var str = " ";
            var booAm = false;
            decimal decS = 0;
            //Tung addnew
            try
            {
                decS = Convert.ToDecimal(s);
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString(CultureInfo.InvariantCulture);
                booAm = true;
            }
            var i = s.Length;
            if (i == 0)
                str = so[0] + str;
            else
            {
                var j = 0;
                while (i > 0)
                {
                    var donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    int chuc;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    int tram;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        str = hang[j] + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "một " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "lăm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + " " + str;
                    }
                    if (chuc < 0)
                        break;
                    if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                    if (chuc == 1) str = "mười " + str;
                    if (chuc > 1) str = so[chuc] + " mươi " + str;
                    if (tram < 0) break;
                    if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                    str = " " + str;
                }
            }
            if (booAm) str = "Âm " + str;

            str = string.Format("{0}{1}{2}", str.Trim().Substring(0, 1).ToUpper(), str.Trim().Substring(1), " đồng");
            str = str.Replace("mươi một", "mươi mốt");

            return str;
        }


        public static long LamTron(long soTien, long solamtron)
        {
            if (solamtron <= 0) return soTien;
            return (soTien + solamtron / 2) / solamtron * solamtron;
        }
    }
}