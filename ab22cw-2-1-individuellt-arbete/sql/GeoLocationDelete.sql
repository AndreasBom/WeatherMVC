
USE [1dv409_ab22cw_Weather]
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andreas Bom>
-- Create date: <20151220>
-- =============================================
CREATE PROCEDURE [weatherApp].[uspGeoLocationDelete]
	-- Add the parameters for the stored procedure here
	@GeoLocationId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [weatherApp].[GeoLocation]
	WHERE GeoLocationId = @GeoLocationId
END
GO
