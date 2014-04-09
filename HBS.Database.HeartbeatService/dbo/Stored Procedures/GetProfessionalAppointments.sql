

CREATE ProCedure [dbo].[GetProfessionalAppointments]
@ProfessionalID int,
@StartDate Date=NULL,
@EndDate Date=NULL

AS

If @StartDate is null
Begin
SET @EndDate =NULL

SELECT * FROM Appointments where ProfessionalId=@ProfessionalID
END
ELSE
Begin
IF @EndDate is null
SET @EndDate=DATEADD(DD,1,@StartDate)


SELECT * FROM Appointments Where ProfessionalId=@ProfessionalID AND AppointmentDate between @StartDate And @EndDate
END