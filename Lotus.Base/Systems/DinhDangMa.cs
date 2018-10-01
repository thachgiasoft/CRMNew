
using Lotus.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Lotus.Base.Systems
{
    public class DinhDangMa
    {
        public static string LayMaTuDong(string tenBang, string key, string dinhdangMacDinh, DataTable dt_tmp)
        {
            string dinhDang = dinhdangMacDinh;
           
            int soDong = dt_tmp.Rows.Count;
            int maHienTai = soDong ;
            if (maHienTai == 0)
                ++maHienTai;
            string ma = string.Format(dinhDang, maHienTai);
            DataRow[] rows = dt_tmp.Select(string.Format("{0} = '{1}'", key, ma));

            while (rows.Length > 0)
            {
                ma = string.Format(dinhDang, ++maHienTai);
                rows = dt_tmp.Select(string.Format("{0} = '{1}'", key, ma));
            }


            return ma;
        }


       


        public static string LayMaDinhLuong(string loaiSP, DataTable dt_tmp)
        {
            int soDong = dt_tmp.Rows.Count;
            int maHienTai = soDong;

            string ma = string.Format("{0}_{1:d3}", loaiSP, ++maHienTai);

            DataRow[] rows = dt_tmp.Select(string.Format("MaDinhLuong = '{0}'", ma));

            while (rows.Length > 0)
            {
                ma = string.Format("{0}_{1:d3}", loaiSP, ++maHienTai);
                rows = dt_tmp.Select(string.Format("MaDinhLuong = '{0}'", ma));
            }
            
            return ma;
        }






        public static string LayMaNV()
        {
            int nextNumber = SQLHelper.ExecuteScalar<int>("SELECT count(MaNV) FROM NhanVien") + 1;

            string dinhdang = Param.GetValue<string>("Mã nhân viên", "Định dạng mã không lặp", "NV{0:d7}");

            string ma = string.Format(dinhdang, nextNumber);
            while (HeThong.Exits("NhanVien", "MaNV", ma))
                ma = string.Format(dinhdang, nextNumber++);

            return ma;
        }

        public static string LayMaTuDong(string CotMa, string TableName, string dinhdang)
        {
            string sql = string.Format("select count({0}) from {1}", CotMa, TableName);
            int nextNumber = SQLHelper.ExecuteScalar<int>(sql) + 1;

            string ma = string.Format(dinhdang, nextNumber);
            while (HeThong.Exits(TableName, CotMa, ma))
                ma = string.Format(dinhdang, nextNumber++);

            return ma;
        }

        public static string LaySoPhieu(string CotMa, string TableName, string cotNgay, string dinhdang, DateTime d)
        {
            string sql = string.Format("select count({0}) from {1} where month({2}) = {3} and year({2}) = {4}", CotMa, TableName, cotNgay, d.Month, d.Year);
            int nextNumber =0;

            nextNumber = SQLHelper.ExecuteScalar<int>(sql);
            if (nextNumber == 0)
                nextNumber = 1;
            else
                nextNumber++;

            //"DH{0:d7}{1:ddMMyyHHmmss}"
            // cho này hơi chuối ke bà nó
            string ma = string.Format(dinhdang, nextNumber, d);
            while (HeThong.Exits(TableName, CotMa, ma))
                ma = string.Format(dinhdang, nextNumber++, d);

            return ma;
        }
       
    }
}
