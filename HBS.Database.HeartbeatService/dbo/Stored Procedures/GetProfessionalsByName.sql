
CREATE PROCEDURE [dbo].[GetProfessionalsByName]
--GetProfessionalsByName  ''


@CompanyId int,
@Name nvarchar(50)



AS

SELECT 
	p.ProfessionalId,
	t.ProfessionalTypeId,
	t.ProfessionalTypeDesc,
	c.CompanyId,
	c.CompanyName,
	p.FirstName,
	p.LastName,
	p.phone,
	p.ProfessionalIdentificationNumber
FROM Professional p
INNER JOIN Company c
ON p.CompanyId=c.CompanyId
inner join ProfessionalType t
on p.ProfessionalTypeId=t.ProfessionalTypeId
WHERE (ISNULL(p.FirstName,'') like '%'+@Name+'%' OR ISNULL(p.LastName,'')  like '%'+@Name+'%' )
and c.companyid=@CompanyId