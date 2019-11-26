CREATE TABLE [dbo].[User] (
    [Id]        INT           NOT NULL,
    [Firstname] NVARCHAR (50) NOT NULL,
    [Username]  NVARCHAR (50) NOT NULL,
    [Password]  NVARCHAR (50) NOT NULL,
    [Lastname]  NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
    
);
INSERT INTO User
(Id, Firstname, Username, Password, Lastname)
VALUES
(1,"Peter","Amazing", "Spiderman","Parker"),
(2, "Rasmus", "Pandekage","Mary","Klump");
