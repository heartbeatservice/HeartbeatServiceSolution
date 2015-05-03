CREATE TABLE [dbo].[Workflow] (
    [WorkflowID]    INT          IDENTITY (1, 1) NOT NULL,
    [CategoryID]    INT          NULL,
    [OwnerID]       INT          NULL,
    [WorkerID]      INT          NULL,
    [WorkflowTitle] VARCHAR (50) NOT NULL,
    [WorkflowNote]  TEXT         NULL,
    [DueDate]       DATETIME     NULL,
    [StatusID]      INT          NULL,
    [DateCreated]   DATETIME     NOT NULL,
    [DateUpdated]   DATETIME     NOT NULL,
    [CompanyId] BIGINT NULL, 
    PRIMARY KEY CLUSTERED ([WorkflowID] ASC),
    FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[WorkflowCategory] ([WorkflowCategoryID]),
    FOREIGN KEY ([OwnerID]) REFERENCES [dbo].[UserProfile] ([UserId]),
    FOREIGN KEY ([StatusID]) REFERENCES [dbo].[WorkflowStatus] ([WorkflowStatusID]),
    FOREIGN KEY ([WorkerID]) REFERENCES [dbo].[UserProfile] ([UserId])
);

