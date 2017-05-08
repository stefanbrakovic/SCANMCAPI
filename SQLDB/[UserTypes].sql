USE [Teretana]
GO

/****** Object:  Table [dbo].[UserTypes]    Script Date: 5/8/2017 10:42:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserTypes](
	[UserTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](30) NOT NULL,
	[TypeDescription] [nvarchar](30) NULL
) ON [PRIMARY]

GO


