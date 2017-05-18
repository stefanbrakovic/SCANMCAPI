USE [Teretana]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_User_by_Mail]    Script Date: 5/18/2017 8:40:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_get_User_by_Mail]
		
			@Mail nvarchar(50),
           
		    @ErrorCode int output,
			@ErrorMessage nvarchar(600) output
AS
BEGIN
	
	begin try
		select  
            FirstName 
           , LastName 
           , Telephone 
           , Mail 
           , UserPassword 
           , UserTypeId 
           , GenderId 
           , DateOfBirth 
           , DateOfRegistration 
           , Street 
           , City 
           , StreetNumber 
     from Users
	 where Mail = @Mail
	end try
	begin catch
		set @ErrorCode = ERROR_NUMBER() ;
		set @ErrorMessage = ERROR_MESSAGE();

	end catch
END

GO


