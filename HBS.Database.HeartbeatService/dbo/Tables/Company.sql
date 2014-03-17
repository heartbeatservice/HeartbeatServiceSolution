CREATE TABLE [dbo].[Company]
(
	[CompanyId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CompanyName] VARCHAR(150) NOT NULL, 
    [Description] VARCHAR(1000) NULL, 
    [CreatedBy] INT NULL, 
    [CreatedDate] DATETIME NULL, 
    [UpdatedBy] INT NULL, 
    [UpdatedDate] DATETIME NULL
)
