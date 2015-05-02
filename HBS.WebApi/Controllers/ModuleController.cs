using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HBS.Data.Abstract;
using HBS.Data.Concrete;
using HBS.Entities;
using System.Web;
using HBS.WebApi.Models;

namespace HBS.WebApi.Controllers
{
    public class ModuleController : ApiController
    {
        //
        // GET: /Admin/
        IAdminRepository repository;
        public ModuleController(IAdminRepository repo)
        {
            repository = repo;
        }
        public IList<Module> GetModules(int companyId, int userId, string role)
        {
            if (role == "1")
            {
                return BuildSubMenu(repository.GetModules(-1, ""));
            }
            else if (role == "2")
            {
                return BuildSubMenu(repository.GetModulesByCompany(companyId));
            }
            else if (role == "3")
            {
                return BuildSubMenu(repository.GetModulesByUser(userId));
            }
            else return null;

        }
        private List<Module> BuildSubMenu(List<Module> module)
        {
            List<Module> pModule = module.Where(i => i.ParentId == 0).ToList();
            List<Module> cModule = module.Where(i => i.ParentId != 0).ToList();
            foreach (var item in pModule)
            {
                List<Module> tModule = cModule.Where(i => i.ParentId == item.ModuleId).ToList();
                if (tModule.Count > 0)
                {
                    item.SubModule = new List<Module>();
                    foreach (var im in tModule)
                    {
                        item.SubModule.Add(im);
                    }
                }
            }
            return pModule;
        }

        public int PostModule([FromBody] Module module)
        {
            return repository.AddModule(module);
        }


        public List<Module> GetModule(int CompanyId, String ModuleName)
        {
            return repository.GetModules(CompanyId, ModuleName);

        }
        public Module GetModule(int ModuleId)
        {
            return repository.GetModule(ModuleId);

        }
        [HttpPut]
        public bool PutModuleUpdate(int id, [FromBody] Module module)
        {
            return repository.UpdateModule(id,module);
        }
        [AcceptVerbs("OPTIONS")]
        public HttpResponseMessage Options()
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);

            return resp;
        }

    }
}
