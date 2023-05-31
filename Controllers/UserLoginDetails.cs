using curdoperationsReact.Interfaces;
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
        public IuserLoginDetails _IuserLoginDetails;

        public UserLoginDetails(IuserLoginDetails IuserLoginDetails)
        {
            _IuserLoginDetails = IuserLoginDetails;
        }




    }
}
