
CREATE ProCedure [dbo].[GetWorkflowDetail]
@CompanyID int,
@WorkerID int,
@OwnerID int,
@StatusID int,
@CategoryID int,
@DueDate Date=NULL
AS
Begin
select w.WorkflowId, U.UserName OwnerName,P.UserName WorkerName ,WorkflowTitle,DueDate,StatusName,w.CategoryID, CategoryName
from Workflow w INNER join WorkflowStatus s On w.StatusID=s.WorkflowStatusID 
	INNER JOIN UserProfile u On w.OwnerID=u.UserID 
	INNER JOIN UserProfile p On w.WorkerID=p.UserID
	INNER JOIN WorkflowCategory c ON w.CategoryID = c.WorkflowCategoryID
WHERE w.CompanyId = @CompanyId AND 
	(@WorkerID = 0 OR w.WorkerID = @WorkerID) AND
	(@WorkerID = 0 OR w.WorkerID = @WorkerID) AND
	(@OwnerID = 0 OR w.OwnerID = @OwnerID) AND
	(@StatusID = 0 OR w.StatusID = @StatusID) AND
	(@CategoryID = 0 OR w.CategoryID = @CategoryID) AND
	(@DueDate IS NULL OR w.DueDate > @DueDate)
END