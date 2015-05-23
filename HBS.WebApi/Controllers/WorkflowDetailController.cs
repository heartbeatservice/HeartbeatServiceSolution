using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HBS.Data.Abstract;
using HBS.Data.Concrete;
using HBS.Data.Utilities;
using HBS.Entities;
using Newtonsoft.Json;
using System.Web;

namespace HBS.WebApi.Controllers
{
    public class WorkflowDetailController : ApiController
    {

        IWorkflowRepository repository = new WorkflowRepository();
        //
        // GET: /WorkflowDetail/

        
        public IList<Workflow> GetWorkflowDetail(int CompanyId, int ownerId, int workerId, int statusId, int categoryId, DateTime dueDate)
        {
            return repository.GetWorkflowDetail(CompanyId, ownerId, workerId, statusId, categoryId, dueDate);
        }

        public IList<Workflow> GetWorkflowDetail(int CompanyId, int ownerId, int workerId, int statusId, int categoryId)
        {
            return repository.GetWorkflowDetail(CompanyId, ownerId, workerId, statusId, categoryId, DateTime.MinValue);
        }

        public Workflow GetWorkflowDetail(int workflowDetailId)
        {
            return repository.GetWorkflowDetailById(workflowDetailId);
        }


        [AcceptVerbs("OPTIONS")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
