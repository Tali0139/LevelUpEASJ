CREATE TABLE [dbo].[Client] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Height]        INT           NULL,
    [Weight]        DECIMAL (18)  NULL,
    [FatPercentage] DECIMAL (18)  NULL,
    [Age]           INT           NULL,
    [Gender]        NVARCHAR (50) NULL,
    [WaistSize]     INT           NULL,
    [ArmSize]       DECIMAL (18)  NULL,
    [Username]      NVARCHAR (50) NULL,
    [FirstName]     NVARCHAR (50) NULL,
    [LastName]      NVARCHAR (50) NULL,
    [Password]      VARCHAR (50)  NULL,
    [PhoneNumber]   INT           NULL,
	[TotalXP]		INT			NULL,
	[Image]			NVARCHAR (50) NULL,
    [Goal] NVARCHAR(MAX) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

