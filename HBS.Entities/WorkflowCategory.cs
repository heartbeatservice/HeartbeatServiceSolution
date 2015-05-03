using System;
using System.Data;
using HBS.Entities.Utilities;

namespace HBS.Entities
{
    public class WorkflowCategory
    {
        public int WorkflowCategoryID { get; set; }
        public int CompanyId { get; set; }
        public string CategoryName { get; set; }

        public WorkflowCategory()
        {

        }

        public WorkflowCategory(int workflowCategoryID, string categoryName, int companyId)
            : this()
        {
            WorkflowCategoryID = workflowCategoryID;
            CategoryName = categoryName;
            CompanyId = companyId;
        }

        public WorkflowCategory(IDataReader dbReader)
            : this()
        {
            if (dbReader["WorkflowCategoryID"] != DBNull.Value) WorkflowCategoryID = (int)dbReader["WorkflowCategoryID"];
            if (dbReader["CategoryName"] != DBNull.Value) CategoryName = (string)dbReader["CategoryName"];
            if (dbReader["CompanyId"] != DBNull.Value) CompanyId = (int)dbReader["CompanyId"];
        }
    }
}
