using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Masterz_N
{
    public class DataManager
    {
        private static readonly Lazy<DataManager> lazy = new Lazy<DataManager>(() => new DataManager());
        private string connectionString;

        private DataManager()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Masterz"].ConnectionString;
        }
        public static DataManager Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public DataTable GetData(string pSP, Dictionary<string, string> dicParam)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                using (MySqlCommand command = new MySqlCommand(pSP, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (dicParam != null && dicParam.Count > 0)
                    {
                        AddParam(command, dicParam);
                    }
                    try
                    {
                        connection.Open();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(command))
                        {   // this will query your database and return the result to your datatable
                            da.Fill(dt);
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        //log
                    }
                    finally
                    {
                        if (connection.State != ConnectionState.Closed)
                        {
                            connection.Close();
                        }
                    }
                }
            }
            return dt;
        }

        public bool InsertUpdate(string queryString, Dictionary<string, string> dicParam)
        {
            bool ret = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (dicParam != null && dicParam.Count > 0)
                    {
                       // AddParam(command, dicParam);
                    }

                    try
                    {
                        connection.Open();
                        ret = command.ExecuteNonQuery() > 0 ? true : false;
                    }
                    catch (Exception ex)
                    {
                        //log
                    }
                    finally
                    {
                        if (connection.State != ConnectionState.Closed)
                        {
                            connection.Close();
                        }
                    }
                }
            }
            return ret;
        }

        private void AddParam(MySqlCommand command, Dictionary<string, string> dicParam)
        {
            foreach (var item in dicParam)
            {
                if (!string.IsNullOrEmpty(item.Value))
                {
                    command.Parameters.AddWithValue(item.Key, item.Value);
                }
                else
                {
                    command.Parameters.AddWithValue(item.Key, DBNull.Value);
                }
            }
        }

    }
}
