
CREATE PROCEDURE [dbo].[GetInsurances]
-- [GetInsurances]  1, 'z'


@CompanyId int,
@InsuranceName nvarchar(50)=Null



AS

IF @InsuranceName='-1'
SET @InsuranceName=NULL
SELECT 
	I.InsuranceID,
	c.CompanyId,
	c.CompanyName,
	I.InsuranceName,
	I.InsuranceAddress,
	I.InsurancePhone,
	I.InsuranceWebsite,
	I.IsActive
FROM Insurances I
INNER JOIN Company c
ON I.CompanyId=c.CompanyId
WHERE ((ISNULL(I.InsuranceName,'') like '%'+@InsuranceName+'%') or @InsuranceName is null)
and c.companyid=@CompanyId