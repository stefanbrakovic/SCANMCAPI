USE [Teretana]
GO

/****** Object:  Table [dbo].[Services]    Script Date: 5/8/2017 10:42:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Services](
	[ServiceId] [int] NOT NULL,
	[ServiceName] [nvarchar](30) NOT NULL,
	[ServiceDescription] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


