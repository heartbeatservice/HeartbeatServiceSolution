using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HBS.Data.Abstract;
using HBS.Entities;

namespace HBS.Data.Concrete
{
    public class ProfessionalRepository : BaseRepository, IProfessionalRepository
    {
<<<<<<< HEAD

        private const string AddProfessionalSp = "AddProfessional";
        private const string UpdateProfessionalSp = "UpdateProfessional";
        private const string GetProfessionalByIdSp = "GetProfessionalById";
        
   

        private const string GetProfessionalByIdSp = "GetProfessionalById";
        private const string GetProfessionalsSp = "GetProfessionals";
      
     

        public int AddProfessional(Professional professional)

=======
        private const string GetProfessionalByIdSp = "GetProfessionalById";
        private const string GetProfessionalsSp = "GetProfessionals";
        private const string AddProfessionalSp = "AddProfessional";
        private const string UpdateProfessionalSp = "UpdateProfessional";

        public int AddProfessional(Professional professional)
>>>>>>> a0b577e90d686fa330813b20a2c36b2457fcfb5d
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

<<<<<<< HEAD


         
=======
>>>>>>> a0b577e90d686fa330813b20a2c36b2457fcfb5d
                using (var cmd = new SqlCommand(AddProfessionalSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProfessionalTypeId", SqlDbType.Int).Value = professional.ProfessionalTypeId;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = professional.CompanyId;
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = professional.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = professional.LastName;
                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = professional.Phone;
                    cmd.Parameters.Add("@ProfessionalIdentificationNumber", SqlDbType.VarChar).Value = professional.ProfessionalIdentificationNumber;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = professional.CreatedBy;
                    cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = DateTime.UtcNow;
<<<<<<< HEAD
                    return (int)cmd.ExecuteScalar();                  cmd.Parameters.Add("@CreatedBy", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CreatedBy"].Value = professional.CreatedBy;

                    cmd.Parameters.Add("@CreatedDate", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CreatedDate"].Value = DateTime.UtcNow;

                   

                    return (int)cmd.ExecuteScalar();

=======
                    return (int)cmd.ExecuteScalar();
>>>>>>> a0b577e90d686fa330813b20a2c36b2457fcfb5d
                }
            }
        }
         
            
          

           

        public bool UpdateProfessional(Professional professional)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(UpdateProfessionalSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

<<<<<<< HEAD

=======
>>>>>>> a0b577e90d686fa330813b20a2c36b2457fcfb5d
                    cmd.Parameters.Add("@ProfessionalId", SqlDbType.Int).Value = professional.ProfessionalId;
                    cmd.Parameters.Add("@ProfessionalTypeId", SqlDbType.Int).Value = professional.ProfessionalTypeId;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = professional.CompanyId;
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = professional.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = professional.LastName;
                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = professional.Phone;
                    cmd.Parameters.Add("@ProfessionalIdentificationNumber", SqlDbType.VarChar).Value = professional.ProfessionalIdentificationNumber;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = professional.IsActive;
                    cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = professional.UpdatedBy;
                    cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = DateTime.UtcNow;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public Professional GetProfessional(int professionalId)
        {
            Professional professional = null;
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
<<<<<<< HEAD

                conn.Open();

=======
                conn.Open();
>>>>>>> a0b577e90d686fa330813b20a2c36b2457fcfb5d
                using (var cmd = new SqlCommand(GetProfessionalByIdSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

<<<<<<< HEAD

                    cmd.Parameters.Add("@professionalId", System.Data.SqlDbType.Int);
                    cmd.Parameters["@professionalId"].Value = professionalId;

=======
                    cmd.Parameters.Add("@ProfessionalId", SqlDbType.Int);
                    cmd.Parameters["@ProfessionalId"].Value = professionalId;
>>>>>>> a0b577e90d686fa330813b20a2c36b2457fcfb5d

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (myReader.HasRows)
                            {
                                myReader.Read();
                                professional = new Professional(myReader);
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
<<<<<<< HEAD


                return professional;
            }
=======
            }
            return professional;
>>>>>>> a0b577e90d686fa330813b20a2c36b2457fcfb5d
        }

        public List<Professional> GetProfessionals(int companyId, string professionalName)
        {
<<<<<<< HEAD

            var professionals = new List<Professional>();
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(GetProfessionalsSp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int);
                    cmd.Parameters["@CompanyId"].Value = companyId;

                    if (!string.IsNullOrWhiteSpace(professionalName))
                    {
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                        cmd.Parameters["@Name"].Value = professionalName;
                    }

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                professionals.Add(new Professional(myReader));
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return professionals;
       }

=======
            var professionals = new List<Professional>();
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(GetProfessionalsSp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int);
                    cmd.Parameters["@CompanyId"].Value = companyId;

                    if (!string.IsNullOrWhiteSpace(professionalName))
                    {
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                        cmd.Parameters["@Name"].Value = professionalName;
                    }

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                professionals.Add(new Professional(myReader));
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return professionals;
        }

>>>>>>> a0b577e90d686fa330813b20a2c36b2457fcfb5d

        public bool RemoveProfessional(int professionalId,int removedBy)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(UpdateProfessionalSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProfessionalId", SqlDbType.Int).Value = professionalId;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = false;
                    cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = removedBy;
                    cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = DateTime.UtcNow;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool AddProfessionalSchedule(ProfessionalSchedule professionalSchedule)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProfessionalSchedule(ProfessionalSchedule professionalSchedule)
        {
            throw new NotImplementedException();
        }

        public ProfessionalSchedule GetProfessionalSchedule(int professionalSchedulreId)
        {
            throw new NotImplementedException();
        }

        public List<ProfessionalSchedule> GetProfessionalScheduleList(int professionalId)
        {
            throw new NotImplementedException();
        }

        public List<ProfessionalSchedule> GetProfessionalSchedule(DateTime scheduleDate)
        {
            throw new NotImplementedException();
        }

        public bool RemoveProfessionalSchedule(int professionalSchduleId)
        {
            throw new NotImplementedException();
        }
    }
}



