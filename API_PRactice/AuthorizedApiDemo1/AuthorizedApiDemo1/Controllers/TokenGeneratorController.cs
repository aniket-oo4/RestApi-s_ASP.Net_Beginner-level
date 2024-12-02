using AuthorizedApiDemo1.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AuthorizedApiDemo1.Controllers
{
    public class LoginDTO
    {
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
    public class TokenGeneratorController : ApiController
    {
        //
        // POST: api/TokenGenerator/
        public HttpResponseMessage Post([FromBody]LoginDTO login)
        {
            return Request.CreateResponse(HttpStatusCode.OK, CustomJwtHandler.GenerateToken(login.username, login.role));
        }

    }
}
