CREATE PROCEDURE dbo.GetModuleById
@ModuleId int
AS 

SELECT ModuleId,ModuleName,ModuleDescription,ModuleURL,DisplayOrder,[ParentId],[IsForAll],[IconName]		
FROM Modules
WHERE ModuleId=@ModuleId