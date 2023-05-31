using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace curdoperationsReact.DataAccess
{
    public class DatabaseManager
    {
        private string connectionstring;

        public DatabaseManager(string connectionString)
        {
            this.connectionstring = connectionString;
        }
        public DataTable ReadData(string commenttext, SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //connection.Open();
                using (SqlCommand command = new SqlCommand(commenttext, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(parameters);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                        reader.Close();
                    }

                }
                connection.Close();
            }
                        return dataTable;
        }
        public int WriteData(string commenttext, SqlParameter[] parameters)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(commenttext, connection))
                {
                    
                    command.Parameters.Add(parameters);
                    result = command.ExecuteNonQuery();
                }
            }
                return result;
        }

    }
}
