CREATE PROCEDURE [dbo].[GetModule]
@ModuleId int
AS 

SELECT ModuleId,ModuleName,ModuleDescription,ModuleURL,DisplayOrder,[ParentId],[IsForAll],[IconName]		
FROM Modules
WHERE ModuleId = @ModuleId
ORDER BY DisplayOrder