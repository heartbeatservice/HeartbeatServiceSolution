

CREATE PROCEDURE [dbo].[GetAppointments] 
@CompanyId int
AS

  DECLARE @dt datetime 
  DECLARE @Edt datetime 
  SET @dt = CONVERT(date, GetDate())
  SET @Edt = DateAdd(d,1,@dt)
  SELECT p.FirstName + ' ' + p.LastName as DoctorName,Count(a.AppointmentId) AS TotalAppointment
  FROM [dbo].[Appointments] a INNER JOIN [dbo].[Professional] p ON a.ProfessionalId = p.ProfessionalId
  WHERE (StartTime > @dt AND StartTime < @Edt) AND p.CompanyId = @CompanyId
  GROUP BY p.FirstName + ' ' + p.LastName