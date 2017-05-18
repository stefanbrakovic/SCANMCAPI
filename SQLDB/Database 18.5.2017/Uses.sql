USE [Teretana]
GO

/****** Object:  Table [dbo].[Uses]    Script Date: 5/18/2017 8:36:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Uses](
	[UsageId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[DateFrom] [datetime] NOT NULL,
	[DateTo] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UsageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Uses]  WITH CHECK ADD  CONSTRAINT [FK_Uses_Service] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO

ALTER TABLE [dbo].[Uses] CHECK CONSTRAINT [FK_Uses_Service]
GO

ALTER TABLE [dbo].[Uses]  WITH CHECK ADD  CONSTRAINT [FK_Uses_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO

ALTER TABLE [dbo].[Uses] CHECK CONSTRAINT [FK_Uses_Users]
GO

