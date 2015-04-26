
CREATE PROCEDURE [dbo].[GetUserByUserName]
--GetUserByUserName  'Umais'

@UserName nvarchar(50)



AS

SELECT 
    u.UserId,
	c.CompanyId,
	c.CompanyName,
	u.UserName,
	u.Password,
	u.PasswordSalt,
	u.FirstName,
	u.LastName,
	u.Email,
	u.ConfirmationToken,
	u.IsConfirmed,
	u.CreatedDate,
	u.CreatedBy,
	u.UpdatedDate,
	u.UpdatedBy,
	u.IsActive,
	u.RoleId,
	r.RoleName
FROM UserProfile u
INNER JOIN Company c
ON u.CompanyId=c.CompanyId
LEFT JOIN dbo.Roles r ON u.RoleId = r.RoleId
WHERE u.UserName=@UserName