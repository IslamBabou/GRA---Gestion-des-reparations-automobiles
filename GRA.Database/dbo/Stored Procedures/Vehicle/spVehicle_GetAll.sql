CREATE PROCEDURE [dbo].[spVehicle_GetAll]

	AS
	BEGIN
		SELECT Id, CustomerId, NumberPlate, Brand, Model, Year, ChassisNumber, FuelType, TransmissionType,
	EngineDescription, Cylinder, BodyType, SizeLitre, FirstVisit FROM Vehicle
	END;
GO