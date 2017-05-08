USE [Teretana]
GO

/****** Object:  Table [dbo].[Contains]    Script Date: 5/8/2017 10:42:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contains](
	[ContainsId] [int] NOT NULL,
	[DateAdded] [datetime] NULL,
	[Discount] [decimal](4, 2) NOT NULL,
	[ServiceId] [int] NOT NULL,
	[PackageId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ContainsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Contains] ADD  DEFAULT (getdate()) FOR [DateAdded]
GO

ALTER TABLE [dbo].[Contains] ADD  DEFAULT ((0.00)) FOR [Discount]
GO

ALTER TABLE [dbo].[Contains]  WITH CHECK ADD FOREIGN KEY([PackageId])
REFERENCES [dbo].[Packages] ([PackageId])
GO

ALTER TABLE [dbo].[Contains]  WITH CHECK ADD FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([ServiceId])
GO


