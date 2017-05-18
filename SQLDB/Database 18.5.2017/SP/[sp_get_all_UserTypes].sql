USE [Teretana]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_all_UserTypes]    Script Date: 5/18/2017 8:40:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[sp_get_all_UserTypes]
	-- Add the parameters for the stored procedure here
	@ErrorCode int output,
	@ErrorMessage nvarchar(600) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    begin try
	
		select * from UserTypes;
	end try
	begin catch
		set @ErrorCode = ERROR_NUMBER() ;
		set @ErrorMessage = ERROR_MESSAGE();
	end catch
END

GO


