using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlDataAccess
    {

        private const string connectionString = @"Data Source=LEHIEU\LEHIEU;Initial Catalog=DAn_1_QLBanThuoc;Integrated Security=True;TrustServerCertificate=True";
        public static DataTable GetDataFromTable(string tableName, string columns = "*") 
        {
            string query = $"SELECT {columns} FROM {tableName}";

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                    catch { }
                }
            }

            return dataTable;
        }

        public static void ExecuteNonQuery(string sqlCommand) 
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public static DataTable GetDataFromProcedure(string procCommand)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(procCommand, connection))
                {

                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
        public static int ExecuteProcedureWithOutput(string procName, Dictionary<string, object> parameters, string outputParamName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(procName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                    SqlParameter outputParam = new SqlParameter(outputParamName, SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParam);
                    connection.Open();
                    command.ExecuteNonQuery();
                    return Convert.ToInt32(outputParam.Value);
                }
            }
        }
    }
}
