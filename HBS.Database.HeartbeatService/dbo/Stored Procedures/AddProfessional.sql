
Create PROCEDURE [dbo].[AddProfessional]

@ProfessionalTypeId int,
@CompanyId int,
@FirstName nvarchar(100)=NULL,
@LastName nvarchar(100)=NULL,
@Phone nvarchar(50)=NULL,
@ProfessionalIdentificationNumber nvarchar(50)=NULL

AS


INSERT INTO Professional(ProfessionalTypeId, CompanyId,FirstName,LastName,Phone,ProfessionalIdentificationNumber) 
VALUES(@ProfessionalTypeId,@companyId,@FirstName,@LastName,@Phone,@ProfessionalIdentificationNumber)