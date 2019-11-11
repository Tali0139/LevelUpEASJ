CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Username] NVARCHAR(50) NOT NULL, 
    [Password] NCHAR(10) NOT NULL
)
