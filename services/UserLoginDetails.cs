using webapi.DataAccess;
using webapi.Models;
using webapi.Utilitiy;
using System.Data.SqlClient;
using System.Data;
using webapi.Interfaces;

namespace webapi.services
{
    public class UserLoginDetails : IuserLoginDetails, IpostDetails
    {
        private string connectionString { get;set; }
        public UserLoginDetails()
        {

        }
        public List<UserDetails> GetUserData(int searchType, string searchText)
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
        public int writedata(UserDetails userDetails)
        {
            LoadConnectionString connectionString = new LoadConnectionString();
            DatabaseManager databaseManager = new DatabaseManager(connectionString.LoadString());


            SqlParameter[] sqlparameter = new SqlParameter[] {
             new SqlParameter("@Username", SqlDbType.NVarChar) { Value = userDetails.Username, Size = 50 },
             new SqlParameter("@password", SqlDbType.NVarChar) { Value = userDetails.password, Size = 50 },
             new SqlParameter("@EmailId", SqlDbType.NVarChar) { Value = userDetails.EmailId, Size = 50 },
             new SqlParameter("@BloadGrup", SqlDbType.NVarChar) { Value = userDetails.BloadGru, Size = 50 },
             new SqlParameter("@CreateAT", SqlDbType.DateTime){ Value=userDetails.CreateAT },
             new SqlParameter("@UpdateAT", SqlDbType.DateTime){ Value=userDetails.UpdateAT },
            };

            int result = databaseManager.WriteData("NCRE_USER_Insert", sqlparameter);
            return result;

        }

        public int Deletedata(int UserID)
        {
            LoadConnectionString connectionString = new LoadConnectionString();
            DatabaseManager databaseManager = new DatabaseManager(connectionString.LoadString());


            SqlParameter[] sqlparameter = new SqlParameter[] {
             new SqlParameter("@UserID", SqlDbType.Int) { Value = UserID },
             
            };

            int result = databaseManager.DeleteData("NCRE_USER_Detele", sqlparameter);
            return result;

        }


    }
}
