Create PROCEDURE [dbo].[UpdateModule] 
-- UpdateModule 1,null,'Aetnas',null,'866-801-8245','www.aet-na.com',1

@ModuleId int,
@ModuleName nvarchar(50)=NULL,
@ModuleDescription nvarchar(150)=NULL,
@ModuleDisplayOrder int=NULL,
@ModuleURL nvarchar(250)=NULL,
@IsForAll bit=1,
@ParentId int=NULL,
@IconName nvarchar(250)=NULL


AS


declare @sql varchar(256)
Declare @tblParams  table(id int identity(1,1),name varchar(50),paramName varchar(50))

SET @Sql='Update Modules
Set'


If(@ModuleName is not Null)
Insert Into @tblParams Values('ModuleName',@ModuleName)

If(@ModuleDescription is not Null)
Insert Into @tblParams Values('ModuleDescription',@ModuleDescription)

If(@ModuleDisplayOrder is not Null)
Insert Into @tblParams Values('DisplayOrder',@ModuleDisplayOrder)

If(@ModuleURL is not Null)
Insert Into @tblParams Values('ModuleURL',@ModuleURL)

If(@IsForAll is not Null)
Insert Into @tblParams Values('IsForAll',@IsForAll)

If(@ParentId is not Null)
Insert Into @tblParams Values('ParentId',@ParentId)

If(@IconName is not Null)
Insert Into @tblParams Values('IconName',@IconName)


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

Set @SQL=@Sql+' WHERE ModuleId='+CONVERT(varchar,@ModuleId) 
EXECute(@sql)