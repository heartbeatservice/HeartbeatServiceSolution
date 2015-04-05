CREATE PROCEDURE [dbo].[RemoveCompanyModule]
@CompanyId int,
@ModuleId int
AS
IF EXISTS(SELECT 'x' from CompanyModules WHERE CompanyId=@CompanyId AND ModuleId=@ModuleId)
BEGIN
DELETE FROM CompanyModules WHERE CompanyId=@CompanyId AND ModuleId=@ModuleId
END