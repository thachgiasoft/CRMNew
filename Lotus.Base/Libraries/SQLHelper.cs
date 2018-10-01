using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Lotus.Libraries
{
    public class SQLHelper
    {
        /// <summary>
        /// 200
        /// </summary>
        const int CMD_TIMEOUT = 200;

        #region Properties
        static string strConn;
        public static string Connectionstring
        {
            get { return strConn; }
            set { strConn = value; }
        }
        #endregion


        public static DataTable ExecuteDataTable(string commandText)
        {
            return ExecuteDataTable(strConn, CommandType.Text, commandText, null);
        }
        public static DataTable ExecuteDataTable(string connection, string commandText)
        {
            return ExecuteDataTable(connection, CommandType.Text, commandText, null);
        }
        public static DataTable ExecuteDataTable(string spName, params SqlParameter[] commandParameters)
        {
            return ExecuteDataTable(strConn, CommandType.StoredProcedure, spName, commandParameters);
        }
        public static DataTable ExecuteDataTable(string connection, string spName, params SqlParameter[] commandParameters)
        {
            return ExecuteDataTable(connection, CommandType.StoredProcedure, spName, commandParameters);
        }
        public static DataTable ExecuteDataTable(string connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (connection == string.Empty)
                connection = strConn;

            SqlCommand cmd = new SqlCommand(commandText, new SqlConnection(connection));
            cmd.CommandType = commandType;
            cmd.CommandTimeout = CMD_TIMEOUT;

            if (commandParameters != null)
                for (int i = 0; i < commandParameters.Length; i++)
                {
                    cmd.Parameters.Add(commandParameters[i]);
                }

            cmd.Connection.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                try
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Parameters.Clear();
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("expects parameter"))
                        MsgBox.ShowWarningDialog("Khai báo tham số câu truy vấn không hợp lệ");
                    return null;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }

        }

        #region ExecuteDataset

        /// <summary>
        /// Thực thi câu truy vấn lấy ra dataset
        /// </summary>
        /// <param name="commandText">Câu truy vấn (dạng text)</param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string commandText)
        {
            return ExecuteDataset(strConn, CommandType.Text, commandText, null);
        }

        /// <summary>
        /// Thực thi câu truy vấn lấy ra dataset
        /// </summary>
        /// <param name="connection">connection string</param>
        /// <param name="commandText">Câu truy vấn (dạng text)</param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string connection, string commandText)
        {
            return ExecuteDataset(connection, CommandType.Text, commandText, null);
        }

        /// <summary>
        /// Thực thi câu truy vấn bằng StoredProcedure lấy ra dataset
        /// </summary>
        /// <param name="spName">Tên StoredProcedure</param>
        /// <param name="commandParameters">
        /// Ví dụ: 
        ///        DataSet ds = ExecuteDataset(spName, new SqlCommand("@param1", 10), new SqlCommand("@param2", "001"), ... );
        /// </param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string spName, params SqlParameter[] commandParameters)
        {
            return ExecuteDataset(strConn, CommandType.StoredProcedure, spName, commandParameters);
        }

        /// <summary>
        /// Thực thi câu truy vấn bằng StoredProcedure lấy ra dataset
        /// </summary>
        /// <param name="connection">connection string</param>
        /// <param name="spName">Tên StoredProcedure</param>
        /// <param name="commandParameters">
        /// Ví dụ: 
        ///        DataSet ds = ExecuteDataset(spName, new SqlCommand("@param1", 10), new SqlCommand("@param2", "001"), ... );
        /// </param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string connection, string spName, params SqlParameter[] commandParameters)
        {
            return ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters);
        }

        /// <summary>
        /// Thực thi câu truy vấn lấy ra dataset
        /// </summary>
        /// <param name="connection">connection string</param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters">
        /// Ví dụ: 
        ///        DataSet ds = ExecuteDataset(spName, new SqlCommand("@param1", 10), new SqlCommand("@param2", "001"), ... );
        /// </param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (connection == string.Empty)
                connection = strConn;

            SqlCommand cmd = new SqlCommand(commandText, new SqlConnection(connection));
            cmd.CommandType = commandType;
            cmd.CommandTimeout = CMD_TIMEOUT;

            if (commandParameters != null)
                for (int i = 0; i < commandParameters.Length; i++)
                {
                    cmd.Parameters.Add(commandParameters[i]);
                }

            cmd.Connection.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                try
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    cmd.Parameters.Clear();
                    return ds;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("expects parameter"))
                        MsgBox.ShowWarningDialog("Khai báo tham số câu truy vấn không hợp lệ");
                    return null;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
           
        }

        #endregion

        #region ExecuteNonQuery

        /// <summary>
        /// Thực thi câu truy vấn
        /// </summary>
        /// <param name="commandText">Câu truy vấn (dạng text)</param>
        /// <returns></returns>
        /// 
        public static int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(strConn, CommandType.Text, commandText, null);
        }

        /// <summary>
        /// Thực thi câu truy vấn
        /// </summary>
        /// <param name="connection">connection string</param>
        /// <param name="commandText">câu truy vấn (dạng text)</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connection, string commandText)
        {
            return ExecuteNonQuery(connection, CommandType.Text, commandText, null);
        }

        /// <summary>
        /// Thực thi câu truy vấn
        /// </summary>
        /// <param name="spName">Tên StoredProcedure</param>
        /// <param name="commandParameters">
        /// Ví dụ: 
        ///     int result = ExecuteNonQuery(conn, commandType, "SPNAME", new SqlCommand("@param1", 10), new SqlCommand("@param2", "001"), ...);
        /// </param>
        /// </param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string spName, params SqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(strConn, CommandType.StoredProcedure, spName, commandParameters);
        }

        /// <summary>
        /// Thực thi câu truy vấn
        /// </summary>
        /// <param name="connection">connection string</param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters">
        /// Ví dụ: 
        ///     int result = ExecuteNonQuery(conn, commandType, "SPNAME", new SqlCommand("@param1", 10), new SqlCommand("@param2", "001"), ...);
        /// </param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (connection == string.Empty)
                connection = strConn;

            SqlCommand cmd = new SqlCommand(commandText, new SqlConnection(connection));
            cmd.CommandType = commandType;
            cmd.CommandTimeout = CMD_TIMEOUT;

            if (commandParameters != null)
                for (int i = 0; i < commandParameters.Length; i++)
                    cmd.Parameters.Add(commandParameters[i]);

            cmd.Connection.Open();
            int returnValue;
            try
            {
                returnValue = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                returnValue = -1;
            }
            cmd.Connection.Close();
            return returnValue;
        }

        #endregion

        #region FillDataset

        /// <summary>
        /// Fill dataset
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableNames"></param>
        public static void FillDataset(string commandText, DataSet dataSet, string[] tableNames)
        {
            FillDataset(strConn, CommandType.Text, commandText, dataSet, tableNames, null);
        }

        /// <summary>
        /// Fill dataset
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="commandText"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableNames"></param>
        public static void FillDataset(string connection, string commandText, DataSet dataSet, string[] tableNames)
        {
            FillDataset(connection, CommandType.Text, commandText, dataSet, tableNames, null);
        }

        /// <summary>
        /// Fill dataset
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableNames"></param>
        /// <param name="commandParameters">
        /// Ví dụ: 
        ///      FillDataset(connStr, commandType, "SPNAME", dataSet, new string[]{"TableName"}, new FbParameter("@param1", 10), new FbParameter("@param2", "001"), ...);
        /// </param>
        public static void FillDataset(string spName, DataSet dataSet, string[] tableNames, params SqlParameter[] commandParameters)
        {
            FillDataset(strConn, CommandType.StoredProcedure, spName, dataSet, tableNames, commandParameters);
        }

        /// <summary>
        /// Fill dataset
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="spName"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableNames"></param>
        /// <param name="commandParameters">
        /// Ví dụ: 
        ///      FillDataset(connStr, commandType, "SPNAME", dataSet, new string[]{"TableName"}, new FbParameter("@param1", 10), new FbParameter("@param2", "001"), ...);
        /// </param>
        public static void FillDataset(string connection, string spName, DataSet dataSet, string[] tableNames, params SqlParameter[] commandParameters)
        {
            FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames, commandParameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection">connection string</param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="dataSet"></param>
        /// <param name="tableNames"></param>
        /// <param name="commandParameters">
        /// Ví dụ: 
        ///      FillDataset(connStr, commandType, "SPNAME", dataSet, new string[]{"TableName"}, new FbParameter("@param1", 10), new FbParameter("@param2", "001"), ...);
        /// </param>
        public static void FillDataset(string connection, CommandType commandType
                            , string commandText, DataSet dataSet, string[] tableNames
                            , params SqlParameter[] commandParameters)
        {
            if (connection == string.Empty)
                connection = strConn;
            if (dataSet == null) throw new ArgumentNullException("dataSet");

            SqlCommand cmd = new SqlCommand(commandText, new SqlConnection(connection));
            cmd.CommandType = commandType;
            cmd.CommandTimeout = CMD_TIMEOUT;

            if (commandParameters != null)
                for (int i = 0; i < commandParameters.Length; i++)
                    cmd.Parameters.Add(commandParameters[i]);

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
            {
                if (tableNames != null && tableNames.Length > 0)
                {
                    string tableName = "Table";
                    for (int index = 0; index < tableNames.Length; index++)
                    {
                        if (tableNames[index] == null || tableNames[index].Length == 0) throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames");
                        dataAdapter.TableMappings.Add(tableName, tableNames[index]);
                        tableName += (index + 1).ToString();
                    }
                }
                try
                {
                    dataAdapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                cmd.Parameters.Clear();
            }
        }

        #endregion





        public static object ExecuteScalar(string spName, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(strConn, CommandType.StoredProcedure, spName, commandParameters);
        }
        public static object ExecuteScalar(string connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (connection == string.Empty)
                connection = strConn;

            SqlCommand cmd = new SqlCommand(commandText, new SqlConnection(connection));
            cmd.CommandType = commandType;
            cmd.CommandTimeout = CMD_TIMEOUT;

            if (commandParameters != null)
                for (int i = 0; i < commandParameters.Length; i++)
                    cmd.Parameters.Add(commandParameters[i]);


            cmd.Connection.Open();
             object obj = cmd.ExecuteScalar();
            cmd.Connection.Close();

            return obj;
        }

        public static T ExecuteScalar<T>(string cmdText)
        {
            return ExecuteScalar<T>(strConn, CommandType.Text, cmdText, null);
        }
        
        public static T ExecuteScalar<T>(string spName, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar<T>(strConn, CommandType.StoredProcedure, spName, commandParameters);
        }
        public static T ExecuteScalar<T>(string connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (connection == string.Empty)
                connection = strConn;

            SqlCommand cmd = new SqlCommand(commandText, new SqlConnection(connection));
            cmd.CommandType = commandType;
            cmd.CommandTimeout = CMD_TIMEOUT;

            if (commandParameters != null)
                for (int i = 0; i < commandParameters.Length; i++)
                    cmd.Parameters.Add(commandParameters[i]);


            cmd.Connection.Open();
            object obj = cmd.ExecuteScalar();
            cmd.Connection.Close();
            cmd.Dispose();
            cmd = null;

            return obj == DBNull.Value || obj == null ? default(T) : (T)Convert.ChangeType(obj, typeof(T));
        }

        public static object ExecuteScalar(string commandText)
        {
            return ExecuteScalar(strConn, CommandType.Text, commandText, null);
        }


      

        public static bool ExecuteSqlFromFile(string sqlFile)
        {
            using (SqlConnection connection = new SqlConnection(Connectionstring))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MsgBox.ShowErrorDialog("Không kết nối được cơ sở dữ liệu");
                    WriteLogText(ex.Message);
                    return false;
                }

                string sql = string.Empty;
                using (FileStream strm = File.OpenRead(sqlFile))
                {
                    StreamReader reader = new StreamReader(strm);
                    sql = reader.ReadToEnd();
                }

                Regex regex = new Regex("^GO", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                string[] lines = regex.Split(sql);
                SqlTransaction transaction = connection.BeginTransaction();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            cmd.CommandText = line;
                            cmd.CommandType = CommandType.Text;

                            try
                            {
                                cmd.ExecuteNonQuery();
                                WriteLogText(string.Format("DONE\n{0}", line));
                            }
                            catch (SqlException ex)
                            {
                                WriteLogText(string.Format("ERROR\n{0}", line));
                                WriteLogText(ex.Message);
                                transaction.Rollback();
                                return false;
                            }
                        }
                    }
                }

                transaction.Commit();
                connection.Close();
                return true;
            }

        }
        private static void WriteLogText(string description)
        {
            using (StreamWriter sw = new StreamWriter(Application.StartupPath + "\\updateLog.txt", true, System.Text.Encoding.Unicode))
            {
                string str = string.Format("{0:dd/MM/yyyy hh:mm:ss tt}\t:\t{1}", DateTime.Now, description);
                sw.WriteLine(str);
            }
        }
    }
}
