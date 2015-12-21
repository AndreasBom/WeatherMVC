USE [1dv409_ab22cw_Weather]
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andreas Bom>
-- Create date: <20151220>
-- =============================================
CREATE PROCEDURE [weatherApp].[uspGeoLocationInsert]
@Latitude float,
@Longitude float,
@Location varchar
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [weatherApp].[GeoLocation]
	(Latitude,Longitude, Location)
	VALUES(@Latitude, @Longitude, @Location)
END
GO
