using System;
using System.Data;
using HBS.Entities.Utilities;

namespace HBS.Entities
{
    public class Workflow
    {

        public int WorkflowID { get; set; }
        public int CompanyId { get; set; }
        public int CategoryID { get; set; }
        public int OwnerID { get; set; }
        public int WorkerID { get; set; }
        public string WorkflowTitle { get; set; }
        public string WorkflowNote { get; set; }
        public string StatusName { get; set; }
        public string OwnerName { get; set; }
        public string WorkerName { get; set; }
        public string CategoryName { get; set; }
        public DateTime DueDate { get; set; }
        public int StatusID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public Workflow()
        {

        }

        public Workflow(int workflowID, int categoryDI, int ownerID, int workerID, string workflownote, DateTime dueDate, int statusID, DateTime dateCreated, DateTime dateUpdated)
            : this()
        {

        }

        public Workflow(IDataReader dbReader)
            : this()
        {
            if (dbReader.HasColumn("WorkflowID") && dbReader["WorkflowID"] != DBNull.Value) WorkflowID = (int)dbReader["WorkflowID"];
            if (dbReader.HasColumn("CategoryID") && dbReader["CategoryID"] != DBNull.Value) CategoryID = (int)dbReader["CategoryID"];
            if (dbReader.HasColumn("OwnerID") && dbReader["OwnerID"] != DBNull.Value) OwnerID = (int)dbReader["OwnerID"];
            if (dbReader.HasColumn("WorkerID") && dbReader["WorkerID"] != DBNull.Value) WorkerID = (int)dbReader["WorkerID"];
            if (dbReader.HasColumn("WorkflowTitle") && dbReader["WorkflowTitle"] != DBNull.Value) WorkflowTitle = (string)dbReader["WorkflowTitle"];
            if (dbReader.HasColumn("WorkflowNote") && dbReader["WorkflowNote"] != DBNull.Value) WorkflowNote = (string)dbReader["WorkflowNote"];
            if (dbReader.HasColumn("DueDate") && dbReader["DueDate"] != DBNull.Value) DueDate = (DateTime)dbReader["DueDate"];
            if (dbReader.HasColumn("StatusID") && dbReader["StatusID"] != DBNull.Value) StatusID = (int)dbReader["StatusID"];
            if (dbReader.HasColumn("DateCreated") && dbReader["DateCreated"] != DBNull.Value) DateCreated = (DateTime)dbReader["DateCreated"];
            if (dbReader.HasColumn("DateUpdated") && dbReader["DateUpdated"] != DBNull.Value) DateUpdated = (DateTime)dbReader["DateUpdated"];
            if (dbReader.HasColumn("WorkerName") && dbReader["WorkerName"] != DBNull.Value) WorkerName = (string)dbReader["WorkerName"];
            if (dbReader.HasColumn("OwnerName") && dbReader["OwnerName"] != DBNull.Value) OwnerName = (string)dbReader["OwnerName"];
            if (dbReader.HasColumn("StatusName") && dbReader["StatusName"] != DBNull.Value) StatusName = (string)dbReader["StatusName"];
            if (dbReader.HasColumn("CompanyId") && dbReader["CompanyId"] != DBNull.Value) CompanyId = Convert.ToInt32(dbReader["CompanyId"]);
            if (dbReader.HasColumn("CategoryName") && dbReader["CategoryName"] != DBNull.Value) CategoryName = Convert.ToString(dbReader["CategoryName"]); 
        }

    }
}
