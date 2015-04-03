CREATE PROCEDURE [dbo].[AssignUserModule]
@UserId int,
@ModuleId int
AS

DECLARE @companyId int

SELECT @companyId=companyId from UserProfile where UserId=@UserId

IF EXISTS(SELECT 'x' from CompanyModules WHERE CompanyId=@CompanyId AND ModuleId=@ModuleId)
BEGIN
INSERT INTO UserModules(UserId,ModuleId) VALUES(@UserId,@ModuleId)
END