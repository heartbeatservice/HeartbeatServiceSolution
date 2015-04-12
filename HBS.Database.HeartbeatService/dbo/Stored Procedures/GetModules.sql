CREATE PROCEDURE dbo.GetModules
AS 

SELECT ModuleId,ModuleName,ModuleDescription,ModuleURL,DisplayOrder,[ParentId],[IsForAll],[IconName]		
FROM Modules
ORDER BY DisplayOrder