USE [Teretana]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_User_by_Mail]    Script Date: 19-Jun-17 22:30:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_update_User_by_Mail]
			@FirstName nvarchar(30)
           ,@LastName nvarchar(40)
           ,@Telephone nvarchar(25)
           ,@Mail nvarchar(50)
           
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

		UPDATE [dbo].[Users]
		 SET [FirstName] =@FirstName
		  ,[LastName] = @LastName
		  ,[Telephone] = @Telephone
		
		  
		  ,[UserTypeId] = @UserTypeId
		  ,[GenderId] = @GenderId
		  ,[DateOfBirth] = @DateOfBirth
		  
		  ,[Street] = @Street
		  ,[City] = @City
		  ,[StreetNumber] = @StreetNumber
		 WHERE Mail = @Mail

	end try
	begin catch
		set @ErrorCode = ERROR_NUMBER() ;
		set @ErrorMessage = ERROR_MESSAGE();

	end catch
END
