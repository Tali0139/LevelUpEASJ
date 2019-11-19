CREATE TABLE [dbo].[Trainer] (
    [Id]                INT NOT NULL,
    [YearsOfExperience] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Trainer_IUser] FOREIGN KEY ([Id]) REFERENCES [dbo].[IUser] ([Id])
);

