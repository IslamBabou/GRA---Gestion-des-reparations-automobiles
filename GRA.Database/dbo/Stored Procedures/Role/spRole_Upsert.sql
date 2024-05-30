CREATE PROCEDURE [dbo].[spRole_Upsert]
	@Id INT = NULL,
    @Name NVARCHAR(50)
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM [Role] WHERE Id = @Id)
         BEGIN
                INSERT INTO [Role](
                    Name
                ) VALUES (
                    @Name
                )
        END
    ELSE 
        BEGIN
            UPDATE [Role] 
                SET Name=@Name 
                WHERE Id = @Id
        END
END;
GO
