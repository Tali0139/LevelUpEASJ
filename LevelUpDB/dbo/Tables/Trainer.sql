CREATE TABLE [dbo].[Trainer] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [YearsOfExpericence] INT           NULL,
    [Username]           VARCHAR (50)  NULL,
    [FirstName]          NVARCHAR (50) NULL,
    [LastName]           NVARCHAR (50) NULL,
    [Password]           NVARCHAR (50) NULL,
    [PhoneNumber]        INT           NULL,
    [Image]			NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)

);

