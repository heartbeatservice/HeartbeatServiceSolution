using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Entities;

namespace HBS.Data.Abstract
{
    public interface ISchedulingRepository
    {
        int AddCompany(Company company);
        bool UpdateCompany(Company company);
    }
}
