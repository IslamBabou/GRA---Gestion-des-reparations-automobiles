CREATE PROCEDURE [dbo].[spEmailExists_Get]
	@Email NVARCHAR(50)
AS
BEGIN
    SELECT [Auth].[Email] 
    FROM Auth AS Auth 
        WHERE Auth.Email = @Email
END;
GO
