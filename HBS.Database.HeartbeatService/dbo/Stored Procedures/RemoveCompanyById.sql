

CREATE PROCEDURE [dbo].[RemoveCompanyById] 
--UpdateUser 1,1,'ABCTesting','','Umais','Siddiqui','umais@heartbeatservice.com'

@CompanyId int



AS

DELETE FROM Company Where CompanyId=@CompanyId