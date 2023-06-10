using curdoperationsReact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curdoperationsReact.Interfaces
{
    public interface IuserLoginDetails
    {
        public List<UserDetails> GetUserData(int searchType, string searchText);
        public int writedata(UserDetails userDetails);

    }
}
