﻿CREATE PROCEDURE dbo.GetModulesByCompanyId
@CompanyId int
AS 
SELECT m.ModuleId,m.ModuleName,m.ModuleDescription,m.ModuleURL,m.[ParentId],m.[IsForAll],m.[IconName]		
FROM Modules m where m.IsForAll = 1
UNION 
SELECT m.ModuleId,m.ModuleName,m.ModuleDescription,m.ModuleURL,m.[ParentId],m.[IsForAll],m.[IconName]		
FROM Modules m
LEFT JOIN CompanyModules c
ON m.ModuleId=c.ModuleId
WHERE c.CompanyId=@CompanyId