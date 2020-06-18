using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HIS.Models
{
    public class SqlHelper
    {

            private string ConnectionString { get; set; }

            public SqlHelper()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();
            }

            public void CloseConnection(SqlConnection connection)
            {
                connection.Close();
            }

            public SqlParameter CreateParameter(string name, object value, DbType dbType)
            {
                return CreateParameter(name, 0, value, dbType, ParameterDirection.Input);
            }

            public SqlParameter CreateParameter(string name, int size, object value, DbType dbType)
            {
                return CreateParameter(name, size, value, dbType, ParameterDirection.Input);
            }

            public SqlParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
            {
                return new SqlParameter
                {
                    DbType = dbType,
                    ParameterName = name,
                    Size = size,
                    Direction = direction,
                    Value = value
                };
            }

            public DataTable GetDataTable(string commandText, CommandType commandType, SqlParameter[] parameters = null)
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = commandType;
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        var dataset = new DataSet();
                        var dataAdaper = new SqlDataAdapter(command);
                        dataAdaper.Fill(dataset);

                        return dataset.Tables[0];
                    }
                }
            }

            public DataSet GetDataSet(string commandText, CommandType commandType, SqlParameter[] parameters = null)
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = commandType;
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        var dataset = new DataSet();
                        var dataAdaper = new SqlDataAdapter(command);
                        dataAdaper.Fill(dataset);

                        return dataset;
                    }
                }
            }

            public IDataReader GetDataReader(string commandText, CommandType commandType, SqlParameter[] parameters, out SqlConnection connection)
            {
                IDataReader reader = null;
                connection = new SqlConnection(ConnectionString);
                connection.Open();

                var command = new SqlCommand(commandText, connection);
                command.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }

                reader = command.ExecuteReader();

                return reader;
            }

            public void Delete(string commandText, CommandType commandType, SqlParameter[] parameters = null)
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = commandType;
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        command.ExecuteNonQuery();
                    }
                }
            }

            public void Insert(string commandText, CommandType commandType, SqlParameter[] parameters)
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = commandType;
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        command.ExecuteNonQuery();
                    }
                }
            }

            public int Insert(string commandText, CommandType commandType, SqlParameter[] parameters, out int lastId)
            {
                lastId = 0;
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = commandType;
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        object newId = command.ExecuteScalar();
                        lastId = Convert.ToInt32(newId);
                    }
                }

                return lastId;
            }

   
        public long Insert(string commandText, CommandType commandType, SqlParameter[] parameters, out long lastId)
            {
                lastId = 0;
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = commandType;
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        object newId = command.ExecuteScalar();
                        lastId = Convert.ToInt64(newId);
                    }
                }

                return lastId;
            }

            public void InsertWithTransaction(string commandText, CommandType commandType, SqlParameter[] parameters)
            {
                SqlTransaction transactionScope = null;
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    transactionScope = connection.BeginTransaction();

                    using (var command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = commandType;
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        try
                        {
                            command.ExecuteNonQuery();
                            transactionScope.Commit();
                        }
                        catch (Exception)
                        {
                            transactionScope.Rollback();
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }

            public void InsertWithTransaction(string commandText, CommandType commandType, IsolationLevel isolationLevel, SqlParameter[] parameters)
            {
                SqlTransaction transactionScope = null;
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    transactionScope = connection.BeginTransaction(isolationLevel);

                    using (var command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = commandType;
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        try
                        {
                            command.ExecuteNonQuery();
                            transactionScope.Commit();
                        }
                        catch (Exception)
                        {
                            transactionScope.Rollback();
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }

            public void Update(string commandText, CommandType commandType, SqlParameter[] parameters)
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = commandType;
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        command.ExecuteNonQuery();
                    }
                }
            }

            public void UpdateWithTransaction(string commandText, CommandType commandType, SqlParameter[] parameters)
            {
                SqlTransaction transactionScope = null;
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    transactionScope = connection.BeginTransaction();

                    using (var command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = commandType;
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        try
                        {
                            command.ExecuteNonQuery();
                            transactionScope.Commit();
                        }
                        catch (Exception exxx)
                        {
                            transactionScope.Rollback();
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }

            public void UpdateWithTransaction(string commandText, CommandType commandType, IsolationLevel isolationLevel, SqlParameter[] parameters)
            {
                SqlTransaction transactionScope = null;
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    transactionScope = connection.BeginTransaction(isolationLevel);

                    using (var command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = commandType;
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        try
                        {
                            command.ExecuteNonQuery();
                            transactionScope.Commit();
                        }
                        catch (Exception)
                        {
                            transactionScope.Rollback();
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }

     public   static DataTable ConvertListToDataTable(List<string[]> list)
        {
            // New table.
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }

            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }

        public List<Dictionary<string, object>> GetTableRows(DataTable dtData)
        {
            List<Dictionary<string, object>>
            lstRows = new List<Dictionary<string, object>>();
            Dictionary<string, object> dictRow = null;

            foreach (DataRow dr in dtData.Rows)
            {
                dictRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtData.Columns)
                {
                    dictRow.Add(col.ColumnName, dr[col]);
                }
                lstRows.Add(dictRow);
            }
            return lstRows;
        }

        public static class CommonMethod
        {
            public static List<T> ConvertToList<T>(DataTable dt)
            {
                var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
                var properties = typeof(T).GetProperties();
                return dt.AsEnumerable().Select(row =>
                {
                    var objT = Activator.CreateInstance<T>();
                    foreach (var pro in properties)
                    {
                        if (columnNames.Contains(pro.Name.ToLower()))
                        {
                            try
                            {
                                pro.SetValue(objT, row[pro.Name]);
                            }
                            catch (Exception ex) { }
                        }
                    }
                    return objT;
                }).ToList();
            }



        }

        public object GetScalarValue(string commandText, CommandType commandType, SqlParameter[] parameters = null)
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = commandType;
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        return command.ExecuteScalar();
                    }
                }
            }
        }
    }
