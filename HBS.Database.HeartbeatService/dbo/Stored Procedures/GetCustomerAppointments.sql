
CREATE ProCedure [dbo].[GetCustomerAppointments]
@CompanyID int,
@CustomerID int=NULL,
@ProfessionalID int,
@StartDate Date=NULL,
@EndDate Date=NULL

AS

SELECT 
      c.[FirstName] + ' ' + c.[LastName] CustomerName
      ,[DateOfBirth]
      ,[Address1]
	  ,[Address2]
      ,[HomePhone]      
	  ,c.Email
	  ,c.[State]
	  ,c.City
	  ,c.Zip
	  , a.StartTime AppointmentStartTime
  FROM [dbo].[Customers] c INNER JOIN [dbo].Appointments a ON c.CustomerId = a.CustomerId
INNER JOIN [dbo].[Professional] p on a.ProfessionalId = p.ProfessionalId
WHERE @CompanyID = p.CompanyId AND (@CustomerID IS NULL OR c.CustomerId = @CustomerID) AND
(@ProfessionalID IS NULL OR p.ProfessionalId = @ProfessionalID) AND
(@StartDate IS NULL OR a.StartTime > @StartDate) AND
(@EndDate IS NULL OR a.StartTime < @EndDate) 