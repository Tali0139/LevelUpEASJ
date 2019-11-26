CREATE TABLE [dbo].[Trainer]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [YearsOfExpericence] NCHAR(10) NULL, 
    CONSTRAINT [FK_Trainer_User] FOREIGN KEY ([Id]) REFERENCES [User]([Id]) 
)
