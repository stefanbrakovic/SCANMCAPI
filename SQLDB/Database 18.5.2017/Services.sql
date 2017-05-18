USE [Teretana]
GO

/****** Object:  Table [dbo].[Services]    Script Date: 5/18/2017 8:36:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Services](
	[ServiceId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](30) NOT NULL,
	[ServiceDescription] [nvarchar](250) NULL,
	[IsActive] [tinyint] NOT NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK__Services__C51BB00AD346CE8B] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Services] ADD  CONSTRAINT [DF__Services__IsActi__22751F6C]  DEFAULT ((0)) FOR [IsActive]
GO

ALTER TABLE [dbo].[Services] ADD  CONSTRAINT [DF__Services__DateCr__236943A5]  DEFAULT (getdate()) FOR [DateCreated]
GO

