CREATE PROCEDURE [dbo].[spAppointment_UpdateCompletedById]
	@Id INT
AS
BEGIN
	UPDATE Appointment SET IsCompleted = 1
	WHERE Id = @Id
END
RETURN 0
