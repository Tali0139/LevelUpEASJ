CREATE TABLE [dbo].[Trainer] (
    [Id]                INT NOT NULL,
    [YearsOfExperience] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Trainer_User] FOREIGN KEY ([Id]) REFERENCES [dbo].[User] ([Id])
	ON DELETE CASCADE,
);
INSERT INTO Trainer
(Id)
VALUES
(2);

