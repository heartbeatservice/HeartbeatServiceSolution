CREATE TABLE [dbo].[Customers] (
    [CustomerId]  INT            IDENTITY (1, 1) NOT NULL,
    [UserId]      INT            NOT NULL,
    [FirstName]   NVARCHAR (50)  NULL,
    [LastName]    NVARCHAR (50)  NULL,
    [DateOfBirth] DATE           NULL,
    [Address1]    NVARCHAR (100) NULL,
    [Address2]    NVARCHAR (100) NULL,
    [City]        NVARCHAR (50)  NULL,
    [State]       CHAR (2)       NULL,
    [Zip]         CHAR (10)      NULL,
    [HomePhone]   NVARCHAR (10)  NULL,
    [CellPhone]   NVARCHAR (10)  NULL,
    [CreatedBy] INT NULL, 
    [DateCreated] DATETIME NULL, 
    [UpdatedBy] INT NULL, 
    [DateUpdated] DATETIME NULL, 
    [Middle Initial] VARCHAR NULL, 
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);

