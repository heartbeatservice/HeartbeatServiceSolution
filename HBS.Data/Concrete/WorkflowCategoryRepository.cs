using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HBS.Data.Abstract;
using HBS.Entities;
using System.Data.SqlClient;
using System.Data;

namespace HBS.Data.Concrete
{
    public class WorkflowCategoryRepository : BaseRepository, IWorkflowCategoryRepository
    {
        public WorkflowCategoryRepository()
        {

        }

        public IQueryable<WorkflowCategory> GetWorkflowCategory(int companyId)
        {
            IList<WorkflowCategory> categoryList = new List<WorkflowCategory>();

            using (var connection = new SqlConnection(PrescienceRxConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT WorkflowCategoryID, CategoryName, CompanyId FROM dbo.WorkflowCategory";
                    command.CommandText += " WHERE CompanyId=" + companyId; 

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categoryList.Add(new WorkflowCategory(reader));
                        }
                    }
                }

                connection.Dispose();
            }

            return categoryList.AsQueryable();
        }

        public int AddWorkflowCategory(WorkflowCategory toInsert)
        {
            int rowAffected = 0;

            using (var connection = new SqlConnection(PrescienceRxConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO dbo.WorkflowCategory VALUES (@CategoryName, @CompanyId); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                    command.Parameters.AddWithValue("@CategoryName", toInsert.CategoryName);
                    command.Parameters.AddWithValue("@CompanyId", toInsert.CompanyId);
                    rowAffected = (int)command.ExecuteScalar();
                }

                connection.Dispose();
            }

            return rowAffected;
        }

        public bool EditWorkflowCategory(WorkflowCategory toUpdate)
        {
            int rowAffected = 0;

            using (var connection = new SqlConnection(PrescienceRxConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE dbo.WorkflowCategory SET CategoryName = @CategoryName WHERE WorkflowCategoryID = @WorkflowCategoryID";
                    command.Parameters.AddWithValue("@WorkflowCategoryID", toUpdate.WorkflowCategoryID);
                    command.Parameters.AddWithValue("@CategoryName", toUpdate.CategoryName);
                    rowAffected = command.ExecuteNonQuery();
                }

                connection.Dispose();
            }

            return rowAffected == 1 ? true : false;
        }

        public bool DeleteWorkflowCategory(int id)
        {
            int rowAffected = 0;

            using (var connection = new SqlConnection(PrescienceRxConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM dbo.WorkflowCategory WHERE WorkflowCategoryID = @WorkflowCategoryID";
                    command.Parameters.AddWithValue("@WorkflowCategoryID", id);
                    rowAffected = command.ExecuteNonQuery();
                }

                connection.Dispose();
            }

            return rowAffected == 1 ? true : false;
        }
    }
}
