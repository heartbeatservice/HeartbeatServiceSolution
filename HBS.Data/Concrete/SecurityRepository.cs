﻿using System;
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
        private const string GetUesrByIdSp = "GetUserById";
        private const string GetUesrByUserNameSp = "GetUserByUserName";
        private const string GetUsersByCompanyIdSp = "GetUsersByCompanyId";
        private const string SearchUsersSp = "GetUserBySearchText";
        private const string IsUserNameExistsSp = "IsUserNameExists";

        public int AddUser(UserProfile user)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(AddUserSp, conn))
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
            UserProfile user = null;
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                
               
                    conn.Open();

                using (var cmd = new SqlCommand(GetUesrByIdSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@UserId"].Value = userId;

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (myReader.HasRows)
                            {
                                myReader.Read();
                                user = new UserProfile(myReader);
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            
                }

            return user;
        }

        public UserProfile GetUser(string userName)
        {
            UserProfile user = null;

            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(GetUesrByUserNameSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserName", System.Data.SqlDbType.Int);
                    cmd.Parameters["@UserName"].Value = userName;

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (myReader.HasRows)
                            {
                                myReader.Read();
                                user = new UserProfile(myReader);
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return user;

        }

        public List<UserProfile> GetUsers(int companyId)
        {
            UserProfile user = null;
            List<UserProfile> ListUserProfile = null;

            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(GetUsersByCompanyIdSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@companyId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@companyId"].Value = companyId;


                    using (var myReader = cmd.ExecuteReader())
                    {
                        
                        
                        try
                        {
                            if (myReader.HasRows)
                            {
                                
                                ListUserProfile= new List<UserProfile>();
                               
                                while (myReader.Read())
                                {

                                   
                                    user = new UserProfile(myReader);
                                    ListUserProfile.Add(user);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return ListUserProfile;
        }

        public List<UserProfile> GetUsers(int companyId,string searchText)
        {
            UserProfile user = null;
            List<UserProfile> ListUserProfile = null;

            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(SearchUsersSp, conn)) //TODO: Need a correct stored procedue name right now it has not been created. 
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@searchText", System.Data.SqlDbType.Int);
                    cmd.Parameters["@searchText"].Value = searchText;
                    cmd.Parameters.Add("@companyId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@companyId"].Value = searchText;

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (myReader.HasRows)
                            {
                                ListUserProfile = new List<UserProfile>();

                                while (myReader.Read())
                                {
                                    user = new UserProfile(myReader);
                                    ListUserProfile.Add(user);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return ListUserProfile;
        }

        public bool IsUserNameExists(int companyId,string searchText)
        {
            bool exists = false;// TODO: Stored procedure is not ready
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(IsUserNameExistsSp, conn))  
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@searchText", System.Data.SqlDbType.Int);
                    cmd.Parameters["@searchText"].Value = searchText;
                    cmd.Parameters.Add("@companyId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@companyId"].Value = searchText;

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        { 
                            if (myReader.HasRows)
                            {

                                exists = Convert.ToBoolean(myReader["Exists"].ToString()); //TODO: dont know the name of the return column name
                              
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return exists;



        }
    }
}
