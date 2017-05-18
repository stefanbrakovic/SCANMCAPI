USE [Teretana]
GO

/****** Object:  StoredProcedure [dbo].[sp_delete_UserType_by_TypeName]    Script Date: 5/18/2017 8:39:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[sp_delete_UserType_by_TypeName]
	-- Add the parameters for the stored procedure here
	@TypeName nvarchar(40),
	@ErrorCode int output,
	@ErrorMessage nvarchar(600) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    begin try
	
		delete from UserTypes 
		where TypeName = @TypeName;
	end try
	begin catch
		set @ErrorCode = ERROR_NUMBER() ;
		set @ErrorMessage = ERROR_MESSAGE();
	end catch
END

GO


