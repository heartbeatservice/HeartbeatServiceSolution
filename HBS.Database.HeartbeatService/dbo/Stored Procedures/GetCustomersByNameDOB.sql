    
CREATE PROCEDURE [dbo].[GetCustomersByNameDOB]    
--[GetCustomersByNameDOB]  1, 'Aziz'
    
@CompanyId int,  
@Name nvarchar(50)=Null,  
@DateOfBirth Date=Null
    
    
AS    
    if ISNULL(@Name,'-1')='-1'
	set @Name=Null
    if(YEAR(ISNULL(@DateOfBirth,'1/1/1900'))=1900)
	SET @DateOfbirth=null
SELECT     
 C.CustomerId,    
 P.CompanyID,    
 P.CompanyName,    
 c.FirstName,    
 c.MiddleInitial,  
 c.LastName,    
 c.DateOfBirth,    
 c.Address1,  
 c.Address2,  
 c.City,  
 c.State,  
 c.Zip,  
 c.HomePhone,  
 c.CellPhone,  
 c.Email,  
 c.CreatedBy,  
 c.DateCreated,  
 c.UpdatedBy,  
 c.DateUpdated,
 c.IsActive
FROM Customers C    
inner join Company P    
on C.CompanyID=P.CompanyID  
WHERE ((ISNULL(C.FirstName,'') + ' ' + ISNULL(C.LastName,'') like '%'+@Name+'%') or @Name is null)  
and c.companyid=@CompanyId  and (c.DateofBirth=@DateofBirth or @DateofBirth is Null)