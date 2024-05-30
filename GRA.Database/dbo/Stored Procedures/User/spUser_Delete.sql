CREATE PROCEDURE [dbo].[spUser_Delete]
	@UserId INT
AS
BEGIN
    DECLARE @Email NVARCHAR(50);

    SELECT @Email = [User].Email
    FROM [User]
    WHERE [User].Id = @UserId;

    DELETE FROM Appointment
    WHERE Appointment.UserId = @UserId;

    DELETE FROM [User]
    WHERE [User].Id = @UserId;

    DELETE FROM Auth
    WHERE Auth.Email = @Email;
END;
GO
