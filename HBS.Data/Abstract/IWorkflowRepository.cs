using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HBS.Entities;

namespace HBS.Data.Abstract
{
    public interface IWorkflowRepository
    {
        IQueryable<Workflow> GetAllWorkflow(int companyId);
        bool AddWorkflow(Workflow toInsert);
        bool EditWorkflow(Workflow toUpdate);
        bool DeleteWorkflow(int id);

        List<Workflow> GetWorkflowDetail(int companyId, int ownerId, int workerId, int statusId, int categoryId, DateTime dueDate);

        List<Workflow> GetWorkflowDetail(int companyId, int workerId);
        List<Workflow> GetWorkflowDetail(int companyId, int workerId, bool byDueDate);

        Workflow GetWorkflowDetail(int campanyId);
        Workflow GetWorkflowDetailById(int workflowDetailId);
    }
}
