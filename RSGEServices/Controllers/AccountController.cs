using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RSGEServices.BLL.Models;
using RSGEServices.BLL.Services;

namespace RSGEServices.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [Route("rsLogin")]
        public async Task<User> RsLogin([FromForm] string autKey)
        {
            var service = new RSService();
            var rsLogin = service.RsLogin(autKey);
            var userModel = new User
            {
                FullName = rsLogin.Result.FullName,
                PersNo = rsLogin.Result.PersNo,
                Address = rsLogin.Result.Address,
                PayerTypeName = rsLogin.Result.PayerTypeName,
            };

            return userModel;
        }
    }
}