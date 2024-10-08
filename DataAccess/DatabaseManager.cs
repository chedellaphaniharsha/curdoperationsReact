﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.DataAccess
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
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(commenttext, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(parameters);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }

                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dataTable;
        }



        public int DeleteData(string commenttext, SqlParameter[] parameters)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(commenttext, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(parameters);
                         rowsAffected = command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return rowsAffected;
        }

        public int WriteData(string commenttext, SqlParameter[] parameters)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(commenttext, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(parameters);
                        result = command.ExecuteNonQuery();

                    }
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                result = 2;
                ex.ToString();

            }
            return result;
        }

    }
}
