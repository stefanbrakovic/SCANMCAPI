USE [Teretana]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 5/8/2017 10:42:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](40) NOT NULL,
	[AddressId] [int] NULL,
	[Telephone] [nvarchar](25) NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[UserPassword] [nvarchar](50) NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[GenderId] [int] NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[DateOfRegistration] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


