using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace OrderManagement_Api.Controllers.Test
{
    public class TestController : ApiController
    {
        [Authorize(Users = "DRN/0058")]
        [HttpGet]
        [Route("api/test/Res1")]
        public IHttpActionResult GetRsuorce1()
        {
            var Identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello" + Identity.Name);
        }

        [Authorize]
        [HttpGet]
        [Route("api/test/Res2")]
        public IHttpActionResult GetResource2()
        {
            var identity = (ClaimsIdentity)User.Identity;
            //var Role = identity.Claims
            //          .FirstOrDefault(c => c.Type == "Admin").Value;
            var UserName = identity.Name;
            //var Email = identity.Claims.FirstOrDefault(c => c.Type == "Email").Value;

            return Ok("Hello " + UserName + ", Your Role ID is :Test");

        }


    }
}
