CREATE TABLE [dbo].[UserProfile] (
    [UserId]                                  INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId]                               INT            NOT NULL,
    [UserName]                                NVARCHAR (MAX) NULL,
    [CreateDate]                              DATETIME       NULL,
    [ConfirmationToken]                       NVARCHAR (128) NULL,
    [IsConfirmed]                             BIT            NULL,
    [LastPasswordFailureDate]                 DATETIME       NULL,
    [PasswordFailuresSinceLastSuccess]        INT            NOT NULL,
    [Password]                                NVARCHAR (128) NOT NULL,
    [PasswordChangedDate]                     DATETIME       NULL,
    [PasswordSalt]                            NVARCHAR (128) NOT NULL,
    [PasswordVerificationToken]               NVARCHAR (128) NULL,
    [PasswordVerificationTokenExpirationDate] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC), 
    CONSTRAINT [FK_UserProfile_Company] FOREIGN KEY ([CompanyId]) REFERENCES [Company]([CompanyId])
);

