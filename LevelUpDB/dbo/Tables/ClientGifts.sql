CREATE TABLE [dbo].[ClientGifts] (
    [CGId]   INT NOT NULL,
    [Id]     INT NULL,
    [GiftId] INT NULL,
    PRIMARY KEY CLUSTERED ([CGId] ASC),
    CONSTRAINT [FK_ClientGifts_achievementGifts (GiftId)] FOREIGN KEY ([GiftId]) REFERENCES [dbo].[achievementGifts] ([GiftItemId]),
    CONSTRAINT [FK_ClientGifts_Client] FOREIGN KEY ([Id]) REFERENCES [dbo].[Client] ([Id])
);

