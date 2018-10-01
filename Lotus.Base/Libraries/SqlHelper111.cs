using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using Lotus.HRM.Libraries;
using DevExpress.Xpo;


namespace Lotus.HRM
{
    public class SqlHelper
    {
        private string m_ConnectString = "";
        private SqlConnection m_Connection;
        private System.Data.CommandType m_CommandType;
        private SqlTransaction m_Transaction;
        private bool m_EnableShowError = true;
        private int m_CommandTimeout = 15;// for internal use

        public SqlHelper() 
        {
            m_ConnectString = XpoDefault.Session.ConnectionString;
        }

        public SqlHelper(string connectionStr)
        {
            m_ConnectString = connectionStr;
        }

        #region properties

        public SqlConnection Connection
        {
            get { return m_Connection; }
        }

        public SqlTransaction Transaction
        {
            get { return m_Transaction; }
        }

        /// <summary>
        /// Default command type is query text
        /// </summary>
        public System.Data.CommandType CommandType
        {
            get { return m_CommandType; }
            set { m_CommandType = value; }
        }

        public string ConnectString
        {
            get { return m_ConnectString; }
        }

        public bool EnableShowError
        {
            get { return m_EnableShowError; }
            set { m_EnableShowError = value; }
        }

        public int CommandTimeout
        {
            get { return m_CommandTimeout; }
        }

        #endregion

        #region tranmission

        public bool Open()
        {
            if (string.IsNullOrEmpty(m_ConnectString))
            {
                ShowError("The connection string has not been established yet");
                return false;
            }

            if (m_Connection != null)
            {
                m_Connection.Close();
                m_Connection = null;
            }

            m_Connection = new SqlConnection(m_ConnectString);
            bool result = false;
            try
            {
                m_Connection.Open();
                result = true;
            }
            catch(Exception err)
            {
                ShowError(err.Message);
            }
            return result;
        }

        public void Close()
        {
            if (m_Connection != null)
            {
                m_Connection.Close();
                m_Connection = null;
            }
        }

        public bool BeginTransaction()
        {
            if (!Open()) return false;
            m_Transaction = m_Connection.BeginTransaction();
            return true;
        }

        public void CommitTransaction()
        {
            if (m_Transaction == null)
            {
                ShowError("Nothing to commit");
                return;
            }

            try
            {
                m_Transaction.Commit();
                Close();
            }
            catch (Exception err)
            {
                RollBack();
                ShowError(err.Message);
            }
        }

        public void RollBack()
        {
            try
            {
                m_Transaction.Rollback();
                Close();
            }
            catch { }
        }
        #endregion

        #region execute

