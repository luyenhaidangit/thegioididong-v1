using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Thegioididong.Data.Infrastructure
{
    public class StoreParameterInfo
    {
        public string StoreProcedureName { get; set; }
        public List<Object> StoreProcedureParams { get; set; }
    }
    public interface IDatabaseHelper
    {
        void SetConnectionString(string connectionString);
        /// <summary>
        /// Open Connection to PostGresDB
        /// </summary>
        /// <returns></returns>
        string OpenConnection();
        /// <summary>
        /// Open Connection and Begin Transaction
        /// </summary>
        /// <returns></returns>
        string OpenConnectionAndBeginTransaction();
        /// <summary>
        /// Close Connect to PostGres DB
        /// </summary>
        /// <returns>String.Empty when Close connect success or Message Error when connection close happen issue</returns>
        string CloseConnection();
        /// <summary>
        /// Close Connect and end transaction
        /// </summary>
        /// <returns>String.Empty when Close connect success or Message Error when connection close happen issue</returns>
        string CloseConnectionAndEndTransaction(bool isRollbackTransaction);

        string ExecuteNoneQuery(string strquery);

        DataTable ExecuteQueryToDataTable(string strquery, out string msgError);

        object ExecuteScalar(string strquery, out string msgError);
        #region Execute StoreProcedure
        /// <summary>
        /// Execute Procedure None Query
        /// </summary>
        /// <param name="sprocedureName">Procedure Name</param>
        /// <param name="paramObjects">List Param Objects, Each Item include 'ParamName' and 'ParamValue'</param>
        /// <returns>String.Empty when run query success or Message Error when run query happen issue</returns>
        string ExecuteSProcedure(string sprocedureName, params object[] paramObjects);
        /// <summary>
        /// Execute Procedure return DataTale
        /// </summary>
        /// <param name="msgError">String.Empty when run query success or Message Error when run query happen issue</param>
        /// <param name="sprocedureName">Procedure Name</param>
        /// <param name="paramObjects">List Param Objects, Each Item include 'ParamName' and 'ParamValue'</param>
        /// <returns>Table result</returns>
        DataTable ExecuteSProcedureReturnDataTable(out string msgError, string sprocedureName, params object[] paramObjects);
        /// <summary>
        /// Execute Procedure return DataSet
        /// </summary>
        /// <param name="msgError">String.Empty when run query success or Message Error when run query happen issue</param>
        /// <param name="sprocedureName">Procedure Name</param>
        /// <param name="paramObjects">List Param Objects, Each Item include 'ParamName' and 'ParamValue'</param>
        /// <returns>DataSet result</returns>
        DataSet ExecuteSProcedureReturnDataset(out string msgError, string sprocedureName, params object[] paramObjects);
        /// <summary>
        /// Execute Procedure None Query
        /// </summary>
        /// <param name="sqlConnection">sqlConnection: Connection use to connect to SQL Server</param>
        /// <param name="sprocedureName">Procedure Name</param>
        /// <param name="paramObjects">List Param Objects, Each Item include 'ParamName' and 'ParamValue'</param>
        /// <returns>String.Empty when run query success or Message Error when run query happen issue</returns>
        string ExecuteSProcedure(SqlConnection sqlConnection, string sprocedureName, params object[] paramObjects);
        /// <summary>
        /// Execute Procedure None Query with transaction
        /// </summary>
        /// <param name="sprocedureName">Procedure Name</param>
        /// <param name="paramObjects">List Param Objects, Each Item include 'ParamName' and 'ParamValue'</param>
        /// <returns>String.Empty when run query success or Message Error when run query happen issue</returns>
        string ExecuteSProcedureWithTransaction(string sprocedureName, params object[] paramObjects);
        /// <summary>
        /// Execute Scalar Procedure query List store and command
        /// </summary>
        /// <param name="storeParameterInfos">List Store and ListList Parameter</param>
        /// <returns>List msgErrors return from storeprocedure</returns>
        List<string> ExecuteScalarSProcedure(List<StoreParameterInfo> storeParameterInfos);
        /// <summary>
        /// Execute Procedure query List store with transaction
        /// </summary>
        /// <param name="storeParameterInfos">List Store and ListList Parameter</param>
        /// <returns>List msgErrors return from storeprocedure</returns>
        List<string> ExecuteSProcedureWithTransaction(List<StoreParameterInfo> storeParameterInfos);
        /// <summary>
        ///  Execute Scalar Procedure query
        /// </summary>
        /// <param name="msgError">String.Empty when run query success or Message Error when run query happen issue</param>
        /// <param name="strConnectionString">Connection String use to connect to PostGresDB</param>
        /// <param name="sprocedureName">Procedure Name</param>
        /// <param name="paramObjects">List Param Objects, Each Item include 'ParamName' and 'ParamValue'</param>
        /// <returns>Value return from Store</returns>
        object ExecuteScalarSProcedure(out string msgError, string sprocedureName, params object[] paramObjects);
        /// <summary>
        ///  Execute Scalar Procedure query with transaction
        /// </summary>
        /// <param name="msgError">String.Empty when run query success or Message Error when run query happen issue</param>        
        /// <param name="sprocedureName">Procedure Name</param>
        /// <param name="paramObjects">List Param Objects, Each Item include 'ParamName' and 'ParamValue'</param>
        /// <returns>Value return from Store</returns>
        object ExecuteScalarSProcedureWithTransaction(out string msgError, string sprocedureName, params object[] paramObjects);
        /// <summary>
        /// Execute Scalar Procedure query List store and command
        /// </summary>
        /// <param name="msgErrors">List Error message</param>
        /// <param name="storeParameterInfos">List Store and ListList Parameter</param>
        /// <returns>List Object return from storeprocedure</returns>
        List<object> ExecuteScalarSProcedure(out List<string> msgErrors, List<StoreParameterInfo> storeParameterInfos);
        /// <summary>
        /// Execute Scalar Procedure query List store with transaction
        /// </summary>
        /// <param name="msgErrors">List Error message</param>
        /// <param name="storeParameterInfos">List Store and ListList Parameter</param>
        /// <returns>List Object return from storeprocedure</returns>
        List<object> ExecuteScalarSProcedureWithTransaction(out List<string> msgErrors, List<StoreParameterInfo> storeParameterInfos);
        /// <summary>
        /// Execute Procedure return List Object Results
        /// </summary>
        /// <param name="msgError">String.Empty when run query success or Message Error when run query happen issue</param>
        /// <param name="sprocedureName">Procedure Name</param>
        /// <param name="outputParamCountNumber">outputParam Count Number</param>
        /// <param name="paramObjects">List Param Objects, Each Item include 'ParamName' and 'ParamValue'</param>
        /// <returns>List Object Result in query</returns>
        List<Object> ReturnValuesFromExecuteSProcedure(out string msgError, string sprocedureName, int outputParamCountNumber, params object[] paramObjects);
        #endregion 
    }
}
