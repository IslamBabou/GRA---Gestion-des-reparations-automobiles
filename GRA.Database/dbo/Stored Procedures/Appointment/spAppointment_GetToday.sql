CREATE PROCEDURE [dbo].[spAppointment_GetToday]
	@Today DATETIME
AS
BEGIN
		SELECT a.Id, a.UserId, a.IsCompleted, a.CustomerId, v.NumberPlate, a.DateAppointment, c.FirstName, c.LastName, v.Brand, v.Model, 
		u.FirstName + ' ' + u.LastName
		FROM Appointment a 
		INNER JOIN Vehicle v ON v.Id = a.VehicleId
		INNER JOIN Customer c ON c.Id = a.CustomerId
		INNER JOIN [User] u ON u.Id = a.UserId
		WHERE CAST( a.DateAppointment AS DATE) = @Today
		ORDER BY a.DateAppointment ASC
END
	
RETURN 0
