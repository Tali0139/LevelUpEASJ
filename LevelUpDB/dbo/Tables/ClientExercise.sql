CREATE TABLE [dbo].[ClientExercise]
(
	[ClientExerciseId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ClientId] INT NULL, 
    [ExerciseId] INT NULL, 
    CONSTRAINT [FK_ClientExercise_Client] FOREIGN KEY ([ClientId]) REFERENCES [Client]([Id]),
   CONSTRAINT [FK_ClientExercise_Exercises] FOREIGN KEY ([ExerciseId]) REFERENCES [Exercises]([ExerciseId])
)
