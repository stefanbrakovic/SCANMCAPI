USE [Teretana]
GO
/****** Object:  StoredProcedure [dbo].[sp_create_new_Service]    Script Date: 25-Jun-17 23:01:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[sp_create_new_contains] 
	-- Add the parameters for the stored procedure here
	@ServiceId int,
	@PackageId int,
	@Discount decimal(4,2),
	
	@ErrorCode int output,
	@ErrorMessage nvarchar(600) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   begin try
	
		INSERT INTO [dbo].[Contains]
           (ServiceId
           ,PackageId
           ,Discount
           ,[DateAdded])
     VALUES
           (@ServiceId
           ,@PackageId
           ,@Discount
           ,getdate());

	end try
	begin catch
		set @ErrorCode = ERROR_NUMBER() ;
		set @ErrorMessage = ERROR_MESSAGE();
	end catch
END
