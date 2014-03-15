CREATE TABLE [dbo].[Insurance_Type] (
    [InsuranceID]      INT            IDENTITY (1, 1) NOT NULL,
    [InsuranceName]    NVARCHAR (50)  NULL,
    [InsuranceAddress] NVARCHAR (150) NULL,
    [InsurancePhone]   NVARCHAR (15)  NULL,
    [InsuranceWebsite] NVARCHAR (250) NULL,
    CONSTRAINT [PK_Insurance_Type] PRIMARY KEY CLUSTERED ([InsuranceID] ASC)
);

