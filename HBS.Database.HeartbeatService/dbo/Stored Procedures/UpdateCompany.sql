

CREATE PROCEDURE [dbo].[UpdateCompany] 
--UpdateUser 1,1,'ABCTesting','','Umais','Siddiqui','umais@heartbeatservice.com'

@CompanyId int,
@CompanyName nvarchar(150)=NULL,
@Description nvarchar(1000)=NULL,
@UpdatedBy int=NULL



AS



DECLARE @UpdatedDate DATETime=getDate();

declare @sql varchar(256)
Declare @tblParams  table(id int identity(1,1),name varchar(50),paramName varchar(50))

SET @Sql='Update  Company
Set'





If(@CompanyName is not Null)
Insert Into @tblParams Values('CompanyName',@CompanyName)

If(@Description is not Null)
Insert Into @tblParams Values('Description',@Description)





If(@UpdatedDate is not Null)
Insert Into @tblParams Values('UpdatedDate',CONVERT(varchar,@UpdatedDate))

If(@UpdatedBy is not Null)
Insert Into @tblParams Values('UpdatedBy',CONVERT(varchar,@UpdatedBy))

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

Set @SQL=@Sql+' WHERE CompanyId='+CONVERT(varchar,@CompanyId) 
EXECute(@sql)