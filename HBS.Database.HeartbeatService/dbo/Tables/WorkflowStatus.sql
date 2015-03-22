CREATE TABLE [dbo].[WorkflowStatus] (
    [WorkflowStatusID] INT           IDENTITY (1, 1) NOT NULL,
    [StatusName]       VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([WorkflowStatusID] ASC)
);

