USE [Teretana]
GO

/****** Object:  StoredProcedure [dbo].[sp_select_Service_by_ServiceName]    Script Date: 5/18/2017 8:41:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_select_Service_by_ServiceName]
	-- Add the parameters for the stored procedure here
	@ServiceName nvarchar(30),
	@ErrorCode int output,
	@ErrorMessage nvarchar(600) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   begin try
	
		select * from [dbo].[Services]
  
		WHERE ServiceName = @ServiceName

	end try
	begin catch
		set @ErrorCode = ERROR_NUMBER() ;
		set @ErrorMessage = ERROR_MESSAGE();
	end catch
END

GO


