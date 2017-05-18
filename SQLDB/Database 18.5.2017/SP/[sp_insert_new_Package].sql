USE [Teretana]
GO

/****** Object:  StoredProcedure [dbo].[sp_insert_new_Package]    Script Date: 5/18/2017 8:40:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insert_new_Package]
	-- Add the parameters for the stored procedure here
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
	INSERT INTO [dbo].[Packages]
           ([PackageName]
           ,[PackageDescription]
           ,[IsActive]
           ,[DateCreated])
     VALUES
           (@PackageName
           ,@PackageDescription
           ,@IsActive
           ,Getdate())

	end try
	begin catch
		set @ErrorCode = ERROR_NUMBER() ;
		set @ErrorMessage = ERROR_MESSAGE();
	end catch
END

GO


