using HBS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBS.Data.Abstract
{
    public interface IAdminRepository
    {
        List<Module> GetModules();
        List<Module> GetModules(string modulename);
        List<Module> GetModulesByCompany(int companyid);
        List<Module> GetModulesByUser(int userid);
        Module GetModule(int moduleId);
        int AddModule(Module module);
        bool UpdateModule(int moduleId,Module module);
    }
}
