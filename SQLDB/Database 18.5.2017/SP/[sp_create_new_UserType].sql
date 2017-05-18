USE [Teretana]
GO

/****** Object:  StoredProcedure [dbo].[sp_create_new_UserType]    Script Date: 5/18/2017 8:38:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_create_new_UserType]
	-- Add the parameters for the stored procedure here
	@TypeName nvarchar(30),
	@TypeDescription nvarchar(300),
	@ErrorCode int output,
	@ErrorMessage nvarchar(600) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    begin try
	
		insert into UserTypes (TypeName,TypeDescription)
		values (@TypeName, @TypeDescription);
	end try
	begin catch
		set @ErrorCode = ERROR_NUMBER() ;
		set @ErrorMessage = ERROR_MESSAGE();
	end catch
END

GO


