USE [Teretana]
GO

/****** Object:  Table [dbo].[Provides]    Script Date: 5/8/2017 10:42:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Provides](
	[ProvidesId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[DateFrom] [datetime] NOT NULL,
	[DateTo] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProvidesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Provides]  WITH CHECK ADD FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([ServiceId])
GO

ALTER TABLE [dbo].[Provides]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO


