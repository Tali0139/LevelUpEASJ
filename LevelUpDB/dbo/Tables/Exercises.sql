CREATE TABLE [dbo].[Exercises]
(
	[ExerciseName] NVARCHAR(50) NOT NULL , 
    [XpForExercise] INT NOT NULL, 
    [ExerciseId] INT NOT NULL IDENTITY, 
    [ExerciseImage] NVARCHAR(50) NULL, 
    PRIMARY KEY ([ExerciseId])
)
