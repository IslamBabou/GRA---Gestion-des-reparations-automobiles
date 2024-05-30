CREATE PROCEDURE [dbo].[spVehicle_UpdateFirstVisitById]
	@Id INT,
	@FirstVisit DATETIME
AS
BEGIN
	UPDATE Vehicle SET FirstVisit = @FirstVisit
	WHERE Id = @Id
END
RETURN 0
