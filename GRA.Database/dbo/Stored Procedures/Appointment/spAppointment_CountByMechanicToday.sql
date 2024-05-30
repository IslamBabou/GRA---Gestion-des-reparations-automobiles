CREATE PROCEDURE [dbo].[spAppointment_CountByMechanicToday]
	@MechanicId int,
	@Date DATETIME
AS
BEGIN
	SELECT COUNT(*)
	FROM Appointment
	WHERE CAST(DateAppointment AS DATE) = @Date
	AND UserId = @MechanicId
	AND IsCompleted = 0
END
RETURN 0
