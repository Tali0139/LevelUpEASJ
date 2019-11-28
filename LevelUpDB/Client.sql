CREATE TABLE [dbo].[Client]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Height] INT NULL, 
    [Weight] DECIMAL NULL, 
    [FatPercentage] DECIMAL NULL, 
    [Age] INT NULL, 
    [Gender] NVARCHAR(50) NULL, 
    [WaistSize] INT NULL, 
    [ArmSize] DECIMAL NULL, 
    [Username] NVARCHAR(50) NULL, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Password] VARCHAR(50) NULL, 
)
