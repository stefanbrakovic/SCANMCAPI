USE [Teretana]
GO

/****** Object:  StoredProcedure [dbo].[sp_update_Package_by_PackageId]    Script Date: 5/18/2017 8:41:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_update_Package_by_PackageId]
	-- Add the parameters for the stored procedure here
	@PackageId int,
	@PackageName nvarchar(50),
	@PackageDescription nvarchar(250),
	@IsActive binary,
	@ErrorCode int output,
	@ErrorMessage nvarchar(600) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   begin try
	UPDATE [dbo].[Packages]
   SET [PackageName] = @PackageName
      ,[PackageDescription] = @PackageDescription
      ,[IsActive] = @IsActive
     
 WHERE PackageId = @PackageId

	end try
	begin catch
		set @ErrorCode = ERROR_NUMBER() ;
		set @ErrorMessage = ERROR_MESSAGE();
	end catch
END

GO


