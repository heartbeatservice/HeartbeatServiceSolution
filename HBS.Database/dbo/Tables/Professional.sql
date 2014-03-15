CREATE TABLE [dbo].[Professional] (
    [Professional_ID]                    INT            IDENTITY (1, 1) NOT NULL,
    [Professional_Type_ID]               INT            NOT NULL,
    [First_Name]                         NVARCHAR (100) NULL,
    [Last_Name]                          NVARCHAR (100) NULL,
    [Phone]                              NVARCHAR (50)  NULL,
    [Professional_Identification_Number] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Professional] PRIMARY KEY CLUSTERED ([Professional_ID] ASC),
    CONSTRAINT [FK_Professional_Professional_Type] FOREIGN KEY ([Professional_Type_ID]) REFERENCES [dbo].[Professional_Type] ([Professional_Type_ID])
);

