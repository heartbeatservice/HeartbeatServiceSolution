CREATE TABLE [dbo].[Professional_Schedule] (
    [Professional_Schedule_ID] INT      IDENTITY (1, 1) NOT NULL,
    [Professional_ID]          INT      NOT NULL,
    [StartTime]                DATETIME NOT NULL,
    [EndTime]                  DATETIME NULL,
    [TimeIntervalMinutes]      SMALLINT NULL,
    CONSTRAINT [PK_Professional_Schedule] PRIMARY KEY CLUSTERED ([Professional_Schedule_ID] ASC)
);

