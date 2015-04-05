using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Mail;
using HBS.Entities;
using HBS.Data.Abstract;

namespace HBS.WebPortal.Controllers
{
    public class StudentController : ApiController
    {
        ICommonRepository repository;

        public StudentController(ICommonRepository repo)
        {
            repository = repo;
        }
        public bool PostSaveStudent([FromBody]Student student)
        {
            return repository.AddStudent(student);
        }

        [AcceptVerbs("OPTIONS")]
        public HttpResponseMessage Options()
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);

            return resp;
        }
    }
}
