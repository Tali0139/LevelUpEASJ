﻿INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (1, 0, 99)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (2, 100, 199)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (3, 200, 349)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (4, 350, 549)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (5, 550, 799)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (6, 800, 1099)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (7, 1100, 1449)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (8, 1450, 1849)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (9, 1850, 2299)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (10, 2300, 2799)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (11, 2800, 3349)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (12, 3350, 3949)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (13, 3950, 4599)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (14, 4600, 5299)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (15, 5300, 6049)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (16, 6050, 6849)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (17, 6850, 7699)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (18, 7700, 8599)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (19, 8600, 9999)
INSERT INTO [dbo].[Levels] ([LevelValue], [MinXP], [MaxXP]) VALUES (20, 10000, 100000)
INSERT INTO [dbo].[Client] ( [Height], [Weight], [FatPercentage], [Age], [Gender], [WaistSize], [ArmSize], [Username], [FirstName], [LastName], [Password], [PhoneNumber], [TotalXP], [Image]) VALUES ( 181, CAST(75 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), 27, N'Mand', 120, CAST(33 AS Decimal(18, 0)), N'Gibbernakker', N'Konrad', N'Kirkebjerg', N'11111', 11111111, 100, N'../Assets/mand1.png')
INSERT INTO [dbo].[Client] ( [Height], [Weight], [FatPercentage], [Age], [Gender], [WaistSize], [ArmSize], [Username], [FirstName], [LastName], [Password], [PhoneNumber], [TotalXP], [Image]) VALUES ( 178, CAST(78 AS Decimal(18, 0)), CAST(22 AS Decimal(18, 0)), 24, N'Mand', 120, CAST(47 AS Decimal(18, 0)), N'DonOli', N'Oliver', N'Eierstrand', N'22222', 12345678, 4000, N'../Assets/Mand3.png')
INSERT INTO [dbo].[Client] ( [Height], [Weight], [FatPercentage], [Age], [Gender], [WaistSize], [ArmSize], [Username], [FirstName], [LastName], [Password], [PhoneNumber], [TotalXP], [Image]) VALUES ( 178, CAST(75 AS Decimal(18, 0)), CAST(25 AS Decimal(18, 0)), 30, N'Mand', 120, CAST(10 AS Decimal(18, 0)), N'omar', N'Omar', N'Jaber', N'3333', 87654321, 9855, N'../Assets/Mand4.png')
INSERT INTO [dbo].[Client] ( [Height], [Weight], [FatPercentage], [Age], [Gender], [WaistSize], [ArmSize], [Username], [FirstName], [LastName], [Password], [PhoneNumber], [TotalXP], [Image]) VALUES ( 165, CAST(79 AS Decimal(18, 0)), CAST(30 AS Decimal(18, 0)), 36, N'Kvinde', 120, CAST(9 AS Decimal(18, 0)), N'Talus', N'Talia', N'Damary', N'4444', 15612733, 7705, N'../Assets/kvinde1.png')
INSERT INTO [dbo].[Client] ( [Height], [Weight], [FatPercentage], [Age], [Gender], [WaistSize], [ArmSize], [Username], [FirstName], [LastName], [Password], [PhoneNumber], [TotalXP], [Image]) VALUES ( 166, CAST(99 AS Decimal(18, 0)), CAST(31 AS Decimal(18, 0)), 41, N'Mand', 120, CAST(40 AS Decimal(18, 0)), N'Elven', N'John', N'Farimas', N'5555', 12378913, 495, N'../Assets/Mand5.png')
INSERT INTO [dbo].[Client] ( [Height], [Weight], [FatPercentage], [Age], [Gender], [WaistSize], [ArmSize], [Username], [FirstName], [LastName], [Password], [PhoneNumber], [TotalXP], [Image]) VALUES ( 159, CAST(58 AS Decimal(18, 0)), CAST(29 AS Decimal(18, 0)), 26, N'Kvinde', 120, CAST(57 AS Decimal(18, 0)), N'ILoveTv', N'Julie', N'Hassan', N'6666', 77771273, 4685, N'../Assets/Kvinde2.png')
INSERT INTO [dbo].[Client] ( [Height], [Weight], [FatPercentage], [Age], [Gender], [WaistSize], [ArmSize], [Username], [FirstName], [LastName], [Password], [PhoneNumber], [TotalXP], [Image]) VALUES ( 159, CAST(58 AS Decimal(18, 0)), CAST(19 AS Decimal(18, 0)), 46, N'Mand', 180, CAST(57 AS Decimal(18, 0)), N'Best', N'Alfred', N'Pedersen', N'7777', 74271293, 10800, N'.../Assets/BrugerIconGennemsigitg.png')
INSERT INTO [dbo].[Exercises] ([ExerciseName], [XpForExercise]) VALUES (N'Armbøjninger', 50)
INSERT INTO [dbo].[Exercises] ([ExerciseName], [XpForExercise]) VALUES (N'Ryg', 100)
INSERT INTO [dbo].[Exercises] ([ExerciseName], [XpForExercise]) VALUES (N'Løb', 200)
INSERT INTO [dbo].[Exercises] ([ExerciseName], [XpForExercise]) VALUES (N'Biceps', 50)
INSERT INTO [dbo].[Exercises] ([ExerciseName], [XpForExercise]) VALUES (N'Triceps', 50)
INSERT INTO [dbo].[Exercises] ([ExerciseName], [XpForExercise]) VALUES (N'Squats', 70)
INSERT INTO [dbo].[Trainer] ([FirstName], [LastName],[Password],[PhoneNumber],[Username],[YearsOfExpericence], [Image]) VALUES ('Trainer', 'Trainersen', 'admin', 12345678, 'admin',5,'../Assets/Mand2.png')
