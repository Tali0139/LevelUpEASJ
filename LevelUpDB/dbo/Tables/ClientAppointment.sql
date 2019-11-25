CREATE TABLE [dbo].[ClientAppointment] (
    [AppointmentId]   INT      NOT NULL,
    [Time]            TIME (7) NULL,
    [NoOfReps1]       INT      NULL,
    [Reps Completed1] INT      NULL,
    [Id]              INT      NULL,
    [Date]            DATETIME NULL,
    [XpEarned]        INT      NULL,
    PRIMARY KEY CLUSTERED ([AppointmentId] ASC),
    CONSTRAINT [FK_ClientAppointment_ExperiencePoints] FOREIGN KEY ([XpEarned]) REFERENCES [dbo].[ExperiencePoints] ([XpEarned]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ClientAppointment_User] FOREIGN KEY ([Id]) REFERENCES [dbo].[User] ([Id])ON DELETE CASCADE
);

