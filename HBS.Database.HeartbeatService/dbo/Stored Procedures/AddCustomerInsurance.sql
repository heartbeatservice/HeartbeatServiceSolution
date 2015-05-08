
Create PROCEDURE [dbo].[AddCustomerInsurance]

@InsuranceID int,
@CustomerId int,
@EffectiveDate date,
@EndDate date=NULL,
@PCPName nvarchar(100)=NULL,
@CustomerInsuranceNumber nvarchar(50)=NULL,
@InsuranceType nvarchar(50)=NULL,
@IsActive bit

AS


INSERT INTO CustomerInsurance(InsuranceID,CustomerId,EffectiveDate,EndDate,PCPName,CustomerInsuranceNumber,InsuranceType,IsActive) 
VALUES(@InsuranceID,@CustomerId,@EffectiveDate,@EndDate,@PCPName,@CustomerInsuranceNumber,@InsuranceType,@IsActive)