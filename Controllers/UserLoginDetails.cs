using webapi.Interfaces;
using webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserLoginDetails : ControllerBase
    {
        public readonly IuserLoginDetails _IuserLoginDetails;
        public readonly IpostDetails _ipostDetails;

        public UserLoginDetails(IuserLoginDetails IuserLoginDetails, IpostDetails ipostDetails)
        {
            _IuserLoginDetails = IuserLoginDetails;
            _ipostDetails = ipostDetails;
        }
        [HttpGet]
        [Route("GetUserDetails")]
        public List<UserDetails> GetUserDetails(int searchtype, string searchtext)
        {
            List<UserDetails> userDetails = new List<UserDetails>();
            userDetails = _IuserLoginDetails.   GetUserData(searchtype, searchtext);
            return userDetails;

        }
        [HttpDelete]
        [Route("DeleteUserDetails")]
        public Response UserDetailsDelete(int Userid)
        {
            Response response = new Response();
            response.result = _IuserLoginDetails.Deletedata(Userid);
            response.message = (response.result == 1) ? Status.SuccessfullyRegistered.ToString() : Status.ExceptionOccurred.ToString();
            return response;
       
        }

        [HttpPost]
        [Route("InsertUserDetails")]
        public Response WriteUserDetail([FromBody] UserDetails userDetails)
        {
            Response response = new Response();
            response.result = _ipostDetails.writedata(userDetails);
            response.message = (response.result == 1) ? Status.SuccessfullyRegistered.ToString() : Status.ExceptionOccurred.ToString();

            return response;
        }



    }
}
