CREATE PROCEDURE [dbo].[spAppointment_Delete]
	@Id INT
AS
BEGIN
	DELETE FROM Appointment 
	WHERE Id = @Id
END
RETURN 0
