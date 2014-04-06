
CREATE PROCEDURE [dbo].[GetProfessionalById]
--[GetProfessionalById]  3

@ProfessionalId int


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
WHERE p.ProfessionalId=@ProfessionalId