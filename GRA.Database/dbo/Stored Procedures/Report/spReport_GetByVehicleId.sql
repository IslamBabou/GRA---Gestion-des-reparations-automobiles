CREATE PROCEDURE [dbo].[spReport_GetByVehicleId]
	@Id INT
AS
BEGIN
	SELECT * FROM Report 
	WHERE VehicleId = @Id
END
RETURN 0
