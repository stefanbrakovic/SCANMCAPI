USE [Teretana]
GO

/****** Object:  Table [dbo].[Subscribed]    Script Date: 5/18/2017 8:36:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Subscribed](
	[SubscribedId] [int] IDENTITY(1,1) NOT NULL,
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

ALTER TABLE [dbo].[Subscribed]  WITH CHECK ADD  CONSTRAINT [FK_Subscribed_Package] FOREIGN KEY([PackageId])
REFERENCES [dbo].[Packages] ([PackageId])
GO

ALTER TABLE [dbo].[Subscribed] CHECK CONSTRAINT [FK_Subscribed_Package]
GO

ALTER TABLE [dbo].[Subscribed]  WITH CHECK ADD  CONSTRAINT [FK_Subscribed_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO

ALTER TABLE [dbo].[Subscribed] CHECK CONSTRAINT [FK_Subscribed_Users]
GO

ALTER TABLE [dbo].[Subscribed]  WITH CHECK ADD CHECK  (([DateTo]>=getdate()))
GO

