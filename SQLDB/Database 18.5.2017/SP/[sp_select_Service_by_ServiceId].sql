USE [Teretana]
GO

/****** Object:  StoredProcedure [dbo].[sp_select_Service_by_ServiceId]    Script Date: 5/18/2017 8:40:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_select_Service_by_ServiceId] 
	-- Add the parameters for the stored procedure here
	@ServiceId int,
	@ErrorCode int output,
	@ErrorMessage nvarchar(600) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   begin try
	
		select * from [dbo].[Services]
  
		WHERE ServiceId = @ServiceId

	end try
	begin catch
		set @ErrorCode = ERROR_NUMBER() ;
		set @ErrorMessage = ERROR_MESSAGE();
	end catch
END

GO


