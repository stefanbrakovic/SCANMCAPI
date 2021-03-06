USE [Teretana]
GO
/****** Object:  StoredProcedure [dbo].[sp_create_new_Service]    Script Date: 19-Jun-17 20:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_create_new_Service] 
	-- Add the parameters for the stored procedure here
	@ServiceName nvarchar(30),
	@ServiceDescription nvarchar(250),
	@IsActive binary,
	@ServicePrice money,
	@ErrorCode int output,
	@ErrorMessage nvarchar(600) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   begin try
	
		INSERT INTO [dbo].[Services]
           ([ServiceName]
           ,[ServiceDescription]
           ,[IsActive]
           ,[DateCreated])
     VALUES
           (@ServiceName
           ,@ServiceDescription
           ,@IsActive
           ,getdate())
		declare @ServiceId int = (select top 1 ServiceId from [Services]
		where ServiceName = @ServiceName);

		exec sp_create_new_ServicePrice_for_ServiceId @ServiceId = @ServiceId, @Price = @ServicePrice, @ErrorCode = @ErrorCode out, @ErrorMessage = @ErrorMessage out



	end try
	begin catch
		set @ErrorCode = ERROR_NUMBER() ;
		set @ErrorMessage = ERROR_MESSAGE();
	end catch
END
