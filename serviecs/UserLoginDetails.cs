using curdoperationsReact.DataAccess;
using curdoperationsReact.Interfaces;
using curdoperationsReact.Models;
using curdoperationsReact.Utilitiy;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace curdoperationsReact.serviecs
{
    public class UserLoginDetails: IuserLoginDetails
    {
        public UserLoginDetails()
        {

        }
        public List<UserDetails> GetUserData(int searchType, string searchText)
        {
            List<UserDetails> userDetails = new List<UserDetails>();

            LoadConnectionString connectionString = new LoadConnectionString();
            DatabaseManager databaseManager = new DatabaseManager(connectionString.LoadString());

            SqlParameter[] sqlparameter = new SqlParameter[] {
              new SqlParameter("@searchtype", searchType ),
              new SqlParameter("@searchText", searchText),

            };
         DataTable dataTable= databaseManager.ReadData("NCRE_USER_RD", sqlparameter);

            userDetails = dataTable.AsEnumerable()
            .Select(row => new UserDetails
            {
                ID       = row.Field<int>("ID"),
                Username = row.Field<string>("Username"),
                EmailId  = row.Field<string>("EmailId"),
                BloadGru = row.Field<string>("BloadGru"),
                CreateAT = row.Field<string>("CreateAT"),
                UpdateAT = row.Field<string>("UpdateAT"),
            }).ToList();
            return userDetails;
        }
         public int writedata(UserDetails userDetails)
        {
            LoadConnectionString connectionString = new LoadConnectionString();
            DatabaseManager databaseManager = new DatabaseManager(connectionString.LoadString());


            SqlParameter[] sqlparameter = new SqlParameter[] {
              new SqlParameter("@Username", userDetails.Username ),
              new SqlParameter("@password", userDetails.password),
              new SqlParameter("@EmailId",  userDetails.EmailId),
              new SqlParameter("@BloadGrup",userDetails.BloadGru ),
              new SqlParameter("@CreateAT", userDetails.CreateAT),
              new SqlParameter("@UpdateAT", userDetails.UpdateAT),

            };

            int result = databaseManager.WriteData("NCRE_USER_Insert", sqlparameter);
            return 1;

        }

    }
}
