USE [Teretana]
GO

/****** Object:  Table [dbo].[Packages]    Script Date: 5/18/2017 8:35:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Packages](
	[PackageId] [int] IDENTITY(1,1) NOT NULL,
	[PackageName] [nvarchar](50) NOT NULL,
	[PackageDescription] [nvarchar](250) NULL,
	[IsActive] [binary](1) NOT NULL,
	[DateCreated] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PackageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Packages] ADD  DEFAULT ('Opis paketa') FOR [PackageDescription]
GO

ALTER TABLE [dbo].[Packages] ADD  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[Packages] ADD  DEFAULT (getdate()) FOR [DateCreated]
GO

