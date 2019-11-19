CREATE TABLE [dbo].[achievementGifts] (
    [GiftItemId]       INT           NOT NULL,
    [NameOfGift]       NVARCHAR (50) NULL,
    [Level]            INT           NULL,
    [ItemsInInventory] INT           NULL,
    PRIMARY KEY CLUSTERED ([GiftItemId] ASC),
    CONSTRAINT [FK_AchievementGifts_Level] FOREIGN KEY ([Level]) REFERENCES [dbo].[LevelUp] ([Level])
);

