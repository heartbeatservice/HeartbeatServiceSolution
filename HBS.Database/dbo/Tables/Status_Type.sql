CREATE TABLE [dbo].[Status_Type] (
    [StatusID]   INT            IDENTITY (1, 1) NOT NULL,
    [StatusDesc] NVARCHAR (150) NULL,
    CONSTRAINT [PK_Status_Type] PRIMARY KEY CLUSTERED ([StatusID] ASC)
);

