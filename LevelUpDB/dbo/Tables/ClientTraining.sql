CREATE TABLE [dbo].[ClientTraining] (
    [CTId]          INT NOT NULL,
    [AppointmentId] INT NULL,
    [ExerciseId]    INT NULL,
    PRIMARY KEY CLUSTERED ([CTId] ASC),
    CONSTRAINT [FK_ClientTraining_ToTable] FOREIGN KEY ([AppointmentId]) REFERENCES [dbo].[ClientAppointment] ([AppointmentId]),
    CONSTRAINT [FK_ClientTraining_TrainingExercise] FOREIGN KEY ([ExerciseId]) REFERENCES [dbo].[TrainingExercise] ([ExerciseId])
);

