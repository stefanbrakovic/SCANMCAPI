USE [Teretana]
GO
/****** Object:  StoredProcedure [dbo].[sp_create_new_ServicePrice_for_ServiceId]    Script Date: 19-Jun-17 20:56:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_create_new_ServicePrice_for_ServiceId]
	-- Add the parameters for the stored procedure here
	@ServiceId int,
	@Price decimal(18,4),
	@ErrorCode int output,
	@ErrorMessage nvarchar(600) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   begin try
	INSERT INTO [dbo].[ServicePrice]
           ([ServiceId]
         
           ,[Price])
     VALUES
           (@ServiceId
        
           ,@Price)
	end try
	begin catch
		set @ErrorCode = ERROR_NUMBER() ;
		set @ErrorMessage = ERROR_MESSAGE();
	end catch
END
