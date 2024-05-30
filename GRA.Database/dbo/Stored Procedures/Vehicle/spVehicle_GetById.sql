CREATE PROCEDURE [dbo].[spVehicle_GetById]
@Id INT

	AS
	BEGIN
		SELECT * FROM [Vehicle] 
		WHERE [Vehicle].Id = @Id;
	END;
GO