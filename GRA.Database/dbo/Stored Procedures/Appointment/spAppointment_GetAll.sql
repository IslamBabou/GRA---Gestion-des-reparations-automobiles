CREATE PROCEDURE [dbo].[spAppointment_GetAll]
	
AS
BEGIN
		SELECT Id, CustomerId, VehicleId, DateAppointment, UserId, IsCompleted FROM Appointment
END
RETURN 0
