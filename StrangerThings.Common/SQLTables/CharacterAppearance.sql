/****** Object:  Table [dbo].[CharacterAppearance]    Script Date: 2/5/2019 3:38:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CharacterAppearance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](48) NOT NULL,
	[EpisodePresent] [int] NOT NULL,
 CONSTRAINT [constraint AppearancePairs] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[EpisodePresent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CharacterAppearance]  WITH CHECK ADD  CONSTRAINT [fk_ep_num] FOREIGN KEY([EpisodePresent])
REFERENCES [dbo].[Episode] ([EpisodeNumber])
GO

ALTER TABLE [dbo].[CharacterAppearance] CHECK CONSTRAINT [fk_ep_num]
GO

ALTER TABLE [dbo].[CharacterAppearance]  WITH CHECK ADD  CONSTRAINT [fk_name] FOREIGN KEY([Name])
REFERENCES [dbo].[Character] ([Name])
GO

ALTER TABLE [dbo].[CharacterAppearance] CHECK CONSTRAINT [fk_name]
GO