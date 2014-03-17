CREATE TABLE [dbo].[InsuranceType] (
    [InsuranceId]      INT            IDENTITY (1, 1) NOT NULL,
    [InsuranceName]    NVARCHAR (50)  NULL,
    [InsuranceAddress] NVARCHAR (150) NULL,
    [InsurancePhone]   NVARCHAR (15)  NULL,
    [InsuranceWebsite] NVARCHAR (250) NULL,
    CONSTRAINT [PK_InsuranceType] PRIMARY KEY CLUSTERED ([InsuranceId] ASC)
);

