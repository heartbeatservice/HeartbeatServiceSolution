
CREATE PROCEDURE [dbo].[GetProfessionalById]
--GetProfessionalsById  3

@ProfessionalId int


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
WHERE p.ProfessionalId=@ProfessionalId