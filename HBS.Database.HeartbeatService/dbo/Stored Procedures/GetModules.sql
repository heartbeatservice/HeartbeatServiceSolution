CREATE PROCEDURE dbo.GetModules
@CompanyId int,
@ModuleName varchar(100) = NULL
AS 

SELECT DISTINCT M.ModuleId,M.ModuleName,M.ModuleDescription,M.ModuleURL,M.DisplayOrder,M.[ParentId],M.[IsForAll],M.[IconName]		
FROM Modules M INNER JOIN CompanyModules c
ON m.ModuleId=c.ModuleId
WHERE  (M.ModuleName LIKE '%' + @ModuleName +'%' OR @ModuleName IS NULL) AND (c.CompanyId = @CompanyId OR @CompanyId = -1)
ORDER BY DisplayOrder