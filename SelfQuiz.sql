IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'selfquiz')
BEGIN
EXEC('CREATE SCHEMA selfquiz');
END

IF EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[selfquiz].[Soort]') AND type in (N'U'))
DROP TABLE [selfquiz].[Soort]
GO

IF EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[selfquiz].[Tag]') AND type in (N'U'))
DROP TABLE [selfquiz].[Tag]
GO

IF EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[selfquiz].[Vraag]') AND type in (N'U'))
DROP TABLE [selfquiz].[Vraag]
GO

IF EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[selfquiz].[VraagTag]') AND type in (N'U'))
DROP TABLE [selfquiz].[VraagTag]
GO

CREATE TABLE [selfquiz].[Soort](
    [id] INT IDENTITY(1,1) NOT NULL,
    [soort] VARCHAR(MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [selfquiz].[Vraag](
    [id] INT IDENTITY(1,1) NOT NULL,
    [vraag] VARCHAR(MAX) NOT NULL,
    [antwoord] VARCHAR(MAX) NOT NULL,
	[soortId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
	CONSTRAINT [soortId] FOREIGN KEY ([soortId]) REFERENCES [selfquiz].[Soort]([id])
);

CREATE TABLE [selfquiz].[Tag](
    [id] INT IDENTITY(1,1) NOT NULL,
    [tag] VARCHAR(MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [selfquiz].[VraagTag](
    [Id] INT IDENTITY(1,1) NOT NULL,
	[vraagId] INT NOT NULL,
	[tagId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [vraagId] FOREIGN KEY ([vraagId]) REFERENCES [selfquiz].[Vraag]([id]),
    CONSTRAINT [tagId] FOREIGN KEY ([tagId]) REFERENCES [selfquiz].[Tag]([id])
);


SET IDENTITY_INSERT [selfquiz].[Soort] ON
INSERT [selfquiz].[Soort]([id], [soort])
VALUES (1, 'Naam')
INSERT [selfquiz].[Soort]([id], [soort])
VALUES (2, 'Voorwerp')
SET IDENTITY_INSERT [selfquiz].[Soort] OFF

SET IDENTITY_INSERT [selfquiz].[Vraag] ON
INSERT [selfquiz].[Vraag]([id], [vraag], [antwoord], [soortId])
VALUES (1, 'Wie heeft het boek "Utopia" geschreven?', 'Thomas More', 1)
INSERT [selfquiz].[Vraag]([id], [vraag], [antwoord], [soortId])
values (2, 'Wat is het bekende boek dat Thomas More schreef in 1516?', 'Utopia', 2)
SET IDENTITY_INSERT [selfquiz].[Vraag] OFF

SET IDENTITY_INSERT [selfquiz].[Tag] ON
INSERT [selfquiz].[Tag]([id], [tag])
VALUES (1, 'Geschiedenis')
INSERT [selfquiz].[Tag]([id], [tag])
VALUES (2, 'Humanisme')
SET IDENTITY_INSERT [selfquiz].[Tag] OFF

SET IDENTITY_INSERT [selfquiz].[VraagTag] ON
INSERT [selfquiz].[VraagTag]([id], [vraagId], [tagId])
VALUES (1, 1, 1)
INSERT [selfquiz].[VraagTag]([id], [vraagId], [tagId])
VALUES (2, 1, 2)
SET IDENTITY_INSERT [selfquiz].[VraagTag] OFF

