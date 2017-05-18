USE [Teretana]
GO

/****** Object:  StoredProcedure [dbo].[sp_create_new_User]    Script Date: 5/18/2017 8:38:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_create_new_User]
			@FirstName nvarchar(30)
           ,@LastName nvarchar(40)
           ,@Telephone nvarchar(25)
           ,@Mail nvarchar(50)
           ,@UserPassword nvarchar(50)
           ,@UserTypeId int
           ,@GenderId int
           ,@DateOfBirth datetime
          
           ,@Street nvarchar(50)
           ,@City nvarchar(50)
           ,@StreetNumber nvarchar(50),
		    @ErrorCode int output,
			@ErrorMessage nvarchar(600) output
AS
BEGIN
	
	begin try
		INSERT INTO [dbo].[Users]
           ([FirstName]
           ,[LastName]
           ,[Telephone]
           ,[Mail]
           ,[UserPassword]
           ,[UserTypeId]
           ,[GenderId]
           ,[DateOfBirth]
           ,[DateOfRegistration]
           ,[Street]
           ,[City]
           ,[StreetNumber])
     VALUES
           (@FirstName, @LastName, @Telephone, @Mail, @UserPassword, @UserTypeId, @GenderId, @DateOfBirth, getdate(), @Street , @City, @StreetNumber)
	end try
	begin catch
		set @ErrorCode = ERROR_NUMBER() ;
		set @ErrorMessage = ERROR_MESSAGE();

	end catch
END

GO


