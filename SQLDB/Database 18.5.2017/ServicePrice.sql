USE [Teretana]
GO

/****** Object:  Table [dbo].[ServicePrice]    Script Date: 5/18/2017 8:36:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ServicePrice](
	[ServiceId] [int] NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_ServicePrice] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ServicePrice] ADD  CONSTRAINT [DF_ServicePrice_DateModified]  DEFAULT (getdate()) FOR [DateModified]
GO

ALTER TABLE [dbo].[ServicePrice]  WITH CHECK ADD  CONSTRAINT [FK_ServicePrice_Services] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([ServiceId])
GO

ALTER TABLE [dbo].[ServicePrice] CHECK CONSTRAINT [FK_ServicePrice_Services]
GO

