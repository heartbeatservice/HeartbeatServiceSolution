using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HBS.Data.Abstract;
using HBS.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Serialization;

namespace HBS.Data.Concrete
{
    public class WorkflowRepository : BaseRepository, IWorkflowRepository
    {
        private const string GetWorkflowDetailSp = "GetWorkflowDetail";
        private object WorkflowID;
        public WorkflowRepository()
        {
        }

        public IQueryable<Workflow> GetAllWorkflow(int companyId)
        {
            IList<Workflow> workflowList = new List<Workflow>();

            using (var connection = new SqlConnection(PrescienceRxConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT WorkflowID, CategoryID, OwnerID, WorkerID, CompanyId, WorkflowTitle, WorkflowNote, DueDate, StatusID, DateCreated, DateUpdated FROM dbo.Workflow";
                    command.CommandText += " WHERE CompanyId=" + companyId;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            workflowList.Add(new Workflow(reader));
                        }
                    }
                }

                connection.Dispose();
            }

            return workflowList.AsQueryable();
        }

        public Workflow GetWorkflowDetailById(int workflowDetailId)
        {
            Workflow workflowdetail = new Workflow();

            using (var connection = new SqlConnection(PrescienceRxConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"select w.WorkflowID, U.UserName OwnerName,P.UserName WorkerName ,WorkflowTitle,DueDate,StatusName,w.CategoryID, CategoryName, WorkflowNote " +
                                                " FROM Workflow w INNER join WorkflowStatus s On w.StatusID=s.WorkflowStatusID  " +
                                                " INNER JOIN UserProfile u On w.OwnerID=u.UserID  " +
                                                " INNER JOIN UserProfile p On w.WorkerID=p.UserID " +
                                                " INNER JOIN WorkflowCategory c ON w.CategoryID = c.WorkflowCategoryID";
                    command.CommandText += " WHERE WorkflowID=" + workflowDetailId;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            workflowdetail = new Workflow(reader);
                        }
                    }
                }

                connection.Dispose();
            }

            return workflowdetail;
        }
        public bool AddWorkflow(Workflow toInsert)
        {
            int rowAffected = 0;
            bool notification = false;
            bool history = false;

            if (toInsert.CategoryID == 0) toInsert.CategoryID = 1;
            if (toInsert.OwnerID == 0) toInsert.OwnerID = 1;
            if (toInsert.WorkerID == 0) toInsert.WorkerID = 1;
            if (toInsert.StatusID == 0) toInsert.StatusID = 1;

            using (var connection = new SqlConnection(PrescienceRxConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO dbo.Workflow VALUES(@CategoryID, @OwnerID, @WorkerID, @WorkflowTitle, @WorkflowNote, @DueDate, @StatusID, @DateCreated, @DateUpdated, @CompanyId); SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    command.Parameters.AddWithValue("@CategoryID", toInsert.CategoryID);
                    command.Parameters.AddWithValue("@OwnerID", toInsert.OwnerID);
                    command.Parameters.AddWithValue("@WorkerID", toInsert.WorkerID);
                    command.Parameters.AddWithValue("@WorkflowTitle", toInsert.WorkflowTitle);
                    command.Parameters.AddWithValue("@WorkflowNote", toInsert.WorkflowNote);
                    command.Parameters.AddWithValue("@DueDate", toInsert.DueDate);
                    command.Parameters.AddWithValue("@StatusID", toInsert.StatusID);
                    command.Parameters.AddWithValue("@DateCreated", toInsert.DateCreated);
                    command.Parameters.AddWithValue("@DateUpdated", toInsert.DateUpdated);
                    command.Parameters.AddWithValue("@CompanyId", toInsert.CompanyId);
                    rowAffected = (int)command.ExecuteScalar();
                }

                connection.Dispose();
            }

            // add workflow history and notification for the newly added workflow
            if (rowAffected >= 1)
            {
                // set the workflow ID for the workflow object in memeory to the newly created ID
                toInsert.WorkflowID = rowAffected;

                // add workflow notification and history
                notification = AddWorkflowNotification(null, toInsert);
                history = AddWorkflowHistory(toInsert);

                return true;
            }

            return false;
        }

        public bool EditWorkflow(Workflow toUpdate)
        {
            int rowAffected = 0;
            bool notification = false;
            bool history = false;

            if (toUpdate.CategoryID == 0) toUpdate.CategoryID = 1;
            if (toUpdate.OwnerID == 0) toUpdate.OwnerID = 1;
            if (toUpdate.WorkerID == 0) toUpdate.WorkerID = 1;
            if (toUpdate.StatusID == 0) toUpdate.StatusID = 1;

            // get workflow object before update
            Workflow beforeUpdate = GetWorkflowByID(toUpdate.WorkflowID);

            using (var connection = new SqlConnection(PrescienceRxConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE dbo.Workflow SET CategoryID = @CategoryID, OwnerID = @OwnerID, WorkerID = @WorkerID, WorkflowTitle = @WorkflowTitle, WorkflowNote = @WorkflowNote, DueDate = @DueDate, StatusID = @StatusID, DateCreated = @DateCreated, DateUpdated = @DateUpdated WHERE WorkflowID = @WorkflowID";

                    command.Parameters.AddWithValue("@WorkflowID", toUpdate.WorkflowID);
                    command.Parameters.AddWithValue("@CategoryID", toUpdate.CategoryID);
                    command.Parameters.AddWithValue("@OwnerID", toUpdate.OwnerID);
                    command.Parameters.AddWithValue("@WorkerID", toUpdate.WorkerID);
                    command.Parameters.AddWithValue("@WorkflowTitle", toUpdate.WorkflowTitle);
                    command.Parameters.AddWithValue("@WorkflowNote", toUpdate.WorkflowNote);
                    command.Parameters.AddWithValue("@DueDate", toUpdate.DueDate);
                    command.Parameters.AddWithValue("@StatusID", toUpdate.StatusID);
                    command.Parameters.AddWithValue("@DateCreated", toUpdate.DateCreated);
                    command.Parameters.AddWithValue("@DateUpdated", toUpdate.DateUpdated);

                    rowAffected = command.ExecuteNonQuery();
                }

                connection.Dispose();
            }

            // add workflow history and notification for the newly added workflow
            if (rowAffected >= 1)
            {
                // add workflow notification and history
                notification = AddWorkflowNotification(beforeUpdate, toUpdate);
                history = AddWorkflowHistory(toUpdate);

                return true;
            }

            return false;
        }

        public bool DeleteWorkflow(int id)
        {
            int rowAffected = 0;

            using (var connection = new SqlConnection(PrescienceRxConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM dbo.Workflow WHERE WorkflowID = @WorkflowID";
                    command.Parameters.AddWithValue("@WorkflowID", id);

                    rowAffected = command.ExecuteNonQuery();
                }

                connection.Dispose();
            }

            return rowAffected == 1 ? true : false;
        }

        private bool AddWorkflowHistory(Workflow toInsert)
        {
            int rowAffected = 0;

            using (var connection = new SqlConnection(PrescienceRxConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO dbo.WorkflowHistory VALUES(@WorkflowID, @Payload, @DateCreated)";

                    command.Parameters.AddWithValue("@WorkflowID", toInsert.WorkflowID);
                    command.Parameters.AddWithValue("@Payload", ConvertObjectToJSON<Workflow>(toInsert));
                    command.Parameters.AddWithValue("@DateCreated", DateTime.Now);

                    rowAffected = command.ExecuteNonQuery();
                }

                connection.Dispose();
            }

            return rowAffected == 1 ? true : false;
        }

        private bool AddWorkflowNotification(Workflow before, Workflow after)
        {
            int rowAffected = 0;
            string payloadMessage = "";
            string notificationType = "";

            // new workflow
            if (before == null)
            {
                payloadMessage = "{'Message':'There is a new task assigned to you!','WorkflowName':'" + after.WorkflowTitle + "'," + "'DueDate':'" + after.DueDate + "'}";
                notificationType = "NewWorkflow";
            }

            // existing workflow
            if (before != null)
            {
                if (before.WorkerID != after.WorkerID && before.DueDate != after.DueDate)
                {
                    payloadMessage = "{'Message': 'There is an existing task reassigned to you!','WorkflowName':'" + after.WorkflowTitle + "'," + "'DueDate':'" + after.DueDate + "'}";
                    notificationType = "UpdateWorkerAndDueDate";
                }

                if (before.WorkerID == after.WorkerID && before.DueDate != after.DueDate)
                {
                    payloadMessage = "{'Message': 'The due date for an existing task is changed!','WorkflowName':'" + after.WorkflowTitle + "'," + "'DueDate':'" + after.DueDate + "'}";
                    notificationType = "UpdateDueDate";
                }

                if (before.WorkerID != after.WorkerID && before.DueDate == after.DueDate)
                {
                    payloadMessage = "{'Message': 'There is an existing task reassigned to you!','WorkflowName':'" + after.WorkflowTitle + "'," + "'DueDate':'" + after.DueDate + "'}";
                    notificationType = "UpdateWorker";
                }
            }

            using (var connection = new SqlConnection(PrescienceRxConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO dbo.WorkflowNotification VALUES(@WorkflowID, @Payload, @NotificationType, @DateCreated)";

                    command.Parameters.AddWithValue("@WorkflowID", after.WorkflowID);
                    command.Parameters.AddWithValue("@Payload", payloadMessage);
                    command.Parameters.AddWithValue("@NotificationType", notificationType);
                    command.Parameters.AddWithValue("@DateCreated", DateTime.Now);

                    rowAffected = command.ExecuteNonQuery();
                }

                connection.Dispose();
            }

            return rowAffected == 1 ? true : false;
        }

        private Workflow GetWorkflowByID(int workflowID)
        {
            IList<Workflow> workflowList = new List<Workflow>();

            using (var connection = new SqlConnection(PrescienceRxConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT WorkflowID, CategoryID, OwnerID, WorkerID, CompanyId, WorkflowTitle, WorkflowNote, DueDate, StatusID, DateCreated, DateUpdated FROM dbo.Workflow WHERE WorkflowID = @WorkflowID";
                    command.Parameters.AddWithValue("@WorkflowID", workflowID);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            workflowList.Add(new Workflow(reader));
                        }
                    }
                }

                connection.Dispose();
            }

            return workflowList.First();
        }

        public Workflow GetWorkflowDetail(int campanyId)//
        {
            Workflow workflow = null;
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {

                conn.Open();

                using (var cmd = new SqlCommand(GetWorkflowDetailSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@WorkflowId", SqlDbType.Int);
                    cmd.Parameters["@WorkflowId"].Value = WorkflowID;

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (myReader.HasRows)
                            {
                                myReader.Read();
                                workflow = new Workflow(myReader);
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }

            }
            return workflow;

        }

        public List<Workflow> GetWorkflowDetail(int companyId, int ownerId, int workerId, int statusId, int categoryId, DateTime dueDate)
        {

            var workflow = new List<Workflow>();
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(GetWorkflowDetailSp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int);
                    cmd.Parameters["@CompanyId"].Value = companyId;
                    if (dueDate.ToString() != "1/1/0001 12:00:00 AM")
                    {
                        cmd.Parameters.Add("@DueDate", SqlDbType.DateTime);
                        cmd.Parameters["@DueDate"].Value = dueDate;
                    }
                    cmd.Parameters.Add("@OwnerId", SqlDbType.Int);
                    cmd.Parameters["@OwnerId"].Value = ownerId;
                    cmd.Parameters.Add("@WorkerId", SqlDbType.Int);
                    cmd.Parameters["@WorkerId"].Value = workerId;
                    cmd.Parameters.Add("@StatusId", SqlDbType.Int);
                    cmd.Parameters["@StatusId"].Value = statusId;
                    cmd.Parameters.Add("@CategoryId", SqlDbType.Int);
                    cmd.Parameters["@CategoryId"].Value = categoryId;

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                workflow.Add(new Workflow(myReader));
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return workflow;



        }
        private string ConvertObjectToJSON<T>(T theObject)
        {
            var javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string jsonString = javaScriptSerializer.Serialize(theObject);
            return jsonString;
        }
    }
}
