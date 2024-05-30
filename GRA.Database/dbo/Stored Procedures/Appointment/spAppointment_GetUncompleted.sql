CREATE PROCEDURE [dbo].[spAppointment_GetUncompleted]
	
AS
BEGIN
		SELECT a.Id, a.CustomerId, v.NumberPlate, a.DateAppointment, c.FirstName, c.LastName, v.Brand, v.Model, 
		u.FirstName + ' ' + u.LastName
		FROM Appointment a 
		INNER JOIN Vehicle v ON v.Id = a.VehicleId
		INNER JOIN Customer c ON c.Id = a.CustomerId
		INNER JOIN [User] u ON u.Id = a.UserId
		WHERE a.IsCompleted = 0 
END
RETURN 0
