CREATE TABLE [dbo].[Professional_Type] (
    [Professional_Type_ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Professional_Type_Desc] NVARCHAR (150) NOT NULL,
    CONSTRAINT [PK_Professional_Type] PRIMARY KEY CLUSTERED ([Professional_Type_ID] ASC)
);

