CREATE TABLE [dbo].[Customer_Insurance] (
    [InsuranceID]             INT            NOT NULL,
    [Customer_ID]             INT            NOT NULL,
    [EffectiveDate]           DATE           NOT NULL,
    [EndDate]                 DATE           NULL,
    [PCPName]                 NVARCHAR (100) NULL,
    [CustomerInsuranceNumber] NVARCHAR (50)  NULL,
    [InsuranceType]           NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Customer_Insurance] PRIMARY KEY CLUSTERED ([InsuranceID] ASC, [Customer_ID] ASC, [EffectiveDate] ASC),
    CONSTRAINT [FK_Customer_Insurance_Customers] FOREIGN KEY ([Customer_ID]) REFERENCES [dbo].[Customers] ([Customer_ID]),
    CONSTRAINT [FK_Customer_Insurance_Insurance_Type] FOREIGN KEY ([InsuranceID]) REFERENCES [dbo].[Insurance_Type] ([InsuranceID])
);

