CREATE Procedure [dbo].[AddUpdateProfessionalAppointment]
@AppointmentId int=NULL,
@ProfessionalId int,
@CustomerId int=NULL,
@Title nvarchar(255)=NULL,
@StartTime Datetime=NULL,
@EndTime DateTime=NULL,
@StatusId int=NULL,
@Comments nvarchar(1000)=NULL,
@CreatedBy int =null,
@DateCreated DATETIME =NULL,
@UpdatedBy int=NULL,
@DateUpdated DateTime=NULL
AS

-- AddUpdateProfessionalAppointment 61,0,1,'Wow I get it now Another Light Headed Test','11/18/2014 9:00:00 AM','11/18/2014 9:30:00 AM',NULL,'Oh what the hell',0,'11/19/2014 12:00:00 AM'
IF @AppointmentId is not null
BEGIN
declare @sql nvarchar(max)
Declare @tblParams  table(id int identity(1,1),name nvarchar(50),paramName nvarchar(1000))

SET @Sql='Update Appointments
Set'


If(@CustomerId is not Null)
Insert Into @tblParams Values('CustomerId',@CustomerId)

If(@Title is not Null)
Insert Into @tblParams Values('Title',@Title)

If(@StartTime is not Null)
Insert Into @tblParams Values('StartTime',@StartTime)

If(@EndTime is not Null)
Insert Into @tblParams Values('EndTime',@EndTime)

If(@StatusId is not Null)
Insert Into @tblParams Values('StatusId',@StatusId)

If(@Comments is not Null)
Insert Into @tblParams Values('Comments',@Comments)

If(@CreatedBy is not Null)
Insert Into @tblParams Values('CreatedBy',@CreatedBy)

If(@DateCreated is not Null)
Insert Into @tblParams Values('DateCreated',@DateCreated)

If(@UpdatedBy is not Null)
Insert Into @tblParams Values('UpdatedBy',@UpdatedBy)

If(@DateUpdated is not Null)
Insert Into @tblParams Values('DateUpdated',@DateUpdated)

Declare @start int,@end int
Declare @UpdateColumn varchar(max)
Select @start =min(Id) from @tblParams
Select @end=max(Id) from @tblParams

While @start<=@end

BEGIN
Select @UpdateColumn=name+'='''+paramName FROM @tblParams WHERE ID=@start
set @UpdateColumn=@UpdateColumn+''''
if @start=1
Set @sql=@sql+ ' '+@UpdateColumn
ELSE
Set @sql=@sql+',' +@updateColumn
SET @start=@start+1
END
print @sql
Set @SQL=@Sql+' WHERE AppointmentId='+CONVERT(varchar,@AppointmentId) 
EXECute(@sql)
print @sql
END
ELSE
BEGIN
Insert Into Appointments(ProfessionalId,CustomerId,Title,StartTime,EndTime,StatusId,Comments,CreatedBy,DateCreated,UpdatedBy,DateUpdated)
            VALUES(@ProfessionalId,@CustomerId,@title,@StartTime,@EndTime,@StatusId,@Comments,@CreatedBy,@DateCreated,@UpdatedBy,@DateUpdated)
END