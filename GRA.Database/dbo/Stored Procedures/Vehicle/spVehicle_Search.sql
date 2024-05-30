CREATE PROCEDURE [dbo].[spVehicle_Search]
	@SearchTerm NVARCHAR(20)
AS
BEGIN
	SELECT Id, CustomerId, NumberPlate, Brand, Model, Year, ChassisNumber, FuelType, TransmissionType,
	EngineDescription, Cylinder, BodyType, SizeLitre, FirstVisit  FROM Vehicle
	WHERE NumberPlate LIKE '%' + @SearchTerm + '%'
	OR Brand LIKE '%' + @SearchTerm + '%'
	OR Model LIKE '%' + @SearchTerm + '%'
END
RETURN 0
