Use LevelUpDB;
GO;
CREATE TABLE [dbo].[Client] (
    [Id]         INT          NOT NULL,
    [Weight]     DECIMAL (18) NOT NULL,
    [Gender]     NCHAR (10)   NOT NULL,
    [FatPercent] DECIMAL (18) NOT NULL,
    [TotalXp]    INT          NOT NULL,
    [Level]      INT          NOT NULL,
    [Height]     INT          NOT NULL,
    [Age] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Client_User] FOREIGN KEY ([Id]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE,
    );
INSERT INTO Client
(Id)
VALUES
(1);
GO;