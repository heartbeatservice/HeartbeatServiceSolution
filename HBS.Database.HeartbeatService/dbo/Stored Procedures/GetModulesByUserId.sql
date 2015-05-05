CREATE PROCEDURE dbo.GetModulesByUserId
@UserId int
AS 
WITH ModuleLst (ModuleId,ModuleName,ModuleDescription,ModuleURL,ParentId,IsForAll,IconName)
AS
(
SELECT distinct m.ModuleId,m.ModuleName,m.ModuleDescription,m.ModuleURL,m.[ParentId],m.[IsForAll],m.[IconName]		
FROM Modules m
INNER JOIN CompanyModules c
ON m.ModuleId=c.ModuleId
INNER JOIN UserModules u
ON m.ModuleId=u.ModuleId
WHERE u.UserId=@UserId
)
SELECT distinct m.ModuleId,m.ModuleName,m.ModuleDescription,m.ModuleURL,m.[ParentId],m.[IsForAll],m.[IconName]		
FROM Modules m
INNER JOIN CompanyModules c
ON m.ModuleId=c.ModuleId
INNER JOIN UserModules u
ON m.ModuleId=u.ModuleId
WHERE u.UserId=@UserId
union 	
select distinct m.ModuleId,m.ModuleName,m.ModuleDescription,m.ModuleURL,m.[ParentId],m.[IsForAll],m.[IconName]		 
from modules m where moduleid in (select parentid from ModuleLst)
UNION
SELECT m.ModuleId,m.ModuleName,m.ModuleDescription,m.ModuleURL,m.[ParentId],m.[IsForAll],m.[IconName]		
FROM Modules m where m.IsForAll = 1
