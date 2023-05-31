//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Threading.Tasks;

//namespace curdoperationsReact.DataAccess
//{
//    public class GenericTable<T> where T:new()

//    {

//        private string connectionString;

//        public GenericTable(string connectionString)
//        {
//            this.connectionString = connectionString;
//        }

//        public List<T> GetAll(string tableName)
//        {
//            string query = $"SELECT * FROM {tableName}";
//            DataTable dataTable = ExecuteQuery(query);

//            List<T> entities = MapDataTableToEntities(dataTable);
//            return entities;
//        }

//        public T GetById(string tableName, int id)
//        {
//            string query = $"SELECT * FROM {tableName} WHERE Id = @Id";
//            SqlParameter parameter = new SqlParameter("@Id", id);
//            DataTable dataTable = ExecuteQuery(query, parameter);

//            T entity = MapDataRowToEntity(dataTable.Rows[0]);
//            return entity;
//        }

//        public void Insert(string tableName, T entity)
//        {
//            Dictionary<string, object> parameters = GetEntityParameters(entity);
//            string query = BuildInsertQuery(tableName, parameters);

//            ExecuteNonQuery(query, parameters);
//        }

//        public void Update(string tableName, int id, T entity)
//        {
//            Dictionary<string, object> parameters = GetEntityParameters(entity);
//            parameters["Id"] = id;
//            string query = BuildUpdateQuery(tableName, parameters);

//            ExecuteNonQuery(query, parameters);
//        }

//        public void Delete(string tableName, int id)
//        {
//            string query = $"DELETE FROM {tableName} WHERE Id = @Id";
//            SqlParameter parameter = new SqlParameter("@Id", id);

//            ExecuteNonQuery(query, parameter);
//        }

//        private DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();

//                using (SqlCommand command = new SqlCommand(query, connection))
//                {
//                    command.Parameters.AddRange(parameters);

//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        DataTable dataTable = new DataTable();
//                        dataTable.Load(reader);

//                        return dataTable;
//                    }
//                }
//            }
//        }

//        private int ExecuteNonQuery(string query, params SqlParameter[] parameters)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();

//                using (SqlCommand command = new SqlCommand(query, connection))
//                {
//                    command.Parameters.AddRange(parameters);

//                    return command.ExecuteNonQuery();
//                }
//            }
//        }

//        private List<T> MapDataTableToEntities(DataTable dataTable)
//        {
//            List<T> entities = new List<T>();

//            foreach (DataRow row in dataTable.Rows)
//            {
//                T entity = MapDataRowToEntity(row);
//                entities.Add(entity);
//            }

//            return entities;
//        }

//        private T MapDataRowToEntity(DataRow row)
//        {
//            T entity = new T();

//            foreach (DataColumn column in row.Table.Columns)
//            {
//                string propertyName = column.ColumnName;
//                object value = row[column];

//                entity.GetType().GetProperty(propertyName)?.SetValue(entity, value);
//            }

//            return entity;
//        }

//        private Dictionary<string, object> GetEntityParameters(T entity)
//        {
//            Dictionary<string, object> parameters = new Dictionary<string, object>();

//            foreach (var property in entity.GetType().GetProperties())
//            {
//                string propertyName = property.Name;
//                object value = property.GetValue(entity);

//                parameters.Add(propertyName, value);
//            }

//            return parameters;
//        }

//        private string BuildInsertQuery(string tableName, Dictionary<string, object> parameters)
//        {
//            string query = $"INSERT INTO {tableName} ({string.Join(", ", parameters.Keys)}) VALUES (";

//            foreach (var parameter in parameters)
//            {
//                query += $"@{parameter.Key}, ";
//            }

//            query = query.TrimEnd(',', ' ') + ")";

//            return query;
//        }

//        private string BuildUpdateQuery(string tableName, Dictionary<string, object> parameters)
//        {
//            string query = $"UPDATE {tableName} SET ";

//            foreach (var parameter in parameters)
//            {
//                if (parameter.Key != "Id")
//                {
//                    query += $"{parameter.Key} = @{parameter.Key}, ";
//                }
//            }

//            query = query.TrimEnd(',', ' ');
//            query += " WHERE Id = @Id";

//            return query;
//        }
//    }


//}
//}
