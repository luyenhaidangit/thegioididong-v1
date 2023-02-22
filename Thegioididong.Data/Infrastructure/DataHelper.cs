using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Thegioididong.Data.Infrastructure;

namespace Demo.Data.Infrastructure
{
    public class DatabaseHelper : IDatabaseHelper
    {

        //Connection String
        public string StrConnection { get; set; }
        //Connection
        public SqlConnection sqlConnection { get; set; }
        //NpgsqlTransaction 
        public SqlTransaction sqlTransaction { get; set; }

        public DatabaseHelper(IConfiguration configuration)
        {
            StrConnection = configuration["ConnectionStrings:DefaultConnection"];
        }
        /// <summary>
        /// Set Connection String
        /// </summary>
        /// <param name="connectionString"></param>
        public void SetConnectionString(string connectionString)
        {
            StrConnection = connectionString;
        }
        /// <summary>
        /// Open Connect to PostGres DB
        /// </summary>
        /// <returns>String.Empty when connected or Message Error when connect happen issue</returns>
        public string OpenConnection()
        {
            try
            {
                if (sqlConnection == null)
                    sqlConnection = new SqlConnection(StrConnection);

                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();

                return "";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        /// <summary>
        /// Open Connect begin transaction to PostGres DB
        /// </summary>
        /// <returns>String.Empty when connected or Message Error when connect happen issue</returns>
        public string OpenConnectionAndBeginTransaction()
        {
            try
            {
                if (sqlConnection == null)
                    sqlConnection = new SqlConnection(StrConnection);

                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction();

                return "";
            }
            catch (Exception exception)
            {
                if (sqlConnection != null)
                    sqlConnection.Dispose();

                if (sqlTransaction != null)
                    sqlTransaction.Dispose();

                return exception.Message;
            }
        }
        /// <summary>
        /// Close Connect and end transaction to PostGres DB
        /// </summary>
        /// <returns>String.Empty when Close connect success or Message Error when connection close happen issue</returns>
        public string CloseConnectionAndEndTransaction(bool isRollbackTransaction)
        {
            try
            {
                if (sqlTransaction != null)
                {
                    if (isRollbackTransaction)
                        sqlTransaction.Rollback();
                    else sqlTransaction.Commit();
                }

                if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
                return "";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        /// <summary>
        /// Close Connect to PostGres DB
        /// </summary>
        /// <returns>String.Empty when Close connect success or Message Error when connection close happen issue</returns>
        public string CloseConnection()
        {
            try
            {
                if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
                return "";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public string ExecuteNoneQuery(string strquery)
        {
            string msgError = "";
            try
            {
                OpenConnection();
                var sqlCommand = new SqlCommand(strquery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
            }
            catch (Exception exception)
            {
                msgError = exception.ToString();
            }
            finally
            {
                CloseConnection();
            }
            return msgError;
        }

        public DataTable ExecuteQueryToDataTable(string strquery, out string msgError)
        {
            msgError = "";
            var result = new DataTable();
            var sqlDataAdapter = new SqlDataAdapter(strquery, StrConnection);
            try
            {
                sqlDataAdapter.Fill(result);
            }
            catch (Exception exception)
            {
                msgError = exception.ToString();
                result = null;
            }
            finally
            {
                sqlDataAdapter.Dispose();
            }
            return result;
        }

        public object ExecuteScalar(string strquery, out string msgError)
        {
            object result = null;
            try
            {
                OpenConnection();
                var npgsqlCommand = new SqlCommand(strquery, sqlConnection);
                result = npgsqlCommand.ExecuteScalar();
                npgsqlCommand.Dispose();
                msgError = "";
            }
            catch (Exception ex) { msgError = ex.StackTrace; }
            finally
            {
                CloseConnection();
            }
            return result;
        }
        #region Execute StoreProcedure
        /// <summary>
        /// Execute Procedure None Query
        /// </summary>
        /// <param name="sprocedureName">Procedure Name</param>
        /// <param name="paramObjects">List Param Objects, Each Item include 'ParamName' and 'ParamValue'</param>
        /// <returns>String.Empty when run query success or Message Error when run query happen issue</returns>
        public string ExecuteSProcedure(string sprocedureName, params object[] paramObjects)
        {
            string result = "";
            SqlConnection connection = new SqlConnection(StrConnection);
            try
            {
                SqlCommand cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = sprocedureName };
                connection.Open();
                cmd.Connection = connection;
                int parameterInput = (paramObjects.Length) / 2;
                int j = 0;
                for (int i = 0; i < parameterInput; i++)
                {
                    string paramName = Convert.ToString(paramObjects[j++]);
                    object value = paramObjects[j++];
                    if (paramName.ToLower().Contains("json"))
                    {
                        cmd.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = paramName,
                            Value = value ?? DBNull.Value,
                            SqlDbType = SqlDbType.NVarChar
                        });
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter(paramName, value ?? DBNull.Value));
                    }
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception exception)
            {
                result = exception.ToString();
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Execute Procedure None Query with transaction
        /// </summary>
        /// <param name="sprocedureName">Procedure Name</param>
        /// <param name="paramObjects">List Param Objects, Each Item include 'ParamName' and 'ParamValue'</param>
        /// <returns>String.Empty when run query success or Message Error when run query happen issue</returns>
        public string ExecuteSProcedureWithTransaction(string sprocedureName, params object[] paramObjects)
        {
            string result = "";
            using (SqlConnection connection = new SqlConnection(StrConnection))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = connection.CreateCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sprocedureName;
                        cmd.Transaction = transaction;
                        cmd.Connection = connection;
                        int parameterInput = (paramObjects.Length) / 2;
                        int j = 0;
                        for (int i = 0; i < parameterInput; i++)
                        {
                            string paramName = Convert.ToString(paramObjects[j++]);
                            object value = paramObjects[j++];
                            //DbType type = ConvertSystemType2DbType(value);
                            if (paramName.ToLower().Contains("json"))
                            {
                                cmd.Parameters.Add(new SqlParameter()
                                {
                                    ParameterName = paramName,
                                    Value = value ?? DBNull.Value,
                                    SqlDbType = SqlDbType.NVarChar
                                });
                            }
                            else
                            {
                                cmd.Parameters.Add(new SqlParameter(paramName, value ?? DBNull.Value));
                            }
                        }
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        transaction.Commit();
                    }
                    catch (Exception exception)
                    {
                        result = exception.ToString();
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex) { }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Execute Scalar Procedure query List store and command
        /// </summary>
        /// <param name="storeParameterInfos">List Store and ListList Parameter</param>
        /// <returns>List msgErrors return from storeprocedure</returns>
        public List<string> ExecuteScalarSProcedure(List<StoreParameterInfo> storeParameterInfos)
        {
            var msgErrors = new List<string>();
            List<object> result = new List<object>();
            using (SqlConnection connection = new SqlConnection(StrConnection))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, Connection = connection })
                {

                    for (int p = 0; p < storeParameterInfos.Count; p++)
                    {
                        try
                        {
                            cmd.CommandText = storeParameterInfos[p].StoreProcedureName;
                            int parameterInput = storeParameterInfos[p].StoreProcedureParams == null ? 0 : (storeParameterInfos[p].StoreProcedureParams.Count) / 2;
                            int j = 0;

                            if (cmd.Parameters != null && cmd.Parameters.Count > 0)
                                cmd.Parameters.Clear();

                            for (int i = 0; i < parameterInput; i++)
                            {
                                string paramName = Convert.ToString(storeParameterInfos[p].StoreProcedureParams[j++]);
                                object value = storeParameterInfos[p].StoreProcedureParams[j++];
                                if (paramName.ToLower().Contains("json"))
                                {
                                    cmd.Parameters.Add(new SqlParameter()
                                    {
                                        ParameterName = paramName,
                                        Value = value ?? DBNull.Value,
                                        SqlDbType = SqlDbType.NVarChar
                                    });
                                }
                                else
                                {
                                    cmd.Parameters.Add(new SqlParameter(paramName, value ?? DBNull.Value));
                                }
                            }

                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception exception)
                        {
                            msgErrors.Add(exception.StackTrace);
                        }
                    }
                }
            }
            return msgErrors;
        }
        /// <summary>
        /// Execute Procedure query List store with transaction
        /// </summary>
        /// <param name="storeParameterInfos">List Store and ListList Parameter</param>
        /// <returns>List msgErrors return from storeprocedure</returns>
        public List<string> ExecuteSProcedureWithTransaction(List<StoreParameterInfo> storeParameterInfos)
        {
            var msgErrors = new List<string>();
            bool isSuccess = true;
            List<object> result = new List<object>();
            using (SqlConnection connection = new SqlConnection(StrConnection))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = transaction;
                        cmd.Connection = connection;

                        for (int p = 0; p < storeParameterInfos.Count; p++)
                        {
                            try
                            {
                                cmd.CommandText = storeParameterInfos[p].StoreProcedureName;
                                int parameterInput = storeParameterInfos[p].StoreProcedureParams == null ? 0 : (storeParameterInfos[p].StoreProcedureParams.Count) / 2;
                                int j = 0;

                                if (cmd.Parameters != null && cmd.Parameters.Count > 0)
                                    cmd.Parameters.Clear();

                                for (int i = 0; i < parameterInput; i++)
                                {
                                    string paramName = Convert.ToString(storeParameterInfos[p].StoreProcedureParams[j++]);
                                    object value = storeParameterInfos[p].StoreProcedureParams[j++];
                                    if (paramName.ToLower().Contains("json"))
                                    {
                                        cmd.Parameters.Add(new SqlParameter()
                                        {
                                            ParameterName = paramName,
                                            Value = value ?? DBNull.Value,
                                            SqlDbType = SqlDbType.NVarChar
                                        });
                                    }
                                    else
                                    {
                                        cmd.Parameters.Add(new SqlParameter(paramName, value ?? DBNull.Value));
                                    }
                                }

                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception exception)
                            {
                                isSuccess = false;
                                msgErrors.Add(exception.StackTrace);
                            }
                        }
                    }
                    if (isSuccess)
                        transaction.Commit();
                    else
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex) { }
                    }
                }
            }
            return msgErrors;
        }
        /// <summary>
        ///  Execute Scalar Procedure query
        /// </summary>
        /// <param name="msgError">String.Empty when run query success or Message Error when run query happen issue</param>        
        /// <param name="sprocedureName">Procedure Name</param>
        /// <param name="paramObjects">List Param Objects, Each Item include 'ParamName' and 'ParamValue'</param>
        /// <returns>Value return from Store</returns>
        public object ExecuteScalarSProcedure(out string msgError, string sprocedureName, params object[] paramObjects)
        {
            msgError = "";
            object result = null;
            SqlConnection connection = new SqlConnection(StrConnection);

            try
            {
                SqlCommand cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = sprocedureName };
                connection.Open();
                cmd.Connection = connection;
                int parameterInput = (paramObjects.Length) / 2;
                int j = 0;
                for (int i = 0; i < parameterInput; i++)
                {
                    string paramName = Convert.ToString(paramObjects[j++]);
                    object value = paramObjects[j++];
                    if (paramName.ToLower().Contains("jsonb"))
                    {
                        cmd.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = paramName,
                            Value = value ?? DBNull.Value,
                            SqlDbType = SqlDbType.NVarChar
                        });
                    }
                    else if (paramName.ToLower().Contains("json"))
                    {
                        cmd.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = paramName,
                            Value = value ?? DBNull.Value,
                            SqlDbType = SqlDbType.NVarChar
                        });
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter(paramName, value ?? DBNull.Value));
                    }
                }

                result = cmd.ExecuteScalar();
                cmd.Dispose();
            }
            catch (Exception exception)
            {
                result = null;
                msgError = exception.ToString();
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        /// <summary>
        /// Execute Scalar Procedure query List store and command
        /// </summary>
        /// <param name="msgErrors">List Error message</param>
        /// <param name="storeParameterInfos">List Store and ListList Parameter</param>
        /// <returns>List Object return from storeprocedure</returns>
        public List<object> ExecuteScalarSProcedure(out List<string> msgErrors, List<StoreParameterInfo> storeParameterInfos)
        {
            msgErrors = new List<string>();
            List<object> result = new List<object>();
            using (SqlConnection connection = new SqlConnection(StrConnection))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, Connection = connection })
                {

                    for (int p = 0; p < storeParameterInfos.Count; p++)
                    {
                        try
                        {
                            cmd.CommandText = storeParameterInfos[p].StoreProcedureName;
                            int parameterInput = storeParameterInfos[p].StoreProcedureParams == null ? 0 : (storeParameterInfos[p].StoreProcedureParams.Count) / 2;
                            int j = 0;

                            if (cmd.Parameters != null && cmd.Parameters.Count > 0)
                                cmd.Parameters.Clear();

                            for (int i = 0; i < parameterInput; i++)
                            {
                                string paramName = Convert.ToString(storeParameterInfos[p].StoreProcedureParams[j++]);
                                object value = storeParameterInfos[p].StoreProcedureParams[j++];
                                if (paramName.ToLower().Contains("json"))
                                {
                                    cmd.Parameters.Add(new SqlParameter()
                                    {
                                        ParameterName = paramName,
                                        Value = value ?? DBNull.Value,
                                        SqlDbType = SqlDbType.NVarChar
                                    });
                                }
                                else
                                {
                                    cmd.Parameters.Add(new SqlParameter(paramName, value ?? DBNull.Value));
                                }
                            }

                            var rresult = cmd.ExecuteScalar();
                            result.Add(rresult);
                        }
                        catch (Exception exception)
                        {
                            result.Add(null);
                            msgErrors.Add(exception.StackTrace);
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Execute Scalar Procedure query List store with transaction
        /// </summary>
        /// <param name="msgErrors">List Error message</param>
        /// <param name="storeParameterInfos">List Store and ListList Parameter</param>
        /// <returns>List Object return from storeprocedure</returns>
        public List<object> ExecuteScalarSProcedureWithTransaction(out List<string> msgErrors, List<StoreParameterInfo> storeParameterInfos)
        {
            msgErrors = new List<string>();
            bool isSuccess = true;
            List<object> result = new List<object>();
            using (SqlConnection connection = new SqlConnection(StrConnection))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = transaction;
                        cmd.Connection = connection;

                        for (int p = 0; p < storeParameterInfos.Count; p++)
                        {
                            try
                            {
                                cmd.CommandText = storeParameterInfos[p].StoreProcedureName;
                                int parameterInput = storeParameterInfos[p].StoreProcedureParams == null ? 0 : (storeParameterInfos[p].StoreProcedureParams.Count) / 2;
                                int j = 0;

                                if (cmd.Parameters != null && cmd.Parameters.Count > 0)
                                    cmd.Parameters.Clear();

                                for (int i = 0; i < parameterInput; i++)
                                {
                                    string paramName = Convert.ToString(storeParameterInfos[p].StoreProcedureParams[j++]);
                                    object value = storeParameterInfos[p].StoreProcedureParams[j++];
                                    if (paramName.ToLower().Contains("json"))
                                    {
                                        cmd.Parameters.Add(new SqlParameter()
                                        {
                                            ParameterName = paramName,
                                            Value = value ?? DBNull.Value,
                                            SqlDbType = SqlDbType.NVarChar
                                        });
                                    }
                                    else
                                    {
                                        cmd.Parameters.Add(new SqlParameter(paramName, value ?? DBNull.Value));
                                    }
                                }

                                var rresult = cmd.ExecuteScalar();
                                result.Add(rresult);
                            }
                            catch (Exception exception)
                            {
                                isSuccess = false;
                                result.Add(null);
                                msgErrors.Add(exception.StackTrace);
                            }
                        }
                    }
                    if (isSuccess)
                        transaction.Commit();
                    else
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex) { }
                    }
                }
            }
            return result;
        }
        /// <summary>
        ///  Execute Scalar Procedure query with transaction
        /// </summary>
        /// <param name="msgError">String.Empty when run query success or Message Error when run query happen issue</param>        
        /// <param name="sprocedureName">Procedure Name</param>
        /// <param name="paramObjects">List Param Objects, Each Item include 'ParamName' and 'ParamValue'</param>
        /// <returns>Value return from Store</returns>
        public object ExecuteScalarSProcedureWithTransaction(out string msgError, string sprocedureName, params object[] paramObjects)
        {
            msgError = "";
            object result = null;
            using (SqlConnection connection = new SqlConnection(StrConnection))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = connection.CreateCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sprocedureName;
                        cmd.Transaction = transaction;
                        cmd.Connection = connection;

                        int parameterInput = (paramObjects.Length) / 2;
                        int j = 0;
                        for (int i = 0; i < parameterInput; i++)
                        {
                            string paramName = Convert.ToString(paramObjects[j++]);
                            object value = paramObjects[j++];
                            if (paramName.ToLower().Contains("json"))
                            {
                                cmd.Parameters.Add(new SqlParameter()
                                {
                                    ParameterName = paramName,
                                    Value = value ?? DBNull.Value,
                                    SqlDbType = SqlDbType.NVarChar
                                });
                            }
                            else
                            {
                                cmd.Parameters.Add(new SqlParameter(paramName, value ?? DBNull.Value));
                            }
                        }

                        result = cmd.ExecuteScalar();
                        cmd.Dispose();
                        transaction.Commit();
                    }
                    catch (Exception exception)
                    {

                        result = null;
                        msgError = exception.ToString();
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex) { }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Execute Procedure return DataTale
        /// </summary>
        /// <param name="msgError">String.Empty when run query success or Message Error when run query happen issue</param>
        /// <param name="sprocedureName">Procedure Name</param>
        /// <param name="paramObjects">List Param Objects, Each Item include 'ParamName' and 'ParamValue'</param>
        /// <returns>Table result</returns>
        public DataTable ExecuteSProcedureReturnDataTable(out string msgError, string sprocedureName, params object[] paramObjects)
        {
            DataTable tb = new DataTable();
            SqlConnection connection;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = sprocedureName };
                connection = new SqlConnection(StrConnection);
                cmd.Connection = connection;

                int parameterInput = (paramObjects.Length) / 2;

                int j = 0;
                for (int i = 0; i < parameterInput; i++)
                {
                    string paramName = Convert.ToString(paramObjects[j++]).Trim();
                    object value = paramObjects[j++];
                    if (paramName.ToLower().Contains("json"))
                    {
                        cmd.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = paramName,
                            Value = value ?? DBNull.Value,
                            SqlDbType = SqlDbType.NVarChar
                        });
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter(paramName, value ?? DBNull.Value));
                    }
                }

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(tb);
                cmd.Dispose();
                ad.Dispose();
                connection.Dispose();
                msgError = "";
            }
            catch (Exception exception)
            {
                tb = null;
                msgError = exception.ToString();
            }
            return tb;
        }
        /// <summary>
        /// Execute Procedure return DataSet
        /// </summary>
        /// <param name="msgError">String.Empty when run query success or Message Error when run query happen issue</param>
        /// <param name="sprocedureName">Procedure Name</param>
        /// <param name="paramObjects">List Param Objects, Each Item include 'ParamName' and 'ParamValue'</param>
        /// <returns>DataSet result</returns>
        public DataSet ExecuteSProcedureReturnDataset(out string msgError, string sprocedureName, params object[] paramObjects)
        {
            DataSet tb = new DataSet();
            SqlConnection connection;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = sprocedureName };
                connection = new SqlConnection(StrConnection);
                cmd.Connection = connection;

                int parameterInput = (paramObjects.Length) / 2;

                int j = 0;
                for (int i = 0; i < parameterInput; i++)
                {
                    string paramName = Convert.ToString(paramObjects[j++]);
                    object value = paramObjects[j++];
                    if (paramName.ToLower().Contains("json"))
                    {
                        cmd.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = paramName,
                            Value = value ?? DBNull.Value,
                            SqlDbType = SqlDbType.NVarChar
                        });
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter(paramName, value ?? DBNull.Value));
                    }
                }

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(tb);
                cmd.Dispose();
                ad.Dispose();
                connection.Dispose();
                msgError = "";
            }
            catch (Exception exception)
            {
                tb = null;
                msgError = exception.ToString();
            }

            return tb;
        }
        /// <summary>
        /// Execute Procedure None Query
        /// </summary>
        /// <param name="npgsqlConnection">NpgsqlConnection: Connection use to connect to PostGresDB</param>
        /// <param name="sprocedureName">Procedure Name</param>
        /// <param name="paramObjects">List Param Objects, Each Item include 'ParamName' and 'ParamValue'</param>
        /// <returns>String.Empty when run query success or Message Error when run query happen issue</returns>
        public string ExecuteSProcedure(SqlConnection npgsqlConnection, string sprocedureName, params object[] paramObjects)
        {
            string result = "";
            // NpgsqlConnection connection = new NpgsqlConnection(strConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = sprocedureName };
                if (npgsqlConnection.State != ConnectionState.Open)
                {
                    return "CONNECTION_NOT_OPENING";
                }

                cmd.Connection = npgsqlConnection;
                int parameterInput = (paramObjects.Length) / 2;
                int j = 0;
                for (int i = 0; i < parameterInput; i++)
                {
                    string paramName = Convert.ToString(paramObjects[j++]);
                    object value = paramObjects[j++];
                    if (paramName.ToLower().Contains("json"))
                    {
                        cmd.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = paramName,
                            Value = value ?? DBNull.Value,
                            SqlDbType = SqlDbType.NVarChar
                        });
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter(paramName, value ?? DBNull.Value));
                    }
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception exception)
            {
                result = exception.ToString();
            }
            return result;
        }
        /// <summary>
        /// Execute Procedure return List Object Results
        /// </summary>
        /// <param name="msgError">String.Empty when run query success or Message Error when run query happen issue</param>
        /// <param name="sprocedureName">Procedure Name</param>
        /// <param name="outputParamCountNumber">outputParam Count Number</param>
        /// <param name="paramObjects">List Param Objects, Each Item include 'ParamName' and 'ParamValue'</param>
        /// <returns>List Object Result in query</returns>
        public List<Object> ReturnValuesFromExecuteSProcedure(out string msgError, string sprocedureName, int outputParamCountNumber, params object[] paramObjects)
        {
            List<Object> result = new List<Object>();
            SqlConnection connection = new SqlConnection(StrConnection);
            try
            {
                SqlCommand cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = sprocedureName };
                connection.Open();
                cmd.Connection = connection;

                int numberOutput = outputParamCountNumber * 2;

                int parameterInput = (paramObjects.Length - numberOutput) / 2;

                int j = 0;
                for (int i = 0; i < parameterInput; i++)
                {
                    string paramName = Convert.ToString(paramObjects[j++]);
                    object value = paramObjects[j++];
                    if (paramName.ToLower().Contains("json"))
                    {
                        cmd.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = paramName,
                            Value = value ?? DBNull.Value,
                            SqlDbType = SqlDbType.NVarChar
                        });
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter(paramName, value ?? DBNull.Value));
                    }
                }

                for (int i = parameterInput * 2 - numberOutput; i < parameterInput * 2; i++)
                {
                    string paramName = Convert.ToString(paramObjects[j++]);
                    object value = paramObjects[j++];
                    cmd.Parameters.Add(new SqlParameter(paramName, value ?? DBNull.Value) { Direction = ParameterDirection.Output, Size = 1000, IsNullable = true });
                }

                cmd.ExecuteNonQuery();

                foreach (SqlParameter sqlParameter in cmd.Parameters)
                    if (sqlParameter.Direction == ParameterDirection.Output)
                        result.Add(sqlParameter.Value);

                cmd.Dispose();
                msgError = "";
            }
            catch (Exception exception)
            {
                msgError = exception.ToString();
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        #endregion
    }

}
