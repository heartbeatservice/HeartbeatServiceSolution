CREATE TABLE [dbo].[Professional] (
    [ProfessionalId]                   INT            IDENTITY (1, 1) NOT NULL,
    [ProfessionalTypeId]               INT            NOT NULL,
    [CompanyId]                        INT            NOT NULL,
    [Title]                            NVARCHAR (50)  NULL,
    [FirstName]                        NVARCHAR (100) NULL,
    [LastName]                         NVARCHAR (100) NULL,
    [Phone]                            NVARCHAR (50)  NULL,
    [ProfessionalIdentificationNumber] NVARCHAR (150) NULL,
    [Email]                            NVARCHAR (150) NULL,
    CONSTRAINT [PK_Professional] PRIMARY KEY CLUSTERED ([ProfessionalId] ASC),
    CONSTRAINT [FK_Professional_Company] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([CompanyId])
);



