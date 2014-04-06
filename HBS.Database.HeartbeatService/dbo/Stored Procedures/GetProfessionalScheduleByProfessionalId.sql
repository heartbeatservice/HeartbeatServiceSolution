CREATE PROCEDURE dbo.GetProfessionalScheduleByProfessionalId
@ProfessionalId int
AS

SELECT * FROM ProfessionalSchedule Where ProfessionalId=@ProfessionalId