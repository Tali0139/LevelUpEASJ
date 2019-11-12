--Konrad Kirkebjerg
CREATE TABLE [dbo].[achievementGifts]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [GiftItem] NVARCHAR(50) NULL, 
    [Price] DECIMAL NULL, 
    [DiscountPercentage] DECIMAL NULL,
	[ItemsInInventory] int NULL


)
