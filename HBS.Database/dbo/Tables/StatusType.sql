CREATE TABLE [dbo].[StatusType] (
    [StatusId]   INT            IDENTITY (1, 1) NOT NULL,
    [StatusDesc] NVARCHAR (150) NULL,
    CONSTRAINT [PK_StatusType] PRIMARY KEY CLUSTERED ([StatusId] ASC)
);

