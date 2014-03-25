using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Data.Abstract;
using HBS.Entities;

namespace HBS.Data.Concrete
{
    public class SecurityRepository : BaseRepository, ISecurityRepository
    {
        private const string AddUserSp = "AddUser";
        private const string UpdateUserSp = "UpdateUser";

        public int AddUser(UserProfile user)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("AddUserSp", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CompanyId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CompanyId"].Value = user.CompanyId;

                    cmd.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@UserName"].Value = user.UserName;

                    cmd.Parameters.Add("@Password", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@Password"].Value = user.Password;

                    cmd.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@FirstName"].Value = user.FirstName;

                    cmd.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@LastName"].Value = user.LastName;

                    cmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@Email"].Value = user.Email;

                    cmd.Parameters.Add("@CreatedBy", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CreatedBy"].Value = user.CreatedBy;

                    cmd.Parameters.Add("@CreatedDate", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CreatedDate"].Value = DateTime.UtcNow;

                    return (int)cmd.ExecuteScalar();

                }
            }
        }

        public bool UpdateUser(UserProfile user)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(UpdateUserSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@UserId"].Value = user.UserId;

                    cmd.Parameters.Add("@CompanyId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CompanyId"].Value = user.CompanyId;

                    cmd.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@UserName"].Value = user.UserName;

                    cmd.Parameters.Add("@Password", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@Password"].Value = user.Password;

                    cmd.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@FirstName"].Value = user.FirstName;

                    cmd.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@LastName"].Value = user.LastName;

                    cmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@Email"].Value = user.Email;

                    cmd.Parameters.Add("@UpdatedBy", System.Data.SqlDbType.Int);
                    cmd.Parameters["@UpdatedBy"].Value = user.UpdatedBy;

                    cmd.Parameters.Add("@UpdatedDate", System.Data.SqlDbType.Int);
                    cmd.Parameters["@UpdatedDate"].Value = DateTime.UtcNow;

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        public UserProfile GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public UserProfile GetUser(string userName)
        {
            throw new NotImplementedException();
        }

        public List<UserProfile> GetUsers(int companyId)
        {
            throw new NotImplementedException();
        }

        public List<UserProfile> GetUsers(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool IsUserNameExists(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
