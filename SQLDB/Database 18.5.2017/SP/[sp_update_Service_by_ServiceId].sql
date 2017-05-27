USE [Teretana]
GO

/****** Object:  StoredProcedure [dbo].[sp_update_Service_by_ServiceId]    Script Date: 5/18/2017 8:41:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_update_Service_by_ServiceId] 
	-- Add the parameters for the stored procedure here
	@ServiceId int,
	@ServiceName nvarchar(30),
	@ServiceDescription nvarchar(250),
	@IsActive binary,
	@ErrorCode int output,
	@ErrorMessage nvarchar(600) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   begin try
	
		UPDATE [dbo].[Services]
   SET [ServiceName] = @ServiceName
      ,[ServiceDescription] = @ServiceDescription
      ,[IsActive] = @IsActive
      ,[DateCreated] = getdate()
 WHERE ServiceId = @ServiceId

	end try
	begin catch
		set @ErrorCode = ERROR_NUMBER() ;
		set @ErrorMessage = ERROR_MESSAGE();
	end catch
END

GO

