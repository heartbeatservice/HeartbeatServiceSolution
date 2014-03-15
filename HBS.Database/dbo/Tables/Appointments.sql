CREATE TABLE [dbo].[Appointments] (
    [AppointmentID]        INT             IDENTITY (1, 1) NOT NULL,
    [Professional_ID]      INT             NOT NULL,
    [Customer_ID]          INT             NULL,
    [AppointmentDate]      DATE            NOT NULL,
    [AppointmentStartTime] NVARCHAR (50)   NOT NULL,
    [StatusID]             INT             NULL,
    [Comments]             NVARCHAR (1000) NULL,
    CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED ([AppointmentID] ASC),
    CONSTRAINT [FK_Appointments_Customers] FOREIGN KEY ([Customer_ID]) REFERENCES [dbo].[Customers] ([Customer_ID]),
    CONSTRAINT [FK_Appointments_Professional] FOREIGN KEY ([Professional_ID]) REFERENCES [dbo].[Professional] ([Professional_ID]),
    CONSTRAINT [FK_Appointments_Status_Type] FOREIGN KEY ([StatusID]) REFERENCES [dbo].[Status_Type] ([StatusID])
);

