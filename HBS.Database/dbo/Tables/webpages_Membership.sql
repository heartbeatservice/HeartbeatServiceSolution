CREATE TABLE [dbo].[webpages_Membership] (
    [webpages_MembershipId]                   INT            IDENTITY (1, 1) NOT NULL,
    [UserId]                                  INT            NOT NULL,
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
    PRIMARY KEY CLUSTERED ([webpages_MembershipId] ASC)
);

