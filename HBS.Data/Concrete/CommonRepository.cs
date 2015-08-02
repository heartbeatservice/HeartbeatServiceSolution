using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Data.Abstract;
using HBS.Entities;
using System.Data;
using System.Net.Mail;
using System.Configuration;

namespace HBS.Data.Concrete
{
    public class CommonRepository : BaseRepository, ICommonRepository
    {
        private const string AddCompanySp = "AddCompany";
        private const string AssignCompanyModuleSp = "AssignCompanyModule";
        private const string UpdateCompanySp = "UpdateCompany";
        private const string GetCompanyByIdSp = "GetCompanyById";
        private const string UpdateInsuranceSp = "UpdateInsurance";
        private const string GetCompaniesSp = "GetCompanies";
        private const string AddInsuranceSp = "AddInsurance";
        private const string GetInsurancesSp = "GetInsurances";
        private const string GetInsuranceByIdSp = "GetInsuranceById";
        private const string AddStudentSp = "AddStudent";
        private const string GetAppointmentsSp = "GetAppointments";


        public bool AddStudent(Student student)//
        {

            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(AddStudentSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@FirstName"].Value = student.FirstName;

                    cmd.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@LastName"].Value = (student.LastName == null ? "" : student.LastName);

                    cmd.Parameters.Add("@EmailAddress", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@EmailAddress"].Value = student.EmailAddress;

                    cmd.Parameters.Add("@Gendar", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@Gendar"].Value = (student.Gendar == null ? "" : student.Gendar);

                    cmd.Parameters.Add("@Profession", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@Profession"].Value = (student.Profession == null ? "" : student.Profession);

                    cmd.Parameters.Add("@Source", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@Source"].Value = (student.Source == null ? "" : student.Source);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        SendMail(new EmailMessage
                        {
                            ToEmail = student.EmailAddress,
                            Subject = ConfigurationManager.AppSettings["CourseEmailSubject"],
                            Message = ConfigurationManager.AppSettings["CourseEmailMessage"]
                        });
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
        }
        public int AddCompany(Company company)//
        {

            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(AddCompanySp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CompanyName", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@CompanyName"].Value = company.CompanyName;

                    cmd.Parameters.Add("@Description", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@Description"].Value = company.Description;

                    cmd.Parameters.Add("@CreatedBy", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CreatedBy"].Value = company.CreatedBy;

                    cmd.Parameters.Add("@UpdatedBy", System.Data.SqlDbType.Int);
                    cmd.Parameters["@UpdatedBy"].Value = company.UpdatedBy;

                    int i= Convert.ToInt16(cmd.ExecuteScalar());
                    if (i > 0)
                    {
                        cmd.CommandText = AssignCompanyModuleSp;
                        cmd.Parameters.Clear();

                        cmd.Parameters.Add("@CompanyId", System.Data.SqlDbType.Int);
                        cmd.Parameters["@CompanyId"].Value = i;

                        cmd.Parameters.Add("@ModuleId", System.Data.SqlDbType.Int);
                        foreach (var item in company.LstModules)
                        {
                            cmd.Parameters["@ModuleId"].Value = item;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    return i;
                }

            }
        }
        public bool UpdateCompany(Company company)//
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(UpdateCompanySp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CompanyId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CompanyId"].Value = company.CompanyId;

                    cmd.Parameters.Add("@CompanyName", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@CompanyName"].Value = company.CompanyName;

                    cmd.Parameters.Add("@Description", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@Description"].Value = company.Description;

                    cmd.Parameters.Add("@UpdatedBy", System.Data.SqlDbType.Int);
                    cmd.Parameters["@UpdatedBy"].Value = company.UpdatedBy;

                    cmd.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit);
                    cmd.Parameters["@IsActive"].Value = company.IsActive;

                    bool b = cmd.ExecuteNonQuery() > 0;
                    if (b)
                    {
                        cmd.CommandText = "Delete from dbo.CompanyModules WHERE companyId=" + company.CompanyId;
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Clear();
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = AssignCompanyModuleSp;
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.Add("@CompanyId", System.Data.SqlDbType.Int);
                        cmd.Parameters["@CompanyId"].Value = company.CompanyId;

                        cmd.Parameters.Add("@ModuleId", System.Data.SqlDbType.Int);
                        foreach (var item in company.LstModules)
                        {
                            cmd.Parameters["@ModuleId"].Value = item;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    return b;
                }
            }
        }


        public List<Company> GetAllCompanies()//
        {

            var company = new List<Company>();
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(GetCompaniesSp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                company.Add(new Company(myReader));
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return company;
        }

        public List<Company> GetCompanies(string companyName)//
        {
            var company = new List<Company>();
            AdminRepository admrep = new AdminRepository();
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(GetCompaniesSp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                    cmd.Parameters["@Name"].Value = companyName;
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                company.Add(new Company(myReader));
                                List<Module> modules = admrep.GetModulesByCompany(Convert.ToInt32(myReader["CompanyId"]));
                                company[company.Count - 1].LstModules = new List<int>();
                                foreach (var item in modules)
                                {
                                    company[company.Count - 1].LstModules.Add(item.ModuleId);
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
            return company;
        }

        public Company GetCompnay(int companyId)//
        {
            Company company = null;
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(GetCompanyByIdSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CompanyId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CompanyId"].Value = companyId;


                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (myReader.HasRows)
                            {
                                myReader.Read();
                                company = new Company(myReader);
                                AdminRepository admrep = new AdminRepository();
                                List<Module> modules = admrep.GetModulesByCompany(Convert.ToInt32(myReader["CompanyId"]));
                                company.LstModules = new List<int>();
                                foreach (var item in modules)
                                {
                                    company.LstModules.Add(item.ModuleId);
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
            return company;
        }

        public bool RemoveCompany(int compnayId, int updatedBy)//
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(UpdateInsuranceSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CompnayId", SqlDbType.Int).Value = compnayId;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = false;
                    cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                    cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = DateTime.UtcNow;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool AddInsurance(Insurance insurance)//
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(AddInsuranceSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CompanyId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CompanyId"].Value = insurance.CompanyId;
                    cmd.Parameters.Add("@InsuranceName", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@InsuranceName"].Value = insurance.InsuranceName;
                    cmd.Parameters.Add("@InsuranceAddress", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@InsuranceAddress"].Value = insurance.InsuranceAddress;
                    cmd.Parameters.Add("@InsurancePhone", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@InsurancePhone"].Value = insurance.InsurancePhone;
                    cmd.Parameters.Add("@InsuranceWebsite", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@InsuranceWebsite"].Value = insurance.InsuranceWebsite;

                    //cmd.Parameters.Add("@CreatedBy", System.Data.SqlDbType.Int);
                    //cmd.Parameters["@CreatedBy"].Value = insurance.CreatedBy;

                    //cmd.Parameters.Add("@CreatedDate", System.Data.SqlDbType.Int);
                    //cmd.Parameters["@CreatedDate"].Value = DateTime.UtcNow;

                    return Convert.ToBoolean(cmd.ExecuteScalar());
                }
            }
        }

        public bool UpdateInsurance(Insurance insurance)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(UpdateInsuranceSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@InsuranceId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@InsuranceId"].Value = insurance.InsuranceId;
                    cmd.Parameters.Add("@CompanyId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CompanyId"].Value = insurance.CompanyId;
                    cmd.Parameters.Add("@InsuranceName", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@InsuranceName"].Value = insurance.InsuranceName;
                    cmd.Parameters.Add("@InsuranceAddress", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@InsuranceAddress"].Value = insurance.InsuranceAddress;
                    cmd.Parameters.Add("@InsurancePhone", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@InsurancePhone"].Value = insurance.InsurancePhone;
                    cmd.Parameters.Add("@InsuranceWebSite", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@InsuranceWebSite"].Value = insurance.InsuranceWebsite;



                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Insurance> GetInsurances(int companyId, string insuranceName)
        {
            var insurance = new List<Insurance>();
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(GetInsurancesSp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int);
                    cmd.Parameters["@CompanyId"].Value = companyId;
                    cmd.Parameters.Add("@InsuranceName", SqlDbType.VarChar);
                    cmd.Parameters["@InsuranceName"].Value = insuranceName;
                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                insurance.Add(new Insurance(myReader));
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return insurance;
        }

        public Insurance GetInsurance(int insuranceId)//
        {
            Insurance insurance = null;
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(GetInsuranceByIdSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@InsuranceId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@InsuranceId"].Value = insuranceId;


                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (myReader.HasRows)
                            {
                                myReader.Read();
                                insurance = new Insurance(myReader);
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }

            }
            return insurance;

        }

        public bool RemoveInsurance(int insuranceId, int updatedBy)//
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(UpdateInsuranceSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CompnayId", SqlDbType.Int).Value = insuranceId;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = false;
                    cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                    cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = DateTime.UtcNow;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public void SendMail(EmailMessage msg)
        {
            try
            {
                Task task = new Task(() =>
                {
                    MailMessage message = new MailMessage();
                    message.To.Clear();
                    message.To.Add(msg.ToEmail);
                    message.From = new MailAddress("info@heartbeat-biz.com");
                    message.Body = msg.Message;
                    message.Subject = msg.Subject;
                    message.IsBodyHtml = true;
                    System.Net.Mail.SmtpClient smpt = new System.Net.Mail.SmtpClient();
                    //smpt.Host = "smtp.mail.yahoo.com";
                    smpt.Host = "mail.heartbeat-biz.com";
                    //smpt.EnableSsl = true;
                    //smpt.Port = 587;
                    smpt.Port = Convert.ToInt32(587);
                    smpt.Credentials = new System.Net.NetworkCredential("arif@heartbeatservice.com", "abcd@1234");
                    // smpt.Credentials = new System.Net.NetworkCredential("dinesh.vmscheck", "dineshvms");
                    smpt.Send(message);
                });
                task.Start();
            }
            catch (Exception ex) { }
        }

        public Alert GetAlerts(int companyId, int userId)
        {
            Alert alert = new Alert();

            using (var connection = new SqlConnection(PrescienceRxConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT COUNT(*) FROM dbo.Workflow WHERE CompanyId = @CompanyId AND WorkerID = @UserId AND StatusID <> 3";
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@CompanyId", companyId);
                    var reader = command.ExecuteScalar();
                    if (reader != null)
                    {
                        alert.AssignedItems = Convert.ToInt32(reader);
                    }
                    command.CommandText = @"SELECT COUNT(*) FROM [dbo].[Customers] c INNER JOIN [dbo].Appointments a ON c.CustomerId = a.CustomerId " +
                                        " INNER JOIN [dbo].[Professional] p on a.ProfessionalId = p.ProfessionalId " +
                                        " WHERE @CompanyID = p.CompanyId AND StartTime > GetDate() ";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@CompanyId", companyId);
                    reader = command.ExecuteScalar();
                    if (reader != null)
                    {
                        alert.NoOfAppointments = Convert.ToInt32(reader);
                    }
                    command.CommandText = @"SELECT COUNT(*) FROM dbo.Workflow WHERE CompanyId = @CompanyId AND WorkerID = @UserId AND StatusID <> 3 AND DueDate < GetDate()";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@CompanyId", companyId);
                    reader = command.ExecuteScalar();
                    if (reader != null)
                    {
                        alert.DueDateItems = Convert.ToInt32(reader);
                    }
                }

                connection.Dispose();
            }

            return alert;
        }

        public List<DashboardAppointment> GetAppointments(int companyId)
        {
            List<DashboardAppointment> appointment = new List<DashboardAppointment>();
            using (var connection = new SqlConnection(PrescienceRxConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(GetAppointmentsSp, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@CompanyId", SqlDbType.Int);
                    command.Parameters["@CompanyId"].Value = companyId;
                    using (var myReader = command.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                appointment.Add(new DashboardAppointment(myReader));
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return appointment;
        }
    }
}
