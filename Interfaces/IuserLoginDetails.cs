using webapi.Models;

namespace webapi.Interfaces
{
    public interface IuserLoginDetails
    {
        public List<UserDetails> GetUserData(int searchType, string searchText);
        //public int writedata(UserDetails userDetails);
        public int Deletedata(int UserID);
       
    }
}
