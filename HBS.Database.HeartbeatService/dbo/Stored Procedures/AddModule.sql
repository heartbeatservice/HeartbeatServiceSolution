Create PROCEDURE [dbo].[AddModule]

@ModuleName nvarchar(100)=NULL,
@ModuleDescription nvarchar(100)=NULL,
@ModuleDisplayOrder INT=NULL,
@ModuleURL nvarchar(150)=NULL,
@IsForAll bit=1,
@ParentId int=NULL,
@IconName nvarchar(250)=NULL

AS


INSERT INTO Modules(ModuleName,ModuleDescription,DisplayOrder,ModuleURL,IsForAll,ParentId,IconName) 
	VALUES(@ModuleName,@ModuleDescription,@ModuleDisplayOrder,@ModuleURL,@IsForAll,@ParentId,@IconName)
	