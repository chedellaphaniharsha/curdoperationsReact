using curdoperationsReact.Interfaces;
using curdoperationsReact.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curdoperationsReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginDetails : ControllerBase
    {
        public readonly IuserLoginDetails _IuserLoginDetails;

        public UserLoginDetails(IuserLoginDetails IuserLoginDetails)
        {
            _IuserLoginDetails = IuserLoginDetails;
        }
        [HttpGet]
        [Route("GetUserDetails")]
        public List<UserDetails> GetUserDetails(int searchtype, string searchtext )
        {
            List<UserDetails> userDetails = new List<UserDetails>();
            userDetails= _IuserLoginDetails.GetUserData(searchtype, searchtext);
            return userDetails;

        }

        [HttpPost]
        [Route("InsertUserDetails")]
        public Response WriteUserDetail([FromBody] UserDetails userDetails)
        {
            Response response = new Response();
            response.result = _IuserLoginDetails.writedata(userDetails);
            response.message = (response.result == 1) ? Status.SuccessfullyRegistered.ToString() : Status.ExceptionOccurred.ToString();

            return response;
        }



    }
}
