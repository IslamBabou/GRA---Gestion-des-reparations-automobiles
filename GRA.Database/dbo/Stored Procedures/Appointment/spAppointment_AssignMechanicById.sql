CREATE PROCEDURE [dbo].[spAppointment_AssignMechanicById]
	@MechanicId INT,
	@AppointmentId INT
AS
BEGIN
	UPDATE Appointment SET UserId = @MechanicId 
	WHERE Id = @AppointmentId
END
RETURN 0
