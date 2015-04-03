CREATE PROCEDURE [dbo].[RemoveUserModule]
@UserId int,
@ModuleId int
AS


DELETE FROM UserModules WHERE UserId=@UserId and ModuleId=@ModuleId