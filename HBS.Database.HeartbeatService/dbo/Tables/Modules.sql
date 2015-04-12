CREATE TABLE [dbo].[Modules] (
    [ModuleId]          INT            NOT NULL IDENTITY,
    [ModuleName]        NVARCHAR (255) NULL,
    [ModuleDescription] NVARCHAR (255) NULL,
    [DisplayOrder]      INT            NULL,
    [ModuleURL]         NVARCHAR (255) NULL,
	[ParentId]          INT            NULL,
	[IsForAll]			BIT			   NULL,
	[IconName]			Varchar(50)	   NULL,
    PRIMARY KEY CLUSTERED ([ModuleId] ASC)
);