        public bool ExecuteNonQuery(string query)
        {
            if (query == "")
            {
                ShowError("The query command has not been initialized!");
                return false;
            }

            if (!Open()) return false;
            bool result = false;

            SqlCommand m_Command = new SqlCommand(query, m_Connection);
            m_Command.CommandType = m_CommandType;
            m_Command.CommandTimeout = m_CommandTimeout;
            try
            {
                m_Command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
            m_Command.Dispose();
            m_Command = null;
            Close();
            return result;
        }

        public bool ExecuteNonQuery(string query, string[] myparams, object[] myvalues)
        {
            if (query == "")
            {
                ShowError("The query command has not been initialized!");
                return false;
            }

            if (myparams == null || myvalues == null) 
                return ExecuteNonQuery(query);

            if (myparams.Length != myvalues.Length)
            {
                ShowError("The number of parameters does not match with ther numbers of values applied");
                return false;
            }

            if (!Open()) return false;
            bool result = false;

            SqlCommand m_Command = new SqlCommand(query, m_Connection);
            m_Command.CommandType = m_CommandType;
            m_Command.CommandTimeout = m_CommandTimeout;
            for (int i = 0; i < myparams.Length; i++)
                m_Command.Parameters.Add(new SqlParameter(myparams[i], myvalues[i]));
            try
            {
                m_Command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
            m_Command.Dispose();
            m_Command = null;
            Close();
            return result;
        }

        public bool ExecuteNonQuery(SqlTransaction mytrans, string query)
        {
            if (mytrans == null)
            {
                ShowError("The transaction has not been initialized yet!");
                return false;
            }

            if (query == "")
            {
                ShowError("The query command has not been initialized yet!");
                return false;
            }

            bool result = false;

            SqlCommand m_Command = mytrans.Connection.CreateCommand();
            m_Command.Transaction = mytrans;
            m_Command.CommandType = m_CommandType;
            m_Command.CommandTimeout = m_CommandTimeout;
            m_Command.CommandText = query;
            
            try
            {
                m_Command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
            m_Command.Dispose();
            m_Command = null;
            return result;
        }

        public bool ExecuteNonQuery(SqlTransaction mytrans, string query, string[] myparams, object[] myvalues)
        {
            if (mytrans == null)
            {
                ShowError("The transaction has not been initialized yet!");
                return false;
            }

            if (query == "")
            {
                ShowError("The query command has not been initialized!");
                return false;
            }

            if (myparams == null || myvalues == null) 
                return ExecuteNonQuery(mytrans, query);

            if (myparams.Length != myvalues.Length)
            {
                ShowError("The number of parameters does not match with ther numbers of values applied");
                return false;
            }

            bool result = false;

            SqlCommand m_Command = mytrans.Connection.CreateCommand();
            m_Command.Transaction = mytrans;
            m_Command.CommandType = m_CommandType;
            m_Command.CommandTimeout = m_CommandTimeout;
            m_Command.CommandText = query;

            for (int i = 0; i < myparams.Length; i++)
                m_Command.Parameters.Add(new SqlParameter(myparams[i], myvalues[i]));
            try
            {
                m_Command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
            m_Command.Dispose();
            m_Command = null;
            return result;
        }

        public SqlDataReader ExecuteReader(string query)
        {
            if (query == "")
            {
                ShowError("The query command has not been initialized!");
                return null;
            }

            SqlCommand m_Command = new SqlCommand(query, m_Connection);
            m_Command.CommandType = m_CommandType;
            m_Command.CommandTimeout = m_CommandTimeout;
            SqlDataReader myReader = null;
            try
            {
                myReader = m_Command.ExecuteReader(CommandBehavior.SingleRow);
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
            m_Command.Dispose();
            m_Command = null;
            return myReader;
        }

        public SqlDataReader ExecuteReader(string query, string[] myparams, object[] myvalues)
        {
            if (query == "")
            {
                ShowError("The query command has not been initialized!");
                return null;
            }

            if (myparams == null || myvalues == null) 
                return ExecuteReader(query);

            if (myparams.Length != myvalues.Length)
            {
                ShowError("The number of parameters does not match with the numbers of values applied");
                return null;
            }

            SqlCommand m_Command = new SqlCommand(query, m_Connection);
            m_Command.CommandType = m_CommandType;
            m_Command.CommandTimeout = m_CommandTimeout;

            for (int i = 0; i < myparams.Length; i++)
                m_Command.Parameters.Add(new SqlParameter(myparams[i], myvalues[i]));

            SqlDataReader myReader = null;

            try
            {
                myReader = m_Command.ExecuteReader(CommandBehavior.SingleRow);
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
            m_Command.Dispose();
            m_Command = null;
            return myReader;
        }

        public SqlDataReader ExecuteReader(SqlTransaction mytrans, string query)
        {
            if (mytrans == null)
            {
                ShowError("The transaction has not been initialized yet!");
                return null;
            }

            if (query == "")
            {
                ShowError("The query command has not been initialized!");
                return null;
            }

            SqlCommand m_Command = mytrans.Connection.CreateCommand();
            m_Command.Transaction = mytrans;
            m_Command.CommandType = m_CommandType;
            m_Command.CommandTimeout = m_CommandTimeout;
            m_Command.CommandText = query;
            
            SqlDataReader myReader = null;
            try
            {
                myReader = m_Command.ExecuteReader(CommandBehavior.SingleRow);
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
            m_Command.Dispose();
            m_Command = null;
            return myReader;
        }

        public SqlDataReader ExecuteReader(SqlTransaction mytrans, string query, string[] myparams, object[] myvalues)
        {
            if (mytrans == null)
            {
                ShowError("The transaction has not been initialized yet!");
                return null;
            }

            if (query == "")
            {
                ShowError("The query command has not been initialized!");
                return null;
            }

            if (myparams == null || myvalues == null) 
                return ExecuteReader(query);

            if (myparams.Length != myvalues.Length)
            {
                ShowError("The number of parameters does not match with the numbers of values applied");
                return null;
            }

            SqlCommand m_Command = mytrans.Connection.CreateCommand();
            m_Command.Transaction = mytrans;
            m_Command.CommandType = m_CommandType;
            m_Command.CommandTimeout = m_CommandTimeout;
            m_Command.CommandText = query;

            for (int i = 0; i < myparams.Length; i++)
                m_Command.Parameters.Add(new SqlParameter(myparams[i], myvalues[i]));

            SqlDataReader myReader = null;

            try
            {
                myReader = m_Command.ExecuteReader(CommandBehavior.SingleRow);
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
            m_Command.Dispose();
            m_Command = null;
            return myReader;
        }

        public DataTable ExecuteDataTable(string query)
        {
            DataTable dtResult = new DataTable();
            if (query == "")
            {
                ShowError("The query command has not been initialized!");
                return dtResult;
            }

            if (!Open()) return dtResult;

            SqlCommand m_Command = new SqlCommand(query, m_Connection);
            m_Command.CommandType = m_CommandType;
            m_Command.CommandTimeout = m_CommandTimeout;
            SqlDataAdapter da = new SqlDataAdapter(m_Command);
            try
            {
                da.Fill(dtResult);
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
            m_Command.Dispose();
            m_Command = null;
            da.Dispose();
            da = null;

            Close();
            return dtResult;
        }

        public DataTable ExecuteDataTable(string query, string[] myparams, object[] myvalues)
        {
            DataTable dtResult = new DataTable();
            if (myparams == null || myvalues == null) return ExecuteDataTable(query);

            if (query == "")
            {
                ShowError("The query command has not been initialized!");
                return dtResult;
            }

            if (myparams.Length != myvalues.Length)
            {
                ShowError("The number of parameters does not match with the numbers of values applied");
                return dtResult;
            }

            if (!Open()) return dtResult;

            SqlCommand m_Command = new SqlCommand(query, m_Connection);
            m_Command.CommandType = m_CommandType;
            m_Command.CommandTimeout = m_CommandTimeout;
            for (int i = 0; i < myparams.Length; i++)
                m_Command.Parameters.Add(new SqlParameter(myparams[i], myvalues[i]));
            SqlDataAdapter da = new SqlDataAdapter(m_Command);
            try
            {
                da.Fill(dtResult);
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
            m_Command.Dispose();
            m_Command = null;
            da.Dispose();
            da = null;

            Close();
            return dtResult;
        }

        public DataTable ExecuteDataTable(SqlTransaction mytrans, string query)
        {
            DataTable dtResult = new DataTable();

            if (mytrans == null)
            {
                ShowError("The transaction has not been initialized yet!");
                return dtResult;
            }

            if (query == "")
            {
                ShowError("The query command has not been initialized!");
                return dtResult;
            }

            SqlCommand m_Command = mytrans.Connection.CreateCommand();
            m_Command.Transaction = mytrans;
            m_Command.CommandType = m_CommandType;
            m_Command.CommandTimeout = m_CommandTimeout;
            m_Command.CommandText = query;

            SqlDataAdapter da = new SqlDataAdapter(m_Command);
            try
            {
                da.Fill(dtResult);
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
            m_Command.Dispose();
            m_Command = null;
            da.Dispose();
            da = null;

            return dtResult;
        }

        public DataTable ExecuteDataTable(SqlTransaction mytrans, string query, string[] myparams, object[] myvalues)
        {
            DataTable dtResult = new DataTable();

            if (mytrans == null)
            {
                ShowError("The transaction has not been initialized yet!");
                return dtResult;
            }

            if (query == "")
            {
                ShowError("The query command has not been initialized!");
                return dtResult;
            }

            if (myparams == null || myvalues == null)
                return ExecuteDataTable(mytrans, query);

            if (myparams.Length != myvalues.Length)
            {
                ShowError("The number of parameters does not match with the numbers of values applied");
                return dtResult;
            }

            SqlCommand m_Command = mytrans.Connection.CreateCommand();
            m_Command.Transaction = mytrans;
            m_Command.CommandType = m_CommandType;
            m_Command.CommandTimeout = m_CommandTimeout;
            m_Command.CommandText = query;
            for (int i = 0; i < myparams.Length; i++)
                m_Command.Parameters.Add(new SqlParameter(myparams[i], myvalues[i]));
            SqlDataAdapter da = new SqlDataAdapter(m_Command);
            try
            {
                da.Fill(dtResult);
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
            m_Command.Dispose();
            m_Command = null;
            da.Dispose();
            da = null;

            return dtResult;
        }

        public T ExecuteScalar<T>(string query)
        {
            if (query == "")
            {
                ShowError("The query command has not been initialized!");
                return default(T);
            }

            if (!Open()) return default(T);
            object result = null;
            SqlCommand m_Command = new SqlCommand(query, m_Connection);
            m_Command.CommandType = m_CommandType;
            m_Command.CommandTimeout = m_CommandTimeout;
            try
            {
                result = m_Command.ExecuteScalar();
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
            m_Command.Dispose();
            m_Command = null;
            Close();
            return result == DBNull.Value || result == null ? default(T) : (T)Convert.ChangeType(result, typeof(T));
        }

        public T ExecuteScalar<T>(string query, string[] myparams, object[] myvalues)
        {
            if (query == "")
            {
                ShowError("The query command has not been initialized!");
                return default(T);
            }

            if (myparams == null || myvalues == null)
                return ExecuteScalar<T>(query);

            if (myparams.Length != myvalues.Length)
            {
                ShowError("The number of parameters does not match with ther numbers of values applied");
                return default(T);
            }

            if (!Open()) return default(T);
            object result = null;
            SqlCommand m_Command = new SqlCommand(query, m_Connection);
            m_Command.CommandType = m_CommandType;
            m_Command.CommandTimeout = m_CommandTimeout;
            for (int i = 0; i < myparams.Length; i++)
                m_Command.Parameters.Add(new SqlParameter(myparams[i], myvalues[i]));
            try
            {
                result = m_Command.ExecuteScalar();
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
            m_Command.Dispose();
            m_Command = null;
            Close();
            return result == DBNull.Value || result == null ? default(T) : (T)Convert.ChangeType(result, typeof(T));
        }

        public T ExecuteScalar<T>(SqlTransaction mytrans, string query)
        {
            if (mytrans == null)
            {
                ShowError("The transaction has not been initialized yet!");
                return default(T);
            }

            if (query == "")
            {
                ShowError("The query command has not been initialized!");
                return default(T);
            }

            object result = null;
            SqlCommand m_Command = mytrans.Connection.CreateCommand();
            m_Command.Transaction = mytrans;
            m_Command.CommandType = m_CommandType;
            m_Command.CommandTimeout = m_CommandTimeout;
            m_Command.CommandText = query;
            try
            {
                result = m_Command.ExecuteScalar();
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
            m_Command.Dispose();
            m_Command = null;
            return result == DBNull.Value || result == null ? default(T) : (T)Convert.ChangeType(result, typeof(T));
        }

        public T ExecuteScalar<T>(SqlTransaction mytrans, string query, string[] myparams, object[] myvalues)
        {
            if (mytrans == null)
            {
                ShowError("The transaction has not been initialized yet!");
                return default(T);
            }

            if (query == "")
            {
                ShowError("The query command has not been initialized!");
                return default(T);
            }

            if (myparams == null || myvalues == null)
                return ExecuteScalar<T>(mytrans, query);

            if (myparams.Length != myvalues.Length)
            {
                ShowError("The number of parameters does not match with ther numbers of values applied");
                return default(T);
            }

            object result = null;

            SqlCommand m_Command = mytrans.Connection.CreateCommand();
            m_Command.Transaction = mytrans;
            m_Command.CommandType = m_CommandType;
            m_Command.CommandTimeout = m_CommandTimeout;
            m_Command.CommandText = query;

            for (int i = 0; i < myparams.Length; i++)
                m_Command.Parameters.Add(new SqlParameter(myparams[i], myvalues[i]));
            try
            {
                result = m_Command.ExecuteScalar();
            }
            catch (Exception err)
            {
                ShowError(err.Message);
            }
            m_Command.Dispose();
            m_Command = null;
            return result == DBNull.Value || result == null ? default(T) : (T)Convert.ChangeType(result, typeof(T));
        }

        #endregion

        #region static strategy

        public static DateTime ServerDateTime
        {
            get 
            {
                SqlHelper mysql = new SqlHelper();
                if (!mysql.Open()) return DateTime.Now;
                return mysql.ExecuteScalar<DateTime>("SELECT GETDATE()");
            }
        }

        #endregion

        private void ShowError(string msg)
        {
            if (!m_EnableShowError) return;
            MsgBox.ShowErrorDialog(msg);
        }
    }
}
