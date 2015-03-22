CREATE TABLE [dbo].[WorkflowCategory] (
    [WorkflowCategoryID] INT           IDENTITY (1, 1) NOT NULL,
    [CategoryName]       VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([WorkflowCategoryID] ASC)
);

