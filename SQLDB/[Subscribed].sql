USE [Teretana]
GO

/****** Object:  Table [dbo].[Subscribed]    Script Date: 5/8/2017 10:42:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Subscribed](
	[SubscribedId] [int] NOT NULL,
	[DateFrom] [datetime] NOT NULL,
	[DateTo] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
	[PackageId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SubscribedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Subscribed] ADD  DEFAULT (getdate()) FOR [DateFrom]
GO

ALTER TABLE [dbo].[Subscribed]  WITH CHECK ADD FOREIGN KEY([PackageId])
REFERENCES [dbo].[Packages] ([PackageId])
GO

ALTER TABLE [dbo].[Subscribed]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO

ALTER TABLE [dbo].[Subscribed]  WITH CHECK ADD CHECK  (([DateTo]>=getdate()))
GO


