
CREATE PROCEDURE [dbo].[AddStudent]
@FirstName varchar(100),
@LastName varchar(100),
@EmailAddress varchar(100),
@Gendar varchar(10),
@Profession varchar(100),
@Source	varchar(100)


AS


INSERT INTO Students(FirstName,LastName,EmailAddress,Gendar,Profession,[Source],CreatedDate,CreatedBy,UpdatedDate,UpdatedBy) 
VALUES(@FirstName,@LastName,@EmailAddress,@Gendar,@Profession,@Source,GetUtcDate(),0,GetUtcDate(),0)