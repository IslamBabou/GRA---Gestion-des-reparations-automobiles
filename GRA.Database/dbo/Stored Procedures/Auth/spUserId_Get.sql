CREATE PROCEDURE [dbo].[spUserId_Get]
	@Email NVARCHAR(50) = NULL,
    @UserId INT = NULL
AS
BEGIN
    SELECT Users.Id 
    FROM [User] AS Users
        WHERE Users.Email = ISNULL (@Email, Users.Email)
            AND Users.Id = ISNULL (@UserId, Users.Id)
END;
GO
