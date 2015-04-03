CREATE PROCEDURE dbo.GetModules
AS 

SELECT ModuleId,ModuleName,ModuleDescription,ModuleURL
FROM Modules
ORDER BY DisplayOrder