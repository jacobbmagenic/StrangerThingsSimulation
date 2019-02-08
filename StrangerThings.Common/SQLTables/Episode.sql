/****** Object:  Table [dbo].[Episode]    Script Date: 2/5/2019 3:38:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Episode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EpisodeNumber] [int] NOT NULL,
	[SeasonNumber] [int] NOT NULL,
	[EpisodeName] [nvarchar](48) NOT NULL,
	[RuntimeMinutes] [int] NULL,
	[Rating] [float] NULL,
 CONSTRAINT [PK_Episodes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[EpisodeNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Episode]  WITH CHECK ADD  CONSTRAINT [fk_season] FOREIGN KEY([SeasonNumber])
REFERENCES [dbo].[Season] ([SeasonNumber])
GO

ALTER TABLE [dbo].[Episode] CHECK CONSTRAINT [fk_season]
GO