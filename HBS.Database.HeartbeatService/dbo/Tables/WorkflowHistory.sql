CREATE TABLE [dbo].[WorkflowHistory] (
    [WorkflowHistoryID] INT      IDENTITY (1, 1) NOT NULL,
    [WorkflowID]        INT      NULL,
    [Payload]           TEXT     NULL,
    [DateCreated]       DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([WorkflowHistoryID] ASC)
);

