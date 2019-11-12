CREATE TABLE [dbo].[Client]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Weight] DECIMAL NOT NULL, 
    [Gender] NCHAR(10) NOT NULL, 
    [FatPercent] DECIMAL NOT NULL, 
    [ClientXp] INT NOT NULL, 
    [ClientLevel] INT NOT NULL, 
    [Height] INT NOT NULL
)
