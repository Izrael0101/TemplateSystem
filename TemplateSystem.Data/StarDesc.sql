CREATE TABLE [dbo].[StarDesc] (

 [StarName]            NVARCHAR (150) NULL,

 [StarSize]            NVARCHAR (50)  NULL,

 [StarDistanceFromSun] NVARCHAR (50)  NULL,

 [StarGalaxyName]      NVARCHAR (50)  NULL,

 [StarBrightness]      NVARCHAR (50)  NULL,

 [SpectralType]        NVARCHAR (50)  NULL,

 [Id]                  INT            IDENTITY (1, 1) NOT NULL,

 CONSTRAINT [PK_StarDesc] PRIMARY KEY CLUSTERED ([Id] ASC)

 );

SET IDENTITY_INSERT [dbo].[StarDesc] ON
INSERT INTO [dbo].[StarDesc] ([StarName], [StarSize], [StarDistanceFromSun], [StarGalaxyName], [StarBrightness], [SpectralType], [Id]) VALUES (N'10 Lacertae', N'8.27', N'2300', N'Lacerta OB1', N'-4.40', N'O9V', 1)
INSERT INTO [dbo].[StarDesc] ([StarName], [StarSize], [StarDistanceFromSun], [StarGalaxyName], [StarBrightness], [SpectralType], [Id]) VALUES (N'Rigel', N'79', N'863', N'Orion', N'-7.84', N'B8Ia', 2)
INSERT INTO [dbo].[StarDesc] ([StarName], [StarSize], [StarDistanceFromSun], [StarGalaxyName], [StarBrightness], [SpectralType], [Id]) VALUES (N'Sirius ', N'1.71', N'8.6', N'Canis Major', N'1.42', N'A1V', 3)
INSERT INTO [dbo].[StarDesc] ([StarName], [StarSize], [StarDistanceFromSun], [StarGalaxyName], [StarBrightness], [SpectralType], [Id]) VALUES (N'Canopus', N'71', N'320', N'Carina', N'-5.71', N'A9II', 4)
INSERT INTO [dbo].[StarDesc] ([StarName], [StarSize], [StarDistanceFromSun], [StarGalaxyName], [StarBrightness], [SpectralType], [Id]) VALUES (N'Sun', N'1', N'0', N'Milky Way', N'4.83', N'G2V', 5)
INSERT INTO [dbo].[StarDesc] ([StarName], [StarSize], [StarDistanceFromSun], [StarGalaxyName], [StarBrightness], [SpectralType], [Id]) VALUES (N'Arcturus', N'25.4', N'36.66', N'Bootes', N'-0.32', N'K0III', 6)
INSERT INTO [dbo].[StarDesc] ([StarName], [StarSize], [StarDistanceFromSun], [StarGalaxyName], [StarBrightness], [SpectralType], [Id]) VALUES (N'Betelgeuse', N'1180', N'642.5', N'Orion', N'-5.85', N'M1Ia', 7)
SET IDENTITY_INSERT [dbo].[StarDesc] OFF