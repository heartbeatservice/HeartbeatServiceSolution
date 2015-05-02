using HBS.Data.Abstract;
using HBS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBS.Data.Concrete
{
    public class AdminRepository : BaseRepository, IAdminRepository
    {
        private const string GetModulesSp = "GetModules";
        private const string GetModulesByCompanyIdSp = "GetModulesByCompanyId";
        private const string GetModulesByUserIdSp = "GetModulesByUserId";

        private const string AddModuleSp = "AddModule";
        private const string UpdateModuleSp = "UpdateModule";
        private const string GetModuleSp = "GetModule";
        private const string GetCustomerAppointmentsSp = "GetCustomerAppointments";
        public List<Module> GetModules()
        {
            List<Module> lstModules = null;
            Module module = null;
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(GetModulesSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (myReader.HasRows)
                            {
                                lstModules = new List<Module>();
                                while (myReader.Read())
                                {
                                    module = new Module(myReader);
                                    lstModules.Add(module);
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

            return lstModules;
        }

        public int AddModule(Module module)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(AddModuleSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ModuleName", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@ModuleName"].Value = module.ModuleName;

                    cmd.Parameters.Add("@ModuleDescription", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@ModuleDescription"].Value = module.ModuleDescription;

                    cmd.Parameters.Add("@ModuleDisplayOrder", System.Data.SqlDbType.Int);
                    cmd.Parameters["@ModuleDisplayOrder"].Value = module.DisplayOrder;

                    cmd.Parameters.Add("@ModuleURL", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@ModuleURL"].Value = module.ModuleURL;

                    cmd.Parameters.Add("@IsForAll", System.Data.SqlDbType.Bit);
                    cmd.Parameters["@IsForAll"].Value = module.IsForAll;


                    cmd.Parameters.Add("@ParentId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@ParentId"].Value = module.ParentId;

                    cmd.Parameters.Add("@IconName", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@IconName"].Value = module.IconName;

                    cmd.Parameters.Add("@CompanyId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CompanyId"].Value = module.CompanyId;

                    return Convert.ToInt16(cmd.ExecuteScalar());

                }
            }
        }

        public bool UpdateModule(int moduleId,Module module)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(UpdateModuleSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModuleId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@ModuleId"].Value = moduleId;

                    cmd.Parameters.Add("@ModuleName", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@ModuleName"].Value = module.ModuleName;

                    cmd.Parameters.Add("@ModuleDescription", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@ModuleDescription"].Value = module.ModuleDescription;

                    cmd.Parameters.Add("@ModuleDisplayOrder", System.Data.SqlDbType.Int);
                    cmd.Parameters["@ModuleDisplayOrder"].Value = module.DisplayOrder;

                    cmd.Parameters.Add("@ModuleURL", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@ModuleURL"].Value = module.ModuleURL;

                    cmd.Parameters.Add("@IsForAll", System.Data.SqlDbType.Bit);
                    cmd.Parameters["@IsForAll"].Value = module.IsForAll;


                    cmd.Parameters.Add("@ParentId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@ParentId"].Value = module.ParentId;

                    cmd.Parameters.Add("@IconName", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@IconName"].Value = module.IconName;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Module> GetModules(int companyid, string modulename)
        {

            var moduel = new List<Module>();
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(GetModulesSp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CompanyId"].Value = companyid;
                    cmd.Parameters.Add("@ModuleName", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@ModuleName"].Value = modulename;
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                moduel.Add(new Module(myReader));
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return moduel;



        }

        public Module GetModule(int moduleId)
        {

            var moduel = new Module();
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(GetModuleSp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ModuleId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@ModuleId"].Value = moduleId;
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                moduel = new Module(myReader);
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return moduel;



        }

        public List<Module> GetModulesByCompany(int companyid)
        {
            List<Module> lstModules = null;
            Module module = null;
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(GetModulesByCompanyIdSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CompanyId"].Value = companyid;
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (myReader.HasRows)
                            {
                                lstModules = new List<Module>();
                                while (myReader.Read())
                                {
                                    module = new Module(myReader);
                                    lstModules.Add(module);
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

            return lstModules;
        }

        public List<Module> GetModulesByUser(int userid)
        {
            List<Module> lstModules = null;
            Module module = null;
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(GetModulesByUserIdSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@UserId"].Value = userid;

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (myReader.HasRows)
                            {
                                lstModules = new List<Module>();
                                while (myReader.Read())
                                {
                                    module = new Module(myReader);
                                    lstModules.Add(module);
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

            return lstModules;
        }
    }
}
