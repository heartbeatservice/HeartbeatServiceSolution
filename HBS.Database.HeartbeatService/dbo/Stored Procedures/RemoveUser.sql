
create PROCEDURE [dbo].[RemoveUser]
--

@UserId int




AS

DELETE FROM UserProfile Where UserId=@UserID