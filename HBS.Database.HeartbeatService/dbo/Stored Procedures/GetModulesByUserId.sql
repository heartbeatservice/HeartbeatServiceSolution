CREATE PROCEDURE dbo.GetModulesByUserId
@UserId int
AS 
SELECT m.ModuleId,m.ModuleName,m.ModuleDescription,m.ModuleURL,m.[ParentId],m.[IsForAll],m.[IconName]		
FROM Modules m where m.IsForAll = 1
UNION 
SELECT m.ModuleId,m.ModuleName,m.ModuleDescription,m.ModuleURL,m.[ParentId],m.[IsForAll],m.[IconName]		
FROM Modules m
INNER JOIN CompanyModules c
ON m.ModuleId=c.ModuleId
INNER JOIN UserModules u
ON m.ModuleId=u.ModuleId
WHERE u.UserId=@UserId