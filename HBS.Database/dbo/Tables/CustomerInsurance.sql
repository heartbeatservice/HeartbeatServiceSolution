CREATE TABLE [dbo].[CustomerInsurance] (
    [InsuranceId]             INT            NOT NULL,
    [CustomerId]             INT           NOT NULL,
    [EffectiveDate]           DATE           NOT NULL,
    [EndDate]                 DATE           NULL,
    [PCPName]                 NVARCHAR (100) NULL,
    [CustomerInsuranceNumber] NVARCHAR (50)  NULL,
    [InsuranceType]           NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Customer_Insurance] PRIMARY KEY CLUSTERED ([InsuranceId] ASC, [CustomerId] ASC, [EffectiveDate] ASC),
    CONSTRAINT [FK_Customer_InsuranceCustomers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId]),
    CONSTRAINT [FK_Customer_InsuranceInsuranceType] FOREIGN KEY ([InsuranceId]) REFERENCES [dbo].[InsuranceType] ([InsuranceId])
);

