CREATE PROCEDURE dbo.GetModulesByCompanyId
@CompanyId int
AS 

SELECT m.ModuleId,m.ModuleName,m.ModuleDescription,m.ModuleURL
FROM Modules m
INNER JOIN CompanyModules c
ON m.ModuleId=c.ModuleId
WHERE c.CompanyId=@CompanyId