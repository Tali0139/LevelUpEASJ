CREATE TABLE [dbo].[Exercises]
(
	[ExerciseName] NVARCHAR(50) NOT NULL , 
    [XpForExercise] INT NOT NULL, 
    [ExerciseId] INT NOT NULL IDENTITY, 
    PRIMARY KEY ([ExerciseId])
)
