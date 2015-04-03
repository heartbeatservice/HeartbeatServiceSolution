CREATE PROCEDURE dbo.GetModuleById
@ModuleId int
AS 

SELECT ModuleId,ModuleName,ModuleDescription,ModuleURL
FROM Modules
WHERE ModuleId=@ModuleId