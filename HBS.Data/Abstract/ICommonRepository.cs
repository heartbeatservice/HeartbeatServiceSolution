using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Entities;

namespace HBS.Data.Abstract
{
    public interface ICommonRepository
    {
        int AddCompany(Company company);
        bool UpdateCompany(Company company);

        List<Company> GetAllCompanies();
        List<Company> GetCompany(string companyName);
        Company GetCompnay(int compnayId);
        bool RemoveCompany(int compnayId);


        bool AddInsurance(Insurance insurance);
        bool UpdateInsurance(Insurance insurance);
        List<Insurance> GetInsurance(int companyId, string insuranceName);
        Insurance GetInsurance(int insuranceId);
        bool RemoveInsurance(int insuranceId);




    }
}
