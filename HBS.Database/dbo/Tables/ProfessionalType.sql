CREATE TABLE [dbo].[ProfessionalType] (
    [ProfessionalTypeId]   INT            IDENTITY (1, 1) NOT NULL,
    [ProfessionalTypeDesc] NVARCHAR (150) NOT NULL,
    CONSTRAINT [PK_ProfessionalType] PRIMARY KEY CLUSTERED ([ProfessionalTypeId] ASC)
);

