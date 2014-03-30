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
    public class SchedulingRepository :BaseRepository, ISchedulingRepository
    {
        

        private string AddCompanySp = "AddCompany";
        private string UpdateCompanySp="UpdateCompany";
  
        public int AddCompany(Company company)
        {

            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(AddCompanySp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CompanyName", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CompanyName"].Value = company.CompanyName;

                    cmd.Parameters.Add("@Description", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@Description"].Value = company.Description;

                    cmd.Parameters.Add("@CreatedBy", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CreatedBy"].Value = company.CreatedBy;

                    cmd.Parameters.Add("@CreatedDate", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CreatedDate"].Value = DateTime.UtcNow;

                   return (int)cmd.ExecuteScalar();
                }

            }
        }

        public bool UpdateCompany(Company company)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(UpdateCompanySp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CompanyName", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CompanyName"].Value = company.CompanyName;

                    cmd.Parameters.Add("@Description", System.Data.SqlDbType.VarChar);
                    cmd.Parameters["@Description"].Value = company.Description;

                    cmd.Parameters.Add("@UpdatedBy", System.Data.SqlDbType.Int);
                    cmd.Parameters["@UpdatedBy"].Value = company.UpdatedBy;

                    cmd.Parameters.Add("@UpdatedDate", System.Data.SqlDbType.Int);
                    cmd.Parameters["@UpdatedDate"].Value = DateTime.UtcNow;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
