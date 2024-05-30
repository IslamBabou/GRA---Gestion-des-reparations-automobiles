CREATE PROCEDURE [dbo].[spAppointment_Create]
	@Id INT = NULL,
	@CustomerId INT,
	@VehicleId INT,
	@DateAppointment DATETIME,
	@UserId INT = NULL,
	@IsCompleted BIT = 0
AS
BEGIN
	INSERT      INTO [Appointment](
							CustomerId,
							VehicleId,
							DateAppointment,
							UserId,
							IsCompleted
							) 
				VALUES (
							@CustomerId,
							@VehicleId,
							@DateAppointment,
							@UserId,
							@IsCompleted)
END
RETURN 0










	