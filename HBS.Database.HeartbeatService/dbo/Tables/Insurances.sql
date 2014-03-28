CREATE TABLE [dbo].[Insurances] (
    [InsuranceId]      INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId]        INT            NOT NULL,
    [InsuranceName]    NVARCHAR (50)  NULL,
    [InsuranceAddress] NVARCHAR (150) NULL,
    [InsurancePhone]   NVARCHAR (15)  NULL,
    [InsuranceWebsite] NVARCHAR (250) NULL,
    CONSTRAINT [PK_InsuranceType] PRIMARY KEY CLUSTERED ([InsuranceId] ASC), 
    CONSTRAINT [FK_InsuranceType_Company] FOREIGN KEY ([CompanyId]) REFERENCES [Company]([CompanyId])
);

