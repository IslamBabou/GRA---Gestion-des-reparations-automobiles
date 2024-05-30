CREATE PROCEDURE [dbo].[spRepair_GetByCustomerId]
	@Id INT
AS
BEGIN
	SELECT r.Id, r.Code,c.FirstName, c.LastName, v.NumberPlate, v.Brand, v.Model, r.DateOpening, r.DateClosing, r.Status, r.Total, r.Paid, r.PaiementStatus 
	FROM Repair r
	INNER JOIN Vehicle v ON v.Id = r.VehicleId
	INNER JOIN Customer c ON c.Id = v.CustomerId
	WHERE v.CustomerId = @Id;
END
RETURN 0
