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
    CONSTRAINT [FK_Client_IUser] FOREIGN KEY ([Id]) REFERENCES [dbo].[IUser] ([Id]),
    CONSTRAINT [FK_Client_LevelUp] FOREIGN KEY ([Level]) REFERENCES [dbo].[LevelUp] ([Level])
);

