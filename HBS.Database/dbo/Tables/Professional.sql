CREATE TABLE [dbo].[Professional] (
    [ProfessionalId]                    INT            IDENTITY (1, 1) NOT NULL,
    [ProfessionalTypeId]               INT            NOT NULL,
    [First_Name]                         NVARCHAR (100) NULL,
    [Last_Name]                          NVARCHAR (100) NULL,
    [Phone]                              NVARCHAR (50)  NULL,
    [ProfessionalIdentificationNumber] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Professional] PRIMARY KEY CLUSTERED ([ProfessionalId] ASC),
    CONSTRAINT [FK_Professional_ProfessionalType] FOREIGN KEY ([ProfessionalTypeId]) REFERENCES [dbo].[ProfessionalType] ([ProfessionalTypeId])
);

