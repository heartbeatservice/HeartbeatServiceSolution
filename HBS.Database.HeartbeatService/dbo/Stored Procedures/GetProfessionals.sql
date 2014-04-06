
CREATE PROCEDURE [dbo].[GetProfessionals]
-- [GetProfessionals]  1, 'z'


@CompanyId int,
@Name nvarchar(50)=Null



AS

SELECT 
	p.ProfessionalId,
	t.ProfessionalTypeId,
	t.ProfessionalTypeDesc,
	c.CompanyId,
	c.CompanyName,
	p.Title,
	p.FirstName,
	p.MiddleInitial,
	p.LastName,
	p.phone,
	p.ProfessionalIdentificationNumber,
	p.Email,
	p.IsActive
FROM Professional p
INNER JOIN Company c
ON p.CompanyId=c.CompanyId
inner join ProfessionalType t
on p.ProfessionalTypeId=t.ProfessionalTypeId
WHERE ((ISNULL(p.FirstName,'') like '%'+@Name+'%' OR ISNULL(p.LastName,'')  like '%'+@Name+'%' ) or @Name is null)
and c.companyid=@CompanyId