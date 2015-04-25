CREATE PROCEDURE [dbo].[GetUserBySearchText]
--GetUsersByCompanyId  1


@companyId int,
@searchText VARCHAR(50) = null


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
	u.RoleId
FROM UserProfile u
INNER JOIN Company c
ON u.CompanyId=c.CompanyId
WHERE (c.companyid=@companyid or @CompanyId = -1) and
(u.UserName like '%' + @searchText + '%' OR @searchText is null)