USE [Teretana]
GO

/****** Object:  Table [dbo].[UserTypes]    Script Date: 5/17/2017 7:11:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserTypes](
	[UserTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](30) NOT NULL,
	[TypeDescription] [nvarchar](30) NULL,
 CONSTRAINT [PK_UserTypes] PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


