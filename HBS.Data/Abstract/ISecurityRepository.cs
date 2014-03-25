using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Entities;

namespace HBS.Data.Abstract
{
    public interface ISecurityRepository
    {
        int AddUser(UserProfile user);
        bool UpdateUser(UserProfile user);
        UserProfile GetUser(int userId);
        UserProfile GetUser(string userName);
        List<UserProfile> GetUsers(int companyId);
        List<UserProfile> GetUsers(string searchText);
        bool IsUserNameExists(string searchText);
    }
}
