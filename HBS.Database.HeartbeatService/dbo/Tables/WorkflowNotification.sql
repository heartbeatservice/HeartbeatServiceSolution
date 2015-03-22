CREATE TABLE [dbo].[WorkflowNotification] (
    [WorkflowNotificationID] INT          IDENTITY (1, 1) NOT NULL,
    [WorkflowID]             INT          NULL,
    [Payload]                TEXT         NULL,
    [NotificationType]       VARCHAR (50) NULL,
    [DateCreated]            DATETIME     NOT NULL,
    PRIMARY KEY CLUSTERED ([WorkflowNotificationID] ASC)
);

