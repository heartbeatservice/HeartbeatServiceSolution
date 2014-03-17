CREATE TABLE [dbo].[Appointments] (
    [AppointmentId]        INT             IDENTITY (1, 1) NOT NULL,
    [ProfessionalId]      INT             NOT NULL,
    [CustomerId]          INT             NULL,
    [AppointmentDate]      DATE            NOT NULL,
    [AppointmentStartTime] NVARCHAR (50)   NOT NULL,
    [StatusId]             INT             NULL,
    [Comments]             NVARCHAR (1000) NULL,
    CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED ([AppointmentId] ASC),
    CONSTRAINT [FK_Appointments_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId]),
    CONSTRAINT [FK_Appointments_Professional] FOREIGN KEY ([ProfessionalId]) REFERENCES [dbo].[Professional] ([ProfessionalId]),
    CONSTRAINT [FK_Appointments_StatusType] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[StatusType] ([StatusId])
);

