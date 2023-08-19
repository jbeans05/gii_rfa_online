using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paperless_rfa.interfaces;
using Paperless_rfa.DataAccess;
using Paperless_rfa.Models;

namespace Paperless_rfa.Controllers.WebApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAppController : ControllerBase
    {
        private readonly IUserAccess _userAccess;
        public UserAppController(IUserAccess userAccess){
            _userAccess = userAccess;
        }


        [HttpGet]
        public IEnumerable<UserApp> GetUserApps(){

            var uApp = _userAccess.GetUsers().ToList();
            if (uApp.ToList().Count > 0)
            {
                return uApp.ToList();
            }
            return null;
        }

    }
}