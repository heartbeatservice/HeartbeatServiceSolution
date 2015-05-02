CREATE PROCEDURE [dbo].[GetProfessionalsSchedule]
  @CompanyId int,  
  @ProfessionalId int,  
  @Year int=NULL,
  @CustomerId int = 0
AS
	
 If @Year is null
   set @Year=YEAR(getdate())

 SELECT CustomerId As OwnerID,
        0 AS IsAllDay,
		a.Title,
		Comments as [Description],
		StartTime as Start,
		EndTime as [End],
		AppointmentId as TaskId
 FROM Appointments a INNER JOIN Professional p on a.ProfessionalId = p.ProfessionalId
 Where a.ProfessionalId=@ProfessionalId and YEAR(StartTime)=@Year
		AND (@CustomerId = 0 OR CustomerId = @CustomerId)
		AND (@CompanyId = 0 OR p.CompanyId = @CompanyId)