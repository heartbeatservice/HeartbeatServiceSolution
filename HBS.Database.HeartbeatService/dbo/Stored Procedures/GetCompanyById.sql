

CREATE PROCEDURE [dbo].[GetCompanyById] 
--UpdateUser 1,1,'ABCTesting','','Umais','Siddiqui','umais@heartbeatservice.com'

@CompanyId int


AS


Select CompanyId,CompanyName,Description,CreatedDate,CreatedBy,UpdatedDate,Updatedby FROM
Company WHERE CompanyId=@CompanyId