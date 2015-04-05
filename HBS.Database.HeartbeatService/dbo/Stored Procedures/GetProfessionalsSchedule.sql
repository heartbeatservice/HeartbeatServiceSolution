CREATE PROCEDURE [dbo].[GetProfessionalsSchedule]
  @ProfessionalId int,  
  @Year int=NULL,
  @CustomerId int = 0
AS
	
 If @Year is null
   set @Year=YEAR(getdate())

 SELECT CustomerId As OwnerID,
        0 AS IsAllDay,
		Title,
		Comments as [Description],
		StartTime as Start,
		EndTime as [End],
		AppointmentId as TaskId
 FROM Appointments
 Where ProfessionalId=@ProfessionalId and YEAR(StartTime)=@Year
		AND (@CustomerId = 0 OR CustomerId = @CustomerId)