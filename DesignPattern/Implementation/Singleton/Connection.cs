using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DesignPattern.Implementation.Singleton
{
    public sealed class SQLConnection
    {
        static string SQLConnectionString;
        private static SQLConnection _instance;
        readonly static object obj = new object();

        private SQLConnection() { }
        private SQLConnection(string ConnectionString)
        {
            SQLConnectionString = ConnectionString;
        }

        public static SQLConnection getInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (obj)
                    {
                        _instance = new SQLConnection(ConnectionString);
                    }
                }
                return _instance;
            }
        }
        public enum ExecutionType
        {
            ReturnNothing = 1,
            ReturnScalarValue = 2
        }
        private static string ModifiedSQLQuery(string argSQLQry)
        {
            argSQLQry = argSQLQry.Replace(" Function ", "[Function]");
            argSQLQry = argSQLQry.Replace(" Function,", "[Function],");
            argSQLQry = argSQLQry.Replace(".Function", ".[Function]");
            argSQLQry = argSQLQry.Replace(" Status ", "[Status]");
            argSQLQry = argSQLQry.Replace(" Status,", "[Status],");
            argSQLQry = argSQLQry.Replace(".Status", ".[Status]");
            argSQLQry = argSQLQry.Replace("[", "(");
            argSQLQry = argSQLQry.Replace("]", ")");
            return argSQLQry;
        }
        public static string ConnectionString
        {
            get;
            set;
        }
        /// <summary>
        /// Get DataSet
        /// </summary>
        /// <param name="argSQLQry"></param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string argSQLQry)
        {
            try
            {
                using (DataSet dataset = new DataSet())
                {
                    argSQLQry = ModifiedSQLQuery(argSQLQry);
                    SqlDataAdapter adapter = new SqlDataAdapter(argSQLQry, SQLConnectionString);
                    adapter.Fill(dataset);
                    return dataset;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Get DataTable
        /// </summary>
        /// <param name="argSQLQry"></param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(string argSQLQry)
        {
            try
            {
                using (DataTable datatable = new DataTable())
                {
                    argSQLQry = ModifiedSQLQuery(argSQLQry);
                    SqlDataAdapter adapter = new SqlDataAdapter(argSQLQry, SQLConnectionString);
                    adapter.Fill(datatable);
                    return datatable;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Execute SQL Command
        /// </summary>
        /// <param name="argSQLQry"></param>
        /// <param name="executionCommandType"></param>
        /// <returns>Object</returns>
        public object ExecuteSQLCommand(string argSQLQry, ExecutionType executionCommandType)
        {
            try
            {
                using (SqlConnection ConnectionString = new SqlConnection(SQLConnectionString))
                {
                    ConnectionString.Open();
                    using (SqlCommand command = new SqlCommand(argSQLQry, ConnectionString))
                    {
                        object obj = DBNull.Value;
                        if (executionCommandType == ExecutionType.ReturnNothing)
                            obj = command.ExecuteNonQuery() as object;
                        else
                            obj = command.ExecuteScalar() as object;
                        return obj;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object ExecuteSQLCommand(string argSQLQry, List<SqlParameter> sqlParamCollection, ExecutionType executionCommandType)
        {
            try
            {
                using (SqlConnection ConnectionString = new SqlConnection(SQLConnectionString))
                {
                    ConnectionString.Open();
                    using (SqlCommand command = new SqlCommand(argSQLQry, ConnectionString))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        foreach (SqlParameter param in sqlParamCollection)
                        {
                            command.Parameters.Add(param);
                        }

                        object obj = DBNull.Value;
                        if (executionCommandType == ExecutionType.ReturnNothing)
                            obj = command.ExecuteNonQuery() as object;
                        else
                            obj = command.ExecuteScalar() as object;
                        return obj;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }

    public class SQLConnectionTest
    {
       public void SQLConnectionTestDemo()
        {
            SQLConnection.ConnectionString = "Data Source=CYG411;Initial Catalog=MyTest;Integrated Security=True";
            SQLConnection sqlConnection = SQLConnection.getInstance;

            Console.WriteLine(SQLConnection.ConnectionString);

            DataTable dataTable = sqlConnection.GetDataTable("SELECT * FROM City");
            DataSet dataSet = sqlConnection.GetDataSet("SELECT * FROM City");
            sqlConnection.ExecuteSQLCommand("UPDATE City Set StatusID = 10 where CityID = 10", SQLConnection.ExecutionType.ReturnNothing);

        }
    }
}
