
Create PROCEDURE [dbo].[UpdateProfessional] 
--UpdateProfessional 1,1,'ABCTesting','','Umais','Siddiqui','umais@heartbeatservice.com'

@ProfessionalId int,
@ProfessionalTypeId int=NULL,
@CompanyId int=NULL,
@FirstName nvarchar(100)=NULL,
@LastName nvarchar(100)=NULL,
@Phone nvarchar(50)=NULL,
@ProfessionalIdentificationNumber nvarchar(150)=NULL


AS


declare @sql varchar(256)
Declare @tblParams  table(id int identity(1,1),name varchar(50),paramName varchar(50))

SET @Sql='Update Professional
Set'

If(@ProfessionalTypeId is not Null)
Insert Into @tblParams Values('ProfessionalTypeId',@ProfessionalTypeId)


If(@CompanyId is not Null)
Insert Into @tblParams Values('CompanyId',@CompanyId)


If(@FirstName is not Null)
Insert Into @tblParams Values('FirstName',@FirstName)

If(@LastName is not Null)
Insert Into @tblParams Values('LastName',@LastName)

If(@Phone is not Null)
Insert Into @tblParams Values('Phone',CONVERT(varchar,@Phone))

If(@ProfessionalIdentificationNumber is not Null)
Insert Into @tblParams Values('ProfessionalIdentificationNumber',CONVERT(varchar,@ProfessionalIdentificationNumber))



Declare @start int,@end int
Declare @UpdateColumn varchar(50)
Select @start =min(Id) from @tblParams
Select @end=max(Id) from @tblParams

While @start<=@end

BEGIN
Select @UpdateColumn=name+'='''+paramName+'''' FROM @tblParams WHERE ID=@start
if @start=1
Set @sql=@sql+ ' '+@UpdateColumn
ELSE
Set @sql=@sql+',' +@updateColumn
SET @start=@start+1
END

Set @SQL=@Sql+' WHERE ProfessionalID='+CONVERT(varchar,@ProfessionalID) 
EXECute(@sql)