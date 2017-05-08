USE [Teretana]
GO

/****** Object:  Table [dbo].[Address]    Script Date: 5/8/2017 10:42:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Address](
	[AddressId] [int] NOT NULL,
	[Street] [nvarchar](40) NOT NULL,
	[City] [nvarchar](40) NOT NULL,
	[StreetNumber] [nvarchar](8) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


