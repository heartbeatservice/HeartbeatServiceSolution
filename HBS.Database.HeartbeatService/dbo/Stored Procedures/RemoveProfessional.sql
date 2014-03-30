
Create PROCEDURE [dbo].[RemoveProfessional]
--

@ProfessionalID int




AS

DELETE FROM Professional Where ProfessionalID=@ProfessionalID