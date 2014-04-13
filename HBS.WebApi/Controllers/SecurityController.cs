using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HBS.Data.Entities;
using HBS.Data.Abstract;
using HBS.Data.Concrete;
using HBS.Entities;

namespace HBS.WebApi.Controllers
{
    public class SecurityController : ApiController
    {
        public ISecurityRepository securityEntity;

        public SecurityController(ISecurityRepository repo)
        {
            this.securityEntity = repo;
            

         }

        public UserProfile GetUserByName(string id)
        {
            return securityEntity.GetUser(id);
        }

        public void PostUser([FromBody] UserProfile user)
        {
            securityEntity.AddUser(user);
        }

        }
}
