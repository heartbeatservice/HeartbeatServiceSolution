CREATE TABLE [dbo].[webpages_UsersInRoles] (
    [webpages_UsersInRolesId] INT IDENTITY (1, 1) NOT NULL,
    [UserId]                  INT NOT NULL,
    [RoleId]                  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([webpages_UsersInRolesId] ASC)
);

