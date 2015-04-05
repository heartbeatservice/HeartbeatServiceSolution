CREATE TABLE [dbo].[Modules] (
    [ModuleId]          INT            NOT NULL,
    [ModuleName]        NVARCHAR (255) NULL,
    [ModuleDescription] NVARCHAR (255) NULL,
    [DisplayOrder]      INT            NULL,
    [ModuleURL]         NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ModuleId] ASC)
);

