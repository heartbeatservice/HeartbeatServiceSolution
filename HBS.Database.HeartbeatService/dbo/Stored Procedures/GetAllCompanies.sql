

CREATE PROCEDURE [dbo].[GetAllCompanies] 
--UpdateUser 1,1,'ABCTesting','','Umais','Siddiqui','umais@heartbeatservice.com'




AS

Select CompanyId,CompanyName,Description,CreatedDate,CreatedBy,UpdatedDate,Updatedby FROM
Company