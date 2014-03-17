CREATE TABLE [dbo].[webpages_OAuthMembership] (
    [webpages_OAuthMembershipId] INT            IDENTITY (1, 1) NOT NULL,
    [Provider]                   NVARCHAR (30)  NOT NULL,
    [ProviderUserId]             NVARCHAR (100) NOT NULL,
    [UserId]                     INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([webpages_OAuthMembershipId] ASC)
);

