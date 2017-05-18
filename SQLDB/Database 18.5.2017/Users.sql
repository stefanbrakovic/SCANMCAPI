USE [Teretana]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 5/18/2017 8:36:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](40) NOT NULL,
	[Telephone] [nvarchar](25) NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[UserPassword] [nvarchar](500) NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[GenderId] [int] NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[DateOfRegistration] [datetime] NULL,
	[Street] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[StreetNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK__Users__1788CC4C027D74C6] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Users__2724B2D16C5A912B] UNIQUE NONCLUSTERED 
(
	[Mail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

