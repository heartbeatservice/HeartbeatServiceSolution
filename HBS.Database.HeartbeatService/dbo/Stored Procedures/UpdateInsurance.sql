
Create PROCEDURE [dbo].[UpdateInsurance] 
-- UpdateInsurance 1,null,'Aetnas',null,'8668018245','www.aetnas.com'


@InsuranceId int,
@CompanyId int=NULL,
@InsuranceName nvarchar(50)=NULL,
@InsuranceAddress nvarchar(150)=NULL,
@InsurancePhone nvarchar(15)=NULL,
@InsuranceWebsite nvarchar(250)=NULL


AS


declare @sql varchar(256)
Declare @tblParams  table(id int identity(1,1),name varchar(50),paramName varchar(50))

SET @Sql='Update Insurances
Set'


If(@CompanyId is not Null)
Insert Into @tblParams Values('CompanyId',@CompanyId)

If(@InsuranceName is not Null)
Insert Into @tblParams Values('InsuranceName',@InsuranceName)

If(@InsuranceAddress is not Null)
Insert Into @tblParams Values('InsuranceAddress',@InsuranceAddress)

If(@InsurancePhone is not Null)
Insert Into @tblParams Values('InsurancePhone',CONVERT(varchar,@InsurancePhone))

If(@InsuranceWebsite is not Null)
Insert Into @tblParams Values('InsuranceWebsite',CONVERT(varchar,@InsuranceWebsite))



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

Set @SQL=@Sql+' WHERE InsuranceId='+CONVERT(varchar,@InsuranceId) 
EXECute(@sql)