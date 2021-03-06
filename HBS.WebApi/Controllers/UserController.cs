﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HBS.Data.Abstract;
using HBS.Data.Concrete;
using HBS.Entities;
namespace HBS.WebApi.Controllers
{
    public class UserController : ApiController
    {
        public ISecurityRepository securityEntity;

        public UserController(ISecurityRepository repo)
        {
            this.securityEntity = repo;
        }
                
        public UserProfile GetUser(string id)
        {
            return securityEntity.GetUser(Convert.ToInt32(id));
        }
        public int PostUser([FromBody] UserProfile user)
        {
            return securityEntity.AddUser(user);
        }

        public IEnumerable<KendoDDL> Get(HttpRequestMessage requestMessage)
        {
            return securityEntity.GetAllUsers().ToList();
        }
        public IList<Role> GetAllRole(string RoleName)
        {
            return securityEntity.GetAllRoles().ToList();
        }

        public List<UserProfile> GetUsers(string UserName)
        {
            return securityEntity.GetUsers(-1, UserName).ToList();
        }

        public List<UserProfile> GetUsers(string UserName, int CompanyId)
        {
            return securityEntity.GetUsers(CompanyId, UserName).ToList();
        }

        public List<KendoDDL> GetCompanyUsers(int CompanyId)
        {
            List<KendoDDL> users = new List<KendoDDL>();

            var u = securityEntity.GetUsers(CompanyId, "");
            if (u != null)
            {
                u.ToList().ForEach(i => users.Add(new KendoDDL { text = i.UserName, value = i.UserId }));
            }            
            return users;
        }
        [HttpPut]
        public bool PutUserUpdate([FromBody] UserProfile user)
        {
            return securityEntity.UpdateUser(user);
        }
        [AcceptVerbs("OPTIONS")]
        public HttpResponseMessage Options()
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);

            return resp;
        }
    }
}
