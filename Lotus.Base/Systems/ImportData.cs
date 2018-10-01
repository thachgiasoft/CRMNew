using System;
using System.Data;
using System.Data.OleDb;
using DevExpress.Xpo;
using System.Linq;
using DevExpress.Data.Filtering;
using Lotus;


namespace Lotus.Systems
{
    public class ImportData
    {
        private static DataTable GetExcelTable(string fileName, string sheetName)
        {
            return GetExcelTable(fileName, sheetName, string.Empty);
        }

        private static DataTable GetExcelTable(string fileName, string sheetName, string sql)
        {
            sheetName = sheetName.Replace(".", "#");
            if (sql == string.Empty)
                sql = string.Format("select * from [{0}$]", sheetName);

            var strConn = string.Empty;
            if (fileName.Contains(".xlsx"))
            {
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                          + fileName + ";Extended Properties=\"Excel 12.0;HDR=YES\";";
            }
            else if (fileName.Contains(".xls"))
            {
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                          "Data Source=" + fileName + ";Extended Properties=Excel 8.0;";
            }
            var dt = new DataTable();
            try
            {
                var oleConn = new OleDbConnection(strConn);
                var oleCmd = new OleDbDataAdapter(sql, strConn);
                oleCmd.Fill(dt);
            }
            catch (Exception ex)
            {
                MsgBox.ShowWarningDialog("Không import được file");
                Console.WriteLine(ex.Message);

                return null;
            }
            //if (dt != null)
            //    foreach (DataRow dr in dt.Rows)
            //        dr[0] = Convert.ToString(dr[0]).Replace("&", "");

            return dt;
        }

     

      
    }
}