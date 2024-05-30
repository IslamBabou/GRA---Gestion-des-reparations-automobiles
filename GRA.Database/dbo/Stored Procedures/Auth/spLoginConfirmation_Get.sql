CREATE PROCEDURE [dbo].[spLoginConfirmation_Get]
	@Email NVARCHAR(50)
AS
BEGIN
    SELECT [Auth].[PasswordHash],
        [Auth].[PasswordSalt] 
    FROM Auth AS Auth 
        WHERE Auth.Email = @Email
END;
GO
