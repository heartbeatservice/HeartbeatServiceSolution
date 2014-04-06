CREATE PROCEDURE dbo.GetProfessionalScheduleById
@ProfessionalScheduleId int
AS

SELECT * FROM ProfessionalSchedule Where ProfessionalScheduleId=@ProfessionalScheduleId