CREATE TABLE [dbo].[Students] (
    [StudentId]    INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (100) NULL,
    [LastName]     VARCHAR (100) NULL,
    [EmailAddress] VARCHAR (100) NULL,
    [Gendar]       VARCHAR (10)  NULL,
    [Profession]   VARCHAR (100) NULL,
    [Source]       VARCHAR (100) NULL,
    [CreatedBy]    INT           NULL,
    [CreatedDate]  DATETIME      NULL,
    [UpdatedBy]    INT           NULL,
    [UpdatedDate]  DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([StudentId] ASC)
);


