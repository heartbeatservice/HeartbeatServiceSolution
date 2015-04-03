CREATE PROCEDURE [dbo].[AssignCompanyModule]
@CompanyId int,
@ModuleId int
AS
IF NOT EXISTS(SELECT 'x' from CompanyModules WHERE CompanyId=@CompanyId AND ModuleId=@ModuleId)
BEGIN
INSERT INTO CompanyModules(CompanyId,ModuleId) VALUES(@CompanyId,@ModuleId)
END

SELECT @@Identity