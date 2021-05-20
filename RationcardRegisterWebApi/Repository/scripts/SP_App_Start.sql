IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_App_Start]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SP_App_Start]
GO
--EXEC SP_App_Start '802BF966815B', '192.168.225.22','157.40.125.127','fe804::4b4963960::77107:012%125'
CREATE PROCEDURE [dbo].[SP_App_Start]
	@uniqueClientId VARCHAR(1000),
	@Internal_Ip VARCHAR(100), 
	@Public_Ip VARCHAR(100),
	@Browser_Name VARCHAR(100),
	@Browser_Version VARCHAR(20),
	@Browser_Major VARCHAR(20),
	@Os_Name VARCHAR(100),
	@Os_Version VARCHAR(20)
AS
BEGIN
	
	SET NOCOUNT ON;

	BEGIN TRY

	DECLARE @distId INT, @distName VARCHAR(1000)
	SELECT @distId = Dist_Id, @distName = Dist_Name  FROM Mst_Distributor WHERE Unique_Client_Id = @uniqueClientId

	IF(@distId = 0)
	BEGIN
	 SELECT 'FAILURE', 'Please register in our system first'
	END
	ELSE
	BEGIN
		INSERT INTO App_Start_History
		(
		  Dist_Id
		, Dist_Name
		, Unique_Client_Id
		, Internal_Ip
		, Public_Ip
		, Browser_Name 
		, Browser_Version
		, Browser_Major
		, Os_Name
		, Os_Version
		, Created_Date
		, Last_Updated_Date
		, Updated_By
		)
		VALUES(@distId, @distName, @uniqueClientId,@Internal_Ip,@Public_Ip,@Browser_Name,@Browser_Version,@Browser_Major,@Os_Name,@Os_Version, GETDATE(), GETDATE(), 'SP_App_Start')

		--UserList
		SELECT * FROM Mst_Distributor WHERE Dist_Id = @distId OR IsSuperAdmin = 1
	END
	END TRY
	BEGIN CATCH
		SELECT  
		ERROR_NUMBER() AS ErrorNumber  
		,ERROR_SEVERITY() AS ErrorSeverity  
		,ERROR_STATE() AS ErrorState  
		,ERROR_PROCEDURE() AS ErrorProcedure  
		,ERROR_LINE() AS ErrorLine  
		,ERROR_MESSAGE() AS ErrorMessage;  
	END CATCH
END

