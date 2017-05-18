USE [Teretana]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_all_Users]    Script Date: 5/18/2017 8:39:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[sp_get_all_Users]
		
		
           
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
	
	end try
	begin catch
		set @ErrorCode = ERROR_NUMBER() ;
		set @ErrorMessage = ERROR_MESSAGE();

	end catch
END

GO


