CREATE PROCEDURE [dbo].[spVehicle_GetByCustomerId]
		@CustomerId INT

	AS
	BEGIN
		SELECT Id, CustomerId, NumberPlate, Brand, Model, Year, ChassisNumber, FuelType, TransmissionType,
	EngineDescription, Cylinder, BodyType, SizeLitre, FirstVisit FROM [Vehicle] 
		WHERE [Vehicle].CustomerId = @CustomerId;
	END;
GO