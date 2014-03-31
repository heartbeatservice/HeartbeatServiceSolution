CREATE TABLE [dbo].[Company] (
    [CompanyId]   INT            IDENTITY (1, 1) NOT NULL,
    [CompanyName] VARCHAR (150)  NOT NULL,
    [Description] VARCHAR (1000) NULL,
    [CreatedBy]   INT            NULL,
    [CreatedDate] DATETIME       NULL,
    [UpdatedBy]   INT            NULL,
    [UpdatedDate] DATETIME       NULL,
    [IsActive]    BIT            NULL,
    PRIMARY KEY CLUSTERED ([CompanyId] ASC)
);


