using System.Data.SqlClient;
using System.Data;
using webapi.DataAccess;
using webapi.Models;
using webapi.Utilitiy;
using webapi.Interfaces;

namespace webapi.services
{
    public class postDetailsService: UserLoginDetails
    {

        public List<UserDetails> GetPostData(int searchType, string searchText)
        {
            List<UserDetails> userDetails = new List<UserDetails>();

            LoadConnectionString connectionString = new LoadConnectionString();
            DatabaseManager databaseManager = new DatabaseManager(connectionString.LoadString());

            SqlParameter[] sqlparameter = new SqlParameter[] {
              new SqlParameter("@searchtype", SqlDbType.Int )  { Value = searchType },
              new SqlParameter("@searchText", SqlDbType.NVarChar) { Value = searchText,Size=50 },

            };
            DataTable dataTable = databaseManager.ReadData("NCRE_USER_RD", sqlparameter);

            userDetails = dataTable.AsEnumerable()
            .Select(row => new UserDetails
            {
                ID = row.Field<int>("ID"),
                Username = row.Field<string>("Username"),
                EmailId = row.Field<string>("EmailId"),
                BloadGru = row.Field<string>("BloadGru"),
                CreateAT = row.Field<DateTime>("CreateAT"),
                UpdateAT = row.Field<DateTime>("UpdateAT"),
            }).ToList();
            return userDetails;
        }

    }
}
