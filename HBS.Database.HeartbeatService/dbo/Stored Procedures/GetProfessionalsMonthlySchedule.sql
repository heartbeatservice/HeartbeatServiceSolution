
CREATE PROCEDURE [dbo].[GetProfessionalsMonthlySchedule]
  @ProfessionalId int,
  @Month int=NULL,
  @Year int=NULL
 AS

 If @Month is null
 set @Month=MONTH(getDate())

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
 Where ProfessionalId=@ProfessionalId and MONTH(StartTime)=@Month and YEAR(StartTime)=@Year