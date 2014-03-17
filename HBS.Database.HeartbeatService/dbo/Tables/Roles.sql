CREATE TABLE [dbo].[Roles]
(
	[RoleId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CompanyId] INT NOT NULL, 
    [RoleName] VARCHAR(150) NOT NULL, 
    [CreatedBy] INT NULL, 
    [CreatedDate] DATETIME NULL, 
    [UpdatedBy] INT NULL, 
    [UpdatedOn] DATETIME NULL
)
